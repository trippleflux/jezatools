/***************************/
/*  COMPiLE WHAT           */ 
/***************************/
#define jScripts_normal_version					FALSE
#define jScripts_public_version					TRUE
/***************************/
/*  DEFAULT                */ 
/***************************/
#define jScripts_default_version				"1.1.1.1"
#define jScripts_default_message_window			"ioFTPD::MessageWindow"
#define jScripts_default_allowed_comp_list		"JEZACOMP"
#define jScripts_default_timebomb				"2007/12/20 00:00:00"		//yyyy/mm/dd HH:MM:SS
#define jScripts_default_flags					"3"
#define jScripts_default_user					"nobody"
#define jScripts_default_group					"NoGroup"
#define jScripts_default_tagline				"I.SUCK!"
#define jScripts_default_uid					0
#define jScripts_default_gid					1
#define jScripts_default_info					"jS $script_version$ by Jeza (C) 2006"

#if ( jScripts_normal_version )

	#define jScripts_default_file_name_debug		"E:\\server\\ioFTPD\\scripts\\jScripts\\jScripts.debug"
	#define jScripts_default_file_name_actions		"E:\\server\\ioFTPD\\scripts\\jScripts\\jScripts.actions"
	#define jScripts_default_log_file				"E:\\server\\ioFTPD\\logs\\jScripts.log"
	#define jScripts_default_sysop_file				"E:\\server\\ioFTPD\\logs\\SysOp.log"
	#define jScripts_default_user_files				"E:\\server\\ioFTPD\\users\\"
	#define jScripts_default_user_db				"E:\\server\\ioFTPD\\scripts\\jScripts\\jScripts.user.db"
	#define jScripts_default_ban_db					"E:\\server\\ioFTPD\\scripts\\jScripts\\jScripts.ban.db"
	#define jScripts_default_dupe_dir_db			"E:\\server\\ioFTPD\\scripts\\jScripts\\jScripts.dupe.dir.db"
	#define jScripts_default_dupe_file_db			"E:\\server\\ioFTPD\\scripts\\jScripts\\jScripts.dupe.file.db"

#else

	#define jScripts_default_file_name_debug		"C:\\ioFTPD\\system\\jScripts.debug"
	#define jScripts_default_file_name_actions		"C:\\ioFTPD\\system\\jScripts.actions"
	#define jScripts_default_log_file				"C:\\ioFTPD\\logs\\jScripts.log"
	#define jScripts_default_sysop_file				"C:\\ioFTPD\\logs\\SysOp.log"
	#define jScripts_default_user_files				"C:\\ioFTPD\\users\\"
	#define jScripts_default_user_db				"C:\\ioFTPD\\system\\jScripts.user.db"
	#define jScripts_default_ban_db					"C:\\ioFTPD\\system\\jScripts.ban.db"
	#define jScripts_default_dupe_dir_db			"C:\\ioFTPD\\system\\jScripts.dupe.dir.db"
	#define jScripts_default_dupe_file_db			"C:\\ioFTPD\\system\\jScripts.dupe.file.db"

#endif

/***************************/
/*  USER                   */ 
/***************************/

#if ( jScripts_normal_version )

	#define jScripts_user_power_users				"Jeza j3su5"
	#define jScripts_user_power_groups				"SiTEOPS"
	#define jScripts_user_power_flags				"1V"
	#define jScripts_user_number_of_sections		3
	char *jScripts_user_section[3]					= { "ISO", "MP3", "DiVX" };

#else

	#define jScripts_user_power_users				"Jeza j3su5"
	#define jScripts_user_power_groups				"SiTEOPS"
	#define jScripts_user_power_flags				"1V"
	#define jScripts_user_number_of_sections		6
	char *jScripts_user_section[6]					= { "ISO", "MP3", "DiVX", "XXX", "GAMES", "GAY" };

#endif

