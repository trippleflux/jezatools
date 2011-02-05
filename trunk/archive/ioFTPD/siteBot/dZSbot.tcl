#########################################################
#  This script is part of zipscript-c made by dark0n3   #
#		Ported by B0unTy for ioFTPD community			#
#########################################################
# BASIC CONFIG											#
#########################################################
set location(IODIR)			"C:/ioFTPD"
set location(IOLOG)			"C:/ioFTPD/logs"
set location(RULES)			"C:/ioFTPD/text/ftp/rules.msg"
# need ioA 1.0.5+
set location(NUKESLOG)		"C:/ioFTPD/scripts/logs/ioA.nuke.log"
set location(UNNUKESLOG)	"C:/ioFTPD/scripts/logs/ioA.unnuke.log"
set location(CMDSLOG)		"C:/ioFTPD/scripts/logs/ioACommands.log"

# IF YOU DON'T KNOW WHAT TO CHANGE !!! DON'T TOUCH ANY MSGTYPES !!!
set msgtypes(RACE)		"IMDB ALLOCINE NFOURL NFO NEWDATE WIPE NEWDIR BLA DELDIR BLE INCOMPLETE NUKE UNNUKE PRE WARN RACE SFV UPDATE HALFWAY NEWLEADER COMPLETE STATS"
set msgtypes(DEFAULT)	"INVITE LOGIN LOGOUT REQUEST REQFILLED REQDEL GIVE TAKE BTRIAL OPEN CLOSE IOJN"

set sitename		"PiMPEK"
set cmdpre			"!p"

# SETUP THIS ONLY IF YOU HAVE BNC for your SERVER
set bnc(LIST)		"pimpek.no-ip.com:43210"
set bnc(USER)		"sitebot"
set bnc(PASS)		"sitebotpass"
set bnc(TIMEOUT)	3

# EXTERNAL EXE PATH CONFIGURATION HERE
set binary(PASSCHK)		"C:/ioFTPD/scripts/dZSbot/bin/ioPasswd.exe"
set binary(DF)			"C:/ioFTPD/scripts/dZSbot/bin/ioDiskSpace.exe"
set binary(NCFTPLS)		"C:/ioFTPD/scripts/dZSbot/bin/ncftpls.exe"
set binary(CURL)		"C:/ioFTPD/scripts/dZSbot/bin/curl.exe"
set binary(FIND)		"C:/ioFTPD/scripts/dZSbot/bin/find.exe"
set binary(IOA)			"C:/ioFTPD/scripts/ioA/ioa.exe"
set binary(IOGROUP)		"C:/ioFTPD/scripts/dZSbot/iogroups/iogroups.exe"
set binary(UPTIME)		"C:/ioFTPD/scripts/dZSbot/iouptime/ioUptime.exe"
set binary(SITEKILL)	"C:/ioFTPD/scripts/dZSbot/sitekill/sitekill.exe"
#set binary(WHO)			"C:/ioFTPD/scripts/dZSbot/sitewho/sitewho.exe"
set binary(WHO)			"C:/ioFTPD/system/jScripts.exe"
set binary(UNDUPE)		"C:/ioFTPD/scripts/dZSbot/undupe.exe" ;# THIS REQUIRE DUPELOGGER 1.1

# SETUP HERE YOUR SECTIONS
set sections		"0day mp3 movies utils games xxx series request"

# !!! THE LOGICAL DRIVE LETTER SHOULD BE WRITED IN UPPER CASE !!!
# !!!   Exemple: C: or D: or E: ...but without \ at the end   !!!
# !!!   OTHER ARGS SHOULD RESPECT $sections variable ABOVE    !!!
set device(0)		"D: mp3 movies request"
set device(1)		"F: 0day games utils series"
set device(TOTAL)	2
set device(COLUMN)	2

#########################################################
# SETUP EATCH PATH YOU NEED LIKE THIS					#
# set paths(section)	"/vfs_path/*" (vfs format)		#
# set type(section)		"RACE"							#
# set chanlist(section)	"#chan1 #chan2"					#
#########################################################
set paths(0day)			"/0day/*"
set type(0day)			"RACE"
set chanlist(0day)		"#pimpek"

set paths(movies)		"/movies/*"
set type(movies)		"RACE"
set chanlist(movies)		"#pimpek"

set paths(mp3)			"/mp3/*"
set type(mp3)			"RACE"
set chanlist(mp3)		"#pimpek"

set paths(utils)		"/utils/*"
set type(utils)			"RACE"
set chanlist(utils)		"#pimpek"

set paths(request)		"/request/*"
set type(request)		"RACE"
set chanlist(request)		"#pimpek"

set paths(series)		"/series/*"
set type(series)		"RACE"
set chanlist(series)		"#pimpek"

set paths(xxx)			"/xxx/*"
set type(xxx)			"RACE"
set chanlist(xxx)		"#pimpek"

set paths(games)		"/games/*"
set type(games)			"RACE"
set chanlist(games)		"#pimpek"

set chanlist(DEFAULT)	"#pimpek"
set chanlist(INVITE)	"#pimpek"
set chanlist(WELCOME)	"#pimpek"

#########################################################
# MSGTYPES: ENABLE=0 or DISABLE=1 announces
set disable(NEWDIR)			0
set disable(BLA)			0
set disable(DELDIR)			0
set disable(BLE)			0
set disable(WIPE)			1
set disable(PRE)			0
set disable(INVITE)			0
set disable(NUKE)			0
set disable(UNNUKE)			0
set disable(LOGIN)			1
set disable(LOGOUT)			1
set disable(NEWDATE)		0
set disable(REQUEST)		0
set disable(REQFILLED)		0
set disable(REQDEL)			0
set disable(INCOMPLETE)		0
set disable(GIVE)			0
set disable(TAKE)			0
set disable(IMDB)			0
set disable(ALLOCINE)		0
set disable(NFOURL)			0
set disable(NFO)			0
set disable(IOJN)			0

# ZIPSCRIPT: ENABLE=0 or DISABLE=1 announces
set disable(WARN)			0
set disable(RACE)			0
set disable(SFV)			1
set disable(UPDATE)			0
set disable(HALFWAY)		0
set disable(NEWLEADER)		0
set disable(COMPLETE)		0
set disable(STATS)			0

# SITEWHO: ENABLE=0 or DISABLE=1 announces
set disable(WHO)			0
set disable(SPEED)			0
set disable(BW)				0
set disable(UPLOADER)		0
set disable(LEECHER)		0
set disable(IDLER)			0

# BTRIAL: ENABLE=0 or DISABLE=1 announces
set disable(BTRIAL)			1

# OCSCRIPT: ENABLE=0 or DISABLE=1 announces
set disable(OPEN)			0
set disable(CLOSE)			0

# INDEPENDENTS: ENABLE=0 or DISABLE=1 announces
set disable(WELCOME)		1
set disable(NCFTPLS)		0
set disable(REQUESTSHOW)	0
set disable(REQUESTIRC)		0
set disable(REQDELIRC)		0
set disable(REQFILLEDIRC)	0
set disable(SEARCHIRC)		0
set disable(MSGINVITE)		1
set disable(BADMSGINVITE)	1
set disable(FREE)			0
set disable(NUKES)			0
set disable(UNNUKES)		0
set disable(PRES)			1
set disable(AFFILS)			1
set disable(BANNED)			1
set disable(RULES)			1
set disable(GETRULES)		1
set disable(GETNFO)			1
set disable(UPTIME)			0
set disable(APPROVE)		0
set disable(VERSION)		0
set disable(DEFAULT)		0

#########################################################
# AFFILS CONFIG, EDIT THIS IF YOU NEED IT				#
# set affils(section) "GRP1 GRP2 GRP3"					#
#########################################################
set affils(mp3)	"PiMPEK"
#set affils(DIVX)	"GRP4 GRP5 GRP6"
#set affils(MP3)		"GRP7 GRP8 GRP9"
#set affils(0DAY)	"GRP10 GRP11 GRP12"

#########################################################
# BANNED GRPS CONFIG, EDIT THIS IF YOU NEED IT			#
# set banned(section) "GRP1 GRP2 GRP3"					#
#########################################################
set banned(mp3)	"PiMPEK"
#set banned(DIVX)	"GRP4 GRP5 GRP6"
#set banned(MP3)		"GRP7 GRP8 GRP9"
#set banned(0DAY)	"GRP10 GRP11 GRP12"

#########################################################
# IMDB CONFIG: ENABLE=0 or DISABLE=1					#
# work only if "set disable(IMDB) 0"					#
#########################################################
set disable(IMDBANNOUNCE)	0  ; # announce imdb infos in channel
set disable(IMDBURL)		1  ; # create imdb .url link in dir
set disable(IMDBTAG)		1  ; # create a tag in dir with imdb infos
set disable(IMDBMSG)		0  ; # create file(s) with imdb infos stored in dir

# setup here the filenames you want imdb infos stored in dir
set IMDBMSG_MSG ".ioFTPD.message imdb.nfo"

# setup the IMDBTAG "dir" or "file"
set IMDBTAG "dir"

# IMDBMSG STYLE if you use project-zs set 0 else ioZS set 1
set IMDBMSG_STYLE 1

# set IMDB_ALT 0 = use the internal tcl http 2.4 package
# set IMDB_ALT 1 = use the external curl.exe
set IMDB_ALT 0

#########################################################
# IOA CONFIG, EDIT THIS IF YOU USE IOA.exe from WarC	#
#########################################################
## Complete path to requests file. Make sure it exist
set ioa(REQFILE) "d:/request/.ioFTPD.message"

# The max. number for searches output to give back
set ioa(MAXSRCH) 15

# set to 0 = all results will be sent as private message (default)
# set to 1 = all results will be sent publicly to the DEFAULT channel
set ioa(SEARCHIRC)	0
set ioa(REQUESTS)	1
set ioa(NUKES)		0
set ioa(UNNUKES)	0
set ioa(PRES)		0

# The max. number for nukes/unnukes/pres output
set ioa(MAX) 30

# The default number for nukes/unnukes/pres output
set ioa(DEFAULT) 10

# experimental settings are: "TRUE FALSE" (uppercase)
set ioa(GMT) "TRUE"

#########################################################
# POST STATS CONFIG:									#
#########################################################
# set to 0 = all results will be sent as private message (default)
# set to 1 = all results will be sent publicly to the channel
set poststats(OUTPUT) 1

# The max. number for poststats output
set poststats(MAX) 30

# The default number for poststats output
set poststats(DEFAULT) 10

#########################################################
# IRCSTATS CONFIG:										#
#########################################################
# ENABLE=0 or DISABLE=1 IRCSTATS announce
set disable(IRCSTATS) 1

# set the USERSTATS requested for output
# settings are: "alldn allup monthup monthdn wkup wkdn dayup daydn" (lowercase)
set ircstats(USR) "dayup"

# set the GROUPSTATS requested for output
# settings are: "alldn allup monthup monthdn wkup wkdn dayup daydn" (lowercase)
set ircstats(GRP) ""

# set the max TOP number to output (3 = will output TOP 3)
set ircstats(MAX) 3

# set the time frequency for ircstats output
# you can add multiple 'bind time - ......' lines to set different times
# syntax: bind time - "<mins> <hour> <day> <month> <year>" proc_ircstats
# <mins> <hour> <day> <month> are two characters long. <year> is four characters long.
# !!! If you modify the time frequency you should restart your eggy (not rehash) !!!

bind time - "00 00 * * *" proc_ircstats ; # here is every days @ 00:00
#bind time - "00 * * * *" proc_ircstats ; # here is every hours

#########################################################
# SITEKILL CONFIG:										#
#########################################################
# ENABLE=0 or DISABLE=1 SITEKILL usage
set disable(SITEKILL) 0

# set the SiteKill exceptions (!!READ MANUAL!!)
set SK_EXCEPTIONS "group!=ioftpd"

# set the IdleTime Limit
set IT_LIMIT 120

#########################################################
# UNDUPE CONFIG:										#
#########################################################
# ENABLE=0 or DISABLE=1 UNDUPE usage
set disable(UNDUPE) 0

