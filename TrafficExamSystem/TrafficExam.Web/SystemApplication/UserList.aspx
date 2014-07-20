<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="TrafficExam.Web.SystemApplication.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改人员信息</title>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../CSS/main.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/UserList.js" type="text/javascript"></script>
</head>
<body style="background-color: White">
    <div>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td style="width: 25%">
                    姓名：<input id="name" type="text" />
                </td>
                <td style="width: 25%">
                    警号：<input id="policeid" type="text" />
                </td>
                <td style="width: 20%">
                    职务：<select id="position">
                        <option value=""></option>
                        <option value="大队领导">大队领导</option>
                        <option value="部门领导">部门领导</option>
                        <option value="民警">民警</option>
                    </select>
                </td>
                <td style="width: 25%">
                    部门:
                    <select id="department">
                        <option value=""></option>
                        <option value="大队部">大队部</option>
                        <option value="事故中队">事故中队</option>
                        <option value="监控中心">监控中心</option>
                        <option value="办公室">办公室</option>
                        <option value="车管所">车管所</option>
                        <option value="邓关中队">邓关中队</option>
                        <option value="二中队">二中队</option>
                        <option value="仙市中队">仙市中队</option>
                        <option value="沿滩中队">沿滩中队</option>
                    </select>
                </td>
                <td style="width: 5%">
                    <input id="btnSearch" type="button" value="搜索" />
                </td>
            </tr>
        </table>
        <table border="0" cellspacing="7" class="AdminTable">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" class="AdminrightTable01" id="tableUserList">
                        <tr class="AdminrightTable01title">
                            <td style="padding-left: 20px; text-align: center">
                                姓名
                            </td>
                            <td style="text-align: center">
                                性别
                            </td>
                            <td style="text-align: center">
                                警号
                            </td>
                            <td style="text-align: center">
                                职务
                            </td>
                            <td style="text-align: center">
                                部门
                            </td>
                            <td style="text-align: center">
                                修改
                            </td>
                            <td style="text-align: center">
                                删除
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
