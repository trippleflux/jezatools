set jScripts(default_version)									"1.0.2.9"

source "scripts/jScripts/jScripts.conf"


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

set jScripts(group,groupname)			""
set jScripts(group,groupusers)		""
set jScripts(group,allupmb)			""
set jScripts(group,alluppos)			""
set jScripts(group,alldnmb)			""
set jScripts(group,alldnpos)			""
set jScripts(group,mnupmb)				""
set jScripts(group,mnuppos)			""
set jScripts(group,mndnmb)				""
set jScripts(group,mndnpos)			""
set jScripts(group,wkupmb)				""
set jScripts(group,wkuppos)			""
set jScripts(group,wkdnmb)				""
set jScripts(group,wkdnpos)			""
set jScripts(group,dayupmb)			""
set jScripts(group,dayuppos)			""
set jScripts(group,daydnmb)			""
set jScripts(group,daydnpos)			""

set jScripts(approve,release)			""
set jScripts(approve,found)			false
set jScripts(approve,user)				""
set jScripts(approve,date)				""
set jScripts(approve,section)			""

set jScripts(rank,01,pos)				""
set jScripts(rank,01,name)				""
set jScripts(rank,01,group)			""
set jScripts(rank,01,flags)			""
set jScripts(rank,01,mb)				""
set jScripts(rank,01,files)			""
set jScripts(rank,01,speed)			""

set jScripts(rank,02,pos)				""
set jScripts(rank,02,name)				""
set jScripts(rank,02,group)			""
set jScripts(rank,02,flags)			""
set jScripts(rank,02,mb)				""
set jScripts(rank,02,files)			""
set jScripts(rank,02,speed)			""

set jScripts(rank,03,pos)				""
set jScripts(rank,03,name)				""
set jScripts(rank,03,group)			""
set jScripts(rank,03,flags)			""
set jScripts(rank,03,mb)				""
set jScripts(rank,03,files)			""
set jScripts(rank,03,speed)			""

set jScripts(rank,section)				""
set jScripts(rank,section,nr)			""
set jScripts(rank,dif,up)				""
set jScripts(rank,dif,dn)				""
set jScripts(rank,user)					""
set jScripts(rank,type)					""

set jScripts(TodoNumber)				""
set jScripts(TodoName)					""
set jScripts(TodoText)					""

set jScripts(stats,pos)					""
set jScripts(stats,user)				""
set jScripts(stats,group)				""
set jScripts(stats,mb)					""
set jScripts(stats,files)				""
set jScripts(stats,speed)				""

set jScripts(stats,text)				""
set jScripts(stats,section)			0
set jScripts(stats,default,name)		""

set jScripts(AffilSection)				""
set jScripts(Affils)						""
set jScripts(SectionSection)			""
set jScripts(Sections)					""
set jScripts(BannedSection)			""
set jScripts(Banned)						""
set jScripts(bnc_site)					""
set jScripts(bnc_ip)						""
set jScripts(bnc_fake_ip)				""
set jScripts(bnc_port)					""
set jScripts(bnc_loc)					""
set jScripts(bnc_sect)					""
set jScripts(bnc_speed)					""
set jScripts(bnc_desc)					""
set jScripts(bnc_status)				""
set jScripts(bnc_ssl)					""
set jScripts(bnc_time)					""
set jScripts(df_body_total)			0
set jScripts(df_body_free)				0
set jScripts(df_body_per)				0
set jScripts(df_body_tmp)				""
set jScripts(df_body_sct)				""
set jScripts(df_foot_total)			0
set jScripts(df_foot_free)				0
set jScripts(df_foot_per)				0

set jScripts(who_up_total_speed)		""
set jScripts(who_up_count)				""
set jScripts(who_dn_total_speed)		""
set jScripts(who_dn_count)				""
set jScripts(who_idle_count)			""
set jScripts(who_total_speed)			""
set jScripts(who_total_count)			""
set jScripts(who_username)				""
set jScripts(who_groupname)			""
set jScripts(who_idle_time)			""
set jScripts(who_login_time)			""
set jScripts(who_file_name)			""
set jScripts(who_user_speed)			""
set jScripts(who_bytes_transfered)	""
set jScripts(who_file_size)			""
set jScripts(who_percent_done)		""

set jScripts(speed,up,bw)				""
set jScripts(speed,dn,bw)				""
set jScripts(speed,all,bw)				""

set jScripts(arch,date,format)		""

set jScripts(age,username)				""
set jScripts(age,groupname)			""
set jScripts(age,addedby)				""
set jScripts(age,dateadded)			""
set jScripts(age,daysago)				""

# SHOWS Age (Date Added)
proc jScripts:AGE { nick uhost hand chan text } {
	
	global jTQ jSB jScripts
	
	if { !$jScripts(enable,user,age) } { return }
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: -> jScripts:age $nick $uhost $hand $chan '$text' " }
	
	if { [lindex $text 0] == "" } { 
		
		jScripts:SND $chan $jScripts(skin,age,help)
		
	} else {
	
		set jScripts(age,username)	[lindex $text 0]
		
		if { ![file exist $jScripts(location,log,sysop)] } { 
			
			if { $jScripts(enable_partyline) } { jScripts:DebugPartyLine "..jS....: -> '$jScripts(location,log,sysop)' Not Found!" }
			
		} else {
		
			set FILE [open "$jScripts(location,log,sysop)" "r"]
			set lines [read $FILE]
			close $FILE
			unset FILE
			
			set found false
			foreach line [split $lines "\n"] {
				
				if { $line == "" } { continue }
				
				regsub -all -- {\'} $line {} line
					
				if { ([lindex $line 3] == "created") && ([lindex $line 5] == "$jScripts(age,username)") } {

					set jScripts(age,groupname)			[lindex $line 8]
					set jScripts(age,addedby)				[lindex $line 2]
					set jScripts(age,dateadded)			"[lindex $line 0] [lindex $line 1]"
					regsub -all -- {-} $jScripts(age,dateadded) {/} jScripts(age,dateadded)
					set jScripts(time,now)					[clock seconds]
					set jScripts(time,added)				[clock scan "$jScripts(age,dateadded)" -gmt true]
					set jScripts(age,daysago)				[expr [expr $jScripts(time,now)-$jScripts(time,added)]/86400]
					#regsub -all -- { } $args {} args
					set found true
					break
				}
			}
			
			if { $found } {

				if { ($chan == $jScripts(default_admin_chan)) } {

					if { $jScripts(default,show,age) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,age,admin)] }
					if { $jScripts(default,show,age) == "private" }				{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,age,admin)] }
					if { $jScripts(default,show,age) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,age,admin)]" }

				} else {
					
					if { $jScripts(default,show,age) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,age,user)] }
					if { $jScripts(default,show,age) == "private" }				{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,age,user)] }
					if { $jScripts(default,show,age) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,age,user)]" }
				}
				
			} else {
			
				if { $jScripts(default,show,age) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,age,noinfo)] }
				if { $jScripts(default,show,age) == "private" }				{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,age,noinfo)] }
				if { $jScripts(default,show,age) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,age,noinfo)]" }
					
			}
		}
		
	}
	
}

# SHOWS Group Info
proc jScripts:GROUP { nick uhost hand chan text } {
	
	global jTQ jSB jScripts
	
	if { !$jScripts(enable,group) } { return }
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: -> jScripts:group $nick $uhost $hand $chan '$text' " }
	
	if { [lindex $text 0] == "" } { 
		
		jScripts:SND $chan $jScripts(skin,group,help)
		
	}
	
	set jScripts(group,groupname)	[lindex $text 0]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $jScripts(location_jScripts) POSGALLSTATS $jScripts(group,groupname) $jScripts(group,default,section)" }
		
	set status 	[catch { exec -- $jScripts(location_jScripts) POSGALLSTATS $jScripts(group,groupname) $jScripts(group,default,section)  } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: STATUS = $status" }
	
	if { $status > 0 } { 
		
		putlog "..jS....: $jScripts(location_jScripts) POSGALLSTATS $jScripts(group,groupname) $jScripts(group,default,section) FAiLED ($result)"
		jScripts:SND $jScripts(default_admin_chan) "..jS....: $jScripts(location_jScripts) POSGALLSTATS $jScripts(group,groupname) $jScripts(group,default,section) FAiLED ($result)"
		break
		
	}
	
	set line [lindex $result 0]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
	
	if { $line == "-" } {
		
		if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,notfound)] }
		if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,notfound)] }
		if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,notfound)]" }
		
		return
			
	} else {
	
#"{{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$ustats_credits$} {$ustats_timeadded$} {$ustats_lastseen$} 
#{$bustats_pos_dayup$} {$bustats_dayup$} {$bustats_pos_daydn$} {$bustats_daydn$} 
#{$bustats_pos_wkup$} {$bustats_wkup$} {$bustats_pos_wkdn$} {$bustats_wkdn$} 
#{$bustats_pos_mnup$} {$bustats_mnup$} {$bustats_pos_mndn$} {$bustats_mndn$} 
#{$bustats_pos_allup$} {$bustats_allup$} {$bustats_pos_alldn$} {$bustats_alldn$}} \n"

		set jScripts(group,groupname)			[lindex $line 0]
		set jScripts(group,groupusers)			[lindex $line 1]
		set jScripts(group,alluppos)			[lindex $line 2]
		set jScripts(group,allupmb)				[jScripts:ConvertSize [lindex $line 3]]
		set jScripts(group,alldnpos)			[lindex $line 4]
		set jScripts(group,alldnmb)				[jScripts:ConvertSize [lindex $line 5]]
		set jScripts(group,mnuppos)				[lindex $line 6]
		set jScripts(group,mnupmb)				[jScripts:ConvertSize [lindex $line 7]]
		set jScripts(group,mndnpos)				[lindex $line 8]
		set jScripts(group,mndnmb)				[jScripts:ConvertSize [lindex $line 9]]
		set jScripts(group,wkuppos)				[lindex $line 10]
		set jScripts(group,wkupmb)				[jScripts:ConvertSize [lindex $line 11]]
		set jScripts(group,wkdnpos)				[lindex $line 12]
		set jScripts(group,wkdnmb)				[jScripts:ConvertSize [lindex $line 13]]
		set jScripts(group,dayuppos)			[lindex $line 14]
		set jScripts(group,dayupmb)				[jScripts:ConvertSize [lindex $line 15]]
		set jScripts(group,daydnpos)			[lindex $line 16]
		set jScripts(group,daydnmb)				[jScripts:ConvertSize [lindex $line 17]]
		
		if { $jScripts(skin,group,head) != "" } { 
		
			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,head)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,head)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,head)]" }

		}
		
		if { $jScripts(skin,group,body,allup) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,allup)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,allup)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,allup)]" }

		}
		
		if { $jScripts(skin,group,body,alldn) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,alldn)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,alldn)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,alldn)]" }

		}

		if { $jScripts(skin,group,body,mnup) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,mnup)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,mnup)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,mnup)]" }

		}

		if { $jScripts(skin,group,body,mndn) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,mndn)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,mndn)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,mndn)]" }

		}

		if { $jScripts(skin,group,body,wkup) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,wkup)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,wkup)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,wkup)]" }

		}

		if { $jScripts(skin,group,body,wkdn) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,wkdn)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,wkdn)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,wkdn)]" }

		}

		if { $jScripts(skin,group,body,dayup) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,dayup)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,dayup)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,dayup)]" }

		}

		if { $jScripts(skin,group,body,daydn) != "" } { 

			if { $jScripts(default,show,group) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,group,body,daydn)] }
			if { $jScripts(default,show,group) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,group,body,daydn)] }
			if { $jScripts(default,show,group) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,group,body,daydn)]" }

		}

	}

}

