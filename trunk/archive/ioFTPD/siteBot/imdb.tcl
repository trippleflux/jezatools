###############################################################################
##     This iMDB.tcl requires Eggdrop1.6.0 or higher                         ##
##                  (c) 2003 by B0unTy                                       ##
##                                                                           ##
##  changed by OV2                                                           ##
##  28.02.2007:                                                              ##
##    *ratings work again                                                    ##
##    *director and writing credits work again                               ##
##                                                                           ##
##  25.02.2007:                                                              ##
##    *fixed some bugs of the previous changes (thanks to rosc2112)          ##
##                                                                           ##
##  24.02.2007:                                                              ##
##    *bold/underline/color in front of the multiline cast will now be       ##
##     applied to each of the cast lines                                     ##
##    *the | character is now used to declare sections in the announce line  ##
##     if any variable in a section is not found on the imdb page, the       ##
##     corresponding section will not be displayed in the output             ##
##     (see the default announce line for an example)                        ##
##                                                                           ##
##  22.02.2007:                                                              ##
##    *incorporated some code from rosc2112's version                        ##
##    *some small fixes                                                      ##
##                                                                           ##
##  20.02.2007:                                                              ##
##    *changed regexp queries to accomodate the new imdb layout              ##
##    *cleaned up the unneccesary post-regexp code                           ##
##                                                                           ##
##  14.05.2006:                                                              ##
##    *fixed plot outline not showing completely if it included links        ##
##      (thanks to darkwing for finding the bug)                             ##
##    +added support for awards (thanks to rosc2112)                         ##
##    +added support for the cast list (be careful with the limit)           ##
##    +added support for writing credits                                     ##
##                                                                           ##
##  21.01.2006:                                                              ##
##    *fixed problem with irregular search-result pages from imdb            ##
##                                                                           ##
##  31.08.2005:                                                              ##
##    *changed search result priority again:                                 ##
##      1. popular match where the title=search string                       ##
##      2. exact matches                                                     ##
##      3. first title on page                                               ##
##    *fixed missig warn_msg var                                             ##
##                                                                           ##
##  until 24.06.2005:                                                        ##
##    *works with new IMDB                                                   ##
##    *works with (hopefully) all search results (popular/exact/partial)     ##
##    +added timeouts (20secs)                                               ##
##    +added bottom 100 support                                              ##
##    +added rating bar from chilla's imdb-script                            ##
##    +added flood control                                                   ##
##    *small speedup (if your output does not include %screens or %budget    ##
##    *changed proc name to improve compatibility with other scripts         ##
##    *changed search result priority to {exact->first displayed}            ##
##                                                                           ##
###############################################################################
##                                                                           ##
## INSTALL:                                                                  ##
## ========                                                                  ##
##   1- Copy iMDB.tcl in your dir scripts/                                   ##
##   2- Add iMDB.tcl in your eggdrop.conf:                                   ##
##        source scripts/imdb.tcl                                            ##
##                                                                           ##
##   For each channel you want users to use !imdb cmd                        ##
##   Just type in partyline: .chanset #channel +imdb                         ##
##                                                                           ##
###############################################################################
# COOKIES ARE :
# =============
# TITLE             = %title      |    BOLD           = %bold
# URL               = %url        |    UNDERLINE      = %uline
# DIRECTOR          = %name       |    COLORS         = %color#,#
# GENRE             = %genre      |    NEW LINE       = \n
# SYNOPSIS          = %plot       |-----------------------------
# RATING            = %rating     |    !! to reset color code !!
# RATING_BAR        = %rbar       |    !! use %color w/o args !!
# VOTES             = %votes      |
# RUNTIME           = %time       |
# AWARDS            = %awards     |
# BUDGET            = %budget     |
# SCREENS           = %screens    |
# TAGLINE           = %tagline    |
# MPAA              = %mpaa       |
# COUNTRY           = %country    |
# LANGUAGE          = %language   |
# SOUND MIX         = %soundmix   |
# TOP 250           = %top250     |
# CAST LINES        = %castmline  |
# WRITING CREDITS   = %wcredits   |
#
# RANDOMIZING OUTPUT :
# ====================
# Exemple:
#  set random(IMDBIRC-0)       "IMDB info for %bold%title%bold Directed by %name"
#  set random(IMDBIRC-1)       "IMDB info for %title Directed by %bold%name%bold"
#  set random(IMDBIRC-2)       "IMDB info for %title Directed by %name"
# TYPE --------^   ^
#       ID --------^
#
#  set announce(IMDBIRC) "random 3"
# TYPE ---------^        ^    ^
#       RANDOM ----------^    ^
#           # OF IDS ---------^
#
# exemple random announces:
# set announce(IMDBIRC) "random 3"
# set random(IMDBIRC-0) "IMDB info for %bold%title%bold Directed by %name -> rated %uline%rating%uline (%votes votes) - genre: %genre - runtime: %time mins >> URL: %uline%url%uline >> Budget: %budget >> Screens: (USA) %screens"
# set random(IMDBIRC-1) "TITLE: %bold%title%bold - DIRECTOR: %name - RATE: %rating by %votes users - GENRE: %genre - RUNTIME: %time mins - URL: %url - BUDGET: %budget - SCREENS: (USA) %screens"
# set random(IMDBIRC-2) "%bold%title%bold - %url\n%boldDirected by:%bold %name\n%boldGenre:%bold %genre\n%boldTagline:%bold %tagline\n%boldSynopsis:%bold %plot\n%boldRating:%bold %rating (%votes votes) top 250:%bold%top250%bold\n%boldMPAA:%bold %mpaa\n%boldRuntime:%bold %time mins.\n%boldCountry:%bold %country\n%boldLanguage:%bold %language\n%boldSound Mix:%bold %soundmix\n%boldBudget:%bold %budget \n%boldOpening Weekend:%bold (USA) %screens"