# set UNDUPE_ALT 0 = undupe for NEWDIR 3.2.0+ users (default)
# set UNDUPE_ALT 1 = undupe for DUPELOGGER 1.1 users
# !!! if you use DUPELOGGER 1.1 you can use wildcards in argument !!!
set UNDUPE_ALT 0


#########################################################
# FIND CONFIG:											#
#########################################################
# REQUIRED FOR !APPROVE & !INCOMPLETE
# set here all physical paths you want find.exe to monitor
# syntax : set find_path "<physical/path1>|<maxdepth#> <physical/path2>|<maxdepth#> ...etc"
# You can adjust the dated paths using cookies below (then don't forget to adjust maxdepth)
# date syntax: day=%d , week=%W , month=%m , year(2digits)=%y , year(4digits)=%Y
set find_path "f:/0day|1 f:/games|1 f:/utils|1 f:/xxx|1 d:/mp3|1 e:/movies|1 f:/series|3"

# set here your incomplete tag
set inc_tag "\[iNCOMPLETE\]-*"

#########################################################
# ADVANCED CONFIG, EDIT _VERY_ CAREFULLY				#
#########################################################
# !!! denypost is CASE SENSITIVE !!!
set denypost ""
set hidenuke "UNKNOWN"

## Defining variables for announce
#
# Special variables:
#  %pf      = path filter, must be the first parameter and contain full path of the release, it defines:
#   %release = Last directory in path ( /site/xxx/marissa-exxtasy/cd1 => cd1 )
#   %path    = Second last directory in path ( /site/xxx/marissa-exxtasy/cd1 => marissa-exxtasy )
#   %relname = all directories after those defined in paths
#              ( paths(ISO) = "/site/xxx/" does: /site/xxx/marissa-exxtasy/cd1 => marissa-exxtasy/cd1 )
#

# !!!  MODIFY _VERY_ CAREFULLY  ANY VARIABLES BELOW  !!!
# !!! IF YOU DON'T KNOW WHAT CHANGE !!! DON'T CHANGE !!!

set variables(NEWDIR)		"%pf %user %group"
set variables(BLA)		"%pf %user %group %tagline"
set variables(DELDIR)		"%pf %user %group"
set variables(BLE)		"%pf %user %group %tagline"
set variables(LOGIN)		"%service %user %group %tagline %host"
set variables(LOGOUT)		"%service %user %group %tagline %host"
set variables(INVITE)		"%user %group %ircnick"
set variables(WIPE)			"%pf %user %group %dirs %files %size"
set variables(PRE)			"%pf %user %group %files %mbytes %type %desc %ufo"
set variables(PREMP3)		"%pf %user %group %files %mbytes %type %desc %ufo %genre %kbit %year"
set variables(REQUEST)		"%user %group %request"
set variables(REQFILLED)	"%user %group %request"
set variables(REQDEL)		"%user %group %request"
set variables(NEWDATE)		"%pf"
set variables(IMDB)			"%pf %url %title %name %genre %plot %rating %votes %time %budget %screens %tagline %top250 %mpaa %country %language %soundmix %user %group"
set variables(ALLOCINE)		"%pf %url %user %group"
set variables(NFOURL)		"%pf %url %user %group"
set variables(NFO)			"%pf %no %user %group"
set variables(GIVE)			"%user %group %mb %target"
set variables(TAKE)			"%user %group %mb %target"
set variables(DEFAULT)		"%pf %msg"
set variables(IOJN)		"%msg"

# BTRIAL VARIABLE
set variables(BTRIAL)		"%msg"

# OCSCRIPT VARIABLES
set variables(OPEN)			"%user %group"
set variables(CLOSE)		"%user %group %reason"

## Converts empty or zero variable to something else if defined
#
# Example:
#  set zeroconvert(%user) "NoOne"

set zeroconvert(%group) ""

## Splits output line to smaller pieces
#
# To disable set it to "\n"

set splitter(CHAR) "\n"

## RANDOMIZING OUTPUT
#
# Example:
#  set random(NEWDIR-0)       "\[%bold%section%bold\] %user@%group creates a directory called %release"
#  set random(NEWDIR-1)       "\[%bold%section%bold\] %user@%group makes a directory called %release"
#  set random(NEWDIR-2)       "\[%bold%section%bold\] %user@%group does mkdir %release"
#   TYPE --------^   ^
#         ID --------^
#
#  set announce(NEWDIR) "random 3"»
#   TYPE ---------^        ^    ^
#         RANDOM ----------^    ^
#             # OF IDS ---------^

set announce(NEWDIR)		"\[%bold%section%bold\] %color07%boldnew%bold%color %bold%path/%release%bold By %bold%user%bold"
set announce(BLA)		"\[%bold%section%bold\] %color07%boldnew%bold%color %bold%path/%release%bold By %bold%user%bold/%group (%uline%tagline%uline)"
set announce(DELDIR)		"\[%bold%section%bold\] %color04%bolddelete%bold%color %path/%bold%release%bold by %bold%user%bold"
set announce(BLE)		"\[%bold%section%bold\] %color04%bolddelete%bold%color %path/%bold%release%bold by %bold%user%bold/%group (%uline%tagline%uline)"
set announce(LOGIN)		"\[%bold%sitename%bold\] %color07%boldlogin%bold%color %bold%user%bold"
set announce(LOGOUT)		"\[%bold%sitename%bold\] %color07%boldlogout%bold%color %bold%user%bold"
set announce(NUKE)		"\[%color04%boldNUKE%bold%color\] %path/%bold%release%bold %ulinenuked %mult%ulinex by %bold%nuker%bold - reason: %reason - nukees: %nukees"
set announce(UNNUKE)		"\[%color04%boldUNNUKE%bold%color\] %path/%bold%release%bold %ulineunnuked %mult%ulinex by %bold%nuker%bold - reason: %bold%reason%bold - returned: %nukees"
set announce(INVITE)		"\[%boldiNViTE%bold\] %bold%user%bold Is Ready For Action as %bold%ircnick%bold"
set announce(MSGINVITE)		"\[%bold%color07iNViTE%color%bold\] %bold%user%bold invited himself as %bold%ircnick%bold"
set announce(BADMSGINVITE)	"\[%bold%color07iNViTE%color%bold\] %bold%ircnick%bold (%host) tried to invite himself with invalid login!"
set announce(WIPE)		"\[%bold%section%bold\] %color04%boldwipe%bold%color %path/%bold%release%bold by %bold%user%bold %sizeMB"
set announce(NEWDATE)		"\[%bold%section%bold\] %color07%boldnew%bold%color %bold%path%bold/%bold%release%bold"
set announce(PRE)		"\[%color04%bold%section-pre%bold%color\] by %color04%bold%group%bold%color %bold%release%bold \[%bold%mbytes%boldM in %bold%files%boldF\] "
set announce(PREMP3)		"\[%color04%bold%section-pre%bold%color\] by %color04%bold%group%bold%color %bold%release%bold \[%bold%mbytes%boldM in %bold%files%boldF - %bold%genre%bold - %bold%kbit%boldkbits - %bold%year%bold\]"
set announce(REQUEST)		"\[%boldrequest%bold\] %color07%boldnew%bold%color %bold%request%bold by %bold%user%bold"
set announce(REQUESTIRC)	"\[%boldrequest%bold\] %color07%boldnew%bold%color %bold%request%bold by %bold%user%bold"
set announce(REQFILLED)		"\[%boldrequest%bold\] %color12%boldfilled%bold%color %bold%request%bold by %bold%user%bold"
set announce(REQDEL)		"\[%boldrequest%bold\] %color04%bolddelete%bold%color %bold%request%bold by %bold%user%bold"
set announce(IMDB)		"\[%bold%section%bold\] %color03%boldimdb%bold%color %bold%title%bold Directed by %name \n\[%bold%section%bold\] %color03%boldimdb%bold%color rated %uline%rating%uline (%votes votes) \n\[%bold%section%bold\] %color03%boldimdb%bold%color genre: %genre - runtime: %timemin \n\[%bold%section%bold\] %color03%boldimdb%bold%color URL: %uline%url%uline >> %boldBudget:%bold %budget \n\[%bold%section%bold\] %color03%boldimdb%bold%color Opening Weekend: (USA) %screens"
set announce(ALLOCINE)		"\[%bold%section%bold\] %color03%boldurl%bold%color %bold%path%bold (%uline%url%uline)"
set announce(NFOURL)		"\[%bold%section%bold\] %color03%boldurl%bold%color %bold%path%bold (%uline%url%uline)"
set announce(NFO)		"\[%bold%section%bold\] %color03%boldnfo%bold%color %bold%path%bold (%uline%no%uline) by %bold%user%bold"
set announce(GIVE)		"\[%bold%sitename%bold\] %color07%boldgive%bold%color %bold%target%bold \[%bold%mb%boldMB\] by %bold%user%bold"
set announce(TAKE)		"\[%bold%sitename%bold\] %color07%boldtake%bold%color %bold%target%bold \[%bold%mb%boldMB\] by %bold%user%bold"
set announce(BW)		"\[%bold%color12BANDWIDTH%color%bold\] %boldUL%bold: %uploaders@%bold%upspeed%boldkb/sec %boldDN%bold: %leechers@%bold%dnspeed%boldkb/sec Idlers: %bold%idlers%bold %boldALL%bold: %totalusers@%bold%totalspeed%boldkb/sec"
set announce(UPTIME)		"\[%bold%sitename%bold\] %taskname started @ %EUdate %time, running for %dayd %hourh %minutem %seconds"
set announce(VERSION)		"\[%bold%sitename%bold\] ioFTPD %bold%iover%bold - dZSbot %bold%dzver%bold - Eggdrop %bold%eggver%bold - ioA %bold%ioaver%bold"
set announce(APPROVE)		"\[%bold%sitename%bold\] %color03%boldapprove%bold%color %bold%release%bold by %bold%user%bold"
set announce(WELCOME)		"Type ${cmdpre}help If U Need It"
set announce(OPEN)		"\[%bold%sitename%bold\] %color03%boldopen%bold%color %bold%user%bold has opened the server"
set announce(CLOSE)		"\[%bold%sitename%bold\] %color03%boldclose%bold%color %bold%user%bold has closed the server. Reason: %reason"
set announce(IOJN)		"\[%color12IOJN%color\] %msg"
set announce(SPEEDTEST)		"%msg"

#\n\[%bold%section%bold\] %fast\n\[%bold%section%bold\] %slow"

## NO RANDOMIZING OUTPUT with announces below
## IF YOU DON'T KNOW WHAT TO CHANGE !!! DON'T TOUCH !!!
set announce(UPLOAD)		"\[%bold%color12SPEED%color%bold\] %bold%user%bold is uploading %file @ %bold%speed%boldkb/sec"
set announce(LEECH)		"\[%bold%color12SPEED%color%bold\] %bold%user%bold is downloading %file @ %bold%speed%boldkb/sec - %tsizeMB/%fsizeMB (%progress%)"
set announce(IDLE)		"\[%bold%color12SPEED%color%bold\] %bold%user%bold is idle for %idletime  -  Online for %logintime"
set announce(NOUPLOAD)		"\[%bold%color12SPEED%color%bold\] Ohh Noo !! Give us something to trade !!"
set announce(NOLEECH)		"\[%bold%color12SPEED%color%bold\] Ohh Yeah !! We are free from Leechers !!"
set announce(NOIDLE)		"\[%bold%color12SPEED%color%bold\] Yeah Good !! no fucking Idlers online !!"
set announce(SPEED)		"\[%bold%color12SPEED%color%bold\] %bold%user%bold is %action %file @ %bold%speed%boldkb/sec"
set announce(AFFILS)		"\[%bold%section-AFFiLS\] %affils"
set announce(BANNED)		"\[%bold%section-BANNED\] %banned"
set announce(NUKES)		"\[%bold%sitename%bold\] \[%cnt\] %date %release was nuked %multi by %nuker reason: %reason"
set announce(UNNUKES)		"\[%bold%sitename%bold\] \[%cnt\] %date %release was unnuked %multi by %nuker reason: %reason"
set announce(PRES)		"\[%bold%sitename%bold\] \[%cnt\] %release was preed %time ago by %user in %section"
set announce(IRCSTATS)		"\[%bold%sitename%bold\] %usrgrp %status: %result"
set announce(BNC)		"\[%bold%color12%sitename BNC%color%bold\] %host - %bold%status%bold   %speed"
set announce(INCOMPLETE)	"\[%bold%sitename%bold\] %release"
# !!! add nothing after %msg in announce(DEFAULT) !!!
set announce(DEFAULT)		"\[%bold%section%bold\] %msg"
#set announce(DEFAULT)		"%msg"
# BTRIAL ANNOUNCE
set announce(BTRIAL)		"\[%color12TRIAL%color\] %msg"

