<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetPratice.aspx.cs" Inherits="TrafficExam.Web.UserApplication.SetPratice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/SetPratice.js" type="text/javascript"></script>
  
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
    <div>
    <img src="../Images/PicLogintop_3.png" width="100%"  height="90px" />
        <table width="100%" border="0" cellspacing="0" class="bxxqtable">
        <tr>
          <td class="bxxqtabletitle">题目数量设置</td>
          <td class="bxxqtabletitle"></td>
          <td class="bxxqtabletitle"></td>
        </tr>
        <tr>
          <td> <br /></td>
        </tr>
        <tr>
          <td><span>简单:</span><span><input id="onceitem" type="radio" name="item"></span></td>
          <td><span>中等:</span><span><input id="moreitem" type="radio" name="item"></span></td>
          <td><span>困难:</span><span><input id="deteritem" type="radio" name="item"></span></td>
        </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" class="bxxqtable" id="topic">
            <tr>
                <td class="bxxqtabletitle">考点设置</td>
                <td class="bxxqtabletitle"></td>
                <td class="bxxqtabletitle"></td>
            </tr>
            
            <tr>
                <td class="bxxqtableselcet" style="width: 33%">
                    <input type="checkbox" id="chkCarLoss" name="More" value="1" />
                    法律法规知识
                </td>
                <td class="bxxqtableselcet" style="width: 33%">
                    <input type="checkbox" id="chkCarRob" name="More" value="2" />
                    执勤执法
                </td>
                <td class="bxxqtableselcet" style="width: 33%">
                    <input type="checkbox" id="chkCarThird" name="More" value="3" />
                    事故处理
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <div class="Adminrightline">
                    </div>
                </td>
                <td>
                    <div class="Adminrightline">
                    </div>
                </td>
                <td>
                    <div class="Adminrightline">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="bxxqtableselcet">
                    <input type="checkbox" id="chkPerson" name="More" value="4" />车辆及驾驶人管理
                </td>
                <td class="bxxqtableselcet">
                    <input type="checkbox" id="chkCarFranchise" name="More" value="5" />
                    警纪警规
                </td>
                <td class="bxxqtableselcet">
                    <input type="checkbox" id="chkTraffic" name="More" value="6" />
                    警务技能
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <div class="Adminrightline">
                    </div>
                </td>
                <td>
                    <div class="Adminrightline">
                    </div>
                </td>
                <td>
                    <div class="Adminrightline">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="bxxqtableselcet">
                    <input type="checkbox" id="chkSafety" name="More" value="7" />
                    警察礼仪
                </td>
                <td class="bxxqtableselcet">
                    <input type="checkbox" id="chkCulture" name="More" value="8" />
                    办公文秘
                </td>
                <td class="bxxqtableselcet">
                    <input type="checkbox" id="chkAccident" name="More" value="9" disabled = "true" />
                    宣传教育
                </td>
            </tr>
            <tr>
                <td class="bxxqtableselcet" colspan="3">
                    <div class="Adminrightline">
                    </div>
                </td>
            </tr>
        </table>
        <div align="center">
            <span><input id="Sub_GetSubject" type="button" value="确定" class="Adminrighttablebtn" /></span>&nbsp;
        </div>
      
    </form>
</body>
</html>

