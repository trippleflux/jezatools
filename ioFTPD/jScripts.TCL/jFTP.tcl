set jFTP(default,version)									"1.0.0.2"

source "$jScripts(location_jFTP)jFTP.conf"
source "$jScripts(location_ftplib)ftplib.tcl"

set jFTP(text,usergroup)					""
set jFTP(text,username)						""
set jFTP(text,groupname)					""

set jFTP(text,sitename)						""

set jFTP(text,credits)						""
set jFTP(text,credits,total)				""

set jFTP(ftp,connected)						false

proc jFTP:FTP {nick uhost hand chan text} {

	global jTQ jSB jScripts jFTP
	
	if { $jFTP(enable,partyline) } { putlog "..jFTP..: jFTP:FTP {$nick $uhost $hand $chan $text}" }
	
	if { !$jFTP(enable,commands) } { return }
	
	foreach site $jFTP(default,sites,list) {
		
		set n [split $site ":"]
		
		set name [lindex $n 0]
		set type	[lindex $n 5]
		
		if { [lsearch $jFTP(default,disabled,list) $name ] != -1 } { 
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' Is Disabled" }
			continue
			
		}
		
		if { [lsearch $jFTP(default,command,list) $name ] == -1 } { 
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' Not In List For FTP Commands." }
			continue
			
		}
		
		set reply [ catch { [ [lindex $n 0]::Noop ] } result ]
		if { $jFTP(enable,partyline) } { putlog "..jFTP..: result='$result'" }
		
		if { ($reply != 1) || ( ![string match -nocase "invalid command name*" $result]) } {

			if { $jFTP(enable,partyline) } { putlog "..jFTP..: jFTP:FTP Connection Error -> '$name'" }
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: result: $result" }
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: reply : $reply" }
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' -> Add To Disabled List" }
			
			set jFTP(default,disabled,list) [concat $jFTP(default,disabled,list) " $name"]
			continue
			
		}
		
		set number_of_args [llength $text]
		
		if { $number_of_args < 2 } { return }
		
		if { $number_of_args == 2 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] ]
		}
		
		if { $number_of_args == 3 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] ]
		}
		
		if { $number_of_args == 4 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] ]
		}
		
		if { $number_of_args == 5 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] ]
		}
		
		if { $number_of_args == 6 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] ]
		}
		
		if { $number_of_args == 7 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] ]
		}
		
		if { $number_of_args == 8 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] [lindex $text 7] ]
		}
		
		if { $number_of_args == 9 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] [lindex $text 7] [lindex $text 8] ]
		}
		
		if { $number_of_args == 10 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] [lindex $text 7] [lindex $text 8] [lindex $text 9] ]
		}
		
		if { $number_of_args == 11 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] [lindex $text 7] [lindex $text 8] [lindex $text 9] [lindex $text 10] ]
		}
		
		if { $number_of_args == 12 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] [lindex $text 7] [lindex $text 8] [lindex $text 9] [lindex $text 10] [lindex $text 11] ]
		}
		
		if { $number_of_args == 13 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] [lindex $text 7] [lindex $text 8] [lindex $text 9] [lindex $text 10] [lindex $text 11] [lindex $text 12] ]
		}
		
		if { $number_of_args == 14 } {
			set reply [ [lindex $n 0]::Quote [lindex $text 0] [lindex $text 1] [lindex $text 2] [lindex $text 3] [lindex $text 4] [lindex $text 5] [lindex $text 6] [lindex $text 7] [lindex $text 8] [lindex $text 9] [lindex $text 10] [lindex $text 11] [lindex $text 12] [lindex $text 13] ]
		}
		 
		set data [split $reply "\n" ]
		
		foreach line $data {
		
			jScripts:SND $jFTP(default,admin,chan) "\037$name\037 $line"
		 
		}

	}

	return
		
}

