using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProjDAL;
using SQLHelper;
using ProjBO;

namespace ProjDAL
{
    public class LoginDAL
    {


        public static bool Login(LoginBO log)
        {
            try
            {               
                SQLHelper.SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("CheckUser", SQLHelper.SQLHelper.objCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("username", log.Username);
                SqlParameter p2 = new SqlParameter("password", log.Password);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    return true;

                }
                else
                {
                    return false;
                }
              

                 }
                 catch (Exception ex)
                {
                
                }
                finally
                {
                    SQLHelper.SQLHelper.CloseConnection();
                }

            return false;

            }
        }
    }

       
