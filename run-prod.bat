@echo off
set /p COMPOSE_FILE=<env.prod
docker-compose up --build