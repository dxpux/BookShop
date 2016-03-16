using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class BookShop
    {
        private List<Book> Cart;
        public BookShop()
        {
            Cart = new List<Book>();
        }

        public Book GetBook(string name)
        {
            return new BookDAO().Find(name);
        }

        public void AddBookList(Book book)
        {
            Cart.Add(book);
        }

        public double GetTotal()
        {
            var total = (from book in Cart
                     select book.Price).Sum();

            return total;
        }
    }
}
