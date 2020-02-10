﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Statement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random integerRnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView_Statement.RowCount = 1;
            this.dataGridView_Statement.ColumnCount = 1;
        }

        private void numericUpDown_CountStud_ValueChanged(object sender, EventArgs e)
        {
            //int numUpDownStud = Convert.ToInt32(numericUpDown_CountStud.Value);
            //this.dataGridView_Statement.RowCount = numUpDownStud > 0 ? numUpDownStud : 1;
            //Он добавляет строки не верно (они добаляются сверху, а не в конце строк) в отличии от столбцов !
            this.dataGridView_Statement.RowCount = Convert.ToInt32(numericUpDown_CountStud.Value);
        }

        private void numericUpDown_CountSubject_ValueChanged(object sender, EventArgs e)
        {
            this.dataGridView_Statement.ColumnCount = Convert.ToInt32(numericUpDown_CountSubject.Value);
        }

        private void tabPage_Statement_Click(object sender, EventArgs e)
        {
            //integerRnd.Next(10, 15);
        }

        private void button_RandomGeneration_Click(object sender, EventArgs e)
        {
            //this.dataGridView_Statement.ReadOnly = true;
            //int intRow = integerRnd.Next(10, 20), intColumn = integerRnd.Next(10,20);
            int intCell = 0, int_NA_Cell = 0,i = 0, j = 0, NA_Rows=0, NA_Columns=0; 
            int countRows = this.dataGridView_Statement.RowCount, countColumn = this.dataGridView_Statement.ColumnCount;
            //Заполнение Зголовков
            for (i=0; i < countRows; i++ )
            {
                this.dataGridView_Statement.Rows[i].HeaderCell.Value = "Студент"+(i+1);
            }
            for (j=0; j < countColumn; j++)
            {
                this.dataGridView_Statement.Columns[j].HeaderCell.Value = "Предмет" + (j+1);
            }
            //Заполнение Таблицы
            for (i = 0; i < countRows; i++)//Можна потом как нибудь подумать как с помощью foreach сделать, всё же это массив
            {
                for (j = 0; j < countColumn; j++)
                {
                    intCell = integerRnd.Next(2, 6);//Рандом делает максимальное значение на единицу ментше, т.е. для 5 от 2 до 6
                    //this.dataGridView_Statement.Rows[j].Cells[i].Value= intCell;//Другой способ записывания строк и столбцов dataGridView
                    this.dataGridView_Statement[j, i].Value = Convert.ToString(intCell);
                }
                //Рандом для н/а
                NA_Rows = integerRnd.Next(0, countRows);
                NA_Columns = integerRnd.Next(0, countColumn);
                switch (integerRnd.Next(0, 2))
                {
                    case 0: break;
                    case 1:
                        switch (integerRnd.Next(1, 4))
                        {
                            case 1: this.dataGridView_Statement[--j, NA_Rows].Value = "н/а"; break;//Здесь j-1, т.к. j уже увеличился //инкремент сначало действие(+|-) потом инициализирует, а посткримент сначало инициализирует потом действие(+|-)
                            case 2: this.dataGridView_Statement[NA_Columns, i].Value = "н/а"; break;//Здесь i не вычитали 1, т.к. i ещё не увеличивался
                            case 3: this.dataGridView_Statement[NA_Columns, NA_Rows].Value = "н/а"; break;
                        }
                        break;
                }
            }
            //this.dataGridView_Statement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;

            //this.dataGridView_Statement.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //this.dataGridView_Statement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //Авторазмер заголовков Столбцов
            this.dataGridView_Statement.AutoResizeColumnHeadersHeight();

            //this.dataGridView_Statement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            //Авторазмер заголовков Строк
            this.dataGridView_Statement.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            //this.dataGridView_Statement.AutoResizeColumnHeadersHeight();
            //this.dataGridView_Statement.Cell 
        }

        private void button_ReadFile_Click(object sender, EventArgs e)
        {
            //this.dataGridView_Statement.ReadOnly = true;
            string[] arr_str, arr_Stud = new string[1], arr_Subject = new string[1], arr_Assessment = new string[1];
            string path = Application.StartupPath + @"\table_Statement.txt"/*\ - для того чтобы спустился на уровень ниже, т.е. попал в папку*/, text;
            Encoding encoding = Encoding.GetEncoding(1251);/*Encoding.GetEncoding("utf-8"); Encoding.GetEncoding(1251);
            Encoding.GetEncoding("windows-1251");*/
            StreamReader sr = new StreamReader(path,encoding);
            int i = 0, j = 0;
            string data="Rows";
            while((text = sr.ReadLine()) != null)
            {
                arr_str = text.Split(new char[] { ';' });
                switch (data)
                {
                    case"Rows":
                        if (arr_str[0] == "<>")
                        {
                            data = "Colums";break;
                        }
                        this.dataGridView_Statement.Rows[i].HeaderCell.Value = Convert.ToString(arr_str[0]);
                        ++i;
                        break;
                    case "Colums":
                        if(arr_str[0]=="<>")
                        {
                            data = "Table";i = 0;j = 0; break;
                        }
                        this.dataGridView_Statement.Columns[j].HeaderCell.Value = Convert.ToString(arr_str[0]);
                        ++j;
                        break;
                    case "Table":
                        for (j = 0; j < this.dataGridView_Statement.ColumnCount; j++)
                        {
                            this.dataGridView_Statement[j, i].Value = Convert.ToString(arr_str[j]);
                        }
                        i++;
                        break;
                }
            }
            sr.Close();

            //try
            //{
            //    while ((text = sr.ReadLine()) != null)
            //    {
            //        arrStr = text.Split(new char[] { ';' });
            //        arrStr0[i] = arrStr[0];
            //        arrStr1[i] = arrStr[1];
            //        Array.Resize(ref arrStr0, arrStr0.Length + 1);
            //        Array.Resize(ref arrStr1, arrStr1.Length + 1);
            //        i++;
            //    }
            //    //do
            //    //{

            //    //    string[] arrStr = (text=sr.ReadLine()).Split(new char[] { ';' });
            //    //    //text = File.ReadAllText(path)
            //    //    //WriteLine(text = File.ReadAllText(path,encoding));
            //    //    WriteLine(arrStr[2]);

            //    //} while ((text= sr.ReadLine())!=null);
            //}
            //catch (Exception e)
            //{
            //    WriteLine(e.Message);
            //}
            //finally
            //{
            //    sr.Close();//Это не обязательно, т.к. finally это делает автоматически для файлов.
            //    WriteLine("Освобождение файлов или закрытие.");
            //}





            //string path = Application.StartupPath + @"\Название.txt", str;
            //Encoding encoding = Encoding.GetEncoding(1251);
            //if (!File.Exists(path))
            //{
            //    MessageBox.Show("Файл с товарами не найден, в связи с этим приложение не отвечает, обратитесь к разработчику :|");
            //    Environment.Exit(0);//Выгрузка приложения
            //}

            ////**********************************************************************************************
            ////Работа с файлами 
            ////**********************************************************************************************
            //string pathSR = "example.txt", text = "";
            //Encoding encoding = Encoding.GetEncoding("utf-8");/*Encoding.GetEncoding("windows-1251");
            //Encoding.GetEncoding(1251);*/
            ////StreamReader sr = new StreamReader(pathSR, encoding);
            //string[] arrStr, arrStr0 = new string[1], arrStr1 = new string[1];
            //string[,] arrTwoStr = new string[1, 2];
            ////Array.Resize(ref arrTwoStr, arrTwoStr.Length + 1);
            ////arrTwoStr = new string[arrTwoStr.Length + 1, arrTwoStr.Length + 1];
            //int i = 0, j = 0;
            //try
            //{
            //    while ((text = sr.ReadLine()) != null)
            //    {
            //        arrStr = text.Split(new char[] { ';' });
            //        //arrTwoStr[i, j] = arrStr[0];
            //        //arrTwoStr[i, j+1] = arrStr[1];
            //        //arrTwoStr = new string[arrTwoStr.Length + 1, arrTwoStr.Length + 1];
            //        //WriteLine(arrTwoStr[i, j]);
            //        //WriteLine(arrTwoStr[i, j+1]);
            //        arrStr0[i] = arrStr[0];
            //        arrStr1[i] = arrStr[1];
            //        Array.Resize(ref arrStr0, arrStr0.Length + 1);
            //        Array.Resize(ref arrStr1, arrStr1.Length + 1);
            //        WriteLine("arrStr0: " + arrStr0[i]);
            //        WriteLine("arrStr1: " + arrStr1[i]);
            //        i++;
            //    }
            //    //do
            //    //{

            //    //    string[] arrStr = (text=sr.ReadLine()).Split(new char[] { ';' });
            //    //    //text = File.ReadAllText(path)
            //    //    //WriteLine(text = File.ReadAllText(path,encoding));
            //    //    WriteLine(arrStr[2]);

            //    //} while ((text= sr.ReadLine())!=null);
            //}
            //catch (Exception e)
            //{
            //    WriteLine(e.Message);
            //    //ReadKey(true);
            //    //return;
            //}
            //finally
            //{
            //    sr.Close();//Это не обязательно, т.к. finally это делает автоматически для файлов.
            //    WriteLine("Освобождение файлов или закрытие.");
            //}
            ////if (!File.Exists(path))
            ////{
            ////    WriteLine("Файл не найден, закрытие программы!\n\r" +
            ////        "Для закрытия файла нажмите любую клавишу.");
            ////    ReadKey(true);
            ////    Environment.Exit(0);
            ////}

            //string[] arr_str, arr_price = new string[1], arr_title = new string[1];
            //string path = Application.StartupPath + @"\Название.txt", str;
            //Encoding encoding = Encoding.GetEncoding(1251);
            //this.comboBox_Title.Items.Clear();
            //if (!File.Exists(path))
            //{
            //    MessageBox.Show("Файл с товарами не найден, в связи с этим приложение не отвечает, обратитесь к разработчику :|");
            //    Environment.Exit(0);//Выгрузка приложения
            //}
            ////StreamReader sr = new StreamReader(path, encoding);
            //byte i = 0;
            //while ((str = sr.ReadLine()) != null)
            //{
            //    arr_str = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);//В массив пристваиваюстя столько наборов символов, на сколько мы их разделим, например строка Хлеб Белый;40 в arr_str выделится память под два элемента (arr_str[0] = Хлеб Белый, arr_str[1] = 40)
            //    if (i == (arr_title.Length))
            //    {
            //        Array.Resize(ref arr_title, i + 1);
            //        Array.Resize(ref arr_price, i + 1);
            //    }
            //    this.comboBox_Title.Items.Add(arr_str[0]);
            //    arr_title[i] = arr_str[0];
            //    arr_price[i] = arr_str[1];
            //    i++;
            //}
            //sr.Close();
        }
        private void button_AddByHand_Click(object sender, EventArgs e)
        {

            //this.dataGridView_Statement.ReadOnly = false;

            //this.dataGridView_Statement.Columns[0].HeaderText = "";
            //dataGridView_Statement.Columns[0].HeaderCell.ReadOnly = false;
            //dataGridView_Statement.ColumnHeader.
            //dataGridView_Statement.Columns["2"].HeaderCell.ReadOnly = false;
            //this.dataGridView_Statement.TopLeftHeaderCell.ReadOnly = false;
            //this.dataGridView_Statement.SelectionMode(get)

            //dataGridView1.Columns[0].HeaderText = "Логин";
        }
    }
}
