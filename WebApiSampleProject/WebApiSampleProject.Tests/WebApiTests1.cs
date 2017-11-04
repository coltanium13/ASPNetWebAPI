﻿using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using WebApiSampleProject.Controllers;
using WebApiSampleProject.Models;
using System.Collections.Generic;
using System.Net.Http;

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
            Assert.That(testEmployee.EmployeeId == 2);
        }

        [Test]
        public void GetEmployeeByName_ShouldReturnSpecificName()
        {
            Employee testEmployee = Controller.GetEmployeeByName("manish");
            Assert.That(testEmployee.EmployeeName.ToLower(), Contains.Substring("manish"));
        }
        
        
        [Test]
        [Ignore("how to throw exception")]
        public void GetNoEmployeeById_ShouldThrowException()
        {
            var test = Controller.GetEmployeeDetails(100);
            Assert.Fail();
        }
    }
}