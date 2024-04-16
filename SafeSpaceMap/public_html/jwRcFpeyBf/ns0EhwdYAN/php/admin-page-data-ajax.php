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
	    $sql = "SELECT id, lati, longi, dattim, groupid, cmmnt FROM unchecked";
		$bd->set_charset('utf8');
		if (!$result = $bd->query($sql)) { throw new Exception('Нет результата'); }
        if ($result->num_rows === 0) { echo -3; }
        else
        {
            $data = $result->fetch_all();
		    echo json_encode($data);
        }
	}
	catch(Exception $e)
	{
		echo -2;
	} 
}

?>