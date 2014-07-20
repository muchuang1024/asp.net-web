<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonScoreDetail.aspx.cs"
    Inherits="TrafficExam.Web.SystemApplication.PersonScoreDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>考试人员成绩明细</title>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/PersonScoreDetail.js" type="text/javascript"></script>
    <link href="TableCSS/main.css" rel="stylesheet" type="text/css" />
    <link href="TableCSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div>
        <table id="showScoreDetail" cellspacing="0" cellpadding="0" align="center" border="1"
            class="mainTable">
        </table>
    </div>
</body>
</html>
