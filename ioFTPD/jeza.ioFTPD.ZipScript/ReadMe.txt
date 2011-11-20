============================================================================================================
************************************************************************************************************
Microsoft .net Framework 4.0 must be installed on machine where the script will be executed.
************************************************************************************************************
============================================================================================================

Extract ZIP to some location on your DISK...

============================================================================================================
============================================================================================================

Installation:
------------------------------------------------------------------------------------------------------------
Copy folder 'jeza.ioFTPD.ZipScript' to ioFTPD/scripts/

In your favorite editor open 'jeza.ioFTPD.ZipScript.exe.config' and change it so it fits to your site configuration.

ioFTPD.ini:
[Events]
OnUploadComplete	= EXEC ..\scripts\jeza.ioFTPD.ZipScript\jeza.ioFTPD.ZipScript.exe upload
[FTP_Post-Command_Events]
dele				= EXEC ..\scripts\jeza.ioFTPD.ZipScript\jeza.ioFTPD.ZipScript.exe delete
[FTP_Custom_Commands]
rescan            = EXEC ..\scripts\jeza.ioFTPD.ZipScript\jeza.ioFTPD.ZipScript.exe rescan
[FTP_SITE_Permissions]
rescan		= 1V

SITE REHASH or restart ioFTPD server