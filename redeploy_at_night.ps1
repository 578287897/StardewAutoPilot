# Wait until the agent has gone to bed (and tomorrow's script is prepared), then deploy the mod,
# restart the game and resume continuous play. Nothing is lost: the night's save has already happened.
#   powershell -File redeploy_at_night.ps1 -Log agent\runs\now.log -NextLog agent\runs\next.log [-AnyNight]
param([Parameter(Mandatory = $true)][string]$Log,      # the running agent's log
      [Parameter(Mandatory = $true)][string]$NextLog,  # log file for the restarted agent
      [switch]$AnyNight)  # also when the farmer passes out at 2:00 (no bedtime, so no "script ready" line)

$agent = Join-Path $PSScriptRoot "agent"
$cfg = Get-Content (Join-Path $agent "config.json") -Raw -Encoding utf8 | ConvertFrom-Json
$game = if ($cfg.game_path) { $cfg.game_path } else { $env:STARDEW_GAME_PATH }
$profileName = if ($cfg.profile) { $cfg.profile } else { "default" }
$start = (Get-Content $Log -Encoding utf8).Count

# 1. wait for "tomorrow's script is ready" (written after the sleep action succeeded)
while (-not $AnyNight) {
    $new = Get-Content $Log -Encoding utf8 | Select-Object -Skip $start
    if ($new -match "的脚本已准备好|明日脚本生成失败") { break }
    Start-Sleep 5
}
# 2. wait until the new morning is loaded AND the save file was rewritten after bedtime
#    (/state can still report the old day as ready for a few seconds after going to bed)
#    The game flips the date early in the night, before saving: so require the save FILE to be rewritten after
#    this point, then the new day to be fully started (the mod reports ready only after SMAPI's DayStarted).
$saveName = (Get-Content (Join-Path $agent "memory\$profileName\save_name.txt")).Trim()
$saveFile = "$env:APPDATA\StardewValley\Saves\$saveName\$saveName"
$saveBefore = (Get-Item $saveFile).LastWriteTime
while ($true) {
    try {
        $s = Invoke-RestMethod http://localhost:8765/state -TimeoutSec 5
        $saved = (Get-Item $saveFile).LastWriteTime -gt $saveBefore
        if ($saved -and $s.ready -and -not $s.menu -and $s.time -le 610) { break }
    } catch {}
    Start-Sleep 3
}
Start-Sleep 10  # let the save file finish flushing
"new morning: day $($s.day) $($s.time_str)"

# 3. stop agent + game, deploy, restart
Get-CimInstance Win32_Process -Filter "Name='py.exe' or Name='python.exe'" | Where-Object { $_.CommandLine -like '*autopilot.py*' } | ForEach-Object { Stop-Process -Id $_.ProcessId -Force }
Stop-Process -Name StardewModdingAPI -Force -ErrorAction SilentlyContinue
Start-Sleep 3
Set-Location (Join-Path $PSScriptRoot "mod")
dotnet build -c Release 2>&1 | Select-String "error|Build succeeded" | Select-Object -First 3
Start-Process -FilePath "$game\StardewModdingAPI.exe" -WorkingDirectory $game
for ($i = 0; $i -lt 60; $i++) { Start-Sleep 3; try { if ((Invoke-WebRequest -UseBasicParsing http://localhost:8765/ping -TimeoutSec 5).Content) { break } } catch {} }

# 4. resume (the agent loads the save itself from the title screen)
Start-Process -FilePath "py" -ArgumentList "autopilot.py" -WorkingDirectory $agent -RedirectStandardOutput $NextLog -RedirectStandardError "$NextLog.err" -WindowStyle Hidden
"redeployed and resumed; log: $NextLog"