# SHOWS USer Info
proc jScripts:USER { nick uhost hand chan text } {
	
	global jTQ jSB jScripts
	
	if { !$jScripts(enable,user) } { return }
	
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

#
proc jScripts:ConvertSize { bytes } {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: -> jScripts:ConvertSize $bytes" }

	for {set i 0} {$bytes >= 1024.} {incr i} { set bytes [expr $bytes / 1024.] }
	#set post "B kB MB GB TB PB"
	set post "MB GB TB PB"
	#return [format "%7u [lindex $post $i]" $bytes]
	return [format "%.2f[lindex $post $i]" $bytes]

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

proc jScripts:Glob { sdir ilevel ssection } {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: -> $sdir $ilevel $ssection" }

	set ldir [glob -nocomplain -directory $sdir *]
	
	if {[llength $ldir] == 0} { return }

	foreach ndir $ldir {
	
		if { ![file exist $ndir] } { continue }
		
		if { $jScripts(approve,found) } { break }
		
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: '$ndir'" }
		
		if { [string match -nocase "*$jScripts(approve,release)" $ndir] } {
		
			set jScripts(approve,found)	true
			
			set temp	[jScripts:FormatString $jScripts(skin,approve,dir)]
			
			file mkdir "$ndir/$temp"
			
			break
						
		}
		
		if {($ilevel > 1) && ([file exists $ndir]) } {
		
			jScripts:Glob $ndir [expr $ilevel-1] $ssection
		
		}

	}

}

####################################################
# APPROVE                                          #
####################################################
proc jScripts:APPROVE { nick uhost hand chan text } {
  
	global jTQ jSB jScripts
	
	if { !$jScripts(enable,approve) } { return }
	
	set jScripts(approve,release)	""
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:APPROVE { $nick $uhost $hand $chan '$text' }" }
	
	if { [lindex $text 0] == "" } { return }
	
	set jScripts(approve,release) [lindex $text 0]
	
	set jScripts(approve,found)	false
	
	#putlog "$jScripts(approve,release)"
	#putlog "$jScripts(approve,list)"
	
	set jScripts(approve,user)				$nick
	set jScripts(approve,date)				[clock format [clock seconds] -format "%Y.%m.%d"]
	
	foreach path $jScripts(approve,list) {
		
		set n [split $path "|"]
		
		set pth	[lindex $n 0]
		set lvl	[lindex $n 1]
		set sct	[lindex $n 2]
		
		set jScripts(approve,section) $sct
		
		jScripts:Glob $pth $lvl $sct
		
		if { $jScripts(approve,found) } { break }
		
	}
	
	if { !$jScripts(approve,found) } {
		
		jScripts:SND $chan [jScripts:FormatString $jScripts(skin,approve,notfound)]
			
	} else {
		
		jScripts:SND $chan [jScripts:FormatString $jScripts(skin,approve,anounce)]
		
	}
	
}

####################################################
# SHOW RANK                                        #
####################################################
proc jScripts:RANK { nick uhost hand chan text } {
  
	global jTQ jSB jScripts
	
	if { !$jScripts(enable,rank) } { return }
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:RANK { $nick $uhost $hand $chan $text }" }
	
	if { [lindex $text 0] == "" } { return }
	
	set jScripts(rank,user) [lindex $text 0]
	
	set jScripts(rank,type)	$jScripts(rank,default,type)
	
	if { [lindex $text 1] != "" } {
		
		set jScripts(typefound)	false
		
		foreach Type $jScripts(rank,types) {
			
			if { $jScripts(typefound) } { break }
			
			if { $Type == [string toupper [lindex $text 1]] } {
				
				set jScripts(rank,type) $Type
				
				set jScripts(typefound)	true
				
			}
			
		}	
			
	}
	
	set jScripts(isup)		false
	set jScripts(isdn)		false	
	
	if { [string match -nocase "*DN" "$jScripts(rank,type)"] != 0 } {
		
		set jScripts(isdn)		true	
		
	} else {
		
		set jScripts(isup)		true
		
	}

	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts(isup)=$jScripts(isup)" }
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts(isdn)=$jScripts(isdn)" }

	set jScripts(user,found)	false
	
	foreach stssect $jScripts(rank,sections) {
		
		set n [split $stssect ":"]
		
		set jScripts(rank,section)								[lindex $n 0]
		set jScripts(rank,section,nr)							[lindex $n 1]
		
	  	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWUSERSRANK [lindex $text 0] $jScripts(rank,type) $jScripts(rank,section,nr)" }
	  	
	  	set status 	[catch { exec -- $jScripts(location_jScripts) SHOWUSERSRANK [lindex $text 0] $jScripts(rank,type) $jScripts(rank,section,nr) } result]
	
		if { $status > 0 } { 
			putlog "..jS....: $jScripts(location_jScripts) SHOWUSERSRANK [lindex $text 0] $jScripts(rank,type) $jScripts(rank,section,nr) FAiLED ($result)"
			jScripts:SND $jTQ(default_admin_chan) "..jS....: SHOWUSERSRANK [lindex $text 0] $jScripts(rank,type) $jScripts(rank,section,nr) FAiLED ($result)"
			return
		}
	
		set data [split $result "\n"]
		
		set count 0
		
		set jScripts(isfirst)	false
		set jScripts(islast)		false
		
		foreach line $data {
			
			if { $line == "" } { continue }
			
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
			
			if { $count == 0 } {
				
				set jScripts(rank,01,pos)				[lindex $line 0]
				set jScripts(rank,01,name)				[lindex $line 1]
				set jScripts(rank,01,group)			[lindex $line 2]
				set jScripts(rank,01,flags)			[lindex $line 3]
				set jScripts(rank,01,mb)				[lindex $line 4]
				set jScripts(rank,01,files)			[lindex $line 5]
				set jScripts(rank,01,speed)			[lindex $line 6]
				
				if { $jScripts(rank,user) == $jScripts(rank,01,name) } {
					
					set jScripts(isfirst)	true
					
				}
			
			}
		
			if { $count == 1 } {
				
				set jScripts(rank,02,pos)				[lindex $line 0]
				set jScripts(rank,02,name)				[lindex $line 1]
				set jScripts(rank,02,group)			[lindex $line 2]
				set jScripts(rank,02,flags)			[lindex $line 3]
				set jScripts(rank,02,mb)				[lindex $line 4]
				set jScripts(rank,02,files)			[lindex $line 5]
				set jScripts(rank,02,speed)			[lindex $line 6]
			
			}

			if { $count == 2 } {
				
				set jScripts(rank,03,pos)				[lindex $line 0]
				set jScripts(rank,03,name)				[lindex $line 1]
				set jScripts(rank,03,group)			[lindex $line 2]
				set jScripts(rank,03,flags)			[lindex $line 3]
				set jScripts(rank,03,mb)				[lindex $line 4]
				set jScripts(rank,03,files)			[lindex $line 5]
				set jScripts(rank,03,speed)			[lindex $line 6]
			
				if { $jScripts(rank,user) == $jScripts(rank,03,name) } {
					
					set jScripts(islast)	true
					
				}
			
			}
			
			incr count
		
		}
		
		if { $count > 0 } {
			
			set jScripts(user,found)	true
			
		}
		
		if { !$jScripts(user,found) } {
			
			if { $jScripts(default,show,rank) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,rank,usernotfound)] }
			if { $jScripts(default,show,rank) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,rank,usernotfound)] }
			if { $jScripts(default,show,rank) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,rank,usernotfound)]" }
			
			break
				
		}
		
		if { $jScripts(isup) } {
			
			set jScripts(rank,dif,up)	[expr $jScripts(rank,01,mb) - $jScripts(rank,02,mb)]

			set jScripts(rank,01,mb)				[jScripts:ConvertSize $jScripts(rank,01,mb)]
			set jScripts(rank,02,mb)				[jScripts:ConvertSize $jScripts(rank,02,mb)]
			set jScripts(rank,03,mb)				[jScripts:ConvertSize $jScripts(rank,03,mb)]
			
			set jScripts(rank,dif,up)	[jScripts:ConvertSize $jScripts(rank,dif,up)]
			
			if { $jScripts(isfirst) } {
				
				if { $jScripts(default,show,rank) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,rank,first,up)] }
				if { $jScripts(default,show,rank) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,rank,first,up)] }
				if { $jScripts(default,show,rank) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,rank,first,up)]" }
			
			} else {
				
				if { $jScripts(islast) } {
					
					if { $jScripts(default,show,rank) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,rank,last,up)] }
					if { $jScripts(default,show,rank) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,rank,last,up)] }
					if { $jScripts(default,show,rank) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,rank,last,up)]" }
				
				} else {
				
					if { $jScripts(default,show,rank) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,rank,normal,up)] }
					if { $jScripts(default,show,rank) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,rank,normal,up)] }
					if { $jScripts(default,show,rank) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,rank,normal,up)]" }
				
				}
				
			}
			
		}
		
		if { $jScripts(isdn) } {
			
			set jScripts(rank,dif,dn)	[expr $jScripts(rank,01,mb) - $jScripts(rank,02,mb)]
			
			set jScripts(rank,01,mb)				[jScripts:ConvertSize $jScripts(rank,01,mb)]
			set jScripts(rank,02,mb)				[jScripts:ConvertSize $jScripts(rank,02,mb)]
			set jScripts(rank,03,mb)				[jScripts:ConvertSize $jScripts(rank,03,mb)]
			
			set jScripts(rank,dif,dn)	[jScripts:ConvertSize $jScripts(rank,dif,dn)]
			
			if { $jScripts(isfirst) } {
				
				if { $jScripts(default,show,rank) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,rank,first,dn)] }
				if { $jScripts(default,show,rank) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,rank,first,dn)] }
				if { $jScripts(default,show,rank) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,rank,first,dn)]" }
				
			} else {
				
				if { $jScripts(islast) } {
					
					if { $jScripts(default,show,rank) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,rank,last,dn)] }
					if { $jScripts(default,show,rank) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,rank,last,dn)] }
					if { $jScripts(default,show,rank) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,rank,last,dn)]" }
				
				} else {
				
					if { $jScripts(default,show,rank) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr2ng $jScripts(skin,rank,normal,dn)] }
					if { $jScripts(default,show,rank) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr2ng $jScripts(skin,rank,normal,dn)] }
					if { $jScripts(default,show,rank) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr2ng $jScripts(skin,rank,normal,dn)]" }
				
				}
				
			}
			
		}
		
	}
	
}

