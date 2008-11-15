<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01//EN"
   "http://www.w3.org/TR/html4/strict.dtd"><html>
<head>
<title>Travian si6</title>
<link rel=stylesheet type="text/css" href="new.css?t">
<link rel=stylesheet type="text/css" href="unx.css">
<script src="unx.js?t" type="text/javascript"></script>

<meta http-equiv="cache-control" content="max-age=0">
<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="expires" content="0">
<meta http-equiv="imagetoolbar" content="no">
<meta http-equiv="content-type" content="text/html; charset=UTF-8">
</head>
<body onload="start()"><div id="ltop1"><div id="ltop5"><a href="dorf1.php"><img id="n1" src="img/un/a/x.gif" title="Pregled naselbine"></a><a href="dorf2.php"><img id="n2" src="img/un/a/x.gif" title="Center naselja"></a><a href="karte.php"><img id="n3" src="img/un/a/x.gif" title="Zemljevid"></a><a href="statistiken.php"><img id="n4" src="img/un/a/x.gif" title="Statistika"></a><img id="n5" src="img/un/l/m4.gif" usemap="#nb"><a href="plus.php"><img id="lplus1" src="img/si/a/plus.gif" width="80" height="100" title="Plus meni"></a></div></div><map name="nb"><area shape=rect coords="0,0,35,100" href="berichte.php" title="Poročila"><area shape=rect coords="35,0,70,100" href="nachrichten.php" title="Sporočila"></map><div id="lmidall"><div id="lmidlc"><div id="lleft">

<a href="http://www.travian.si/"><img class="logo" src="img/si/a/travian0.gif"></a><table id="navi_table" cellspacing="0" cellpadding="0">
<tr>
<td class="menu">
<a href="http://www.travian.si/">Domača stran</a>
<a href="#" onClick="return Popup(0,0);">Napotki&Pregled</a>
<a href="spieler.php?uid=9500">Profil</a><a href="logout.php">Odjava</a><br><br><a href="http://si-forum.travian.com/" target="_blank">Forum</a><a href="http://www.travian.si/chat.php?chatname=si6|jeza" target="_blank">Klepet</a><br><br><a href="plus.php?id=3">Travian <b><font color="#71D000">P</font><font color="#FF6F0F">l</font><font color="#71D000">u</font><font color="#FF6F0F">s</font></b></a><a href="support.php">Podpora</a></td>
</tr>
</table></div><div id="lmid1"><div id="lmid2"><h1><b>Tržnica Stopnja 15</b></h1>
<p class="f10">Preko trgovcev na tržnici lahko trguješ z drugimi igralci ali pa med svojimi naselji. Bolj kot je tržnica nadgrajena več surovin lahko pošlješ naenkrat.</p><p class="txt_menue">
<a href="build.php?id=33">Pošlji surovine</a> |
<a href="build.php?id=33&t=1">Kupi</a> |
<a href="build.php?id=33&t=2">Ponudi</a> | <a href="build.php?id=33&t=3">NPC trgovanje</a></p><script language="JavaScript">
<!--
var haendler = 14;
var carry = 1000;
//-->
</script><p>
<form method="POST" name="snd" action="build.php">
<input type="hidden" name="id" value="33">
<table cellspacing="0" cellpadding="0" width="100%" valign="top">
<tr valign="top">

<td width="45%">
<table class="f10">
<tr>
<td><a href="#" onClick="upd_res(1,1); return false;"><img class="res" src="img/un/r/1.gif"></a></td>
<td>Les:</td><td align="right"><input class="fm" type="Text" name="r1" id="r1" value="" size="4" maxlength="5" onKeyUp="upd_res(1)" tabindex="1"></td><td class="s7 f8"><a href="#" onMouseUp="add_res(1);" onClick="return false;">(1000)</a></td>
</tr>
<tr>
<td><a href="#" onClick="upd_res(2,1); return false;"><img class="res" src="img/un/r/2.gif"></a></td>
<td>Glina:</td><td align="right"><input class="fm" type="Text" name="r2" id="r2" value="" size="4" maxlength="5" onKeyUp="upd_res(2)" tabindex="2"></td><td class="s7 f8"><a href="#" onMouseUp="add_res(2);" onClick="return false;">(1000)</a></td>
</tr>
<tr>
<td><a href="#" onClick="upd_res(3,1); return false;"><img class="res" src="img/un/r/3.gif"></a></td>
<td>Železo:</td><td align="right"><input class="fm" type="Text" name="r3" id="r3" value="" size="4" maxlength="5" onKeyUp="upd_res(3)" tabindex="3"></td><td class="s7 f8"><a href="#" onMouseUp="add_res(3);" onClick="return false;">(1000)</a></td>
</tr>
<tr>
<td><a href="#" onClick="upd_res(4,1); return false;"><img class="res" src="img/un/r/4.gif"></a></td>
<td>Žito:</td><td align="right"><input class="fm" type="Text" name="r4" id="r4" value="" size="4" maxlength="5" onKeyUp="upd_res(4)" tabindex="4"></td><td class="s7 f8"><a href="#" onMouseUp="add_res(4);" onClick="return false;">(1000)</a></td>

</tr>
</table>
</td><td width="55%" valign="top">

<table class="f10">
<tr><td colspan="2">Trgovci 14/15<br><br></td></tr>

<tr><td colspan="2"><span class="f135 b">Naselje:</span>

