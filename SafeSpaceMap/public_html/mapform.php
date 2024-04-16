<?php

$bd=new mysqli('localhost', 'k91111f0_ssm', 'Ssm49495798', 'k91111f0_ssm');
if($bd->connect_errno)
{
	$categoriesData = -1;
}
else
{
    try
	{
	    $sql = "SELECT * FROM groups";
		$bd->set_charset('utf8');
		if (!$result = $bd->query($sql)) { throw new Exception('Нет результата'); }
        if ($result->num_rows === 0) { $categoriesData = -3; }
        else { $categoriesData = $result->fetch_all(); }
	}
	catch(Exception $e)
	{
		$categoriesData = -2;
	} 
}

include("html/mapform.html");

?>