<?php 
if (isset($_POST['action']) && $_POST['action'] == 'submitted') { 
    print '<pre>'; 

    print_r($_POST); 
    print '<a href="'. $_SERVER['PHP_SELF'] .'">Please try again</a>'; 

    print '</pre>'; 
} else { 
?> 
<form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="POST"> 
    Name:  <input type="text" name="personal[name]"><br> 
    Email: <input type="text" name="personal[email]"><br> 
    Beer: <br> 
    <select multiple name="beer[]"> 
        <option value="warthog">Warthog 
        <option value="guinness">Guinness 
    </select><br> 
    <input type="hidden" name="action" value="submitted"> 
    <input type="submit" name="submit" value="submit me!"> 
</form> 
<?php 
} 
?>  