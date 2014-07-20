<?php
require('../../conn.class.php');
mysql_query('set names utf8');
$id = $_GET['id'];
$sql = "select * from news where newsId = ". $id;
$result = $db->query($sql);
$res = mysql_fetch_array($result);
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta http-equiv="Content-Type" content="text/html"; charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>更改新闻</title>
    <!-- Bootstrap -->
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet">
	<link rel="stylesheet" href="../../kindeditor/themes/default/default.css" />
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
 
   <div style="padding-top:20px">
 <form class="form-horizontal" role="form" action="UpdateNews.php?id=<?php echo $res['newsId'];?>" method="post">
   <div class="form-group">
   	<label for="inputPassword3" class="col-sm-2 control-label">新闻类型</label>
  	<div class="col-sm-5">
  	<select class="form-control" name="class">
	<?php
		$sql = "select categoryId, className from Category";
		$result2 = $db->query($sql);
		while($res2 = mysql_fetch_array($result2))
		{
		    if($res2['categoryId']==$res['categoryId'])
			{
			   echo "<option value=".$res2['categoryId']." selected=selected >".$res2['className']."</option>";
			}
			else
			{
			    echo "<option value=".$res2['categoryId']." >".$res2['className']."</option>";
	     	}
		
	   }
	?>
  	</select>
   </div>
   </div>
  <div class="form-group">
    <label for="inputEmail3" class="col-sm-2 control-label">新闻标题</label>
    <div class="col-sm-5">
      <input type="text" class="form-control" name="title" placeholder="title" value="<?php echo $res['title'];?>">
    </div>
  </div>
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">新闻内容</label>
    <div class="col-sm-5">
     <textarea name="content" style="height:400px;visibility:hidden;"><?php echo $res['content'];?></textarea>
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-5">
       <div class="col-sm-6">
	   <button type="submit" class="btn btn-lg btn-primary btn-block" id="btnUpdate" value="UpdateNews">更改新闻</button>
	   </div>
	   <div class="col-sm-6" style="float:left">
	   <button type="reset" class="btn btn-lg btn-primary btn-block">取消更改</button>
	   </div>
    </div>
  </div>
</form>
</div>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="../bootstrap/js/bootstrap.js"></script>
  </body>

</html>