﻿using System;
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

            double discount = GetDiscount();
            return total - discount;
        }
        private double GetDiscount()
        {
            Dictionary<String, Int32> BookCount = new Dictionary<string, int>();
            foreach (var book in Cart)
            {
                string name = book.Name;
                if (BookCount.ContainsKey(name))
                {
                    //有值 +1
                    BookCount[name] = BookCount[name] + 1;
                }
                else
                {
                    BookCount.Add(name, 1);
                }
            }
            int[] buyOff = { 0, 0, 0, 0,};

            for (int i = buyOff.Count(); i > -1; i--)
            {
                while ((from book in BookCount where book.Value > 0 select book).Count() == i + 2)
                {
                    buyOff[i] = buyOff[i] + 1;

                    var restBook = (from book in BookCount where book.Value > 0 select book).ToList();
                    foreach (var book in restBook)
                    {
                        BookCount[book.Key] = book.Value - 1;
                    }
                }
            }

            return buyOff[0] * 10 + buyOff[1] * 30 + buyOff[2] * 80 + buyOff[3] * 125;
        }
    }
}
