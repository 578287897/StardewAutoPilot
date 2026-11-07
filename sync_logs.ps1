# Copy the game's own logs into this repo and push them.
# Does not start or talk to the autopilot. Safe to run while the game is open.
$ErrorActionPreference = "Stop"
$repo = Split-Path -Parent $MyInvocation.MyCommand.Path
$game = "F:\steam\steamapps\common\Stardew Valley"
$dest = Join-Path $repo "play-logs"
$smapiSrc = Join-Path $env:APPDATA "StardewValley\ErrorLogs"
# Find the play-journal folder by its day files, so the script does not depend on a Chinese path.
$journalSrc = $null
Get-ChildItem $game -Directory -ErrorAction SilentlyContinue | ForEach-Object {
    if (-not $journalSrc) {
        $hit = Get-ChildItem $_.FullName -Recurse -Filter "Y1_*.md" -ErrorAction SilentlyContinue | Select-Object -First 1
        if ($hit) { $script:journalSrc = $_.FullName }
    }
}

New-Item -ItemType Directory -Force -Path (Join-Path $dest "smapi") | Out-Null
New-Item -ItemType Directory -Force -Path (Join-Path $dest "journal") | Out-Null

if (Test-Path $smapiSrc) {
    Copy-Item (Join-Path $smapiSrc "SMAPI-latest.txt") (Join-Path $dest "smapi\SMAPI-latest.txt") -Force
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
    Write-Host "play-logs unchanged"
    exit 0
}
git -c user.name="578287897" -c user.email="57710382+578287897@users.noreply.github.com" commit -m "Sync game logs."
git push origin main
Write-Host "pushed play-logs"
