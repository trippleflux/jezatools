set jSB(default_version)									"1.0.0.6"

source "$jScripts(location_jSB)jSB.conf"


set jSB(n_user)		""
set jSB(n_group)		""
set jSB(n_mb)			""


proc jSB:ARCHIVELOGS { archFile archSize } {
	
	global jTQ jSB jScripts
	
	foreach ArchLogFile $jSB(arch,list) {
		
		if { $archFile != $ArchLogFile } { continue }
		
		if { $archSize > $jSB(arch,$ArchLogFile,size) } {
			
			if { $jSB(arch,$ArchLogFile,action) == "copy" } {
			
				if {![file exist $jSB(arch,$archFile,path)]} { 
				
					if { $jScripts(enable_partyline) } { putlog "..jS....: CREATiNG $jSB(arch,$archFile,path)" }
					file mkdir "$jSB(arch,$archFile,path)"
				
				}
				
				set jScripts(arch,date,format)	[clock format [clock seconds] -format $jSB(arch,ioFTPD,head,date)]
				set jSB(arch,$ArchLogFile,name)	[jScripts:FormatString $jSB(arch,$ArchLogFile,name)]
				file copy -force -- "$jSB(location_$archFile)" "$jSB(arch,$ArchLogFile,path)$jSB(arch,$ArchLogFile,name)"

				if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB:ARCHIVELOGS '$jSB(location_$archFile)' '$jSB(arch,$ArchLogFile,path)$jSB(arch,$ArchLogFile,name)'" }
				
			}

		   set file [open $jSB(location_$archFile) "w+"]
		   puts $file ""
		   close $file
		   
		   if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB:ARCHIVELOGS CLEAR '$archFile'" }
		   
		}
		
	}

	return
	
}

proc jSB:GETLOGSSIZE {} {

	global jTQ jSB jScripts
	
	#if { $jSB(enable,xferlog,readonly) } {
	#	
	#	file attributes "$jSB(location_xferlog)" -readonly
	#	
	#}
	
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
		
		if { $jSB(enable,arhive,logs) } {
			
			jSB:ARCHIVELOGS $LogFile $jSB(LogSize,$LogFile)
			
		}
		
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
			
			;#anounce system logs
			foreach type $jSB(type_system_list) {
				
				if { $type == $LogFile } {
			
					if { $jSB(enable_debug_partyline) } { putlog "..jSB...: $LogFile [lrange $line 2 end]" }
					
					jScripts:SND $jSB(default_admin_chan) "$jSB(skin,$LogFile) [lrange $line 2 end]"
					
					break
				
				}
					
			}
			
			;#race logs
			foreach type $jSB(type_race_list) {
				
				;#found logfile to anounce
				if { $type == $LogFile } {
			
					set jSB(line)	[lrange $line 2 end]
					
					set jSB(type)	[lindex $line 2]				;#NEWDIR, DELDIR, ...
					set jSB(vars)	[lrange $line 3 end]			;#"Jeza" "FRiENDS" "/test/...
					
					;#remove ':' --> :NEWDIR
					regsub -all -- {:} $jSB(type) {} jSB(type)
					
					;#it is in VARS
					if { [info exists jSB(var,$LogFile,$jSB(type))] } {
						
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: VARS....: $jSB(vars)" }
						
						;#IMDB
						if { $jSB(type) == "IMDB" } {
							
							set jSB(vars)	[jSB:GETIMDB [lindex $line 3] [lindex $line 4] [lindex $line 5] [lindex $line 6] [lindex $line 7]]
							
						}
						
						;#find %pwd possition for sectionname
						set jSB(pos)		[lsearch $jSB(var,$LogFile,$jSB(type)) "%pwd"]
						
						if { $jSB(pos) > -1 } {
							
						#set jSB(section)	[string tolower [lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] 1]]
						set jSB(section)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] 1]
							
						} else {
							
							;#section not found
							set jSB(section)	"default"
							
						}
						
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: TYPE....: $jSB(type)" }
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: SECTiON.: $jSB(section)" }
						
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
						
						if { $jSB(hidden) } { 
							
							if { $jSB(enable_debug_partyline) } { putlog "..jSB...: HiDDEN..: $jSB(section)" }
							
							continue
							
						}
						
						;#find release name
						set jSB(rlsname)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end]
						set jSB(rlsroot)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end-1]
						
						if { $jSB(rlsname) == "" } {
							
							set jSB(rlsname)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end-1]
							set jSB(rlsroot)	[lindex [split [lindex $jSB(vars) $jSB(pos)] "/"] end-2]

						}
						
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: RELEASE.: $jSB(rlsroot)/$jSB(rlsname)" }
						
						;#find skin
						if { [info exists jSB(section,$jSB(section),skin)] } { 
							
							set jSB(skin)	$jSB(section,$jSB(section),skin)
							
						} else {
							
							set jSB(skin)	$jSB(section,default,skin)
								
						}
						
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: SKiN NR.: $jSB(skin)" }
						
						;#check if type should be anounced
						
						if { ![info exists jSB(section,$jSB(section),anounce)] } { 
							
							if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(section,$jSB(section),anounce) Not Found!" }

							continue 
							
						}
						
						set jSB(anounced)	-1
						
						if { $jSB(section,$jSB(section),anounce) == "ALL" } {
							
							set jSB(anounced)	1

						} else {
							
							set jSB(anounced)	[lsearch $jSB(section,$jSB(section),anounce) "$jSB(type)"]
							
						}
						
						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: ANOUNCE.: $jSB(anounced)" }
						
						if { $jSB(anounced) == -1 } { 
							
							continue 
						
						}
						
						#if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(type) = '$jSB(type)'" }
						#if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(pos) = '$jSB(pos)'" }
						#if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(section) = '$jSB(section)'" }
						#if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(skin) = '$jSB(skin)'" }
						
						;#skin to anounce not there
						if { ![info exists jSB(skin,$jSB(type),$LogFile,$jSB(skin))] } { 
							
							if { $jSB(enable_debug_partyline) } { putlog "..jSB...: NO SKiN.: jSB(skin,$jSB(type),$LogFile,$jSB(skin))" }
							
							continue 
							
						}

						if { $jSB(enable_debug_partyline) } { putlog "..jSB...: SKiN....: jSB(skin,$jSB(type),$LogFile,$jSB(skin))" }
						
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
								
								if { $jSB(enable_debug_partyline) } { putlog "..jSB...: UN/NUKE.: $jSB(rlsname)" }
								
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

						if { [lsearch $jSB(section,requeue,anounce) "$jSB(type)"] } {
							
							foreach channel $jSB(section,requeue,chan) { 
								
								jScripts:SND $channel "$output"
								
							}
							
							continue
							
						}

						if { ![info exists jSB(section,$jSB(section),chan)] } { 
							
							if { $jSB(enable_debug_partyline) } { putlog "..jSB...: jSB(section,$jSB(section),chan) Not Found!" }

							continue 
							
						}
						
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

