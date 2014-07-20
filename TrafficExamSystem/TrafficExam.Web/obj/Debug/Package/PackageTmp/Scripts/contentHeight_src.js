/*树形菜单使用*/
function IsExplorer()
{
    var Sys = {};
    var ua = navigator.userAgent.toLowerCase();
    window.ActiveXObject ? Sys.ie = ua.match(/msie ([\d.]+)/)[1] :
    document.getBoxObjectFor ? Sys.firefox = ua.match(/firefox\/([\d.]+)/)[1] :
    window.MessageEvent && !document.getBoxObjectFor ? Sys.chrome = ua.match(/chrome\/([\d.]+)/)[1] :
    window.opera ? Sys.opera = ua.match(/opera.([\d.]+)/)[1] :
    window.openDatabase ? Sys.safari = ua.match(/version\/([\d.]+)/)[1] : 0;
    return Sys;
};

function checkItem(e, allName)
{
    var all = document.getElementsByName(allName)[0];

    if (!e.checked) all.checked = false;
    else
    {
        var aa = e.form.elements;
        for (var i = 0; i < aa.length; i++)
        {
            if (aa[i].type == "checkbox" && aa[i].id != "allChk" && aa[i].id != e.id)
            {
                if (!aa[i].checked) return;
            }
        }
        all.checked = true;
    }
};

function SelectAll(tempControl)
{
    //将除头模板中的其它所有的CheckBox取反 

    var theBox = tempControl;
    xState = theBox.checked;

    elem = theBox.form.elements;
    for (i = 0; i < elem.length; i++)
        if (elem[i].type == "checkbox" && elem[i].id != theBox.id)
        {
            if (elem[i].checked != xState)
                elem[i].click();
        }
};

var isExp = IsExplorer();
var tHeight = 340;
//以下进行测试 

if (isExp.safari) tHeight = 436;

if (isExp.ie) tHeight = 0.82;
if (isExp.firefox) tHeight = 0.80;
if (isExp.chrome) tHeight = 406;
if (isExp.opera) tHeight = 400;
if (isExp.safari) tHeight = 436; 