####################################################
# TODO                                             #
####################################################
proc jScripts:TODO {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
  	if { !($jScripts(enable,todo)) } { return }
  	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:TODO {$nick $uhost $hand $chan $text}" }
	
  	set jScripts(todo,add)	true		;#if text should be added to list
  	
  	if { [lindex $text 0] == "" } {
  		
  		if { $jScripts(enable,list,todo,admin) && ( $chan != $jScripts(default_admin_chan) ) } { return }
  		
  		set jScripts(todo,add)	false
  		
  		if { $jScripts(skin,todo,head) != "" } {
  			
			if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,head)] }
			if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,head)] }
			if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,head)]" }
		
		}
	
		set FILE [open "$jScripts(location,todo)$jScripts(location,todo,filename)" "r"]
		
		set i 1
		
		while {![eof $FILE]} {
		
			set line [gets $FILE]
			
			if { $line == "" } { continue }
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
			
			set jScripts(TodoNumber)	$i
			set jScripts(TodoText)		$line
				
			if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,body)] }
			if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,body)] }
			if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,body)]" }
			
			incr i
			
		}
		
		if { $i < 2 } {
			
			if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,body,nothing)] }
			if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,body,nothing)] }
			if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,body,nothing)]" }
			
				
		}
		
		close $FILE
  			
  		if { $jScripts(skin,todo,foot) != "" } {
  			
			if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,foot)] }
			if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,foot)] }
			if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,foot)]" }
		
		}
		
  	}
		
  	if { [string tolower [lindex $text 0]] == "delete" } {
  		
		set jScripts(todo,add)	false
		
		if { [lindex $text 1] == "" } {
			
			if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,del,help)] }
			if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,del,help)] }
			if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,del,help)]" }
				
		}
		
		set jScripts(todo,del,found)	false		;#if found the number to remove in todo file
		
		set FILE [open "$jScripts(location,todo)$jScripts(location,todo,filename)" "r"]
		set lines [read $FILE]
		close $FILE
		unset FILE
		
		set FILE [open "$jScripts(location,todo)$jScripts(location,todo,filename)" "w"]
		close $FILE
		unset FILE
		
		set i 1
		
		foreach line [split $lines "\n"] {
		
			if { $line == "" } { continue }
			#if { $jScripts(todo,del,found) } { break }
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
			
			if { $i != [lindex $text 1] } {
				
				jScripts:LOG "$jScripts(location,todo)$jScripts(location,todo,filename)" "TODO" "$line"				
					
			} 
			
			if { $i == [lindex $text 1] } {
				
				set jScripts(todo,del,found)	true
				
				if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,del)] }
				if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,del)] }
				if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,del)]" }
					
			} 
			
			incr i
			
		}
		
		if { !$jScripts(todo,del,found) } {
		
			if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,del,notfound)] }
			if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,del,notfound)] }
			if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,del,notfound)]" }
				
			jScripts:TODO $nick $uhost $hand $chan ""
			
		}

  	}
		
  	if { $jScripts(todo,add) } {
  		
  		set jScripts(TodoName)			$nick
  		set jScripts(TodoText)			$text
  		
  		jScripts:LOG "$jScripts(location,todo)$jScripts(location,todo,filename)" "TODO" "[jScripts:FormatStr1ng $jScripts(skin,todo,line)]"

		if { $jScripts(default,show,todo) == "chan" } 				{ jScripts:SND $chan [jScripts:FormatStr1ng $jScripts(skin,todo,add)] }
		if { $jScripts(default,show,todo) == "private" }			{ jScripts:SND $nick [jScripts:FormatStr1ng $jScripts(skin,todo,add)] }
		if { $jScripts(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jScripts:FormatStr1ng $jScripts(skin,todo,add)]" }

	}
	
  	return

}

####################################################
# DUPE                                             #
####################################################
proc jScripts:DUPE {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:DUPE {$nick $uhost $hand $chan $text}" }
	
 	if { !($jScripts(enable,dupe)) || [lindex $text 0] == "" } { return }
 	
 	set args [lindex $text 0]
 	for {set i 1} {$i < [llength $text]} {incr i} {
 		
 		set args	[concat $args "%[lindex $text $i]"]
 		putlog "- $i $args -"
 	}
 	regsub -all -- { } $args {} args
 	putlog $args
  	
  	#set status 	[catch { exec -- $jScripts(location_jScripts) DUPE [lindex $text 0] } result]
  	set status 	[catch { exec -- $jScripts(location_dupe) DUPE $args } result]

	if { $status > 0 } { 
		putlog "..jS....: $jScripts(location_dupe) DUPE $text FAiLED ($result)"
		jScripts:SND $jTQ(default_admin_chan) "..jS....: DUPE $text FAiLED ($result)"
		return
	}

	set data [split $result "\n"]
	
	set count -1
	
	foreach line $data {
		
		if { $line == "" } { continue }
		incr count
		
		if { !($jScripts(enable,dupe,head)) && ($count == 0) } { continue }
		
		if { $count <= $jScripts(default,show,dupe,number) } {
			
			if { $jScripts(default,show,dupe) == "chan" } 			{ jScripts:SND $chan "$jScripts(skin,dupe,head)$line" }
			if { $jScripts(default,show,dupe) == "private" }		{ jScripts:SND $nick "$jScripts(skin,dupe,head)$line" }
			if { $jScripts(default,show,dupe) == "notice" }			{ putquick "NOTICE $nick :$jScripts(skin,dupe,head)$line" }
			
		
		}
					
	}
	
  	return

}

####################################################
# UNDUPE                                           #
####################################################
proc jScripts:UNDUPE {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:UNDUPE {$nick $uhost $hand $chan $text}" }
	
  	if { !($jScripts(enable,undupe)) || [lindex $text 0] == "" } { return }
  	
  	set status 	[catch { exec -- $jScripts(location_dupe) UNDUPE [lindex $text 0] } result]

	if { $status > 0 } { 
		putlog "..jS....: $jScripts(location_dupe) UNDUPE [lindex $text 0] FAiLED ($result)"
		jScripts:SND $jTQ(default_admin_chan) "..jS....: UNDUPE [lindex $text 0] FAiLED ($result)"
		return
	}

	set data [split $result "\n"]
	
	foreach line $data {
	
		if { $jScripts(default_show_undupe) == "chan" } 		{ jScripts:SND $chan "$jScripts(skin,undupe,head)$line" }
		if { $jScripts(default_show_undupe) == "private" }		{ jScripts:SND $nick "$jScripts(skin,undupe,head)$line" }
		if { $jScripts(default_show_undupe) == "notice" }		{ putquick "NOTICE $nick :$jScripts(skin,undupe,head)$line" }
			
	}
	
  	return

}

####################################################
# KiCK iDLERS                                      #
####################################################
proc jScripts:KiCKiDLERS {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:KiCKiDLERS {$nick $uhost $hand $chan $text}" }
	
  	if { !($jScripts(enable,sitekill)) } { return }
  	
  	if { $jScripts(enable_partyline) } { putlog "..jS....: Kicking IDLERS For '$nick'" }
  	
  	set status 	[catch { exec -- $jScripts(location_sitekill) group!=$jScripts(sitekill,exclude) "idletime>$jScripts(sitekill,idletime)" "service=$jScripts(sitekill,service)" } result]

	if { $status > 0 } { 
		putlog "..jS....: $jScripts(location_sitekill) group!=$jScripts(sitekill,exclude) \"idletime>$jScripts(sitekill,idletime)\" \"service=$jScripts(sitekill,service)\" FAiLED ($result)"
		jScripts:SND $jTQ(default_admin_chan) "..jS....: group!=$jScripts(location_sitekill) group!=$jScripts(sitekill,exclude) \"idletime>$jScripts(sitekill,idletime)\" \"service=$jScripts(sitekill,service)\" FAiLED ($result)"
		return
	}

	set data [split $result "\n"]
	
	foreach line $data {
	
		if { $jScripts(default_show_kill) == "chan" } 			{ jScripts:SND $chan $line }
		if { $jScripts(default_show_kill) == "private" }		{ jScripts:SND $nick $line }
		if { $jScripts(default_show_kill) == "notice" }			{ putquick "NOTICE $nick :$line" }
			
	}
	
  	#set output 		[jScripts:FormatString $jScripts(skin_bnc_ncftpls_yes)]
  	
  	return

}

####################################################
# SHOW DAYSTATS                                    #
####################################################
proc jScripts:DAYSTATS {min hour day month year} {
  
	global jTQ jSB jScripts
	
	if { !$jScripts(enable,daystats) } { return }
	
	foreach stssect $jScripts(daystatsup,default,show) {
		
		set n [split $stssect ":"]
		
		set jScripts(stats,default,name)	[lindex $n 0]
		set jScripts(stats,section)		[lindex $n 1]
		set jScripts(stats,anounce,chan)	[lindex $n 2]
		
		if { $jScripts(enable_partyline) } { putlog "..jS....: DAYUP STATS For $jScripts(stats,default,name)" }
		
		if { $jScripts(enable,daystatsup,head) } {
			
			set output 									[jScripts:FormatStr1ng $jScripts(skin,daystatsup,head)]
			
			jScripts:SND $jScripts(stats,anounce,chan) $output
				
		}
			
		if { $jScripts(enable,daystatsup,body) } {
			
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsup,excludedgroups,list)\" \"$jScripts(daystatsup,excludedusers,list)\" \"$jScripts(daystatsup,excludedflags,list)\" $jScripts(daystatsup,default,type) $jScripts(daystatsup,default,number) $jScripts(stats,section) " }
				
			set status 	[catch { exec -- $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsup,excludedgroups,list)\" \"$jScripts(daystatsup,excludedusers,list)\" \"$jScripts(daystatsup,excludedflags,list)\" $jScripts(daystatsup,default,type) $jScripts(daystatsup,default,number) $jScripts(stats,section)  } result]
			
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: STATUS = $status" }
			
			if { $status > 0 } { 
				
				putlog "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsup,excludedgroups,list)\" \"$jScripts(daystatsup,excludedusers,list)\" \"$jScripts(daystatsup,excludedflags,list)\" $jScripts(daystatsup,default,type) $jScripts(daystatsup,default,number) $jScripts(stats,section) FAiLED ($result)"
				jScripts:SND $jScripts(default_admin_chan) "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsup,excludedgroups,list)\" \"$jScripts(daystatsup,excludedusers,list)\" \"$jScripts(daystatsup,excludedflags,list)\" $jScripts(daystatsup,default,type) $jScripts(daystatsup,default,number) $jScripts(stats,section) FAiLED ($result)"
				break
				
			}
			
			set data [split $result "\n"]
			
			set j 1
			
			foreach line $data {
				
				if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
				
				set jScripts(stats,pos)			$j
				set jScripts(stats,user)		[lindex $line 1]
				set jScripts(stats,group)		[lindex $line 2]
				set jScripts(stats,mb)			[lindex $line 4]
				set jScripts(stats,files)		[lindex $line 5]
				set jScripts(stats,speed)		[lindex $line 6]
				
				set output 				[jScripts:FormatStr1ng $jScripts(skin,daystatsup,body)]
				
				jScripts:SND $jScripts(stats,anounce,chan) $output
		
				incr j
				
			}
	
		}
		
		if { $jScripts(enable,daystatsup,foot) } {
			
			set output 				[jScripts:FormatStr1ng $jScripts(skin,daystatsup,foot)]
			
			jScripts:SND $jScripts(stats,anounce,chan) $output
	
		}
		
	}

	#LEECH DA STATS

	foreach stssect $jScripts(daystatsdn,default,show) {
		
		set n [split $stssect ":"]
		
		set jScripts(stats,default,name)	[lindex $n 0]
		set jScripts(stats,section)		[lindex $n 1]
		set jScripts(stats,anounce,chan)	[lindex $n 2]
		
		if { $jScripts(enable_partyline) } { putlog "..jS....: DAYDN STATS For $jScripts(stats,default,name)" }
		
		if { $jScripts(enable,daystatsdn,head) } {
			
			set output 									[jScripts:FormatStr1ng $jScripts(skin,daystatsdn,head)]
			
			jScripts:SND $jScripts(stats,anounce,chan) $output
				
		}
			
		if { $jScripts(enable,daystatsdn,body) } {
			
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsdn,excludedgroups,list)\" \"$jScripts(daystatsdn,excludedusers,list)\" \"$jScripts(daystatsdn,excludedflags,list)\" $jScripts(daystatsdn,default,type) $jScripts(daystatsdn,default,number) $jScripts(stats,section) " }
			
			set status 	[catch { exec -- $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsdn,excludedgroups,list)\" \"$jScripts(daystatsdn,excludedusers,list)\" \"$jScripts(daystatsdn,excludedflags,list)\" $jScripts(daystatsdn,default,type) $jScripts(daystatsdn,default,number) $jScripts(stats,section) } result]
			
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: STATUS = $status" }
			
			if { $status > 0 } { 
				
				putlog "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsdn,excludedgroups,list)\" \"$jScripts(daystatsdn,excludedusers,list)\" \"$jScripts(daystatsdn,excludedflags,list)\" $jScripts(daystatsdn,default,type) $jScripts(daystatsdn,default,number) $jScripts(stats,section) FAiLED ($result)"
				jScripts:SND $jScripts(default_admin_chan) "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(daystatsdn,excludedgroups,list)\" \"$jScripts(daystatsdn,excludedusers,list)\" \"$jScripts(daystatsdn,excludedflags,list)\" $jScripts(daystatsdn,default,type) $jScripts(daystatsdn,default,number) $jScripts(stats,section) FAiLED ($result)"
				break
				
			}
			
			set data [split $result "\n"]
			
			set j 1
			
			foreach line $data {
				
				if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
				
				set jScripts(stats,pos)			$j
				set jScripts(stats,user)		[lindex $line 1]
				set jScripts(stats,group)		[lindex $line 2]
				set jScripts(stats,mb)			[lindex $line 4]
				set jScripts(stats,files)		[lindex $line 5]
				set jScripts(stats,speed)		[lindex $line 6]
				
				set output 				[jScripts:FormatStr1ng $jScripts(skin,daystatsdn,body)]
				
				jScripts:SND $jScripts(stats,anounce,chan) $output
				
				incr j
		
			}
	
		}
		
		if { $jScripts(enable,daystatsdn,foot) } {
			
			set output 				[jScripts:FormatStr1ng $jScripts(skin,daystatsdn,foot)]
			
			jScripts:SND $jScripts(stats,anounce,chan) $output
	
		}
	
	}

	return
	
}

