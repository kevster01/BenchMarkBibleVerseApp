using System.Web;
using System.Web.Mvc;

namespace BenchmarkBibleVerseApp
{
    /*
         code configures global error handling for the application by adding the HandleErrorAttribute
        filter to the global filter collection, which will handle errors and exceptions that occur during 
         the execution of controller actions. This is a common practice in ASP.NET applications to 
            provide a consistent way to handle errors
     
     */
    public class FilterConfig
    {
        //This method is responsible for registering global filters.
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