#define jScripts_site_user_notfound				" \n User '$user_login$' Not Found \n\n"
#define jScripts_site_user_failed				" Command Failed! \n"
#define jScripts_site_user_not_allowed			" SITE USER '$user_login$': Permission denied. \n"
#define jScripts_site_user_help					" \n SITE USER UserName \n\n"
/***************************/
/*  WHO                    */ 
/***************************/
#if ( jScripts_normal_version )

	#define jScripts_who_power_users				"Jeza j3su5"
	#define jScripts_who_power_groups				"SiTEOPS"
	#define jScripts_who_power_flags				"1V"
	#define jScripts_who_hide_users					"ioFTPD sitebot"
	#define jScripts_who_hide_groups				"ioftpd"
	#define jScripts_who_hide_path					"/.groups/ /groups/ /private/ /0day/.pre/ /appz/.pre/ /bookware/.pre/ /covers/.pre/ /divx/.pre/ /dox/.pre/ /dvdr/.pre/ /ebook/.pre/ /games/.pre/ /mp3/.pre/ /pda/.pre/ /series/.pre/ /utils/.pre/ /vcd/.pre/ /xxx/.pre/"

#else

	#define jScripts_who_power_users				"Jeza j3su5"
	#define jScripts_who_power_groups				"SiTEOPS"
	#define jScripts_who_power_flags				"1V"
	#define jScripts_who_hide_users					"ioFTPD sitebot"
	#define jScripts_who_hide_groups				"ioftpd"
	#define jScripts_who_hide_path					"/private/"

#endif

#define jScripts_jwho_head						"-----------------------------------------------------------------------------------------------\n"
#define jScripts_jwho_body_normal_idle			" $15who_username$ | IDLE    | $who_idle_time$ | $-10.10who_action$ | $who_virtualpath$ \n"
#define jScripts_jwho_body_normal_up			" $15who_username$ |      UP | $6who_user_speed$ k | $10who_bytes_transfered$ | $who_virtualdatapath$ \n"
#define jScripts_jwho_body_normal_dn			" $15who_username$ |      DN | $6who_user_speed$ k | $10who_bytes_transfered$ | $who_virtualdatapath$ \n"
#define jScripts_jwho_body_normal_list			" $15who_username$ | LIST    | $who_idle_time$ | $-10.10who_action$ | $who_virtualpath$ \n"
#define jScripts_jwho_body_power_idle			" $15who_username$ | $-15who_groupname$ | IDLE    | $who_idle_time$ | $-10.10who_action$ | $who_virtualpath$ \n"
#define jScripts_jwho_body_power_up				" $15who_username$ | $-15who_groupname$ |      UP | $6who_user_speed$ k | $10who_bytes_transfered$ | $who_virtualdatapath$ \n"
#define jScripts_jwho_body_power_dn				" $15who_username$ | $-15who_groupname$ |      DN | $6who_user_speed$ k | $10who_bytes_transfered$ | $who_virtualdatapath$ \n"
#define jScripts_jwho_body_power_list			" $15who_username$ | $-15who_groupname$ | LIST    | $who_idle_time$ | $-10.10who_action$ | $who_virtualpath$ \n"
#define jScripts_jwho_foot						"-----------------------------------------------------------------------------------------------\n" \
												" Idlers..........| $7who_idle_count$ | \n" \
												" Uploaders.......| $7who_up_count$ | $8who_up_total_speed$ kBps \n" \
												" Downloaders.....| $7who_dn_count$ | $8who_dn_total_speed$ kBps \n" \
												" Total...........| $7who_total_count$ | $8who_total_speed$ kBps \n" \
												"------------------------------------------------------------=[ jS $script_version$ by Jeza (C) 2006 ]=--\n"
