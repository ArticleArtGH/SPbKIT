using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Caesars_code//Работает только для EN символов с нижним регистром !
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = 0, long_pswd = 0;
            string password = "", code = "", exercise = "", s_key = "";
            string alhabet = "abcdefghijklmnopqrstuvwxyz";
            char[] c_array_alhabet = new char[alhabet.Length];
            c_array_alhabet = alhabet.ToCharArray();

            WriteLine("Придумайте пароль на английском (только для букв малёнького регистра):");
            password = ReadLine();
            long_pswd = password.Length;
            char[] c_arr_password = password.ToCharArray(); 

            WriteLine("Выберите шифрованию \n" +
                "1 - Цезарь\n" +
                "2 - Вижлер\n" +
                "3 - Перестановка\n"+
                "4 - XOR\n"+
                "5 - Плейфера\n");
            exercise = ReadLine(); 
            switch (exercise)
            {
                case "1":
                    WriteLine("Введите кодовое число (ключ) для шифрования пароля:");
                    key = Convert.ToInt32(ReadLine());
                    int index = 0, inkey = key;
                    for (int i = 0; i < long_pswd; i++)
                    {
                        index = Array.BinarySearch(c_array_alhabet, c_arr_password[i]);
                        while (inkey > alhabet.Length - 1)
                        {
                            inkey = inkey - alhabet.Length;
                        }//Убираеи лишнии круги, т.к. размер ключа
                        if (index + inkey > alhabet.Length - 1)
                        {
                            index = inkey + index - alhabet.Length;
                        }
                        else
                        {
                            index = index + inkey;
                        }
                        code += c_array_alhabet[index];
                    }//ЗАШИФРОВКА пароля
                    WriteLine("Зашифрованный пароль:\n" + code);

                    WriteLine("Введите зашифрованный пароль, который хотите расшифровать:");
                    code = ReadLine();
                    WriteLine("Введите число (ключ) для рассшифрования пароля:");
                    key = Convert.ToInt32(ReadLine());
                    long_pswd = code.Length;
                    c_arr_password = new char[long_pswd];
                    c_arr_password = code.ToCharArray();
                    password = ""; inkey = key;

                    for (int i = 0; i < long_pswd; i++)
                    {
                        index = Array.BinarySearch(c_array_alhabet, c_arr_password[i]);
                        while (inkey > alhabet.Length - 1)
                        {
                            inkey = inkey - alhabet.Length;
                        }//Убираеи лишнии круги, т.к. размер ключа
                        if (index - inkey < 0)
                        {
                            index = index - inkey + alhabet.Length;
                        }
                        else
                        {
                            index = index - inkey;
                        }
                        password += c_array_alhabet[index];
                    }//ДЕШИФРОВКА пароля
                    WriteLine("Расшифрованный пароль:\n" + password);
                    break;
                case "2":
                    char[,] table_Vigenere = new char[26, 26];
                    int k = 0, extra_k = 0;
                    for (int i = 0; i < c_array_alhabet.Length; i++)
                    {
                        for (int j = 0; j < c_array_alhabet.Length; j++)
                        {
                            table_Vigenere[i, j] = c_array_alhabet[k];
                            Write(" "+c_array_alhabet[k]);
                            k++;
                            if (k == c_array_alhabet.Length)
                            {
                                k = 0;
                            }
                        }
                        extra_k++;
                        k = extra_k;
                        WriteLine();
                    }
                    WriteLine("Введите кодовое слово (ключ) для шифрования пароля:");
                    s_key = ReadLine();
                    string changePasword = "";
                    k = 0;
                    for(int i=0;i<long_pswd; i++)
                    {
                        if (k == s_key.Length)
                        {
                            k = 0;
                        }
                        changePasword += s_key[k];
                        k++;
                    }
                    WriteLine("Распределение ключа по длинные пароля для шифрования по Vigenere\n" + changePasword);
                    int index_I = 0, index_J = 0;
                    for (k = 0; k < long_pswd; k++)
                    {
                        index_I = Array.BinarySearch(c_array_alhabet, password[k]);
                        index_J = Array.BinarySearch(c_array_alhabet, changePasword[k]);
                        code += table_Vigenere[index_I, index_J];
                    }
                    WriteLine("Зашифрованный пароль:\n"+code);

                    WriteLine("Введите зашифрованный пароль, который хотите расшифровать:");
                    code = ReadLine();
                    WriteLine("Введите кодовое слово (ключ) для расшифрования пароля:");
                    s_key = ReadLine();
                    long_pswd = code.Length;
                    k = 0; long_pswd = code.Length; changePasword = "";
                    for (int i = 0; i < long_pswd; i++)
                    {
                        if (k == s_key.Length)
                        {
                            k = 0;
                        }
                        changePasword += s_key[k];
                        k++;
                    }
                    WriteLine("Распределение ключа по длинные пароля для расшифрования по Vigenere\n" + changePasword);
                    password = "";
                    for(int j = 0; j<long_pswd; j++)
                    {
                        index_J = Array.BinarySearch(c_array_alhabet, changePasword[j]);
                        int i = 0;
                        while(table_Vigenere[i, index_J] != code[j])
                            i++;//без скобок - "{}" можно выполнить всего одно действие(одна - ; после неё уже 
                        //будет считатья другое действие), например здесь в loop одно действие и в if:
                        //for (int i = 0; i < c_array_alhabet.Length; i++)
                        //    if (table_Vigenere[i, index_J] == code[j])
                        //        password += c_array_alhabet[i];
                        password += c_array_alhabet[i];
                    }
                    WriteLine("Расшифрованный пароль:\n" + password);
                    break;
                case "3":
                    WriteLine("Введите кодовое число (ключ) для шифрования пароля:");
                    key = Convert.ToInt32(ReadLine());
                    while(key>long_pswd)
                    {
                        key = key - long_pswd;
                    }
                    index = key-1; code = ""; char c_sym = ' ';
                    c_arr_password = password.ToCharArray();
                    while (index + 1 < long_pswd)
                    {
                        c_sym = c_arr_password[index];
                        c_arr_password[index] = c_arr_password[index + 1];
                        c_arr_password[index + 1] = c_sym;
                        index += key;
                    }
                    for(int i = 0; i<long_pswd; i++)
                    {
                        code += c_arr_password[i];
                    }
                    WriteLine("Зашифрованный пароль:\n" + code);

                    WriteLine("Введите зашифрованный пароль, который хотите расшифровать:");
                    code = ReadLine();
                    WriteLine("Введите число (ключ) для рассшифрования пароля:");
                    key = Convert.ToInt32(ReadLine());
                    long_pswd = code.Length;
                    while (key > long_pswd)
                    {
                        key = key - long_pswd;
                    }
                    index = key - 1; password = ""; c_sym = ' ';
                    c_arr_password = code.ToCharArray();
                    //Array.Reverse(c_arr_password);
                    while (index + 1 < long_pswd)
                    {
                        c_sym = c_arr_password[index];
                        c_arr_password[index] = c_arr_password[index + 1];
                        c_arr_password[index + 1] = c_sym;
                        index += key;
                    }
                    //Array.Reverse(c_arr_password); 
                    for (int i = 0; i < long_pswd; i++)
                    {
                        password += c_arr_password[i];
                    }
                    WriteLine("Расшифрованный пароль:\n" + password);
                    break;
                case "4"://Минус в моём коде только что не выведит выведит некоторые символы неизвестные, но
                    //с ними можно решить проблему как с пробелом я решил. Всё же может есть способ лучше
                    //решения неизвестных символов.
                    WriteLine("Введите кодовое слово (ключ) для шифрования пароля:");
                    s_key = ReadLine();
                    k = 0; changePasword = "";
                    for (int i = 0; i < long_pswd; i++)
                    {
                        if (k == s_key.Length)
                        {
                            k = 0;
                        }
                        changePasword += s_key[k];
                        k++;
                    }
                    WriteLine("Распределение ключа по длинные пароля для шифрования\n" + changePasword);
                    byte bits; string s_symPswd = "", s_symChPswd = "", s_symCode = ""; code ="";//c_sym = ' ';
                    //так как это ascii  то можно и просто символы складывать ...
                    for (int i = 0; i < long_pswd; i++)
                    {
                        //bits = Encoding.ASCII.GetBytes(s_sym);
                        s_symPswd = Convert.ToString(password[i], 2);//Перевод в 2 систему счисленя
                        s_symChPswd = Convert.ToString(changePasword[i], 2);

                        //Уравнивание длинны двоичного кода символа
                        string s_dif = "";
                        if (s_symPswd.Length > s_symChPswd.Length)
                        {
                            int dif = s_symPswd.Length - s_symChPswd.Length;
                            for (int j = 0; j < dif; j++)
                                s_dif += 0;
                            s_symChPswd = s_symChPswd.Insert(0, s_dif);//Вставляем недостающие символы в начало
                        }
                        if (s_symChPswd.Length > s_symPswd.Length)
                        {
                            int dif = s_symChPswd.Length - s_symPswd.Length;
                            for (int j = 0; j < dif; j++)
                                s_dif += 0;
                            s_symPswd = s_symPswd.Insert(0, s_dif);//Вставляем недостающие символы в начало
                        }

                        for (int j = 0; j < s_symPswd.Length; j++)
                            s_symCode += (s_symPswd[j] == s_symChPswd[j]) ? "0" : "1";
                        //bits = new int[s_symPswd.Length];
                        //for (int j = 0; j < s_symPswd.Length; j++)
                        //    bits[j] = (s_symPswd[j] == s_symChPswd[j]) ? 0 : 1;

                        //bits = Convert.ToInt32(s_symCode);
                        //code += Convert.ToString(bits, toBase:S);
                        //code += (char)bits;//Encoding.ASCII.GetChars(bits);

                        //s_symCode = Convert.ToString(Convert.ToByte(s_symCode), toBase:10);
                        //s_symCode = Convert.ToString(s_symCode, toBase: 10);

                        bits = Convert.ToByte(s_symCode, 2);//Перевод в 10 систему счисленя,
                        //можно также это использовать в INT, а ещё где не проверял.

                        //bits = Convert.ToInt64(s_symCode);
                        //code += Convert.ToChar(bits);
                        //string backslah = "\\u0003";
                        //if (bits == 2)
                        //    code += code.Insert(0, backslah);
                        code += (bits == 2) ? Convert.ToChar("\\u0003") : Convert.ToChar(bits);//Если попадётся 
                        //пробел то он выведистя в виде символа.

                        //code += "\\" + Encoding.GetEncoding(1251).GetString(new byte[] { bits } )[0];
                        //code += Convert.ToChar(bits);
                        //code += Convert.ToString(bits, toBase:8);

                        s_symCode = "";
                        bits = 0;

                        //xor
                        //не понял в какой кодировку именно я должен получить и при помощи кодировку
                        //я получу сразу двойичный код ?
                    }
                    WriteLine("Зашифрованный пароль:\n" + code);

                    WriteLine("Введите зашифрованный пароль, который хотите расшифровать:");
                    code = ReadLine();
                    WriteLine("Введите кодовое слово (ключ) для шифрования пароля:");
                    s_key = ReadLine();
                    k = 0; changePasword = "";long_pswd = code.Length;
                    for (int i = 0; i < long_pswd; i++)
                    {
                        if (k == s_key.Length)
                        {
                            k = 0;
                        }
                        changePasword += s_key[k];
                        k++;
                    }
                    WriteLine("Распределение ключа по длинные пароля для расшифрования\n" + changePasword);
                    bits=0; s_symPswd = ""; s_symChPswd = ""; s_symCode = ""; password = "";
                    for (int i = 0; i < long_pswd; i++)
                    {
                        s_symPswd = Convert.ToString(code[i], 2);//Перевод в 2 систему счисленя
                        s_symChPswd = Convert.ToString(changePasword[i], 2);

                        //Уравнивание длинны двоичного кода символа
                        string s_dif = "";
                        if (s_symPswd.Length > s_symChPswd.Length)
                        {
                            int dif = s_symPswd.Length - s_symChPswd.Length;
                            for (int j = 0; j < dif; j++)
                                s_dif += 0;
                            s_symChPswd = s_symChPswd.Insert(0, s_dif);//Вставляем недостающие символы в начало
                        }
                        if (s_symChPswd.Length > s_symPswd.Length)
                        {
                            int dif = s_symChPswd.Length - s_symPswd.Length;
                            for (int j = 0; j < dif; j++)
                                s_dif += 0;
                            s_symPswd = s_symPswd.Insert(0, s_dif);//Вставляем недостающие символы в начало
                        }

                        for (int j = 0; j < s_symPswd.Length; j++)
                            s_symCode += (s_symPswd[j] == s_symChPswd[j]) ? "0" : "1";

                        bits = Convert.ToByte(s_symCode, 2);//Перевод в 10 систему счисленя,
                        //можно также это использовать в INT, а ещё где не проверял.
                        //password += Convert.ToChar(bits);
                        password += (bits == 2) ? Convert.ToChar("\\u0003") : Convert.ToChar(bits);//Если попадётся 
                        //пробел то он выведистя в виде символа.
                        s_symCode = "";
                        bits = 0;
                    }
                    WriteLine("Расшифрованный пароль:\n" + password);
                    break;
                case "5":
                    WriteLine("Введите кодовое ключ для шифрования пароля:");
                    s_key = ReadLine();
                    string ch_s_key = "";
                    char[] copy_c_array_alhabet = c_array_alhabet;
                    string[,] matrix5x5 = new string[5, 5];
                    ch_s_key += s_key[0];//только первый символ
                    k = 0;int zero = 0;
                    for (int i = 1; i< s_key.Length; i++)
                    {
                        for (int j = 0; j < ch_s_key.Length; j++)
                        {
                            if (s_key[i] == ch_s_key[j])
                                k++;
                            zero = i;
                        }
                        if (k > 0)
                        {
                            k = 0; continue;
                        }
                        else
                        {
                            ch_s_key += s_key[zero];
                            //Исключение из алфавита букв ключа
                            zero = Array.BinarySearch(copy_c_array_alhabet, s_key[zero]);
                            if (zero > -1)
                                copy_c_array_alhabet[zero] = '0';
                        }
                    }//Убираем одинаковые символы из ключа для подговтовки к матрице
                    WriteLine("Изменённый ключ:\n" + ch_s_key);

                    k = 0; zero = 0;
                    WriteLine("Матрица 5х5:\n");
                    for (int i = 0; i<5; i++)
                    {
                        for(int j = 0; j<5; j++)
                        {
                            if (k != ch_s_key.Length)
                            {
                                matrix5x5[i, j] = Convert.ToString(ch_s_key[k]);
                                k++;
                                Write(matrix5x5[i, j]);
                            }//заполнение матрицы ключом
                            else
                            {
                                if (copy_c_array_alhabet[zero] != 0)
                                {
                                    if (copy_c_array_alhabet[zero] == i && copy_c_array_alhabet[zero + 1] == j)
                                    {
                                        matrix5x5[i, j] += Convert.ToString(copy_c_array_alhabet[zero]);
                                        Write(matrix5x5[i, j]);
                                        j--;
                                    }
                                    else
                                    {
                                        matrix5x5[i, j] = Convert.ToString(copy_c_array_alhabet[zero]);
                                        Write(matrix5x5[i, j]);
                                    }
                                    zero++;
                                }
                                else
                                {
                                    zero++;
                                }//заполнение матрицы недостающими символами алфавита
                            }
                        }
                        WriteLine();
                    }

                    break;
                default: WriteLine("Вы ввели не верное значение!\n" +
                    "Программа ЗАКРЫВАЕТСЯ !\n" +
                    "...нажмите Enter...");
                    break;
            }
            ReadKey(true); 
        }
    }
}
