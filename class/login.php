<?php
session_start();
if(isset($_POST['btnLogin']) && $_POST['btnLogin'] == 'login')
{
   require('conn.class.php');
   $username = strtolower($_POST['user']);
   $pwd = $_POST['pwd'];
   $verifycode = $_POST['code'];
   if($_SESSION['randcode'] == $verifycode)
   {
  		mysql_query('set names utf8');
		$sql = "select * from user where username  = '$username'";
   		$result = $db->query($sql);
		$count = mysql_num_rows($result);
  		if($count > 0)
   		{
		    $res = mysql_fetch_array($result);
       		if($res['password'] == $pwd)
	   		{
	       		header('Location:admin/index.html');
	   		}
	   		else
	   		{
	       		echo "<script>alert('密码错误');</script>";
	   		}
   		}
   		else
   		{
       		echo "<script>alert('该用户不存在');</script>";
   		}
   }
   else
   {
      echo "<script>alert('验证码错误');</script>";
   }
}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="admin/bootstrap/css/bootstrap.css" />
<link rel="stylesheet" href="admin/css/login.css" />
<title>后台登录</title>
</head>
<body>
<div class="container">
<form class="form-signin" role="form" action="" method="post">
	<h2 class="form-sigin-heading">登录</h2>
	<input type="text" class="form-control" placeholder="用户名"  name = "user" required autofocus />
	<input type="password" class="form-control" placeholder="密码" name = "pwd" required />
	<input type="text" class="form-control" placeholder="验证码"  name = "code" required/><br />
	<img src="verify.php" onclick="javascript:this.src='verify.php'" alt="验证码"  align="left"/><label style="width:120px" ></label><input type="checkbox" value="remeber me" align="right" />记住我<br />
	 <button class="btn btn-lg btn-primary btn-block" type="submit" name="btnLogin" value="login">登录</button>
</form>
</div>
</body>
</html>