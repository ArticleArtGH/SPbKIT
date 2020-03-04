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

namespace TRPO_curse_DB
{
    public partial class FormConnetDB : Form
    {
        public static string pathDB = "Provider=Microsoft.Jet.OLEDB.4.0; DataSource = TeachersOfUniversities.mdb";
        //provider=Microsoft.Jet.OLEDB.4.0 для формата с расширением для accedb (2007), 
        //a Provider=Microsoft.ACE.OLEDB.12.0 mdf (2002-2003).//Не точно :)
        private OleDbConnection connDB;
        public FormConnetDB()
        {
            InitializeComponent();
            this.CenterToScreen();//Появление формы по центру экрана
            connDB = new OleDbConnection(pathDB);
        }

        private void button_SignIN_Click(object sender, EventArgs e)
        {
            //Аунтентификация
            connDB.Open();
            string commandDB = "select [Login], [Password]";
            OleDbDataAdapter daDB = new OleDbDataAdapter(commandDB, connDB);
            DataTable dtDB = new DataTable();
            daDB.Fill(dtDB);
            DataGridView dataGridViewStorage = new DataGridView();
            dataGridViewStorage.DataSource = dtDB;
            byte colomnsDTdb = (byte)dataGridViewStorage.Columns.Count,
                 rowsnDTdb = (byte)dataGridViewStorage.Rows.Count;
            string[,] arrUsersDT = new string[rowsnDTdb, colomnsDTdb];
            for(int i = 0; i < rowsnDTdb; i++)
            {
                for(int j = 0; j < colomnsDTdb; j++)
                {
                    arrUsersDT[i, j] = (string)dataGridViewStorage[j, i].Value;
                }
            }
            connDB.Close();
            //Затем сравнивая значения из массива с textboxs дать/не дать попасть на вторую форму.

            //Запуск БД если аунтентификация пройдена
            this.Hide();
            FormDB fDB = new FormDB();
            fDB.ShowDialog();
            //fDB.Show();//Для одновременного использования(-hide, -ShowDialog, -close -(убрать))
            this.Close();//Что бы не просто скрывалась, а ещё не занимала память
        }
    }
}
