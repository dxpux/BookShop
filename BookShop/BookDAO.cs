using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop
{
    internal class BookDAO
    {
        public BookDAO()
        {
        }

        internal Book Find(string name)
        {
            List<Book> BookMenu = new List<Book>()
            {
                new Book() { Name = "哈利波特第一集", Price = 100},
                new Book() { Name = "哈利波特第二集", Price = 100},
                new Book() { Name = "哈利波特第三集", Price = 100},
                new Book() { Name = "哈利波特第四集", Price = 100},
                new Book() { Name = "哈利波特第五集", Price = 100},
            };

            var qbook = from book in BookMenu
                        where book.Name == name
                        select book;

            return qbook.FirstOrDefault();
        }
    }
}