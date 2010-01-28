****************************************************************************************************************
[1.14]
****************************************************************************************************************
add	: #define iojZS_window_name			"ioFTPD::MessageWindow"
add	: #define iojZS_get_user_stats			true		//rank


****************************************************************************************************************
[1.13]
****************************************************************************************************************
?


****************************************************************************************************************
[1.12]
****************************************************************************************************************
?


****************************************************************************************************************
[1.11]
****************************************************************************************************************
add	: #define iojZS_irc_incomplete			"%C04%Binfo%B%C %B%R%B is %BiNCOMPLETE%B because %B%u%B deleted file."
add	: #define iojZS_allow_genre			"pop,metal,rock"
add	: #define iojZS_bad_name_file			".bad"
add	: #define iojZS_logfile				"..\\logs\\iojZS.log"
add	: #define iojZS_users_stats_file		"_%2p__%u@%g_%m_%P%%_%fF_%skBps_"
add	: #define iojZS_delete_users_stats_file		"_*@*%*_"
add	: #define iojZS_rar_on_rls_complete		"c:\\Progra~1\\WinRar\\UnRAR.exe x -o+ %a\\*.rar d:\\play\\%h\\"
add	: #define iojZS_zip_on_rls_complete		"unzip.exe -qqojC \"%a\\*.zip\" \"*\" -d \"d:\\play\\%h\\\""
add	: #define iojZS_on_nfo_uploaded			"nfo.exe %i"
add	: #define iojZS_on_sfv_uploaded			"sfv.exe %i"
add	: #define iojZS_on_zip_uploaded			"unzip.exe -qqojC \"%i\" \"*\" -d \"d:\\play\\%h\\\""
		
add	: #define iojZS_check_files_when_race		false
add	: #define iojZS_anounce_incomplete		true
add	: #define iojZS_create_bad_files		false
add	: #define iojZS_run_rar_on_complete		false
add	: #define iojZS_run_zip_on_complete		false
add	: #define iojZS_run_nfo_on_upload		false
add	: #define iojZS_run_sfv_on_upload		false
add	: #define iojZS_run_zip_on_upload		false
add	: #define iojZS_dont_wait_for_script		true
add	: #define iojZS_check_ok_genre			false	
add	: #define iojZS_create_stats_files		false
add	: #define iojZS_log_ioftpd			true
add	: #define iojZS_log_iojzs			false
add	: #define iojZS_anounce_nfo			true
add	: #define iojZS_anounce_newleader		false
add	: #define iojZS_irc_nfo				"\"%h\" \"%f\" \"%u\" \"%g\""
add	: #define iojZS_irc_newleader			"%C03%Blead%B%C %B%R%B by %B%w%B [%m/%P%%/%fF/%skBps]"
	
remove	: 'nfo' from iojZS_skip_ext

remove	: #define iojZS_msg_head_users
remove	: #define iojZS_msg_users
remove	: #define iojZS_msg_head_groups
remove	: #define iojZS_msg_groups
remove	: #define iojZS_msg_foot

add	: #define iojZS_msg_head_release
add	: #define iojZS_msg_mp3_info
add	: #define iojZS_msg_head_users
add	: #define iojZS_msg_users
add	: #define iojZS_msg_head_groups
add	: #define iojZS_msg_groups
add	: #define iojZS_msg_foot
	
	
****************************************************************************************************************
[1.10]
****************************************************************************************************************
add	: #define iojZS_minimum_halfway_files		5	
remove	: #define iojZS_on_rls_complete			"c:\\ioFTPD\\script.exe %a %f"
remove	: #define iojZS_run_on_complete			false
add	: #define iojZS_anounce_0byte_file		false
add	: #define iojZS_anounce_bad_file		false
add	: #define iojZS_irc_0_byte			"%C04%Binfo%B%C %B%R%B %B0 byte%B FiLE by %B%u%B"
add	: #define iojZS_irc_bad_file			"%C04%Binfo%B%C %B%R%B %BBAD%B FiLE by %B%u%B"
