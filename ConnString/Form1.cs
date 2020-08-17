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
            string ConString = ConfigurationManager.ConnectionStrings["inner"].ConnectionString;
            string sqlQuery = "SELECT ID, Nev, Torzsszam, TartozasJellege, Osszeg, VegrehajtasiKTSG, " +
                "RogzDatum, ElsoBefizetesDatum, Futamido, Statusz, FigyelmeztetesDatum, VegrehajtasDatum, " +
                "Megjegyzes FROM dbo.DanyTartozasok WHERE Statusz <>5  AND Statusz <>2 ORDER BY ID DESC";
            string connection2 = ConfigurationManager.ConnectionStrings["mvMeres"].ConnectionString;
            string sqlQurey2 = "SELECT MertErtek, Datum FROM dbo.Hal2EllenallasTemp ORDER BY Datum DESC";
            string sqlQuery3 = "SELECT name FROM sys.tables ORDER BY name";
//string sqlQuery4 = "SELECT * FROM sysobjects WHERE xtype = 'U'";


            DataTable dt = new DataTable();
            loadGridView(ConString, sqlQuery).Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            loadGridView(connection2, sqlQurey2).Fill(dt2);
            dataGridView2.DataSource = dt2;

            DataTable dt3 = new DataTable();
            loadGridView(ConString, sqlQuery3).Fill(dt3);
            // comboBox1.Items.Add(dt3);
            foreach (DataRow i in dt3.Rows) {
                comboBox1.Items.Add(i["name"].ToString());
            }
            dataGridView3.DataSource = dt3;

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
    }
}
