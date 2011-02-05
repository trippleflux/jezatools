source "scripts/jSB/jSB.conf"


set jSB(n_user)		""
set jSB(n_group)		""
set jSB(n_mb)			""


proc jSB:GETLOGSSIZE {} {

	global jTQ jSB jScripts
	
	foreach LogFile $jSB(location_list) {
		
		if { !$jSB(enable_monitor_$LogFile) } { continue }
		
		if { ![file exists $jSB(location_$LogFile)] } { 
			
			set jSB(LastLogSize,$LogFile) 0
			
			continue
		
		}
		
		catch { set jSB(LastLogSize,$LogFile) [file size $jSB(location_$LogFile)] }
		
		if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB:GETLOGSSIZE jSB(LastLogSize,$LogFile) = '$jSB(LastLogSize,$LogFile)'" }
			
	}
	
	return
	
}

proc jSB:READLOGS {} {

	global jTQ jSB jScripts
	
	#if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB:READLOGS { }" }
	
	foreach LogFile $jSB(location_list) {
		
		if { !$jSB(enable_monitor_$LogFile) } { continue }
		
		if { ![file exists $jSB(location_$LogFile)] } { continue }
		
		catch { set jSB(LogSize,$LogFile) [file size $jSB(location_$LogFile)] }
		
		catch { 
			
			if { $jSB(LogSize,$LogFile) == jSB(LastLogSize,$LogFile) } { 
				
				utimer 1 "jSB:READLOGS"
				return
				
			} 
			
		}
		
		catch { 
			
			if { $jSB(LogSize,$LogFile) < $jSB(LastLogSize,$LogFile) } { 
			
				set jSB(LastLogSize,$LogFile) $jSB(LogSize,$LogFile)
				utimer 1 "jSB:READLOGS"
				return
				
			} 
			
		}
		
		if { [catch { set FILE [open $jSB(location_$LogFile) r] } ] } { 
			
			utimer 1 "jSB:READLOGS"
			return
		
		}
		
		#if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB:READLOGS $LogFile" }
		
		seek $FILE $jSB(LastLogSize,$LogFile)
		
		while {![eof $FILE]} {
			
			set line [gets $FILE]
			
			#regsub -all -- {\\} $line {/} line
			
			if { $line == "" } { continue }
			
			foreach type $jSB(type_system_list) {
				
				if { $type == $LogFile } {
			
					jScripts:SND $jSB(default_admin_chan) "$jSB(skin,$LogFile) [lrange $line 2 end]"
					
					break
				
				}
					
			}
			
			foreach type $jSB(type_race_list) {
				
				if { $type == $LogFile } {
			
					set jSB(line)	[lrange $line 2 end]
					
					set jSB(type)	[lindex $line 2]				;#NEWDIR, DELDIR, ...
					set jSB(vars)	[lrange $line 3 end]			;#"Jeza" "FRiENDS" "/test/...
					
					regsub -all -- {:} $jSB(type) {} jSB(type)
					
					;#it is in VARS
					if { [info exists jSB(var,$LogFile,$jSB(type))] } {
						
						;#find %pwd possition for sectionname
						set jSB(pos)		[lsearch $jSB(var,$LogFile,$jSB(type)) "%pwd"]
						
						if { $jSB(pos) > -1 } {
							
							set jSB(section)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] 1]
							
						} else {
							
							set jSB(section)	"default"
							
						}
						
						;#check if section should NOT be anounced
						set jSB(hidden)	false
						
						if { $jSB(section) != "default" } {
							
							foreach hide_sect $jSB(section_exclude) {
								
								if { $jSB(enable_debug_partyline) } { putlog "[lindex $jSB(vars) $jSB(pos)] -- $hide_sect" }

								if { [string match -nocase $hide_sect [lindex $jSB(vars) $jSB(pos)]] != 0 } { 
									
									if { $jSB(enable_debug_partyline) } { putlog "--> found hidden dir -> break" }
									
									set jSB(hidden)	true
									
									break
									
								}
									
							}
							
						}
						
						if { $jSB(hidden) } { continue }
						
						;#find release name
						set jSB(rlsname)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end]
						set jSB(rlsroot)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end-1]
						
						if { $jSB(rlsname) == "" } {
							
							set jSB(rlsname)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end-1]
							set jSB(rlsroot)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end-2]

						}
						
						;#find skin
						if { [info exists jSB(section,$jSB(section),skin)] } { 
							
							set jSB(skin)	$jSB(section,$jSB(section),skin)
							
						} else {
							
							set jSB(skin)	$jSB(section,default,skin)
								
						}
						
						;#check if type should be anounced
						set jSB(anounced)	-1
						
						if { $jSB(section,$jSB(section),anounce) == "ALL" } {
							
							set jSB(anounced)	1

						} else {
							
							set jSB(anounced)	[lsearch $jSB(section,$jSB(section),anounce) "$jSB(type)"]
							
						}
						
						if { $jSB(anounced) == -1 } { continue }
						
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(type) = '$jSB(type)'" }
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(pos) = '$jSB(pos)'" }
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(section) = '$jSB(section)'" }
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(skin) = '$jSB(skin)'" }
						
						;#skin to anounce not there
						if { ![info exists jSB(skin,$jSB(type),$LogFile,$jSB(skin))] } { continue }

						set i 0
						
						;#use skin as template
						set output	"$jSB(skin,$jSB(type),$LogFile,$jSB(skin))"
						
						set output	[jScripts:Replace "$output" "%section" "$jSB(section)"]
						set output	[jScripts:Replace "$output" "%rls" "$jSB(rlsname)"]
						set output	[jScripts:Replace "$output" "%pth" "$jSB(rlsroot)"]
						
						set jSB(user)	""
						
						;#go trough all VARS
						foreach smt $jSB(var,$LogFile,$jSB(type)) {
							
							if { (($jSB(type) == "NUKE") || ($jSB(type) == "UNNUKE")) && ($smt == "%nukees") } {
								
								#"[lindex $jSB(vars) $i]"
								#"ioFTPD ioftpd 0 pimpek iND 18"
								set jSB(tmp)		"[lindex $jSB(vars) $i]"
								set jSB(nmbr)		"[expr [llength $jSB(tmp)]/3]"
								set jSB(nukees)	""
								set jSB(n_user)	""
								set jSB(n_group)	""
								set jSB(n_mb)		""
								
								if { $jSB(enable_debug_partyline) } { putlog "..jSB...: %nukees = '$jSB(tmp)' = $jSB(nmbr)" }
								
								for {set x 0} {$x<$jSB(nmbr)} {incr x} {
									
									set jSB(n_user)	[lindex $jSB(tmp) [expr [expr $x*3]+0]]
									set jSB(n_group)	[lindex $jSB(tmp) [expr [expr $x*3]+1]]
									set jSB(n_mb)		[lindex $jSB(tmp) [expr [expr $x*3]+2]]
									
									#"%nukeeuser@%%nukeegroup (%nukeembMB)"
									
									set jSB(temp)		$jSB(skin,nukees)
									
									set jSB(temp) 		[jScripts:Replace "$jSB(temp)" "%nukeeuser" "$jSB(n_user)"]
									set jSB(temp) 		[jScripts:Replace "$jSB(temp)" "%nukeegroup" "$jSB(n_group)"]
									set jSB(temp) 		[jScripts:Replace "$jSB(temp)" "%nukeemb" "$jSB(n_mb)"]
									
									lappend jSB(nukees) $jSB(temp)
										
								}
								
								regsub -all -- {\{|\}} $jSB(nukees) {} jSB(nukees)
								
								set output [jScripts:Replace "$output" "$smt" "$jSB(nukees)"]
								
							} else {
							
								set output [jScripts:Replace "$output" "$smt" "[lindex $jSB(vars) $i]"]
								
							}
							
							if { ($jSB(type) == "INVITE") && ($smt == "%ircnick") } {
								
								set jSB(user) "[lindex $jSB(vars) $i]"
								
							}
							
							incr i
								
						}
						
						if { $jSB(type) == "INVITE" } {
							
							foreach channel $jSB(section,invite,chan) { 
								
								puthelp "INVITE $jSB(user) $channel"
								
							}
							
							foreach channel $jSB(section,invite,anounce) { 
								
								jScripts:SND $channel "$output"
								
							}
							
							continue
							
						}

						if { ![info exists jSB(section,$jSB(section),chan)] } { continue }
						
						foreach chn	$jSB(section,$jSB(section),chan) {
							
							jScripts:SND $chn "$output"
							
						}
						
					}
					;#it is in VARS
					
					break
				
				}
					
			}
				
		}
		
		close $FILE
		
		set jSB(LastLogSize,$LogFile) [file size $jSB(location_$LogFile)]
			
	}
	
	utimer 1 "jSB:READLOGS"
	
	return
	
}

jSB:GETLOGSSIZE
jSB:READLOGS

putlog "\002 -> .jSB...... $jSB(default_version) by Jeza Loaded"