proc jScripts:FiNDUser { user type } {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:FiNDUser { $user $type }" }
	
	set jScripts(text,back)	""
	set jScripts(ok)			true
	
	foreach sct $jScripts(stats,sections) {
		
		set n [split $sct ":"]
		
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $jScripts(location_jScripts) GETSTATS $user $type [lindex $n 1] " }
		
		set status 	[catch { exec -- $jScripts(location_jScripts) GETSTATS $user $type [lindex $n 1] } result]
		
		#set result "[expr {int(rand()*100)}] $user iND 3 [expr {int(rand()*999999)}]"
		
		if { $status > 0 } { 
			
			putlog "..jS....: $jScripts(location_jScripts) GETSTATS $user $type [lindex $n 1] FAiLED ($result)"
			jScripts:SND $jScripts(default_admin_chan) "..jS....: $jScripts(location_jScripts) GETSTATS $user $type [lindex $n 1] FAiLED ($result)"
			break
			
		}
		
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: result='$result'" }
		
		if { $result != "" } {
			
			lappend jScripts(text,back) $result
		
		} else {
			
			set jScripts(ok)			false
			
		}
		
	}
				
	if { $jScripts(ok) } {
		
		return $jScripts(text,back)
		
	} else {
		
		return "no"
			
	}
	
}

####################################################
# SHOW STATS                                       #
####################################################
proc jScripts:STATS { nick uhost hand chan text } {
  
	global jTQ jSB jScripts
	
	if { !$jScripts(enable_stats) } { return }
	
	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG STATS '$text' To '$nick'" }
	
	set jScripts(stats,text)				[lindex $text 1]	;#%Q
	
	regsub -all -- {\.} $jScripts(stats,text) { } jScripts(stats,text)	
	
	set jScripts(stats,default,type)		[lindex $text 0]
	
	set jScripts(stats,get)					""
	
	if { ([lindex $text 2] == "") } {
		
		set jScripts(stats,user,found) false
		
	} else {
		
		set jScripts(stats,get)	[jScripts:FiNDUser [lindex $text 2] $jScripts(stats,default,type)]
		
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts(stats,get)='$jScripts(stats,get)'" }
			
		if { $jScripts(stats,get) == "no" } {
			
			set jScripts(stats,user,found) false

		} else {
			
			set jScripts(stats,user,found) true
		
			set i 0
			
			foreach sct $jScripts(stats,sections) {
				
				set n [split $sct ":"]
				
				set jScripts(stats,section) 			[lindex $n 0]
				set jScripts(stats,default,section) [lindex $n 1]
				
				#{pos user group mb} {pos user group mb}
				
				set result [lindex $jScripts(stats,get) $i]
				
				set jScripts(stats,pos)			[lindex $result 0]
				set jScripts(stats,user)		[lindex $result 1]
				set jScripts(stats,group)		[lindex $result 2]
				set jScripts(stats,mb)			[lindex $result 4]
				set jScripts(stats,files)		[lindex $result 5]
				set jScripts(stats,speed)		[lindex $result 6]
				
				set output 				[jScripts:FormatStr1ng $jScripts(skin,stats,user)]
				
				if { $jScripts(default_show_stats) == "chan" } 				{ jScripts:SND $chan $output }
				if { $jScripts(default_show_stats) == "private" }			{ jScripts:SND $nick $output }
				if { $jScripts(default_show_stats) == "notice" }			{ putquick "NOTICE $nick :$output" }
				
				incr i
						
			}
			
			return
			
		}

	}
		
	if { (!$jScripts(stats,user,found)) } {
		
		foreach sct $jScripts(stats,sections) {
			
			set n [split $sct ":"]
			
			set jScripts(stats,section) 			[lindex $n 0]
			set jScripts(stats,default,section) [lindex $n 1]
			
			if { $jScripts(enable_stats_head) } {
				
				set output 									[jScripts:FormatStr1ng $jScripts(skin,stats,head)]
				
				if { $jScripts(default_show_stats) == "chan" } 				{ jScripts:SND $chan $output }
				if { $jScripts(default_show_stats) == "private" }			{ jScripts:SND $nick $output }
				if { $jScripts(default_show_stats) == "notice" }			{ putquick "NOTICE $nick :$output" }
					
			}
				
			if { $jScripts(enable_stats) } {
			
				if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(stats,excludedgroups,list)\" \"$jScripts(stats,excludedusers,list)\" \"$jScripts(stats,excludedflags,list)\" $jScripts(stats,default,type) $jScripts(stats,default,number) $jScripts(stats,default,section) " }
				
				set status 	[catch { exec -- $jScripts(location_jScripts) DAYSTATS \"$jScripts(stats,excludedgroups,list)\" \"$jScripts(stats,excludedusers,list)\" \"$jScripts(stats,excludedflags,list)\" $jScripts(stats,default,type) $jScripts(stats,default,number) $jScripts(stats,default,section) } result]
				
				if { $status > 0 } { 
					
					putlog "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(stats,excludedgroups,list)\" \"$jScripts(stats,excludedusers,list)\" \"$jScripts(stats,excludedflags,list)\" $jScripts(stats,default,type) $jScripts(stats,default,number) $jScripts(stats,default,section) FAiLED ($result)"
					jScripts:SND $jScripts(default_admin_chan) "..jS....: $jScripts(location_jScripts) DAYSTATS \"$jScripts(stats,excludedgroups,list)\" \"$jScripts(stats,excludedusers,list)\" \"$jScripts(stats,excludedflags,list)\" $jScripts(stats,default,type) $jScripts(stats,default,number) $jScripts(stats,default,section) FAiLED ($result)"
					break
					
				}
						
				set data [split $result "\n"]
				
				set i 1
				
				foreach line $data {
					
					if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
					
					set jScripts(stats,pos)			$i
					set jScripts(stats,user)		[lindex $line 1]
					set jScripts(stats,group)		[lindex $line 2]
					set jScripts(stats,mb)			[lindex $line 4]
					set jScripts(stats,files)		[lindex $line 5]
					set jScripts(stats,speed)		[lindex $line 6]
					
					set output 				[jScripts:FormatStr1ng $jScripts(skin,stats,body)]
					
					if { $jScripts(default_show_stats) == "chan" } 				{ jScripts:SND $chan $output }
					if { $jScripts(default_show_stats) == "private" }			{ jScripts:SND $nick $output }
					if { $jScripts(default_show_stats) == "notice" }			{ putquick "NOTICE $nick :$output" }
					
					incr i
			
				}
				
			}
		
			if { $jScripts(enable_stats_foot) } {
		
				set output 				[jScripts:FormatStr1ng $jScripts(skin,stats,foot)]
				
				if { $jScripts(default_show_stats) == "chan" } 				{ jScripts:SND $chan $output }
				if { $jScripts(default_show_stats) == "private" }			{ jScripts:SND $nick $output }
				if { $jScripts(default_show_stats) == "notice" }			{ putquick "NOTICE $nick :$output" }
			
			}	
		
		}
		
	}
	
	return
		
}

####################################################
# READ FiLES iN TRiGGRES DiR                       #
####################################################
proc jScripts:TRiGGERS { nick uhost hand chan text } {
  
	global jTQ jSB jScripts
	
	if { !$jScripts(enable_triggers) } { return }
	
	if { ![file exists "$jScripts(location_triggers)[lindex $text 0]"] } {
		
		if { $jScripts(enable_partyline) } { putlog "..jS....: $jScripts(location_triggers)[lindex $text 0] Not Found!" }

		return
		
	}
	
	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG TRiGGER [lindex $text 0] To '$nick'" }
	
	set FILE [open "$jScripts(location_triggers)[lindex $text 0]" "r"]
	
	while {![eof $FILE]} {
	
		set line [gets $FILE]
	
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
			
		if { $jScripts(default_show_triggers) == "chan" } 				{ jScripts:SND $chan $line }
		if { $jScripts(default_show_triggers) == "private" }			{ jScripts:SND $nick $line }
		if { $jScripts(default_show_triggers) == "notice" }			{ putquick "NOTICE $nick :$line" }
		
	}
	
	close $FILE
	
	return
  
}

####################################################
# DEL REQUEST                                      #
####################################################
proc jScripts:REQDEL {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { [lindex $text 0] == "" } { return }

	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:REQDEL {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_reqdel) } { return }

	set status 	[catch { exec -- $jScripts(location_ioA) REQDELIRC [lindex $text 0] } result]
	
	set data [split $result "\n"]
	
	set i 0
	
	foreach line $data {
		
		if { $i == 1 } {
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
			
			if { $jScripts(default_show_reqdel) == "chan" } 			{ jScripts:SND $chan $line }
			if { $jScripts(default_show_reqdel) == "private" }			{ jScripts:SND $nick $line }
			if { $jScripts(default_show_reqdel) == "notice" }			{ putquick "NOTICE $nick :$line" }

		}
		
		incr i
		
	}
	
	return
	
}

####################################################
# FILL REQUEST                                     #
####################################################
proc jScripts:REQFILL {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { [lindex $text 0] == "" } { return }

	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:REQFILL {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_reqfill) } { return }

	set status 	[catch { exec -- $jScripts(location_ioA) REQFILLEDIRC [lindex $text 0] } result]
	
	set data [split $result "\n"]
	
	set i 0
	
	foreach line $data {
		
		if { $i == 1 } {
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
			
			if { $jScripts(default_show_reqfill) == "chan" } 			{ jScripts:SND $chan $line }
			if { $jScripts(default_show_reqfill) == "private" }		{ jScripts:SND $nick $line }
			if { $jScripts(default_show_reqfill) == "notice" }			{ putquick "NOTICE $nick :$line" }

		}
		
		incr i
		
	}
	
	return
	
}

