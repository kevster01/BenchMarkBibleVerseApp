using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BenchmarkBibleVerseApp.Models
{
    public class VerseEntryModel
    {
        [DisplayName("Book Name: ")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(15, ErrorMessage = "Book Name can only be 15 characters long")]
        //getters and setters for book name
        public int BookName { get; set; }

        [DisplayName("Chapter Number: ")]
        [Required]
        //getters and setters for Chapter Number
        public int ChapterNumber { get; set; }

        [DisplayName("Verse Number: ")]
        [Required]
        ////getters and setters for number of verse
        public int VerseNumber { get; set; }

        [DisplayName("Verse Text: ")]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(200, ErrorMessage = "Verse Text can only be 200 characters long")]
        ////getters and setters for verse text content
        public string VerseText { get; set; }

        //empty metho
        public VerseEntryModel() { }

        //constructors
        public VerseEntryModel(int bookname, int chapternumber, int versenumber, string versetext)
        {
            this.BookName = bookname;
            this.ChapterNumber = chapternumber;
            this.VerseNumber = versenumber;
            this.VerseText = versetext;
        }             
    }
}