<?php
    error_reporting(E_ERROR|E_WARNING|E_PARSE);
	require('../../conn.class.php');
	mysql_query('set names utf8');
	$FmenuId = $_GET["Fmenu"];
	$sql = "select categoryId, className from Category where parentId = $FmenuId";
	$result = $db->query($sql);
    while($res = mysql_fetch_array($result))
	{
	   echo "<option value=".$res['categoryId'].">".$res['className']."</option>";
	}
?>