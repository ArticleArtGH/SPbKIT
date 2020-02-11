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
            string password = "", code = "", exercise = "", c_key = "";
            string alhabet = "abcdefghijklmnopqrstuvwxyz";
            char[] c_array_alhabet = new char[alhabet.Length];
            c_array_alhabet = alhabet.ToCharArray();

            WriteLine("Придумайте пароль на английском:");
            password = ReadLine();
            long_pswd = password.Length;
            char[] c_arr_password = new char[long_pswd];
            c_arr_password = password.ToCharArray();

            WriteLine("Выберите задание по шифрованию \n" +
                "1 - Цезарь\n" +
                "2 - Вижлер\n" +
                "3 - ...");
            exercise = ReadLine(); 
            switch (exercise)
            {
                case "1":
                    WriteLine("Введите ключ для шифрования пароля:");
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
                    WriteLine("Зашифрованный пароль:" + code);

                    WriteLine("Введите пароль на английском, который хотите расшифровать:");
                    code = ReadLine();
                    WriteLine("Введите ключ для рассшифрования пароля:");
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
                    WriteLine("Зашифрованный пароль:" + password);
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
                    WriteLine("Введите ключ для шифрования пароля:");
                    c_key = ReadLine();
                    string changePasword = "";
                    k = 0;
                    for(int i=0;i<long_pswd; i++)
                    {
                        if (k == c_key.Length)
                        {
                            k = 0;
                        }
                        changePasword += c_key[k];
                        k++;
                    }
                    WriteLine(changePasword);
                    for (k = 0; k < long_pswd; k++)
                    {
                        //index = Array.BinarySearch(c_array_alhabet, c_arr_password[i]);//идиея искать буквы в алфавите и затем шифр на основе массивВижнера[i,j]

                        //for (int j = 0; j < )
                        //{

                        //}
                    }
                    //foreach(int i in table_Vigenere)
                    //{
                    //    WriteLine(i);
                    //    foreach(int j in table_Vigenere)
                    //    {
                    //        WriteLine(j);
                    //    }
                    //}
                    break;
                case "3":

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