#define jScripts_bot_bw							"{$who_up_total_speed$} {$who_up_count$} {$who_dn_total_speed$} {$who_dn_count$} {$who_idle_count$} {$who_total_speed$} {$who_total_count$}\n"
#define jScripts_bot_who_head					"-----------------------------------------------------------------\n"
#define jScripts_bot_who_body_normal_idle		" $15who_username$ | IDLE    | $who_idle_time$ | $-10.10who_action$ | $who_virtualpath$ \n"
#define jScripts_bot_who_body_normal_up			" $15who_username$ |      UP | $6who_user_speed$ k | $10who_bytes_transfered$ | $who_action$ \n"
#define jScripts_bot_who_body_normal_dn			" $15who_username$ |      DN | $6who_user_speed$ k | $10who_bytes_transfered$ | $who_action$ \n"
#define jScripts_bot_who_body_normal_list		" $15who_username$ | LIST    | $who_idle_time$ | $-10.10who_action$ | $who_virtualpath$ \n"
#define jScripts_bot_who_foot					"-----------------------------------------------------------------\n" \
												" UP: $3who_up_count$@$-5who_up_total_speed$ kBps | DN: $3who_dn_count$@$-5who_dn_total_speed$ kBps | TOTAL: $3who_total_count$@$-5who_total_speed$ kBps \n" \
												"------------------------------=[ jS $script_version$ by Jeza (C) 2006 ]=--\n"

