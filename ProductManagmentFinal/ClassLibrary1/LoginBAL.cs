using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjBO;
using ProjDAL;

namespace ProjBAL
{
    public class LoginBAL
    {
        public static bool Login(LoginBO login)
        {
          
            return LoginDAL.Login(login);
           
        }

       
    }
}