<input class="fm" type="Text" name="dname" value="" size="10" maxlength="20" tabindex="5"></td>
</tr>


<tr><td colspan="2"><i>ali</i></td></tr>

<tr>
<td colspan="2">
<span class="f135 b">
X:
<input class="fm" type="Text" name="x" value="" size="2" maxlength="4" tabindex="6">
Y:
<input class="fm" type="Text" name="y" value="" size="2" maxlength="4" tabindex="7">
</span></td>
</tr>

</table>

</td></tr>
</table><p><input type="image" value="ok" border="0" name="s1" src="img/si/b/ok1.gif" width="50" height="20" onMousedown="btm1('s1','','img/si/b/ok2.gif',1)" onMouseOver="btm1('s1','','img/si/b/ok3.gif',1)" onMouseUp="btm0()" onMouseOut="btm0()" tabindex="8"></input></form></p><script language="JavaScript" type="text/javascript">
//<!--
document.snd.r1.focus();
//-->
</script><p>Vsak tvoj trgovec lahko prepelje <b>1000</b> surovin.</p><p class="b">Prihajajoči trgovci:</p><p><table cellspacing="1" cellpadding="2" class="tbg">
	<tr class="cbg1">
	<td width="21%"><a href="spieler.php?uid=9500"><span class="c0">jeza</span></a></td>
	<td colspan="2"><a href="karte.php?d=395279&c=8d"><span class="c0">Transport iz 01</span></a></td>
	</tr>

	<tr><td>Prihod</td><td><span id=timer1>0:26:56</span> h</td><td>ob 23:46</td></tr>

	<tr class="cbg1"><td>Surovine</td><td class="s7" colspan="2"><span class="f10"><img class="res" src="img/un/r/1.gif">0 | <img class="res" src="img/un/r/2.gif">3000 | <img class="res" src="img/un/r/3.gif">0 | <img class="res" src="img/un/r/4.gif">0</td></tr></table></p><p class="b">Lastni trgovci na poti:</p><p><table cellspacing="1" cellpadding="2" class="tbg">
	<tr class="cbg1">
	<td width="21%"><a href="spieler.php?uid=9500"><span class="c0">jeza</span></a></td>
	<td colspan="2"><a href="karte.php?d=412868&c=e5"><span class="c0">Transport v Izida</span></a></td>
	</tr>

	<tr><td>Prihod</td><td><span id=timer2>0:16:31</span> h</td><td>ob 23:36</td></tr>

	<tr class="cbg1"><td>Surovine</td><td class="s7" colspan="2"><span class="f10"><img class="res" src="img/un/r/1.gif">0 | <img class="res" src="img/un/r/2.gif">0 | <img class="res" src="img/un/r/3.gif">1000 | <img class="res" src="img/un/r/4.gif">0</td></tr></table></p><br><div><b>Cena</b> nadgradnje 16:
<table class="f10"><tr><td><img class="res" src="img/un/r/1.gif">3245 | <img class="res" src="img/un/r/2.gif">2840 | <img class="res" src="img/un/r/3.gif">4870 | <img class="res" src="img/un/r/4.gif">2840 | <img class="res" src="img/un/r/5.gif">4 | <img class="clock" src="img/un/a/clock.gif" width="18" height="12"> 5:21:00</td></tr></table>
<span class="c">Vsi gradbeni delavci so zaposleni</span></div><img src="img/un/a/x.gif" /></div></div></div><div id="lright1"><a href="dorf3.php"><span class="f10 c0 s7 b">Naselbine:</span></a><table class="f10"><tr><td class="nbr"><span class="c2">&#8226;</span>&nbsp; <a href="?newdid=73913&gid=17&id=33" class="active_vl">00</a></td><td class="right"><table class="dtbl" cellspacing="0" cellpadding="0">
<tr>
<td class="right dlist1">(-22</td>
<td class="center dlist2">|</td>
<td class="left dlist3">-95)</td>
</tr>
</table></td></tr><tr><td class="nbr"><span>&#8226;</span>&nbsp; <a href="?newdid=83117&gid=17&id=33">01</a></td><td class="right"><table class="dtbl" cellspacing="0" cellpadding="0">
<tr>
<td class="right dlist1">(-15</td>
<td class="center dlist2">|</td>
<td class="left dlist3">-93)</td>
</tr>
</table></td></tr></table></div></div><div id="lres0">
<table align="center" cellspacing="0" cellpadding="0"><tr valign="top">
<td><img class="res" src="img/un/r/1.gif" title="Les"></td>
<td id=l4 title=681>5960/21400</td>
<td class="s7"> <img class="res" src="img/un/r/2.gif" title="Glina"></td>
<td id=l3 title=681>6970/21400</td>
<td class="s7"> <img class="res" src="img/un/r/3.gif" title="Železo"></td>
<td id=l2 title=750>6545/21400</td><td class="s7"> <img class="res" src="img/un/r/4.gif" title="Žito"></td>
<td id=l1 title=629>6939/14400</td>
<td class="s7"> &nbsp;<img class="res" src="img/un/r/5.gif" title="Poraba žita">&nbsp;1351/1980</td></tr></table>
</div><div id="ltime">Izračunano v <b>21</b> ms<br>Čas na serverju: <span id="tp1" class="b">23:19:39</span> </div>
<div id="ce"></div></body>
</html>