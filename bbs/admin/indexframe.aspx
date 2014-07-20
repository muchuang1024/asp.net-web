<%@ Page Language="C#" AutoEventWireup="true" CodeFile="indexframe.aspx.cs" Inherits="admin_indexframe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    html  
    {
    	overflow-x:hidden; 
    }
    </style>
      <frameset rows="18%,72%,10%"  frameborder="NO" border="0" framespacing="0" > 
  <frame src="admin_top.aspx" noresize="noresize" frameborder="NO" name="topFrame" scrolling="no" marginwidth="0" marginheight="0"/>
  <frameset cols="210,*" id="frame">
	<frame src="left.aspx" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="0" scrolling="no" />
     <frameset rows="30,*" id="frame2">
	<frame src="right_top.aspx" name="rightFrame" marginwidth="0" marginheight="0" frameborder="0" scrolling="yes" target="_self" />
	<frame src="./bbs/section.aspx" name="mainFrame" marginwidth="0" marginheight="0" frameborder="0" scrolling="yes" target="_self" />
     <frameset></frameset>
  </frameset>
  <frame src="footer.aspx" noresize="noresize" frameborder="NO" name="footerFrame" scrolling="no" marginwidth="0" marginheight="0" />
  </frameset><noframes></noframes>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      

    </div>
    </form>
</body>
</html>
