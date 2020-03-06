@ECHO off
REM ****************************************************************************************************************
REM ** --
REM ** This script demonstrates how to use the model compiler to generate source code from a variety
REM ** of XML files that adhere to the 'Nodeset2.xml' format. Please refer to the UA Specifications Part 6
REM ** for more information.
REM ** --
REM ****************************************************************************************************************
SETLOCAL

set MODELCOMPILER=.\Opc.Ua.ModelCompiler.exe
set DOCUGENERATOR=.\Opc.Ua.DocuGenerator.exe
set OUTPUT=.\Published
set SOURCE=YourOpcUaModel
set TARGET=YourOpcUaTargetXml

ECHO Building Model %TARGET%
IF NOT EXIST "%OUTPUT%\%TARGET%" MKDIR "%OUTPUT%\%TARGET%"
ECHO %MODELCOMPILER% -d2 "..\%SOURCE%.xml" -cg "..\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\"
%MODELCOMPILER% -d2 "..\%SOURCE%.xml" -cg "..\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %TARGET% & EXIT /B 3 )

ECHO %DOCUGENERATOR% -m "..\%SOURCE%.xml" -c "..\%SOURCE%.csv" -wo "%OUTPUT%\%TARGET%_Docu.docx"
%DOCUGENERATOR% -m "..\%SOURCE%.xml" -c "..\%SOURCE%.csv" -wo "%OUTPUT%\%TARGET%_Docu.docx"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %TARGET% & EXIT /B 3 )

ECHO Copying Model files to %OUTPUT%\%TARGET%\%SOURCE%
COPY "..\%SOURCE%.xml" "%OUTPUT%\%TARGET%\%SOURCE%.xml"
COPY "..\%SOURCE%.csv" "%OUTPUT%\%TARGET%\%SOURCE%.csv"
DEL /f /q "%OUTPUT%\%TARGET%\*NodeSet.xml"
GOTO theEnd

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:theEnd
ENDLOCAL
