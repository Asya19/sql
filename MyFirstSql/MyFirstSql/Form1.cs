using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MyFirstSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string config;
        SqlConnection connection;


        private void Form1_Load(object sender, EventArgs e)
        {
            config = @"Data source =.\SQLEXPRESS; Initial Catalog = Employee; Integrated Security = True ";
            connection = new SqlConnection(config);

            // conectoin.Open();

            // conectoin.Clouse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmnd = new SqlCommand("INSERT INTO Empl" + "(FIRSTNAME, LASTNAME, AGE, CITY, SALARY)" + "VALUES ('KOLYA  ', 'PETROV', '20', 'SPB', '5000')", connection);
            connection.Open();
            cmnd.ExecuteNonQuery();
            connection.Close();


            //cmnd.Connection = connection;
            //cmnd.Connection = "text";


            //cmnd = connection.CreateCommand(); // автоматически создаст Sql Command
            //cmnd.CommandText = "text";

            //cmnd = new SqlCommand("text", connection);

            //cmnd.ExecuteNonQuery(); // никаких данных из Sql таблиц не возвращает
            //cmnd.ExecuteScalar(); // если нужны какая то велична
            //cmnd.ExecuteReader();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmnd = new SqlCommand("DELETE Empl WHERE FIRSTNAME = 'KOLYA'", connection);


            connection.Open();
            cmnd.ExecuteNonQuery();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmnd = new SqlCommand("INSERT INTO Empl" + "(FIRSTNAME, LASTNAME, AGE, CITY, SALARY)" + "VALUES ('ALEX', 'PETROV', '20', 'SPB', '5000')", connection);

            connection.Open();
            cmnd.ExecuteNonQuery();
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmnd = new SqlCommand("SELECT * FROM Empl", connection);

            connection.Open();
            UpdateTextBox(cmnd);

            ///cmnd.ExecuteNonQuery();
             connection.Close();
        }

        private void UpdateTextBox(SqlCommand cmnd)
        {
            SqlDataReader reader = cmnd.ExecuteReader();

            string s = "";

            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    s += reader[i] + " ";
                }
                s += "\r" + "\n";

                //{
                //    s += reader.GetString(4) + "";
                //}
                //s += "\r" + "\n";



            }

            textBox1.Text = s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmnd = new SqlCommand("SELECT * FROM Empl ORDER BY FIRSTNAME", connection);

            connection.Open();
            cmnd.ExecuteNonQuery();
            UpdateTextBox(cmnd);
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmnd = new SqlCommand(
                "UPDATE Empl " +
                "SET LASTNAME = 'IVANOV' " +
                "WHERE ID = 5", connection);

            connection.Open();
            cmnd.ExecuteNonQuery();
            UpdateTextBox(cmnd);
            connection.Close();
        }
    }
}
