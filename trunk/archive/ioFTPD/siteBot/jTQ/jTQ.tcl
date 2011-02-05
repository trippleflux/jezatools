source "$jScripts(location_jTQ)jTQ.conf"

set jTQ(enable_passed_quota)			false
set jTQ(enable_passed_end)				false
set jTQ(enable_trials)					false
set jTQ(enable_quotas)					false
                              		
set jTQ(text_username)					""
set jTQ(text_groupname)					""
set jTQ(text_flags)						""
set jTQ(section_name)					""
set jTQ(text_out_missing)				""
set jTQ(text_out_passed)				""
set jTQ(end_date)							""
set jTQ(gquota_text_passed)			""
set jTQ(gquota_text_missing)			""
set jTQ(text_out_group_quota)			""
set jTQ(gquota_users)					""
set jTQ(text_out_stats)					""
set jTQ(text_end_action)				""

set jTQ(trial_send_chan)				$jTQ(default_admin_chan)

set jTQ(to_end_days)						1
set jTQ(needed_mb)						0
set jTQ(over_mb)							0
set jTQ(missing_mb)						0
set jTQ(per_day_mb)						0
set jTQ(percent_grp)						1
set jTQ(trial_count)						0
set jTQ(number_amount)					0
set jTQ(sect_amount)						0		;#group amount
set jTQ(number_pos)						999

proc jTQ:FormatString { tekst } {
  
	global jTQ jSB jScripts
	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:FormatString { $tekst}" }
	
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
			  
				{a}		{ append rpl [format %${x}.${y}s $jTQ(number_amount)] }
				{b}		{ append rpl [format %${x}.${y}s $jTQ(needed_mb)] }
				{c}		{ append rpl [format %${x}.${y}s $jTQ(over_mb)] }
				{d}		{ append rpl [format %${x}.${y}s $jTQ(missing_mb)] }
				{e}		{ append rpl [format %${x}.${y}s $jTQ(per_day_mb)] }
				{f}		{ append rpl [format %${x}.${y}s $jTQ(text_flags)] }
				{g}		{ append rpl [format %${x}.${y}s $jTQ(text_groupname)] }
				{h}		{ append rpl [format %${x}.${y}s $jTQ(text_out_missing)] }
				{i}		{ append rpl [format %${x}.${y}s $jTQ(text_out_passed)] }
				{j}		{ append rpl [format %${x}.${y}s $jTQ(to_end_days)] }
				{k}		{ append rpl [format %${x}.${y}s $jTQ(end_date)] }
				{l}		{ append rpl [format %${x}.${y}s $jTQ(percent_grp)] }
				{m}		{ append rpl [format %${x}.${y}s $jTQ(sect_amount)] }
				{n}		{ append rpl [format %${x}.${y}s $jTQ(default_site_name)] }
				{o}		{ append rpl [format %${x}.${y}s $jTQ(gquota_text_passed)] }
				{p}		{ append rpl [format %${x}.${y}s $jTQ(number_pos)] }
				{r}		{ append rpl [format %${x}.${y}s $jTQ(gquota_text_missing)] }
				{s}		{ append rpl [format %${x}.${y}s $jTQ(section_name)] }
				{t}		{ append rpl [format %${x}.${y}s $jTQ(trial_count)] }
				{u}		{ append rpl [format %${x}.${y}s $jTQ(text_username)] }
				{v}		{ append rpl [format %${x}.${y}s $jTQ(default_version)] }
				{z}		{ append rpl [format %${x}.${y}s $jTQ(text_out_group_quota)] }
				{x}		{ append rpl [format %${x}.${y}s $jTQ(gquota_users)] }
				{y}		{ append rpl [format %${x}.${y}s $jTQ(text_out_stats)] }
				{q}		{ append rpl [format %${x}.${y}s $jTQ(text_end_action)] }				
			  	
				{A}		{ append rpl [format %${x}.${y}s $jTQ(text_out_passed)] }

				{%}		{ append rpl [format %${x}.${y}s "%"] }
			  
			  	default	{ append rpl [string index $tekst $i] }
			  
			}
		
		} else {
		
			append rpl [string index $tekst $i]
		
		}
	 
	}
	
	return "$rpl"

}

###############################################
#	Get Amount Group 'grpname' Uploaded in Section 'sectname.$sectnmr' (file)
#	Fills The List of Users in Group 'grpname' (groupquota)
#
proc jTQ:GETGROUPiNFO { grpname sectname sectnmr } {
	
  	global jTQ jSB jScripts
  	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:GETGROUPiNFO { $grpname $sectname $sectnmr }" }
	
	#"$jTQ(text_groupname)" "$jTQ(section_name)" "$jTQ(sect_nmr)"
	#jTQ(sect_amount)
	#jTQ(gquota_users)

	set name		"$jScripts(location_jTQ)files/$sectname.$sectnmr"
	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: READiNG $name" }
	
	catch { set FILE			[open "$name" "r+"] }
	
	set i	1
	
	while {![eof $FILE]} {
		
		set line [gets $FILE]
		
		if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: $line" }
		
		if { [lindex $line 1] == $grpname } {
			
			if { $jTQ(quota_check_interval) == "A" } {
				set jTQ(number_amount)		[lindex $line end-1]
			}
      	
			if { $jTQ(quota_check_interval) == "M" } {
				set jTQ(number_amount)		[lindex $line end-3]
			}
      	
			if { $jTQ(quota_check_interval) == "W" } {
				set jTQ(number_amount)		[lindex $line end-5]
			}
      	
			if { $jTQ(quota_check_interval) == "D" } {
				set jTQ(number_amount)		[lindex $line end-7]
			}
			
			#increase group amount
			set jTQ(sect_amount)				[expr $jTQ(sect_amount) + $jTQ(number_amount)]
			#add user to users list
			lappend jTQ(gquota_users)		[lindex $line 0]
						
		}
		
	#!EOF
	}
		
	catch { close $FILE }
			
	return

}

proc jTQ:QUOTAS  {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:QUOTAS {$nick $uhost $hand $chan $text}" }
	
	if { !($jTQ(enable_quota)) } { return }
	
	set jTQ(enable_quotas)		true
	
	set jTQ(quotas_chan)			$chan
	
	jTQ:QUOTACHECK min hour day month year
	
	set jTQ(enable_quotas)		false

	return
	
}

