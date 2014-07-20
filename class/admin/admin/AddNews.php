<?php
require('../../conn.class.php');
mysql_query('set names utf8');
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta http-equiv="content-type" content="text/html"; charset="utf8" >
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>添加新闻</title>
    <!-- Bootstrap -->
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" />
	<link rel="stylesheet" href="../../kindeditor/themes/default/default.css" />
	<script charset="utf8" src="../js/jquery.js" language="javascript" ></script>
	<script charset="utf8" src="../js/selectMenu.js" language="javascript"></script>
	<script charset="utf-8" src="../../kindeditor/kindeditor-min.js"></script>
	<script charset="utf-8" src="../../kindeditor/lang/zh_CN.js"></script>
		<script>
			var editor;
			KindEditor.ready(function(K) {
				editor = K.create('textarea[name="content"]', {
					allowFileManager : true
				});
			});
		</script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
   <body>
   <?php
   if(isset($_POST['btnAddnews']) && $_POST['btnAddnews'] == "addnews")
	{
         $categoryId =  $_POST['sMenu']; //取得选中的值
		 $className =  $_POST['sMenu'];
		 $newstitle = $_POST['title'];
         $newscontent = $_POST['content'];;
		 $author = "蔡金林";
		 $current = date("Y-m-d H:i:m");
		 $sql = "insert into news(title,content,category,categoryId,author,date) values('$newstitle', '$newscontent','$className', '$categoryId', '$author', '$current')";
		 $result = $db->query($sql);
		 if($result)
		 {
   			echo "<script> alert('添加成功');</script>";
		}
		else
		{
  			die('error:'.mysql_error());
		}
	}
	if(isset($_POST['btnReset']) && $_POST['btnReset'] == "resetnews")
	{
        document.getElementById("cont").value == "";
	}
   ?>
  <div style="padding-top:20px">
 <form class="form-horizontal" role="form" action="AddNews.php" method="post">
   <div class="form-group">
   		<label for="lblFmenu" class="col-sm-2 control-label">一级分类</label>
  		<div class="col-sm-5">
  			<select class="form-control" onchange="showSecondMenu(this.value)">
   			<?php
			$sql = "select categoryId, className from Category where parentId = 0";
			$result = $db->query($sql);
			while($res = mysql_fetch_array($result))
			{
			?>
				<option value="<?php echo $res['categoryId'];?>"><?php echo $res['className'];?></option>
			<?php	
			}
			?>
  			</select>
   		</div>
   </div>
    <div class="form-group">
   		<label for = "lblSmenu" class="col-sm-2 control-label">二级分类</label>
		<div class="col-sm-5">
    		 <select class="form-control" name="sMenu" id="sMenu">
	 		 </select>
		</div>
   </div>
   <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">新闻标题</label>
    <div class="col-sm-5">
      <input type="text" class="form-control" name="title" placeholder="title">
    </div>
  </div>
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">新闻内容</label>
    <div class="col-sm-5">
     <textarea name="content" style=" height:400px;visibility:hidden;" id="cont">KindEditor</textarea>
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-5">
       <div class="col-sm-6">
	   <button type="submit" class="btn btn-lg btn-primary btn-block" name="btnAddnews" value="addnews">添加新闻</button>
	   </div>
	   <div class="col-sm-6" style="float:left">
	   <button type="reset" class="btn btn-lg btn-primary btn-block" name="btnReset" value="resetnews">新闻重置</button>
	   </div>
    </div>
  </div>
</form>
</div>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="../../js/jquery.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="../bootstrap/js/bootstrap.js"></script>
  </body>
</html>