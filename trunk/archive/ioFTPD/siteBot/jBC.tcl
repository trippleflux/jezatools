### DEFAULT         -#
set jBC(default_command_prefix)							"!"
### FiSH            -#
set jBC(fish_head)											"+OK"
set jBC(fish_key)												"sfdhkjh31h45kjh4608dg'09rewgjlkz5jn54209uds0fg"


catch {rename putquick put2quick}

bind pub -|- $jBC(fish_head) jBC:FiSH

proc putquick {text {option ""}} {
	
	global jBC
	
	if { ![string compare -nocase -length 7 $text "PRIVMSG"] } {
		
		set pos [string first ":" $text]
		
		if {$pos == -1} { return }
		
		incr pos
		
		set eline [encrypt $jBC(fish_key) [string range $text $pos end]]
		
		#put2quick "PRIVMSG [lindex $text 1] :$jBC(fish_head) $eline"
		
		put2quick "$text"

	}
	
}

proc jBC:FiSH {nick uhost hand chan arg} {
  
	global jBC
	
	set cmdline	[decrypt $jBC(fish_key) $arg]
	set dcmd		[lindex $cmdline 0]
	set darg		[lrange $cmdline 1 end]
	
	foreach item [binds pub] {

		if {[lindex $item 2] == "+OK"} { continue }

		if {[lindex $item 1] != "-|-"} {
			
			if {![matchattr $hand [lindex $item 1] $chan]} { continue }
			
		}
		
		if {![string compare -nocase [lindex $item 2] [lindex $dcmd 0]]} {
			
			#putlog "-> $item"	
			
			eval [lindex $item 4] [list $nick $uhost $hand $chan $darg]
			
			break
			
		}		
	
	}
	
	return
	
}

putlog "jBC 1.0.0.1 Loaded"