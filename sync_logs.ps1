# Copy the game's own logs into this repo and push them.
# Does not start or talk to the autopilot. Safe to run while the game is open.
#   powershell -File sync_logs.ps1          one push
#   powershell -File sync_logs.ps1 -Watch   keep pushing within about a minute of each change
param([switch]$Watch)
$ErrorActionPreference = "Stop"
$repo = Split-Path -Parent $MyInvocation.MyCommand.Path
$game = "F:\steam\steamapps\common\Stardew Valley"
$dest = Join-Path $repo "play-logs"
$smapiSrc = Join-Path $env:APPDATA "StardewValley\ErrorLogs"
$watchLog = Join-Path $env:TEMP "stardew-log-sync.log"

function Write-Watch([string]$line) {
    $text = "{0} {1}" -f (Get-Date -Format "HH:mm:ss"), $line
    Write-Host $text
    Add-Content -Path $watchLog -Value $text -Encoding UTF8
}

function Find-Journal {
    $found = $null
    Get-ChildItem $game -Directory -ErrorAction SilentlyContinue | ForEach-Object {
        if (-not $found) {
            $hit = Get-ChildItem $_.FullName -Recurse -Filter "Y1_*.md" -ErrorAction SilentlyContinue | Select-Object -First 1
            if ($hit) { $script:found = $_.FullName }
        }
    }
    return $found
}

function Get-Stamp {
    param($journalSrc)
    $times = @()
    $latest = Join-Path $smapiSrc "SMAPI-latest.txt"
    if (Test-Path $latest) { $times += (Get-Item $latest).LastWriteTimeUtc.Ticks }
    if ($journalSrc -and (Test-Path $journalSrc)) {
        $newest = Get-ChildItem $journalSrc -Recurse -File -ErrorAction SilentlyContinue |
            Sort-Object LastWriteTimeUtc -Descending | Select-Object -First 1
        if ($newest) { $times += $newest.LastWriteTimeUtc.Ticks }
    }
    return ($times | Measure-Object -Maximum).Maximum
}

function Sync-Logs {
    $journalSrc = Find-Journal
    New-Item -ItemType Directory -Force -Path (Join-Path $dest "smapi") | Out-Null
    New-Item -ItemType Directory -Force -Path (Join-Path $dest "journal") | Out-Null
    if (Test-Path $smapiSrc) {
        $latest = Join-Path $smapiSrc "SMAPI-latest.txt"
        if (Test-Path $latest) {
            Copy-Item $latest (Join-Path $dest "smapi\SMAPI-latest.txt") -Force
        }
        Get-ChildItem $smapiSrc -Filter "SMAPI-crash.txt" -ErrorAction SilentlyContinue | ForEach-Object {
            Copy-Item $_.FullName (Join-Path $dest "smapi" $_.Name) -Force
        }
    }
    if ($journalSrc -and (Test-Path $journalSrc)) {
        $ErrorActionPreference = "Continue"
        robocopy $journalSrc (Join-Path $dest "journal") /E /NFL /NDL /NJH /NJS /nc /ns /np | Out-Null
        $copyCode = $LASTEXITCODE
        $ErrorActionPreference = "Stop"
        if ($copyCode -ge 8) { throw "robocopy failed: $copyCode" }
    }
    Set-Location $repo
    git add -- play-logs
    $pending = git status --porcelain -- play-logs
    if (-not $pending) {
        Write-Watch "unchanged"
        return
    }
    git -c user.name="578287897" -c user.email="57710382+578287897@users.noreply.github.com" commit -m "Sync game logs."
    git push origin main
    Write-Watch "pushed"
}

if (-not $Watch) {
    Sync-Logs
    exit 0
}

$lock = Join-Path $env:TEMP "stardew-log-sync.lock"
if (Test-Path $lock) {
    $old = 0
    [void][int]::TryParse((Get-Content $lock -ErrorAction SilentlyContinue | Select-Object -First 1), [ref]$old)
    $alive = Get-Process -Id $old -ErrorAction SilentlyContinue
    if ($alive -and $alive.ProcessName -match "powershell") {
        Write-Watch "already watching pid $old"
        exit 0
    }
}
Set-Content -Path $lock -Value $PID -Encoding ASCII
Write-Watch "watch start pid $PID"
$lastStamp = Get-Stamp (Find-Journal)
$lastPush = Get-Date
try {
    while ($true) {
        Start-Sleep -Seconds 20
        $stamp = Get-Stamp (Find-Journal)
        $due = ((Get-Date) - $lastPush).TotalSeconds -ge 60
        if ($stamp -and $stamp -ne $lastStamp -and $due) {
            try {
                Sync-Logs
                $lastPush = Get-Date
                $lastStamp = Get-Stamp (Find-Journal)
            } catch {
                Write-Watch ("sync failed: " + $_.Exception.Message)
            }
        }
    }
} finally {
    if ((Get-Content $lock -ErrorAction SilentlyContinue | Select-Object -First 1) -eq "$PID") {
        Remove-Item $lock -ErrorAction SilentlyContinue
    }
}
