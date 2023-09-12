using BenchmarkBibleVerseApp.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace BenchmarkBibleVerseApp.Controllers
{
    /*
     * This controller is used to handle the home page of the application
     * Index()--> this method returns the main page of the application
     * onButtonClick()--> This method handles the users choice from the main page and redirects to chosen page
     */
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MyLogger.GetInstance().Info(" Entering HomeController");
            return View();
        }

        [HttpPost]
        //Method handle click action. Depending on the choice of user it
        ////routes them 
        public ActionResult onButtonClick(String btnValue)
        {
            MyLogger.GetInstance().Info(" Inside onButtonClick");
            String ViewName = "";
            if(btnValue == "Entry")
            {
                ViewName = "~/Views/Entry/Index.cshtml";
            }
            else
            {
                ViewName = "~/Views/Search/Index.cshtml";
            }

            return View(ViewName);
        }

    }
}