#define jScripts_bot_idle_users					"{$who_username$} {$who_groupname$} {$who_idle_time$} {$who_login_time$}\n"
#define jScripts_bot_idle_none					"no\n"
#define jScripts_bot_up_users					"{$who_username$} {$who_groupname$} {$who_file_name$} {$who_user_speed$}\n"
#define jScripts_bot_up_none					"no\n"
#define jScripts_bot_dn_users					"{$who_username$} {$who_groupname$} {$who_file_name$} {$who_user_speed$} {$who_bytes_transfered$} {$who_file_size$} {$who_percent_done$}\n"
#define jScripts_bot_dn_none					"no\n"
#define jScripts_bot_speed_not_online			"is not online\n"
#define jScripts_bot_speed_idle					"{$who_username$} {$who_groupname$} {idle} {$who_idle_time$} {$who_login_time$}\n"
#define jScripts_bot_speed_up					"{$who_username$} {$who_groupname$} {uploading} {$who_file_name$} {$who_user_speed$}\n"
#define jScripts_bot_speed_dn					"{$who_username$} {$who_groupname$} {downloading} {$who_file_name$} {$who_user_speed$}\n"
/***************************/
/*  GSTATS                 */ 
/***************************/
#define jScripts_gstats_default_sections		0
#define jScripts_gstats_default_count			5
#define jScripts_gstats_out_head				" --=[ Top $02gstats_count$ $5.5gstats_name$ Groups in Section $gstats_section$ ]=-------------------\n"
#define jScripts_gstats_out_body_allup			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_allup$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_body_alldn			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_alldn$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_body_mnup			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_mnup$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_body_mndn			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_mndn$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_body_wkup			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_wkup$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_body_wkdn			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_wkdn$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_body_dayup			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_dayup$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_body_daydn			" ' $04gstats_position$ ' $-15.15gstats_groupname$ ' $11.11gstats_daydn$ ' $10TotalUsersInGroup$ Users '\n"
#define jScripts_gstats_out_foot				" -----------------------=[ jS $script_version$ by Jeza (C) 2006 ]=--\n"
/***************************/
/*  BGSTATS                */ 
/***************************/
//$bgstats_allup$ = stats / 1024
#define jScripts_bgstats_default_sections		0
#define jScripts_bgstats_default_count			3
#define jScripts_bgstats_out_body_allup			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_allup$} {$gstats_allupf$} {$gstats_allups$} \n"
#define jScripts_bgstats_out_body_alldn			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_alldn$} {$gstats_alldnf$} {$gstats_alldns$} \n"
#define jScripts_bgstats_out_body_mnup			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_mnup$} {$gstats_mnupf$} {$gstats_mnups$} \n"
#define jScripts_bgstats_out_body_mndn			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_mndn$} {$gstats_mndnf$} {$gstats_mndns$} \n"
#define jScripts_bgstats_out_body_wkup			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_wkup$} {$gstats_wkupf$} {$gstats_wkups$} \n"
#define jScripts_bgstats_out_body_wkdn			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_wkdn$} {$gstats_wkdnf$} {$gstats_wkdns$} \n"
#define jScripts_bgstats_out_body_dayup			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_dayup$} {$gstats_dayupf$} {$gstats_dayups$} \n"
#define jScripts_bgstats_out_body_daydn			"{$gstats_position$} {$ustats_groupname$} {$TotalUsersInGroup$} {$bgstats_daydn$} {$gstats_daydnf$} {$gstats_daydns$} \n"
/***************************/
/*  USTATS                 */ 
/***************************/
#define jScripts_ustats_default_sections		0
#define jScripts_ustats_default_count			5
#define jScripts_ustats_out_head				" --=[ Top $02ustats_count$ $5.5ustats_name$ Users in Section $ustats_section$ ]=-------------------\n"
#define jScripts_ustats_out_body_allup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_allup$ '\n"
#define jScripts_ustats_out_body_alldn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_alldn$ '\n"
#define jScripts_ustats_out_body_mnup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_mnup$ '\n"
#define jScripts_ustats_out_body_mndn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_mndn$ '\n"
#define jScripts_ustats_out_body_wkup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_wkup$ '\n"
#define jScripts_ustats_out_body_wkdn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_wkdn$ '\n"
#define jScripts_ustats_out_body_dayup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_dayup$ '\n"
#define jScripts_ustats_out_body_daydn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_daydn$ '\n"
/*
#define jScripts_ustats_out_body_allup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_allup$ ' $11ustats_allupf$ F ' $11ustats_allups$ kB/s ' \n"
#define jScripts_ustats_out_body_alldn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_alldn$ ' $11ustats_alldnf$ F ' $11ustats_alldns$ kB/s ' \n"
#define jScripts_ustats_out_body_mnup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_mnup$ ' $11ustats_mnupf$ F ' $11ustats_mnups$ kB/s ' \n"
#define jScripts_ustats_out_body_mndn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_mndn$ ' $11ustats_mndnf$ F ' $11ustats_mndns$ kB/s ' \n"
#define jScripts_ustats_out_body_wkup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_wkup$ ' $11ustats_wkupf$ F ' $11ustats_wkups$ kB/s ' \n"
#define jScripts_ustats_out_body_wkdn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_wkdn$ ' $11ustats_wkdnf$ F ' $11ustats_wkdns$ kB/s ' \n"
#define jScripts_ustats_out_body_dayup			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_dayup$ ' $11ustats_dayupf$ F ' $11ustats_dayups$ kB/s ' \n"
#define jScripts_ustats_out_body_daydn			" ' $04ustats_position$ ' $15.15ustats_username$ ' $-15.15ustats_groupname$ ' $11.11ustats_daydn$ ' $11ustats_daydnf$ F ' $11ustats_daydns$ kB/s ' \n"
*/
#define jScripts_ustats_out_foot				" -----------------------=[ jS $script_version$ by Jeza (C) 2006 ]=--\n"
/***************************/
/*  GETUSERPOSANDSTATS     */ 
/***************************/
#define jScripts_uposstats_default_section		0
#define jScripts_uposstats_out_body_complete	"{{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$ustats_credits$} {$ustats_timeadded$} {$ustats_lastseen$} {$bustats_pos_allup$} {$bustats_allup$} {$bustats_pos_alldn$} {$bustats_alldn$} {$bustats_pos_mnup$} {$bustats_mnup$} {$bustats_pos_mndn$} {$bustats_mndn$} {$bustats_pos_wkup$} {$bustats_wkup$} {$bustats_pos_wkdn$} {$bustats_wkdn$} {$bustats_pos_dayup$} {$bustats_dayup$} {$bustats_pos_daydn$} {$bustats_daydn$}}"
#define jScripts_uposstats_all_complete			"{{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$ustats_credits$} {$ustats_timeadded$} {$bustats_pos_allup$} {$bustats_allup$} {$bustats_pos_alldn$} {$bustats_alldn$} {$bustats_pos_mnup$} {$bustats_mnup$} {$bustats_pos_mndn$} {$bustats_mndn$} {$bustats_pos_wkup$} {$bustats_wkup$} {$bustats_pos_wkdn$} {$bustats_wkdn$} {$bustats_pos_dayup$} {$bustats_dayup$} {$bustats_pos_daydn$} {$bustats_daydn$}} \n"
/***************************/
/*  GETGROUPPOSANDSTATS    */ 
/***************************/
#define jScripts_gposstats_default_section		0
#define jScripts_gposstats_out_body_complete	"{{$gstats_groupname$} {$TotalUsersInGroup$} {$bgstats_pos_allup$} {$bgstats_allup$} {$bgstats_pos_alldn$} {$bgstats_alldn$} {$bgstats_pos_mnup$} {$bgstats_mnup$} {$bgstats_pos_mndn$} {$bgstats_mndn$} {$bgstats_pos_wkup$} {$bgstats_wkup$} {$bgstats_pos_wkdn$} {$bgstats_wkdn$} {$bgstats_pos_dayup$} {$bgstats_dayup$} {$bgstats_pos_daydn$} {$bgstats_daydn$}}"
#define jScripts_gposstats_all_complete			"{{$gstats_groupname$} {$TotalUsersInGroup$} {$bgstats_pos_allup$} {$bgstats_allup$} {$bgstats_pos_alldn$} {$bgstats_alldn$} {$bgstats_pos_mnup$} {$bgstats_mnup$} {$bgstats_pos_mndn$} {$bgstats_mndn$} {$bgstats_pos_wkup$} {$bgstats_wkup$} {$bgstats_pos_wkdn$} {$bgstats_wkdn$} {$bgstats_pos_dayup$} {$bgstats_dayup$} {$bgstats_pos_daydn$} {$bgstats_daydn$}} \n"
/***************************/
/*  BUSTATS                */ 
/***************************/
//$bustats_allup$ = stats / 1024
#define jScripts_bustats_default_sections		0
#define jScripts_bustats_default_count			3
#define jScripts_bustats_out_body_allup			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_allup$} {$ustats_allupf$} {$ustats_allups$} \n"
#define jScripts_bustats_out_body_alldn			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_alldn$} {$ustats_alldnf$} {$ustats_alldns$} \n"
#define jScripts_bustats_out_body_mnup			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_mnup$} {$ustats_mnupf$} {$ustats_mnups$} \n"
#define jScripts_bustats_out_body_mndn			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_mndn$} {$ustats_mndnf$} {$ustats_mndns$} \n"
#define jScripts_bustats_out_body_wkup			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_wkup$} {$ustats_wkupf$} {$ustats_wkups$} \n"
#define jScripts_bustats_out_body_wkdn			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_wkdn$} {$ustats_wkdnf$} {$ustats_wkdns$} \n"
#define jScripts_bustats_out_body_dayup			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_dayup$} {$ustats_dayupf$} {$ustats_dayups$} \n"
#define jScripts_bustats_out_body_daydn			"{$ustats_position$} {$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_daydn$} {$ustats_daydnf$} {$ustats_daydns$} \n"
#define jScripts_bustats_out_body_complete		"{{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$ustats_timeadded$} {$ustats_credits$} {$bustats_dayup$} {$bustats_daydn$} {$bustats_wkup$} {$bustats_wkdn$} {$bustats_mnup$} {$bustats_mndn$} {$bustats_allup$} {$bustats_alldn$}} \n"
#define jScripts_bustats_out_body_quota			"{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$ustats_timeadded$} {$bustats_dayup$} {$bustats_daydn$} {$bustats_wkup$} {$bustats_wkdn$} {$bustats_mnup$} {$bustats_mndn$} {$bustats_allup$} {$bustats_alldn$} \n"
//#define jScripts_bustats_out_body_day_stats		"{{$ustats_username$} {$ustats_groupname$} {$ustats_flags$} {$bustats_dayup$} {$bustats_daydn$} {$bustats_wkup$} {$bustats_wkdn$} {$bustats_mnup$} {$bustats_mndn$} {$bustats_allup$} {$bustats_alldn$}} \n"
/***************************/
/*  iNViTE                 */ 
/***************************/
#define jScripts_site_invite_ircnick			" \n Inviting '$env_username$' As '$irc_username$' \n\n"
#define jScripts_site_invite_help				" \n SITE INVITE IRCNICK \n\n"
/***************************/
/*  ADD/DEL MASTER         */ 
/***************************/
#define jScripts_site_addmaster_success			" \n Added 'M' Flag To '$master_login$' \n\n"
#define jScripts_site_addmaster_failed			" \n Adding 'M' Flag To '$master_login$' Failed!\n\n"
#define jScripts_site_addmaster_notfound		" \n User '$master_login$' Not Found \n\n"
#define jScripts_site_addmaster_help			" \n SITE ADDMASTER UserName \n\n"
#define jScripts_site_delmaster_success			" \n Removed 'M' Flag From '$master_login$' \n\n"
#define jScripts_site_delmaster_failed			" \n Removing 'M' Flag From '$master_login$' Failed!\n\n"
#define jScripts_site_delmaster_notfound		" \n User '$master_login$' Not Found \n\n"
#define jScripts_site_delmaster_help			" \n SITE DELMASTER UserName \n\n"
/***************************/
/*  BAN                    */ 
/***************************/
#define jScripts_site_ban_list_head				"----------------------------------------------------------------\n"
#define jScripts_site_ban_add					" IP '$ban_ip$' Is Now BANNED!\n"
#define jScripts_site_ban_del					" IP '$ban_ip$' Is Now UNBANNED!\n"
#define jScripts_site_ban_notfound				" IP '$ban_ip$' Is Not BANNED!\n"
#define jScripts_site_ban_msg					"530 Your IP Is BANNED!\n"
#define jScripts_site_ban_list_foot				"-----------------------------=[ jS $script_version$ by Jeza (C) 2006 ]=--\n"
/***************************/
/*  DATE ADDED             */ 
/***************************/
#define jScripts_site_writedate_success			" Create Dates File Was Updated Successful \n"
#define jScripts_site_writedate_failed			" Update Of Create Dates File Failed \n"
/***************************/
/*  SHOW                   */ 
/***************************/
#define jScripts_site_show_notfound				" User '$show_login$' Not Found \n\n"
#define jScripts_site_show_failed				" Command Failed! \n"
#define jScripts_site_show_help					" \n SITE SHOW UserName \n\n"
/***************************/
/*  ERROR MESSAGES         */ 
/***************************/
#define jScripts_error_msg_head					"----------------------------------------------------------------\n"
#define jScripts_error_msg_sysoplog_not_open	" Cant Open 'SysOp.log'. Try Again Later.                        \n"
#define jScripts_error_msg_foot					"-----------------------------=[ jS $script_version$ by Jeza (C) 2006 ]=--\n"
/***************************/
/*  CREDiTS                */ 
/***************************/
#define jScripts_credits_all					"{%I64d}\n"
/***************************/
/*  DUPE                   */ 
/***************************/
#define jScripts_dupe_newdir_skip				"/test/ /groups/ /private/ /request/ /_ioFTPD/ /0day/.pre/ /appz/.pre/ /bookware/.pre/ /covers/.pre/ /divx/.pre/ /dox/.pre/ /dvdr/.pre/ /ebook/.pre/ /games/.pre/ /mp3/.pre/ /pda/.pre/ /series/.pre/ /utils/.pre/ /vcd/.pre/ /xxx/.pre/"
#define jScripts_dupe_release_skip				"a aa aaa asd qwe cd covers czsub disk disc dvd extra s0 sample season sub vobsub"
#define jScripts_dupe_newdir_msg				" This Dir Looks Like A Dupe! It Was Created By '$dupeuser$' On '$dupedate$'\n"
#define jScripts_dupe_show_head					"\n"
#define jScripts_dupe_show_msg					" $dupedate$ $dupepwd$\n"
#define jScripts_dupe_show_foot					"\n Found $dupefoundcount$ Matches Out Of $dupetotalcount$ Total Dupes In DB\n"
#define jScripts_undupe_ok_msg					" '$duperls$' Successful Unduped\n"
#define jScripts_undupe_fail_msg				" '$duperls$' Not Found!\n"
#define jScripts_dupe_max_show					25
/***************************/
/*  ENABLE/DiSABLE         */ 
/***************************/
#if ( jScripts_public_version )

