set jFB(default_version)									"1.0.0.1"

source "scripts/jFB/jFB.conf"

set jFB(votes,number)			""
set jFB(votes,name)				""
set jFB(votes,yes)				""
set jFB(votes,no)					""
set jFB(votes,description)		""

set jFB(todo,number)				""
set jFB(todo,name)				""
set jFB(todo,text)				""

proc jFB:TODO {nick uhost hand chan text} {

  	global jFB
  	
  	if { !($jFB(enable,todo)) } { return }
  	
  	set fileName	"$jFB(io,location,todo)$jFB(io,filename,todo)"
  	
  	set jFB(todo,add)	true		;#if text should be added to list
  	
  	if { [lindex $text 0] == "" } {
  		
  		set jFB(todo,add)	false
  		
  		if { $jFB(skin,todo,head) != "" } {
  			
			if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,head)] }
			if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,head)] }
			if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,head)]" }
		
		}
	
		set FILE [open "$fileName" "r"]
		
		set i 1
		
		while {![eof $FILE]} {
		
			set line [gets $FILE]
			
			if { $line == "" } { continue }
		
			set jFB(todo,number)		$i
			set jFB(todo,text)		$line
				
			if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,body)] }
			if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,body)] }
			if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,body)]" }
			
			incr i
			
		}
		
		if { $i < 2 } {
			
			if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,body,nothing)] }
			if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,body,nothing)] }
			if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,body,nothing)]" }
			
				
		}
		
		close $FILE
  			
  		if { $jFB(skin,todo,foot) != "" } {
  			
			if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,foot)] }
			if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,foot)] }
			if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,foot)]" }
		
		}
		
  	}
		
  	if { [string tolower [lindex $text 0]] == "delete" } {
  		
		set jFB(todo,add)	false
		
		if { [lindex $text 1] == "" } {
			
			if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,del,help)] }
			if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,del,help)] }
			if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,del,help)]" }
				
		}
		
		set jFB(todo,del,found)	false		;#if found the number to remove in todo file
		
		set FILE [open "$fileName" "r"]
		set lines [read $FILE]
		close $FILE
		unset FILE
		
		set FILE [open "$fileName" "w"]
		close $FILE
		unset FILE
		
		set i 1
		
		foreach line [split $lines "\n"] {
		
			if { $line == "" } { continue }
			#if { $jFB(todo,del,found) } { break }
		
			if { $i != [lindex $text 1] } {
				
				jFB:LOG "$fileName" "TODO" "$line"				
					
			} 
			
			if { $i == [lindex $text 1] } {
				
				set jFB(todo,del,found)	true
				
				if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,del)] }
				if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,del)] }
				if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,del)]" }
					
			} 
			
			incr i
			
		}
		
		if { !$jFB(todo,del,found) } {
		
			if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,del,notfound)] }
			if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,del,notfound)] }
			if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,del,notfound)]" }
				
			jFB:TODO $nick $uhost $hand $chan ""
			
		}

  	}
		
  	if { $jFB(todo,add) } {
  		
  		set jFB(todo,name)			$nick
  		set jFB(todo,text)			$text
  		
  		jFB:LOG "$fileName" "TODO" "[jFB:FormatStr1ng $jFB(skin,todo,line)]"

		if { $jFB(default,show,todo) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,todo,add)] }
		if { $jFB(default,show,todo) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,todo,add)] }
		if { $jFB(default,show,todo) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,todo,add)]" }

	}
	
  	return

}

