using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnString
{
    public class SqlQueries
    {
        public string sqlQuery = "SELECT ID, Nev, Torzsszam, TartozasJellege, Osszeg, VegrehajtasiKTSG, " +
                "RogzDatum, ElsoBefizetesDatum, Futamido, Statusz, FigyelmeztetesDatum, VegrehajtasDatum, " +
                "Megjegyzes FROM dbo.DanyTartozasok WHERE Statusz <>5  AND Statusz <>2 ORDER BY ID DESC";

        public string sqlQurey2 = "SELECT MertErtek, Datum FROM dbo.Hal2EllenallasTemp ORDER BY Datum DESC";
        public string sqlQuery3 = "SELECT name FROM sys.tables ORDER BY name";
        public string sqlQuery4 = "SELECT * FROM ";
    }
}
