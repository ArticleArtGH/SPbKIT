<!DOCTYPE html>
<html lang="ru">
    <head>
        <meta charset = "utf-8">
        <link href="style_index.css" rel="stylesheet">
        <title>Лабораторная 2</title>
    </head>
    <boby>
        <h1 class="FormH1">Форма</h1>
        <form action="#" method="get" name="form">
            <fieldset>
                <legend>Личные данные</legend>
                    <label for="userName">Имя:</label><input class="personal_data" id="userName" type="text" name="userName" placeholder="Имя"><br>
                    <!-- class="personal_data" -->
                    <label for="userSurname">Фамилия:</label><input class="personal_data" id="userSurname" type="text" name="userSurname" placeholder="Фамилия"><br>
                    <!-- Доабавил for и id для того чтобы слвязать label с input, теперь можно также, если
                    input был в label при нажатии на надпись активируется ячейка-->
                    <!-- class="personal_data" -->
                    <label for="userMail">Почта:</label><input class="personal_data" id="userMail" type="email" name="userMail" placeholder="example@mail.ru"><!-- Должна быть ПОЧТА - типа  EMAIL -->
                    <!-- class="personal_data" -->
            </fieldset>
            <fieldset>
                <legend>Регистрация на курс</legend>
                    <label>
                        <input type="checkbox" checked>Отправить уведомления<br><br><!-- у checkbox углы могут быть округлая форма - это особенности браузера -->
                        <!-- checked - по умолчанию стоит галочка -->
                        <!-- class="personal_data" -->
                        <label>Выберите курс:</label><br><br>
                        <select name="courses" multiple size="5px">
                            <option value="c++">c++</option>
                            <option value="JavaScript"selected>JavaScript</option>
                            <!-- selected - по умолчанию выбранный элемент,
                            а ещё можно для несколки значений одного и того же name="exaple[]"-->
                            <option value="Python" selected>Python</option>
                            <option value="Java">Java</option>
                        </select><br><br>
                        <label>Оставтье Ваши комментарии<br><br>
                            <textarea rows="5" cols="50">
                            </textarea>
                        </label><br>
                        <input type="submit" value="Отправить">
                        <input type="reset" value="Очистить">
                    </label>
            </fieldset>
        </form>
        <?php
        $first_name = $_REQUEST["userName"];
        $second_name = $_REQUEST["userSurname"];
        $curs = $_REQUEST["courses"];
        if(isset($firslt_name)&&isset($second_name)&&isset($curs)) {
            $str = "Здравствуйте, ".$first_name." ".$second_name."! <br>";
            $str .= "Вы выбрали для изучения курс по ".$curs;
        } else {
            $str = "Вы ввели не все данные";
        }
        echo $str;
        function clstr($data){
            return trim (stup_tags($data));
        }//Для защиты от неправильных вводов пользователей, иначе сайт крякниться
        ?>
    </body>
</html>