source "scripts/jScripts.conf"


### STOP HERE       -#
### STOP HERE       -#
### STOP HERE       -#

set jScripts(AffilSection)		""
set jScripts(Affils)				""
set jScripts(SectionSection)	""
set jScripts(Sections)			""
set jScripts(BannedSection)	""
set jScripts(Banned)				""
set jScripts(bnc_site)			""
set jScripts(bnc_ip)				""
set jScripts(bnc_fake_ip)		""
set jScripts(bnc_port)			""
set jScripts(bnc_loc)			""
set jScripts(bnc_sect)			""
set jScripts(bnc_speed)			""
set jScripts(bnc_desc)			""
set jScripts(bnc_status)		""
set jScripts(bnc_ssl)			""
set jScripts(bnc_time)			""
set jScripts(df_body_total)	0
set jScripts(df_body_free)		0
set jScripts(df_body_per)		0
set jScripts(df_body_tmp)		""
set jScripts(df_body_sct)		""
set jScripts(df_foot_total)	0
set jScripts(df_foot_free)		0
set jScripts(df_foot_per)		0

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

####################################################
# Shows REQUESTS                                   #
####################################################
proc jScripts:REQUESTS {nick uhost hand chan text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:REQUESTS {$nick $uhost $hand $chan $text}" }
	
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:IDLE {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_idle) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO IDLE } result]
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:IDLE RESULT = '$result'" }
	
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:DN {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_dn) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO DOWN } result]
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:DN RESULT = '$result'" }
	
	if { $result == "no" } {
		
		set output									[jScripts:FormatString $jScripts(skin_who_dn_no)]
		
		if { $jScripts(default_show_dn) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_dn) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_dn) == "notice" }		{ putquick "NOTICE $nick :$output" }

	} else {
		
		foreach line [split $result "\n"] {
			
			if { $line == "" } { continue }
			
			set jScripts(who_username)				[lindex $line 0]
			set jScripts(who_groupname)			[lindex $line 1]
			set jScripts(who_file_name)			[lindex $line 2]
			set jScripts(who_user_speed)			[lindex $line 3]
			set jScripts(who_bytes_transfered)	[lindex $line 4]
			set jScripts(who_file_size)			[lindex $line 5]
			set jScripts(who_percent_done)		[lindex $line 6]

			set output									[jScripts:FormatString $jScripts(skin_who_dn_yes)]
			
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:UP {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_up) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO UP } result]
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:UP RESULT = '$result'" }
	
	if { $result == "no" } {
		
		set output									[jScripts:FormatString $jScripts(skin_who_up_no)]
		
		if { $jScripts(default_show_up) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_up) == "private" }		{ jScripts:SND $nick $output }
		if { $jScripts(default_show_up) == "notice" }		{ putquick "NOTICE $nick :$output" }
	
	} else {
		
		foreach line [split $result "\n"] {
		
			if { $line == "" } { continue }
			
			set jScripts(who_username)				[lindex $line 0]
			set jScripts(who_groupname)			[lindex $line 1]
			set jScripts(who_file_name)			[lindex $line 2]
			set jScripts(who_user_speed)			[lindex $line 3]
	
			set output									[jScripts:FormatString $jScripts(skin_who_up_yes)]
				
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:SPEED {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_speed) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO SPEED [lindex $text 0] } result]
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:SPEED RESULT = '$result'" }
	
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:BW {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_bw) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO BW } result]
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:BW RESULT = '$result'" }
	
	set jScripts(who_up_total_speed)		[lindex $result 0]
	set jScripts(who_up_count)				[lindex $result 1]
	set jScripts(who_dn_total_speed)		[lindex $result 2]
	set jScripts(who_dn_count)				[lindex $result 3]
	set jScripts(who_idle_count)			[lindex $result 4]
	set jScripts(who_total_speed)			[lindex $result 5]
	set jScripts(who_total_count)			[lindex $result 6]
	
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:WHO {$nick $uhost $hand $chan $text}" }
	
	if { !$jScripts(enable_who) } { return }

	set status 	[catch { exec -- $jScripts(location_jScripts) WHO ALL } result]
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:WHO RESULT = '$result'" }
	
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:CHECKLOG {}" }
	
	if { $jScripts(enable_jTQ_log) } {
		
		if { $jScripts(enable_debug_partyline) } { putlog "..jS....: CHECKiNG $jScripts(log_jTQ)" }
		
		if {![file exist $jScripts(log_jTQ)]} { 
			
			if { $jScripts(enable_partyline) } { putlog "..jS....: CREATiNG $jScripts(log_jTQ)" }
			
			file mkdir "$jScripts(log_jTQ)"
			
		}
	
	}
	
	return
	
}

