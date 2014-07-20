<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="TrafficExam.Web.UserApplication.Exam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>考试页面</title>
    <link href="../CSS/Exam.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/Exam.js" type="text/javascript"></script>
     <script type="text/javascript">
         window.onload = window.onresize = function()
         {
             if (document.getElementById("bxxqtable").clientHeight < document.getElementById("bxxqtable3").clientHeight)
             {
                 document.getElementById("bxxqtable").style.height = document.getElementById("bxxqtable3").offsetHeight - 30 + "px";
             }
             else
             {
                 document.getElementById("bxxqtable3").style.height = document.getElementById("bxxqtable").offsetHeight + "px";
             }
         }
         window.onunload = function () 
         {
             window.opener = null;
             window.close();
             SubmitExam();
         }
   </script>
   <script type="text/javascript">
       function max() 
       {
           self.moveTo(-5, -118)
           self.resizeTo(window.screen.Width + 30, window.screen.Height + 143)
       }
</script>
<script language="javascript">
<!--    屏蔽鼠标右键
    function document.oncontextmenu() {
        return false;
    } 
-->
</script>
<script language="javascript">
function document.onkeydown() 
{ 
   <!--屏蔽F1到F12键 --> 
   if ( event.keyCode>=112 && event.keyCode <= 123) 
     { 
         event.keyCode = 0; 
         event.cancelBubble = true; 
         return false; 
     }
   <!--//屏蔽 Alt+ 方向键 ←  -->
     if ((window.event.altKey)&&((window.event.keyCode==37)||(window.event.keyCode==39)))
     {  
        alert("不准你使用ALT+方向键前进或后退网页！");
        event.returnvalue=false;
      }
  
    <!--屏蔽退格删除键和Ctrl + R  -->
   if ((event.keyCode == 8) && (event.srcElement.type != "text" && 
       event.srcElement.type != "textarea" && 
       event.srcElement.type != "password") ||          
       (event.ctrlKey && event.keyCode==82))
   {            
      event.keyCode=0;
      event.returnvalue=false;
   }
   <!-- 屏蔽 ctrl+n-->
   if (event.ctrlKey && (event.keyCode==78))   
      event.returnvalue=false;
   <!-- 屏蔽 shift+F10-->
   if ((event.shiftKey)&&(event.keyCode==121)) 
      event.returnvalue=false;
   <!-- 屏蔽 shift 加鼠标左键新开一网页 -->
   if (window.event.srcElement.tagName == "A" && window.event.shiftKey) 
       window.event.returnvalue = false;  
   <!-- 屏蔽Alt+F4-->
    if ((window.event.altKey)&&(window.event.keyCode==115))           
    {   
        window.showModelessDialog("about:blank","","dialogWidth:0px;dialogheight:0px");                 return false;   
    }   

}
</script>
</head>
<body  style="background-color: White;margin:8% auto 0 auto" onload='max()' onblur="this.focus()" >
    <div id="content">
        <div id="top">
            <div style="float: left; padding-left: 2px">
                <img src="../Images/PicLogintop_3.png" width="100%"  height="90px" />
            </div>
        </div>
        <div id="box" class="line">
            <div id="left_box">
                <table border="0" cellspacing="7" class="AdminTable">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" class="bxxqtable" id="bxxqtable">
                                <tr>
                                    <td class="bxxqtabletitle">
                                        <span>【<label id="lblTitleId"></label>】</span>
                                        <label id="lblTitle">
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="bxxqnext">
                                            <table width="100%" border="0" cellspacing="1" class="bxxqnexttable" id="paperInfo">
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; padding-left: 55px; width: 100%;" colspan="2">
                                        <div id="divResult" style="display: none">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="height:30px">本题结果：<label id="lblResult"></label></div>
                                                    </td>
                                                    <td>
                                                        <div id="divProperAnswer"  style="height:30px">
                                                            正确答案：<label id="lblProperAnswer"></label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="100%" border="0" cellspacing="0" class="bxxqtable2">
                                <tr>
                                    <td>
                                        <input id="btnNext" type="submit" class="Adminrighttablebtn" value="下一题" />
                                        <input id="btnPrev" type="submit" class="Adminrighttablebtn" value="上一题" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="right_box">
                <table width="100%" border="0" cellspacing="7" class="infotable">
                    <tr>
                        <td>
                            <center>
                                <strong>答题信息</strong></center>
                        </td>
                    </tr>
                </table>
                <table class="bxxqtable3" width="100%" border="0" cellspacing="7" id="bxxqtable3">
                    <tr>
                        <td class="clicktd" colspan="10">
                            <div style="height:36px"><label id="lblCountdown"> </label></div>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper1">
                            1
                        </td>
                        <td class="clicktd" id="tdPaper2">
                            2
                        </td>
                        <td class="clicktd" id="tdPaper3">
                            3
                        </td>
                        <td class="clicktd" id="tdPaper4">
                            4
                        </td>
                        <td class="clicktd" id="tdPaper5">
                            5
                        </td>
                        <td class="clicktd" id="tdPaper6">
                            6
                        </td>
                        <td class="clicktd" id="tdPaper7">
                            7
                        </td>
                        <td class="clicktd" id="tdPaper8">
                            8
                        </td>
                        <td class="clicktd" id="tdPaper9">
                            9
                        </td>
                        <td class="clicktd" id="tdPaper10">
                            10
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper11">
                            11
                        </td>
                        <td class="clicktd" id="tdPaper12">
                            12
                        </td>
                        <td class="clicktd" id="tdPaper13">
                            13
                        </td>
                        <td class="clicktd" id="tdPaper14">
                            14
                        </td>
                        <td class="clicktd" id="tdPaper15">
                            15
                        </td>
                        <td class="clicktd" id="tdPaper16">
                            16
                        </td>
                        <td class="clicktd" id="tdPaper17">
                            17
                        </td>
                        <td class="clicktd" id="tdPaper18">
                            18
                        </td>
                        <td class="clicktd" id="tdPaper19">
                            19
                        </td>
                        <td class="clicktd" id="tdPaper20">
                            20
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper21">
                            21
                        </td>
                        <td class="clicktd" id="tdPaper22">
                            22
                        </td>
                        <td class="clicktd" id="tdPaper23">
                            23
                        </td>
                        <td class="clicktd" id="tdPaper24">
                            24
                        </td>
                        <td class="clicktd" id="tdPaper25">
                            25
                        </td>
                        <td class="clicktd" id="tdPaper26">
                            26
                        </td>
                        <td class="clicktd" id="tdPaper27">
                            27
                        </td>
                        <td class="clicktd" id="tdPaper28">
                            28
                        </td>
                        <td class="clicktd" id="tdPaper29">
                            29
                        </td>
                        <td class="clicktd" id="tdPaper30">
                            30
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper31">
                            31
                        </td>
                        <td class="clicktd" id="tdPaper32">
                            32
                        </td>
                        <td class="clicktd" id="tdPaper33">
                            33
                        </td>
                        <td class="clicktd" id="tdPaper34">
                            34
                        </td>
                        <td class="clicktd" id="tdPaper35">
                            35
                        </td>
                        <td class="clicktd" id="tdPaper36">
                            36
                        </td>
                        <td class="clicktd" id="tdPaper37">
                            37
                        </td>
                        <td class="clicktd" id="tdPaper38">
                            38
                        </td>
                        <td class="clicktd" id="tdPaper39">
                            39
                        </td>
                        <td class="clicktd" id="tdPaper40">
                            40
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper41">
                            41
                        </td>
                        <td class="clicktd" id="tdPaper42">
                            42
                        </td>
                        <td class="clicktd" id="tdPaper43">
                            43
                        </td>
                        <td class="clicktd" id="tdPaper44">
                            44
                        </td>
                        <td class="clicktd" id="tdPaper45">
                            45
                        </td>
                        <td class="clicktd" id="tdPaper46">
                            46
                        </td>
                        <td class="clicktd" id="tdPaper47">
                            47
                        </td>
                        <td class="clicktd" id="tdPaper48">
                            48
                        </td>
                        <td class="clicktd" id="tdPaper49">
                            49
                        </td>
                        <td class="clicktd" id="tdPaper50">
                            50
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper51">
                            51
                        </td>
                        <td class="clicktd" id="tdPaper52">
                            52
                        </td>
                        <td class="clicktd" id="tdPaper53">
                            53
                        </td>
                        <td class="clicktd" id="tdPaper54">
                            54
                        </td>
                        <td class="clicktd" id="tdPaper55">
                            55
                        </td>
                        <td class="clicktd" id="tdPaper56">
                            56
                        </td>
                        <td class="clicktd" id="tdPaper57">
                            57
                        </td>
                        <td class="clicktd" id="tdPaper58">
                            58
                        </td>
                        <td class="clicktd" id="tdPaper59">
                            59
                        </td>
                        <td class="clicktd" id="tdPaper60">
                            60
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper61">
                            61
                        </td>
                        <td class="clicktd" id="tdPaper62">
                            62
                        </td>
                        <td class="clicktd" id="tdPaper63">
                            63
                        </td>
                        <td class="clicktd" id="tdPaper64">
                            64
                        </td>
                        <td class="clicktd" id="tdPaper65">
                            65
                        </td>
                        <td class="clicktd" id="tdPaper66">
                            66
                        </td>
                        <td class="clicktd" id="tdPaper67">
                            67
                        </td>
                        <td class="clicktd" id="tdPaper68">
                            68
                        </td>
                        <td class="clicktd" id="tdPaper69">
                            69
                        </td>
                        <td class="clicktd" id="tdPaper70">
                            70
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper71">
                            71
                        </td>
                        <td class="clicktd" id="tdPaper72">
                            72
                        </td>
                        <td class="clicktd" id="tdPaper73">
                            73
                        </td>
                        <td class="clicktd" id="tdPaper74">
                            74
                        </td>
                        <td class="clicktd" id="tdPaper75">
                            75
                        </td>
                        <td class="clicktd" id="tdPaper76">
                            76
                        </td>
                        <td class="clicktd" id="tdPaper77">
                            77
                        </td>
                        <td class="clicktd" id="tdPaper78">
                            78
                        </td>
                        <td class="clicktd" id="tdPaper79">
                            79
                        </td>
                        <td class="clicktd" id="tdPaper80">
                            80
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper81">
                            81
                        </td>
                        <td class="clicktd" id="tdPaper82">
                            82
                        </td>
                        <td class="clicktd" id="tdPaper83">
                            83
                        </td>
                        <td class="clicktd" id="tdPaper84">
                            84
                        </td>
                        <td class="clicktd" id="tdPaper85">
                            85
                        </td>
                        <td class="clicktd" id="tdPaper86">
                            86
                        </td>
                        <td class="clicktd" id="tdPaper87">
                            87
                        </td>
                        <td class="clicktd" id="tdPaper88">
                            88
                        </td>
                        <td class="clicktd" id="tdPaper89">
                            89
                        </td>
                        <td class="clicktd" id="tdPaper90">
                            90
                        </td>
                    </tr>
                    <tr>
                        <td class="clicktd" id="tdPaper91">
                            91
                        </td>
                        <td class="clicktd" id="tdPaper92">
                            92
                        </td>
                        <td class="clicktd" id="tdPaper93">
                            93
                        </td>
                        <td class="clicktd" id="tdPaper94">
                            94
                        </td>
                        <td class="clicktd" id="tdPaper95">
                            95
                        </td>
                        <td class="clicktd" id="tdPaper96">
                            96
                        </td>
                        <td class="clicktd" id="tdPaper97">
                            97
                        </td>
                        <td class="clicktd" id="tdPaper98">
                            98
                        </td>
                        <td class="clicktd" id="tdPaper99">
                            99
                        </td>
                        <td class="clicktd" id="tdPaper100">
                            100
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            已答对 :
                        </td>
                        <td class="tctable">
                        </td>
                        <td>
                            <label id="lblProperTrue">
                            </label>
                        </td>
                        <td colspan="2">
                            已答错 :
                        </td>
                        <td class="homebox">
                        </td>
                        <td>
                            <label id="lblProperFalse">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            未答题 :
                        </td>
                        <td style="border: #a2d0e5 1px solid; background-color: White">
                        </td>
                        <td>
                            <label id="lblPrperSpace">
                            </label>
                        </td>
                        <td colspan="3">
                            <input id="btnSubmit" type="submit" value="提交试卷" />
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</body>
</html>