proc jTQ:QUOTACHECK {min hour day month year} {
	
  	global jTQ jSB jScripts
  	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:QUOTACHECK {$min $hour $day $month $year}" }
	
  	if { !($jTQ(enable_quota)) } { return }
  	
  	if { $jTQ(enable_partyline) } { putlog "..jTQ...: QUOTA CHECK" }
  	
  	#!quotas
  	if  { !$jTQ(enable_quotas) } {
   
  		jScripts:SND $jTQ(default_admin_chan) $jTQ(skin_quota_check)
  		
  	}
  	
	set jTQ(enable_passed_end)			false
  		
  	if { $jTQ(quota_check_interval) == "M" } {
  	
		set jTQ(year)							[clock format [clock seconds] -format "%Y" -gmt false]
		set jTQ(month)							[clock format [clock seconds] -format "%m" -gmt false]
		set jTQ(nmonth)						[expr int([format %f [clock format [clock seconds] -format "%m" -gmt false]])+1]
		if {$jTQ(nmonth) == 13} {
		  set jTQ(nmonth)						1
		  set jTQ(year)						[expr $jTQ(year)+1]
		}
		set jTQ(time_month_end)				[clock scan "$jTQ(nmonth)/01/$jTQ(year) 00:00:00" -gmt false]
		set jTQ(quota_to_end_hours)		[expr int(floor([expr $jTQ(time_month_end)-[clock seconds]]/3600))]

  		if { $jTQ(enable_partyline) } { putlog "..jTQ...: $jTQ(quota_to_end_hours)h To The End Of Month" }
  		
  		if { (!$jTQ(enable_quotas)) && ($jTQ(quota_to_end_hours) < 23) } {
  			
  			set jTQ(enable_passed_end)		true
  			
  		}
  		
  		#set jTQ(enable_passed_end)		true
  		
  	}
  	
	if { !$jTQ(enable_passed_end) } {
	
		set jTQ(enable_passed_quota)	true
		
	}

	set jTQ(quotas_passed_list)	""
	set jTQ(quotas_failed_list)	""
	set jTQ(quotas_nextmn_list)	""

  	if { $jTQ(enable_local) } {
  		
		set n [split [lindex $jTQ(stats_sections_locale) 0] ":"]
	
		set name		"$jScripts(location_jTQ)files/[lindex $n 0].[lindex $n 1]"
		
		if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: READiNG $name" }
		
		catch { set FILE			[open "$name" "r+"] }
		
		while {![eof $FILE]} {
			
			catch { set line [gets $FILE] }
			
			if { $line == "" } { continue }
			
			if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: $line" }
			
			if { [lsearch $jTQ(quota_excluded_users) [lindex $line 0]] == -1 } {
				
				if { [lsearch $jTQ(quota_excluded_groups) [lindex $line 1]] == -1 } {
				
					if { ([regexp "[lindex $line 2]" "$jTQ(quota_excluded_flag)"]) == 0 } {
						
						jTQ:PASSED nick uhost hand $jTQ(default_admin_chan) [lindex $line 0]
						
					}
						
				}
				
			}
			
		}
		
		if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: CLOSE $name" }
		
		catch { close $FILE }
		
		join $jTQ(quotas_passed_list)
		join $jTQ(quotas_failed_list)
		join $jTQ(quotas_nextmn_list)
		
		#jScripts:SND $jTQ(default_admin_chan) "$jTQ(skin_quotas_passed_list) [join $jTQ(quotas_passed_list)]"
		#jScripts:SND $jTQ(default_admin_chan) "$jTQ(skin_quotas_failed_list) [join $jTQ(quotas_failed_list)]"
		#jScripts:SND $jTQ(default_admin_chan) "$jTQ(skin_quotas_nextmn_list) [join $jTQ(quotas_nextmn_list)]"
		
		set i	1
		set j	1
		set l	[llength $jTQ(quotas_passed_list)]
		set o	$jTQ(skin_quotas_passed_list)
		
		foreach entry $jTQ(quotas_passed_list) {
		  
			if { $i <= $l} {
			  
				lappend o $entry
				
				if { ($j > $jTQ(quotas_users_per_line)) || ($i >= $l) } {
				  
				  	if { $jTQ(enable_quotas) } {
				  		
				  		jScripts:SND $jTQ(quotas_chan) "[join $o]"
				  		
				  	} else {
				  		
					  	jScripts:SND $jTQ(default_admin_chan) "[join $o]"
				  	
				  	}
				  	
				  	set o	$jTQ(skin_quotas_passed_list)
				  	set j	1
				  
				}
			
			}
			
			incr i
			incr j
		  
		}

		set i	1
		set j	1
		set l	[llength $jTQ(quotas_nextmn_list)]
		set o	$jTQ(skin_quotas_nextmn_list)
		
		foreach entry $jTQ(quotas_nextmn_list) {
		  
		  	if { $i <= $l} {
		  	  
		  	  	lappend o $entry
		  	  	
		  	  	if { ($j > $jTQ(quotas_users_per_line)) || ($i >= $l) } {
		  	  	  
				  	if { $jTQ(enable_quotas) } {
				  		
				  		jScripts:SND $jTQ(quotas_chan) "[join $o]"
				  		
				  	} else {
				  		
					  	jScripts:SND $jTQ(default_admin_chan) "[join $o]"
				  	
				  	}
				  	
		  	  	  	set o	$jTQ(skin_quotas_nextmn_list)
		  	  	  	set j	1
		  	  	  
		  	  	}
		  	
		  	}
		  	
		  	incr i
		  	incr j
		  
		}
		
		#quotas
		if { !$jTQ(enable_passed_end) } {
			
			set i	1
			set j	1
			set l	[llength $jTQ(quotas_failed_list)]
			set o	$jTQ(skin_quotas_failed_list)
			
			foreach entry $jTQ(quotas_failed_list) {
			  
			  	if { $i <= $l} {
			  	  
			  	  	lappend o $entry
			  	  	
			  	  	if { ($j > $jTQ(quotas_users_per_line)) || ($i >= $l) } {
			  	  	  
					  	if { $jTQ(enable_quotas) } {
					  		
					  		jScripts:SND $jTQ(quotas_chan) "[join $o]"
					  		
					  	} else {
					  		
						  	jScripts:SND $jTQ(default_admin_chan) "[join $o]"
					  	
					  	}
					  	
			  	  	  	set o	$jTQ(skin_quotas_failed_list)
			  	  	  	set j	1
			  	  	  
			  	  	}
			  	
			  	}
			  	
			  	incr i
			  	incr j
			  
			}
		
		#quotas
		} else {
		#end of month
		
			foreach entry $jTQ(quotas_failed_list) {
			  
			  	jScripts:SND $jTQ(default_admin_chan) "[jTQ:FormatString $jTQ(skin_endquota_failed_head)] $entry"
			  	
			}
		
		#end of month
		}
		
		set jTQ(enable_passed_quota)	false
		
  	}
  	#local check
  	
	return
	
}

