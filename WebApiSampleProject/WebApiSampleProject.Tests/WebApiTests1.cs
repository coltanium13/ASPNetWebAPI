using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using WebApiSampleProject.Controllers;
using WebApiSampleProject.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

namespace WebApiSampleProject.Tests
{
    [TestFixture]
    public class WebApiTests1
    {
        #region variable declaration
        EmployeeController Controller;
#endregion

        [SetUp]
        public void SetupTestObjects()
        {
            Controller = new EmployeeController();
            Controller.Request = new HttpRequestMessage()
            {
                Properties = { { System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey, new System.Web.Http.HttpConfiguration() } }
            };
        }

        [TearDown]
        public void TearDownTests()
        {

        }

        [Test]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            Assert.That(Controller.GetAllEmployees(), Is.Not.Null);
        }

        [Test]
        public void GetEmployeeById_ShouldReturnSpecificId()
        {
            var testEmployee = Controller.GetEmployeeDetails(2);
            Assert.That(testEmployee.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void GetEmployeeByName_ShouldReturnSpecificName()
        {
            HttpResponseMessage testEmployee = Controller.GetEmployeeByName("manish");
            Assert.That(testEmployee.StatusCode == HttpStatusCode.OK);
        }
        
        
        [Test]
        public void GetNoEmployeeById_ShouldThrowException()
        {
            var test = Controller.GetEmployeeDetails(100);
            Assert.That(HttpStatusCode.NotFound == test.StatusCode);
        }
    }
}
