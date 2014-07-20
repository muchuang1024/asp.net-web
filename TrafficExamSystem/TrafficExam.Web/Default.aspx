<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrafficExam.Web.Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>管理员控制台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" type="Text/Javascript">
		<!--
        if (window.top != window)
        {
            window.top.location.href = document.location.href;
        }
		//-->
    </script>
    <style type="text/css">
		    <!--
		     head{ SCROLLBAR-FACE-COLOR: #F4F3EE; 
		           SCROLLBAR-HIGHLIGHT-COLOR: #006666; 
		           SCROLLBAR-SHADOW-COLOR: #363946; 
		           SCROLLBAR-3DLIGHT-COLOR: #B9C2B3; 
		           SCROLLBAR-ARROW-COLOR: #006666;
		            SCROLLBAR-TRACK-COLOR: #006666; 
		            SCROLLBAR-DARKSHADOW-COLOR: #000; 
		            }
		       -->
		</style>
</head>
<div id="content">
    <frameset rows="82,100%,27" cols="*" framespacing="0" frameborder="0" border="0">
		<FRAME id="frmTop"  name="frmTop" src="header.aspx" noresize frameBorder="0" scrolling="no" height="129px">
		<FRAMESET id="frmBody" border="0" frameSpacing="0" cols="214, 12, *">
			<FRAME id="frmLeft" name="frmLeft" src="left.aspx" frameBorder="0" noresize>
			<FRAME id="drag-frame" name="drag-frame" src="drag.htm" frameBorder="0" scrolling="no"
				noresize>
			<FRAME id="main" name="main" frameBorder="0" scrolling="auto" src="MainForm.aspx">
		</FRAMESET>
		<FRAME id="frmBottom" name="frmBottom" src="footer.aspx" noresize frameBorder="0" scrolling="no">
	</frameset>
</div>
</html>
