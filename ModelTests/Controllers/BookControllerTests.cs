using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.BookFolder;
using Model.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Controllers.Tests
{
    [TestClass()]
    public class BookControllerTests
    {
        [TestMethod()]
        public void BookControllerTest()
        {
            // Arrange
            var Title = Guid.NewGuid().ToString();
            var _code = Guid.NewGuid().ToString();
            var _using = Guid.NewGuid().ToString();
            var _template = Guid.NewGuid().ToString();
            var _definition = new List<ListDefinition>() { new ListDefinition(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()) };
            var _propertie = new List<ListDefinition>() { new ListDefinition(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()) };
            var _return = new List<ListDefinition>() { new ListDefinition(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()) };
            var controller = new BookController(Title);

            // Act
            controller.SetNewBookData(_code, _using, _template, _definition, _propertie, _return);
            var controller2 = new BookController(Title);

            // Assert
            Assert.AreEqual(controller2.CurrentBook.Title, Title);
            Assert.AreEqual(controller2.CurrentBook.Code, _code);
            Assert.AreEqual(controller2.CurrentBook.Using, _using);
            Assert.AreEqual(controller2.CurrentBook.Template, _template);
            Assert.AreEqual(controller2.CurrentBook.Definition.First().Definition, _definition.First().Definition);
            Assert.AreEqual(controller2.CurrentBook.Propertie.First().Definition, _propertie.First().Definition);
            Assert.AreEqual(controller2.CurrentBook.Return.First().Definition, _return.First().Definition);
            Assert.AreEqual(controller2.CurrentBook.Definition.First().Title, _definition.First().Title);
            Assert.AreEqual(controller2.CurrentBook.Propertie.First().Title, _propertie.First().Title);
            Assert.AreEqual(controller2.CurrentBook.Return.First().Title, _return.First().Title);
        }

    }
}