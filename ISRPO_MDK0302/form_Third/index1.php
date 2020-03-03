<link rel = 'stylesheet' href = 'style_index.css'><!--подключение стили-->
<?php
    // echo "<link rel = 'stylesheet' href = 'style_index.css'>";//подключение стили
    $times = array("PHP"=>"14.30", "C++"=>"15.00", "LISP"=>"12.30", "UNIX"=>"10.30");
    $lectors = array("PHP"=>"Васильев", "C++"=>"Иванов", "LISP"=>"Петров", "UNIX"=>"Сидоров");
    $name1 = $_POST["userName"];
    $name2 = $_POST["userSurname"];
    $str ="Здравствуйте, уважаемый ".$name1." ".$name2."!<br>";
    $str .= "Сообщаем Вам, что ";

    if(!isset($_POST["course"])){//т.к. сheckbox, поэтому так получилось прописали 
        //не переменную в if.
        $str .= "Собрание состоится 12 мая в 12.00<br>";
    }else{
        $courses = $_POST["course"];
        $str .= "выбранная вами лекция состоится 12 мая <br>";
        $str .= "<ul class = 'course'>";
        for($i = 0; $i<count($courses); $i++){
            $c = $courses[$i];
            $str .= "<li>лекция по $c в $times[$c]";
            $str .= " Ваш лектор - $lectors[$c] </li>";
        }
        $str .= "</ul>";}
    $str .= "<br> С увaжением, администрация";
    echo $str;
?>