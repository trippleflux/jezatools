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
weekly           = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe weekly
newday            = EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe manual
[FTP_SITE_Permissions]
weekly		= 1
newday		= 1
[Scheduler]
NewDay           = 59 23 * * EXEC ..\scripts\jeza.ioFTPD.Manager\jeza.ioFTPD.Manager.exe scheduler

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
actionType				Move/Delete/Copy
source					Source folder
destination				Destination folder
action
		id				TotalUsedSpace/TotalFolderUsedSpace/TotalFreeSpace/TotalFolderCount/DateOlder
		value			Number
		minFolderAction	Number
regExpressionExclude	Regular expression for excluding specified folders
regExpressionInclude	Regular expression for including only specified folders
------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------
