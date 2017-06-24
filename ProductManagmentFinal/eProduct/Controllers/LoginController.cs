using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjBAL;
using ProjBO;

namespace eProduct.Controllers 
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult login(string Username, string Password)
        {
            LoginBO log = new LoginBO();
            log.Username = Username;
            log.Password = Password;
           
            if (LoginBAL.Login(log))
            {
                Session["user"] = log.Username;
               return RedirectToAction("getAllProd","Product");
            }
            else 
            {
                Session["message"] = "Invalid Username and Password";
                return RedirectToAction("login");
            }
          

           // return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("login");
        }


    }
}
