:loop
tasklist /FI "IMAGENAME eq WebSocketServerWorking.exe" 2>NUL | find /I /N "WebSocketServerWorking.exe" >NUL
if "%ERRORLEVEL%" NEQ "0" START "" ".\WebSocketServerWorking\bin\Release\WebSocketServerWorking.exe" "start"
echo will loop

REM goto loop