# set the blowfish encrytion key (empty = no encryption)
set blfs(KEY) "sfdhkjh31h45kjh4608dg'09rewgjlkz5jn54209uds0fg"
# set the blowfish header tag
set blfs(HEADER) "+OK"



#########################################################
#			!!!    END OF CONFIG HERE    !!!			#
#			!!! DO NOT CHANGE THIS BELOW !!!			#
#########################################################

set procs {
	!imdb:proc_imdb
	!new:proc_news
	!quota:proc_bquota
	!trial:proc_btrial
	${cmdpre}bnc:proc_bnc
	${cmdpre}help:proc_help
	${cmdpre}free:show_free
	${cmdpre}requests:proc_requests
	${cmdpre}search:proc_search
	${cmdpre}nukes:proc_nukes
	${cmdpre}unnukes:proc_unnukes
	${cmdpre}pres:proc_lastpres
	${cmdpre}affils:proc_affils
	${cmdpre}banned:proc_banned
	${cmdpre}rules:proc_rules
	${cmdpre}getrules:proc_getrules
	${cmdpre}uptime:proc_uptime
	${cmdpre}version:proc_version
	${cmdpre}getnfo:proc_getnfo
	${cmdpre}inc:proc_incomplete
	${cmdpre}who:proc_who
	${cmdpre}bw:proc_bandwidth
	${cmdpre}uploaders:proc_uploaders
	${cmdpre}leechers:proc_leechers
	${cmdpre}idlers:proc_idlers
	${cmdpre}speed:proc_speed
	${cmdpre}allup:stats_user_allup
	${cmdpre}alldn:stats_user_alldn
	${cmdpre}monthup:stats_user_monthup
	${cmdpre}monthdn:stats_user_monthdn
	${cmdpre}wkup:stats_user_wkup
	${cmdpre}wkdn:stats_user_wkdn
	${cmdpre}dayup:stats_user_dayup
	${cmdpre}daydn:stats_user_daydn
	${cmdpre}gallup:stats_group_allup
	${cmdpre}galldn:stats_group_alldn
	${cmdpre}gmonthup:stats_group_monthup
	${cmdpre}gmonthdn:stats_group_monthdn
	${cmdpre}gwkup:stats_group_wkup
	${cmdpre}gwkdn:stats_group_wkdn
	${cmdpre}gdayup:stats_group_dayup
	${cmdpre}gdaydn:stats_group_daydn
	# ENCRYPTED PUB PROCS WITH FLAGS REQUIRED
	${cmdpre}undupe:proc_undupe
	${cmdpre}approve:proc_approve
	${cmdpre}killidlers:proc_kill
	${cmdpre}reqadd:proc_reqadd
	${cmdpre}reqdel:proc_reqdel
	${cmdpre}reqfilled:proc_reqfilled
}

#########################################################
# SET BINDINGS											#
#########################################################

bind pub -|- [set cmdpre]bnc proc_bnc
bind pub -|- [set cmdpre]help proc_help
bind pub -|- [set cmdpre]free show_free
bind pub -|- [set cmdpre]requests proc_requests
bind pub -|- [set cmdpre]search proc_search
bind pub -|- [set cmdpre]nukes proc_nukes
bind pub -|- [set cmdpre]unnukes proc_unnukes
bind pub -|- [set cmdpre]pres proc_lastpres
bind pub -|- [set cmdpre]affils proc_affils
bind pub -|- [set cmdpre]banned proc_banned
bind pub -|- [set cmdpre]new proc_news
bind pub -|- [set cmdpre]rules proc_rules
bind pub -|- [set cmdpre]getrules proc_getrules
bind pub -|- [set cmdpre]uptime proc_uptime
bind pub -|- [set cmdpre]version proc_version
bind pub -|- [set cmdpre]getnfo proc_getnfo
bind pub -|- [set cmdpre]inc proc_incomplete

bind pub -|- [set cmdpre]who proc_who
bind pub -|- [set cmdpre]bw proc_bandwidth
bind pub -|- [set cmdpre]uploaders proc_uploaders
bind pub -|- [set cmdpre]leechers proc_leechers
bind pub -|- [set cmdpre]idlers proc_idlers
bind pub -|- [set cmdpre]speed proc_speed

bind pub -|- [set cmdpre]allup stats_user_allup
bind pub -|- [set cmdpre]alldn stats_user_alldn
bind pub -|- [set cmdpre]monthup stats_user_monthup
bind pub -|- [set cmdpre]monthdn stats_user_monthdn
bind pub -|- [set cmdpre]wkup stats_user_wkup
bind pub -|- [set cmdpre]wkdn stats_user_wkdn
bind pub -|- [set cmdpre]dayup stats_user_dayup
bind pub -|- [set cmdpre]daydn stats_user_daydn

bind pub -|- [set cmdpre]gallup stats_group_allup
bind pub -|- [set cmdpre]galldn stats_group_alldn
bind pub -|- [set cmdpre]gmonthup stats_group_monthup
bind pub -|- [set cmdpre]gmonthdn stats_group_monthdn
bind pub -|- [set cmdpre]gwkup stats_group_wkup
bind pub -|- [set cmdpre]gwkdn stats_group_wkdn
bind pub -|- [set cmdpre]gdayup stats_group_dayup
bind pub -|- [set cmdpre]gdaydn stats_group_daydn

bind join -|- * welcome_msg
bind msg -|- !invite proc_invite
bind pub -|- [set blfs(HEADER)] proc_decryptcmd

# BINDS WITH FLAGS REQUIRED
bind pub f|f [set cmdpre]undupe proc_undupe
bind pub o|o [set cmdpre]approve proc_approve
bind pub o|o [set cmdpre]killidlers proc_kill
bind pub o|o [set cmdpre]reqadd proc_reqadd
bind pub o|o [set cmdpre]reqdel proc_reqdel
bind pub o|o [set cmdpre]reqfilled proc_reqfilled

bind msg o|o !silent proc_silent

#########################################################
# SOME IMPORTANT GLOBAL VARIABLES						#
#########################################################

set dver "1.15"
catch { set lastoct [file size $location(IOLOG)/ioFTPD.log] }
set defaultsection "DEFAULT"
set nuke(LASTTYPE) ""
set nuke(LASTDIR) ""
set nuke(SHOWN) 1
set variables(NUKE)   ""
set variables(UNNUKE) ""
set mpath ""
set rlc_timeout 15

#########################################################
# MAIN LOOP - PARSES DATA FROM IOFTPD.LOG				#
#########################################################

proc readlog {} {
	global location lastoct disable defaultsection variables msgtypes chanlist IMDB_ALT
	set fileid [open dZSbot.timestamp w] ; puts $fileid "[clock seconds]" ; close $fileid
	catch { set ioftpdlogsize [file size $location(IOLOG)/ioFTPD.log] }
	catch { if { $ioftpdlogsize == $lastoct } { utimer 1 "readlog" ; return } }
	catch { if { $ioftpdlogsize < $lastoct } { set lastoct $ioftpdlogsize ; utimer 1 "readlog" ; return } }
	if { [catch { set of [open $location(IOLOG)/ioFTPD.log r] } ] } { utimer 1 "readlog" ; return }
	seek $of $lastoct
	while {![eof $of]} {
		set line [gets $of]
		if {$line == ""} {continue}
		set msgtype [string trim [lindex $line 2] ":"]
		if { ! [info exists disable($msgtype)] } {continue}
		if { $msgtype == "BLA" || $msgtype == "BLE" } {
		  set path [lindex $line 7]
		  if { $msgtype == "BLE" } { set path [string trimright $path "/"] }
		  set var1 "{$path} [lrange $line 3 5]"
		} elseif { $msgtype == "NEWDIR" || $msgtype == "DELDIR" } {
			set path [lindex $line 5]
			if { $msgtype == "DELDIR" } { set path [string trimright $path "/"] }
			set var1 "{$path} [lrange $line 3 4]"
		} elseif { $msgtype == "IMDB" } {
			#putlog "!!! click IMDB_ALT == $IMDB_ALT"
			set now1 [clock clicks -milliseconds]
			set path [lindex $line 3]
			set var1 [imdbcall $path [lindex $line 4] [lindex $line 5] [lindex $line 6] [lindex $line 7]]
			if { $disable(IMDBANNOUNCE) == 1 } {
				close $of
				set lastoct [file size $location(IOLOG)/ioFTPD.log]
				utimer 1 "readlog"
				return 0
			}
			#putlog "!!! imdb proc speed: [expr ([clock clicks -milliseconds] - $now1)]ms"

		} else {
			set path [lindex $line 3]
			set var1 [lrange $line 3 end]
		}
		if { ! [string compare $msgtype "INVITE"] } {
			set nick [lindex $line 5]
			#foreach channel $chanlist(INVITE) { puthelp "INVITE $nick $channel" }
			if { [lindex $line 6] == "0day" } {
			  puthelp "INVITE $nick #iojtq"
			}
			if { [lindex $line 6] == "iso" } {
			  puthelp "INVITE $nick #pimpek"
			}
			if { [lindex $line 6] == "all" } {
			  puthelp "INVITE $nick #iojtq"
			  puthelp "INVITE $nick #pimpek"
			}
		}
		set section [getsection $path $msgtype]
		if { [denycheck "$path"] == 0 } {
			#putlog "passed denycheck $path $msgtype"
			if { [string compare "$section" "$defaultsection"] } {
				if { $disable($msgtype) == 0 } {
					if { [info exists variables($msgtype)] } {
						set echoline [parse $msgtype $var1 $section]
						sndall $section $echoline
					} else {
						set echoline [parse DEFAULT $var1 $section]
						sndall $section $echoline
					}
				}
			} elseif { [string match *$msgtype* $msgtypes(DEFAULT)] != 0 } {
				if { $disable($msgtype) == 0 } {
					set echoline [parse $msgtype $var1 "DEFAULT"]
					sndall "DEFAULT" $echoline
				}
			} else { 
				if { $disable(DEFAULT) == 0 } {
					set echoline [parse $msgtype $var1 "DEFAULT"]
					sndall "DEFAULT" $echoline
				}
			}
		}
	}
	close $of
	set lastoct [file size $location(IOLOG)/ioFTPD.log]
	launchnuke
	utimer 1 "readlog"
	return 0
}
proc readlogcheck {} {
	global rlc_timeout
	set fileid [open dZSbot.timestamp r] ; set timestamp [read $fileid] ; close $fileid
	if { [expr [clock seconds] - $timestamp] > $rlc_timeout } { putlog "dzsbot timeout" ; rehash }
	utimer 1 "readlogcheck"
}



#########################################################
# GET SECTION NAME (BASED ON PATH)						#
#########################################################
proc getsection {cpath msgtype} {
	#putlog "proc getsection"
	global sections msgtypes paths type defaultsection mpath
	foreach section $sections {
		foreach path $paths($section) {
			if { [string match $path $cpath] == 1 && [string first $msgtype $msgtypes($type($section))] != -1 } {
				set mpath $path
				return $section
			}
		}
	}
	return $defaultsection
}



