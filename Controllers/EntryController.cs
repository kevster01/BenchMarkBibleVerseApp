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
     * This controller handles all verse entry functionality of the program. 
     * Index()--> This method returns the main verse entry form
     * SubmitEntry()--> this method handles the verse entry form data and adds it to the database
     */
    public class EntryController : Controller
    {
        private SecurityService service;
        // GET: Entry
        //Method return starting view
        public ActionResult Index()
        {
            MyLogger.GetInstance().Info(" Entering EntryController");
            return View();
        }

        [HttpPost]
        //Method dedicated to handle entry submissions 
        public ActionResult SubmitEntry(VerseEntryModel model)
        {
            MyLogger.GetInstance().Info(" Inside SubmitEntry");
            try
            {
                service = new SecurityService();
                if (ModelState.IsValid)
                {
                    if (service.AddEntry(model))//Success
                    {
                        MyLogger.GetInstance().Info(" Entry Added --> Inside SubmitEntry");
                        return View("~/Views/Entry/EntrySuccess.cshtml", model);
                    }
                    else//Fail
                    {
                        MyLogger.GetInstance().Error(" Entry was not Added --> Inside SubmitEntry");
                        return View("~/Views/Entry/EntryFailure.cshtml");
                    }
                }
                else
                {
                    //failure message
                    MyLogger.GetInstance().Error(" Entry was not Added --> Inside SubmitEntry");
                    return View("~/Views/Entry/EntryFailure.cshtml");
                }
            }
            catch(Exception e)
            {
                MyLogger.GetInstance().Error(" Exception inside SubmitEntry --> " + e.Message);
                return View("~/Views/Entry/EntryFailure.cshtml");
            }                    
        }
    }
}