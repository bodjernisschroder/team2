using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Controller
    {
        public List<Book> books;
        public List<Amulet> amulets;

        public Controller() 
        {
            books = new List<Book>();
            amulets = new List<Amulet>();   
        }

        public void AddToList(Book book) 
        {
            books.Add(book);
        }
        public void AddToList(Amulet amulet)
        {
            amulets.Add(amulet);
        }
    }
}