proc jTQ:TRiALS  {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:TRiALS {$nick $uhost $hand $chan $text}" }
	
	if { !($jTQ(enable_trial)) } { return }
	
	set jTQ(enable_trials)		true
	
	jScripts:SND $chan [jTQ:FormatString $jTQ(skin_trial_check)]
	
	set jTQ(trial_send_chan)				$chan
	
	jTQ:TRiALCHECK min hour day month year
	
	set jTQ(enable_trials)		false
	
	set jTQ(trial_send_chan)				$jTQ(default_admin_chan)

	return
	
}

proc jTQ:TRiALCHECK {min hour day month year} {
	
  	global jTQ jSB jScripts
  	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:TRiALCHECK {$min $hour $day $month $year}" }
	
  	if { !($jTQ(enable_trial)) } { return }
  	
  	if { $jTQ(enable_partyline) } { putlog "..jTQ...: TRiAL CHECK" }
  	
  	#set jTQ(trial_send_chan)				$jTQ(default_admin_chan)
  	
  	#!trials
  	if  { !$jTQ(enable_trials) } {
  	
  		jScripts:SND $jTQ(default_admin_chan) [jTQ:FormatString $jTQ(skin_trial_check)]
  		
  	}
  	
  	if { $jTQ(enable_local) } {
  		
		set n [split [lindex $jTQ(stats_sections_locale) 0] ":"]
	
		set name		"$jScripts(location_jTQ)files/[lindex $n 0].[lindex $n 1]"
		
		if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: READiNG $name" }
		
		catch { set FILE			[open "$name" "r+"] }
		
		set jTQ(trial_count)	0
		
		while {![eof $FILE]} {
			
			catch { set line [gets $FILE] }
			
			if { [lindex $line 1] == $jTQ(trial_group) } {
				
				jTQ:PASSED nick uhost hand $jTQ(trial_send_chan) [lindex $line 0]
				
				incr jTQ(trial_count)
				
			}
			
		}
		
		catch { close $FILE }
		
	  	jScripts:SND $jTQ(trial_send_chan) [jTQ:FormatString $jTQ(skin_trial_count)]
	  	
	  	#if  { !$jTQ(enable_trials) } {
  		#
		#	jScripts:SND $jTQ(default_admin_chan) [jTQ:FormatString $jTQ(skin_trial_count)]
  		#
  		#}

  	}
  	
	return
	
}

