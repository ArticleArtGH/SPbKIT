<?php
    $first_name = $_REQUEST["userName"];
    $second_name = $_REQUEST["userSurname"];
    $mail = $_REQUEST["userMail"];
    $curs = $_REQUEST["courses"];
    //$check = $_REQUEST["check"]; типо для chekbox надо так инач

    $times = array("PHP"=>"14.30", "C++"=>"15.00", "LISP"=>"12.30", "UNUX"=>"10.30");
    $lectors =array("PHP"=>"Васильев", "C++"=>"Иванов", "LISP"=>"Петров", "UNUX"=>"Сидоров");
    $name1 = $_POST['first_name'];
    $name2-$_POST['last_name'];
    $str ="Здравствуйте, уважаемый ".$name1." ".$name."<!br>";
    $str .= "Сообщаем Вам, что ";
    $curses = $_POST['courses'];

    if(!isset($curses))
        $str .= "Собрание состоится 12 мая в 12.00<br>";
    else{
        $str .= "выбранная вами лекция состоится 12 мая <br>";
        $str .= "<ul>";
        for($i = 0; $i<count($curses); $i++){
            
        }
    }


 
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