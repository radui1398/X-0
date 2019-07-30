using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace X_and_0
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Label> labels = new List<Label>();
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            labels.Add(label12);
            labels.Add(label13);
            labels.Add(label14);
            labels.Add(label15);
            labels.Add(label16);
            labels.Add(label17);
            labels.Add(label18);
            labels.Add(label19);
            labels.Add(label20);
            labels.Add(label21);
            labels.Add(label22);

            //Conectarea la baza de date
            string server, database, uid, password;
            server = "sql8.freemysqlhosting.net";
            database = "sql8172470";
            uid = "sql8172470";
            password = "vZRDwsEz8J";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //Conectarea la baza de date

            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand selectData;
            selectData = con.CreateCommand();
            selectData.CommandText = "SELECT Scor,Nume FROM Top15 ORDER BY  Scor DESC LIMIT 10";
            MySqlDataReader rdr = selectData.ExecuteReader();
            int i = 0;
            while (rdr.Read())
            {
                string Scor = rdr["Scor"].ToString();
                string Nume = rdr["Nume"].ToString();
                labels[i].Text = Nume;
                labels[i+10].Text = Scor;
                i = i + 1;
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
