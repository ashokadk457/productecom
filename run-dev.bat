@echo off
REM Load COMPOSE_FILE from env.dev
for /f "usebackq tokens=* delims=" %%i in ("env.dev") do set "%%i"

REM Show what was loaded
echo Using Compose Files: %COMPOSE_FILE%

REM Run docker-compose
docker-compose down --volumes --remove-orphans
docker-compose up --build

REM Keep the terminal open after completion
pause