proc jFB:VOTES {nick uhost hand chan text} {

	global jFB
	
	if { !($jFB(enable,votes)) } { return }
	
	set fileName	"$jFB(io,location,votes)$jFB(io,filename,votes)"

	if { [string tolower [lindex $text 0]] == "add" } {
	
		if { [lindex $text 1] == "" } {
			
			if { $jFB(default,show,voteadd) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,add,help)] }
			if { $jFB(default,show,voteadd) == "private" }			{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,add,help)] }
			if { $jFB(default,show,voteadd) == "notice" }			{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,add,help)]" }
				
			return
			
		}
		
		set jFB(votes,name)				[lindex $text 1]
		set jFB(votes,description)		[lrange $text 2 end]
		
		jFB:LOG "$fileName" "VOTE" "$jFB(votes,name) 0 0 $jFB(votes,description)"
		
		if { $jFB(default,show,voteadd) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,add)] }
		if { $jFB(default,show,voteadd) == "private" }			{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,add)] }
		if { $jFB(default,show,voteadd) == "notice" }			{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,add)]" }

	} elseif { [string tolower [lindex $text 0]] == "for" } {
		
		if { ([lindex $text 1] == "") && ([lindex $text 2] == "")} {
			
			if { $jFB(default,show,vote) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,vote,help)] }
			if { $jFB(default,show,vote) == "private" }			{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,vote,help)] }
			if { $jFB(default,show,vote) == "notice" }			{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,vote,help)]" }
				
			return
			
		}

		set jFB(votes,vote,found)	false		;#if found the number to remove in votes file
		
		set FILE [open "$fileName" "r"]
		set lines [read $FILE]
		close $FILE
		unset FILE
		
		set FILE [open "$fileName" "w"]
		close $FILE
		unset FILE
		
		foreach line [split $lines "\n"] {
		
			if { $line == "" } { continue }
			
			if { [lindex $line 0] != [lindex $text 1] } {
				
				jFB:LOG "$fileName" "VOTE" "$line"				
					
			}
			
			if { [lindex $line 0] == [lindex $text 1] } {
				
				set jFB(votes,vote,found)	true
				
				set jFB(votes,name)				[lindex $line 0]
				set jFB(votes,yes)				[lindex $line 1]
				set jFB(votes,no)					[lindex $line 2]
				set jFB(votes,description)		[lrange $line 3 end]
				
				if { [lindex $text 2] == "yes" } {
					set jFB(votes,yes) [expr $jFB(votes,yes) + 1]
				}
				
				if { [lindex $text 2] == "no" } {
					set jFB(votes,no) [expr $jFB(votes,no) + 1]
				}

				jFB:LOG "$fileName" "VOTE" "$jFB(votes,name) $jFB(votes,yes) $jFB(votes,no) $jFB(votes,description)"

				if { $jFB(default,show,vote) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,vote)] }
				if { $jFB(default,show,vote) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,vote)] }
				if { $jFB(default,show,vote) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,vote)]" }
					
			} 
			
		}
		
		if { !$jFB(votes,vote,found) } {
		
			if { $jFB(default,show,vote) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,vote,notfound)] }
			if { $jFB(default,show,vote) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,vote,notfound)] }
			if { $jFB(default,show,vote) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,vote,notfound)]" }
				
			jFB:VOTES $nick $uhost $hand $chan ""
			
		}
					
	} elseif { [string tolower [lindex $text 0]] == "delete" } {
	
		if { [lindex $text 1] == "" } {
			
			if { $jFB(default,show,votedel) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,del,help)] }
			if { $jFB(default,show,votedel) == "private" }			{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,del,help)] }
			if { $jFB(default,show,votedel) == "notice" }			{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,del,help)]" }
				
			return
			
		}
		
		set jFB(votes,del,found)	false		;#if found the number to remove in votes file
		
		set FILE [open "$fileName" "r"]
		set lines [read $FILE]
		close $FILE
		unset FILE
		
		set FILE [open "$fileName" "w"]
		close $FILE
		unset FILE
		
		set i 1
		
		foreach line [split $lines "\n"] {
		
			if { $line == "" } { continue }
			
			if { $i != [lindex $text 1] } {
				
				jFB:LOG "$fileName" "VOTE" "$line"				
					
			} 
			
			if { $i == [lindex $text 1] } {
				
				set jFB(votes,del,found)	true
				
				if { $jFB(default,show,votedel) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,del)] }
				if { $jFB(default,show,votedel) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,del)] }
				if { $jFB(default,show,votedel) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,del)]" }
					
			} 
			
			incr i
			
		}
		
		if { !$jFB(votes,del,found) } {
		
			if { $jFB(default,show,votedel) == "chan" } 					{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,del,notfound)] }
			if { $jFB(default,show,votedel) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,del,notfound)] }
			if { $jFB(default,show,votedel) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,del,notfound)]" }
				
			jFB:VOTES $nick $uhost $hand $chan ""
			
		}
					
	} else {
		
		if { $jFB(default,show,votes) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,head)] }
		if { $jFB(default,show,votes) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,head)] }
		if { $jFB(default,show,votes) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,head)]" }
	
		set FILE [open "$fileName" "r"]
		
		set i 1
		
		while {![eof $FILE]} {
		
			set line [gets $FILE]
			
			if { $line == "" } { continue }
			
			#name yesvotes novotes
			set jFB(votes,number)			$i
			set jFB(votes,name)				[lindex $line 0]
			set jFB(votes,yes)				[lindex $line 1]
			set jFB(votes,no)					[lindex $line 2]
			set jFB(votes,description)		[lrange $line 3 end]
			
			if { $jFB(default,show,votes) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,body)] }
			if { $jFB(default,show,votes) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,body)] }
			if { $jFB(default,show,votes) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,body)]" }
	
			incr i
			
		}
		
		if { $i < 2 } {
			
			if { $jFB(default,show,votes) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,nothing)] }
			if { $jFB(default,show,votes) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,nothing)] }
			if { $jFB(default,show,votes) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,nothing)]" }
			
				
		}
		
		close $FILE
	
		if { $jFB(default,show,votes) == "chan" } 				{ jFB:SND $chan [jFB:FormatStr1ng $jFB(skin,votes,foot)] }
		if { $jFB(default,show,votes) == "private" }				{ jFB:SND $nick [jFB:FormatStr1ng $jFB(skin,votes,foot)] }
		if { $jFB(default,show,votes) == "notice" }				{ putquick "NOTICE $nick :[jFB:FormatStr1ng $jFB(skin,votes,foot)]" }

	}
	
	return
	
}

