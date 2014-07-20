<!DOCTYPE html>
<html lang="en">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>添加新闻</title>
    <!-- Bootstrap -->
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet">
  </head>
<body style="margin-top:20px">
<?php
require('../../conn.class.php');
mysql_query("set names utf8");
if(isset($_POST['btn_Add']) && $_POST['btn_Add'] == 'AddSecondMenu')
{
$className = $_POST['SecondMenu'];
$categoryId = $_POST['FirstMenu'];
$link = "view.php?cid=";
$id = mysql_insert_id()+1;
$href = $link.$id;
$sql = "insert into Category(className,href,parentId) values ('$className', '$href' ,'$categoryId')";
$result = $db->query($sql);
if($result)
{
   echo "<script> alert('添加成功');</script>";
}
else
{
  die('error:'.mysql_error());
}
  header('Location:AddSecondMenu.php');
}
else
{
?>
 <form class="form-horizontal" role="form" action="AddSecondMenu.php" method="post">
   <div class="form-group">
   		<label for="FirstMenu" class="col-sm-2 control-label">一级菜单</label>
  		<div class="col-sm-2">
  		<select class="form-control" name="FirstMenu">
		<?php
	 	$sql="select * from Category where parentId = 0";
	 	$result = $db->query($sql);
	  	while($res=mysql_fetch_array($result))
	 	{
	  	?>
	 	<option value=<?php echo $res["categoryId"]; ?>><?php echo $res["className"];?></option>
	   <?php
	 	}
		?>
  		</select>
   		</div>
   </div>
   <div class="form-group">
   		<label for="SecondMenu" class="col-sm-2 control-label">二级菜单</label>
 		<div class="col-sm-2">
   		<input type="text" class="form-control" name="SecondMenu"  placeholder="添加菜单" required autofocus />
   		</div>
   </div>
   <div class="form-group">
   		<div class="col-sm-offset-2 col-sm-2">
   		<button type="submit" class="btn btn-lg btn-primary btn-block" name="btn_Add" value="AddSecondMenu">添加</button>
   </div>
  </div>
 </form>
<?php
}
?>
 </body>
</body>
</html>

