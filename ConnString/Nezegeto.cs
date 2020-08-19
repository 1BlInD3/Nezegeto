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
using System.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Base.Enums;

namespace ConnString
{
    public partial class Nezegeto : Form
    {
        public Nezegeto()
        {
            InitializeComponent();
            SetupData();
        }

        ConnectionStrings connectionStrings = new ConnectionStrings();
        SqlQueries sqlQueries = new SqlQueries();
        int index = 0;
        SqlTableDependency<DanyTartozasok> tableDependency; 

        private void Form1_Load(object sender, EventArgs e)
        {
         //  tableDependency = new SqlTableDependency<DanyTartozasok>(connectionStrings.ConString, "DanyTartozasok");

          // tableDependency.OnChanged += TableDependency_Changed;
        //   tableDependency.Start();


        }

    /*   private void TableDependency_Changed(object sender, RecordChangedEventArgs<DanyTartozasok> e)
        {
            if (e.ChangeType != ChangeType.None) {
                // var chentity = e.Entity;
                DataTable dt = new DataTable();
                loadGridView(connectionStrings.ConString, sqlQueries.sqlQuery).Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }*/

        private SqlDataAdapter loadGridView(string conString, string sqlQuery) {

            SqlConnection sqlConnection = new SqlConnection(conString);
            SqlCommand sql = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            MessageBox.Show("Siker!");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            sqlConnection.Close();
            return sqlDataAdapter;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (index == 0)
            {
                DataTable dt = new DataTable();
                loadGridView(connectionStrings.ConString, sqlQueries.sqlQuery4 + comboBox1.Text).Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else if(index == 1){
               
                DataTable dt = new DataTable();
                loadGridView(connectionStrings.ConString2, sqlQueries.sqlQuery4 + comboBox1.Text).Fill(dt);
                dataGridView3.DataSource = dt;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                dataGridView3.DataSource = null;
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                DataTable dt3 = new DataTable();
                loadGridView(connectionStrings.ConString, sqlQueries.sqlQuery3).Fill(dt3);
                foreach (DataRow i in dt3.Rows)
                {
                    comboBox1.Items.Add(i["name"].ToString());
                }
                index = 0;
                
            }

            else { 
                index = 1;
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                dataGridView3.DataSource = null;
                DataTable dt3 = new DataTable();
                loadGridView(connectionStrings.ConString2, sqlQueries.sqlQuery3).Fill(dt3);
                foreach (DataRow i in dt3.Rows)
                {
                    comboBox1.Items.Add(i["name"].ToString());
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           // tableDependency.Stop();
        }

        private void SetupData() {
            DataTable dt = new DataTable();
            loadGridView(connectionStrings.ConString, sqlQueries.sqlQuery).Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            loadGridView(connectionStrings.ConString2, sqlQueries.sqlQurey2).Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

    }
}
