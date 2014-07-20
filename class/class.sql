-- phpMyAdmin SQL Dump
-- version 3.4.10.1
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2014 年 07 月 20 日 07:28
-- 服务器版本: 5.5.20
-- PHP 版本: 5.3.10

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `class`
--

-- --------------------------------------------------------

--
-- 表的结构 `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `categoryId` int(11) NOT NULL AUTO_INCREMENT COMMENT '新闻类别代号',
  `className` varchar(20) NOT NULL COMMENT '新闻分类',
  `rel` varchar(20) NOT NULL DEFAULT '0' COMMENT '表示二级菜单与一级菜单的关系属性',
  `href` varchar(50) NOT NULL COMMENT '菜单链接',
  `parentId` int(5) NOT NULL DEFAULT '0' COMMENT '一级菜单id',
  PRIMARY KEY (`categoryId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COMMENT='新闻类别' AUTO_INCREMENT=19 ;

--
-- 转存表中的数据 `category`
--

INSERT INTO `category` (`categoryId`, `className`, `rel`, `href`, `parentId`) VALUES
(1, '专业概况', 'dropmenu1', 'view.php?cid=1', 0),
(2, '师资队伍', 'dropmenu2', 'view.php?cid=2', 0),
(3, '专业动态', 'dropmenu3', 'view.php?cid=3', 0),
(4, '教学工作', 'dropmenu4', 'view.php?cid=4', 0),
(5, '科学研究', 'dropmenu5', 'view.php?cid=5', 0),
(6, '校友风采', 'dropmenu6', 'view.php?cid=6', 0),
(7, '招生就业', 'dropmenu7', 'view.php?cid=7', 0),
(8, '资源下载', 'dropmenu8', 'view.php?cid=8', 0),
(9, '留言板', 'dropmenu9', 'view.php?cid=9', 0),
(10, '培养方案', '0', 'view.php?cid=10', 1),
(11, '专业介绍', '0', 'view.php?cid=1', 1),
(12, '教学团队', '0', 'view.php?cid=2', 2),
(13, '教学改革', '0', 'view.php?cid=.4', 4),
(14, '课程建设', '0', 'view.php?cid=.mysql_insert_id()', 4),
(15, '大学生竞赛', '0', 'view.php?cid=+=mysql_insert_id()', 4),
(16, '生源情况', '0', 'href', 7),
(17, '专业课件', '0', 'view.php?cid=1', 8),
(18, '学生作品', '0', 'view.php?cid=1', 8);

-- --------------------------------------------------------

--
-- 表的结构 `news`
--