proc jFB:LOG {what where text} {
	
	global jFB
	
	if { ($jFB(enable,votes)) && ($where == "VOTE") } {
		
      set file [open "$what" "a+"]
      puts $file "$text"
      close $file
			
	}

	if { ($jFB(enable,todo)) && ($where == "TODO") } {
		
      set file [open "$what" "a+"]
      puts $file "$text"
      close $file
			
	}

	return
	
}

proc jFB:CHECK {} {

	global jFB
	
	if { $jFB(enable,votes) } {
		
		if {![file exist $jFB(io,location,votes)]} { 
		
			file mkdir "$jFB(io,location,votes)"
		
		}
		
		if {![file exist "$jFB(io,location,votes)$jFB(io,filename,votes)"]} {
			
			jFB:LOG "$jFB(io,location,votes)$jFB(io,filename,votes)" "VOTE" ""
			
		}

	}

	if { $jFB(enable,todo) } {
		
		if {![file exist $jFB(io,location,todo)]} { 
		
			file mkdir "$jFB(io,location,todo)"
		
		}
		
		if {![file exist "$jFB(io,location,todo)$jFB(io,filename,todo)"]} {
			
			jFB:LOG "$jFB(io,location,todo)$jFB(io,filename,todo)" "TODO" ""
			
		}

	}

	return
		
}

proc jFB:REHASH {nick uhost hand chan text} {

	global jFB
	
	if { !($jFB(enable,rehash)) } { return }
	
	rehash
	
	jFB:SND $chan "REHASH DONE"
	
	return
	
}

