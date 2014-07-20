<?php
   class mysql
   {
       private $host;
       private $root;
       private $pwd;
       private $database;
       private $conn;   
       function __construct($host,$root,$pwd,$database)
       {
       	  $this->host = $host;
       	  $this->root = $root;
       	  $this->pwd = $pwd;
       	  $this->database = $database;
       	  $this->connect();
       }
       function connect()
       {
       	  $this->conn=mysql_connect($this->host,$this->root,$this->pwd);
       	  mysql_select_db($this->database);
       	  mysql_query("set names utf8");
       }
	   function query($sql)
	   {
	       return mysql_query($sql);
	   }
   }
   $db = new mysql("127.0.0.1","root","","class");
?>