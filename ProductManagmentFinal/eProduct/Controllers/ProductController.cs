using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjBAL;
using ProjBO;
using System.IO;


namespace eProduct.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        ProdBAL BAL = new ProdBAL();
        ProductBO BO = new ProductBO();
        

        public ActionResult Index()
        {
            if(Session["user"] != null )
            {
                return View("getAllProd");
            }
            else
            {
                return RedirectToAction("login","Login");
            }
        }

     /*   public ActionResult getById(int Id)
        {
            var Prod = ProdBAL.GetProductId(Id);
            ViewData["Name"] = Prod.Name;
            ViewData["Cat"] = Prod.Category;
            ViewData["Description"] = Prod.Description;
            ViewData["Price"] = Prod.Price;
            ViewData["Path"] = Prod.imagePath;
           return View();
        }*/

        public ActionResult getAllProd()
        {
           
           var Prod =   ProdBAL.GetAllProducts();
          
           if (Session["user"] != null)
           {
               return View(Prod);
           }
           else
           {

               return RedirectToAction("login", "Login");
           }
           

           
        }

        [HttpGet]
        public ActionResult create()
        {


            return View();
        }

        [HttpPost]
        public ActionResult create(string Name, string Category, String Description, int Price, string ImagePath, HttpPostedFileBase file)
        {
           
           ProductBO product = new ProductBO();
            product.Name =Name;
            product.Description = Description;
            product.Category = Category;
            product.Price = Price;

            if (file != null && file.ContentLength > 0)
            {
                string fi = Path.GetExtension(file.FileName);
                if (fi.Equals(".jpg") || fi.Equals(".png"))
                {
                    //Get Filename from fileupload control
                    string filename = Path.GetFileName(file.FileName);
                    //Save images into Images folder
                    string s = "/image/" + filename;
                    file.SaveAs(Server.MapPath(s));
                    product.imagePath = s;

                    ProdBAL.AddProduct(product);
                    return RedirectToAction("getAllProd");
                }
                else
                {
                    TempData["errorMsg"] = fi + " is not valid format Please Select jpg or png file";
                    return RedirectToAction("create");
                }
            }
            else
            {
                TempData["errorMsg"] = "please upload file first";
                return RedirectToAction("create");
            }
        }

        [HttpGet]
        public ActionResult editProduct(int id)
        {
            
            ProductBO product = ProdBAL.GetProductById(id);

            product.ProdId = id;
            return View(product);
        }

        [HttpPost]
        public ActionResult editProduct(string ProdId,string Name, string Category, String Description, int Price, string ImagePath,HttpPostedFileBase file)
        {
            
            

           
           if (file != null && file.ContentLength > 0)
           {
               string fi = Path.GetExtension(file.FileName);
               if (fi.Equals(".jpg") || fi.Equals(".png"))
               {

                   string fname = file.FileName;
                   //Get Filename from fileupload control
                   string filename = Path.GetFileName(file.FileName);
                   //Save images into Images folder
                   string s = "../../image/" + filename;
                   file.SaveAs(Server.MapPath(s));









                   ProductBO product = new ProductBO();

                   product.ProdId = Convert.ToInt32(ProdId);
                   product.Name = Name;
                   product.Description = Description;
                   product.Category = Category;
                   product.Price = Price;
                   product.imagePath = s;

                   ProdBAL.editProduct(product);

                   return RedirectToAction("getAllProd");
               }

               else
               {
                   TempData["errorMsg"] = fi + " is not valid format Please Select jpg or png file";
                   return RedirectToAction("editProduct");
               }
           }
           else
           {
               TempData["errorMsg"] = "please upload file first";
               return RedirectToAction("editProduct");
           }
        }


        public ActionResult DeleteProduct(int id)
        {
           
            ProdBAL.deleteProduct(id);

            return RedirectToAction("getAllProd");
        }
    }
}