####################################################
# ADD REQUEST                                      #
####################################################
proc jScripts:REQADD {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { [lindex $text 0] == "" } { return }

	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:REQADD {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_reqadd) } { return }

	set status 	[catch { exec -- $jScripts(location_ioA) REQUESTIRC [lindex $text 0] } result]
	
	set data [split $result "\n"]
	
	set i 0
	
	foreach line $data {
		
		if { $i == 1 } {
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: $line" }
			
			if { $jScripts(default_show_reqadd) == "chan" } 		{ jScripts:SND $chan $line }
			if { $jScripts(default_show_reqadd) == "private" }		{ jScripts:SND $nick $line }
			if { $jScripts(default_show_reqadd) == "notice" }		{ putquick "NOTICE $nick :$line" }

		}
		
		incr i
		
	}
	
	return
	
}

####################################################
# Shows REQUESTS                                   #
####################################################
proc jScripts:REQUESTS {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:REQUESTS {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_requests) } { return }

	catch { set FILE [open $jScripts(location_requests) r] } 
	
	while {![eof $FILE]} {
		
		set line [gets $FILE]
		
		if { $jScripts(default_show_requests) == "chan" } 			{ jScripts:SND $chan $line }
		if { $jScripts(default_show_requests) == "private" }		{ jScripts:SND $nick $line }
		if { $jScripts(default_show_requests) == "notice" }		{ putquick "NOTICE $nick :$line" }
	
	}
	
	catch { close $FILE } 
	
	return
	
}

####################################################
# Shows IDLE                                       #
####################################################
proc jScripts:IDLE {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:IDLE {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_idle) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO IDLE } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:IDLE RESULT = '$result'" }
	
	if { $result == "no" } {
		
		set output									[jScripts:FormatString $jScripts(skin_who_idle_no)]
		
		if { $jScripts(default_show_idle) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_idle) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_idle) == "notice" }			{ putquick "NOTICE $nick :$output" }

	} else {
		
		foreach line [split $result "\n"] {
			
			if { $line == "" } { continue }
			
			set jScripts(who_username)				[lindex $line 0]
			set jScripts(who_groupname)			[lindex $line 1]
			set jScripts(who_idle_time)			[lindex $line 2]
			set jScripts(who_login_time)			[lindex $line 3]

			set output									[jScripts:FormatString $jScripts(skin_who_idle_yes)]
			
			if { $jScripts(default_show_idle) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_idle) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_idle) == "notice" }			{ putquick "NOTICE $nick :$output" }

		}
			
	}
	
	return
	
}

####################################################
# Shows DN                                         #
####################################################
proc jScripts:DN {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:DN {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable,dn) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO DOWN } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:DN RESULT = '$result'" }
	
	if { $result == "no" } {
		
		set output									[jScripts:FormatString $jScripts(skin,who,dn,no)]
		
		if { $jScripts(default_show_dn) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_dn) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_dn) == "notice" }		{ putquick "NOTICE $nick :$output" }

	} else {
		
		if { $jScripts(enable,dn,head) } { 
			
			set output									[jScripts:FormatString $jScripts(skin,who,dn,head)]
				
			if { $jScripts(default_show_dn) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_dn) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_dn) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
		}
		
		set jScripts(who_dn_count)				0
		set jScripts(who_dn_total_speed)	0
		
		foreach line [split $result "\n"] {
			
			if { $line == "" } { continue }
			if { !$jScripts(enable,dn,body) } { continue }
			
			set jScripts(who_username)				[lindex $line 0]
			set jScripts(who_groupname)			[lindex $line 1]
			set jScripts(who_file_name)			[lindex $line 2]
			set jScripts(who_user_speed)			[lindex $line 3]
			set jScripts(who_bytes_transfered)	[lindex $line 4]
			set jScripts(who_file_size)			[lindex $line 5]
			set jScripts(who_percent_done)		[lindex $line 6]

			set jScripts(who_dn_total_speed)		[expr $jScripts(who_dn_total_speed) + $jScripts(who_user_speed)]
			incr jScripts(who_dn_count)

			set output									[jScripts:FormatString $jScripts(skin,who,dn,yes)]
				
			if { $jScripts(default_show_dn) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_dn) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_dn) == "notice" }		{ putquick "NOTICE $nick :$output" }

		}
			
		if { $jScripts(enable,dn,foot) } { 
			
			set output									[jScripts:FormatString $jScripts(skin,who,dn,foot)]
				
			if { $jScripts(default_show_dn) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_dn) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_dn) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
		}
		
	}
	
	return
	
}

####################################################
# Shows UP                                         #
####################################################
proc jScripts:UP {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:UP {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable,up) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO UP } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:UP RESULT = '$result'" }
	
	if { $result == "no" } {
		
		set output									[jScripts:FormatString $jScripts(skin,who,up,no)]
		
		if { $jScripts(default_show_up) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_up) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_up) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
	} else {
		
		if { $jScripts(enable,up,head) } { 
			
			set output									[jScripts:FormatString $jScripts(skin,who,up,head)]
				
			if { $jScripts(default_show_up) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_up) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_up) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
		}
		
		set jScripts(who_up_count)			0
		set jScripts(who_up_total_speed)	0
		
		foreach line [split $result "\n"] {
		
			if { $line == "" } { continue }
			if { !$jScripts(enable,up,body) } { continue }
		
			set jScripts(who_username)				[lindex $line 0]
			set jScripts(who_groupname)			[lindex $line 1]
			set jScripts(who_file_name)			[lindex $line 2]
			set jScripts(who_user_speed)			[lindex $line 3]
	
			set jScripts(who_up_total_speed)		[expr $jScripts(who_up_total_speed) + $jScripts(who_user_speed)]
			incr jScripts(who_up_count)

			set output									[jScripts:FormatString $jScripts(skin,who,up,yes)]
				
			if { $jScripts(default_show_up) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_up) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_up) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
		}
		
		if { $jScripts(enable,up,foot) } { 
			
			set output									[jScripts:FormatString $jScripts(skin,who,up,foot)]
				
			if { $jScripts(default_show_up) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_up) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_up) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
		}
		
	}
	
	return
	
}

####################################################
# Shows SPEED                                      #
####################################################
proc jScripts:SPEED {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { [lindex $text 0] == "" } { return }

	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:SPEED {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_speed) } { return }
	
	set status 	[catch { exec -- $jScripts(location_jScripts) WHO SPEED [lindex $text 0] } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:SPEED RESULT = '$result'" }
	
	if { [lindex $result 2] == "online" } {
		
		set jScripts(who_username)				[lindex $text 0]
		
		set output									[jScripts:FormatString $jScripts(skin_who_speed_notonline)]

	}
	
	set jScripts(who_username)				[lindex $result 0]
	set jScripts(who_groupname)			[lindex $result 1]
	
	if { [lindex $result 2] == "idle" } {
		
		set jScripts(who_idle_time)			[lindex $result 3]
		set jScripts(who_login_time)			[lindex $result 4]

		set output									[jScripts:FormatString $jScripts(skin_who_speed_idle)]

	}
	
	if { [lindex $result 2] == "uploading" } {
		
		set jScripts(who_file_name)			[lindex $result 3]
		set jScripts(who_user_speed)			[lindex $result 4]

		set output									[jScripts:FormatString $jScripts(skin_who_speed_up)]

	}

	if { [lindex $result 2] == "downloading" } {
		
		set jScripts(who_file_name)			[lindex $result 3]
		set jScripts(who_user_speed)			[lindex $result 4]

		set output									[jScripts:FormatString $jScripts(skin_who_speed_dn)]

	}

	if { $jScripts(default_show_speed) == "chan" } 			{ jScripts:SND $chan $output }
	if { $jScripts(default_show_speed) == "private" }		{ jScripts:SND $nick $output }
	if { $jScripts(default_show_speed) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
	return
	
}

####################################################
# Shows BW                                         #
####################################################
proc jScripts:BW {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:BW {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_bw) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO BW } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:BW RESULT = '$result'" }
	
	set jScripts(who_up_total_speed)		[lindex $result 0]
	set jScripts(who_up_count)				[lindex $result 1]
	set jScripts(who_dn_total_speed)		[lindex $result 2]
	set jScripts(who_dn_count)				[lindex $result 3]
	set jScripts(who_idle_count)			[lindex $result 4]
	set jScripts(who_total_speed)			[lindex $result 5]
	set jScripts(who_total_count)			[lindex $result 6]
	
	set jScripts(speed,up,bw)				[expr { $jScripts(who_up_total_speed) * 100 } / $jScripts(speed,bw,total,up)]
	set jScripts(speed,dn,bw)				[expr { $jScripts(who_dn_total_speed) * 100 } / $jScripts(speed,bw,total,dn)]
	
	set jScripts(speed,sum,up,dn)			[expr $jScripts(who_up_total_speed) + $jScripts(who_dn_total_speed) ]
	set jScripts(speed,sum,total)			[expr $jScripts(speed,bw,total,up) + $jScripts(speed,bw,total,dn)]
	set jScripts(speed,all,bw)				[expr { $jScripts(speed,sum,up,dn) * 100 } / $jScripts(speed,sum,total) ]
	
	set output						[jScripts:FormatString $jScripts(skin_who_bw)]

	if { $jScripts(default_show_bw) == "chan" } 			{ jScripts:SND $chan $output }
	if { $jScripts(default_show_bw) == "private" }		{ jScripts:SND $nick $output }
	if { $jScripts(default_show_bw) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
	return
	
}

####################################################
# Shows WHO                                        #
####################################################
proc jScripts:WHO {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:WHO {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_who) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO ALL } result]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:WHO RESULT = '$result'" }
	
	if { $jScripts(default_show_who) == "chan" } 		{ jScripts:SND $chan $result }
	if { $jScripts(default_show_who) == "private" }		{ jScripts:SND $nick $result }
	if { $jScripts(default_show_who) == "notice" }		{ putquick "NOTICE $nick :$result" }
	
	return
	
}

####################################################
# Checks if dirs for log exists                    #
####################################################
proc jScripts:CHECKLOG {} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:CHECKLOG {}" }
	
	if { $jScripts(enable_jTQ_log) } {
		
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: CHECKiNG $jScripts(log_dir)" }
		
		if {![file exist $jScripts(log_dir)]} { 
			
			if { $jScripts(enable_partyline) } { putlog "..jS....: CREATiNG $jScripts(log_dir)" }
			
			file mkdir "$jScripts(log_dir)"
			
		}
	
		if {![file exist $jScripts(location_triggers)]} { 
			
			if { $jScripts(enable_partyline) } { putlog "..jS....: CREATiNG $jScripts(location_triggers)" }
			
			file mkdir "$jScripts(location_triggers)"
			
		}

		if {![file exist $jScripts(location,todo)]} { 
			
			if { $jScripts(enable_partyline) } { putlog "..jS....: CREATiNG $jScripts(location,todo)" }
			
			file mkdir "$jScripts(location,todo)"
			
		}

		if {![file exist "$jScripts(location,todo)$jScripts(location,todo,filename)"]} {
			
			jScripts:LOG "$jScripts(location,todo)$jScripts(location,todo,filename)" "TODO" ""
			
		}
			
	}
	
	return
	
}

proc jScripts:LOG {what where text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:LOG {$what $where $text}" }
	
	if { ($jScripts(enable_jTQ_log)) && ($where == "jTQ") } {
		
      set file [open "$what" "a+"]
      puts $file "$text"
      close $file
			
	}

	if { ($jScripts(enable,todo)) && ($where == "TODO") } {
		
      set file [open "$what" "a+"]
      puts $file "$text"
      close $file
			
	}

	return
	
}

