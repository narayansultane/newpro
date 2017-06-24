using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBO
{
    public class LoginBO
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password ")]        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string abc { get; set; }

    }
}
