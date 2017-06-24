using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjBO;
using ProjDAL;


namespace ProjBAL
{
    public class ProdBAL
    {

        public static ProductBO GetProductById(int pro_id)
        {
            return ProductDAL.GetProductById(pro_id);
        }

        public static List<ProductBO> GetAllProducts()
        {
            return ProductDAL.GetAllProducts();
        }
        public static void AddProduct(ProductBO product)
        {
             ProductDAL.AddProducts(product);
        }
        public static void editProduct(ProductBO product)
        {
            ProductDAL.editProduct(product);
        }
        public static void deleteProduct(int id)
        {
            ProductDAL.deleteProduct(id);
        }
    }
}
