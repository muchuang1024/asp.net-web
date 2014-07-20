
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml">
<head><meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="Keywords" content="四川理工学院理学院专业信息平台">
<meta name="Description" content="四川理工学院理学院专业信息平台">
<title>首页_四川理工学院理学院专业信息平台</title>
<link rel="stylesheet" type="text/css" href="./css/home.css">
<link rel="stylesheet" type="text/css" href="./css/channel.css">
<script type="text/javascript" src="./js/jquery.js"></script>
<script type="text/javascript" src="./js/tabs.js"></script>
</head>
<body>
  <?php require("conn.class.php");mysql_query("set names utf8");?>
    <div class="top" id="top">
        <div class="top_img">
            <img src="./images/logo.gif" width="990" height="172"></div>
            <link rel="stylesheet" type="text/css" href="./css/nave.css">
            <script type='text/javascript' src='./js/dropdown.js'></script>
            <div id="navMenu">
                <ul>
                <li class="onelink"><a href='index.php'>主页</a></li>
				<!--  加载一级菜单 -->
                <?php
				$sql = "select categoryId, className, rel from Category where parentId = 0";
				$result = $db->query($sql);
				while($res = mysql_fetch_array($result))
				{
				?>
				<li><a href="view.php?cid=<?php echo $res['categoryId']; ?>" rel="<?php echo $res['rel']; ?>"><?php echo $res['className']; ?></a></li>
				<?php	
				}
				?>
               </ul>
           </div>
           <!-- 加载二级菜单 -->
		   <?php
		   $sql = "select categoryId, className, rel from Category where parentId = 0";
		   $result = $db->query($sql);
		   while($res = mysql_fetch_array($result))
		   {
		   ?>
		       <ul id="<?php echo $res['rel']; ?>" class="dropMenu">
			   <?php
		       $sql2menu = 'select categoryId, className, rel from Category where parentId = '.$res['categoryId'];
			   $smenu = $db->query($sql2menu);
			   while($res2menu = mysql_fetch_array($smenu))
			   {
			   ?>
			   <li><a href="view.php?cid=<?php echo $res2menu['categoryId']; ?>"><?php echo $res2menu['className'];?></a></li>
			   <?php
			   }
			   ?>
			   </ul>
		   <?php
		   }
		   ?>
         <script type="text/javascript">cssdropdown.startchrome("navMenu")</script>
    </div>
    <div id="main">
        <div class="Mleft">
            <div class="menu">
                <div class="block2_r fl">
                    <div class="block_t3 clearfix">
                        <div class="block_t_l fl">专业动态</div>
                        <div class="block_t_r fr">
                            <a href="view.php?cid=3">更多&gt;&gt;</a>
                        </div>
                    </div>
                    <br>
                    <div class="box">
                        <ul class="box_list">
						  <?php
                                    $id = 3; //专业动态id
                                    $sql ="select  * from news where categoryId = ".$id;
                                    $news = $db->query($sql);
                                    while($arr = mysql_fetch_array($news))
                                    {
                                        
                                         $res2 = $arr['newsId'];
                                         $res3 = $arr['title'];
										 echo "<li class=clearfix>";
                                         echo "<a href='view.php?cid=".$id."&newsId=".$res2."'>".$res3."</a>";
										 echo "</li>";
                                     
                                    }
                            ?>
						</ul>
                    </div>
                </div>
                <br>
                <div class="block2_r fl">
                    <div class="block_t3 clearfix">
                        <div class="block_t_l fl">科学研究</div>
                        <div class="block_t_r fr"><a href="view.php?cid=5">更多&gt;&gt;</a></div>
                    </div>
                    <br>
                    <div class="box">
                        <ul class="box_list">
                                     <?php
                                    $id=5; //科学研究id
                                    $sql ="select * from news where categoryId = ".$id;
                                    $news = $db->query($sql);
                                    while($result = mysql_fetch_array($news))
                                    {
									     $newsid = $result['newsId'];
                                         $title = $result['title'];
										 $date = $result['date'];
										 echo "<li class=clearfix>";
                                         echo "<a href='view.php?cid=".$id."&newsId=".$newsid."'>".$title."</a>";
                                         echo "</li>";
									}   
                                    ?>
                      
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="mainCont fr">
            <div class="titles">
                <a href="index.php">首页</a> &gt;&gt;
                <a href="view.php?cid=<?php echo $_GET['cid'];?>">
                <?php
                      $classId = $_GET['cid'];
                      $sql ="select * from category where categoryId = '$classId'";
                      $news = $db->query($sql);
                      while($arr = mysql_fetch_array($news))
                      {
                         echo $arr['className'];
                      }
                ?>
                </a> &gt;&gt; 
                <?php
                   if(isset($_GET['newsId']))
				   {
                     $flag = 1;//记录为正文还是列表
					 echo "正文";
					}
                   else
				   {
				     $flag = 0;
                     echo "列表";
				   }
                ?>
            </div>
            <div class="content">
                <div class="content_co">
				    <?php
					if($flag == 1)
					{
					       $sql = "select * from news where newsId = ".$_GET['newsId'];
						   $result = $db->query($sql);
						   $res = mysql_fetch_array($result);
					       echo "<div class=co_title><h1>".$res['title']."</h1><p>更新日期：".$res['date']."</p></div>";
                           echo "<div class=container_content>".$res['content']."</div>";
					} 
					else 
					{      echo "<ul class=news_list style=font-size:14px>";
					       $sql = "select * from news where categoryId= ".$_GET['cid'];
						   $result = $db->query($sql);
						   while($res = mysql_fetch_array($result))
						   {
						       echo "<li class=clearfix style=padding-top:5px>";
					           echo "<a href=view.php?cid=".$res['categoryId']."&newsId=".$res['newsId'].">".$res['title']."</a>";
							   echo "</li>";
						   }
						   echo "</ul>";
					}
					?>
            </div>
        </div>
    </div>
</div>
<div class="clear"></div>
        <div class="flink">
            <div class="flink_wrap clearfix">
                <div class="flink_t fl">相关链接：</div>&nbsp;
                <div class="flink_list fl">&nbsp;
                    <a href="http://www.suse.edu.cn/" target="_blank">四川理工学院</a>&nbsp;
                    <a href="http://61.139.105.143:10101/" target="_blank">教务处</a>&nbsp;
                </div>
            </div>
        </div>
        <div class="footer">
            <div class="footer_con">
                <p>
                    <span>版权所有：四川理工学院 理学院 </span>
                    <span>地址：四川省自贡市汇兴路学苑街180号</span>
                    <span>技术支持：<a href="http://caijinlin.github.io" target="_blank">蔡金林</a></span>
                </p>
                <p>
                   <span>
                    <a href="/lxy_sx/system.php"><span style="color:white;">[后台管理]</span></a>
                   </span>
                </p>
            </div>
        </div>
        <script language="javascript">   
         $(function(){
            $("#imgslide").KandyTabs({
            classes:"kandySlide",
            action:"slifade",
            stall:4000,
            type:"slide",
            btn     : "tabbtn",          // 符合KandyTabs结构的指定按钮元素。
            cont    : "tabcont",          // 符合KandyTabs结构的指定内容元素。
            auto:true,
            process:false,
            direct:"left",
            resize:false
        });
    })
</script>
</body>
</html>