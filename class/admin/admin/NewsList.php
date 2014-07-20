<?php
require('../../conn.class.php');
mysql_query('set names utf8');
$sql = "select * from news";
$query = $db->query($sql);
$total = mysql_num_rows($query);//总记录数
$page_num = 3;//每页记录条数
$all_num = ceil($total/$page_num);//总页数
$page = empty($_GET['page'])?1:$_GET['page'];//当前页
$limit_st = ($page-1)*$page_num;//当前页起始记录数
$previous = ($page<=1)?1:$page-1;//上一页
$next = ($page>=$all_num)?$all_num:$page+1;
?>
<!DOCTYPE html>
<html lang="en">
<head>
<meta http-equiv="content-type" content="text/html"; charset="utf8" >
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>新闻展示</title>
<!-- Bootstrap -->
<link href="../bootstrap/css/bootstrap.css" rel="stylesheet">
<script language="javascript" src="../../js/jquery-1.8.2.min.js"></script>
<script>
windows.onload=function() ({
   alert('hello');
 });
</script>
<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
      <script charset="utf8" src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script charset="utf8" src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<style type="text/css">
.table
{
    background:#fff;
	color"#000;
}
.table tr
{
    height:30px;
	line-height:30px;
	color:#666666;
}
<br>

</style>
</head>
<body>
<div class="table-responsive">
<table class="table table-hover table-striped datagrid">
	<tr class="warning">
		<td width="10%">新闻标号</td>
		<td width="60%">新闻标题</td>
		<td width="10%">发布时间</td>
		<td width="10%">编辑</td>
		<td width="10%">删除</td>
	</tr>
	<?php
	$sql = "select * from news limit $limit_st, $page_num";
	$result=$db->query($sql);
	while($res = mysql_fetch_array($result))
	{
	   echo "<tr>";
	   echo "<td>".$res['newsId']."</td>";
	   echo "<td>".$res['title']."</td>";
	   echo "<td>".$res['date']."</td>";
	   echo "<td><a href=EditNews.php?id=".$res['newsId']." target=_main_area alt=编辑新闻 ><img src=../image/edit.gif />[编辑]</a></td>";
	   echo "<td><a href=DeleteNews.php?id=".$res['newsId']. " alt=删除新闻><img src=../image/delete.gif />[删除]</a></td>";
	   echo "</tr>";
	} 
	?>
	<!--
	<tr>
		<td>1</td>
		<td>2</td>
		<td>3</td>
		<td><a href="EditNews.php?categoryI" target="_main_area" alt="编辑新闻" ><img src="../image/edit.gif" />[编辑]</a></td>
		<td><a href="#" alt="删除新闻" ><img src="../image/delete.gif" />[删除]</a></td>
		
	</tr>
	<tr>
		<td>2</td>
		<td>3</td>
		<td>4</td>
		<td><a href="#" alt="编辑新闻" ><img src="../image/edit.gif" />[编辑]</a></td>
		<td><a href="#" alt="删除新闻" ><img src="../image/delete.gif" />[删除]</a></td
	></tr>
	-->
</table>
<div class="pull-left">
<ul class="pagination">
  <li><a>当前是第<?php echo "<font color=red>$page</font>";?>页</a></li>
  <li><a>总共是<?php echo "<font color=red>$all_num</font>";?>页</a></li>
</ul>
</div>
<div class="pull-right">
<ul class="pagination">
    <li class="disabled"><a href="#">&laquo;</a></li>
    <li><a href="NewsList.php?page=1">首页</a></li>
	<!--  <span class="sr-only">(current)</span></span> -->
    <li><a href="NewsList.php?page=<?php echo $previous ;?>">上一页</a></li>
    <li><a href="NewsList.php?page=<?php echo $next; ?>">下一页</a></li>
    <li><a href="NewsList.php?page=<?php echo $all_num;?>">尾页</a></li>
</ul>
</div>
</div>
</body>
</html>