#########################################################
# MAP HTML CODES										           #
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
# SEARCH ON IMDB                                        #
#                                                       #
# From Bounty                                           #
#                                                       #
#########################################################
set vpath ""
proc jSB:GETIMDB {vpath url user group winpath} {
	
	#putlog "proc imdbcall"
	global jTQ jSB jScripts
	
	set title 		"N/A"
	set name 		"N/A"
	set genre 		"N/A"
	set tagline 	"N/A"
	set plot 		"N/A"
	set rating 		"N/A"
	set votes 		"N/A"
	set mpaa 		"N/A"
	set runtime 	"N/A"
	set budget 		"N/A"
	set screens 	"N/A"
	set country 	"N/A"
	set language 	"N/A"
	set soundmix 	"N/A"
	set top250 		"N/A"
	
	set url2 		[string map {207.171.166.140 www.imdb.com} $url]
	
#	set page [::http::config -useragent "MSIE 6.0"]
#	set page [::http::geturl $url]
#	set html [::http::data $page]
#	::http::Finish $page
	
	set page [::http::config -useragent "MSIE 6.0"]
	set page [::http::geturl $url -timeout 10000]
	putlog "status.. [::http::status $page]"
   set html [::http::data $page]
   ::http::Finish $page
	
	
	putlog "page=$page"
	putlog "html=$html"

	set a [regexp {<title>(.+)</title>} $html title]
	putlog "$title $a"
    ## get title
    if [regexp {<title>[^<]+} $html title] {
        set pos [expr [string last > $title] + 1]
        set title [string range $title $pos end]
        set title [htmlcodes $title]
    }
#    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG title == $title" }
#	## get title
#	if [regexp {<title>+} $html title] {
#		set pos [expr [string last > $title] + 1]
#		set title [string range $title $pos end]
#		regexp {([0-9]+)} $title year
#		set title [htmlcodes $title]
#	}
	## get director
	if [regexp {Directed by</h5>\n<[^>]+>[^<]+} $html name] {
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

	set page [::http::config -useragent "MSIE 6.0"]
	set page [::http::geturl ${url}business]
	set html [::http::data $page]
	::http::Finish $page

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

	# create IMDB MESSAGES
	if { $jSB(enable,imdb,msg) } {
		
		foreach TMP_MSG [split $jSB(imdb,msg,files) " "] {
			
			if { $jSB(imdb,file,action) == "a" } {
			
				set fileid [open "$winpath/$TMP_MSG" a]
				
			} else {
				
				set fileid [open "$winpath/$TMP_MSG" w]
				
			}
			
			puts $fileid ""
			puts $fileid ""
			puts $fileid "                          I M D B  I N F O                            "
			puts $fileid " --------------------------------------------------------------------"
			puts $fileid "   Title....: [format %-55.55s $title] "
			puts $fileid "   Rating...: [format %-8.8s $rating] [format %-46.46s " "] "
			puts $fileid "   Votes....: [format %-8.8s $votes] [format %-46.46s " "] "
			puts $fileid "   Genre....: [format %-55.55s $genre] "
			puts $fileid "   Director.: [format %-55.55s $name] "
			puts $fileid "   URL......: [format %-55.55s $url2] "
			puts $fileid "   Runtime..: [format %-3.3s $runtime] mins [format %-46.46s " "] "
			puts $fileid "   Budget...: [format %-55.55s $budget] "
			puts $fileid "   Screens..: [format %-55.55s $screens] "
			puts $fileid " --------------------------------------------------------------------"
			puts $fileid ""
			puts $fileid ""
			
			close $fileid
			
		}
			
	}
		
	set result "\"$vpath\" \"$url2\" \"$title\" \"$name\" \"$genre\" \"$plot\" \"$rating\" \"$votes\" \"$runtime\" \"$budget\" \"$screens\" \"$tagline\" \"$top250\" \"$mpaa\" \"$country\" \"$language\" \"$soundmix\" \"$user\" \"$group\" \"$winpath\""
	
	return $result
	
}

jSB:GETLOGSSIZE
jSB:READLOGS

catch { package require http 2.3 }

putlog "\002 -> .jSB...... $jSB(default_version) by Jeza Loaded"
#putlog [jSB:GETIMDB "/movies/up/qweqw/" "http://www.imdb.com/title/tt0062622" "jeza" "ind" "D:\\movies\\up\\qweqw"]
