---------------------------------------------------------------
SITE WHO.........:
argv[1] Can Be 'template=3' Or 'WHO'. 
Use 'template=3' For Replace of Addicts Site Who.exe

jScripts.exe WHO WHO
jScripts.exe WHO bw
jScripts.exe WHO all
jScripts.exe WHO idle
jScripts.exe WHO down
jScripts.exe WHO up
jScripts.exe WHO speed Login

---------------------------------------------------------------
SITE INVITE.....:

jScripts.exe INVITE

---------------------------------------------------------------
SITE USTATS.....:
Shows Users Stats
type    [ALLUP/DN, MNUP/DN, WKUP/DN, DAYUP/DN]
count   [1-MAX_USERS]
section [0-9]

jScripts.exe USTATS <type> <count> <section> 

---------------------------------------------------------------
SITE BUSTATS....:
Shows Users Stats in TCL Friendly Format
type    [ALLUP/DN, MNUP/DN, WKUP/DN, DAYUP/DN]
count   [1-MAX_USERS]
section [0-9]

jScripts.exe BUSTATS <type> <count> <section>

---------------------------------------------------------------
SITE BCUSTATS...:
Shows jScripts_bustats_out_body_complete.
Is Used For TRiAL/QUOTA Script.
section [0-9]

jScripts.exe BCUSTATS <section>

---------------------------------------------------------------
SITE BQUSTATS...:
Is Used For TRiAL/QUOTA Script.
section [0-9]

Shows Only QUOTA USERS.
GROUP1, ..., user1, ... , FLAG1, ... Are Not Included

jScripts.exe BQUSTATS "GROUP1 GROUP2" "user1 user2" "FLAG1 FLAG2" <section>

---------------------------------------------------------------
SITE DAYSTATS..:
Is Used For Day Stats.
type    [ALLUP/DN, MNUP/DN, WKUP/DN, DAYUP/DN]
count   [1-MAX_USERS]
section [0-9]

Shows STATS.
GROUP1, ..., user1, ... , FLAG1, ... Are Not Included

jScripts.exe DAYSTATS "GROUP1 GROUP2" "user1 user2" "FLAG1 FLAG2" <type> <count> <section>

---------------------------------------------------------------
SITE BAN........:

jScripts.exe BAN_ADD <ip>

---------------------------------------------------------------
SITE UNBAN......:
Not Ready Yet

jScripts.exe BAN_DEL <ip>

---------------------------------------------------------------
SITE BANLIST....:

jScripts.exe BAN_LIST

---------------------------------------------------------------
BAN_LOGIN.......:
[FTP_Pre-Command_Events]

user = EXEC jScripts.exe BAN_LOGIN

---------------------------------------------------------------
SITE ADDMASTER..:

jScripts.exe ADDMASTER <login>

---------------------------------------------------------------
SITE DELMASTER..:

jScripts.exe DELMASTER <login>

---------------------------------------------------------------
SITE USER.......:

jScripts.exe USER

---------------------------------------------------------------
SITE SHOW.......:

jScripts.exe SHOW

---------------------------------------------------------------
SITE NFO.......:

jScripts.exe NFO



################################################################################

INSTALATION

[FTP_Pre-Command_Events]
user 			= EXEC jScripts.exe BAN_LOGIN

[FTP_Custom_Commands]
#]=-=[jScripts]=-----------------------------------------
who				= EXEC jScripts.exe WHO WHO
speed			= EXEC jScripts.exe WHO speed
ban				= EXEC jScripts.exe BAN_ADD
banlist			= EXEC jScripts.exe BAN_LIST
addmaster		= EXEC jScripts.exe ADDMASTER
delmaster		= EXEC jScripts.exe DELMASTER
invite			= EXEC jScripts.exe INVITE
ustats			= EXEC jScripts.exe USTATS
bustats			= EXEC jScripts.exe BUSTATS
bcustats		= EXEC jScripts.exe BCUSTATS
bqustats		= EXEC jScripts.exe BQUSTATS
gadduser		= EXEC jScripts.exe WRITEDATE
adduser			= EXEC jScripts.exe WRITEDATE
show			= EXEC jScripts.exe SHOW
user			= EXEC jScripts.exe USER
nfo				= EXEC jScripts.exe NFO
gadduser		= EXEC jScripts.exe GADDUSER
adduser			= EXEC jScripts.exe ADDUSER
deleteuser		= EXEC jScripts.exe DELETEUSER
ADDFLAG			= EXEC jScripts.exe ADDFLAG
DELFLAG			= EXEC jScripts.exe DELFLAG
CHANGEGROUP		= EXEC jScripts.exe CHANGEGROUP
ADDTRIALTOLOG	= EXEC jScripts.exe ADDTRIALTOLOG
CHANGECREDITS	= EXEC jScripts.exe CHANGECREDITS
#]=-=[jScripts]=-----------------------------------------

[FTP_SITE_Permissions]
#]=-=[jScripts]=-----------------------------------------
who				= *
speed			= *
ban				= 1
banlist			= 1
addmaster		= M
delmaster		= M
invite			= *
ustats			= *
bustats			= 1
bcustats		= 1
bqustats		= 1
show			= 1
user			= *
nfo				= *
gadduser		= 1G
adduser			= 1G
deleteuser		= 1
addflag			= 1
delflag			= 1
changegroup		= 1
addtrialtolog	= 1
changecredits	= 1
#]=-=[jScripts]=-----------------------------------------

################################################################################

HISTORY

1.0.9.5
	Added.......: LOG ACTiONS
	Fixed.......: ALL ACTiONS (DELETEUSER, CHANGECREDITS, FLAGS, ADDTOTRIAL)

1.0.9.4
	Fixed.......: CHANGECREDITS

1.0.9.3
	Added.......: CHANGECREDITS
	Fixed.......: 

1.0.9.3
	Added.......: ADDTRIALTOLOG
	Changed.....: Allowed Check

1.0.9.2
	Fixed.......: DELETEUSER, ADDFLAG, DELFLAG
	Added.......: CHANGEGROUP

1.0.9.1
	Added.......: DELETEUSER, ADDFLAG, DELFLAG

1.0.9.0
	Added.......: USER TABLE for LoginCount, DateAdded, ... (SQLite.dll)
	Changed.....: BAN Moved to SQL
	Removed.....: SITE WRITEDATES

1.0.8.4
	Fixed.......: SITE USER (Wrong Stats [3*SectionNumber+1])

1.0.8.3
	Added.......: SITE BQUSTATS

1.0.8.2
	Changed.....: Input Arguments Are Case Insensitive
	Added.......: SITE NFO

1.0.8.1
	Fixed.......: SITE USTATS

1.0.8.0
	Added.......: SITE WRITEDATE
	Added.......: SITE SHOW
	Added.......: SITE USER	
	
1.0.7.0
	Changed.....: WriteDate()
	Changed.....: FindDate()