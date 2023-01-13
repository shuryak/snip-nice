@echo off
setlocal enabledelayedexpansion

set sourceDir=%~1
set targetDir=%~2

set resgenPath="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\resgen.exe"

set fileToResgen[0]="%sourceDir%Resources\Strings"
set fileToResgen[1]="%sourceDir%Resources\Strings.ru-RU"


%resgenPath% /compile !fileToResgen[0]!.txt !fileToResgen[1]!.txt

rem for /l %%n in (0,1,6) do (
rem     copy /Y !fileToResgen[%%n]!.resources "bin\Debug\Resources"
rem )

if not exist "%targetDir%Resources\nul" mkdir "%targetDir%Resources"

for /f "tokens=2 delims==" %%s in ('set fileToResgen[') do copy /Y %%s.resources "%targetDir%Resources"
