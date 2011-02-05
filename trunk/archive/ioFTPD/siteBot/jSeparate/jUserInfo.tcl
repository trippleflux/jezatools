#
#Make sure u hve .NET Framework 1.1 instaled
#
#Copy jScripts.exe and sqlite3.dll to ioFTPD/system
#In ioFTPD.ini add
#[Events]
#OnFtpLogIn							= EXEC jScripts.exe FTPLOGIN
#rehash/restart ioFTPD
#
#cmd to ioFTPD/system and type jScripts.exe check
#
#Copy jUserInfo.tcl to windrop/scripts
#In your bot add 
#source scripts/jUserInfo.tcl
#edit this file as u like
#rehash/restart bot 
#
#U can use thise letters as cookies in skins
#
#				{d}		jScripts(user,username)
#				{e}		jScripts(user,groupname)
#				{f}		jScripts(user,flags)
#				{g}		jScripts(user,credits)
#				{h}		jScripts(user,dateadded)
#				{i}		jScripts(user,lastlogin)
#				{j}		jScripts(user,allupmb)
#				{k}		jScripts(user,alluppos)
#				{l}		jScripts(user,alldnmb)
#				{m}		jScripts(user,alldnpos)
#				{n}		jScripts(user,mnupmb)
#				{o}		jScripts(user,mnuppos)
#				{p}		jScripts(user,mndnmb)
#				{r}		jScripts(user,mndnpos)
#				{s}		jScripts(user,wkupmb)
#				{t}		jScripts(user,wkuppos)
#				{u}		jScripts(user,wkdnmb)
#				{v}		jScripts(user,wkdnpos)
#				{z}		jScripts(user,dayupmb)
#				{q}		jScripts(user,dayuppos)
#				{w}		jScripts(user,daydnmb)
#				{y}		jScripts(user,daydnpos)
#

set jScripts(location_jScripts)								"c:/ioFTPD/system/jScripts.exe"
set jScripts(user,default,section)							0
set jScripts(default,show,user)								"chan"
set jScripts(default_split_char)								"\n"
set jScripts(log_dir)											"scripts/jScripts/logs"
set jScripts(log_jSName)										"jScripts.log"
set jScripts(enable_partyline)								true
set jScripts(enable_debug_partyline)						true
set jScripts(skin,user,help)									"\[\00312USERiNFO\003\] !user login"
set jScripts(skin,user,notfound)								"\[\00312USERiNFO\003\] \002%d\002 Was Not Found"
set jScripts(skin,user,head)									"\[\00312USERiNFO\003\] \002%d\002/\002%e\002 With \002%g\002 Credits Was Last Seen On \002%i\002"
#set jScripts(skin,user,body,allup)							"\[\00312USERiNFO\003\] \[ALLUP STATS: \002#%k\002 With \002%j\002\]"
#set jScripts(skin,user,body,alldn)							"\[\00312USERiNFO\003\] \[ALLDN STATS: \002#%m\002 With \002%l\002\]"
#set jScripts(skin,user,body,mnup)							"\[\00312USERiNFO\003\] \[MNUP STATS: \002#%o\002 With \002%n\002\]"
#set jScripts(skin,user,body,mndn)							"\[\00312USERiNFO\003\] \[MNDN STATS: \002#%r\002 With \002%p\002\]"
#set jScripts(skin,user,body,wkup)							"\[\00312USERiNFO\003\] \[WKUP STATS: \002#%t\002 With \002%s\002\]"
#set jScripts(skin,user,body,wkdn)							"\[\00312USERiNFO\003\] \[WKDN STATS: \002#%v\002 With \002%u\002\]"
#set jScripts(skin,user,body,dayup)							"\[\00312USERiNFO\003\] \[DAYUP STATS: \002#%q\002 With \002%z\002\]"
#set jScripts(skin,user,body,daydn)							"\[\00312USERiNFO\003\] "
set jScripts(skin,user,body,allup)							"\[\00312USERiNFO\003\] \[ALLUP STATS: \002#%k\002 With \002%j\002\]-\[ALLDN STATS: \002#%m\002 With \002%l\002\]"
set jScripts(skin,user,body,alldn)							""
set jScripts(skin,user,body,mnup)							"\[\00312USERiNFO\003\] \[MNUP STATS: \002#%o\002 With \002%n\002\]-\[MNDN STATS: \002#%r\002 With \002%p\002\]"
set jScripts(skin,user,body,mndn)							""
set jScripts(skin,user,body,wkup)							"\[\00312USERiNFO\003\] \[WKUP STATS: \002#%t\002 With \002%s\002\]-\[WKDN STATS: \002#%v\002 With \002%u\002\]"
set jScripts(skin,user,body,wkdn)							""
set jScripts(skin,user,body,dayup)							"\[\00312USERiNFO\003\] \[DAYUP STATS: \002#%q\002 With \002%z\002\]-\[DAYDN STATS: \002#%y\002 With \002%w\002\]"
set jScripts(skin,user,body,daydn)							""

