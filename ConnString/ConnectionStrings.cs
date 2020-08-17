using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConnString
{
    public class ConnectionStrings
    {
        public string ConString = ConfigurationManager.ConnectionStrings["inner"].ConnectionString;
        
        public string ConString2 = ConfigurationManager.ConnectionStrings["mvMeres"].ConnectionString;
    }
}
