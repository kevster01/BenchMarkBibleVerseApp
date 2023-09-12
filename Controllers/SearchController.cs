using BenchmarkBibleVerseApp.Models;
using BenchmarkBibleVerseApp.Service;
using BenchmarkBibleVerseApp.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BenchmarkBibleVerseApp.Controllers
{
    /*
     * This class handles the search functionality of the program. 
     * Index() --> returns Index page with search form
     * onButtonClick()--> This method handles the search form data and performs search for specified verse
     */
    public class SearchController : Controller
    {

        private SecurityService service;
        // GET: Search
        public ActionResult Index()
        {
            MyLogger.GetInstance().Info(" Entering SearchController");
            return View();
        }

        [HttpPost]
        //Handles onclick action for searching. and returns dedicated form depending on input result
        public ActionResult onButtonClick(VerseSearchModel search)
        {
            MyLogger.GetInstance().Info(" Inside onButtonClick");
            try
            {
                if (ModelState.IsValid)
                {
                    service = new SecurityService();
                    var result = service.SearchEntry(search);

                    if(result != null)
                    {
                        //Found
                        MyLogger.GetInstance().Info(" Verse has been found!");
                        return View("SearchSuccess", result);
                    }
                    else
                    {
                        //Not found
                        MyLogger.GetInstance().Info(" Verse was not found!");
                        return View("SearchFailure", search);
                    }
                }
                else
                {
                    MyLogger.GetInstance().Info(" Verse was not found!");
                    return View("SearchFailure", search);
                }
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error(" Exception inside onButtonClick --> " + e.Message);
                return View("SearchFailure", search);
            }          
        }
    }
}