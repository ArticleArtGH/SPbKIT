<?php
    $first_name = $_REQUEST["userName"];
    $second_name = $_REQUEST["userSurname"];
    $mail = $_REQUEST["userMail"];
    $curs = $_REQUEST["courses"];
    //$check = $_REQUEST["check"]; типо для chekbox надо так инач
    if(isset($first_name)&&isset($second_name)&&isset($mail)){
        $str = "Здравствуйте, ".$first_name." ".$second_name."! <br>";
        $str .= "Вы выбрали для изучения курс по ".$curs."<br>";
    } else {
        $str = "Вы ввели не все данные !<br>";
    }
    if(isset($_REQUEST["check"])){
        if($_REQUEST["check"]=='on'){
        $str .= " <br>Вам сообщение будет отправлено на почту";
        }
    }
    echo $str;
    // function clstr($data){
    //     return trim (stup_tags($data));
    // }//Для защиты от неправильных вводов пользователей, иначе сайт крякниться
    ?>