$(document).ready(function() {    
     init();   
 });
 function init() 
 {
     $.ajax({ global: true, url: "IndexRequest.aspx", data: { ActionName: "GetLoginName" },
         success: function (data) {
             if (data != null) {
                 ShowLoginName(data);
             }
         },
         error: function (e) 
         {
             alert(e);
         },
         dataType: "json",
         type: "POST",
         async: true
     });
 }
 function ShowLoginName(oLists) {
     $("#username").html("");
     $("#username").append($("<option value=\"0\">－请选择用户登录名－</option>"));
     for (var i = 0; i < oLists.SystemUser.length; i++) {
         var user = oLists.SystemUser[i];
         $("#username").append($("<option value=\"" + user.LoginName + "\">" + user.LoginName + "</option>"));
     }  
 }