proc jScripts:LOG {what where text} {
	
	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:LOG {$what $where $text}" }
	
	if { ($jScripts(enable_jTQ_log)) && ($where == "jTQ") } {
		
      set file [open "$what" "a+"]
      puts $file "$text"
      close $file
			
	}

	return
	
}

proc jScripts:BANNED {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:BANNED {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_banned)) } { return }
	
	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG BANNED To '$nick'" }

  	foreach BannedSection [split $jScripts(banned_sections)] {

    	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: BannedSection = '$BannedSection'" }
    	
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:AFFiLS {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_affils)) } { return }
	
	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG AFFiLS To '$nick'" }

	foreach AffilSection [split $jScripts(affils_sections)] {
	
		if { $jScripts(enable_debug_partyline) } { putlog "..jS....: AffilSection = '$AffilSection'" }
		
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:SECTiONS {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_sections)) } { return }

	if { $jScripts(enable_partyline) } { putlog "..jS....: SHOWiNG SECTiONS To '$nick'" }

	foreach SectionSection [split $jScripts(sections_sections)] {
	
		if { $jScripts(enable_debug_partyline) } { putlog "..jS....: SectionSection = '$SectionSection'" }
		
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:FREESPACE {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_df)) } { return }
	
	if { $jScripts(enable_df_one_line) } {
		
		set jScripts(df_foot_total)	0				;#total 
		set jScripts(df_foot_free)		0				;#total free
		set jScripts(df_foot_per)		0				;#total %
		
		set jScripts(df_body_tmp)		""				;#list for sections space

		foreach DFDisk [split $jScripts(df_disks)] {
		
			if { $jScripts(enable_debug_partyline) } { putlog "..jS....: DFDisk = '$DFDisk'" }
			
			set jScripts(df_body_total)	0
			set jScripts(df_body_free)		0
			set jScripts(df_body_per)		0
			
			set status 	[catch { exec -- $jScripts(location_jScripts) FREESPACE "$DFDisk:" } result]
			
			if { $status > 0 } { 
				putlog "..jS....: $jScripts(location_jScripts) FREESPACE $DFDisk: FAiLED ($result)"
				jScripts:SND $jTQ(default_admin_chan) "..jS....: $jScripts(location_jScripts) FREESPACE $DFDisk: FAiLED ($result)"
				return
			}

			if { $jScripts(enable_debug_partyline) } { putlog "..jS....: result = '$result'" }
			
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
		
		set output								"SET jScripts(enable_df_one_line) to TRUE!!!"
			
	}
	
	if { $jScripts(default_show_df) == "chan" } 			{ jScripts:SND $chan $output }
	if { $jScripts(default_show_df) == "private" }		{ jScripts:SND $nick $output }
	if { $jScripts(default_show_df) == "notice" }		{ putquick "NOTICE $nick :$output" }
			
	return
	
}

proc jScripts:REHASH {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:REHASH {$nick $uhost $hand $chan $text}" }
	
	if { !($jScripts(enable_rehash)) } { return }
	
	rehash
	
	jScripts:SND $chan "REHASH DONE"
	
	return
	
}

proc jScripts:BNC {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:BNC {$nick $uhost $hand $chan $text}" }
	
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

  	  	set output 		[jScripts:FormatString $jScripts(skin_bnc_ncftpls_no)]
  	  	
		if { $jScripts(default_show_bnc) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_bnc) == "private" }			{ jScripts:SND $nick $output }
		if { $jScripts(default_show_bnc) == "notice" }			{ putquick "NOTICE $nick :$output" }
  	
  	}
  	
  	return

}

proc jScripts:BNCTEST {nick uhost hand chan text} {

  	global jTQ jSB jScripts
  	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:BNCTEST {$nick $uhost $hand $chan $text}" }
	
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

  	  	set output 		[jScripts:FormatString $jScripts(skin_bnc_ncftpls_yes)]
  	  	
		if { $jScripts(default_show_bnc) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jScripts(default_show_bnc) == "private" }			{ jScripts:SND $nick $output }
		if { $jScripts(default_show_bnc) == "notice" }			{ putquick "NOTICE $nick :$output" }
  	
  	}
  	
  	return

}

