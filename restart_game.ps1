# Reload the last save after the in-game LLM asked for a restart.
# Started detached. Waits until the old agent process exits, then relaunches the game.
param(
    [string]$SaveName = "AI_453272148",
    [int]$AgentPid = 0
)
$ErrorActionPreference = "Continue"
$game = "F:\steam\steamapps\common\Stardew Valley"
$repo = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Content -Path (Join-Path $env:TEMP "stardew-restart-at.txt") -Value ([DateTimeOffset]::UtcNow.ToUnixTimeSeconds()) -Encoding ASCII

if ($AgentPid -gt 0) {
    Wait-Process -Id $AgentPid -Timeout 30 -ErrorAction SilentlyContinue
    Start-Sleep -Seconds 1
}
Get-CimInstance Win32_Process -Filter "Name='python.exe'" | Where-Object { $_.CommandLine -like '*autopilot.py*' } | ForEach-Object {
    Stop-Process -Id $_.ProcessId -Force -ErrorAction SilentlyContinue
}
$smapi = Get-Process -Name "StardewModdingAPI" -ErrorAction SilentlyContinue
if ($smapi) { taskkill /F /PID $smapi.Id /T | Out-Null }
Start-Sleep -Seconds 2

$exe = Join-Path $game "StardewModdingAPI.exe"
Invoke-CimMethod -ClassName Win32_Process -MethodName Create -Arguments @{ CommandLine = "`"$exe`""; CurrentDirectory = $game } | Out-Null
$ready = $false
for ($i = 0; $i -lt 40; $i++) {
    Start-Sleep -Seconds 3
    try {
        $ping = Invoke-WebRequest -UseBasicParsing http://localhost:8765/ping -TimeoutSec 5
        if ($ping.Content) { break }
    } catch {}
}
for ($i = 0; $i -lt 20; $i++) {
    try {
        Invoke-RestMethod -Method Post -Uri http://localhost:8765/load_save -ContentType "application/json" -Body (@{ name = $SaveName } | ConvertTo-Json) -TimeoutSec 20 | Out-Null
        break
    } catch { Start-Sleep -Seconds 3 }
}
for ($i = 0; $i -lt 40; $i++) {
    Start-Sleep -Seconds 3
    try {
        $s = Invoke-RestMethod http://localhost:8765/state -TimeoutSec 8
        if ($s.ready -and -not $s.menu) { $ready = $true; break }
    } catch {}
}
if (-not $ready) { exit 1 }
$starter = Join-Path $env:TEMP "start-autopilot.ps1"
if (Test-Path $starter) {
    $cmd = "powershell.exe -NoProfile -ExecutionPolicy Bypass -File `"$starter`""
    Invoke-CimMethod -ClassName Win32_Process -MethodName Create -Arguments @{ CommandLine = $cmd; CurrentDirectory = $env:TEMP } | Out-Null
}
exit 0