bind pub -|- !user jScripts:USER


### STOP HERE       -#
### STOP HERE       -#
### STOP HERE       -#


set jScripts(user,username)			""
set jScripts(user,groupname)			""
set jScripts(user,flags)				""
set jScripts(user,credits)				""
set jScripts(user,dateadded)			""
set jScripts(user,lastlogin)			""
set jScripts(user,allupmb)				""
set jScripts(user,alluppos)			""
set jScripts(user,alldnmb)				""
set jScripts(user,alldnpos)			""
set jScripts(user,mnupmb)				""
set jScripts(user,mnuppos)				""
set jScripts(user,mndnmb)				""
set jScripts(user,mndnpos)				""
set jScripts(user,wkupmb)				""
set jScripts(user,wkuppos)				""
set jScripts(user,wkdnmb)				""
set jScripts(user,wkdnpos)				""
set jScripts(user,dayupmb)				""
set jScripts(user,dayuppos)			""
set jScripts(user,daydnmb)				""
set jScripts(user,daydnpos)			""

#
proc jScripts:ConvertSize { bytes } {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: -> jScripts:ConvertSize $bytes" }

	for {set i 0} {$bytes >= 1024} {incr i} { set bytes [expr $bytes / 1024] }
	#set post "B kB MB GB TB PB"
	set post "MB GB TB PB"
	#return [format "%7u [lindex $post $i]" $bytes]
	return [format "%u[lindex $post $i]" $bytes]

}

proc jScripts:DebugPartyLine { tekst } {
	
	global jTQ jSB jScripts
	
	putlog $tekst
	
	set jScripts(log,time) "[clock format [clock seconds] -format {%Y.%m.%d} -gmt true]"
	
   set file [open "$jScripts(log_dir)/$jScripts(log,time)$jScripts(log_jSName)" "a+"]
   #set file [open "$jScripts(log_dir)/$jScripts(log_jSName)" "a+"]
   puts $file "[clock format [clock seconds] -format {%Y-%m-%d %H:%M:%S} -gmt true] $tekst"
   close $file

}