proc jTQ:PASSED {nick uhost hand chan text} {

	global jTQ jSB jScripts
	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:PASSED {$nick $uhost $hand $chan $text}" }
	
	if { !($jTQ(enable_passed)) } { return }
	
	if { [lindex $text 0] == "" } { return }
	
	if { $jTQ(enable_partyline) } { putlog "..jTQ...: PASSED '[lindex $text 0]'" }

	if { $jTQ(enable_local) } {
		
		if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: LOCALE CHECK" }
		
		set jTQ(is_trial)					false								;#user is on trial
		set jTQ(is_quota)					true								;#user is on quota
		set jTQ(is_euser)					false								;#user is excluded from quota
		set jTQ(is_egroup)				false								;#users group is excluded from quota
		set jTQ(is_eflag)					false								;#users falg is excluded from quota
		set jTQ(is_found)					false								;#user was found on site
		set jTQ(is_passed)				false								;#has user passed?
		set jTQ(is_gquota)				false								;#user is in group quota?
		                           	            					
		set jTQ(text_out_passed)		""									;#output text passed
		set jTQ(text_out_missing)		""									;#output text missing
		set jTQ(text_out_stats)			""									;#output text stats on !quotas
		set jTQ(text_out_group_quota)	""									;#output text on group quota

		set jTQ(number_of_passed)		0									;#number of sections where user has passed
		set jTQ(number_of_missing)		0									;#number of sections where user has not passed yet
		
		foreach section $jTQ(stats_sections_locale) {
			
			set jTQ(text_username)		[lindex $text 0]				;#UserName						(%u)
			set jTQ(text_groupname)		""									;#GroupName						(%g)
			set jTQ(text_flags)			""									;#UserFlags						(%f)
			set jTQ(text_dateadded)		""									;#date added

			set jTQ(number_amount)		0									;#how many user uploaded
			set jTQ(number_pos)			1									;#users possition

			#name:number
			set n 							[split $section ':']
			set jTQ(section_name)		[lindex $n 0]					;#SectionName 					(%s)
			set jTQ(section_number)		[lindex $n 1]					;#SectionNumber
			
			set name		"$jScripts(location_jTQ)files/$jTQ(section_name).$jTQ(section_number)"
			
			if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: READiNG $name" }
			
			catch { set FILE			[open "$name" "r+"] }
			
			set i	1
			
			while {![eof $FILE]} {
				
				set line [gets $FILE]
				
				if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: $line" }
				
				#user found
				if { [lindex $line 0] == $jTQ(text_username) } {
					
					set jTQ(is_found)				true
					
					set jTQ(text_groupname)		[lindex $line 1]
					set jTQ(text_flags)			[lindex $line 2]
					set jTQ(text_dateadded)		[lindex $line 3]
					set jTQ(number_pos)			$i
					
					#user is in group quota
					if { [lsearch $jTQ(group_quota_group_list) $jTQ(text_groupname)] > -1 } {
						
						set jTQ(is_gquota)		true
						
					}
						
					#user is in trial group
					if { $jTQ(text_groupname) == $jTQ(trial_group) } { 
						
						set jTQ(is_trial)	true 
						
						if { $jTQ(trial_check_interval) == "days" } {
							
							set jTQ(number_amount)		[lindex $line end-1]
							
						}
						
						if { $jTQ(trial_check_interval) == "week" } {
							
							set jTQ(number_amount)		[lindex $line end-5]
							
						}
					
					#user is in trial group
					#user is NOT in trial group
					}	else {

						if { $jTQ(quota_check_interval) == "A" } {
							set jTQ(number_amount)		[lindex $line end-1]
						}
		         	
						if { $jTQ(quota_check_interval) == "M" } {
							set jTQ(number_amount)		[lindex $line end-3]
						}
		         	
						if { $jTQ(quota_check_interval) == "W" } {
							set jTQ(number_amount)		[lindex $line end-5]
						}
		         	
						if { $jTQ(quota_check_interval) == "D" } {
							set jTQ(number_amount)		[lindex $line end-7]
						}
						
						#!quotas
						if { $jTQ(enable_passed_quota) && !$jTQ(enable_passed_end)} {
						
							lappend 				jTQ(text_out_stats) [jTQ:FormatString $jTQ(skin_quotas_stats_list)]
							
						}
						
						#end of month
						if { !$jTQ(enable_passed_quota) && $jTQ(enable_passed_end)} {
						
							lappend 				jTQ(text_out_stats) [jTQ:FormatString $jTQ(skin_endquota_stats_list)]
							
						}
													
					}
					#user is NOT in trial group
					
					break
					
				#user found
				}
				
				incr i	;#line count
				
			#!EOF
			}
				
			catch { close $FILE }
			
			#user found
			if { $jTQ(is_found) } { 
			
				set jTQ(time_now)						[clock seconds]
				
				#user is in trial group
				if { $jTQ(is_trial) } {
					
					#jScripts:SND $chan "Now.....: [clock format $jTQ(time_now) -format {%m/%d/%Y %H:%M:%S} -gmt false ]"
					#jScripts:SND $chan "Added...: $jTQ(text_dateadded)"
					#jScripts:SND $chan "Day.....: [clock format $jTQ(time_now) -format {%A} -gmt false ]"
					
					set jTQ(time_added)	[clock scan $jTQ(text_dateadded) -gmt false]
					
					if { $jTQ(trial_check_interval) == "days" } {
						
						set jTQ(trial_end_time)		[expr $jTQ(time_added) + [expr $jTQ(trial_days)*86400] ]
						set jTQ(trial_to_end_days)	[expr [expr $jTQ(trial_end_time)-$jTQ(time_now)]/86400]
				      if { $jTQ(trial_to_end_days) == 0 } {
   	     				set jTQ(trial_to_end_days) 1
				      }
						
						#jScripts:SND $chan "End.....: [clock format $jTQ(trial_end_time) -format {%m/%d/%Y %H:%M:%S} -gmt false ]"
						#jScripts:SND $chan "End Days: $jTQ(trial_to_end_days)"
						
						#trial failed
						if { $jTQ(trial_end_time) < $jTQ(time_now) } {
							
							jScripts:SND $chan			[jTQ:FormatString $jTQ(skin_trial_failed)]
							
							if { $jTQ(trial_failed_action) == "delete" } {
								
								set status 	[catch { exec -- $jTQ(location_jscripts) DELETEUSER $jTQ(text_username) } result]
								
								if { $status > 0 } { 
									putlog "..jTQ...: $jTQ(location_jscripts) DELETEUSER $jTQ(text_username) FAiLED ($result)"
									jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) DELETEUSER $jTQ(text_username) FAiLED ($result)"
									return
								}
				
								jScripts:SND $chan	"SITE RESPONSE : $result"
								
							}
							
							if { $jTQ(trial_failed_action) == "disable" } {
								
								set status 	[catch { exec -- $jTQ(location_jscripts) ADDFLAG $jTQ(text_username) $jTQ(trial_disable_flag) } result]
								
								if { $status > 0 } { 
									putlog "..jTQ...: $jTQ(location_jscripts) ADDFLAG $jTQ(text_username) $jTQ(trial_disable_flag) FAiLED ($result)"
									jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) ADDFLAG $jTQ(text_username) $jTQ(trial_disable_flag) FAiLED ($result)"
									return
								}
				
								jScripts:SND $chan	"SITE RESPONSE : $result"
								
								set status 	[catch { exec -- $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_end_group) } result]
								
								if { $status > 0 } { 
									putlog "..jTQ...: $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_end_group) FAiLED ($result)"
									jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_end_group) FAiLED ($result)"
									return
								}
				
								jScripts:SND $chan	"SITE RESPONSE : $result"
								
							}
							
							return
							
						#trial failed
						}
							
						if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: User on TRiAL" }
						
						#trial passed
						if { $jTQ(number_amount) >= $jTQ(trial_$jTQ(section_name))} {
							
							set jTQ(is_passed)			true
							
							incr jTQ(number_of_passed)
							
							set jTQ(needed_mb)			$jTQ(trial_$jTQ(section_name))
							set jTQ(over_mb)				[expr $jTQ(number_amount)-$jTQ(trial_$jTQ(section_name))]
							
							set output						[jTQ:FormatString $jTQ(skin_trial_status_passed)]
							
							if { $jTQ(number_of_passed) > 1 } {
								
								set jTQ(text_out_passed)	[concat $jTQ(text_out_passed) " And $output"]
								
							} else {
								
								set jTQ(text_out_passed)	[concat $jTQ(text_out_passed) "$output"]
								
							}
							
						#trial passed
						#trial missing
						} else {
							
							incr jTQ(number_of_missing)
							
							set jTQ(needed_mb)			$jTQ(trial_$jTQ(section_name))
							set jTQ(missing_mb)			[expr $jTQ(trial_$jTQ(section_name))-$jTQ(number_amount)]
							set jTQ(per_day_mb)			"[expr [expr $jTQ(trial_$jTQ(section_name))-$jTQ(number_amount)]/$jTQ(trial_to_end_days)]"

							set output						[jTQ:FormatString $jTQ(skin_trial_status_missing))]
							
							if { $jTQ(number_of_missing) == [llength $jTQ(stats_sections_locale)] } {
								
								set jTQ(text_out_missing)	[concat $jTQ(text_out_missing) "$output"]
								
							} else {
								
								set jTQ(text_out_missing)	[concat $jTQ(text_out_missing) "$output \037\00303Or\003\037 "]
								
							}
							
						#trial missing
						}
					
					#if { $jTQ(trial_check_interval) == "days" }
					}
					
				#user is in trial group
				#user is NOT in trial group
				} else {
					
					if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: User NOT on TRiAL" }
					
					set jTQ(year)							[clock format [clock seconds] -format "%Y" -gmt false]
					set jTQ(month)							[clock format [clock seconds] -format "%m" -gmt false]
					set jTQ(time_month_begin)			[clock scan "$jTQ(month)/01/$jTQ(year) 00:00:00" -gmt false]
					set jTQ(nmonth)						[expr int([format %f [clock format [clock seconds] -format "%m" -gmt false]])+1]
					if {$jTQ(nmonth) == 13} {
					  set jTQ(nmonth)						1
					  set jTQ(year)						[expr $jTQ(year)+1]
					}
					set jTQ(time_month_end)				[clock scan "$jTQ(nmonth)/01/$jTQ(year) 00:00:00" -gmt false]
					set jTQ(quota_to_end_days)			[expr [expr $jTQ(time_month_end)-$jTQ(time_now)]/86400]
			      if { $jTQ(quota_to_end_days) == 0 } {
        				set jTQ(quota_to_end_days) 1
			      }
					
					#jScripts:SND $chan "time now : [clock format $jTQ(time_now) -format {%m/%d/%Y %H:%M:%S} -gmt false ]"
					#jScripts:SND $chan "time mb  : [clock format $jTQ(time_month_begin) -format {%m/%d/%Y %H:%M:%S} -gmt false ]"
					#jScripts:SND $chan "time me  : [clock format $jTQ(time_month_end) -format {%m/%d/%Y %H:%M:%S} -gmt false ]"
					#jScripts:SND $chan "time da  : $jTQ(text_dateadded)"
    
					
					#group quota
					if { $jTQ(is_gquota) } {
						
						set jTQ(needed_mb)			$jTQ(group_quota_$jTQ(text_groupname)_$jTQ(section_name))
						set jTQ(percent_grp)			[expr (100*$jTQ(number_amount))/$jTQ(needed_mb)]
						
						set output						[jTQ:FormatString $jTQ(skin_group_quota_user_stats)]
						
						set jTQ(text_out_group_quota)	[concat $jTQ(text_out_group_quota) "$output"]
						
					#group quota
					#normal quota
					} else {
					
						#passed in section
						if { $jTQ(number_amount) >= $jTQ(quota_$jTQ(section_name))} {
							
							set jTQ(is_passed)			true
							incr jTQ(number_of_passed)
							
							set jTQ(needed_mb)			$jTQ(quota_$jTQ(section_name))
							set jTQ(over_mb)				[expr $jTQ(number_amount)-$jTQ(quota_$jTQ(section_name))]
							
							set output						[jTQ:FormatString $jTQ(skin_quota_status_passed)]
							
							#set output						[jScripts:Replace $output "%section"		$jTQ(section_name) ]
							#set output						[jScripts:Replace $output "%upped"			$jTQ(number_amount) ]
							#set output						[jScripts:Replace $output "%needed"			$jTQ(quota_$jTQ(section_name)) ]
							#set output						[jScripts:Replace $output "%over"			[expr $jTQ(number_amount)-$jTQ(quota_$jTQ(section_name))] ]
							#set output						[jScripts:Replace $output "%pos"				$jTQ(number_pos) ]
							
							if { $jTQ(number_of_passed) > 1 } {
								
								set jTQ(text_out_passed)	[concat $jTQ(text_out_passed) "$jTQ(skin_quota_out_passed_and)$output"]
								
							} else {
								
								set jTQ(text_out_passed)	[concat $jTQ(text_out_passed) "$output"]
								
							}
							
						#passed in section
						#not passed in section yet
						} else {
							
							incr jTQ(number_of_missing)
							
							set jTQ(needed_mb)			$jTQ(quota_$jTQ(section_name))
							set jTQ(missing_mb)			[expr $jTQ(quota_$jTQ(section_name))-$jTQ(number_amount)]
							set jTQ(per_day_mb)			[expr [expr $jTQ(quota_$jTQ(section_name))-$jTQ(number_amount)]/$jTQ(quota_to_end_days)]
														
							set output						[jTQ:FormatString $jTQ(skin_quota_status_missing)]
							
							#set output						$jTQ(skin_quota_status_missing)
							#set output						[jScripts:Replace $output "%section" 		$jTQ(section_name) ]
							#set output						[jScripts:Replace $output "%upped" 			$jTQ(number_amount) ]
							#set output						[jScripts:Replace $output "%needed" 		$jTQ(quota_$jTQ(section_name)) ]
							#set output						[jScripts:Replace $output "%missing" 		[expr $jTQ(quota_$jTQ(section_name))-$jTQ(number_amount)] ]
							#set output						[jScripts:Replace $output "%pos" 			$jTQ(number_pos) ]
							#set output						[jScripts:Replace $output "%perday"			[expr [expr $jTQ(quota_$jTQ(section_name))-$jTQ(number_amount)]/$jTQ(quota_to_end_days)] ]
							
							if { $jTQ(number_of_missing) == [llength $jTQ(stats_sections_locale)] } {
								
								set jTQ(text_out_missing)	[concat $jTQ(text_out_missing) "$output"]
								
							} else {
								
								set jTQ(text_out_missing)	[concat $jTQ(text_out_missing) "$output$jTQ(skin_quota_out_passed_or)"]
								
							}
							
						#not passed in section yet
						}
						
					#normal quota
					}
					
				#user is NOT in trial group
				}
			
			#user found
			}
				
		#foreach section
		}
		
		if { !$jTQ(is_found) } {
			
			jScripts:SND $chan 			[jTQ:FormatString $jTQ(skin_user_not_found)]
			
			return
			
		}
		
		#trial user
		if { $jTQ(is_trial) } {
			
			#passed trial
			if { $jTQ(is_passed) } {
				
				set output		$jTQ(skin_trial_out_passed)
				
				jScripts:SND $jTQ(default_admin_chan)	[jTQ:FormatString $jTQ(skin_trial_passed)]
				
				set status 	[catch { exec -- $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_end_group) } result]
				
				if { $status > 0 } { 
					putlog "..jTQ...: $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_end_group) FAiLED ($result)"
					jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_end_group) FAiLED ($result)"
					return
				}

				jScripts:SND $chan	"SITE RESPONSE : $result"
							
			#passed trial
			#missing trial
			} else {
				
				set output		$jTQ(skin_trial_out_missing)
				
			#missing trial
			}
			
			set jTQ(to_end_days)	$jTQ(trial_to_end_days)
			set jTQ(end_date)		[clock format $jTQ(trial_end_time) -format {%m/%d/%Y %H:%M:%S} -gmt false ]
			
			jScripts:SND $chan [jTQ:FormatString $output]
		
			return
			
		#trial user
		}
		
		if { [lsearch $jTQ(quota_excluded_users) $jTQ(text_username)] > -1 } {
			
			set jTQ(is_euser) true
			
		}
		
		if { [lsearch $jTQ(quota_excluded_groups) $jTQ(text_groupname)] > -1 } {
			
			set jTQ(is_egroup) true
			
		}
		
		if { ([regexp "\[$jTQ(text_flags)\]" "$jTQ(quota_excluded_flag)"]) != 0 } {
				
			set jTQ(is_eflag) true
			
		}
		
		if { ( [clock scan $jTQ(text_dateadded) -gmt false] > $jTQ(time_month_begin) ) && ( !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) ) } {
   	
			set jTQ(is_quota)					false
   	
		}
								
		#group quota
		if { $jTQ(is_gquota) && !$jTQ(is_euser) && !$jTQ(is_eflag) } {
			
			set jTQ(gquota_passed)			false
			
			set jTQ(number_of_passed)		0
			set jTQ(number_of_missing)		0
			
			set jTQ(gquota_text_passed)	""
			set jTQ(gquota_text_missing)	""
			
			
			foreach section $jTQ(stats_sections_locale) {
				
				set jTQ(section_name)		[lindex [split $section ":"] 0]
				set jTQ(section_number)		[lindex [split $section ":"] 1]
				set jTQ(sect_amount)			0
				
				set jTQ(gquota_users)		""
				
				set jTQ(grp_amount)			$jTQ(group_quota_$jTQ(text_groupname)_$jTQ(section_name))
				
				jTQ:GETGROUPiNFO "$jTQ(text_groupname)" "$jTQ(section_name)" "$jTQ(section_number)"
				
				#passed group quota
				if { $jTQ(sect_amount) > $jTQ(grp_amount) } {
					
					set jTQ(gquota_passed)			true
					incr jTQ(number_of_passed)
					
					set jTQ(needed_mb)			$jTQ(grp_amount)
					set jTQ(over_mb)				[expr $jTQ(sect_amount) - $jTQ(grp_amount)]
					
					set output						[jTQ:FormatString $jTQ(skin_group_quota_passed_stats)]
					
					#set output						$jTQ(skin_group_quota_passed_stats)
					#set output						[jScripts:Replace $output "%section"				$jTQ(section_name) ]
					#set output						[jScripts:Replace $output "%needed"					$jTQ(grp_amount) ]
					#set output						[jScripts:Replace $output "%how_many_over"		[expr $jTQ(sect_amount) - $jTQ(grp_amount)] ]
					#set output						[jScripts:Replace $output "%how_many_upped"		$jTQ(sect_amount) ]
					
					if { $jTQ(number_of_passed) > 1 } {
						
						set jTQ(gquota_text_passed)	[concat $jTQ(gquota_text_passed) "$jTQ(skin_quota_out_passed_and)$output"]
						
					} else {
						
						set jTQ(gquota_text_passed)	[concat $jTQ(gquota_text_passed) "$output"]
						
					}
							
					
				#not passsed yet
				} else {
					
					incr jTQ(number_of_missing)
					
					set jTQ(needed_mb)			$jTQ(grp_amount)
					set jTQ(missing_mb)			[expr $jTQ(grp_amount) - $jTQ(sect_amount)]
					set jTQ(per_day_mb)			[expr [expr $jTQ(grp_amount) - $jTQ(sect_amount)] / $jTQ(quota_to_end_days)]
					
					set output						[jTQ:FormatString $jTQ(skin_group_quota_missing_stats)]
					
					#set output						$jTQ(skin_group_quota_missing_stats)
					#set output						[jScripts:Replace $output "%section"				$jTQ(section_name) ]
					#set output						[jScripts:Replace $output "%needed"					$jTQ(grp_amount) ]
					#set output						[jScripts:Replace $output "%how_many_missing"	[expr $jTQ(grp_amount) - $jTQ(sect_amount)] ]
					#set output						[jScripts:Replace $output "%how_many_upped"		$jTQ(sect_amount) ]
					#set output						[jScripts:Replace $output "%perday"					[expr [expr $jTQ(grp_amount) - $jTQ(sect_amount)] / $jTQ(quota_to_end_days)] ]
					
					if { $jTQ(number_of_missing) == [llength $jTQ(stats_sections_locale)] } {
						
						set jTQ(gquota_text_missing)	[concat $jTQ(gquota_text_missing) "$output"]
						
					} else {
						
						set jTQ(gquota_text_missing)	[concat $jTQ(gquota_text_missing) "$output$jTQ(skin_quota_out_passed_or)"]
						
					}
					
				}
				
			}
			
			if { $jTQ(gquota_passed) } {
				
				set output			$jTQ(skin_group_quota_user_stats_passed)
				#set output 			[jScripts:Replace $output "%gstats_passed"		$jTQ(gquota_text_passed) ]
				
			} else {
				
				set output			$jTQ(skin_group_quota_user_stats_missing)
				#set output 			[jScripts:Replace $output "%gstats_missing"		$jTQ(gquota_text_missing) ]
				
			}
			
			#set output			[jScripts:Replace $output "%user" 			$jTQ(text_username) ]
			#set output			[jScripts:Replace $output "%group" 			$jTQ(text_groupname) ]
			#set output			[jScripts:Replace $output "%stats" 			$jTQ(text_out_group_quota) ]
			#set output 			[jScripts:Replace $output "%to_end_days"	$jTQ(quota_to_end_days) ]
			#set output 			[jScripts:Replace $output "%usrs"			$jTQ(gquota_users) ]
			
			set jTQ(to_end_days)			$jTQ(quota_to_end_days)
			set jTQ(gquota_users)		$jTQ(gquota_users)
			
			jScripts:SND $chan 			[jTQ:FormatString $output]
			
		#group quota
		} else {
		#normal quota
			
			#!passed user
			if { !$jTQ(enable_passed_quota) && !$jTQ(enable_passed_end)} {
			
				#passed quota
				if { $jTQ(is_passed) } {
					
					;#if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ(text_out_passed)=$jTQ(text_out_passed)" }
					
					if { $jTQ(is_euser) } {
						
						set output		$jTQ(skin_quota_out_user_excluded_passed)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_passed) ]
						
					}
					
					if { $jTQ(is_eflag) } {
						
						set output		$jTQ(skin_quota_out_flag_excluded_passed)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_passed) ]
						
					}
					
					if { $jTQ(is_egroup) } {
						
						set output		$jTQ(skin_quota_out_group_excluded_passed)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_passed) ]
						
					}
					
					if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && $jTQ(is_quota) } {
						
						set output		$jTQ(skin_quota_out_passed)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_passed) ]
						
					}
					
					if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && !$jTQ(is_quota) } {
						
						set output		$jTQ(skin_quota_out_not_yet_passed)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_passed) ]
						
					}
					
				#passed quota
				#missing quota
				} else {
					
					if { $jTQ(is_euser) } {
						
						set output		$jTQ(skin_quota_out_user_excluded_missing)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_missing) ]
						
					}
					
					if { $jTQ(is_egroup) } {
						
						set output		$jTQ(skin_quota_out_group_excluded_missing)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_missing) ]
						
					}
					
					if { $jTQ(is_eflag) } {
						
						set output		$jTQ(skin_quota_out_flag_excluded_missing)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_missing) ]
						
					}
					
					if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && $jTQ(is_quota) } {
						
						set output		$jTQ(skin_quota_out_missing)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_missing) ]
						
					}
					
					if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && !$jTQ(is_quota) } {
						
						set output		$jTQ(skin_quota_out_not_yet_missing)
						#set output		[jScripts:Replace $output "%status" $jTQ(text_out_missing) ]
						
					}
					
				#missing quota
				}
				
				#set output			[jScripts:Replace $output "%user" $jTQ(text_username) ]
				#set output			[jScripts:Replace $output "%group" $jTQ(text_groupname) ]
				#set output 			[jScripts:Replace $output "%to_end_days" $jTQ(quota_to_end_days) ]
				
				set jTQ(to_end_days)	$jTQ(quota_to_end_days)
				
				jScripts:SND $chan [jTQ:FormatString $output]
			
			#!passed user
			}
			
			#quotas
			if { $jTQ(enable_passed_quota) && !$jTQ(enable_passed_end)} {
			
				set output			[jTQ:FormatString $jTQ(skin_quotas_user_list)]
				#set output			[jScripts:Replace $output "%user" $jTQ(text_username) ]
				#set output			[jScripts:Replace $output "%group" $jTQ(text_groupname) ]
				#set output			[jScripts:Replace $output "%stats" $jTQ(text_out_stats) ]
				
				#jScripts:SND $chan $output
				
				if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && !$jTQ(is_quota) } {
					
					lappend jTQ(quotas_nextmn_list) $output
					
					return
					
				}
				
				if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && $jTQ(is_quota) } {
				
					if { $jTQ(is_passed) } {
						
						lappend jTQ(quotas_passed_list) $output
						
						return
						
					} else {
					
						lappend jTQ(quotas_failed_list) $output
						
						return
												
					}
					
				}
			
			}
			
			#quota end
			if { !$jTQ(enable_passed_quota) && $jTQ(enable_passed_end)} {
			
			#jScripts:SND $chan $output
			
				if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && !$jTQ(is_quota) } {
					
					jScripts:LOG "$jScripts(log_jTQ)/[clock format [clock seconds] -format {%Y-%m-%d} -gmt false].$jTQ(log_name_quota_end)" "jTQ" [jTQ:FormatString "$jTQ(skin_quotas_nextmn_list) %15u/%-15g %y %-q"]
					
					set jTQ(text_out_stats)		""
					set jTQ(text_end_action)	""
					
					set output			[jTQ:FormatString $jTQ(skin_endquota_nextmn_list)]
					
					#set output			[jScripts:Replace $output "%user"	$jTQ(text_username) ]
					#set output			[jScripts:Replace $output "%group"	$jTQ(text_groupname) ]
					#set output			[jScripts:Replace $output "%stats"	$jTQ(text_out_stats) ]
					#set output			[jScripts:Replace $output "%stats"	"" ]
					#set output			[jScripts:Replace $output "%action"	"" ]
				
					lappend jTQ(quotas_nextmn_list) $output
					
					return
					
				}
				
				if { !$jTQ(is_euser) && !$jTQ(is_egroup) && !$jTQ(is_eflag) && $jTQ(is_quota) } {
				
					if { $jTQ(is_passed) } {
						
						jScripts:LOG "$jScripts(log_jTQ)/[clock format [clock seconds] -format {%Y-%m-%d} -gmt false].$jTQ(log_name_quota_end)" "jTQ" [jTQ:FormatString "$jTQ(skin_quotas_passed_list) %15u/%-15g %y %-q"]
						
						set jTQ(text_out_stats)		""
						set jTQ(text_end_action)	""
						
						set output			[jTQ:FormatString $jTQ(skin_endquota_passed_list)]
						
						#set output			[jScripts:Replace $output "%user"	$jTQ(text_username) ]
						#set output			[jScripts:Replace $output "%group"	$jTQ(text_groupname) ]
						#set output			[jScripts:Replace $output "%stats"	$jTQ(text_out_stats) ]
						#set output			[jScripts:Replace $output "%stats"	"" ]
						#set output			[jScripts:Replace $output "%action"	"" ]
				
						lappend jTQ(quotas_passed_list) $output
						
						return
						
					} else {
					
						set output			$jTQ(skin_endquota_failed_list)
						
						#set output			[jScripts:Replace $output "%user"	[format %$jTQ(length_endquota_user)s $jTQ(text_username)] ]
						#set output			[jScripts:Replace $output "%group"	[format %$jTQ(length_endquota_group)s $jTQ(text_groupname)] ]
						#set output			[jScripts:Replace $output "%stats"	$jTQ(text_out_stats) ]
	
						if { $jTQ(quota_failed_action) == "nothing" } {
						
							set jTQ(text_end_action)	$jTQ(skin_endquota_nothing_action)
							#set output			[jScripts:Replace $output "%action"	$jTQ(skin_endquota_nothing_action) ]
							
						}
	
						if { $jTQ(quota_failed_action) == "disable" } {
						
							set jTQ(text_end_action)	$jTQ(skin_endquota_disable_action)
							#set output			[jScripts:Replace $output "%action"	$jTQ(skin_endquota_disable_action) ]
							
							set status 	[catch { exec -- $jTQ(location_jscripts) ADDFLAG $jTQ(text_username) $jTQ(quota_disable_flag) } result]
				
							if { $status > 0 } { 
								putlog "..jTQ...: $jTQ(location_jscripts) ADDFLAG $jTQ(text_username) $jTQ(quota_disable_flag) FAiLED ($result)"
								jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) ADDFLAG $jTQ(text_username) $jTQ(quota_disable_flag) FAiLED ($result)"
								break
							}
							
							#jScripts:SND $chan	"SITE RESPONSE : $result"
							if { $jTQ(enable_partyline) } { putlog "..jTQ...: SITE RESPONSE : $result" }
				  
						}
	
						if { $jTQ(quota_failed_action) == "delete" } {
						
							set jTQ(text_end_action)	$jTQ(skin_endquota_delete_action)
							#set output			[jScripts:Replace $output "%action"	$jTQ(skin_endquota_delete_action) ]
							
							set status 	[catch { exec -- $jTQ(location_jscripts) DELETEUSER $jTQ(text_username) } result]
				
							if { $status > 0 } { 
								putlog "..jTQ...: $jTQ(location_jscripts) DELETEUSER $jTQ(text_username) FAiLED ($result)"
								jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) DELETEUSER $jTQ(text_username) FAiLED ($result)"
								break
							}
							
							#jScripts:SND $chan	"SITE RESPONSE : $result"
							if { $jTQ(enable_partyline) } { putlog "..jTQ...: SITE RESPONSE : $result" }
				  
						}
	
						if { $jTQ(quota_failed_action) == "trial" } {
						
							set jTQ(text_end_action)	$jTQ(skin_endquota_trial_action)
							#set output			[jScripts:Replace $output "%action"	$jTQ(skin_endquota_trial_action) ]
							
							set status 	[catch { exec -- $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_group) } result]
				
							if { $status > 0 } { 
								putlog "..jTQ...: $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_group) FAiLED ($result)"
								jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) CHANGEGROUP $jTQ(text_username) $jTQ(trial_group) FAiLED ($result)"
								break
							}
							
							#jScripts:SND $chan	"SITE RESPONSE : $result"
							if { $jTQ(enable_partyline) } { putlog "..jTQ...: SITE RESPONSE : $result" }
				  
							set status 	[catch { exec -- $jTQ(location_jscripts) ADDTRIALTOLOG $jTQ(text_username) $jTQ(trial_group) } result]
				
							if { $status > 0 } { 
								putlog "..jTQ...: $jTQ(location_jscripts) ADDTRIALTOLOG $jTQ(text_username) $jTQ(trial_group) FAiLED ($result)"
								jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) ADDTRIALTOLOG $jTQ(text_username) $jTQ(trial_group) FAiLED ($result)"
								break
							}
							
							#jScripts:SND $chan	"SITE RESPONSE : $result"
							if { $jTQ(enable_partyline) } { putlog "..jTQ...: SITE RESPONSE : $result" }
				  
						}
	
						if { $jTQ(quota_failed_action) == "credits" } {
						
							set jTQ(text_end_action)	$jTQ(skin_endquota_credits_action)
							#set output			[jScripts:Replace $output "%action"	$jTQ(skin_endquota_credits_action) ]
							
							set status 	[catch { exec -- $jTQ(location_jscripts) CHANGECREDITS $jTQ(text_username) -$jTQ(quotas_fail_remove_credits) $jTQ(quotas_fail_remove_in_section) } result]
				
							if { $status > 0 } { 
								putlog "..jTQ...: $jTQ(location_jscripts) CHANGECREDITS $jTQ(text_username) -$jTQ(quotas_fail_remove_credits) $jTQ(quotas_fail_remove_in_section) FAiLED ($result)"
								jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) CHANGECREDITS $jTQ(text_username) -$jTQ(quotas_fail_remove_credits) $jTQ(quotas_fail_remove_in_section) FAiLED ($result)"
								break
							}
							
							#jScripts:SND $chan	"SITE RESPONSE : $result"
							if { $jTQ(enable_partyline) } { putlog "..jTQ...: SITE RESPONSE : $result" }
				  
						}
	
						lappend jTQ(quotas_failed_list) [jTQ:FormatString $output]
						
						jScripts:LOG "$jScripts(log_jTQ)/[clock format [clock seconds] -format {%Y-%m-%d} -gmt false].$jTQ(log_name_quota_end)" "jTQ" [jTQ:FormatString "$jTQ(skin_endquota_failed_head) %15u/%-15g %y %-q"]
						
						return
												
					}
					
				}
		
			}
		#normal quota
		}
		
	#locale check
	}
	
	return
	
}

