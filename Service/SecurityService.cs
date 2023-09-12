using BenchmarkBibleVerseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchmarkBibleVerseApp.Service
{
    public class SecurityService
    {
        //This field presumably holds an
        //instance of the SecurityDAO class, which is used for
        //database operations
        public SecurityDAO security;

        /*
         *  constructor does not take any arguments and appears to be empty.
         */
        public SecurityService() { }

        /*
         * This method is responsible for adding a verse entry to the database. It creates a new instance of the SecurityDAO 
         * class (assigned to the security field) and then calls the AddEntryToDb method of the SecurityDAO class, passing in
         * the model parameter. It returns a bool value indicating whether the addition was successful (true) or not (false).
         */
        public bool AddEntry(VerseEntryModel model)
        {
            security = new SecurityDAO();
            return security.AddEntryToDb(model);
        }

        /*
         *  method is responsible for searching for a verse entry in the database based on the provided search parameter.
         *  Similar to the AddEntry method, it creates a new instance of the SecurityDAO class (assigned to the security field)
         *  and then calls the SearchEntryFromDb method of the SecurityDAO class, passing in the search parameter. It returns a 
         *  VerseEntryModel object representing the searched verse entry or null if no entry is found.
         */

        public VerseEntryModel SearchEntry(VerseSearchModel search)
        {
            security = new SecurityDAO();
            return security.SearchEntryFromDb(search);            
        }
    }
}