proc jFTP:CREDiTS {nick uhost hand chan text} {

	global jTQ jSB jScripts jFTP
	
	if { $jFTP(enable,partyline) } { putlog "..jFTP..: jFTP:CREDiTS {$nick $uhost $hand $chan $text}" }

	if { !$jFTP(enable,credits) } { return }
	
	if { ![file exists $jScripts(location_jFTP)files]} { jFTP:UPDATE min hour day month year }
	
	set jFTP(text,username)		[lindex $text 0]

#	if { $jFTP(enable,anounce,credits,head) } {
#		
#		set output						[jFTP:FormatString $jFTP(skin,credits,head)]
#		
#		if { $jFTP(default,show,credits) == "chan" } 			{ jScripts:SND $chan $output }
#		if { $jFTP(default,show,credits) == "private" }			{ jScripts:SND $nick $output }
#		if { $jFTP(default,show,credits) == "notice" }			{ putquick "NOTICE $nick :$output" }
#
#	}
	
	foreach site $jFTP(default,sites,list) {
	
		set n [split $site ":"]
		
		set name [lindex $n 0]
		set type	[lindex $n 5]
		
		if { [lsearch $jFTP(default,disabled,list) $name ] != -1 } { 
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' Is Disabled" }
			continue
			
		}
		
		set fileName "$jScripts(location_jFTP)files/users.$name"
		
		if { ![file exists $fileName] } { 
			
			jScripts:SND $jFTP(default,admin,chan) "jFTP -> '$fileName' Is Missing"
			continue
			
		}
		
		set jFTP(user,found)	false
		set jFTP(text,line)	""
		
		set FILE [open $fileName "r"]
		set result [read $FILE]
		close $FILE
		unset FILE
		
		set data [split $result "\n"]
		
		foreach line $data {
			
			if { $line == "" } { continue }
			
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: $line" }
			
			;#found user
			if { [lindex $line 1] == [lindex $text 0] } {
					
				set jFTP(user,found)	true
				set jFTP(text,line)	$line
				break
					
			}
			
		}
			
		set jFTP(text,sitename)		$name
		
		if { $jFTP(user,found) } {	
			
			;#glFTPD
			if { $type == "gl"} {
				
				set jFTP(text,username)		[lindex $jFTP(text,line) 1]
				set jFTP(text,groupname)	[lindex $jFTP(text,line) 2]
				set jFTP(text,credits)		[lindex $jFTP(text,line) end]
				regsub -all -- {MB} $jFTP(text,credits) {} jFTP(text,credits)
				
			} else {
				
				set jFTP(text,username)		[lindex $jFTP(text,line) 1]
				set jFTP(text,groupname)	[lindex $jFTP(text,line) 3]
				set jFTP(text,credits)		[lindex $jFTP(text,line) end-1]
					
			}
			
			set output						[jFTP:FormatString $jFTP(skin,credits,body)]
			
			if { $jFTP(default,show,credits) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jFTP(default,show,credits) == "private" }			{ jScripts:SND $nick $output }
			if { $jFTP(default,show,credits) == "notice" }			{ putquick "NOTICE $nick :$output" }
			
		} else {
			
			set output						[jFTP:FormatString $jFTP(skin,credits,user,not,found,on,site)]
			
			if { $jFTP(default,show,credits) == "chan" } 			{ jScripts:SND $chan $output }
			if { $jFTP(default,show,credits) == "private" }			{ jScripts:SND $nick $output }
			if { $jFTP(default,show,credits) == "notice" }			{ putquick "NOTICE $nick :$output" }
				
		}

	}
		
	return
		
}

