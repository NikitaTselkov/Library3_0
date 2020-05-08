using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Tests
{
    [TestClass()]
    public class HelperTests
    {
        [TestMethod()]
        public void MyGetHashCodeTest()
        {
            // Arrange
            var _string1 = Guid.NewGuid().ToString();
            var _string2 = Guid.NewGuid().ToString();

            // Act
            var result1 = _string1.MyGetHashCode();
            var result2 = _string1.MyGetHashCode();
            var result3 = _string2.MyGetHashCode();

            // Assert
            Assert.AreEqual(result1, result2);
            Assert.AreNotEqual(result3, _string2);
        }
    }
}