proc jScripts:BANNED {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:BANNED {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_banned)) } { return }
	
	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG BANNED To '$nick'" }

  	foreach BannedSection [split $jScripts(banned_sections)] {

    	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: BannedSection = '$BannedSection'" }
    	
    	set Banned		""
    
    	foreach Bann $jScripts(banned_$BannedSection) {
      	set Banned 	"$Banned$Bann "
    	}
    
		set jScripts(BannedSection)	$BannedSection
		set jScripts(Banned)				$Banned
		
		set output							[jScripts:FormatString $jScripts(skin_banned)]
		
		if { $jScripts(default_show_banned) == "chan" } 		{ jScripts:SND $chan $output }
		if { $jScripts(default_show_banned) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_banned) == "notice" }		{ putquick "NOTICE $nick :$output" }
		
	}
  
	
	return
	
}

proc jScripts:AFFiLS {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:AFFiLS {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_affils)) } { return }
	
	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG AFFiLS To '$nick'" }

	foreach AffilSection [split $jScripts(affils_sections)] {
	
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: AffilSection = '$AffilSection'" }
		
		set Affils		""
		
		foreach Affil $jScripts(affils_$AffilSection) {
			set Affils "$Affils$Affil "
		}
		
		set jScripts(AffilSection)	$AffilSection
		set jScripts(Affils)			$Affils
		
		set output						[jScripts:FormatString $jScripts(skin_affils)]
		
		if { $jScripts(default_show_affils) == "chan" } 		{ jScripts:SND $chan $output }
		if { $jScripts(default_show_affils) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_affils) == "notice" }		{ putquick "NOTICE $nick :$output" }
		
	}
  
	
	return
	
}

proc jScripts:SECTiONS {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:SECTiONS {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_sections)) } { return }

	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG SECTiONS To '$nick'" }

	foreach SectionSection [split $jScripts(sections_sections)] {
	
		if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: SectionSection = '$SectionSection'" }
		
		set Sections		""
		
		foreach Section $jScripts(sections_$SectionSection) {
			set Sections "$Sections$Section "
		}
		
		set jScripts(SectionSection)	$SectionSection
		set jScripts(Sections)			$Sections
		
		set output						[jScripts:FormatString $jScripts(skin_sections)]
		
		if { $jScripts(default_show_sections) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_sections) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_sections) == "notice" }		{ putquick "NOTICE $nick :$output" }
		
	}
  
	
	return
	
}

proc jScripts:FREESPACE {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:FREESPACE {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_df)) } { return }
	
	if { $jScripts(enable_df_one_line) } {
		
		set jScripts(df_foot_total)	0				;#total 
		set jScripts(df_foot_free)		0				;#total free
		set jScripts(df_foot_per)		0				;#total %
		
		set jScripts(df_body_tmp)		""				;#list for sections space

		foreach DFDisk [split $jScripts(df_disks)] {
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: DFDisk = '$DFDisk'" }
			
			set jScripts(df_body_total)	0
			set jScripts(df_body_free)		0
			set jScripts(df_body_per)		0
			
			set status 	[catch { exec -- $jScripts(location_jScripts) FREESPACE "$DFDisk" } result]
			
			if { $status > 0 } { 
				putlog "..jS....: $jScripts(location_jScripts) FREESPACE $DFDisk FAiLED ($result)"
				jScripts:SND $jTQ(default_admin_chan) "..jS....: $jScripts(location_jScripts) FREESPACE $DFDisk FAiLED ($result)"
				return
			}

			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: result = '$result'" }
			
			if { ![info exists jScripts(df_$DFDisk)] } { continue }
			
			set jScripts(df_body_sct)		$jScripts(df_$DFDisk)
			
			set jScripts(df_body_total)	[lindex $result 0]
			set jScripts(df_body_free)		[lindex $result 1]
			set jScripts(df_body_per)		[expr [expr $jScripts(df_body_free) * 100] / $jScripts(df_body_total)]

			set jScripts(df_foot_total)	[expr $jScripts(df_foot_total) + $jScripts(df_body_total)]
			set jScripts(df_foot_free)		[expr $jScripts(df_foot_free) + $jScripts(df_body_free)]

			set body								[jScripts:FormatString $jScripts(skin_df_body)]
			
			lappend jScripts(df_body_tmp) $body
			
		}
		
		regsub -all -- {\{|\}} $jScripts(df_body_tmp) {} jScripts(df_body_tmp)
		
		set jScripts(df_foot_per)			[expr [expr $jScripts(df_foot_free) * 100] / $jScripts(df_foot_total)]
		
		set outhead								[jScripts:FormatString "$jScripts(skin_df_head)"]
		set outbody								"$jScripts(df_body_tmp)"
		set outfoot								[jScripts:FormatString "$jScripts(skin_df_foot)"]
		
		set output								"$outhead$outbody$outfoot"
	
	} else {
		
		if { $jScripts(enable_df_head) } {
			
			set output								[jScripts:FormatString "$jScripts(skin_df_head)"]
			
			if { $jScripts(default_show_df) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jScripts(default_show_df) == "private" }		{ jScripts:SND $nick $output }
			if { $jScripts(default_show_df) == "notice" }		{ putquick "NOTICE $nick :$output" }

		}

		set jScripts(df_foot_total)	0				;#total 
		set jScripts(df_foot_free)		0				;#total free
		set jScripts(df_foot_per)		0				;#total %
		
		set jScripts(df_body_tmp)		""				;#list for sections space

		set count	0
		set i			0
		set total	[llength $jScripts(df_disks)]
		
		foreach DFDisk [split $jScripts(df_disks)] {
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: DFDisk = '$DFDisk'" }
			
			set jScripts(df_body_total)	0
			set jScripts(df_body_free)		0
			set jScripts(df_body_per)		0
			
			incr count
			incr i
			
			set status 	[catch { exec -- $jScripts(location_jScripts) FREESPACE "$DFDisk:" } result]
			
			if { $status > 0 } { 
				putlog "..jS....: $jScripts(location_jScripts) FREESPACE $DFDisk: FAiLED ($result)"
				jScripts:SND $jTQ(default_admin_chan) "..jS....: $jScripts(location_jScripts) FREESPACE $DFDisk: FAiLED ($result)"
				return
			}

			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: result = '$result'" }
			
			if { ![info exists jScripts(df_$DFDisk)] } { continue }
			
			set jScripts(df_body_sct)		$jScripts(df_$DFDisk)
			
			set jScripts(df_body_total)	[lindex $result 0]
			set jScripts(df_body_free)		[lindex $result 1]
			set jScripts(df_body_per)		[expr [expr $jScripts(df_body_free) * 100] / $jScripts(df_body_total)]

			set jScripts(df_foot_total)	[expr $jScripts(df_foot_total) + $jScripts(df_body_total)]
			set jScripts(df_foot_free)		[expr $jScripts(df_foot_free) + $jScripts(df_body_free)]

			set body								[jScripts:FormatString $jScripts(skin_df_body)]
			
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: count = $count, i = $i, total = $total" }
			
			if { ($count >= $jScripts(df_per_line)) || ( $i == $total) } {
				
				lappend jScripts(df_body_tmp) $body
				
				regsub -all -- {\{|\}} $jScripts(df_body_tmp) {} jScripts(df_body_tmp)
				
				if { $jScripts(default_show_df) == "chan" } 			{ jScripts:SND $chan $jScripts(df_body_tmp) }
				if { $jScripts(default_show_df) == "private" }		{ jScripts:SND $nick $jScripts(df_body_tmp) }
				if { $jScripts(default_show_df) == "notice" }		{ putquick "NOTICE $nick :$jScripts(df_body_tmp)" }
			
				set jScripts(df_body_tmp) ""
				
				set count 0
					
			} else {
				
				lappend jScripts(df_body_tmp) $body
				
			}
			
		}
		
		regsub -all -- {\{|\}} $jScripts(df_body_tmp) {} jScripts(df_body_tmp)
		
		set jScripts(df_foot_per)			[expr [expr $jScripts(df_foot_free) * 100] / $jScripts(df_foot_total)]
		
		set outfoot								[jScripts:FormatString "$jScripts(skin_df_foot)"]
		
		set output								"$outfoot"
				
	}
	
	if { $jScripts(default_show_df) == "chan" } 			{ jScripts:SND $chan $output }
	if { $jScripts(default_show_df) == "private" }		{ jScripts:SND $nick $output }
	if { $jScripts(default_show_df) == "notice" }		{ putquick "NOTICE $nick :$output" }
			
	return
	
}

proc jScripts:REHASH {nick uhost hand chan text} {

	global jTQ jSB jScripts jFTP
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:REHASH {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_rehash)) } { return }
	
	rehash
	
	jScripts:SND $chan "REHASH DONE"
	
	return
	
}

proc jScripts:BNC {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:BNC {$nick $uhost $hand $chan $text}" }
	
  	if { !($jScripts(enable_bnc)) } { return }
  	
  	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG BNC(s) To '$nick'" }
  	
  	if { $jScripts(enable_partyline) } { putlog "..jS....: [lindex $text 0]" }
  	
  	set jScripts(bnc_s) 0
  	
  	if { [lindex $text 0] != "" } {
  	  	
  	  	set jScripts(bnc_s) 1
  	  	
  	}
  	
  	if { $jScripts(enable_bnc_head) } {
  		
  	  	set output 		[jScripts:FormatString $jScripts(skin_bnc_head)]
  	  	
		if { $jScripts(default_show_bnc) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_bnc) == "private" }			{ jScripts:SND $nick $output }
		if { $jScripts(default_show_bnc) == "notice" }			{ putquick "NOTICE $nick :$output" }
  	  		
  	}
  	
  	set ssl			""
  	set status		""
  	set time			"N/A"
  	
  	foreach bnc [split $jScripts(bnc_sites)] {
  		
  	  	set n [split $bnc ":"]
  	  	
  	  	if { ($jScripts(bnc_s) == 1) && ([string tolower [lindex $n 0]] != [string tolower [lindex $text 0]]) } { continue }
  	  	
  	  	if { $jScripts(enable_partyline) } { putlog "..jS....: BNC For '[lindex $n 0]' -> [lindex $n 1]:[lindex $n 2]" }
  	  	
  	  	set jScripts(bnc_site)		[lindex $n 0]
  	  	set jScripts(bnc_ip)			[lindex $n 1]
  	  	set jScripts(bnc_port)		[lindex $n 2]
  	  	set jScripts(bnc_loc)		[lindex $n 3]
  	  	if { [lindex $n 4] == 1 } { set jScripts(ssl) $jScripts(skin_bnc_ssl_yes) } else { set jScripts(ssl) $jScripts(skin_bnc_ssl_no) }
  	  	set jScripts(bnc_sect)		[lindex $n 5]
  	  	set jScripts(bnc_speed)		[lindex $n 6]
  	  	set jScripts(bnc_desc)		[lindex $n 7]
  	  	set jScripts(bnc_fake_ip)	[lindex $n 8]
  	  	set jScripts(bnc_status)	$status
  	  	set jScripts(bnc_ssl)		$jScripts(ssl)
  	  	set jScripts(bnc_time)		$time

		regsub -all -- {\.} $jScripts(bnc_sect) { } jScripts(bnc_sect)	
		
  	  	set output 		[jScripts:FormatString $jScripts(skin_bnc_ncftpls_no)]
  	  	
		if { $jScripts(default_show_bnc) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_bnc) == "private" }			{ jScripts:SND $nick $output }
		if { $jScripts(default_show_bnc) == "notice" }			{ putquick "NOTICE $nick :$output" }
  	
  	}
  	
  	return

}

