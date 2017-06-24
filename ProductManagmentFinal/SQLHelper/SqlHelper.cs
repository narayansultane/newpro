using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace SQLHelper
{
    public class SQLHelper
    {
       
            public static SqlConnection objCon = new SqlConnection();

            public static void OpenConnection()
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                objCon = new SqlConnection(connectionString);
                objCon.Open();
            }

            public static void CloseConnection()
            {
                objCon.Close();
            }


        
    }
}
