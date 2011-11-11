============================================================================================================
************************************************************************************************************
Microsoft .net Framework 4.0 must be installed on machine where the script will be executed.
************************************************************************************************************
============================================================================================================

Installation:
------------------------------------------------------------------------------------------------------------
1.) 
Copy jeza.ioFTPD.Manager to ioFTPD\scripts.
Folder jeza.ioFTPD.Manager contains next files:
 'ICSharpCode.SharpZipLib.dll'
 'jeza.ioFTPD.Manager.exe'
 'jeza.ioFTPD.Manager.exe.config'
 'jeza.ioFTPD.Framework.dll'
 'managerConfiguration.xml'
 'ReadMe.txt'
 'taglib-sharp.dll'
 'XMLSchema.xsd'
------------------------------------------------------------------------------------------------------------
2.) 
In ioFTPD.ini add :
[FTP_Custom_Commands]
newday            = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe manualNewDay
weekly            = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe weekly
requests          = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe listrequest
request           = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe request
reqdel            = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe delrequest
reqfill           = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe fillrequest
dupe              = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe dupelist

[FTP_SITE_Permissions]
newday		= 1
weekly		= 1

[Scheduler]
NewDay           = 59 23 * * EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe schedulerNewDay
Weekly            = 59 23 * * EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe schedulerWeekly check

[Events]
OnNewDir = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe newdir
OnDelDir = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe deldir

Restart ioFTPD server or execute SITE command REHASH
------------------------------------------------------------------------------------------------------------
3.) 
------------------------------------------------------------------------------------------------------------
4.) Edit 'managerConfiguration.xml'


============================================================================================================
************************************************************************************************************
============================================================================================================
Configuration:
------------------------------------------------------------------------------------------------------------
Task structure:
XMLNode					Value
----------------------- ------------------------------------------------------------------------------------
status					Enabled/Disabled
type					Move/Delete/Copy
realPath				Source folder
virtualPath				Destination folder
format					Format for the new day folder
						{0}  - day in month
						{1}  - week number in year
						{2}  - month in year
						{3}  - year
						Example:
							If todays date is 2011-11-30 
								type=Month	{3:0000}-{2:00}-{0:00} WEEK-{1:00}	-> 2011-12-30 WEEK-53
								type=Day	{2:00}{0:00}						-> 1201
								type=Day	{2}{0}								-> 121
symlink					Real path of the symlink (Must exist on disk)
mode					folder MODE (777, 744,...)
uid						USER ID for the folder
gid						GROUP ID for the folder
cultureInfo				http://www.csharp-examples.net/culture-names/
firstDayOfWeek			Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday
------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------