CREATE TABLE IF NOT EXISTS `news` (
  `newsId` int(2) NOT NULL AUTO_INCREMENT COMMENT '新闻序号',
  `title` varchar(20) NOT NULL COMMENT '新闻标题',
  `content` text NOT NULL COMMENT '新闻内容',
  `category` varchar(20) NOT NULL COMMENT '新闻类别',
  `author` varchar(20) NOT NULL COMMENT '发布作者',
  `date` date NOT NULL COMMENT '发布时间',
  `categoryId` int(10) NOT NULL,
  PRIMARY KEY (`newsId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- 转存表中的数据 `news`
--

INSERT INTO `news` (`newsId`, `title`, `content`, `category`, `author`, `date`, `categoryId`) VALUES
(2, '专业', '发生大法师法顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶', '专业动态', '蔡金林', '2014-05-13', 5),
(3, '哈哈', '教学', '专业动态', '蔡金林', '2014-05-13', 3),
(4, '我校学生获四川省第六届大学生ACM程序设', '<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;text-indent:28pt;background:white;">\r\n	<span style="font-family:宋体;font-size:14pt;">2014</span><span style="font-family:宋体;font-size:14pt;">年四川省第六届大学生</span><span style="font-size:14pt;">ACM</span><span style="font-family:宋体;font-size:14pt;">程序设计竞赛，</span><span style="font-size:14pt;">6</span><span style="font-family:宋体;font-size:14pt;">月</span><span style="font-size:14pt;">8</span><span style="font-family:宋体;font-size:14pt;">日在电子科技大学清水河校区举行。计算机学院派两支队伍参赛，其中一支参赛代表队获省三等奖。</span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;text-indent:28pt;background:white;">\r\n	<span style="font-family:宋体;font-size:14pt;">本次竞赛，来自重庆大学、北京航天航空大学、四川大学、西南交大等全国</span><span style="font-size:14pt;">32</span><span style="font-family:宋体;font-size:14pt;">所高校、</span><span style="font-size:14pt;">2</span><span style="font-family:宋体;font-size:14pt;">所中学</span><span style="font-size:14pt;">102</span><span style="font-family:宋体;font-size:14pt;">支队伍参加比赛，每支参赛队伍由三人组成，每队使用一台电脑，在规定的五小时内解决</span><span style="font-size:14pt;">10</span><span style="font-family:宋体;font-size:14pt;">个难易程度不等的编程问题。</span><span style="font-size:9pt;"></span>\r\n</p>\r\n<p class="MsoNormal" align="center" style="text-align:justify;color:#444444;font-family:Simsun;text-indent:28pt;background:white;">\r\n	<span style="font-family:宋体;font-size:14pt;">本次竞赛，由四川省教育厅主办，电子科技大学承办，是四川省教育厅公布的2014年省级大学生竞赛项目之一，旨在展示大学生创新实践能力、团队协作精神、在压力下编写程序的能力以及分析问题和解决问题能力</span>\r\n</p>', '15', '蔡金林', '2014-06-22', 15),
(5, '计算机学院第一届网络安全技术竞赛获奖公告', '<span style="color:#FF0000;font-family:宋体;font-size:19px;line-height:25px;background-color:#FFFFFF;">\r\n<p class="MsoNormal" align="center" style="text-align:center;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;color:red;font-size:14pt;">计算机学院第一届网络安全技术竞赛获奖公告</span><span style="color:red;font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;color:red;font-size:14pt;">一等奖</span><span style="color:red;font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">网络工程</span><span style="font-size:14pt;">2012</span><span style="font-family:宋体;font-size:14pt;">级卓越班：</span><span style="font-size:14pt;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-family:宋体;font-size:14pt;">王登科</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;color:red;font-size:14pt;">二等奖</span><span style="color:red;font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">计算机科学与技术</span><span style="font-size:14pt;">2011</span><span style="font-family:宋体;font-size:14pt;">级</span><span style="font-size:14pt;">3</span><span style="font-family:宋体;font-size:14pt;">班：罗鹏</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">计算机科学与技术</span><span style="font-size:14pt;">2011</span><span style="font-family:宋体;font-size:14pt;">级</span><span style="font-size:14pt;">6</span><span style="font-family:宋体;font-size:14pt;">班：刘义</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">网络工程</span><span style="font-size:14pt;">2011</span><span style="font-family:宋体;font-size:14pt;">级卓越班：</span><span style="font-size:14pt;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-family:宋体;font-size:14pt;">余太元</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;color:red;font-size:14pt;">三等奖</span><span style="color:red;font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">网络工程</span><span style="font-size:14pt;">2011</span><span style="font-family:宋体;font-size:14pt;">级卓越班：</span><span style="font-size:14pt;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-family:宋体;font-size:14pt;">廖幸</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">网络工程</span><span style="font-size:14pt;">2012</span><span style="font-family:宋体;font-size:14pt;">级卓越班：</span><span style="font-size:14pt;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-family:宋体;font-size:14pt;">杨云山</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">食品质量与安全</span><span style="font-size:14pt;">2011</span><span style="font-family:宋体;font-size:14pt;">级</span><span style="font-size:14pt;">1</span><span style="font-family:宋体;font-size:14pt;">班：</span><span style="font-size:14pt;">&nbsp;&nbsp;</span><span style="font-family:宋体;font-size:14pt;">周游</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;background-color:#FFFFFF;">\r\n	<span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;text-indent:245pt;background-color:#FFFFFF;">\r\n	<span style="font-family:宋体;font-size:14pt;">计算机学院</span><span style="font-size:14pt;"></span>\r\n</p>\r\n<p class="MsoNormal" style="text-align:justify;color:#444444;font-family:Simsun;text-indent:224pt;background-color:#FFFFFF;">\r\n	<span style="font-size:14pt;">2014</span><span style="font-family:宋体;font-size:14pt;">年</span><span style="font-size:14pt;">6</span><span style="font-family:宋体;font-size:14pt;">月</span><span style="font-size:14pt;">16</span><span style="font-family:宋体;font-size:14pt;">日</span>\r\n</p>\r\n</span>', '15', '蔡金林', '2014-06-23', 15);

-- --------------------------------------------------------

--
-- 表的结构 `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL COMMENT '用户名',
  `password` varchar(20) NOT NULL COMMENT '密码',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- 转存表中的数据 `user`
--

INSERT INTO `user` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
