============================================================================================================
************************************************************************************************************
Microsoft .net Framework 4.0 must be installed on machine where the script will be executed.
************************************************************************************************************
============================================================================================================

Installation:
------------------------------------------------------------------------------------------------------------
1.) 
Copy jeza.ioFTPD.ArchiveScript to ioFTPD\scripts.
Folder jeza.ioFTPD.ArchiveScript contains next files:
 'archiveConfiguration.xml'
 'Examples.txt'
 'ICSharpCode.SharpZipLib.dll'
 'jeza.ioFTPD.Archive.exe'
 'jeza.ioFTPD.Archive.exe.config'
 'jeza.ioFTPD.Framework.dll'
 'ReadMe.txt'
 'taglib-sharp.dll'
 'XMLSchema.xsd'
------------------------------------------------------------------------------------------------------------
2.) 
In ioFTPD.ini add :
[FTP_Custom_Commands]
archive           = EXEC ..\scripts\jeza.ioFTPD.ArchiveScript\jeza.ioFTPD.Archive.exe
[FTP_SITE_Permissions]
archive		= M
[Scheduler]
Archive           = 59 3 * * EXEC ..\scripts\jeza.ioFTPD.ArchiveScript\jeza.ioFTPD.Archive.exe scheduler

Restart ioFTPD server or execute SITE command REHASH
------------------------------------------------------------------------------------------------------------
3.) 
With some editor (notepadd++, pspad,...) open 'jeza.ioFTPD.Archive.exe.config' and set the log file location
Example:
<add key="FileNameDebug" value="d:\\server\\ioFTPD\\logs\\jeza.ioFTPD.Archive.Debug"/>
------------------------------------------------------------------------------------------------------------
4.) Edit 'archiveConfiguration.xml'


============================================================================================================
************************************************************************************************************
============================================================================================================
Configuration:
------------------------------------------------------------------------------------------------------------
Check file 'Examples.txt' for examples with description.
Task structure:
XMLNode					Value
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