#define jScripts_enable_allowed_check			FALSE		//
#define jScripts_enable_compname_check			FALSE
#define jScripts_enable_timebomb_check			FALSE
#define jScripts_enable_client_debug			FALSE		//write debug info to client
#define jScripts_enable_file_debug				FALSE		//write debug info to jScripts_default_file_name_debug
#define jScripts_enable_file_actions_debug		TRUE		//write debug info to jScripts_default_file_name_actions (deleteuser, changecredits, ...)
#define jScripts_enable_log_to_jScripts			FALSE		//write race log to jScripts.log
#define jScripts_enable_log_to_ioFTPD			TRUE		//write race log to ioFTPD.log
#define jScripts_enable_who						TRUE		//enable WHO
#define jScripts_enable_ustats					TRUE		//site stats ...
#define jScripts_enable_invite					TRUE		//site invite
#define jScripts_enable_ban						TRUE		//site ban
#define jScripts_enable_bustats					TRUE		//site stats for bot
#define jScripts_enable_complete_bustats		TRUE		//site stats for trial/quota
#define jScripts_enable_quota_bustats			TRUE		//site stats for trial/quota
#define jScripts_enable_master					TRUE		//add/del master
#define jScripts_enable_site_show				TRUE		//site show user - NOT READY YET
#define jScripts_enable_site_user				TRUE		//site show user
#define jScripts_enable_site_nfo				TRUE		//site nfo
#define jSCripts_enable_sql						TRUE		//use sqlite.dll
#define jScripts_enable_logincount				TRUE		//enable login count and last login 
#define jScripts_enable_ftplogin				TRUE		//OnFtpLogIn
#define jSCripts_enable_adduser					TRUE		//gadduser, adduser write date added,...
#define jScripts_enable_deleteuser				TRUE		//delete user
#define jScripts_enable_addflag					TRUE		//add a flag
#define jScripts_enable_delflag					TRUE		//del a flag
#define jScripts_enable_changegroup				TRUE		//change default group
#define jScripts_enable_addtrialtolog			TRUE		//adds a line to sysop.log
#define jScripts_enable_dupe_dir				TRUE		//dir dupe
#define jScripts_enable_change_credits			TRUE		//change credits
#define jScripts_enable_disk_space				TRUE		//enable free space
#define jScripts_enable_day_stats				TRUE		//enable day stats
#define jScripts_enable_get_user_stats			TRUE		//enable get user stats
#define jScripts_enable_change_number_of_users	TRUE		//change number of users in group
#define jScripts_enable_sql_index				TRUE		//create index on tables
#define jScripts_enable_help					TRUE		//show help
#define jScripts_enable_version					TRUE		//show version
#define jScripts_enable_get_user_rank			TRUE		//users rank
#define jScripts_enable_gstats					TRUE		//site group stats ...
#define jScripts_enable_credits_all				TRUE		//show all credits
#define jscripts_enable_posandstats				TRUE		//POSANDSTATS
#define jscripts_enable_allposandstats			TRUE		//ALLPOSANDSTATS
#define jscripts_enable_gposandstats			TRUE		//GPOSANDSTATS
#define jscripts_enable_gallposandstats			TRUE		//GALLPOSANDSTATS
#define jscripts_enable_addtestuser				TRUE		//adds some users to ioftpd
#define jScripts_enable_reqstats				TRUE		//how many requests user have in month
#define jScripts_enable_bgstats					TRUE		//group stats for bot