proc jFTP:CREDiTSALL {nick uhost hand chan text} {

	global jTQ jSB jScripts jFTP
	
	if { $jFTP(enable,partyline) } { putlog "..jFTP..: jFTP:CREDiTSALL {$nick $uhost $hand $chan $text}" }

	if { !$jFTP(enable,credits) } { return }
	
	if { ![file exists $jScripts(location_jFTP)files]} { jFTP:UPDATE min hour day month year }
	
	set jFTP(text,username)		[lindex $text 0]
	
	set jFTP(user,found,all)	false
	set jFTP(text,credits)		0
	
	foreach site $jFTP(default,sites,list) {
	
		set n [split $site ":"]
		
		set name [lindex $n 0]
		set type	[lindex $n 5]
		
		if { [lsearch $jFTP(default,disabled,list) $name ] != -1 } { 
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' Is Disabled" }
			continue
			
		}
		
		set fileName "$jScripts(location_jFTP)files/users.$name"
		
		if { ![file exists $fileName] } { 
			
			jScripts:SND $jFTP(default,admin,chan) "jFTP -> '$fileName' Is Missing"
			continue
			
		}
		
		set jFTP(user,found)	false
		set jFTP(text,line)	""
		
		set FILE [open $fileName "r"]
		set result [read $FILE]
		close $FILE
		unset FILE
		
		set data [split $result "\n"]
		
		foreach line $data {
			
			if { $line == "" } { continue }
			
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: $line" }
			
			;#found user
			if { [lindex $line 1] == [lindex $text 0] } {
					
				set jFTP(user,found)	true
				set jFTP(text,line)	$line
				break
					
			}
			
		}
			
		if { $jFTP(user,found) } {	
			
			set jFTP(user,found,all)	true
			
			;#glFTPD
			if { $type == "gl"} {
				
				set jFTP(text,sitename)		$name
				set jFTP(text,username)		[lindex $jFTP(text,line) 1]
				set jFTP(text,groupname)	[lindex $jFTP(text,line) 2]
				set jFTP(text,credits)		[lindex $jFTP(text,line) end]
				regsub -all -- {MB} $jFTP(text,credits) {} jFTP(text,credits)
					
			} else {
				
				set jFTP(text,sitename)		$name
				set jFTP(text,username)		[lindex $jFTP(text,line) 1]
				set jFTP(text,groupname)	[lindex $jFTP(text,line) 3]
				set jFTP(text,credits)		[lindex $jFTP(text,line) end-1]
					
			}
			
			set jFTP(text,credits,total)	[expr $jFTP(text,credits,total) + $jFTP(text,credits)]
			
		} else {
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$jFTP(text,username)' Not Found On '$name'" }
				
		}

	}
	
	if { $jFTP(user,found,all) } {
		
		set output						[jFTP:FormatString $jFTP(skin,credits,total)]
		
		if { $jFTP(default,show,credits) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jFTP(default,show,credits) == "private" }			{ jScripts:SND $nick $output }
		if { $jFTP(default,show,credits) == "notice" }			{ putquick "NOTICE $nick :$output" }
		
	} else {
		
		set output						[jFTP:FormatString $jFTP(skin,credits,user,not,found)]
		
		if { $jFTP(default,show,credits) == "chan" } 			{ jScripts:SND $chan $output }
		if { $jFTP(default,show,credits) == "private" }			{ jScripts:SND $nick $output }
		if { $jFTP(default,show,credits) == "notice" }			{ putquick "NOTICE $nick :$output" }
			
	}
	
	return
		
}

proc jFTP:UPDATE {min hour day month year} {

	global jTQ jSB jScripts jFTP
	
	if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: jFTP:UPDATE {$min $hour $day $month $year}" }
	
	if { !$jFTP(enable,credits) } { return }
	
	if { ![file exists $jScripts(location_jFTP)files]} { file mkdir "$jScripts(location_jFTP)files" }
	
	jScripts:SND $jFTP(default,admin,chan) "jFTP -> Updating Users List"
	
	foreach site $jFTP(default,sites,list) {
	
		set n [split $site ":"]
		
		set name [lindex $n 0]
		set type	[lindex $n 5]
		
		if { [lsearch $jFTP(default,disabled,list) $name ] != -1 } { 
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' Is Disabled" }
			continue
			
		}
		
		set reply [ catch { [ [lindex $n 0]::Noop ] } result ]
		
		if { ($reply != 1) || ( ![string match -nocase "invalid command name*" $result]) } {

			if { $jFTP(enable,partyline) } { putlog "..jFTP..: jFTP:UPDATE Connection Error -> '$name'" }
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: result: $result" }
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: reply : $reply" }
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' -> Add To Disabled List" }
			
			set jFTP(default,disabled,list) [concat $jFTP(default,disabled,list) " $name"]
			continue
			
		}
		
		if { $jFTP(enable,partyline) } { putlog "..jFTP..: Saving Users File For '$name'" }
		
		set reply	[ [lindex $n 0]::Quote SITE USERS ]
		set data	[split $reply "\n" ]
		
		if { ($type == "io") && ([lindex $data end]  != "200 USERS Command successful.") } {
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: Wrong Response From SITE USERS Command '[lindex $data end]'" }
			continue
		}
		
		if { ($type == "gl") && !([string match -nocase "200*Total members." [lindex $data end] ]) } {
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: Wrong Response From SITE USERS Command '[lindex $data end]'" }
			continue
		}
		
		set FILE [open "$jScripts(location_jFTP)files/users.$name" "w"]
		
		foreach line $data {
			
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: $line" }
			puts $FILE "$line"
			
		}
		
		close $FILE
		
	}
	
	return
	
}

