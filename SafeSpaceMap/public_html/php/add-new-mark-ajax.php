<?php

$bd = new mysqli('localhost', 'k91111f0_ssm', 'Ssm49495798', 'k91111f0_ssm');
if($bd->connect_errno)
{
	echo -1;
}
else
{
    try
	{
	    $bd->set_charset('utf8');
	    if (isset($_POST['lati']) && isset($_POST['longi']) && isset($_POST['dattim'])&& isset($_POST['groupid']) && isset($_POST['cmmnt']))
	    {
	        $sql = "INSERT INTO unchecked (lati, longi, dattim, groupid, cmmnt) VALUES (".mysqli_real_escape_string($bd, $_POST['lati']).", ".mysqli_real_escape_string($bd, $_POST['longi']).", '".mysqli_real_escape_string($bd, $_POST['dattim'])."', ".mysqli_real_escape_string($bd, $_POST['groupid']).", '".mysqli_real_escape_string($bd, $_POST['cmmnt'])."')";
            if (!$result = $bd->query($sql)) { throw new Exception('Нет результата'); }
    	    echo 1;
	    }
	    else { throw new Exception('Недостаточно данных'); }

	}
	catch(Exception $e)
	{
		echo -2;
	} 
}

?>