using System;
using Microsoft.AspNetCore.Mvc;
using mrs.Controllers;
using NUnit.Framework;

namespace mrs.TESTS
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestHomeIndex()
        {
            var obj = new HomeController();
            var actRes = obj.Index() as ViewResult;
            Assert.That(actRes.ViewData["Message"], Is.EqualTo("Message"));
        }
    }
}