# example normal announce:
set announce(IMDBIRC) "%bold%title%bold - %url\n|Genre: %genre|\n|Tagline: %tagline|\n|Synopsis: %plot|\n|Rating: %rating (%votes votes) %rbar| |%color3%top250%color|\n|Awards: %awards|\n|Runtime: %time mins.|"

#rating bar color
#bracket
set barcol1 "14"
#stars
set barcol2 "7"
#cast count to return on multiline (0 means no limit)
set cast_linelimit "5"

#http connection timeout (milliseconds)
set imdb_timeout "25000"

#flood-control
set queue_enabled 1
#max requests
set queue_size 5
#per ? seconds
set queue_time 120

# for a channel !imdb request
# set to 1 = all results will be sent publicly to the channel
# set to 0 = all results will be sent as private notice
set pub_or_not 1

# use or not the imdb debugger (1=enable debug  0=disable debug)
set IMDB_DEBUG 0

# set IMDB_ALTERNATIVE 0 = use the internal tcl http 2.3 package
# set IMDB_ALTERNATIVE 1 = use the external curl 6.0+
set IMDB_ALTERNATIVE 0

# set here the location path where find curl 6.0+
set binary(CURL) "/path/to/curl"
# note for windrop: use normal slashes, e.g. C:/path/to/curl.exe

#################################################################
# DO NOT MODIFY BELOW HERE UNLESS YOU KNOW WHAT YOU ARE DOING!  #
#################################################################
if { $IMDB_ALTERNATIVE == 0 } { package require http 2.3 }
setudef flag imdb

bind pub -|- !imdb imdb_proc

set instance 0
set warn_msg 0

