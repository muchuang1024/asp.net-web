<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperInstall.aspx.cs" Inherits="TrafficExam.Web.SystemApplication.PaperInstall" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>考题设置管理</title>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/time.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/PaperInstall.js" type="text/javascript"></script>
    <script src="Scripts/Time.js" type="text/javascript"></script>
    <style type="text/css">
        #onceitem
        {
            width: 82px;
        }
        #moreitem
        {
            width: 84px;
        }
        #deteritem
        {
            width: 79px;
        }
    </style>
    
</head>
<body style="background-color: White">
    <div id="mainContent">
        <table width="100%" border="0" cellspacing="0" class="bxxqtable">
        <tr>
          <td class="bxxqtabletitle">题目难度设置</td>
          <td class="bxxqtabletitle"></td>
          <td class="bxxqtabletitle"></td>
        </tr>
        <tr>
          <td> <br /></td>
        </tr>
        <tr>
          <td><span>简单:</span><span><input id="onceitem" type="radio" name="item" /></span></td>
          <td><span>中等:</span><span><input id="moreitem" type="radio" name="item" /></span></td>
          <td><span>困难:</span><span><input id="deteritem" type="radio" name="item" /></span></td>
        </tr>
        <tr>
          <td> <br /></td>
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
            </table>
            <table width="100%" border="0" cellspacing="0" class="bxxqtable" id="Table1">
            <tr>
                <td class="bxxqtabletitle">设置考试人员</td>
                <td class="bxxqtabletitle"></td>
                <td class="bxxqtabletitle"></td>
            </tr>
            </table>
           <span><input id="selectPos" type="radio" name="category"  checked = "checked" /></span>按职务
           <span><input id="selectDpt" type="radio" name="category" /></span>按部门
            <div id="pos">
            <table border="0" width="100%" cellspacing="0" class="bxxqtable">
                  <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList1">
                                    <span>
                                        <input type="checkbox" value="大队领导" name="position" id="chkLeadership" />
                                        大队领导</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Leadership" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList2">
                                    <span>
                                        <input type="checkbox" value="部门领导" name="position" id="chkDepartment" />
                                        部门领导</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Department" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList3">
                                    <span>
                                        <input type="checkbox" value="民警" name="position" id="chkPolice" />
                                        民警</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Police" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="positionList4">
                                    <span>
                                        <input type="checkbox" value="协警" name="position" id="chkHelpPolice" />
                                        协警</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_HelpPolice" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>                
        </table>
        </div>
         <div id="dpt" style="display:none">
        <table border="0" cellspacing="0" class="AdminTable">
                    <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList1">
                                    <span>
                                        <input type="checkbox" value="大队部" name="depart" id="chkCorps" />
                                        大队部</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Corps" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList2">
                                    <span>
                                        <input type="checkbox" value="事故中队" name="depart" id="Checkbox1" />
                                        事故中队</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Accident" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList3">
                                    <span>
                                        <input type="checkbox" value="监控中心" name="depart" id="chkMonitoringCenter" />
                                        监控中心</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_MonitoringCenter" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList4">
                                    <span>
                                        <input type="checkbox" value="办公室" name="depart" id="chkOffice" />
                                        办公室</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Office" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList5">
                                    <span>
                                        <input type="checkbox" value="车管所" name="depart" id="chkVehicle" />
                                        车管所</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Vehicle" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList6">
                                    <span>
                                        <input type="checkbox" value="邓关中队" name="depart" id="chkDengguan" />邓关中队</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Dengguan" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList7">
                                    <span>
                                        <input type="checkbox" value="二中队" name="depart" id="chkSecond" />二中队</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Second" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList8">
                                    <span>
                                        <input type="checkbox" value="仙市中队" name="depart" id="chkXianshi" />仙市中队</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Xianshi" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList9">
                                    <span>
                                        <input type="checkbox" value="沿滩中队" name="depart" id="chkYantan" />沿滩中队</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Yantan" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList10">
                                    <span>
                                        <input type="checkbox" value="新进人员" name="depart" id="chkNewUser" />新进人员</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_NewUser" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="departList11">
                                    <span>
                                        <input type="checkbox" value="其他" name="depart" id="chkOther" />其他</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="bxxqtableselcet">
                                <div id="div_Other" style="padding-left: 30px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class='style1'>
                            </td>
                        </tr>
        </table>
    </div>
         <table  width="100%" border="0" cellspacing="0" class="bxxqtable" id="timeset">
           <tr>
              <td class="bxxqtabletitle" style="padding-right: 10px; text-align: left" colspan="3">
                    考试时间设置
                </td>
           </tr>
           <tr>
                <td colspan="1" style="height: 20px" >
                     <div><span>开始答题：</span><span><input id="starttime" class="Adminrighttableiput" name="starttime" onclick="showCal(starttime);"
                        type="text" value="" /></span></div>
                    <div id="dateTime" onclick="event.cancelBubble=true" style="position: absolute; visibility: hidden;
                        width: 100px; height: 100px; left: 0px; top: 0px; z-index: 100;">
                        <table border="0" class="cal_table">
                            <tr>
                                <td>
                                    <script> var c = new CalendarCalendar('c'); document.write(c);</script>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <script> var m = new CalendarMinute('m'); document.write(m);</script>
                                </td>
                            </tr>
                        </table>
                       
                    </div>
                    <script language="javascript" event="onclick" for="document">hideCalendar()</script>
                </td>
                 <td colspan="2" style="height: 20px">
                    <div><span>时长：</span><span><input type="text" name="endtime"  value="" id="endtime"
                            style="width: 49px" />分钟</span><font color="red"><label>(*必须为整数)</label></font></div>
                </td>
            </tr>
            <tr> 
                  <td class="bxxqtableselcet" colspan="3">
                        <div id="div1" style="padding-left: 30px">
                        </div>
                   </td>
            </tr>
        </table>
        </div>
        <div align="center">
            <span><input id="Sub_GetSubject" type="submit" value="设定" class="Adminrighttablebtn" /></span>
            <span><input id="btn_CompleteExam" type="submit" value="完成考试" class="Adminrighttablebtn" /></span>
        </div>     
</body>
</html>
