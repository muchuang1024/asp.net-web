<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateItemTitle.aspx.cs" Inherits="TrafficExam.Web.SystemApplication.UpdateItemTitle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>题库管理</title>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/UpdateItemTitle.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function newInput() {
            var count = document.getElementById("select1").value;
            if (count == 2) {
                document.getElementById("sixthanswer").style.display = 'none';
                document.getElementById("fifthanswer").style.display = 'none';
                document.getElementById("fourthanswer").style.display = 'none';
                document.getElementById("thirdanswer").style.display = 'none';
                document.getElementById("firstanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";


            }
            if (count == 3) {
                document.getElementById("sixthanswer").style.display = 'none';
                document.getElementById("fifthanswer").style.display = 'none';
                document.getElementById("fourthanswer").style.display = 'none';
                document.getElementById("thirdanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";
                document.getElementById("firstanswer").style.display = "";

            }
            if (count == 4) {
                document.getElementById("sixthanswer").style.display = 'none';
                document.getElementById("fifthanswer").style.display = 'none';
                document.getElementById("fourthanswer").style.display = "";
                document.getElementById("thirdanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";
                document.getElementById("firstanswer").style.display = "";
            }
            if (count == 5) {
                document.getElementById("sixthanswer").style.display = 'none';
                document.getElementById("fifthanswer").style.display = "";
                document.getElementById("fourthanswer").style.display = "";
                document.getElementById("thirdanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";
                document.getElementById("firstanswer").style.display = "";

            }
            if (count == 6) {
                document.getElementById("sixthanswer").style.display = "";
                document.getElementById("fifthanswer").style.display = "";
                document.getElementById("fourthanswer").style.display = "";
                document.getElementById("thirdanswer").style.display = "";
                document.getElementById("secondanwser").style.display = "";
                document.getElementById("firstanswer").style.display = "";

            }
        }
       
    </script>
    <style type="text/css">
        #TextArea1
        {
            width: 338px;
            height: 38px;
        }
        #Adminrighttabletdtitle
        {
            width: 491px;
        }
    </style>
</head>
<body style="background-color: White">
    <div id="item">
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td align="center" valign="top">
                    <table width="690" border="0" cellspacing="0" class="bxgsbox">
                        <tr>
                            <td align="center" class="bxgsboxtitle">
                                题库信息
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0">
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            考点
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <span class="Adminrighttabletdtext">
                                                <select id="selectInsurerName" class="Adminjcselcet" style="width: 208px">
                                                    <option value="请选择">请选择</option>
                                                    <option value="法律法规知识">法律法规知识</option>
                                                    <option value="执勤执法">执勤执法</option>
                                                    <option value="事故处理">事故处理</option>
                                                    <option value="车辆及驾驶人管理">车辆及驾驶人管理</option>
                                                    <option value="警纪警规">警纪警规</option>
                                                    <option value="警务技能">警务技能</option>
                                                    <option value="警察礼仪">警察礼仪</option>
                                                    <option value="办公文秘">办公文秘</option>
                                                    <option value="宣传教育">宣传教育</option>
                                                </select>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            题目类型
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <input id="radioInsuranceTypeA"  type="radio" name="group_InsuranceType"
                                                value="1" />单选
                                            <input id="radioInsuranceTypeB" type="radio" name="group_InsuranceType" value="2" />多选
                                            <input id="radioInsuranceTypeC" type="radio" name="group_InsuranceType" value="3" />判断
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Adminrighttabletdtitle">
                                          题干
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                             <input type="text" id="Adminrighttabletdtitle" name="S1"></input>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td width="27%" class="Adminrighttabletdtitle">
                                            答案个数
                                        </td>
                                        <td width="73%" class="Adminrighttabletdtext02">
                                            <span class="Adminrighttabletdtext">
                                             
                                                <select id="select1" class="Adminjcselcet" style="width: 208px" onchange="newInput()">
                                                    <option value="请选择">请选择</option>
                                                    <option value="6">6</option>
                                                    <option value="5">5</option>
                                                    <option value="4">4</option>
                                                    <option value="3">3</option>
                                                    <option value="2">2</option>
                                                </select>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr id="firstanswer" style="display:none">
                                         <td class="Adminrighttabletdtitle">
                                            第一答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password1" class="Adminrighttableiput" type="text" maxlength="16" />
                                             <input id="chbanswer1" type="checkbox" name="answer" value="1" />
                                        </td>
                                    </tr>
                                     <tr id="secondanwser" style="display:none">
                                         <td class="Adminrighttabletdtitle">
                                            第二答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password2" class="Adminrighttableiput" type="text" maxlength="16" />
                                             <input id="chbanswer2" type="checkbox" name="answer" value="2" />
                                        </td>
                                    </tr>
                                     <tr id="thirdanswer" style="display:none">
                                         <td class="Adminrighttabletdtitle">
                                            第三答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password3" class="Adminrighttableiput" type="text" maxlength="16" />
                                             <input id="chbanswer3" type="checkbox" name="answer" value="3" />
                                        </td>
                                    </tr>
                                     <tr id="fourthanswer"  style="display:none">
                                         <td class="Adminrighttabletdtitle">
                                            第四答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password4" class="Adminrighttableiput" type="text" maxlength="16" />
                                             <input id="chbanswer4" type="checkbox" name="answer" value="4" />
                                        </td>
                                    </tr>
                                     <tr id="fifthanswer" style="display:none">
                                         <td class="Adminrighttabletdtitle">
                                            第五答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password5" class="Adminrighttableiput" type="text" maxlength="16" />
                                             <input id="chbanswer5" type="checkbox" name="answer" value="5" />
                                        </td>
                                    </tr>
                                     <tr id="sixthanswer"  style="display:none">
                                         <td class="Adminrighttabletdtitle">
                                            第六答案项
                                        </td>
                                        <td class="Adminrighttabletdtext02">
                                            <input id="Password6" class="Adminrighttableiput" type="text" maxlength="16" />
                                             <input id="chbanswer6" type="checkbox" name="answer" value="6" />
                                        </td>
                                    </tr>
                                   
                                    
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="Adminrightline">
                                </div>
                                <table width="100%" border="0">
                                    <tr>
                                        <td height="53" align="center">
                                            <span><input id="Update_ItemTitle" type="submit" class="Adminrighttablebtn" value="更新"  /></span>
                                            <span><input id="Back_ItemTitle" type="submit" class="Adminrighttablebtn" value="返回"  /></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