proc jFTP:FormatString { tekst } {
  
	global jTQ jSB jScripts jFTP
	
	if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: jFTP:FormatString { $tekst}" }
	
	set rpl	""
	set x		0
	set y		999

	set jFTP(text,usergroup)					"$jFTP(text,username)/$jFTP(text,groupname)"
	
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
			  
				{a}		{ append rpl [format %${x}.${y}s $jFTP(text,usergroup)] }
				
				{c}		{ append rpl [format %${x}.${y}s $jFTP(text,credits)] }
				
				{g}		{ append rpl [format %${x}.${y}s $jFTP(text,groupname)] }
				
				{s}		{ append rpl [format %${x}.${y}s $jFTP(text,sitename)] }
				{t}		{ append rpl [format %${x}.${y}s $jFTP(text,credits,total)] }
				{u}		{ append rpl [format %${x}.${y}s $jFTP(text,username)] }
				{v}		{ append rpl [format %${x}.${y}s $jFTP(default,version)] }
			  	
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

proc jFTP:NOOP {min hour day month year} {

	global jTQ jSB jScripts jFTP
	
	if { !$jFTP(ftp,connected)} { 
	
		if { $jFTP(enable,partyline) } { putlog "..jFTP..: NotReady Yet" }
		return
		
	}
  
	foreach site $jFTP(default,sites,list) {
	
		set n [split $site ":"]
		
		set name [lindex $n 0]
		
		if { [lsearch $jFTP(default,disabled,list) $name ] != -1 } { 
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' Is Disabled" }
			continue
			
		}
		
		catch { [lindex $n 0]::Noop } noop
		
		#if { ([string trim $noop] == "invalid command name \"[lindex $n 0]::Noop\"") || ([string trim $noop] == "") }
		if { ([string trim $noop] == "invalid command name \"[lindex $n 0]::Noop\"") } { 
		
			jFTP:CONNECT
			return
		
		} else {
			
			if { $jFTP(enable,partyline) } { putlog "..jFTP..: '$name' -> NOOP" }
			
		}
		
	}
	
	return
  
}

proc jFTP:CONNECT {} {

	global jTQ jSB jScripts jFTP
	
	if { $jFTP(enable,partyline) } { putlog "..jFTP..: jFTP:CONNECT" }
	
	set jFTP(default,disabled,list)								""

	foreach site $jFTP(default,sites,list) {
	
		set n [split $site ":"]
		
		set name [lindex $n 0]

		catch { [lindex $n 0]::Noop } noop
		
		if { $jFTP(enable,partyline) } { putlog "..jFTP..: trying $name -> '$noop'" }
			
		if { [string trim $noop] == "invalid command name \"[lindex $n 0]::Noop\""} { 
		
		   catch { [lindex $n 0]::Close } close
		   if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: '$name' Add New Connection" }
		   catch { FTP::new [lindex $n 0] } new
	   
		} 
		
		catch { [lindex $n 0]::Noop } status
		
		if { [string trim $status] == "" } {
			
			if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: '$name' Open New Connection" }
		   catch { [lindex $n 0]::Open [lindex $n 1] [lindex $n 3] [lindex $n 4] -port [lindex $n 2] } ftp
		   
		   if { $ftp == 1 } {
		   	
		   	if { $jFTP(enable,partyline) } { putlog "..jFTP..: $name connected. status='$status'" }
		   	
		   } else {
		   	
		   	if { $jFTP(enable,partyline) } { putlog "..jFTP..: $name failed to connect status='$status' ftp='$ftp'" }
		   	
				set jFTP(default,disabled,list) [concat $jFTP(default,disabled,list) " $name"]
				if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: '$name' -> Add To Disabled List" }
	
		   	catch { [lindex $n 0]::Close } close
		   		
		   }
		
		}
			
		if { $jFTP(enable,debug,partyline) } { putlog "..jFTP..: '$name' Response Is '$status'" }
			
		after 2000
		
	}

	set jFTP(ftp,connected)						true
	
	return
		
}

after 10000 jFTP:CONNECT

putlog "\002 -> .jFTP..... $jFTP(default,version) by Jeza Loaded"