#########################################################
# REPLACE WHAT WITH WITHWHAT							#
#########################################################
proc replacevar {strin what withwhat} {
	#putlog "proc replacevar"
	global zeroconvert
	set output $strin
	set replacement $withwhat
	if { [string length $replacement] == 0 && [info exists zeroconvert($what)] } { set replacement $zeroconvert($what) }
	set cutpos 0
	while { [string first $what $output] != -1 } {
		set cutstart [expr [string first $what $output] - 1]
		set cutstop  [expr $cutstart + [string length $what] + 1]
		set output [string range $output 0 $cutstart]$replacement[string range $output $cutstop end]
	}
	return $output
}



#########################################################
# CONVERT BASIC COOKIES TO DATA							#
#########################################################
proc basicreplace {strin section} {
	#putlog "proc basicreplace"
	global sitename
	set output [replacevar $strin "%sitename" $sitename]
	set output [replacevar $output "%bold" "\002"]
	set output [replacevar $output "%color" "\003"]
	set output [replacevar $output "%uline" "\037"]
	set output [replacevar $output "%section" $section]
	return "$output"
}



#########################################################
# CONVERT COOKIES TO DATA								#
#########################################################
proc parse {msgtype msgline section} {
	#putlog "proc parse"
	global variables announce random mpath binary
	if { $msgtype == "PRE" && [lindex $msgline 8] != "" } { set msgtype "PREMP3" }
	set type $msgtype
	if { ! [string compare $type "NUKE"] || ! [string compare $type "UNNUKE"] } {
		fuelnuke $type [lindex $msgline 0] $section $msgline
		return ""
	}
	if { ! [info exists announce($type)] || ! [info exists variables($type)] } { set type "DEFAULT" }
	set vars $variables($type)
	if { ! [string compare [lindex $announce($type) 0] "random"] && [string is digit -strict [lindex $announce($type) 1]] == 1 } {
		set output $random($msgtype\-[rand [lindex $announce($type) 1]])
	} else {
		set output $announce($type)
	}
	set output [basicreplace $output $section]
	set cnt 0
	if { [ string compare [lindex $vars 0] "%pf" ] == 0 } {
		set split [split [lindex $msgline 0] "/"]
		set ll [llength $split]
		set split2 [split $mpath "/"]
		set sl [llength $split2]
		set temp [lrange $split [expr $sl - 1] end]
		set relname ""
		 foreach part $temp {
		 	set relname $relname/$part
		 }
		 set temp [string range $relname 1 end]
		 set output [replacevar $output "%relname" $temp]
		 set output [replacevar $output "%release" [lindex $split [expr $ll -1]]]
		 set output [replacevar $output "%path" [lindex $split [expr $ll -2]]]
		 set vars [string range $vars 4 end]
		 set cnt 1
	}
	foreach vari $vars {
		set output [replacevar $output $vari [lindex $msgline $cnt]]
		set cnt [expr $cnt + 1]
	}
	if [regexp {rank:[^\"| ]+} $output rankeduser] {
		set zs_user [lindex [split ${rankeduser} :] 1]
		set result [exec $binary(IOGROUP) template=2 ranking ${zs_user}]
		set output [replacevar $output "rank:${zs_user}" "${result}"]
	}
	return $output
}



#########################################################
# SEND TO ALL CHANNELS LISTED							#
#########################################################
proc sndall {section args} {
	#putlog "proc sndall"
	global chanlist splitter blfs
	foreach chan $chanlist($section) {
		foreach line [split [lindex $args 0] $splitter(CHAR)] {
			if { $blfs(KEY) != "" } {
				set eline [encrypt $blfs(KEY) $line]
				putquick "PRIVMSG $chan :$blfs(HEADER) $eline"
			} else {putquick "PRIVMSG $chan :$line"}
		}
	}
}



#########################################################
# SEND TO 1 CHANNEL										#
#########################################################
proc sndchan {puttype chan args} {
	global splitter blfs
	foreach line [split [lindex $args 0] $splitter(CHAR)] {
		if { $blfs(KEY) != "" } {
			set eline [encrypt $blfs(KEY) $line]
			$puttype "PRIVMSG $chan :$blfs(HEADER) $eline"
		} else {$puttype "PRIVMSG $chan :$line"}
	}
}



#########################################################
# POST WHO INFO											#
#########################################################
proc proc_who {nick uhost hand chan arg} {
	global binary disable
	if { $disable(WHO) == 0 } {
		foreach line [split [exec $binary(WHO) template=3 all] \n] {
			if { $line == "" } {continue}
			if { ! [info exists newline($line)] } { set newline($line) 0 } else { set newline($line) [expr $newline($line) + 1] }
			set line [basicreplace $line "WHO"]
			#puthelp "PRIVMSG $nick :$line\003$newline($line)"
			sndchan "putserv" $chan $line\003$newline($line)
		}
		#puthelp "PRIVMSG $nick :Command Successful."
	}
}


#########################################################
# POST SPEED											#
#########################################################
proc proc_speed {nick uhost hand chan arg} {
	global binary announce disable
	if { $disable(SPEED) == 1 } { return }
	set result [exec $binary(WHO) template=3 speed [lindex $arg 0]]
	foreach line [split $result "\n"] {
		if { $line == "" } {continue}
		if { [lindex $line 0] == "ERROR:" } {
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" $line]
			set output [basicreplace $output "SPEED"]
			sndchan "putserv" $chan $output
		} elseif { $line == "is not online" } {
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" "%bold[lindex $arg 0]%bold $line"]
			set output [basicreplace $output "SPEED"]
			sndchan "putserv" $chan $output
		} elseif { [lindex $line 2] == "idle" } {
			set output $announce(IDLE)
			set output [replacevar $output "%user" [lindex $line 0]]
			set output [replacevar $output "%group" [lindex $line 1]]
			set output [replacevar $output "%idletime" [lindex $line 3]]
			set output [replacevar $output "%logintime" [lindex $line 4]]
			set output [basicreplace $output "SPEED"]
			sndchan "putserv" $chan $output
		} else {
			set output $announce(SPEED)
			set output [replacevar $output "%user" [lindex $line 0]]
			set output [replacevar $output "%group" [lindex $line 1]]
			set output [replacevar $output "%action" [lindex $line 2]]
			set output [replacevar $output "%file" [lindex $line 3]]
			set output [replacevar $output "%speed" [lindex $line 4]]
			set output [basicreplace $output "SPEED"]
			sndchan "putserv" $chan $output
		}
	}
}



#########################################################
# POST BANDWIDTH										#
#########################################################
proc proc_bandwidth {nick uhost hand chan arg} {
	global binary announce disable random
	if { $disable(BW) == 0 } {
		if { ! [string compare [lindex $announce(BW) 0] "random"] && [string is digit -strict [lindex $announce(BW) 1]] == 1 } {
			set output $random(BW\-[rand [lindex $announce(BW) 1]])
		} else {
			set output $announce(BW)
		}
		set data [exec $binary(WHO) template=3 bw]
		set output [replacevar $output "%upspeed" [lindex $data 0]]
		set output [replacevar $output "%uploaders" [lindex $data 1]]
		set output [replacevar $output "%dnspeed" [lindex $data 2]]
		set output [replacevar $output "%leechers" [lindex $data 3]]
		set output [replacevar $output "%idlers" [lindex $data 4]]
		set output [replacevar $output "%totalspeed" [lindex $data 5]]
		set output [replacevar $output "%totalusers" [lindex $data 6]]
		set output [basicreplace $output "BW"]
		sndchan "putserv" $chan $output
	}
}



#########################################################
# POST UPLOADERS										#
#########################################################
proc proc_uploaders {nick uhost hand chan arg} {
	global binary announce disable
	if { $disable(UPLOADER) == 0 } {
		set result [exec $binary(WHO) template=3 up]
		if { $result == "no" } {
			set output $announce(NOUPLOAD)
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
		} else {
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" "uploaders:"]
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
			set cntusers 0
			set cntspeed 0
			foreach line [split $result "\n"] {
				if { $line == "" } {continue}
				incr cntusers
				set output $announce(UPLOAD)
				set output [replacevar $output "%user" [lindex $line 0]]
				set output [replacevar $output "%group" [lindex $line 1]]
				set output [replacevar $output "%file" [lindex $line 2]]
				set output [replacevar $output "%speed" [lindex $line 3]]
				set cntspeed [expr $cntspeed + [lindex $line 3]]
				set output [basicreplace $output "STATUS"]
				sndchan "putserv" $chan $output
			}
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" "%boldTOTAL%bold: %bold$cntusers%bold user(s) @ %bold${cntspeed}%boldkb/sec"]
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
		}
	}
}



#########################################################
# POST LEECHERS											#
#########################################################
proc proc_leechers {nick uhost hand chan arg} {
	global binary announce disable
	if { $disable(LEECHER) == 0 } {
		set result [exec $binary(WHO) template=3 down]
		if { $result == "no" } {
			set output $announce(NOLEECH)
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
		} else {
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" "leechers:"]
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
			set cntusers 0
			set cntspeed 0
			foreach line [split $result "\n"] {
				if { $line == "" } {continue}
				incr cntusers
				set output $announce(LEECH)
				set output [replacevar $output "%user" [lindex $line 0]]
				set output [replacevar $output "%group" [lindex $line 1]]
				set output [replacevar $output "%file" [lindex $line 2]]
				set output [replacevar $output "%speed" [lindex $line 3]]
				set cntspeed [expr $cntspeed + [lindex $line 3]]
				set output [replacevar $output "%tsize" [lindex $line 4]]
				set output [replacevar $output "%fsize" [lindex $line 5]]
				set output [replacevar $output "%progress" [lindex $line 6]]
				set output [basicreplace $output "STATUS"]
				sndchan "putserv" $chan $output
			}
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" "%boldTOTAL%bold: %bold$cntusers%bold user(s) @ %bold${cntspeed}%boldkb/sec"]
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
		}
	}
}



#########################################################
# POST IDLERS											#
#########################################################
proc proc_idlers {nick uhost hand chan arg} {
	global binary announce disable
	if { $disable(IDLER) == 0 } {
		set result [exec $binary(WHO) template=3 idle]
		if { $result == "no" } {
			set output $announce(NOIDLE)
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
		} else {
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" "idlers:"]
			set output [basicreplace $output "STATUS"]
			sndchan "putserv" $chan $output
			foreach line [split $result "\n"] {
				if { $line == "" } {continue}
				set output $announce(IDLE)
				set output [replacevar $output "%user" [lindex $line 0]]
				set output [replacevar $output "%group" [lindex $line 1]]
				set output [replacevar $output "%idletime" [lindex $line 2]]
				set output [replacevar $output "%logintime" [lindex $line 3]]
				set output [basicreplace $output "STATUS"]
				sndchan "putserv" $chan $output
			}
		}
	}
}



#########################################################
# POST STATS											#
#########################################################
proc showstats {nick type1 type2 limit chan} {
	global binary poststats
	if { $limit < 1 || $limit > $poststats(MAX) || [string is alpha $limit] == 1 } { set limit $poststats(DEFAULT) }
	foreach line [split [exec $binary(IOGROUP) $type1 $type2 $limit] \n] {
		if { ! [info exists newline($line)] } { set newline($line) 0 } else { set newline($line) [expr $newline($line) + 1] }
		if { $poststats(OUTPUT) == 0 } {
			puthelp "PRIVMSG $nick :$line\003$newline($line)"
		} else {
			sndchan "puthelp" $chan "$line\003$newline($line)"
		}
	}
}



#########################################################
# INVITE CHECK											#
#########################################################
proc proc_invite {nick host hand arg} {
	global location binary chanlist announce sitename disable random cmdpre botnick
	if { ! [info exists announce(MSGINVITE)] || ! [info exists disable(MSGINVITE)] } { return }
	if { $arg == "" } { puthelp "PRIVMSG $nick :Syntax: /MSG $botnick ${cmdpre}invite <FTP_Login> <FTP_Password>" ; return }
	set username [lindex $arg 0]
	set password [lindex $arg 1]
	set result [exec -- $binary(PASSCHK) "$username" "$password" "$location(IODIR)"]
	if { [lindex $result 0] == 1 } {
		if { $disable(MSGINVITE) == 0 } {
  			foreach channel $chanlist(INVITE) { puthelp "INVITE $nick $channel" }
  			if { ! [string compare [lindex $announce(MSGINVITE) 0] "random"] && [string is digit -strict [lindex $announce(MSGINVITE) 1]] == 1 } {
				set output $random(MSGINVITE\-[rand [lindex $announce(MSGINVITE) 1]])
			} else {
				set output $announce(MSGINVITE)
			}
			set output [replacevar $output "%user" $username]
			set output [replacevar $output "%group" [lindex $result 1]]
			set output [replacevar $output "%ircnick" $nick]
			set output [replacevar $output "%host" $host]
			set output [basicreplace $output "INVITE"]
			sndall "DEFAULT" $output
		}
	} else {
		if { $disable(BADMSGINVITE) == 0 } {
  			if { ! [string compare [lindex $announce(BADMSGINVITE) 0] "random"] && [string is digit -strict [lindex $announce(BADMSGINVITE) 1]] == 1 } {
				set output $random(BADMSGINVITE\-[rand [lindex $announce(BADMSGINVITE) 1]])
			} else {
				set output $announce(BADMSGINVITE)
			}
			set output [replacevar $output "%ircnick" $nick]
			set output [replacevar $output "%host" $host]
			set output [basicreplace $output "INTRUDER"]
			sndall "DEFAULT" $output
		}
	}
	return
}



#########################################################
# SHOW FREE SPACE										#
#########################################################
proc show_free {nick uhost hand chan arg} {
	global binary announce device disable sections
	if { $disable(FREE) == 1 } {return}
	set arg [string toupper $arg]
	set total_freespace 0
	set total_space 0
	set cnt 0
	set scheck "$sections ALL"
	if { $arg != "" && [lsearch -exact $scheck $arg] == -1 } {
		set output $announce(DEFAULT)
		set output [replacevar $output "%msg" "Available sections are: $sections"]
		set output [basicreplace $output "FREE"]
		sndchan "puthelp" $chan "$output or ALL"
		return
	}
	if { $arg == "" || $arg == "ALL" } {
		for {set i 0} {$i < $device(TOTAL)} {incr i} {
			incr cnt
			set output $announce(DEFAULT)
			foreach line [split [exec $binary(DF)] "\r\n"] {
				if { [string match [lindex $line 0] [string toupper [lindex $device($i) 0]]] == 1 } {
					append devices "\[[lrange $device($i) 1 end]: %bold[format %.2f [expr [lindex $line 3].0/1024]]%bold/[format %.2f [expr [lindex $line 5].0/1024]] GB\]  "
					set total_freespace [expr $total_freespace + [expr [lindex $line 3].0/1024]]
					set total_space [expr $total_space + [expr [lindex $line 5].0/1024]]
				}
			}
			if { $cnt == $device(COLUMN) || $i == [expr $device(TOTAL) - 1] } {
				set output [replacevar $output "%msg" $devices]
				set output [basicreplace $output "FREE"]
				sndchan "puthelp" $chan $output
				set cnt 0 ; set devices ""
			}
		}
		set output $announce(DEFAULT)
		set devices "%boldTOTAL%bold: %bold[format %.2f $total_freespace]%bold/[format %.2f $total_space] GB"
		set output [replacevar $output "%msg" $devices]
		set output [basicreplace $output "FREE"]
		sndchan "puthelp" $chan $output
	} else {
		set result ""
		set output $announce(DEFAULT)
		for {set i 0} {$i < $device(TOTAL)} {incr i} {
			foreach devicex [split $device($i) " "] {
				if { [string match -nocase $arg $devicex] == 1 } {
					set result [lindex $device($i) 0]
				}
			}
		}
		if { $result == "" } {
			set output $announce(DEFAULT)
			set output [replacevar $output "%msg" "Available sections are: $sections"]
			set output [basicreplace $output "FREE"]
			sndchan "puthelp" $chan "$output or ALL"
			return
		}
		foreach line [split [exec $binary(DF) $result] "\r\n"] {
			if { [string match [lindex $line 0] $result] == 1 } {
				set devices "\[$arg: %bold[format %.2f [expr [lindex $line 3].0/1024]]%bold/[format %.2f [expr [lindex $line 5].0/1024]] GB\] is free @ [lindex $line 6]"
			}
		}
		set output [replacevar $output "%msg" $devices]
		set output [basicreplace $output "FREE"]
		sndchan "puthelp" $chan $output
	}
}



#########################################################
# UPDATE NUKE BUFFER									#
#########################################################
proc fuelnuke {type path section args} {
	global nuke hidenuke
	set args [lindex $args 0]
	if {$type == $nuke(LASTTYPE) && $path == $nuke(LASTDIR) && $nuke(SHOWN) == 0} {
		if {[lindex $args 2] != $hidenuke} {
			append nuke(NUKEE) "\002[lindex $args 2]\002 (\002[lindex [lindex $args 3] 1]\002MB), "
		}
	} else {
		launchnuke
		if {[lindex $args 2] != $hidenuke} {
			set nuke(TYPE) $type
			set nuke(PATH) $path
			set nuke(SECTION) $section
			set nuke(NUKER) [lindex $args 1]
			set nuke(NUKEE) "\002[lindex $args 2]\002 (\002[lindex [lindex $args 3] 1]\002MB) "
			set nuke(MULT) [lindex [lindex $args 3] 0]
			set nuke(REASON) [lindex $args 4]
			set nuke(SHOWN) 0
		}
	}
	set nuke(LASTTYPE) $type
	set nuke(LASTDIR) $path
}



#########################################################
# FLUSH NUKE BUFFER										#
#########################################################
proc launchnuke {} {
	global nuke sitename announce
	if {$nuke(SHOWN) == 1} {return}
	set nuke(NUKEE) [string trim $nuke(NUKEE) ", "]
	set split [split $nuke(PATH) "/"]
	set ll [llength $split]
	if { $nuke(REASON) == "" } { set nuke(REASON) "No reason" }
	set output $announce($nuke(TYPE))
	set output [replacevar $output "%nuker" $nuke(NUKER)]
	set output [replacevar $output "%nukees" $nuke(NUKEE)]
	set output [replacevar $output "%type" $nuke(TYPE)]
	set output [replacevar $output "%mult" $nuke(MULT)]
	set output [replacevar $output "%reason" $nuke(REASON)]
	set output [replacevar $output "%section" $nuke(SECTION)]
	set output [replacevar $output "%release" [lindex $split [expr $ll -1]]]
	set output [replacevar $output "%path" [lindex $split [expr $ll -2]]]
	set output [basicreplace $output $nuke(TYPE)]
	sndall $nuke(SECTION) $output
	set nuke(SHOWN) 1
}



#########################################################
# CHECK IF RELEASE SHOULD NOT BE ANNOUNCED				#
#########################################################
proc denycheck {strin} {
	#putlog "proc denycheck"
	global denypost
	foreach deny $denypost {
		if { [string match $deny $strin] == 1 } { return 1 }
	}
	return 0
}



#########################################################
# SHOW INCOMPLETE LIST									#
#########################################################
proc show_incompletes {nick uhost hand chan arg} {
	global sitename binary
	foreach line [split [exec $binary(INCOMPLETE)] "\n"] {
		if { ! [info exists newline($line)] } { set newline($line) 0 } else { set newline($line) [expr $newline($line) + 1] }
		puthelp "PRIVMSG $nick :$line\003$newline($line)"
	}
}



#########################################################
# SHOW WELCOME MSG										#
#########################################################
proc welcome_msg {nick uhost hand chan} {
	global announce disable chanlist random
	if { $disable(WELCOME) == 0 } {
		if { ! [string compare [lindex $announce(WELCOME) 0] "random"] && [string is digit -strict [lindex $announce(WELCOME) 1]] == 1 } {
			set output $random(WELCOME\-[rand [lindex $announce(WELCOME) 1]])
		} else {
			set output $announce(WELCOME)
		}
		foreach c_chan $chanlist(WELCOME) {
			if { [string match -nocase $c_chan $chan] == 1 } {
				puthelp "NOTICE $nick : $output"
			}
		}
	}
}



#########################################################
# SHOW BNC LIST using NCFTPLS exe						#
#########################################################
proc proc_bnc { nick uhost hand chan arg } {
	global bnc announce binary disable
	if { $disable(NCFTPLS) == 0 } {
		foreach eachbnc $bnc(LIST) {
			if {$eachbnc == ""} {continue}
			set output $announce(BNC)
			set now1 [clock clicks -milliseconds]
			set status [catch { exec -- $binary(NCFTPLS) -u $bnc(USER) -p $bnc(PASS) -t $bnc(TIMEOUT) -r 00 ftp://$eachbnc } result]
			set now2 "Response time: %bold[expr ([clock clicks -milliseconds] - $now1)]%boldms"
			if { ([regexp \[.\]*ncftpls\:\ cannot\ open\[.\]* $result] > 0) } { set bncchk "DOWN" ; set bncspeed "" } else { set bncchk "UP" ; set bncspeed $now2 }
			set output [replacevar $output "%host" $eachbnc]
			set output [replacevar $output "%status" $bncchk]
			set output [replacevar $output "%speed" $bncspeed]
			set output [basicreplace $output "BNC"]
			sndchan "puthelp" $chan $output
		}
	}
}



#########################################################
# SHOWING REQUESTS ON IRC								#
#########################################################
proc proc_requests {nick uhost hand chan arg} {
	global disable ioa
	if { $disable(REQUESTSHOW) == 0 } {
		set tempfile [open $ioa(REQFILE) r]
    	while {![eof $tempfile]} {
    		set line [gets $tempfile]
    		if { $line == "" } { continue }
    		if { $ioa(REQUESTS) == 0 } {
    			puthelp "PRIVMSG $nick :$line"
    		} else {
				sndchan "puthelp" $chan $line
    		}
    	}
    	close $tempfile
    }                                 
}                                     



#########################################################
# ADD REQUEST ON IRC									#
#########################################################
proc proc_reqadd {nick uhost hand chan arg} {
	global binary disable announce
	if { $disable(REQUESTIRC) == 0 } {
		set arg [lindex $arg 0]
		set status [catch { exec -- $binary(IOA) REQUESTIRC $arg } result]
		if { $status == 0 } {
			set output $announce(REQUESTIRC)
			set output [replacevar $output "%user" $nick]
			set output [replacevar $output "%request" $arg]
			set output [basicreplace $output "REQUEST"]
			sndchan "puthelp" $chan $output
		}
	}
}



#########################################################
# DEL REQUEST ON IRC									#
#########################################################
proc proc_reqdel {nick uhost hand chan arg} {
	global binary ioa disable announce
	if { $disable(REQDELIRC) == 0 } {
		set arg [lindex $arg 0]
		if { [string is digit -strict $arg] } {
			set status [catch { exec -- $binary(IOA) REQDELIRC $arg } result]
			if { $status == 0 } {
				puthelp "NOTICE $nick :Request number $arg is now deleted"
			}
		} else {
			puthelp "NOTICE $nick :Request number not found: $arg isn't a number"
		}
	}
}



#########################################################
# FILLED REQUEST ON IRC									#
#########################################################
proc proc_reqfilled {nick uhost hand chan arg} {
	global binary ioa disable announce
	if { $disable(REQFILLEDIRC) == 0 } {
		set arg [lindex $arg 0]
		if { [string is digit -strict $arg] } {
			set status [catch { exec -- $binary(IOA) REQFILLEDIRC $arg } result]
			if { $status == 0 } {
				puthelp "NOTICE $nick :Request number $arg is now filled"
			}
		} else {
			puthelp "NOTICE $nick :Request number not found: $arg isn't a number"
		}
	}
}



#########################################################
# Search via IRC										#
#########################################################
proc proc_search {nick uhost hand chan arg} {
	global binary ioa disable
	if { $disable(SEARCHIRC) == 0 } {
		#putlog "searching"
		set arg [string map {\  *} $arg]
		set status [catch { exec -- $binary(IOA) SEARCHIRC $arg } result]
		#putlog "found $result"
		if {$status =="0" } {
			set pos 0 
			set found 0
			set msg [split $result "\n"]
			set output "-\[Search\]-----------------------------------------------"
			if { $ioa(SEARCHIRC) == 0 } {
				puthelp "PRIVMSG $nick :$output"
			} else {
				sndchan "puthelp" $chan $output
			}
			foreach line $msg {
				incr pos 1
				if { $pos > $ioa(MAXSRCH) } {
					set output "To many results found. Please be more specific"
					if { $ioa(SEARCHIRC) == 0 } {
						puthelp "PRIVMSG $nick :$output"
						break
					} else {
						sndchan "puthelp" $chan $output
						break
					}
				} else {
					if { [string length $line] > "1" } {
						incr found 1
						if { $ioa(SEARCHIRC) == 0 } {
							puthelp "PRIVMSG $nick :$line"
						} else {
							sndchan "puthelp" $chan $line
						}
					}
				}
			}
			set output " $found match to your criteria\n-------------------------------------------------\[ioA\]-"
			if { $ioa(SEARCHIRC) == 0 } {
				puthelp "PRIVMSG $nick :$output"
			} else {
				sndchan "puthelp" $chan $output
			}
		}
	}
}



#########################################################
# MAP HTML CODES										#
#########################################################
proc htmlcodes {tempfile} {
	set mapfile [string map {&#34; ' &#38; & &#91; ( &#92; / &#93; ) &#123; ( &#125; ) &#161; ¡ &#162; ¢ &#163; £ &#164; ¤ &#165; ¥ &#166; ¦ &#167; § &#168; ¨ &#169; © &#170; ª &#171; « &#172; ¬ &#173; ­ &#174; ® } $tempfile]
	set mapfile [string map {&#175; ¯ &#176; ° &#177; ± &#178; ² &#179; ³ &#180; ´ &#181; µ &#182; ¶ &#183; · &#184; ¸ &#185; ¹ &#186; º &#187; » &#188; ¼ &#189; ½ &#190; ¾ &#191; ¿ &#192; À &#193; Á &#194; Â } $mapfile]
	set mapfile [string map {&#195; Ã &#196; Ä &#197; Å &#198; Æ &#199; Ç &#200; È &#201; É &#202; Ê &#203; Ë &#204; Ì &#205; Í &#206; Î &#207; Ï &#208; Ð &#209; Ñ &#210; Ò &#211; Ó &#212; Ô &#213; Õ &#214; Ö } $mapfile]
	set mapfile [string map {&#215; × &#216; Ø &#217; Ù &#218; Ú &#219; Û &#220; Ü &#221; Ý &#222; Þ &#223; ß &#224; à &#225; á &#226; â &#227; ã &#228; ä &#229; å &#230; æ &#231; ç &#232; è &#233; é &#234; ê } $mapfile]
	set mapfile [string map {&#235; ë &#236; ì &#237; í &#238; î &#239; ï &#240; ð &#241; ñ &#242; ò &#243; ó &#244; ô &#245; õ &#246; ö &#247; ÷ &#248; ø &#249; ù &#250; ú &#251; û &#252; ü &#253; ý &#254; þ } $mapfile]
	return $mapfile
}



#########################################################
# SEARCH ON IMDB										#
#########################################################
catch { if { $IMDB_ALT == 0 } { package require http 2.3 } }
proc imdbcall {vpath url user group winpath} {
	#putlog "proc imdbcall"
	global binary disable IMDBTAG IMDBMSG_STYLE IMDB_ALT IMDBMSG_MSG
	set title "N/A" ; set name "N/A" ; set genre "N/A" ; set tagline "N/A"
	set plot "N/A" ; set rating "N/A" ; set votes "N/A" ; set mpaa "N/A"
	set runtime "N/A" ; set budget "N/A" ; set screens "N/A" ; set country "N/A"
	set language "N/A" ; set soundmix "N/A" ; set top250 "N/A"
	set url2 [string map {207.171.166.140 www.imdb.com} $url]
	if { $disable(IMDBURL) == 0 } {
		regexp {[^/]+$} $winpath tempDN
		set dirname [string tolower $tempDN]
		set urlid [open $winpath/$dirname.url w]
		puts $urlid "\[InternetShortcut\]\nURL=$url2"
		close $urlid
	}
	if { $IMDB_ALT == 0 } {
		set page [::http::config -useragent "MSIE 6.0"]
		set page [::http::geturl $url]
		set html [::http::data $page]
		::http::Finish $page
	} else {
		catch { exec $binary(CURL) "$url" } html
	}
	## get title
	if [regexp {<title>[^<]+} $html title] {
		set pos [expr [string last > $title] + 1]
		set title [string range $title $pos end]
		regexp {([0-9]+)} $title year
		set title [htmlcodes $title]
	}
	## get director
	if [regexp {Directed by</b><br>\n<[^>]+>[^<]+} $html name] {
		set pos [string last > $name] ; incr pos
		set name [string range $name $pos end]
		set name [htmlcodes $name]
	}
	## get genre
	if [regexp {<a href=./Sections/Genres[^\n]+} $html genre] {
		regsub -all {<[^\>]*>} $genre {} genre
		regsub {\(.*\)} $genre {} genre
	}
	## get tagline
	if [regexp {<b class="ch">Tagline:</b>[^<]+} $html tagline] {
		set pos [string last > $tagline] ; incr pos
		set tagline [string range $tagline $pos end]
		set tagline [string trim $tagline]
		set tagline [htmlcodes $tagline]
	}
	## get plot
	if [regexp {<b class=\"ch\">Plot (Summary|Outline):</b>[\s\n]+[^<]+} $html plot] {
		set pos [string last > $plot] ; incr pos
		set plot [string range $plot $pos end]
		set plot [string trim $plot]
		set plot [htmlcodes $plot]
	}
	## get iMDb rating
	if [regexp {<b>\d.\d/10</b> \([\w\s\d,]+\)} $html rating] {
		set pos [string last ( $rating]
		set pos1 [string first { } $rating $pos]
		incr pos ; incr pos1 -1
		set votes [string range $rating $pos $pos1]
		set rating [string range $rating 3 8]
	}
	## get TOP 250
	if [regexp {<a href="/top_250_films">[^\n]+} $html top250] {
		regexp {#[^<]+} $top250 top250
	}
	## get MPAA
	if [regexp {<b class="ch"><a href="/mpaa">[^\n]+} $html mpaa] {
		regsub -all {<[^\>]*>} $mpaa {} mpaa
		regsub {MPAA: } $mpaa {} mpaa
		set mpaa [htmlcodes $mpaa]
	}
	## get runtime
	if [regexp {<b class=\"ch\">Runtime:</b>([\n\s]+)([\w:]+)(\d+)} $html runtime] {
		regsub -all {[\n\s]+} $runtime {} runtime
		set pos [string last > $runtime] ; incr pos
		set runtime [string range $runtime $pos end]
		set pos [string last : $runtime]
		if {$pos != -1} {incr pos ; set runtime [string range $runtime $pos end]}
	}
	## get country
	if [regexp {<a href=./Sections/Countries[^\n]+} $html country] {
		regsub -all {<[^\>]*>} $country {} country
	}
	## get language
	if [regexp {<a href=./Sections/Languages[^\n]+} $html language] {
		regsub -all {<[^\>]*>} $language {} language
	}
	## get soundmix
	if [regexp {<a href=./List.sound-mix=[^\n]+} $html soundmix] {
		regsub -all {<[^\>]*>} $soundmix {} soundmix
	}
	unset html
	if { $IMDB_ALT == 0 } {
		set page [::http::config -useragent "MSIE 6.0"]
		set page [::http::geturl ${url}business]
		set html [::http::data $page]
		::http::Finish $page
	} else {
		catch { exec $binary(CURL) "${url}business" } html
	}
	## get budget
	if [regexp {<b>Budget</b></dt>[\s\n]?<dd><[^>]+>[^<]+} $html budget] {
		set pos [string last > $budget] ; incr pos
		set budget [string range $budget $pos end]
		set budget [string map {&#8364; € &#163; £ } $budget]
	}
	## get screens
	if [regexp {<b>Opening Weekend</b></dt>[\s\n]?[^\n]+} $html opweek] {
		if [regexp {\(USA\) \([^)]+\) \([^)]+\)} $opweek screens] {
			set pos [string last ( $screens]
			set pos1 [string last ) $screens]
			incr pos ; incr pos1 -1
			set screens [string range $screens $pos $pos1]
		}
	}
	unset html
	# create IMDB TAG
	if { $disable(IMDBTAG) == 0 } {
		regsub -all {/} $rating { of } rating2
		#regsub -all {/} $genre {} genre2
		set genre2 [lindex $genre 0]
		if { $IMDBTAG == "dir" } {
			file mkdir "$winpath/\[IMDB\] - $genre2 ($year) - $rating2 - \[IMDB\]"
		}
		if { $IMDBTAG == "file" } {
			set fileid [open "$winpath/\[IMDB\] - $genre2 ($year) - $rating2 - \[IMDB\]" w]
			close $fileid
		}
	}
	# create IMDB MESSAGES
	if { $disable(IMDBMSG) == 0 } {
		if { $IMDBMSG_STYLE == 0 } {
			foreach TMP_MSG [split $IMDBMSG_MSG " "] {
				set fileid [open "$winpath/$TMP_MSG" w]
				puts $fileid ""
				puts $fileid ""
				puts $fileid "                          I M D B  I N F O                            "
				puts $fileid "+--------------------------------------------------------------------+"
				puts $fileid "   Title....: [format %-55.55s $title] "
				puts $fileid "   Rating...: [format %-8.8s $rating] [format %-46.46s " "] "
				puts $fileid "   Votes....: [format %-8.8s $votes] [format %-46.46s " "] "
				puts $fileid "   Genre....: [format %-55.55s $genre] "
				puts $fileid "   Director.: [format %-55.55s $name] "
				puts $fileid "   URL......: [format %-55.55s $url2] "
				puts $fileid "   Runtime..: [format %-3.3s $runtime] mins [format %-46.46s " "] "
				puts $fileid "   Budget...: [format %-55.55s $budget] "
				puts $fileid "   Screens..: [format %-55.55s $screens] "
				puts $fileid "+--------------------------------------------------------------------+"
				close $fileid
			}
		}
		if { $IMDBMSG_STYLE == 1 } {
			foreach TMP_MSG [split $IMDBMSG_MSG " "] {
				set fileid [open "$winpath/$TMP_MSG" w]
				puts $fileid ""
				puts $fileid "  ...::(  The IMDB!  )::...                                            "
				puts $fileid ".-===================================================================-."
				puts $fileid "|                                                                     |"
				puts $fileid "| Title....: [format %-56.56s $title] |"
				puts $fileid "| Rating...: [format %-8.8s $rating] [format %-47.47s " "] |"
				puts $fileid "| Votes....: [format %-8.8s $votes] [format %-47.47s " "] |"
				puts $fileid "| Genre....: [format %-56.56s $genre] |"
				puts $fileid "| Director.: [format %-56.56s $name] |"
				puts $fileid "| URL......: [format %-56.56s $url2] |"
				puts $fileid "| Runtime..: [format %-3.3s $runtime] mins [format %-47.47s " "] |"
				puts $fileid "| Budget...: [format %-56.56s $budget] |"
				puts $fileid "| Screens..: [format %-56.56s $screens] |"
				puts $fileid "|                                                                     |"
				puts $fileid "`-===================================================================-'"
				close $fileid
			}
		}
	}
	set result "\"$vpath\" \"$url2\" \"$title\" \"$name\" \"$genre\" \"$plot\" \"$rating\" \"$votes\" \"$runtime\" \"$budget\" \"$screens\" \"$tagline\" \"$top250\" \"$mpaa\" \"$country\" \"$language\" \"$soundmix\" \"$user\" \"$group\" \"$winpath\""
	return $result
}



#########################################################
# SHOWING LAST NUKES ON IRC								#
#########################################################
proc proc_nukes {nick uhost hand chan arg} {
	global location announce ioa disable
	if { $disable(NUKES) == 0 } {
		if { $arg == "" || $arg > $ioa(MAX) || [string is alpha $arg] == 1 } { set arg $ioa(DEFAULT) }
		set fileid [open $location(NUKESLOG) r]
		set lines [split [read $fileid] "\n"]
		set cnt 1
		for {set i [expr {[llength $lines]-2}]} {$i >= 0} {incr i -1} {
			if { $cnt > $arg } { break }
			set tmpf [split [lindex $lines $i] "|"]
			set tmpd [split [lindex $tmpf 5] "-"]
			set output $announce(NUKES)
			set output [replacevar $output "%release" [lindex $tmpf 0]]
			set output [replacevar $output "%multi" [lindex $tmpf 1]]
			set output [replacevar $output "%size" [lindex $tmpf 2]]
			set output [replacevar $output "%nuker" [lindex $tmpf 3]]
			set output [replacevar $output "%nukees" [lindex $tmpf 4]]
			set output [replacevar $output "%date" [lindex $tmpd 0]]
			set output [replacevar $output "%reason" [lindex $tmpf 6]]
			set output [replacevar $output "%cnt" [format %02d $cnt]]
			set output [basicreplace $output "NUKES"]
			if { $ioa(NUKES) == 0 } {
				puthelp "PRIVMSG $nick :$output"
			} else {
				sndchan "puthelp" $chan $output
			}
			incr cnt
		}
		close $fileid
	}
}



#########################################################
# SHOWING LAST UNNUKES ON IRC							#
#########################################################
proc proc_unnukes {nick uhost hand chan arg} {
	global location announce ioa disable
	if { $disable(UNNUKES) == 0 } {
		if { $arg == "" || $arg > $ioa(MAX) || [string is alpha $arg] == 1 } { set arg $ioa(DEFAULT) }
		set fileid [open $location(UNNUKESLOG) r]
		set lines [split [read $fileid] "\n"]
		set cnt 1
		for {set i [expr {[llength $lines]-2}]} {$i >= 0} {incr i -1} {
			if { $cnt > $arg } { break }
			set tmpf [split [lindex $lines $i] "|"]
			set tmpd [split [lindex $tmpf 5] "-"]
			set output $announce(UNNUKES)
			set output [replacevar $output "%release" [lindex $tmpf 0]]
			set output [replacevar $output "%multi" [lindex $tmpf 1]]
			set output [replacevar $output "%size" [lindex $tmpf 2]]
			set output [replacevar $output "%nuker" [lindex $tmpf 3]]
			set output [replacevar $output "%nukees" [lindex $tmpf 4]]
			set output [replacevar $output "%date" [lindex $tmpd 0]]
			set output [replacevar $output "%reason" [lindex $tmpf 6]]
			set output [replacevar $output "%cnt" [format %02d $cnt]]
			set output [basicreplace $output "UNNUKES"]
			if { $ioa(UNNUKES) == 0 } {
				puthelp "PRIVMSG $nick :$output"
			} else {
				sndchan "puthelp" $chan $output
			}
			incr cnt
		}
		close $fileid
	}
}



#########################################################
# SHOWING LAST PRES ON IRC								#
#########################################################
proc proc_lastpres {nick uhost hand chan arg} {
	global location announce ioa disable
	if { $disable(PRES) == 0 } {
		if { $arg == "" || $arg > $ioa(MAX) || [string is alpha $arg] == 1 } { set arg $ioa(DEFAULT) }
		set fileid [open $location(CMDSLOG) r]
		set lines [split [read $fileid] "\n"]
		set cnt 1
		for {set i [expr {[llength $lines]-2}]} {$i >= 0} {incr i -1} {
			set tmpf [split [lindex $lines $i] " "]
			if { [lindex $tmpf 3] == "PRE" } {
				if { $cnt > $arg } { break }
				set unixtime [clock scan "[string range [lindex $tmpf 0] 6 9]-[string range [lindex $tmpf 0] 0 4] [lindex $tmpf 1]" -gmt $ioa(GMT)]
				set now [clock seconds]
				set diff [expr ($now - $unixtime)]
				if { $diff < 3600 } {
					set age [clock format $diff -format "%Mm %Ss" -gmt 1]
				}
				if { $diff >= 3600 && $diff < 86400 } {
					set age [clock format $diff -format "%Hh %Mm" -gmt 1]
				}
				if { $diff >= 86400 } {
					set day [expr int($diff/86400)]
					set hour [clock format $diff -format "%Hh" -gmt 1]
					set age "${day}d $hour"
				}
				set output $announce(PRES)
				set output [replacevar $output "%time" $age]
				set output [replacevar $output "%user" [string range [lindex $tmpf 2] 0 end-1]]
				set output [replacevar $output "%section" [lindex $tmpf 4]]
				set output [replacevar $output "%release" [lindex $tmpf 5]]
				set output [replacevar $output "%cnt" [format %02d $cnt]]
				set output [basicreplace $output "PRES"]
				if { $ioa(PRES) == 0 } {
					puthelp "PRIVMSG $nick :$output"
				} else {
					sndchan "puthelp" $chan $output
				}
				incr cnt
			}
		}
		close $fileid
	}
}



#########################################################
# SHOWING AFFILS GROUPS ON IRC							#
#########################################################
proc proc_affils {nick uhost hand chan arg} {
	global affils sections announce disable
	if { $disable(AFFILS) == 0 } {
		if { $arg == "" } {
			foreach section $sections {
				if { ! [info exists affils($section)] } { continue }
				set output $announce(AFFILS)
				set output [replacevar $output "%section" $section]
				set output [replacevar $output "%affils" $affils($section)]
				set output [basicreplace $output ""]
				sndchan "putserv" $chan $output
			}
		} else {
			foreach section $sections {
				if { ! [info exists affils($section)] } { continue }
				if { [string match -nocase $section $arg] == 1 } {
					set output $announce(AFFILS)
					set output [replacevar $output "%section" $section]
					set output [replacevar $output "%affils" $affils($section)]
					set output [basicreplace $output ""]
					sndchan "putserv" $chan $output
				}
			}
		}
	}
}



#########################################################
# SHOWING BANNED GROUPS ON IRC							#
#########################################################
proc proc_banned {nick uhost hand chan arg} {
	global banned sections announce disable
	if { $disable(BANNED) == 0 } {
		if { $arg == "" } {
			foreach section $sections {
				if { ! [info exists banned($section)] } { continue }
				set output $announce(BANNED)
				set output [replacevar $output "%section" $section]
				set output [replacevar $output "%banned" $banned($section)]
				set output [basicreplace $output ""]
				sndchan "putserv" $chan $output
			}
		} else {
			foreach section $sections {
				if { ! [info exists banned($section)] } { continue }
				if { [string match -nocase $section $arg] == 1 } {
					set output $announce(BANNED)
					set output [replacevar $output "%section" $section]
					set output [replacevar $output "%banned" $banned($section)]
					set output [basicreplace $output ""]
					sndchan "putserv" $chan $output
				}
			}
		}
	}
}



#########################################################
# SHOWING SITE RULES ON IRC								#
#########################################################
proc proc_rules {nick uhost hand chan arg} {
	global location disable
	if { $disable(RULES) == 0 } {
		set fileid [open $location(RULES) r]
		set lines [split [read $fileid] "\n"]
		close $fileid
		set lines [lrange $lines 0 end]
		puthelp "PRIVMSG $nick : Processing site rules..."
		foreach line $lines {
			set templine [string range $line 0 end]
			if {$templine != ""} {puthelp "PRIVMSG $nick : $templine"}
		}
	}
}



#########################################################
# SEND RULES IN DCC										#
#########################################################
proc proc_getrules {nick uhost hand chan arg} {
	global location disable
	if { $disable(GETRULES) == 0 } {
		puthelp "NOTICE $nick : Processing dcc send rules..."
		dccsend $location(RULES) $nick
	}
}



#########################################################
# SHOWING UPTIME ON IRC									#
#########################################################
proc proc_uptime {nick uhost hand chan arg} {
	global binary disable uptime announce
	if { $disable(UPTIME) == 0 } {
		set results [exec $binary(UPTIME)]
		foreach result [split $results "\n"] {
			if { [lindex $result 1] == "not" } {
				set output $announce(DEFAULT)
				set output [replacevar $output "%msg" $result]
				set output [basicreplace $output "UPTIME"]
				sndchan "putserv" $chan $output
			} else {
				if { ! [string compare [lindex $announce(UPTIME) 0] "random"] && [string is digit -strict [lindex $announce(UPTIME) 1]] == 1 } {
					set output $random(UPTIME\-[rand [lindex $announce(UPTIME) 1]])
				} else {
					set output $announce(UPTIME)
				}
				set output [replacevar $output "%taskname" [format %-7.7s [lindex $result 0]]]
				set output [replacevar $output "%EUdate" [lindex $result 1]]
				set output [replacevar $output "%USdate" [lindex $result 2]]
				set output [replacevar $output "%time" [lindex $result 3]]
				set output [replacevar $output "%day" [lindex $result 4]]
				set output [replacevar $output "%hour" [lindex $result 5]]
				set output [replacevar $output "%minute" [lindex $result 6]]
				set output [replacevar $output "%second" [lindex $result 7]]
				set output [basicreplace $output "UPTIME"]
				if { [string trim [lindex $result 0]] != "windrop"} { continue }
				sndchan "putserv" $chan $output
			}
		}
	}
}



#########################################################
# POST UNDUPE											#
#########################################################
proc proc_undupe {nick uhost hand chan arg} {
	global binary disable location UNDUPE_ALT
	if { $disable(UNDUPE) == 0 } {
		if { $UNDUPE_ALT == 0 } {
			# security check
			if { [regexp {[^\w\d().-]+} $arg] > 0 } { puthelp "NOTICE $nick :Syntax error in parameters or arguments." ; return }
			# passed security check
			set check 0
			set udfile [lindex $arg 0]
			set fileid [open $location(IOLOG)/dupefile.log r]
			set dupelog [read $fileid]
			close $fileid
			foreach line [split $dupelog "\n"] {
				if { [string match $udfile [lindex $line 2]] == 1 } {
					regsub \[0-9\]+\ \[^\ \]+\ $udfile\n $dupelog "" dupelog
					set fileid [open $location(IOLOG)/dupefile.log w]
					puts -nonewline $fileid $dupelog
					close $fileid
					puthelp "NOTICE $nick :[lindex $line 2] is removed successfully from dupefile.log"
					incr check
				}
			}
			if { $check == 0 } { puthelp "NOTICE $nick :No results found." ; return }
		} elseif { $UNDUPE_ALT == 1 } {
			set result [exec $binary(UNDUPE) $arg]
			foreach line [split $result \n] {
				puthelp "NOTICE $nick :$line"
			}
		}
	}
}



#########################################################
# SHOWING STATS AUTOMATICALY ON IRC						#
#########################################################
proc proc_ircstats {mins hour day month year} {
	global binary disable announce ircstats
	if { $disable(IRCSTATS) == 0 } {
		foreach ircstat $ircstats(USR) {
			set stats_output ""
			set result [exec $binary(IOGROUP) template=2 userstats $ircstat $ircstats(MAX)]
			set output $announce(IRCSTATS)
			foreach line [split $result \n] {
				if { $line == "" } { continue }
				append stats_output "\[[lindex $line 0]. [lindex $line 1] %bold[lindex $line 4]%boldM\] "
			}
			set output [replacevar $output "%usrgrp" "User"]
			set output [replacevar $output "%status" $ircstat]
			set output [replacevar $output "%result" $stats_output]
			set output [basicreplace $output "IRCSTATS"]
			sndall "DEFAULT" $output
		}
		foreach ircstat $ircstats(GRP) {
			set stats_output ""
			set result [exec $binary(IOGROUP) template=2 groupstats $ircstat $ircstats(MAX)]
			set output $announce(IRCSTATS)
			foreach line [split $result \n] {
				if { $line == "" } { continue }
				append stats_output "\[[lindex $line 0]. [lindex $line 1] %bold[lindex $line 3]%boldM\] "
			}
			set output [replacevar $output "%usrgrp" "Group"]
			set output [replacevar $output "%status" $ircstat]
			set output [replacevar $output "%result" $stats_output]
			set output [basicreplace $output "IRCSTATS"]
			sndall "DEFAULT" $output
		}
	}
}



#########################################################
# POST KILL CMD											#
#########################################################
proc proc_kill {nick uhost hand chan arg} {
	global disable binary SK_EXCEPTIONS IT_LIMIT
	if { $disable(SITEKILL) == 0 } {
		set result [exec -- $binary(SITEKILL) $SK_EXCEPTIONS "idletime>$IT_LIMIT" "service=FTP_Service_0"]
		foreach line [split $result "\n"] {
			puthelp "NOTICE $nick :$line"
		}
	}
}



#########################################################
# POST APPROVED CMD										#
#########################################################
proc proc_approve {nick uhost hand chan arg} {
	global disable binary find_path announce random
	if { $disable(APPROVE) == 0 } {
		set arg [lindex $arg 0]
		set result ""
		set now [clock seconds]
		foreach eachpath $find_path {
			set eachpath [split $eachpath "|"]
			set ppath [clock format $now -format [lindex $eachpath 0] -gmt 1]
			set check [catch [exec $binary(FIND) $ppath -name $arg -maxdepth [lindex $eachpath 1]] tmp]
			if { $check == 0 } { continue } else { set result [exec $binary(FIND) $ppath -name $arg -maxdepth [lindex $eachpath 1]] ; break }
		}
		if { ! [string compare [lindex $announce(APPROVE) 0] "random"] && [string is digit -strict [lindex $announce(APPROVE) 1]] == 1 } {
			set output $random(APPROVE\-[rand [lindex $announce(APPROVE) 1]])
		} else {
			set output $announce(APPROVE)
		}
		if { $result != "" } {
			set result [string map {\\ /} $result]
			file mkdir "$result/approved_by_$nick"
			set output [replacevar $output "%release" $arg]
			set output [replacevar $output "%user" $nick]
			set output [basicreplace $output "APPROVED"]
			sndchan "putserv" $chan $output
		} else {
			sndchan "putserv" $chan "$arg NOT FOUND !!!"
		}
	}
}



#########################################################
# CHOOSE STATS PARAMETERS								#
#########################################################
proc stats_user_allup {nick uhost hand chan arg} { showstats "$nick" "userstats" "allup" "[lindex $arg 0]" "$chan" }
proc stats_user_alldn {nick uhost hand chan arg} { showstats "$nick" "userstats" "alldn" "[lindex $arg 0]" "$chan" }
proc stats_user_monthup {nick uhost hand chan arg} { showstats "$nick" "userstats" "monthup" "[lindex $arg 0]" "$chan" }
proc stats_user_monthdn {nick uhost hand chan arg} { showstats "$nick" "userstats" "monthdn" "[lindex $arg 0]" "$chan" }
proc stats_user_wkup {nick uhost hand chan arg} { showstats "$nick" "userstats" "wkup" "[lindex $arg 0]" "$chan" }
proc stats_user_wkdn {nick uhost hand chan arg} { showstats "$nick" "userstats" "wkdn" "[lindex $arg 0]" "$chan" }
proc stats_user_dayup {nick uhost hand chan arg} { showstats "$nick" "userstats" "dayup" "[lindex $arg 0]" "$chan" }
proc stats_user_daydn {nick uhost hand chan arg} { showstats "$nick" "userstats" "daydn" "[lindex $arg 0]" "$chan" }

proc stats_group_allup {nick uhost hand chan arg} { showstats "$nick" "groupstats" "allup" "[lindex $arg 0]" "$chan" }
proc stats_group_alldn {nick uhost hand chan arg} { showstats "$nick" "groupstats" "alldn" "[lindex $arg 0]" "$chan" }
proc stats_group_monthup {nick uhost hand chan arg} { showstats "$nick" "groupstats" "monthup" "[lindex $arg 0]" "$chan" }
proc stats_group_monthdn {nick uhost hand chan arg} { showstats "$nick" "groupstats" "monthdn" "[lindex $arg 0]" "$chan" }
proc stats_group_wkup {nick uhost hand chan arg} { showstats "$nick" "groupstats" "wkup" "[lindex $arg 0]" "$chan" }
proc stats_group_wkdn {nick uhost hand chan arg} { showstats "$nick" "groupstats" "wkdn" "[lindex $arg 0]" "$chan" }
proc stats_group_dayup {nick uhost hand chan arg} { showstats "$nick" "groupstats" "dayup" "[lindex $arg 0]" "$chan" }
proc stats_group_daydn {nick uhost hand chan arg} { showstats "$nick" "groupstats" "daydn" "[lindex $arg 0]" "$chan" }



#########################################################
# BLOWFISH DECRYPTION PROCEDURE							#
#########################################################
proc proc_decryptcmd {nick uhost hand chan arg} {
	global cmdpre blfs procs
    set cmdline [decrypt $blfs(KEY) $arg]
    if { [string index $cmdline 0] != "!" } { return }
    set dcmd [lindex $cmdline 0]
    set darg [lrange $cmdline 1 end]
    if { $dcmd == "${cmdpre}undupe" } {
    	if { ![matchattr [nick2hand $nick $chan] f|f $chan] } { return }
    }
    if { $dcmd == "${cmdpre}approve" } {
    	if { ![matchattr [nick2hand $nick $chan] o|o $chan] } { return }
    }
    if { $dcmd == "${cmdpre}killidlers" } {
    	if { ![matchattr [nick2hand $nick $chan] o|o $chan] } { return }
    }
    if { $dcmd == "${cmdpre}reqadd" } {
    	if { ![matchattr [nick2hand $nick $chan] o|o $chan] } { return }
    }
    if { $dcmd == "${cmdpre}reqdel" } {
    	if { ![matchattr [nick2hand $nick $chan] o|o $chan] } { return }
    }
    if { $dcmd == "${cmdpre}reqfilled" } {
    	if { ![matchattr [nick2hand $nick $chan] o|o $chan] } { return }
    }
    foreach eachproc $procs {
    	set eachproc [split $eachproc :]
    	if { $dcmd == [subst [lindex $eachproc 0]] } {
    		[lindex $eachproc 1] $nick $uhost $hand $chan $darg
    		return
    	}
    }
}



#########################################################
# POST VERSION											#
#########################################################
proc proc_version {nick uhost hand chan arg} {
	global version location disable announce dver random binary
	if { $disable(VERSION) == 0 } {
		set fileid [open $location(IODIR)/system/ioftpd.exe r]
		seek $fileid -2 end
		set lengthS [read $fileid 2]
		close $fileid ; unset fileid
		binary scan $lengthS s1 length
		set fileid [open $location(IODIR)/system/ioftpd.exe r]
		seek $fileid [expr -3 -$length] end
		set iov [read $fileid]
		close $fileid ; unset fileid
		regsub -all {[^\w\d\-]} $iov {} iov
		set status [catch { exec -- $binary(IOA) IOAVER } result]
		if {$status == 0} {
			set ioaver [lindex $result 4]
		} else {
			set ioaver "N/A"
		}
		if { ! [string compare [lindex $announce(VERSION) 0] "random"] && [string is digit -strict [lindex $announce(VERSION) 1]] == 1 } {
			set output $random(VERSION\-[rand [lindex $announce(VERSION) 1]])
		} else {
			set output $announce(VERSION)
		}
		set output [replacevar $output "%eggver" [lindex $version 0]]
		set output [replacevar $output "%iover" $iov]
		set output [replacevar $output "%dzver" $dver]
		set output [replacevar $output "%ioaver" $ioaver]
		set output [basicreplace $output "VERSION"]
		sndchan "putserv" $chan $output
	}
}



#########################################################
# POST GETNFO											#
#########################################################
set xfer-timeout 10
proc proc_getnfo {nick uhost hand chan arg} {
	global location disable
	if { $disable(GETNFO) == 0 } {
		set arg [lindex $arg 0] ; set check 0
		set fileid [open $location(IOLOG)/nfos.log r]
		set lines [read $fileid]
		close $fileid
		foreach line [split $lines "\n"] {
			set line [string map {¬ \ } $line]
			if { [string match *$arg* [lindex $line end]] == 1 } {
				if { [file exists $line] } { dccsend $line $nick ; incr check ; break }
			}
		}
		if { $check == 0 } { putserv "PRIVMSG $chan :NFO file for \002$arg\002 was not found !!!" }
	}
}



#########################################################
# SILENT PROCEDURE										#
#########################################################
set denybckup $denypost
proc proc_silent {nick host hand arg} {
	global denybckup denypost botnick cmdpre
	if { $arg == "" } { putserv "PRIVMSG $nick :Syntax: /MSG $botnick ${cmdpre}silent \[-off|<*/VFS_path1*> <*/VFS_path2*>\]" ; return }
	if { [lindex $arg 0] == "-off" } {
		set denypost $denybckup
		putserv "PRIVMSG $nick :${cmdpre}silent cmd is now set as default"
		return
	} else {
		set denypost "$denypost $arg"
		putserv "PRIVMSG $nick :${cmdpre}silent cmd is now active. new path(s) added: $arg"
		putserv "PRIVMSG $nick :But don't forget to reset with '-off' argument when you have finished"
	}
}



#########################################################
# INCOMPLETE PROCEDURE									#
#########################################################
proc proc_incomplete {nick uhost hand chan arg} {
	global disable binary find_path announce random inc_tag
	if { $disable(INCOMPLETE) == 0 } {
		set result ""
		set inc 0
		set now [clock seconds]
		foreach eachpath $find_path {
			set eachpath [split $eachpath "|"]
			set ppath [clock format $now -format [lindex $eachpath 0] -gmt 1]
			set check [catch [exec $binary(FIND) $ppath -name $inc_tag -maxdepth [lindex $eachpath 1]] tmp]
			if { $check == 0 } {
				continue
			} else {
				incr inc
				set result [exec $binary(FIND) $ppath -name $inc_tag -maxdepth [lindex $eachpath 1]]
				foreach line [split $result \n] {
					if {$line == ""} { continue }
					regexp {[^\\]*$} $line line
					## string range $line [string length $inc_tag] end
					set output $announce(INCOMPLETE)
					set output [replacevar $output "%release" $line]
					set output [basicreplace $output "INC"]
					sndchan "putserv" $chan $output
				}
			}
		}
		if { $inc == 0 } {
			set output $announce(INCOMPLETE)
			set output [replacevar $output "%release" "No Incomplete releases found"]
			set output [basicreplace $output "INC"]
			sndchan "putserv" $chan $output
		}
	}
}



#########################################################
# HELP SECTION											#
#########################################################
proc proc_help {nick uhost hand chan arg} {
	global sections cmdpre dver
	if {![file exist scripts/dZSbot.help]} {
		puthelp "PRIVMSG $nick :dZSbot.help is missing in your windrop/scripts dir please check install"
		return
	}
	puthelp "PRIVMSG $nick : .-----------------------------------------------------------------."
	puthelp "PRIVMSG $nick :                 B0unTy's dZSbot V.$dver help file"
	puthelp "PRIVMSG $nick : .-----------------------------------------------------------------.\0031"
	puthelp "PRIVMSG $nick :              All channels commands are prefixed by $cmdpre"
	puthelp "PRIVMSG $nick : "
	set helpfile [open scripts/dZSbot.help r]
   	while {![eof $helpfile]} {
   		set line [gets $helpfile]
   		puthelp "PRIVMSG $nick : $line"
   	}
   	close $helpfile
	puthelp "PRIVMSG $nick : Valid sections are : $sections"
}
putlog "Launching sitebot (v$dver) for ioFTPD..."
readlog
readlogcheck
putlog "Sitebot online!"