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


namespace ConnString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConnectionStrings connectionStrings = new ConnectionStrings();
        SqlQueries sqlQueries = new SqlQueries();
        int index = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            /*  string connecion = ConfigurationManager.ConnectionStrings["inner"].ConnectionString;
              SqlConnection sqlConnecion = new SqlConnection(connecion);
              //string sqlQuery = "SELECT ID, Nev, Torzsszam, TartozasJellege, Osszeg, VegrehajtasiKTSG, RogzDatum, ElsoBefizetesDatum, Futamido, Statusz, FigyelmeztetesDatum, VegrehajtasDatum, Megjegyzes FROM dbo.DanyTartozasok WHERE Statusz <>5  AND Statusz <>2 ORDER BY ID DESC";
              string sqlQuery = "SELECT dt.[ID], d.IDTartozas,[Nev],[Torzsszam],[TartozasJellege] ,[Osszeg] ,[VegrehajtasiKTSG]," +
                  "[RogzDatum] ,[ElsoBefizetesDatum],[Futamido] ,[Statusz]   ,[FigyelmeztetesDatum]    ,[VegrehajtasDatum]    ,dt.[Megjegyzes]  ,[figyelmeztetes]  ,d.ID  ,dt.Megjegyzes " +
                  "FROM[Fusetech].[dbo].[DanyTartozasok] as dt  INNER JOIN DanyFizetes as d ON dt.ID = d.IDTartozas  ORDER BY dt.ID";
              SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnecion);
              sqlConnecion.Open();

              SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
              DataTable dataTable = new DataTable();

              sqlDataAdapter.Fill(dataTable);

              dataGridView1.DataSource = dataTable;
              sqlConnecion.Close();*/
            //
            /* string connection2 = ConfigurationManager.ConnectionStrings["mvMeres"].ConnectionString;
             SqlConnection sqlConnection2 = new SqlConnection(connection2);
             string sqlQurey2 = "SELECT MertErtek, Datum FROM dbo.Hal2EllenallasTemp ORDER BY Datum DESC";
             SqlCommand sqlCommand2 = new SqlCommand(sqlQurey2, sqlConnection2);
             sqlConnection2.Open();

             SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
             DataTable dataTable2 = new DataTable();

             sqlDataAdapter2.Fill(dataTable2);

             dataGridView2.DataSource = dataTable2;
             sqlConnection2.Close();*/
           
            DataTable dt = new DataTable();
            loadGridView(connectionStrings.ConString, sqlQueries.sqlQuery).Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            loadGridView(connectionStrings.ConString2, sqlQueries.sqlQurey2).Fill(dt2);
            dataGridView2.DataSource = dt2;

        /*    if (index == 0)
            {
                DataTable dt3 = new DataTable();
                loadGridView(connectionStrings.ConString, sqlQueries.sqlQuery3).Fill(dt3);
                foreach (DataRow i in dt3.Rows)
                {
                    comboBox1.Items.Add(i["name"].ToString());
                }
            }
            else if(index == 1){
                DataTable dt3 = new DataTable();
                loadGridView(connectionStrings.ConString2, sqlQueries.sqlQuery3).Fill(dt3);
                foreach (DataRow i in dt3.Rows)
                {
                    comboBox1.Items.Add(i["name"].ToString());
                }

            }*/
           

        }
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
    }
}
