
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="Keywords" content="四川理工学院计算机学院专业信息平台">
<meta name="Description" content="四川理工学院计算机学院专业信息平台">
<title>首页_四川理工学院计算机学院专业信息平台</title>
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
				<!-- 加载一级菜单 -->
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
				<!--
                <li><a href="view.php?cid=1" rel='dropmenu51'>专业概况</a></li>
                <li><a href="view.php?cid=2" rel='dropmenu52'>师资队伍</a></li>
                <li><a href="view.php?cid=3" rel='dropmenu53'>专业动态</a></li>
                <li><a href="view.php?cid=4" rel='dropmenu55'>教学工作</a></li>
                <li><a href="view.php?cid=5" rel='dropmenu56'>科学研究</a></li>
                <li><a href="view.php?cid=6" rel='dropmenu58'>校友风采</a></li>
                <li><a href="view.php?cid=7" rel='dropmenu59'>招生就业</a></li>
                <li><a href="view.php?cid=8" rel='dropmenu60'>资源下载</a></li>
                <li><a href="view.php?cid=9">留言板</a></li>
				-->
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
		   <!--
           <ul id="dropmenu51" class="dropMenu">
            <li><a href="view.php?cid=10">培养方案</a></li>
            <li><a href="view.php?cid=11">专业介绍</a></li>
           </ul>
           <ul id="dropmenu52" class="dropMenu">
             <li><a href="view.php?cid=12">师资队伍介绍</a></li>
             <li><a href="view.php?cid=13">专业负责人</a></li>
             <li><a href="view.php?cid=14">教学团队</a></li>
           </ul>
           <ul id="dropmenu55" class="dropMenu">
              <li><a href="view.php?cid=15">教学改革</a></li>
              <li><a href="view.php?cid=16">课程建设</a></li>
              <li><a href="/view.php?cid=17">教材建设</a></li>
              <li><a href="view.php?cid=18">实践教学</a></li>
              <li><a href="view.php?cid=19">大学生创新创业训练计划</a></li>
              <li><a href="view.php?cid=20">大学生竞赛</a></li>
           </ul>
           <ul id="dropmenu59" class="dropMenu">
              <li><a href="view.php?cid=21">生源信息</a></li>
              <li><a href="view.php?cid=22">就业情况</a></li>
          </ul>
		  -->
         <script type="text/javascript">cssdropdown.startchrome("navMenu")</script>
    </div>
    <div class="block1 clearfix">
                 <div class="block1_l fl">
                    <div class="flv">
                        <ol id="imgslide" class="kandySlide">
                            <li class="tabtitle">
                                <span class="tabbtn">1</span>
                                <span class="tabbtn">2</span>
                                <span class="tabbtn">3</span>
                                <span class="tabbtn">4</span>
                                <span class="tabbtn">5</span>
                            <li class="tabbody" style="position: relative; overflow: hidden; height: 258px;">
                                <div class="tabcont" style="display: none; float: left; position: absolute; width: 298px; z-index: 5;">
                                 <a href="#" target="_blank">
                                    <img border="0" src="./images/1.jpg" width="294" height="254">
                                </a>
                                </div>
                                <div class="tabcont" style="display: block; float: left; position: absolute; width: 298px; z-index: 0;">
                                    <a href="#" target="_blank">
                                        <img border="0" src="./images/2.jpg" width="294" height="254">
                                    </a>
                                </div>
                                <div class="tabcont" style="display: none; float: left; position: absolute; width: 298px; z-index: 5;">
                                    <a href="#" target="_blank">
                                        <img border="0" src="./images/3.jpg" width="294" height="254">
                                    </a>
                                </div>
                                <div class="tabcont" style="display: none; float: left; position: absolute; width: 298px; z-index: 5;">
                                    <a href="#" target="_blank">
                                        <img border="0" src="./images/4.jpg" width="294" height="254">
                                    </a>
                                </div>
                                <div class="tabcont" style="display: none; float: left; por="0" src="./images/nave.jpg" width="294" height="254">
                               
                                    <a href="#" target="_blank">
                                         <img border="0" src="./images/5.jpg" width="294" height="254">
                                    </a>
                                </div>
                            </li>
                        </ol>
                    </div>
                </div>
                <div class="block1_m fl">
                    <div class="block_t1 clearfix">
                        <div class="block_t_l fl">专业介绍</div>
                    </div>
                    <div class="box_con">
                        <p><span style="font-family:simsun, 'microsoft YaHei', SimHei, sans-serif;color:#2e2f2e;"></span></p>
                        <p class="p0" style="text-indent:21.0000pt;">
	                    <span style="color:#FF9900;">计算机学院</span>四川理工学院计算机专业创建于1986年，2001年成立计算机科学系，2008年成立计算机学院。现设有计算机科学与技术系、软件工程系、网络工程系、电子商务系、计算机基础教育中心、实验中心等六个二级教学部门，开办有计算机科学与技术、软件工程、网络工程、电子商务、信息管理与信息系统、物联网工程六个本科专业，“信息管理与电子商务”、“企业信息系统与工程”两个硕士点，具有“计算机技术”专业工程硕士招生资格。拥有院士（专家）工作站、“企业信息化与物联网测控技术”四川省高校重点实验室和省级“智慧旅游”重点研究基地。</p>
                        <p><br /></p>
                        <p><br /></p>
                    </div>
                </div>
                <div class="block2_r fl">
                    <div class="block_t3 clearfix">
                      <div class="block_t_l fl">专业动态</div>
                      <div class="block_t_r fr"><a href="view.php?cid=3">更多&gt;&gt;</a></div>
                    </div>
                    <div class="box">
                       <div class="news_wrap clearfix">
                        <div class="news_con">
                            <ul class="news_list">
                                <li class="clearfix">
                                    <?php
                                    $id = 3; //专业动态id
                                    $sql ="select  * from news where categoryId = ".$id;
                                    $news = $db->query($sql);
                                    while($arr = mysql_fetch_array($news))
                                    {
                                        
                                         $res2 = $arr['newsId'];
                                         $res3 = $arr['title'];
                                         echo "<a href='view.php?cid=".$id."&newsId=".$res2."'>".$res3."</a><br/>";
                                     
                                    }
                                    ?>
                                </li>
                            </ul>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="block2 clearfix">
            <div class="block2_l fl">
                <div class="col">
                    <div class="block_t2 clearfix">
                        <div class="block_t_l fl">科学研究</div>
                        <div class="block_t_r fr"><a href="view.php?cid=5" target="_blank">更多&gt;&gt;</a></div>
                    </div>
                    <div class="info">
                        <ul class="info_list">
                            <li>
							    <?php
                                    $id=5; //科学研究id
                                    $sql ="select * from news where categoryId = ".$id;
                                    $news = $db->query($sql);
                                    while($result = mysql_fetch_array($news))
                                    {
									     $newsid = $result['newsId'];
                                         $title = $result['title'];
										 $date = $result['date'];
                                         echo "<p class="."fl news"."><a href='view.php?cid=".$id."&newsId=".$newsid."'>".$title."</a></p>";
										 echo "<p class="."time fr"." align = right>".$date."</p>";
                                         
                                    }
                                    ?>
						
                            </li>
                        </ul>
                    </div>
                </div><br/>
            </div>
            <div class="block2_m fl">
                <div class="col">
                    <div class="block_t2 clearfix">
                        <div class="block_t_l fl">教学工作</div>
                        <div class="block_t_r fr"><a href="view.php?cid=4" target="_blank">更多&gt;&gt;</a></div>
                    </div>
                    <div class="info">
                        <ul class="info_list">
                            <li>
                                <?php
                                    $id=4; //教学工作id
                                    $sql ="select * from news where categoryId = ".$id;
                                    $news = $db->query($sql);
                                    while($result = mysql_fetch_array($news))
                                    {
									     $newsid = $result['newsId'];
                                         $title = $result['title'];
										 $date = $result['date'];
                                         echo "<p class="."fl news"."><a href='view.php?cid=".$id."&newsId=".$newsid."'>".$title."</a></p>";
										 echo "<p class="."time fr"." align = right>".$date."</p>";
                                         
                                    }
                                    ?>
                            </li>
                        </ul>
                    </div>
                </div><br/>
            </div>
            <div class="block2_r fl">
                <div class="box">
                    <div class="box_con"></div>
                </div>
            </div>
        </div>
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
                    <span>版权所有：四川理工学院 计算机学院 </span>
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