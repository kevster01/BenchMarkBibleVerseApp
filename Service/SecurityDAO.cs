using BenchmarkBibleVerseApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BenchmarkBibleVerseApp.Service
{
    /*
    //public class SecurityDAO
    */

    public class SecurityDAO {



        /*
         *  # method for inserting a verse entry 
         *  into a database based on the provided VerseEntryModel
         *  
         *   method is wrapped in a try-catch block, which is used to handle any 
         *   exceptions that may occur during the database operation.
         */
        public bool AddEntryToDb(VerseEntryModel model)
        {
            try
            {
                using(var conn = ConnectToDb())
                {
                    conn.Open();

                    string sql = "Insert into dbo.Verses(BOOKNAME, CHAPTERNUMBER, VERSENUMBER, VERSETEXT) values(@BOOKNAME, @CHAPTERNUMBER, @VERSENUMBER, @VERSETEXT)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("BOOKNAME", model.BookName);
                        cmd.Parameters.AddWithValue("CHAPTERNUMBER", model.ChapterNumber);
                        cmd.Parameters.AddWithValue("VERSENUMBER", model.VerseNumber);
                        cmd.Parameters.AddWithValue("VERSETEXT", model.VerseText);

                        if(cmd.ExecuteNonQuery() > 0)//Success
                        {
                            return true;
                        }
                        else//Fail
                        {
                            return false;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }


        //empty method 

        public SecurityDAO() { }



        /*
         *  
         *  method for searching and retrieving a verse 
         *  entry from a database based on a provided VerseSearchModel.
         */
        public VerseEntryModel SearchEntryFromDb(VerseSearchModel search)
        {
            try
            {
                using (var conn = ConnectToDb())
                {
                    conn.Open();

                    string sql = "SELECT * FROM [dbo].[t_kjv] WHERE b = @BOOKNAME AND c = @CHAPTERNUMBER AND v = @VERSENUMBER";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BOOKNAME", search.BookName);
                        cmd.Parameters.AddWithValue("@CHAPTERNUMBER", search.ChapterNumber);
                        cmd.Parameters.AddWithValue("@VERSENUMBER", search.VerseNumber);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                VerseEntryModel entry = new VerseEntryModel((int)dr["b"], (int)dr["c"], (int)dr["v"], (string)dr["t"]);
                                return entry;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        //Method used to establish connection to bible database for cross reference
        public SqlConnection ConnectToDb()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bible;Integrated Security=True;
                                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return conn;
        }
    }
}