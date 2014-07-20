<?php
require('../../conn.class.php');
mysql_query('set names utf8');

   $newsid = $_GET['id'];
   $title = $_POST['title'];
   $content = $_POST['content'];
   $categoryId = $_POST['class'];
   $sql = "update news set title = '$title' , content = '$content',categoryId = '$categoryId' where newsId = '$newsid'";
   $result = $db->query($sql);
   if($result)
   {
       header('Location:NewsList.php');
   }
   else
   {
       die('Error:'.mysql_error());
   }

