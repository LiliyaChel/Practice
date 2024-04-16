<?php
//TODO fix mail form
$name = $_POST['name'];
$email = $_POST['email'];
$message = $_POST['message'];

if(mail('safespacemap@mail.ru', 'Заполненная форма', 'Имя:'.$name.'. E-mail: '.$email.'\n'.$message)) echo 1; else echo "Error!";
?>