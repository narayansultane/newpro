using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjBO
{
    public class ProductBO
    {
        [DisplayName("ProductId")]
        public int ProdId { get; set; }        

        [Required(ErrorMessage = "Please Enter Product Name")]
        [DisplayName("Product Name")]
            public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Product Description")]
        [DisplayName ("Product Description")]
            public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Product  Category")]
         [DisplayName ("Product Category")]   
            public string Category { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Invalid format")]
        [DisplayName("Product Price")]
            public double Price { get; set; }
        
        [Required(ErrorMessage = "Please select product Image")]
        [DisplayName("Product Image")]
            public string imagePath { get; set; }

        

    }
}
