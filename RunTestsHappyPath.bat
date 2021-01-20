set Module=%1
set Filename=%Module%_%date:~-4,4%%date:~-7,2%%date:~-10,2%_%time:~0,2%_%time:~3,2%_%time:~6,2%
set Filename=%Filename: =%
set dir=%date:~-4,4%%date:~-7,2%%date:~-10,2%
set ProjectPath=C:\Users\javed\Documents\SAFAutomation\
set ResultDir=%ProjectPath%TestResults\
set MSTestPath="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\MSTest.exe"
set specflowPath=%ProjectPath%packages\SpecFlow.2.4.1\tools\specflow.exe
set SharedPath="\\GDC-Data\Team\Test Team\SALT\Automation\Daily_Execution_Results\%dir%\"
set CSCPath="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
set convertTRXPath =C:\Users\khanj\Documents\Automation\FuncationaAutomation_Latest\ConvertTrxToHtml

if not exist %ResultDir%  md "C:\Users\khanj\Documents\Automation\FuncationaAutomation_Latest\TestResults"

echo %Module%

%MSTestPath% /testcontainer:%ProjectPath%SpecFlowProject\bin\Debug\SpecFlowProject.dll /category:%Module% /resultsfile:%ResultDir%%FileName%.trx /testsettings:%ProjectPath%SpecFlowProject\TestSettings.testsettings

%specflowPath% mstestexecutionreport %ProjectPath%SpecFlowProject\SpecFlowProject.csproj /testResult:%ResultDir%%FileName%.trx /out:%ResultDir%%FileName%.html

if not exist %SharedPath% md %SharedPath%

copy %ResultDir%%FileName%.trx %SharedPath%%FileName%.trx
copy %ResultDir%%FileName%.html %SharedPath%%FileName%.html
copy %ResultDir%html_%Filename%.html %SharedPath%html_%FileName%.html
