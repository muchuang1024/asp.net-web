<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="TrafficExam.Web.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Simple Javascript Accordions - by www.dezinerfolio.com</title>
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/tree.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        html, body
        {
            font-family: 宋体;
            font-size: 12px;
            margin: auto;
            background-color: #d8ebfc;
            height: 100%;
        }
        
        #basic-accordian
        {
            width: 200px;
            padding: 0;
            position: relative;
            margin-left: 0px;
            z-index: 2;
            margin-top: 1px;
        }
        
        .accordion_headings
        {
            padding: 5px;
            background: #dfe8f6;
            color: #4d6b9c;
            border-bottom: 1px solid #99bbe8;
            cursor: pointer;
            font-weight: bold;
        }
        
        .accordion_headings:hover
        {
            background: #bdceee;
        }
        
        .accordion_child
        {
            padding-left: 5px;
            padding-right: 5px;
            background: #fff;
        }
        
        .header_highlight
        {
            background: #bdceeb;
        }
        
        #ywTree .a
        {
            text-decoration: none;
        }
    </style>
    <script src="../Scripts/accordian-src.js" type="text/javascript"></script>
    <script src="../Scripts/mztreeview10_src.js" type="text/javascript"></script>
    <script src="../Scripts/contentHeight_src.js" type="text/javascript"></script>
</head>
<body>
    <div class="x-panel x-border-panel" id="west-panel" style="width: 200px; height: 96%;
        left: 9px; top: 5px;">
        <div class="x-panel-header x-unselectable" id="ext-gen26" style="-moz-user-select: none;">
            <div class="x-tool x-tool-toggle x-tool-collapse-west" id="ext-gen30">
                &nbsp;&nbsp;</div>
            <span class="f14 c_1 fontbold">功能菜单</span>
        </div>
        <div class="x-panel-bwrap" id="ext-gen27">
            <div id="basic-accordian">
                <!--Parent of the Accordion-->
                <!--Start of each accordion item-->
                <div id="test-header" class="accordion_headings header_highlight">
                    业务操作</div>
                <!--Heading of the accordion ( clicked to show n hide ) -->
                <!--Prefix of heading (the DIV above this) and content (the DIV below this) to be same... eg. foo-header & foo-content-->
                <div id="test-content" style="overflow: hidden;" />
                <!--DIV which show/hide on click of header-->
                <!--This DIV is for inline styling like padding...-->
                <div class="accordion_child" id="ywTree" style="overflow: auto; position: relative;
                    width: auto; height: 100%;">
                </div>
                <!--End of each accordion item-->
                <!--Start of each accordion item-->
                <!--zhouzhouzhushi-->
                <div id="test1-header" class="accordion_headings" style="visibility: hidden;">
                    在线用户</div>
                <!--Heading of the accordion ( clicked to show n hide ) -->
                <!--Prefix of heading (the DIV above this) and content (the DIV below this) to be same... eg. foo-header & foo-content-->
                <div id="test1-content">
                    <!--DIV which show/hide on click of header-->
                    <!--This DIV is for inline styling like padding...-->
                    <div class="accordion_child">
                    </div>
                </div>
                <!--End of each accordion item-->
            </div>
            <!--End of accordion parent-->
        </div>
    </div>
    <script type="text/javascript">
        function InitTree()
        {
            if (tree && timer)
                tree.toAjaxString('ywTree');
            clearTimeout(timer);
        };

        //new Accordian('basic-accordian', 5, 'header_highlight', parent.document.getElementById('frmBody').offsetHeight * tHeight);
        var tree = new MzTreeView("tree");
        tree.setIconPath("../SystemApplication/img/tree/");
        tree.url = "javascript:void(0);";
        tree.target = "main";
        tree.nodeFilePath = "SystemApplication/TreeMenu/";
        document.getElementById('ywTree').innerHTML = "<div style='width:100%;text-align:center;padding-top:10px;'>正在加载栏目，请稍等...</div>";
        //    tree.nodes['0_1'] = 'text:CSDN%u793e%u533a%u8d77%u59cb%u70b9; hint:%u793e%u533a%u8d77%u59cb%u70b9;url:http://www.nmju.net';
        //    tree.nodes['1_9001'] = 'text:%u6211%u611f%u5174%u8da3%u7684%u793e%u533a ; childNodesFileName : treeServer.aspx?treeID=1 ';
        //    tree.nodes['1_2'] = 'text:%u6570%u636e%u5e93%u5f00%u53d1 ; url:http://www.nmju.net; childNodesFileName : db.js ';
        var timer = setTimeout("InitTree()", 20);
        //window.onresize = function () { new Accordian('basic-accordian', 5, 'header_highlight', parent.document.getElementById('frmBody').offsetHeight * tHeight); };
    </script>
</body>
</html>