proc jScripts:FormatStr1ng { tekst } {
  
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:FormatStr1ng { $tekst }" }
	
	set rpl	""
	set x		0
	set y		999
	
	for {set i 0} {$i < [string length $tekst]} {incr i} {
	 
		if {[string index $tekst $i] == "%"} {
		
			set j [incr i]
			
			if { [string index $tekst $i] == "-" } {
				incr i
			}
			
			while {[string is digit -strict [string index $tekst $i]]} { incr i }
			
			if { $j != $i } { 
				set x [string range $tekst $j [expr {$i - 1}]]
			}
			
			if { [string index $tekst $i] == "." } {
				incr i
			}
			
			set j $i
			
			while {[string is digit -strict [string index $tekst $i]]} { incr i }
			
			if { $j != $i } { 
			  set y [string range $tekst $j [expr {$i - 1}]]
			}
			
			switch -- [string index $tekst $i] {
			  
				{a}		{ append rpl [format %${x}.${y}s "empty"] }
				{b}		{ append rpl [format %${x}.${y}s "empty"] }
				{c}		{ append rpl [format %${x}.${y}s "empty"] }
				{d}		{ append rpl [format %${x}.${y}s $jScripts(user,username)] }
				{e}		{ append rpl [format %${x}.${y}s $jScripts(user,groupname)] }
				{f}		{ append rpl [format %${x}.${y}s $jScripts(user,flags)] }
				{g}		{ append rpl [format %${x}.${y}s $jScripts(user,credits)] }
				{h}		{ append rpl [format %${x}.${y}s $jScripts(user,dateadded)] }
				{i}		{ append rpl [format %${x}.${y}s $jScripts(user,lastlogin)] }
				{j}		{ append rpl [format %${x}.${y}s $jScripts(user,allupmb)] }
				{k}		{ append rpl [format %${x}.${y}s $jScripts(user,alluppos)] }
				{l}		{ append rpl [format %${x}.${y}s $jScripts(user,alldnmb)] }
				{m}		{ append rpl [format %${x}.${y}s $jScripts(user,alldnpos)] }
				{n}		{ append rpl [format %${x}.${y}s $jScripts(user,mnupmb)] }
				{o}		{ append rpl [format %${x}.${y}s $jScripts(user,mnuppos)] }
				{p}		{ append rpl [format %${x}.${y}s $jScripts(user,mndnmb)] }
				{r}		{ append rpl [format %${x}.${y}s $jScripts(user,mndnpos)] }
				{s}		{ append rpl [format %${x}.${y}s $jScripts(user,wkupmb)] }
				{t}		{ append rpl [format %${x}.${y}s $jScripts(user,wkuppos)] }
				{u}		{ append rpl [format %${x}.${y}s $jScripts(user,wkdnmb)] }
				{v}		{ append rpl [format %${x}.${y}s $jScripts(user,wkdnpos)] }
				{z}		{ append rpl [format %${x}.${y}s $jScripts(user,dayupmb)] }
				{q}		{ append rpl [format %${x}.${y}s $jScripts(user,dayuppos)] }
				{w}		{ append rpl [format %${x}.${y}s $jScripts(user,daydnmb)] }
				{y}		{ append rpl [format %${x}.${y}s $jScripts(user,daydnpos)] }
				{x}		{ append rpl [format %${x}.${y}s "empty"] }
			  	
			  	{%}		{ append rpl [format %${x}.${y}s "%"] }
			  
			  	default	{ append rpl [string index $tekst $i] }
			  
				set x		0
				set y		999

			}
		
		} else {
		
			append rpl [string index $tekst $i]
		
			set x		0
			set y		999

		}
	 
	}
	
	return "$rpl"

}

proc jScripts:SND {dest text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:SND {$dest $text}" }
	
	foreach line [split $text $jScripts(default_split_char)] {
		
		putquick "PRIVMSG $dest :$line"
	
	}
	
	return
  
}