proc jScripts:SND {dest text} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:SND {$dest $text}" }
	
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
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:FormatString { $tekst}" }
	
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
				{x}		{ append rpl [format %${x}.${y}s ""] }
			  	
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
				{R}		{ append rpl [format %${x}.${y}s ""] }
				{S}		{ append rpl [format %${x}.${y}s ""] }
				{T}		{ append rpl [format %${x}.${y}s ""] }
				{U}		{ append rpl [format %${x}.${y}s ""] }
				{V}		{ append rpl [format %${x}.${y}s ""] }
				{Z}		{ append rpl [format %${x}.${y}s ""] }
				{Q}		{ append rpl [format %${x}.${y}s ""] }
				{W}		{ append rpl [format %${x}.${y}s ""] }
				{Y}		{ append rpl [format %${x}.${y}s ""] }
				{X}		{ append rpl [format %${x}.${y}s ""] }

			  	{%}		{ append rpl [format %${x}.${y}s "%"] }
			  
			  	default	{ append rpl [string index $tekst $i] }
			  
			}
		
		} else {
		
			append rpl [string index $tekst $i]
		
		}
	 
	}
	
	return "$rpl"

}

proc jScripts:Replace {strin what withwhat} {

	global jTQ jSB jScripts
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:Replace {'$strin' '$what' '$withwhat'}" }
	
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
	set op		[isop $user $chan]
	
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:FiSH -> 'isop=$op' '$cmdline'" }
	if { $jScripts(enable_debug_partyline) } { putlog "..jS....: jScripts:FiSH test 'isop=$op' '$cmdline'" }
	
	#jScripts BiNDINGS
	foreach prc $jScripts(bind) {
		
		set n [split $prc "-"]
		
		if { ($dcmd == "$jScripts(default_command_prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op") } {

			if { $op } {
				
				[lindex $n 1] $nick $uhost $hand $chan $darg
				break
				
			}
			
		} else {
			
			[lindex $n 1] $nick $uhost $hand $chan $darg
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
			
				if { $jScripts(enable_debug_partyline) } { putlog "..jS....: matchattr = '[matchattr $hand o|o $chan]'" }
		
				if { [isop $user $chan]} {
					
					[lindex $n 1] min hour day month year
					break
					
				}
				
			}
				
		}
	
	}
	#jTQ BiNDINGS
	
	#jFTP BiNDINGS
	if { $jScripts(enable_jFTP) } {
		
		foreach prc $jFTP(bind) {
			
			set n [split $prc "-"]
			
			if { ($dcmd == "$jFTP(default,command,prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op") } {
				
				if { [isop $user $chan] } {
				
					[lindex $n 1] $nick $uhost $hand $chan $darg
					break
					
				}
				
			} else {
				
				[lindex $n 1] $nick $uhost $hand $chan $darg
				break
				
			}
			
		}
		
		foreach prc $jFTP(time,triggers) {
			
			set n [split $prc "-"]
			
			if { ($dcmd == "$jFTP(default,command,prefix)[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op")} {
				
				if { [isop $user $chan] } {
				
					[lindex $n 1] min hour day month year
					break
				
				}
				
			} else {
				
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
			bind pub -|- $jScripts(default_command_prefix)[lindex $n 0] [lindex $n 1]
			
		}
		#jScripts BiNDINGS

		#jTQ BiNDINGS
		if { $jScripts(enable_jTQ) } {
			
			foreach prc $jTQ(bind) {
				
				set n [split $prc "-"]
				bind pub -|- $jTQ(default_command_prefix)[lindex $n 0] [lindex $n 1]
				
			}
		
		}
		#jTQ BiNDINGS
		
		#jFTP BiNDINGS
		if { $jScripts(enable_jFTP) } {
			
			foreach prc $jFTP(bind) {
				
				set n [split $prc "-"]
				bind pub -|- $jFTP(default,command,prefix)[lindex $n 0] [lindex $n 1]
				
			}
		
		}
		#jFTP BiNDINGS
		
	} else {
	
		bind pub -|- $jScripts(fish_head) jScripts:FiSH
		
	}

	return
	
}

jScripts:BiND
jScripts:CHECKLOG

putlog "\002 -> .jScripts. $jScripts(default_version) by Jeza Loaded"

if { $jScripts(enable_jTQ) } { source "$jScripts(location_jTQ)jTQ.tcl" }
if { $jScripts(enable_jSB) } { source "$jScripts(location_jSB)jSB.tcl" }
if { $jScripts(enable_jFTP) } { source "$jScripts(location_jFTP)jSB.tcl" }