#else

#define jScripts_enable_allowed_check			FALSE		//
#define jScripts_enable_compname_check			FALSE
#define jScripts_enable_timebomb_check			FALSE
#define jScripts_enable_client_debug			FALSE		//write debug info to client
#define jScripts_enable_file_debug				TRUE		//write debug info to jScripts_default_file_name_debug
#define jScripts_enable_file_actions_debug		TRUE		//write debug info to jScripts_default_file_name_actions (deleteuser, changecredits, ...)
#define jScripts_enable_log_to_jScripts			TRUE		//write race log to jScripts.log
#define jScripts_enable_log_to_ioFTPD			TRUE		//write race log to ioFTPD.log
#define jScripts_enable_who						TRUE		//enable WHO
#define jScripts_enable_ustats					TRUE		//site stats ...
#define jScripts_enable_invite					FALSE		//site invite
#define jScripts_enable_ban						TRUE		//site ban
#define jScripts_enable_bustats					TRUE		//site stats for bot
#define jScripts_enable_complete_bustats		TRUE		//site stats for trial/quota
#define jScripts_enable_quota_bustats			TRUE		//site stats for trial/quota
#define jScripts_enable_master					TRUE		//add/del master
#define jScripts_enable_site_show				FALSE		//site show user - NOT READY YET
#define jScripts_enable_site_user				TRUE		//site show user
#define jScripts_enable_site_nfo				TRUE		//site nfo
#define jSCripts_enable_sql						TRUE		//use sqlite.dll
#define jScripts_enable_logincount				TRUE		//enable login count and last login 
#define jScripts_enable_ftplogin				TRUE		//OnFtpLogIn
#define jSCripts_enable_adduser					TRUE		//gadduser, adduser write date added,...
#define jScripts_enable_deleteuser				TRUE		//delete user
#define jScripts_enable_addflag					TRUE		//add a flag
#define jScripts_enable_delflag					TRUE		//del a flag
#define jScripts_enable_changegroup				TRUE		//change default group
#define jScripts_enable_addtrialtolog			TRUE		//adds a line to sysop.log
#define jScripts_enable_dupe_dir				TRUE		//dir dupe
#define jScripts_enable_change_credits			TRUE		//change credits
#define jScripts_enable_disk_space				TRUE		//enable free space
#define jScripts_enable_day_stats				TRUE		//enable day stats
#define jScripts_enable_get_user_stats			TRUE		//enable get user stats
#define jScripts_enable_change_number_of_users	TRUE		//change number of users in group
#define jScripts_enable_sql_index				TRUE		//create index on tables
#define jScripts_enable_help					TRUE		//show help
#define jScripts_enable_version					TRUE		//show version
#define jScripts_enable_get_user_rank			TRUE		//users rank
#define jScripts_enable_gstats					TRUE		//site group stats ...
#define jScripts_enable_credits_all				TRUE		//show all credits
#define jscripts_enable_posandstats				TRUE		//POSANDSTATS
#define jscripts_enable_allposandstats			TRUE		//ALLPOSANDSTATS
#define jscripts_enable_gposandstats			TRUE		//GPOSANDSTATS
#define jscripts_enable_gallposandstats			TRUE		//GALLPOSANDSTATS
#define jscripts_enable_addtestuser				TRUE		//adds some users to ioftpd
#define jScripts_enable_reqstats				TRUE		//how many requests user have in month
#define jScripts_enable_bgstats					TRUE		//group stats for bot

#endif

/***************************/
/*  LOG                    */ 
/***************************/
#define jScripts_mirc_anounce_invite			"INVITE: \"$env_username$\" \"$env_groupname$\" \"$irc_username$\"\n"

#define jScripts_syslog_add_group				"'jScripts' added user '%s' to group '%s'."
#define jScripts_syslog_del_group				"'jScripts' removed user '%s' from group '%s'."
#define jScripts_syslog_add_user				"'jScripts' created user '%s' in group '%s'."
#define jScripts_syslog_del_user				"'jScripts' deleted user '%s'."
#define jScripts_syslog_change_credits			"'jScripts' changed credits for user '%s' (%s kB) in section '%i'."
#define jScripts_syslog_add_flag				"'jScripts' added flag '%s' to user '%s'."
#define jScripts_syslog_del_flag				"'jScripts' removed flag '%s' from user '%s'."
#define jScripts_syslog_update_nr_of_users		"'jScripts' updated number of users in group '%s' to '%s'."

