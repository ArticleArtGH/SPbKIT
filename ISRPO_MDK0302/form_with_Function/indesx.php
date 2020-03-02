<?php
    $user_name = $_REQUEST["userName"];
    $mail = $_REQUEST["userMail"];
    $group = $_REQUEST["groups"];
    $intial_value = $_REQUEST["intial_value"];
    $final_value = $_REQUEST["final_value"];
    $amount_step = $_REQUEST["amount_step"];
    
    if(isset($user_name)&&isset($mail)&&isset($intial_value)&&isset($final_value)&&isset($amount_step)){
        $str = "Выполнил: <label style='color: red;'>".$user_name."</label><br> Группа: <span style='color:red'>".$group."</span><br> Вычисление функции <br> <span style='color:blue'></span>";
        // "<p>F(x)=log(3*arctg(x))</p>"
    }else{
        $str = "Вы ввели не все данные !<br>";
    }
    echo $str;
    // //$check = $_REQUEST["check"]; типо для chekbox надо так инач
    // if(isset($first_name)&&isset($second_name)&&isset($mail)){
    //     $str = "Здравствуйте, ".$first_name." ".$second_name."! <br>";
    //     $str .= "Вы выбрали для изучения курс по ".$curs."<br>";
    // } else {
    //     $str = "Вы ввели не все данные !<br>";
    // }
    // if(isset($_REQUEST["check"])){
    //     if($_REQUEST["check"]=='on'){
    //     $str .= " <br>Вам сообщение будет отправлено на почту";
    //     }
    // }
    // echo $str;
    // // function clstr($data){
    // //     return trim (stup_tags($data));
    // // }//Для защиты от неправильных вводов пользователей, иначе сайт крякниться
    ?>
    
    <!DOCTYPE html>
    <html lang="ru">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta http-equiv="X-UA-Compatible" content="ie=edge">
        <title>Document</title>
    </head>
    <body>
        <table width="200px" border="1" style="text-align: center;">
            <caption style = "color:blue">F(x)=log(3*arctg(x))</caption>
            <tr style="background-image: url(background.jpg);">
                <td>
                    X
                </td>
                <td>
                    F(x)
                </td>
            </tr>
            <?php
            function func1_Math($x){
                return log(3*atan($x));//log - log с основание e, а log10 - log с основание 10 
            }

            $step = ($final_value - $intial_value) / $amount_step;
            $x = $intial_value;
            for ($i = 0; $i <= $amount_step; $i++)
            {   
                $y = func1_Math($x);
                $x = round($x, 2);
                $y = round($y, 2);
                echo("<tr><td>" . $x . "</td><td>" . $y . "</td></tr>");
                $x += $step;
            }           
            ?>
        </table>
    </body>
    </html>