proc jScripts:BNCTEST {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:BNCTEST {$nick $uhost $hand $chan $text}" }
	
  	if { !($jScripts(enable_bnc)) } { return }
  	
  	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG BNC(s) To '$nick'" }
  	
  	if { $jScripts(enable_partyline) } { putlog "..jS....: [lindex $text 0]" }
  	
  	set jScripts(bnc_s) 0
  	
  	if { [lindex $text 0] != "" } {
  		
  	  	set jScripts(bnc_s) 1
  	  	
  	}
  	
  	if { $jScripts(enable_bnc_head) } {
  		
  	  	set output 		[jScripts:FormatString $jScripts(skin_bnc_head)]
  	  	
		if { $jScripts(default_show_bnc) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_bnc) == "private" }			{ jScripts:SND $nick $output }
		if { $jScripts(default_show_bnc) == "notice" }			{ putquick "NOTICE $nick :$output" }
  	  		
  	}
  	
  	set ssl			""
  	set status		""
  	set time			"N/A"
  	
  	foreach bnc [split $jScripts(bnc_sites)] {
  		
  	  	set n [split $bnc ":"]
  	  	
  	  	set jScripts(bnc_site)		[lindex $n 0]
  	  	set jScripts(bnc_ip)			[lindex $n 1]
  	  	set jScripts(bnc_port)		[lindex $n 2]
  	  	set jScripts(bnc_loc)		[lindex $n 3]
  	  	set jScripts(bnc_sect)		[lindex $n 5]
  	  	set jScripts(bnc_speed)		[lindex $n 6]
  	  	set jScripts(bnc_desc)		[lindex $n 7]
  	  	set jScripts(bnc_fake_ip)	[lindex $n 8]

  	  	if { ($jScripts(bnc_s) == 1) && ([string tolower $jScripts(bnc_site)] != [string tolower [lindex $text 0]]) } { continue }
  	  	
  	  	if { $jScripts(enable_partyline) } { putlog "..jS....: CONNECTiNG To 'jScripts(bnc_site)' -> $jScripts(bnc_fake_ip):$jScripts(bnc_port)" }
  	  	
  	  	set now1		[clock clicks -milliseconds]
  	  	set status 	[catch { exec -- $jScripts(location_ncftpls) -u $jScripts(bnc_user) -p $jScripts(bnc_pass) -t $jScripts(bnc_time_out) ftp://$jScripts(bnc_fake_ip):$jScripts(bnc_port) } result]
  	  	set now2		"[expr ([clock clicks -milliseconds] - $now1)]"
  	  	if { ([regexp \[.\]*ncftpls\:\ cannot\ open\[.\]* $result] > 0) } { set status $jScripts(skin_bnc_status_dn) ; set time "N/A" } else { set status $jScripts(skin_bnc_status_up) ; set time "$now2" }
  	  	if { [lindex $n 4] == 1 } { set jScripts(ssl) $jScripts(skin_bnc_ssl_yes) } else { set jScripts(ssl) $jScripts(skin_bnc_ssl_no) }
  	  	
  	  	set jScripts(bnc_status)	$status
  	  	set jScripts(bnc_ssl)		$jScripts(ssl)
  	  	set jScripts(bnc_time)		$time

		regsub -all -- {\.} $jScripts(bnc_sect) { } jScripts(bnc_sect)	
		
  	  	set output 		[jScripts:FormatString $jScripts(skin_bnc_ncftpls_yes)]
  	  	
		if { $jScripts(default_show_bnc) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_bnc) == "private" }			{ jScripts:SND $nick $output }
		if { $jScripts(default_show_bnc) == "notice" }			{ putquick "NOTICE $nick :$output" }
  	
  	}
  	
  	return

}

proc jScripts:SND {dest text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:SND {$dest $text}" }
	
	foreach line [split $text $jScripts(default_split_char)] {
		
		if { $jScripts(fish_key) != "" } {
			
			set eline [encrypt $jScripts(fish_key) $line]
			putquick "PRIVMSG $dest :$jScripts(fish_head) $eline"
			
		} else {
			
			putquick "PRIVMSG $dest :$line"
			
		}
	
	}
	
	return
  
}

