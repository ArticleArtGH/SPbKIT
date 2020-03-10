using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
//using System.Data.SqlClient;
//using System.Data;
//using System.Data.DataTable;

namespace TRPO_curse_DB
{
    public partial class FormConnectDB : Form
    {
        public static string connDB = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TeachersOfUniversities.mdb";
        //string connectStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb:Integrated Security=True";
        //C:\Users\user07\Desktop\374 Черых Артём\TRPO_MDK0301\TRPO_curse_DB\bin\Debug\TeachersOfUniversities.mdb";
        //|DataDirectory|\bin\Debug\TeachersOfUniversities.mdb";
        //provider=Microsoft.Jet.OLEDB.4.0 для формата с расширением для accedb (2007), 
        //a Provider=Microsoft.ACE.OLEDB.12.0 mdf (2002-2003).//Не точно :)
        //private OleDbConnection connectDB;
        public FormConnectDB()
        {
            InitializeComponent();
            this.CenterToScreen();//Появление формы по центру экрана
            //connectDB = new OleDbConnection(connDB);
            //this.Enter += new EventHandler(button_SignIN_Click);//Как то надо чтобы войти ещё при нажатии Enter ? 
        }

        private void button_SignIN_Click(object sender, EventArgs e)
        {//Авторизация
            OleDbConnection connectDB = new OleDbConnection(connDB);//Подключение к БД
            string queryDB = "select count(*) from Users";//команда запроса на кол-во строк в таблице Users
            connectDB.Open();//Делаться кажись должно до выполнения запроса !
            OleDbCommand commandDB = new OleDbCommand(queryDB, connectDB);//Инструкция Transact-SQL
            //OleDbDataReader readerDB = commandDB.ExecuteReader();//Для чтения потока строк (в прямом направлении)
            OleDbDataReader readerDB;
            int countRowsUsers = (int)commandDB.ExecuteScalar();//Количество строк в таблице
            queryDB = "select Login, Password from Users";//Выбераем столбцы Login, Password
            commandDB = new OleDbCommand(queryDB, connectDB);
            readerDB = commandDB.ExecuteReader(CommandBehavior.CloseConnection);//для следующего запроса
            //OleDbDataAdapter daDB = new OleDbDataAdapter(queryDB, connDB);
            //DataTable dtDB = new DataTable();//DataTable.ActorsDataTable();
            //daDB.Fill(dtDB);
            ////daDB.Fill(dtDB.Clone());
            ////daDB.Fill(dtDB);
            //DataGridView dataGridViewStorage = new DataGridView();
            //dataGridViewStorage.DataSource = dtDB;

            string[,] arrUsersDT = new string[countRowsUsers, 2];
            using (readerDB)
            {
                int i = 0;
                    while (readerDB.Read())
                    {
                        arrUsersDT[i, 0] = readerDB.GetValue(0).ToString().Trim();//Login
                        arrUsersDT[i, 1] = readerDB.GetValue(1).ToString().Trim();//Password
                        i++;
                    }
            }

            readerDB.Close();
            connectDB.Close();
            connectDB.Dispose();//Для очистки управляемого мусора

            //byte colomnsDTdb = (byte)dataGridViewStorage.Columns.Count,
            //     rowsnDTdb = (byte)dataGridViewStorage.Rows.Count;
            //string[,] arrUsersDT = new string[rowsnDTdb, colomnsDTdb];
            //for (int i = 0; i < rowsnDTdb; i++)
            //{
            //    for (int j = 0; j < colomnsDTdb; j++)
            //    {
            //        arrUsersDT[i, j] = (string)dataGridViewStorage[j, i].Value;
            //    }
            //}

            //connectDB.Close();

            //Только если Login and Password у всех уникальный !
            int indexLogin = -1, indexPassword = -1;
            for (int i = 0; i < countRowsUsers; i++)
            {
                if (arrUsersDT[i, 0] == this.textBox_Login.Text)
                    indexLogin = i;
                if (arrUsersDT[i, 1] == this.textBox_Password.Text)
                    indexPassword = i;
            }

            bool authorization = (indexLogin == indexPassword&&indexLogin!=-1) ? true : false;
            if (authorization == true)
            {//Запуск БД если аунтентификация пройдена
                this.Hide();
                if (arrUsersDT[indexLogin, 0] == "admin" || arrUsersDT[indexLogin, 0] == "owner")
                {
                    FormAdminDB fAdb = new FormAdminDB();
                    fAdb.ShowDialog();
                    //fDB.Show();//Для одновременного использования(-hide, -ShowDialog, -close -(убрать))
                }
                else
                {
                    FormUsersDB fUdb = new FormUsersDB();
                    fUdb.ShowDialog();
                }
                this.Close();//Что бы не просто скрывалась, а ещё не занимала память
            }
            else
            {
                MessageBox.Show("Вы ввели не верные данные (Логин или Пароль) !", "Ошибка :(",
                                MessageBoxButtons.OK,MessageBoxIcon.Stop); 
            }
            //Осталось помимо Enter сделать чтобы админ и пользователь попадали в разную форму ... .
            //Идея в самом приложении сделать разавторизацию что бы не выходить из приложения для захода дргого 
            //человека )
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            this.textBox_Password.PasswordChar ='*';//Чтобы скрыть вводимы символы пароля
        }

        private void FormConnetDB_Load(object sender, EventArgs e)
        {

        }
    }
}
