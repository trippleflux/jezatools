/***************************/
/*  OUTPUT CLiENT          */ 
/***************************/
#define iojZS_header
	%v=script version
	
#define iojZS_skip_file
#define iojZS_ok_file
#define iojZS_bad_file
	%f=filename
	
#define iojZS_delete_reason
	%s=reason 	-> replaced with iojZS_delete_xxx
	 |------#define iojZS_delete_sfv_reason
	 |------#define iojZS_delete_crc_reason
	 |------#define iojZS_delete_not_in_sfv_reason
	 |------#define iojZS_delete_no_sfv_reason
	 |------#define iojZS_delete_o_byte
	 |------#define iojZS_delete_miss_ext
	 |------#define iojZS_delete_speed_test
		
#define iojZS_mp3_header
	none
	
#define iojZS_stats_id3
	%A=artist
	%S=album
	%D=title
	%Q=comment
	%E=track number
	%X=genre
	%Y=year
	
#define iojZS_user_header
	none
	
#define iojZS_stats_users
	%p=pos
	%u=username
	%r=group
	%w=username@group
	%f=files upped
	%m=MB uspped
	%s=average speed
	%P=percent
	
#define iojZS_group_header
	none
	
#define iojZS_stats_groups
	%p=pos
	%g=groupname
	%c=files upped
	%b=MB uspped
	%q=average speed
	%Q=percent
	
#define iojZS_progressmeter_footer
	%b=progress meter
	%p=total upped
	%t=total files expected
	
#define iojZS_footer
	none


#define iojZS_rescan_head
	%v=script version
	
#define iojZS_rescan_file_not_there
	%s=file.rar		(site rescan file.rar)
	
#define iojZS_rescan_body
	%F=file
	%I=rescan crc
	%K=original crc
	%V=OK,MISSING,FAIL
	
#define iojZS_rescan_total
	%t=total files
	%O=OK files
	%H=failed
	%m=missing 
	%e=size

#define iojZS_rescan_id3
	%A=artist
	%S=album
	%D=title
	%Q=comment
	%E=track number
	%X=genre
	%Y=year

/***************************/
/*  .ioFTPD.message        */ 
/***************************/
#define iojZS_msg_head_users
	%R=release
	%e=rls size
	%t=total files
	%J=average speed
	%N=race time

#define iojZS_msg_users
	%p=pos
	%u=username
	%r=group
	%w=username@group
	%f=files upped
	%m=MB uspped
	%s=average speed
	%P=percent

#define iojZS_msg_head_groups
	none
	
#define iojZS_msg_groups
	%p=pos
	%g=groupname
	%c=files upped
	%b=MB uspped
	%q=average speed
	%Q=percent
	
#define iojZS_msg_foot
	none
	
/***************************/
/*  BARS                   */ 
/***************************/
#define iojZS_incomplete_link
	%r=release

#define iojZS_incomplete_link_cd
	%d=parent dir
	%c=release

#define iojZS_incmpl_bar
	%b=progress meter
	%k=upped files
	%t=total files
	%m=missing files
	%p=percent complete
	%%=%

#define iojZS_cmpl_bar
	%t=total files
	%e=total bytes

#define iojZS_mp3_incmpl_bar
	%b=progress meter
	%k=upped files
	%t=total files
	%m=missing files
	%p=percent complete
	%%=%
	%A=artist
	%S=album
	%D=title
	%Q=comment
	%E=track number
	%X=genre
	%Y=year

#define iojZS_mp3_cmpl_bar
	%t=total files
	%e=total bytes
	%A=artist
	%S=album
	%D=title
	%Q=comment
	%E=track number
	%X=genre
	%Y=year

/***************************/
/*  SCRiPT                 */ 
/***************************/
#define iojZS_on_rls_complete
	%a=path
	%f=virtualpath
	%h=release
	
/***************************/
/*  OUTPUT iRC             */
/***************************/
#define iojZS_irc_speedtest
	%B=bold
	%U=underline
	%C=color
	%u=username
	%g=groupname
	%s=speed

#define iojZS_irc_sfv
	%B=bold
	%U=underline
	%C=color
	%u=username
	%g=groupname
	%t=total files
	%p=total upped
	%m=missing files
	%R=release

#define iojZS_irc_update
	%B=bold
	%U=underline
	%C=color
	%u=username
	%g=groupname
	%t=total files
	%p=total upped
	%m=missing files
	%R=release
	%z=expected MBs

#define iojZS_irc_mp3_update
	%B=bold
	%U=underline
	%C=color
	%u=username
	%g=groupname
	%t=total files
	%p=total upped
	%m=missing files
	%R=release
	%z=expected MBs
	%A=artist
	%S=album
	%D=title
	%Q=comment
	%E=track number
	%X=genre
	%Y=year
	
#define iojZS_irc_users_race
	%B=bold
	%U=underline
	%C=color
	%u=username
	%r=group

#define iojZS_irc_race
	%B=bold
	%U=underline
	%C=color
	%R=release
	%u=username
	%r=group
	%w=username@group
	%o=iojZS_irc_users_race

#define iojZS_irc_halfway
	%B=bold
	%U=underline
	%C=color
	%R=release
	//best user stats
	%u=username
	%r=group
	%w=username@group
	%f=files upped
	%m=MB uspped
	%s=average speed
	%P=percent
	//best group stats
	%g=groupname
	%c=files upped
	%b=MB uspped
	%q=average speed
	%Q=percent

#define iojZS_irc_complete
	%B=bold
	%U=underline
	%C=color
	%t=total files
	%p=total upped
	%m=missing files
	%R=release
	%e=total bytess
	%J=total avg speed
	%M=race time formated
	%L=race time in seconds
	%n=total users in race
	%o=total groups in race
	%i=fastest user
	%j=fastest speed
	%k=slowest user
	%l=slowest speed

#define iojZS_irc_no_race_complete
	%B=bold
	%U=underline
	%C=color
	%p=pos
	%u=username
	%r=group
	%w=username@group
	%f=files upped
	%m=MB uspped
	%s=average speed
	%P=percent
	%R=release
	%M=race time formated
	%L=race time in seconds
	%d=total users in race
	%e=total groups in race
	%i=fastest user
	%j=fastest speed
	%k=slowest user
	%l=slowest speed
	
#define iojZS_irc_user_head
	%B=bold
	%U=underline
	%C=color

#define iojZS_irc_user_stats
	%B=bold
	%U=underline
	%C=color
	%p=pos
	%u=username
	%r=group
	%w=username@group
	%f=files upped
	%m=MB uspped
	%s=average speed
	%P=percent
	%R=release

#define iojZS_irc_group_head
	%B=bold
	%U=underline
	%C=color

#define iojZS_irc_group_stats
	%B=bold
	%U=underline
	%C=color
	%p=pos
	%g=groupname
	%c=files upped
	%b=MB uspped
	%q=average speed
	%Q=percent
	%R=release





