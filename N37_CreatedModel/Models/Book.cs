using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_CreatedModel.Models
{
    public class Books
    {
        //Book: A tuple with elements for the title, author, and publication year of a book.
        public static (string title, string author, int publicationYear) 
            Book = ("Sherlok Xolms", "Konan Duel", 1990);
        string tts = Book.title;
        string aut = Book.author;
        int yaer = Book.publicationYear;
    }
}
