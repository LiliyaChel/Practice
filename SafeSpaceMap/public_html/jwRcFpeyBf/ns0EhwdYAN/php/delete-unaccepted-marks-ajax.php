<?php
$bd=new mysqli('localhost', 'k91111f0_ssm', 'Ssm49495798', 'k91111f0_ssm');
if($bd->connect_errno)
{
	echo -1;
}
else
{
    try
	{
	    $bd->set_charset('utf8');
	    $sql = "DELETE FROM unchecked WHERE unchecked.id IN (".mysqli_real_escape_string($bd, $_POST['no']).")";
		$bd->query($sql);
		echo 1;
	}
	catch(Exception $e)
	{
		echo -2;
	} 
}

?>