proc jFB:FormatStr1ng { tekst } {
  
	global jFB
	
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
			  
				{a}		{ append rpl [format %${x}.${y}s $jFB(votes,number)] }
				{b}		{ append rpl [format %${x}.${y}s $jFB(votes,name)] }
				{c}		{ append rpl [format %${x}.${y}s $jFB(votes,yes)] }
				{d}		{ append rpl [format %${x}.${y}s $jFB(votes,no)] }
				{e}		{ append rpl [format %${x}.${y}s $jFB(votes,description)] }
				{f}		{ append rpl [format %${x}.${y}s $jFB(todo,number)] }
				{g}		{ append rpl [format %${x}.${y}s $jFB(todo,name)] }
				{h}		{ append rpl [format %${x}.${y}s $jFB(todo,text)] }
				{i}		{ append rpl [format %${x}.${y}s "empty"] }
				{j}		{ append rpl [format %${x}.${y}s "empty"] }
				{k}		{ append rpl [format %${x}.${y}s "empty"] }
				{l}		{ append rpl [format %${x}.${y}s "empty"] }
				{m}		{ append rpl [format %${x}.${y}s "empty"] }
				{n}		{ append rpl [format %${x}.${y}s "empty"] }
				{o}		{ append rpl [format %${x}.${y}s "empty"] }
				{p}		{ append rpl [format %${x}.${y}s "empty"] }
				{r}		{ append rpl [format %${x}.${y}s "empty"] }
				{s}		{ append rpl [format %${x}.${y}s "empty"] }
				{t}		{ append rpl [format %${x}.${y}s "empty"] }
				{u}		{ append rpl [format %${x}.${y}s "empty"] }
				{v}		{ append rpl [format %${x}.${y}s "empty"] }
				{z}		{ append rpl [format %${x}.${y}s "empty"] }
				{q}		{ append rpl [format %${x}.${y}s "empty"] }
				{w}		{ append rpl [format %${x}.${y}s "empty"] }
				{y}		{ append rpl [format %${x}.${y}s "empty"] }
				{x}		{ append rpl [format %${x}.${y}s "empty"] }
			  	
				{A}		{ append rpl [format %${x}.${y}s "empty"] }
				{B}		{ append rpl [format %${x}.${y}s "empty"] }
				{C}		{ append rpl [format %${x}.${y}s "empty"] }
				{D}		{ append rpl [format %${x}.${y}s "empty"] }
				{E}		{ append rpl [format %${x}.${y}s "empty"] }
				{F}		{ append rpl [format %${x}.${y}s "empty"] }
				{G}		{ append rpl [format %${x}.${y}s "empty"] }
				{H}		{ append rpl [format %${x}.${y}s "empty"] }
				{I}		{ append rpl [format %${x}.${y}s "empty"] }
				{J}		{ append rpl [format %${x}.${y}s "empty"] }
				{K}		{ append rpl [format %${x}.${y}s "empty"] }
				{L}		{ append rpl [format %${x}.${y}s "empty"] }
				{M}		{ append rpl [format %${x}.${y}s "empty"] }
				{N}		{ append rpl [format %${x}.${y}s "empty"] }
				{O}		{ append rpl [format %${x}.${y}s "empty"] }
				{P}		{ append rpl [format %${x}.${y}s "empty"] }
				{R}		{ append rpl [format %${x}.${y}s "empty"] }
				{S}		{ append rpl [format %${x}.${y}s "empty"] }
				{T}		{ append rpl [format %${x}.${y}s "empty"] }
				{U}		{ append rpl [format %${x}.${y}s "empty"] }
				{V}		{ append rpl [format %${x}.${y}s "empty"] }
				{Z}		{ append rpl [format %${x}.${y}s "empty"] }
				{Q}		{ append rpl [format %${x}.${y}s "empty"] }
				{W}		{ append rpl [format %${x}.${y}s "empty"] }
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

proc jFB:SND {dest text} {

	global jFB
	
	foreach line [split $text $jFB(default,split,char)] {
		
		if { $jFB(fish,key) != "" } {
			
			set eline [encrypt $jFB(fish,key) $line]
			putquick "PRIVMSG $dest :$jFB(fish,head) $eline"
			
		} else {
			
			putquick "PRIVMSG $dest :$line"
			
		}
	
	}
	
	return
  
}

proc jFB:FiSH {nick uhost hand chan arg} {
  
	global jFB
	
	set cmdline	[decrypt $jFB(fish,key) $arg]
	set dcmd		[lindex $cmdline 0]
	set darg		[lrange $cmdline 1 end]
	
	#jFB BiNDINGS
	foreach prc $jFB(bind) {
		
		set n [split $prc "-"]
		
		if { ($dcmd == "[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "all")} {
		
			[lindex $n 1] $nick $uhost $hand $chan $darg

			break
				
		}
		
		if { ($dcmd == "[lindex $n 0]") && ([string tolower "[lindex $n 2]"] == "op")} {
		
			if { [isop $nick $chan] } {
				
				[lindex $n 1] $nick $uhost $hand $chan $darg
				
			}

			break
				
		}

	}

	#jFB BiNDINGS
	
	return
	
}

proc jFB:BiND {} {

	global jFB
	
	if { ($jFB(fish,key) == "") } {
	
		#jFB BiNDINGS
		foreach prc $jFB(bind) {
			
			set n [split $prc "-"]
			
			bind pub -|- [lindex $n 0] [lindex $n 1]
			
		}
		#jFB BiNDINGS
		
	} else {
	
		bind pub -|- $jFB(fish,head) jFB:FiSH
		
	}

	return
	
}

jFB:BiND
jFB:CHECK

putlog "\002 -> .jFB. $jFB(default_version) by Jeza Loaded"
