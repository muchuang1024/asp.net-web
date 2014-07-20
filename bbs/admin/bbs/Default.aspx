<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_bbs_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
        	    margin:0xp;
        	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" margin:0px; width:1000px;height:500px;background-image: url('欢迎界面.jpg')">
   
        <asp:Image ID="Image2" runat="server" Width="60px" Height="60px" 
            ImageUrl="~/admin/bbs/top.gif"  style=" margin-left: 471px; margin-top: 239px;"
           />

    
    </div>
    <div id="lBDiv" style="width:150px; height:160px; top:0px; left:0px; margin:0px; padding:0px;">
<div id="lDiv" style="position:relative; top: 0px; left: 0px;">
内容略
</div>
</div> 


<script type="text/javascript">
    var speded = 30;
    dvvv2.innerHTML = dvvv1.innerHTML;
    function Marqpuee() {
        if (dvvv2.offsetWidth - dvvv.scrollLeft <= 0)
            dvvv.scrollLeft -= dvvv1.offsetWidth;
        else {
            dvvv.scrollLeft++;
        }
    }
    var MyMmar = setInterval(Marqpuee, speded)
    dvvv.onmouseover = function () { clearInterval(MyMmar) }
    dvvv.onmouseout = function () { MyMmar = setInterval(Marqpuee, speded) }
        </script>


</div>
    </form>
</body>
</html>
