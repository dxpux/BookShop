using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Tests
{
    [TestClass()]
    public class BookShopTests
    {
        [TestMethod()]
        public void GetTotal_只買哈利波特第一集共100元()
        {
            //Arrange
            var target = new BookShop();
            double expect = 100;
            //Act
            target.AddBookList(target.GetBook("哈利波特第一集"));
            var actual = target.GetTotal();

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void GetTotal_買哈利波特_壹x1_貮x1_共190()
        {
            //Arrange
            var target = new BookShop();
            double expect = (100 + 100) * 0.95;
            //Act
            target.AddBookList(target.GetBook("哈利波特第一集"));
            target.AddBookList(target.GetBook("哈利波特第二集"));
            var actual = target.GetTotal();

            //Assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void GetTotal_買哈利波特_壹x1_貮x1_參x1_共270()
        {
            //Arrange
            var target = new BookShop();
            double expect = (100 + 100 + 100) * 0.9;
            //Act
            target.AddBookList(target.GetBook("哈利波特第一集"));
            target.AddBookList(target.GetBook("哈利波特第二集"));
            target.AddBookList(target.GetBook("哈利波特第三集"));
            var actual = target.GetTotal();

            //Assert
            Assert.AreEqual(expect, actual);
        }
    }
}