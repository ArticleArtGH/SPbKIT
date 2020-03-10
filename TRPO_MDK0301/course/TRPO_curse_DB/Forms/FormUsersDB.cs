using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//для работы с БД из Access

namespace TRPO_curse_DB
{
    public partial class FormUsersDB : Form
    {
        public static string connDB = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TeachersOfUniversities.mdb";
        OleDbConnection connectDB;
        OleDbCommand commandDB;
        OleDbDataReader readerDB;
        OleDbDataAdapter daDB;
        DataTable dtDB;
        DataGridView dGV;
        string queryDB = "";

        public void Fill_dGVs(string connDB, string queryDB, DataGridView dGV)
        {
            connectDB = new OleDbConnection(connDB);//Подключение к БД
            connectDB.Open();
            daDB = new OleDbDataAdapter(queryDB, connDB);
            dtDB = new DataTable();//DataTable.ActorsDataTable();
            daDB.Fill(dtDB);
            dGV.DataSource = dtDB;
            connectDB.Close();
            connectDB.Dispose();//Для очистки управляемого мусора
        }

        public FormUsersDB()
        {
            InitializeComponent();
        }

        private void FormUsersDB_Load(object sender, EventArgs e)
        {
            queryDB = "select * from Faculty";
            dGV = this.dataGridViewFaculty;
            Fill_dGVs(connDB, queryDB, dGV);

            queryDB = "select * from Cathedra";
            dGV = this.dataGridViewCathedra;
            Fill_dGVs(connDB, queryDB, dGV);

            queryDB = "select * from Hours";
            dGV = this.dataGridViewHours;
            Fill_dGVs(connDB, queryDB, dGV);

            queryDB = "select * from Wages";
            dGV = dataGridViewWages;
            Fill_dGVs(connDB, queryDB, dGV);
        }

        private void buttonDisconnectDB_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConnectDB fCdb = new FormConnectDB();
            fCdb.ShowDialog();
            this.Close();
        }
    }
}
