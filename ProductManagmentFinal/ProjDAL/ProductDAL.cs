using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjDAL;
using SQLHelper;
using ProjBO;
using System.Data.SqlClient;
using System.Data;
 
namespace ProjDAL
{
    public class ProductDAL
    {

        /// <summary>
        /// Create product- call stored procedure that insert record into Product table
        /// </summary>
        /// <param name="objProduct"></param>

        public static void AddProducts(ProductBO objProduct)
        {
            try
            {
                SQLHelper.SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("createProduct", SQLHelper.SQLHelper.objCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", objProduct.Name);
                cmd.Parameters.AddWithValue("@ProductDiscription", objProduct.Description);
                cmd.Parameters.AddWithValue("@ProductCategory", objProduct.Category);
                cmd.Parameters.AddWithValue("@ProductPrice", objProduct.Price);
                cmd.Parameters.AddWithValue("@ProductImagePath", objProduct.imagePath);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                SQLHelper.SQLHelper.CloseConnection();
            }
        }

        /// <summary>
        /// Create product- call stored procedure that insert record into Product table
        /// </summary>
        /// <param name="objProduct"></param>

        public static void editProduct(ProductBO objProduct)
        {
            try
            {
                SQLHelper.SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("putProduct", SQLHelper.SQLHelper.objCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", objProduct.Name);
                cmd.Parameters.AddWithValue("@ProductDiscription", objProduct.Description);
                cmd.Parameters.AddWithValue("@ProductCategory", objProduct.Category);
                cmd.Parameters.AddWithValue("@ProductPrice", objProduct.Price);
                cmd.Parameters.AddWithValue("@ProductImagePath", objProduct.imagePath);
                cmd.Parameters.AddWithValue("@ProdId", objProduct.ProdId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLHelper.SQLHelper.CloseConnection();
            }
        }


        /// <summary>
        /// Get Product- Retrive product by gven Id
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        /// 
        public static ProductBO GetProductById(int ProductId)
        {
            ProductBO objProd = new ProductBO();
            try
            {
                SQLHelper.SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("getProductbyId", SQLHelper.SQLHelper.objCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProdId", ProductId);
                SqlDataReader objRead = cmd.ExecuteReader();
                while (objRead.Read())
                {
                    objProd.Name = Convert.ToString(objRead["ProductName"]);
                    objProd.Description = Convert.ToString(objRead["ProductDiscription"]);
                    objProd.Category = Convert.ToString(objRead["ProductCategory"]);
                    objProd.Price = Convert.ToInt32(objRead["ProductPrice"]);
                    objProd.imagePath = Convert.ToString(objRead["ProductImagePath"]);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLHelper.SQLHelper.CloseConnection();
            }
            return objProd;
        }

        
             /// <summary>
        /// Get All Products- Retrive all products in Product table
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        /// 
        public static List<ProductBO> GetAllProducts()
        {
            List<ProductBO> products = new List<ProductBO>();
            try
            {
                SQLHelper.SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("getAllProduct", SQLHelper.SQLHelper.objCon);
                cmd.CommandType = CommandType.StoredProcedure;

               
                SqlDataReader objRead =cmd.ExecuteReader();

                while (objRead.Read())
                {
                    ProductBO objProd = new ProductBO();
                    objProd.ProdId = Convert.ToInt32(objRead["ProductId"]);
                    objProd.Name = Convert.ToString(objRead["ProductName"]);
                    objProd.Description = Convert.ToString(objRead["ProductDiscription"]);
                    objProd.Category = Convert.ToString(objRead["ProductCategory"]);
                    objProd.Price = Convert.ToInt32(objRead["ProductPrice"]);
                    objProd.imagePath = Convert.ToString(objRead["ProductImagePath"]);
                    products.Add(objProd);
                }
            
            }
            catch (Exception ex)
            {

            }
            finally
            {
               
            }
            return products;
        }

        /// <summary>
        /// Get Product- Retrive product by gven Id
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        /// 
        public static void deleteProduct(int ProductId)
        {
           
            try
            {
                SQLHelper.SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("deleteProduct", SQLHelper.SQLHelper.objCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProdId",Convert.ToInt32(ProductId));
                var returnValue = cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLHelper.SQLHelper.CloseConnection();
            }
           
        }

        public static void AddProduct(ProductBO product)
        {
           
            try
            {
                SQLHelper.SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("createProduct", SQLHelper.SQLHelper.objCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", product.Name);
                cmd.Parameters.AddWithValue("@ProductPrice", product.Price);
                cmd.Parameters.AddWithValue("@ProductCategory", product.Category);
                cmd.Parameters.AddWithValue("@ProductDiscription", product.Description);
                cmd.Parameters.AddWithValue("@ProductImagePath", product.imagePath);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
           
        }
    }


}
