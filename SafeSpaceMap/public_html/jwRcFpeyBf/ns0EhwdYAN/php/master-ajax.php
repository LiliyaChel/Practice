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
	    $sql = "SELECT COUNT(*) FROM master WHERE password = MD5('".mysqli_real_escape_string($bd, $_POST['password'])."')";
		$bd->set_charset('utf8');
		if (!$result = $bd->query($sql)) { throw new Exception('Нет результата'); }
        if ($result->num_rows === 0) { throw new Exception('Результат пустой'); }
		$data = $result->fetch_all();
		echo $data[0][0];
	}
	catch(Exception $e)
	{
		echo -2;
	} 
}

?>