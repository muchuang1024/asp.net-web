<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetUserByDepart.aspx.cs"
    Inherits="TrafficExam.Web.SystemApplication.SetUserByDepart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置考试人员</title>
    <link href="../../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/SetUserByDepart.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" class="bxxqtable" id="positionlist">
                        <tr>
                            <td class="bxxqtabletitle">
                                根据部门设置考试人员
                            </td>
                        </tr>
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
                                        <input type="checkbox" value="事故中队" name="depart" id="chkAccident" />
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
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 17px;">
                    <input class="Adminrighttablebtn" type="button" id="SubmitUser" value="设定" />
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