# SHOWS USer Info
proc jScripts:USER { nick uhost hand chan text } {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: -> jScripts:USER $nick $uhost $hand $chan '$text' " }
	
	if { [lindex $text 0] == "" } { 
		
		jScripts:SND $chan $jScripts(skin,user,help)
		
	}
	
	set jScripts(user,username)	[lindex $text 0]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $jScripts(location_jScripts) POSANDSTATS $jScripts(user,username) $jScripts(user,default,section)" }
		
	set status 	[catch { exec -- $jScripts(location_jScripts) POSANDSTATS $jScripts(user,username) $jScripts(user,default,section)  } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: STATUS = $status" }
	
	if { $status > 0 } { 
		
		putlog "..jS....: $jScripts(location_jScripts) POSANDSTATS $jScripts(user,username) $jScripts(user,default,section) FAiLED ($result)"
		jScripts:SND $jScripts(default_admin_chan) "..jS....: $jScripts(location_jScripts) POSANDSTATS $jScripts(user,username) $jScripts(user,default,section) FAiLED ($result)"
		break
		
	}
	
	set line [lindex $result 0]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
	
	if { $line == "-" } {
		
		if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,notfound)] }
		if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,notfound)] }
		if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,notfound)]" }
		
		return
			
	} else {
	
#"{{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$ustats_credits$} {$ustats_timeadded$} {$ustats_lastseen$} 
#{$bustats_pos_dayup$} {$bustats_dayup$} {$bustats_pos_daydn$} {$bustats_daydn$} 
#{$bustats_pos_wkup$} {$bustats_wkup$} {$bustats_pos_wkdn$} {$bustats_wkdn$} 
#{$bustats_pos_mnup$} {$bustats_mnup$} {$bustats_pos_mndn$} {$bustats_mndn$} 
#{$bustats_pos_allup$} {$bustats_allup$} {$bustats_pos_alldn$} {$bustats_alldn$}} \n"

		set jScripts(user,username)			[lindex $line 0]
		set jScripts(user,groupname)			[lindex $line 1]
		set jScripts(user,flags)				[lindex $line 2]
		set jScripts(user,credits)				[jScripts:ConvertSize [lindex $line 3]]
		set jScripts(user,dateadded)			[lindex $line 4]
		set jScripts(user,lastlogin)			[lindex $line 5]
		set jScripts(user,alluppos)			[lindex $line 6]
		set jScripts(user,allupmb)				[jScripts:ConvertSize [lindex $line 7]]
		set jScripts(user,alldnpos)			[lindex $line 8]
		set jScripts(user,alldnmb)				[jScripts:ConvertSize [lindex $line 9]]
		set jScripts(user,mnuppos)				[lindex $line 10]
		set jScripts(user,mnupmb)				[jScripts:ConvertSize [lindex $line 11]]
		set jScripts(user,mndnpos)				[lindex $line 12]
		set jScripts(user,mndnmb)				[jScripts:ConvertSize [lindex $line 13]]
		set jScripts(user,wkuppos)				[lindex $line 14]
		set jScripts(user,wkupmb)				[jScripts:ConvertSize [lindex $line 15]]
		set jScripts(user,wkdnpos)				[lindex $line 16]
		set jScripts(user,wkdnmb)				[jScripts:ConvertSize [lindex $line 17]]
		set jScripts(user,dayuppos)			[lindex $line 18]
		set jScripts(user,dayupmb)				[jScripts:ConvertSize [lindex $line 19]]
		set jScripts(user,daydnpos)			[lindex $line 20]
		set jScripts(user,daydnmb)				[jScripts:ConvertSize [lindex $line 21]]
		
		if { $jScripts(skin,user,head) != "" } { 
		
			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,head)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,head)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,head)]" }

		}
		
		if { $jScripts(skin,user,body,allup) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,allup)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,allup)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,allup)]" }

		}
		
		if { $jScripts(skin,user,body,alldn) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,alldn)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,alldn)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,alldn)]" }

		}

		if { $jScripts(skin,user,body,mnup) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,mnup)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,mnup)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,mnup)]" }

		}

		if { $jScripts(skin,user,body,mndn) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,mndn)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,mndn)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,mndn)]" }

		}

		if { $jScripts(skin,user,body,wkup) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,wkup)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,wkup)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,wkup)]" }

		}

		if { $jScripts(skin,user,body,wkdn) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,wkdn)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,wkdn)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,wkdn)]" }

		}

		if { $jScripts(skin,user,body,dayup) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,dayup)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,dayup)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,dayup)]" }

		}

		if { $jScripts(skin,user,body,daydn) != "" } { 

			if { $jScripts(default,show,user) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,user,body,daydn)] }
			if { $jScripts(default,show,user) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,user,body,daydn)] }
			if { $jScripts(default,show,user) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,user,body,daydn)]" }

		}

	}

}