proc jScripts:FormatString { tekst } {
  
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:FormatString { $tekst}" }
	
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
			  
				{a}		{ append rpl [format %${x}.${y}s $jScripts(AffilSection)] }
				{b}		{ append rpl [format %${x}.${y}s $jScripts(Affils)] }
				{c}		{ append rpl [format %${x}.${y}s $jScripts(BannedSection)] }
				{d}		{ append rpl [format %${x}.${y}s $jScripts(Banned)] }
				{e}		{ append rpl [format %${x}.${y}s $jScripts(default_site_name)] }
				{f}		{ append rpl [format %${x}.${y}s $jScripts(df_body_sct)] }
				{g}		{ append rpl [format %${x}.${y}s $jScripts(bnc_site)] }
				{h}		{ append rpl [format %${x}.${y}s $jScripts(bnc_ip)] }
				{i}		{ append rpl [format %${x}.${y}s $jScripts(bnc_port)] }
				{j}		{ append rpl [format %${x}.${y}s $jScripts(bnc_loc)] }
				{k}		{ append rpl [format %${x}.${y}s $jScripts(bnc_sect)] }
				{l}		{ append rpl [format %${x}.${y}s $jScripts(bnc_status)] }
				{m}		{ append rpl [format %${x}.${y}s $jScripts(bnc_ssl)] }
				{n}		{ append rpl [format %${x}.${y}s $jScripts(bnc_time)] }
				{o}		{ append rpl [format %${x}.${y}s $jScripts(bnc_speed)] }
				{p}		{ append rpl [format %${x}.${y}s $jScripts(bnc_desc)] }
				{r}		{ append rpl [format %${x}.${y}s $jScripts(bnc_fake_ip)] }
				{s}		{ append rpl [format %${x}.${y}s $jScripts(SectionSection)] }
				{t}		{ append rpl [format %${x}.${y}s $jScripts(Sections)] }
				{u}		{ append rpl [format %${x}.${y}s $jScripts(df_body_free)] }
				{v}		{ append rpl [format %${x}.${y}s $jScripts(df_body_total)] }
				{z}		{ append rpl [format %${x}.${y}s $jScripts(df_body_per)] }
				{q}		{ append rpl [format %${x}.${y}s $jScripts(df_foot_free)] }
				{w}		{ append rpl [format %${x}.${y}s $jScripts(df_foot_total)] }
				{y}		{ append rpl [format %${x}.${y}s $jScripts(df_foot_per)] }
				{x}		{ append rpl [format %${x}.${y}s "empty"] }
			  	
				{A}		{ append rpl [format %${x}.${y}s $jScripts(who_up_total_speed)] }
				{B}		{ append rpl [format %${x}.${y}s $jScripts(who_up_count)] }
				{C}		{ append rpl [format %${x}.${y}s $jScripts(who_dn_total_speed)] }
				{D}		{ append rpl [format %${x}.${y}s $jScripts(who_dn_count)] }
				{E}		{ append rpl [format %${x}.${y}s $jScripts(who_idle_count)] }
				{F}		{ append rpl [format %${x}.${y}s $jScripts(who_total_speed)] }
				{G}		{ append rpl [format %${x}.${y}s $jScripts(who_total_count)] }
				{H}		{ append rpl [format %${x}.${y}s $jScripts(who_username)] }
				{I}		{ append rpl [format %${x}.${y}s $jScripts(who_groupname)] }
				{J}		{ append rpl [format %${x}.${y}s $jScripts(who_idle_time)] }
				{K}		{ append rpl [format %${x}.${y}s $jScripts(who_login_time)] }
				{L}		{ append rpl [format %${x}.${y}s $jScripts(who_file_name)] }
				{M}		{ append rpl [format %${x}.${y}s $jScripts(who_user_speed)] }
				{N}		{ append rpl [format %${x}.${y}s $jScripts(who_bytes_transfered)] }
				{O}		{ append rpl [format %${x}.${y}s $jScripts(who_file_size)] }
				{P}		{ append rpl [format %${x}.${y}s $jScripts(who_percent_done)] }
				{R}		{ append rpl [format %${x}.${y}s $jScripts(approve,release)] }
				{S}		{ append rpl [format %${x}.${y}s $jScripts(approve,user)] }
				{T}		{ append rpl [format %${x}.${y}s $jScripts(approve,date)] }
				{U}		{ append rpl [format %${x}.${y}s $jScripts(approve,section)] }
				{V}		{ append rpl [format %${x}.${y}s $jScripts(speed,up,bw)] }
				{Z}		{ append rpl [format %${x}.${y}s $jScripts(speed,dn,bw)] }
				{Q}		{ append rpl [format %${x}.${y}s $jScripts(speed,all,bw)] }
				{W}		{ append rpl [format %${x}.${y}s $jScripts(arch,date,format)] }
				{Y}		{ append rpl [format %${x}.${y}s "empty"] }
				{X}		{ append rpl [format %${x}.${y}s "empty"] }

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
			  
				{a}		{ append rpl [format %${x}.${y}s $jScripts(TodoNumber)] }
				{b}		{ append rpl [format %${x}.${y}s $jScripts(TodoName)] }
				{c}		{ append rpl [format %${x}.${y}s $jScripts(TodoText)] }
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
			  	
				{A}		{ append rpl [format %${x}.${y}s $jScripts(age,username)] }
				{B}		{ append rpl [format %${x}.${y}s $jScripts(age,groupname)] }
				{C}		{ append rpl [format %${x}.${y}s $jScripts(age,addedby)] }
				{D}		{ append rpl [format %${x}.${y}s $jScripts(age,dateadded)] }
				{E}		{ append rpl [format %${x}.${y}s $jScripts(age,daysago)] }
				{F}		{ append rpl [format %${x}.${y}s "empty"] }
				{G}		{ append rpl [format %${x}.${y}s "empty"] }
				{H}		{ append rpl [format %${x}.${y}s "empty"] }
				{I}		{ append rpl [format %${x}.${y}s "empty"] }
				{J}		{ append rpl [format %${x}.${y}s "empty"] }
				{K}		{ append rpl [format %${x}.${y}s "empty"] }
				{L}		{ append rpl [format %${x}.${y}s "empty"] }
				{M}		{ append rpl [format %${x}.${y}s "empty"] }
				{N}		{ append rpl [format %${x}.${y}s "empty"] }
				{O}		{ append rpl [format %${x}.${y}s $jScripts(stats,files)] }
				{P}		{ append rpl [format %${x}.${y}s $jScripts(stats,speed)] }
				{R}		{ append rpl [format %${x}.${y}s $jScripts(stats,default,type)] }
				{S}		{ append rpl [format %${x}.${y}s $jScripts(stats,default,name)] }
				{T}		{ append rpl [format %${x}.${y}s $jScripts(stats,pos)] }
				{U}		{ append rpl [format %${x}.${y}s $jScripts(stats,user)] }
				{V}		{ append rpl [format %${x}.${y}s $jScripts(stats,group)] }
				{Z}		{ append rpl [format %${x}.${y}s $jScripts(stats,mb)] }
				{Q}		{ append rpl [format %${x}.${y}s $jScripts(stats,text)] }
				{W}		{ append rpl [format %${x}.${y}s $jScripts(stats,section)] }
				{Y}		{ append rpl [format %${x}.${y}s $jScripts(stats,default,name)] }
				{X}		{ append rpl [format %${x}.${y}s "empty"] }

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

proc jScripts:FormatStr2ng { tekst } {
  
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:FormatStr2ng { $tekst }" }
	
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
			  
				{a}		{ append rpl [format %${x}.${y}s $jScripts(rank,01,pos)] }
				{b}		{ append rpl [format %${x}.${y}s $jScripts(rank,01,name)] }
				{c}		{ append rpl [format %${x}.${y}s $jScripts(rank,01,group)] }
				{d}		{ append rpl [format %${x}.${y}s $jScripts(rank,01,flags)] }
				{e}		{ append rpl [format %${x}.${y}s $jScripts(rank,01,mb)] }
				{f}		{ append rpl [format %${x}.${y}s $jScripts(rank,01,files)] }
				{g}		{ append rpl [format %${x}.${y}s $jScripts(rank,01,speed)] }
				{h}		{ append rpl [format %${x}.${y}s $jScripts(rank,02,pos)] }
				{i}		{ append rpl [format %${x}.${y}s $jScripts(rank,02,name)] }
				{j}		{ append rpl [format %${x}.${y}s $jScripts(rank,02,group)] }
				{k}		{ append rpl [format %${x}.${y}s $jScripts(rank,02,flags)] }
				{l}		{ append rpl [format %${x}.${y}s $jScripts(rank,02,mb)] }
				{m}		{ append rpl [format %${x}.${y}s $jScripts(rank,02,files)] }
				{n}		{ append rpl [format %${x}.${y}s $jScripts(rank,02,speed)] }
				{o}		{ append rpl [format %${x}.${y}s $jScripts(rank,03,pos)] }
				{p}		{ append rpl [format %${x}.${y}s $jScripts(rank,03,name)] }
				{r}		{ append rpl [format %${x}.${y}s $jScripts(rank,03,group)] }
				{s}		{ append rpl [format %${x}.${y}s $jScripts(rank,03,flags)] }
				{t}		{ append rpl [format %${x}.${y}s $jScripts(rank,03,mb)] }
				{u}		{ append rpl [format %${x}.${y}s $jScripts(rank,03,files)] }
				{v}		{ append rpl [format %${x}.${y}s $jScripts(rank,03,speed)] }
				{z}		{ append rpl [format %${x}.${y}s $jScripts(rank,section)] }
				{q}		{ append rpl [format %${x}.${y}s $jScripts(rank,dif,up)] }
				{w}		{ append rpl [format %${x}.${y}s $jScripts(rank,dif,dn)] }
				{y}		{ append rpl [format %${x}.${y}s $jScripts(rank,section,nr)] }
				{x}		{ append rpl [format %${x}.${y}s $jScripts(rank,user)] }
			  	
				{A}		{ append rpl [format %${x}.${y}s $jScripts(rank,type)] }
				{B}		{ append rpl [format %${x}.${y}s "empty"] }
				{C}		{ append rpl [format %${x}.${y}s "empty"] }
				{D}		{ append rpl [format %${x}.${y}s "empty"] }
				{E}		{ append rpl [format %${x}.${y}s "empty"] }
				{F}		{ append rpl [format %${x}.${y}s "empty"] }
				{G}		{ append rpl [format %${x}.${y}s "empty"] }
				{H}		{ append rpl [format %${x}.${y}s $jScripts(group,groupname)] }
				{I}		{ append rpl [format %${x}.${y}s $jScripts(group,groupusers)] }
				{J}		{ append rpl [format %${x}.${y}s $jScripts(group,allupmb)] }
				{K}		{ append rpl [format %${x}.${y}s $jScripts(group,alluppos)] }
				{L}		{ append rpl [format %${x}.${y}s $jScripts(group,alldnmb)] }
				{M}		{ append rpl [format %${x}.${y}s $jScripts(group,alldnpos)] }
				{N}		{ append rpl [format %${x}.${y}s $jScripts(group,mnupmb)] }
				{O}		{ append rpl [format %${x}.${y}s $jScripts(group,mnuppos)] }
				{P}		{ append rpl [format %${x}.${y}s $jScripts(group,mndnmb)] }
				{R}		{ append rpl [format %${x}.${y}s $jScripts(group,mndnpos)] }
				{S}		{ append rpl [format %${x}.${y}s $jScripts(group,wkupmb)] }
				{T}		{ append rpl [format %${x}.${y}s $jScripts(group,wkuppos)] }
				{U}		{ append rpl [format %${x}.${y}s $jScripts(group,wkdnmb)] }
				{V}		{ append rpl [format %${x}.${y}s $jScripts(group,wkdnpos)] }
				{Z}		{ append rpl [format %${x}.${y}s $jScripts(group,dayupmb)] }
				{Q}		{ append rpl [format %${x}.${y}s $jScripts(group,dayuppos)] }
				{W}		{ append rpl [format %${x}.${y}s $jScripts(group,daydnmb)] }
				{Y}		{ append rpl [format %${x}.${y}s $jScripts(group,daydnpos)] }
				{X}		{ append rpl [format %${x}.${y}s "empty"] }

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

proc jScripts:Replace {strin what withwhat} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:Replace {'$strin' '$what' '$withwhat'}" }
	
	set output			$strin
	set replacement	$withwhat
	set cutpos			0
	
	while { [string first $what $output] != -1 } {
		
		set cutstart 	[expr [string first $what $output] - 1]
		set cutstop  	[expr $cutstart + [string length $what] + 1]
		set output 		[string range $output 0 $cutstart]$replacement[string range $output $cutstop end]
	 
	}
	
	return $output

}

proc jScripts:FiSH {nick uhost hand chan arg} {
  
	global jTQ jSB jScripts jFTP
	
	set cmdline	[decrypt $jScripts(fish_key) $arg]
	set dcmd		[lindex $cmdline 0]
	set darg		[lrange $cmdline 1 end]
	
	if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: jScripts:FiSH -> $cmdline" }
	
	#jScripts BiNDINGS
	foreach prc $jScripts(bind) {
		
		set n [split $prc "-"]
		
		if { ($dcmd == "[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "all")} {
		
			[lindex $n 1] $nick $uhost $hand $chan $darg

			break
				
		}
		
		if { ($dcmd == "[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op")} {
		
			if { $jScripts(enable_debug_partyline) } { jScripts:DebugPartyLine "..jS....: matchattr = '[isop $nick $chan]' " }
		
			if { [isop $nick $chan] } {
				
				[lindex $n 1] $nick $uhost $hand $chan $darg
				
			}

			break
				
		}

	}

	foreach trig $jScripts(triggers,list) {
		
		set trg [split $trig ":"]
		
		if { [lindex $cmdline 0] == "[lindex $trg 0]" } {
	
			jScripts:TRiGGERS $nick $uhost $hand $chan [lindex $trg 1]
		
		}
	 
	}

	foreach trig $jScripts(stats,triggers) {
		
		set trg [split $trig ":"]
		
		if { [lindex $cmdline 0] == "[lindex $trg 0]" } {
	
			if { $jScripts(enable,stats,details) } {
				jScripts:RANK $nick $uhost $hand $chan "[lindex $cmdline 1] [lindex $trg 1]"
			} else {
				jScripts:STATS $nick $uhost $hand $chan "[lindex $trg 1] [lindex $trg 2] [lrange $cmdline 1 end]"
			}
		
		}
	 
	}

	foreach prc $jScripts(time_triggers) {
		
		set n [split $prc "-"]
		
		if { ($dcmd == "$jScripts(default_command_prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "all")} {
		
			[lindex $n 1] min hour day month year

			break
				
		}
		
		if { ($dcmd == "$jScripts(default_command_prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op")} {
		
			if { [isop $nick $chan] } {
				
				[lindex $n 1] min hour day month year
				
			}

			break
				
		}

	}
	
	#jScripts BiNDINGS

	#jTQ BiNDINGS
	if { $jScripts(enable_jTQ) } {
		
		foreach prc $jTQ(bind) {
			
			set n [split $prc "-"]
			
			if { $dcmd == "$jTQ(default_command_prefix)[lindex $n 0]" } {
				
				[lindex $n 1] $nick $uhost $hand $chan $darg
				
				break
					
			}
			
		}
		
		foreach prc $jTQ(time_triggers) {
			
			set n [split $prc "-"]
			
			if { ($dcmd == "$jTQ(default_command_prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "all")} {
			
				[lindex $n 1] min hour day month year
	
				break
					
			}
			
			if { ($dcmd == "$jTQ(default_command_prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op")} {
			
				if { [matchattr $hand o|o $chan] } {
					
					[lindex $n 1] min hour day month year
					
				}
	
				break
					
			}

		}
	
	}
	#jTQ BiNDINGS
	
	#jFTP BiNDINGS
	if { $jScripts(enable_jFTP) } {
		
		foreach prc $jFTP(bind) {
			
			set n [split $prc "-"]
			
			if { ($dcmd == "$jFTP(default,command,prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op") } {
				
				if { [isop $nick $chan] } {
				
					[lindex $n 1] $nick $uhost $hand $chan $darg
					
				}
				
				break
				
			}
			
			if { ($dcmd == "$jFTP(default,command,prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "all") } {
				
				[lindex $n 1] $nick $uhost $hand $chan $darg
				break
				
			}
			
		}
		
		foreach prc $jFTP(time,triggers) {
			
			set n [split $prc "-"]
			
			if { ($dcmd == "$jFTP(default,command,prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op")} {
				
				if { [isop $nick $chan] } {
				
					[lindex $n 1] min hour day month year
				
				}
				
				break
				
			}
				
			if { ($dcmd == "$jFTP(default,command,prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "all") } {
				
				[lindex $n 1] min hour day month year
				break
				
			}
			
		}
	
	}
	#jFTP BiNDINGS
	
	return
	
}

proc jScripts:BiND {} {

	global jTQ jSB jScripts jFTP
	
	if { ($jScripts(fish_key) == "") } {
	
		#jScripts BiNDINGS
		foreach prc $jScripts(bind) {
			
			set n [split $prc "-"]
			
			#putlog "-|- [lindex $n 0] [lindex $n 1]"
			
			bind pub -|- [lindex $n 0] [lindex $n 1]
			
		}
		#jScripts BiNDINGS

		#jTQ BiNDINGS
		if { $jScripts(enable_jTQ) } {
			
   		foreach prc $jTQ(bind) {

   			set n [split $prc "-"]

				putlog "-|- $jTQ(default_command_prefix)[lindex $n 0] [lindex $n 1]"

				bind pub -|- $jTQ(default_command_prefix)[lindex $n 0] [lindex $n 1]

   		}

		}
		#jTQ BiNDINGS
		
		#jFTP BiNDINGS
		if { $jScripts(enable_jFTP) } {
			
			foreach prc $jFTP(bind) {
				
				set n [split $prc "-"]
				
				#putlog "-|- $jFTP(default,command,prefix)[lindex $n 0] [lindex $n 1]"
				
				bind pub -|- $jFTP(default,command,prefix)[lindex $n 0] [lindex $n 1]
				
			}
		
		}
		#jFTP BiNDINGS
		
	} else {
	
		bind pub -|- $jScripts(fish_head) jScripts:FiSH
		
	}

	return
	
}

if { $jScripts(enable_jTQ) } { source "$jScripts(location_jTQ)jTQ.tcl" }
if { $jScripts(enable_jSB) } { source "$jScripts(location_jSB)jSB.tcl" }
if { $jScripts(enable_jFTP) } { source "$jScripts(location_jFTP)jFTP.tcl" }

jScripts:BiND
jScripts:CHECKLOG

putlog "\002 -> .jScripts. $jScripts(default_version) by Jeza Loaded"