proc jTQ:UPDATE {min hour day month year} {

	global jTQ jSB jScripts
	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:UPDATE {$min $hour $day $month $year}" }
	
	if { !$jTQ(enable_passed) } { return }
	
	if { ![file exists $jScripts(location_jTQ)files]} { file mkdir "$jScripts(location_jTQ)files" }
	
	if { $jTQ(enable_local) } {
		
		if { $jTQ(enable_partyline) } { putlog "..jTQ...: LOCALE UPDATE" }
		
		foreach section $jTQ(stats_sections_locale) {
			
			set n [split $section ':']
			
			set status 	[catch { exec -- $jTQ(location_jscripts) BCUSTATS [lindex $n 1] } result]

			if { $status > 0 } { 
				putlog "..jTQ...: $jTQ(location_jscripts) BCUSTATS [lindex $n 1] FAiLED ($result)"
				jScripts:SND $jTQ(default_admin_chan) "..jTQ...: $jTQ(location_jscripts) BCUSTATS [lindex $n 1] FAiLED ($result)"
				break
			}
			
			#define jScripts_bustats_out_body_complete		"{{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$ustats_timeadded$} {$bustats_dayup$} {$bustats_daydn$} {$bustats_wkup$} {$bustats_wkdn$} {$bustats_mnup$} {$bustats_mndn$} {$bustats_allup$} {$bustats_alldn$}} \n"

			if { $jTQ(quota_check_interval) == "A" } {
				catch { set result	[lsort -integer -decreasing -index end-1 $result] }
			}

			if { $jTQ(quota_check_interval) == "M" } {
				catch { set result	[lsort -integer -decreasing -index end-3 $result] }
			}

			if { $jTQ(quota_check_interval) == "W" } {
				catch { set result	[lsort -integer -decreasing -index end-5 $result] }
			}

			if { $jTQ(quota_check_interval) == "D" } {
				catch { set result	[lsort -integer -decreasing -index end-7 $result] }
			}

			set name		"$jScripts(location_jTQ)files/[lindex $n 0].[lindex $n 1]"
			
			if { $jTQ(enable_partyline) } { putlog "..jTQ...: WRiTiNG $name" }
			
			if { $jTQ(enable_update_anounce) } { jScripts:SND $jTQ(default_admin_chan)	"..jTQ...: WRiTiNG $name" }
			
			catch { set FILE			[open "$name" "w+"] }
			
			foreach line $result {
				
				if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: $line" }
				
				catch { puts $FILE	"$line" }
				
			}
				
			catch { close $FILE }
			
		}
		
	}
	
	#if { $jTQ(enable_remote) } {
	#	
	#	if { $jTQ(enable_partyline) } { putlog "..jTQ...: REMOTE UPDATE" }
	#	
	#}
	
	return
	
}

proc jTQ:iNiT {} {
	
	global jTQ jSB jScripts
	
	if { $jTQ(enable_debug_partyline) } { putlog "..jTQ...: jTQ:iNiT" }
	
	return
	
}

putlog "\002 -> .jTQ...... $jTQ(default_version) by Jeza Loaded"