proc htmlcodes {tempfile} {
    set mapfile [string map {&#34; ' &#38; & &#91; ( &#92; / &#93; ) &#123; ( &#125; ) &#163; £ &#168; ¨ &#169; © &#171; « &#173; ­ &#174; ® &#161; ¡ &#191; ¿ } $tempfile]
    set mapfile [string map {&#180; ´ &#183; · &#185; ¹ &#187; » &#188; ¼ &#189; ½ &#190; ¾ &#192; À &#193; Á &#194; Â } $mapfile]
    set mapfile [string map {&#195; Ã &#196; Ä &#197; Å &#198; Æ &#199; Ç &#200; È &#201; É &#202; Ê &#203; Ë &#204; Ì &#205; Í &#206; Î &#207; Ï &#208; Ð &#209; Ñ &#210; Ò &#211; Ó &#212; Ô &#213; Õ &#214; Ö } $mapfile]
    set mapfile [string map {&#215; × &#216; Ø &#217; Ù &#218; Ú &#219; Û &#220; Ü &#221; Ý &#222; Þ &#223; ß &#224; à &#225; á &#226; â &#227; ã &#228; ä &#229; å &#230; æ &#231; ç &#232; è &#233; é &#234; ê } $mapfile]
    set mapfile [string map {&#235; ë &#236; ì &#237; í &#238; î &#239; ï &#240; ð &#241; ñ &#242; ò &#243; ó &#244; ô &#245; õ &#246; ö &#247; ÷ &#248; ø &#249; ù &#250; ú &#251; û &#252; ü &#253; ý &#254; þ } $mapfile]
    set mapfile [string map {&nbsp; "" &amp; "&"} $mapfile]
    return $mapfile
}

proc channel_check_imdb { chan } {
    foreach setting [channel info $chan] {
        if {[regexp -- {^[\+-]} $setting]} {
            if {![string compare "+imdb" $setting]} {
                set permission 1
                break
            } else {
                set permission 0
            }
        }
    }
    return $permission
}

proc replacevar {strin what withwhat} {
    set output $strin
    set replacement $withwhat
    set cutpos 0
    while { [string first $what $output] != -1 } {
        set cutstart [expr [string first $what $output] - 1]
        set cutstop  [expr $cutstart + [string length $what] + 1]
        set output [string range $output 0 $cutstart]$replacement[string range $output $cutstop end]
    }
    return $output
}

proc findnth {strin what count} {
     set ret 0
     for {set x 0} {$x < $count} {incr x} {
         set ret [string first $what $strin [expr $ret + 1]]
     }
     return $ret
}

proc imdb_proc { nick uhost handle chan arg } {
    global cast_linelimit instance queue_size queue_time queue_enabled imdb_timeout barcol1 barcol2 IMDB_DEBUG pub_or_not announce random warn_msg binary IMDB_ALTERNATIVE
    # channel_check permission
    set permission_result [channel_check_imdb $chan]
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG permission_result == $permission_result" }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG instance == $instance" }
    if { $permission_result == 0} { return }
    # public or private
    if {$pub_or_not == 1 } { set toput "PRIVMSG $chan" } else { set toput "NOTICE $nick" }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG toput_result == $toput" }
    # if no arg passed, show help
    if {$arg == ""} {
        if { $IMDB_ALTERNATIVE == 0 } { set using "Http 2.3+" } else { set using "Curl 6.0+" }
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG no arg passed, show help" }
        puthelp "$toput :IMDb info script \002v28.02.2007\002 using \002$using\002"
        puthelp "$toput :\002Syntax: !imdb <movie title>\002 exemple: !imdb Beautiful Mind"
        return
    }

    #flood-control
    if { $queue_enabled == 1 } {
       #flooded?
       if { $instance >= $queue_size } {
          if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG flood detected" }
          if { $warn_msg == 0 } {
             set warn_msg 1
             putquick "$toput :Flood-Control: Request for \"$arg\" from user \"$nick\" will not be answered."
             putquick "$toput :Flood-Control: Maximum of $queue_size requests every $queue_time seconds."
             utimer 120 wmsg
          }
          return
       }
       incr instance
       if { $IMDB_DEBUG == 1 } { putlog "IMDB_DEBUG new instance == $instance" }
       utimer [set queue_time] decr_inst
    }

    # initial search
    set imdburl "http://www.imdb.com"
    set imdbsearchurl "http://akas.imdb.com/find?tt=on;nm=on;mx=5;"
    set searchString [string map {\  %20 & %26 , %2C . %20} $arg]
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG searchString: \"$searchString\"" }
    if { $IMDB_ALTERNATIVE == 0 } {
        set page [::http::config -useragent "MSIE 6.0"]
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG ${imdbsearchurl}q=$searchString" }
        if [catch {set page [::http::geturl ${imdbsearchurl}q=$searchString -timeout $imdb_timeout]} error] {
            puthelp "$toput :Error retrieving URL... try again later."
            ::http::Finish $page
            return
        }
        if { [::http::status $page] == "timeout" } {
            puthelp "$toput :\002Connection to imdb.com timed out while doing initial search.\002"
            ::http::Finish $page
            return
        }
        set html [::http::data $page]
        ::http::Finish $page
    } else {
        catch { exec $binary(CURL) "${imdbsearchurl}q=$searchString" } html
    }
    #if redirect necessary (search page), find first link and redirect
    if { ([regexp {<title>IMDb.*Search} $html] == 1) } {
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG redirect 1" }
        set ttcode "0000001"
        set start "0"
        #start from the headline
        regexp -indices {<h1>IMDb.*Search</h1>} $html start
        set temp [string range $html [lindex $start 1] end]

        #dealing with different search results
        set hit 0
        if { [regexp -indices {Popular Titles} $temp tstart] } {
           if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG found popular titles" }
           set temp2 [string range $temp [lindex $tstart 1] end]
           regexp {<a.*?>(.*?)</a>} $temp2 dummy title
           if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG compare $title == $arg" }
           if { [string equal -nocase $title $arg] } {
              if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG equals - displaying first popular match" }
              set temp $temp2
              set hit 1
           } else {
              if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG not equal - searching for exact match" }
           }

        }
        if { $hit == 0 } {
           if { [regexp -indices {Exact Matches} $temp start] } {
              if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG displaying exact match" }
           } elseif { [regexp -indices {Titles} $temp start] } {
              if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG no exact match - displaying first title on page" }
           } else {
                puthelp "$toput :No useful results."
                if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG no titles results found" }
                return
           }
           set temp [string range $temp [lindex $start 1] end]
        }

        #searching for first ttcode
        if [regexp {/title/tt[0-9]+} $temp ttcode] {
           set pos [string last / $ttcode] ; incr pos
           set ttcode [string range $ttcode $pos end]
        }
        # for bogus ttcode
        if { $ttcode == "0000001" } {
            puthelp "$toput :No no no! I can't find that!"
            if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG bogus ttcode" }
            return
        }
        set newurl "$imdburl/title/$ttcode/"
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG redirect 1 = $newurl" }
        # get the page redirected to
        unset html
        if { $IMDB_ALTERNATIVE == 0 } {
            set page [::http::config -useragent "MSIE 6.0"]
            set page [::http::geturl $newurl -timeout $imdb_timeout]
            if [catch {set page [::http::geturl $newurl -timeout $imdb_timeout]} error] {
                puthelp "$toput :Error retrieving URL... try again later."
                ::http::Finish $page
                return
	    }
            if {[::http::status $page]=="timeout"} {
                puthelp "$toput :\002Connection to imdb.com timed out.\002"
                ::http::Finish $page
                return
            }
            set html [::http::data $page]
            ::http::Finish $page
        } else {
            catch { exec $binary(CURL) "$newurl" } html
        }
    # if no redirect necessary (only one match in meta), then go there
    } else {
        set location ""
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG redirect 0" }
        if { $IMDB_ALTERNATIVE == 0 } {
            upvar 0 $page oldpage
            regexp {title/tt[0-9]+/} $oldpage(meta) location
        } else {
            set result [catch { exec $binary(CURL) -i "${imdbsearchurl}q=$searchString" } oldpage]
            putlog $oldpage
            regexp {title/tt[0-9]+/} $oldpage location
        }
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG redirect 0 Location == $location" }
        set newurl "$imdburl/$location"
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG redirect 0 = $newurl" }
        if { $location != "" } {
            if { $IMDB_ALTERNATIVE == 0 } {
                unset html
                set page [::http::config -useragent "MSIE 6.0"]
                if [catch {set page [::http::geturl $newurl -timeout $imdb_timeout]} error] {
                    puthelp "$toput :Error retrieving URL... try again later."
                    ::http::Finish $page
                    return
                }
                if {[::http::status $page]=="timeout"} {
                    puthelp "$toput :\002Connection to imdb.com timed out.\002"
                    ::http::Finish $page
                    return
                }
                set html [::http::data $page]
                ::http::Finish $page
            } else {
                unset html
                catch { exec $binary(CURL) "$newurl" } html
            }
        } else { 
            puthelp "$toput :Error in search mechanics - you probably need a newer version." 
            return 
        } 

    }
    # for bogus searches
    if {[string length $newurl] == 0} {
        puthelp "$toput :No no no! I can't find that!"
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG bogus searches" }
        return
    }

    # decide on output
    if { ! [string compare [lindex $announce(IMDBIRC) 0] "random"] && [string is alnum -strict [lindex $announce(IMDBIRC) 1]] == 1 } {
        set output $random(IMDBIRC\-[rand [lindex $announce(IMDBIRC) 1]])
    } else {
        set output $announce(IMDBIRC)
    }

    # collect output
    set title "N/A" ; set name "N/A" ; set genre "N/A" ; set tagline "N/A"
    set plot "N/A" ; set rating "N/A" ; set votes "N/A" ; set mpaa "N/A"
    set runtime "N/A" ; set budget "N/A" ; set screens "N/A" ; set country "N/A"
    set language "N/A" ; set soundmix "N/A" ; set top250 "top/bottom:N/A"; set awards "N/A"
    set rating_bar ""; set cast_multiline "N/A"; set wcredits "N/A"
    ## get title
    if [regexp {<title>[^<]+} $html title] {
        set pos [expr [string last > $title] + 1]
        set title [string range $title $pos end]
        set title [htmlcodes $title]
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG title == $title" }
    ## get director
    if [regexp {<h5>Directed by</h5>\n(.*?)<br/>\n<br/>} $html dummy name] {
        set name [string map {(more) "" <br>&nbsp; ""} $name]
        set name [string map {<br/> ", "} $name]
        regsub -all {<[^>]+>} $name {} name
        set name [htmlcodes $name]
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG director == $name" }
    ## get writing credits
    if [regexp {<h5>Writing credits.*?</h5>\n(.*?)<br/>\n<br/>} $html dummy wcredits] {
        set wcredits [string map {"more" "" <br/>&nbsp; "" "&#38;<br/>" "& " <br/> ", "} $wcredits]
        regsub -all {<[^>]+>} $wcredits {} wcredits
        set wcredits [htmlcodes $wcredits]
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG writer == $wcredits" }
    ## get genre
    if [regexp {<a href=./Sections/Genres[^\n]+} $html genre] {
        set genre [string map {"more" ""} $genre]
        regsub -all {<[^\>]*>} $genre {} genre
        regsub {\(.*\)} $genre {} genre
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG genre == $genre" }
    ## get tagline
    if [regexp {<h5>Tagline:</h5>\n(.*?)\n} $html dummy tagline] {
        set tagline [string map {"more" "" } $tagline]
        regsub -all {<[^\>]*>} $tagline {} tagline
        set tagline [string trim $tagline]
        set tagline [htmlcodes $tagline]
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG tagline == $tagline" }
    ## get plot
    if { [regexp {<h5>Plot Outline:</h5> \n(.*?)\n} $html dummy plot] || [regexp {<h5>Plot Summary:</h5> \n(.*?)\n} $html dummy plot] } {
        set plot [string map {"more" "" "(view trailer)" "" } $plot]
        regsub -all {<[^\>]*>} $plot {} plot
        set plot [string trim $plot]
        set plot [htmlcodes $plot]
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG plot == $plot" }
    ## get iMDb rating
    if [regexp {<b>((\d.\d)/10)</b>.*?\(<a href="ratings">([\d,]+).*?votes</a>\)} $html dummy rating goldstars votes] {

        #rating bar code
        set goldstars [expr round($goldstars)]
        set greystars [expr 10 - $goldstars]
        # generating the rating bar
        set marker "*"
        set rating_bar "$barcol1\[$barcol2"
        for {set i2 0} {$i2 < $goldstars} {incr i2 1} {
            set rating_bar "$rating_bar$marker"
        }
        set marker "-"
        set rating_bar "$rating_bar14"
        for {set i3 0} {$i3 < $greystars} {incr i3 1} {
            set rating_bar "$rating_bar$marker"
        }
        set rating_bar "$rating_bar$barcol1\]"
        #end rating bar code

    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG rating == $rating | votes == $votes | rating bar == $rating_bar" }
    ## get TOP 250
    if [regexp {>(Top 250: #[\d]+)</a>} $html dummy top250] {
    } elseif [regexp {>(Bottom 100: #[\d]+)</a>} $html top250] {
    }

    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG top250 == $top250" }
    ## get MPAA
    if [regexp {<h5><a href="/mpaa">MPAA</a>:</h5> \n(.*?)\n} $html dummy mpaa] {
        regsub -all {<[^\>]*>} $mpaa {} mpaa
        #regsub {MPAA: } $mpaa {} mpaa
        set mpaa [htmlcodes $mpaa]
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG mpaa == $mpaa" }
    ## get runtime
    if [regexp {<h5>Runtime:</h5>\n.*?([\d]+).*?\n} $html dummy runtime] {
        regsub -all {[\n\s]+} $runtime {} runtime
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG runtime == $runtime" }
    ## get awards
    if [regexp {<h5>Awards:</h5> \n(.*?)\n<a} $html dummy awards] {
       set awards [string map {\n " "} $awards]
       set awards [string trim $awards]
       set awards [htmlcodes $awards]
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG awards == $awards" }
    ## get country
    if [regexp {<h5>Country:</h5>\n(.*?)\n} $html dummy country] {
        regsub -all {<[^\>]*>} $country {} country
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG country == $country" }
    ## get language
    if [regexp {<h5>Language:</h5>\n(.*?)\n} $html dummy language] {
        regsub -all {<[^\>]*>} $language {} language
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG language == $language" }
    ## get soundmix
    if [regexp {<h5>Sound Mix:</h5>\n(.*?)\n} $html dummy soundmix] {
        regsub -all {<[^\>]*>} $soundmix {} soundmix
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG soundmix == $soundmix" }
    ## get cast
    if [regexp {<table class="cast">(.*?)</table><a} $html dummy cast] {
        regsub -all {</tr><tr.*?>} $cast \n cast_multiline
        regsub -all {<[^\>]*>} $cast_multiline {} cast_multiline
        set cast_multiline [string map {"rest of cast listed alphabetically:" \n} $cast_multiline]
        set cast_multiline [string trim [htmlcodes $cast_multiline]]
        if { $cast_linelimit > 0 } {
           set nthoccur [expr [findnth $cast_multiline \n $cast_linelimit] - 1]
           if {$nthoccur > 0} {set cast_multiline [string range $cast_multiline 0 $nthoccur]}
        }
    }
    if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG cast_multiline == $cast_multiline" }


    # do we need the second page?

    if {[string match "*%budget*" $output] || [string match "*%screens*" $output]} {
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG page2 needed" }
        unset html
        if { $IMDB_ALTERNATIVE == 0 } {
           set page2 [::http::config -useragent "MSIE 6.0"]
           if [catch {set page2 [::http::geturl ${newurl}business -timeout $imdb_timeout]} error ] {
              puthelp "$toput :Error retrieving URL... try again later."
              ::http::Finish $page
              return
           }
           if {[::http::status $page2]=="timeout"} {
              puthelp "$toput :\002Connection to imdb.com timed out.\002"
              ::http::Finish $page2
              return
           }
           set html [::http::data $page2]
           ::http::Finish $page2
        } else {
          catch { exec $binary(CURL) "${newurl}business" } html
        }
        ## get budget
        if [regexp {<h5>Budget</h5>\n(.*?)<br/>} $html dummy budget] {
           set budget [string map {&#8364; € &#163; £ } $budget]
        }
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG budget == $budget" }
        ## get screens
        if [regexp {<h5>Opening Weekend</h5>\n(.*?Screens\))} $html dummy screens] {
           
           regsub -all {<[^\>]*>} $screens {} screens
           set screens [htmlcodes $screens]
        }
        if {$IMDB_DEBUG == 1} { putlog "IMDB_DEBUG screens == $screens" }
    }

    ## output results

    set output [replacevar $output "%title" $title]
    set output [replacevar $output "%url" $newurl]
    set output [replacevar $output "%name" $name]
    set output [replacevar $output "%genre" $genre]
    set output [replacevar $output "%tagline" $tagline]
    set output [replacevar $output "%plot" $plot]
    set output [replacevar $output "%rating" $rating]
    set output [replacevar $output "%rbar" $rating_bar]
    set output [replacevar $output "%votes" $votes]
    set output [replacevar $output "%top250" $top250]
    set output [replacevar $output "%mpaa" $mpaa]
    set output [replacevar $output "%time" $runtime]
    set output [replacevar $output "%awards" $awards]
    set output [replacevar $output "%country" $country]
    set output [replacevar $output "%language" $language]
    set output [replacevar $output "%soundmix" $soundmix]
    set output [replacevar $output "%budget" $budget]
    set output [replacevar $output "%screens" $screens]
    set checkvar ""
    regexp {.*?%castmline} $output checkvar
    if { [expr [regexp -all {%uline} $checkvar] % 2] == 1 } {
        set cast_multiline [string map {"\n" "\n%uline"} $cast_multiline]
    }
    if { [expr [regexp -all {%bold} $checkvar] % 2] == 1 } {
        set cast_multiline [string map {"\n" "\n%uline"} $cast_multiline]
    }
    if { [regexp {.*%color([\d]+(?:,[\d]+)?)[^\n]*?%castmline} $checkvar dummy colormline] } {
        regsub -all {\n} $cast_multiline "\n%color$colormline" cast_multiline
    }
    set output [replacevar $output "%castmline" $cast_multiline]
    set output [replacevar $output "%wcredits" $wcredits]
    regsub -all {\|[^\|]*?N/A[^\|]*?\|} $output "" output
    set output [string map {| ""} $output]
    regsub -all {\n[\n\s]*\n} $output "\n" output
    set output [string trim $output]
    set output [replacevar $output "%bold" "\002"]
    set output [replacevar $output "%color" "\003"]
    set output [replacevar $output "%uline" "\037"]
    foreach line [split $output "\n"] {
        puthelp "$toput :$line"
    }
}

proc decr_inst { } {
     global IMDB_DEBUG instance
     if { $instance > 0 } { incr instance -1 }
     if { $IMDB_DEBUG == 1 } { putlog "IMDB_DEBUG instance decreased by timer to: $instance" }
}

proc wmsg { } {
     global warn_msg
     set warn_msg 0
}
putlog "IMDB info version 28.02.2007 loaded"
