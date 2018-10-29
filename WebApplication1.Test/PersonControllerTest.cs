using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Xunit;

namespace WebApplication1.Test
{
    public class PersonControllerTest
    {
        private AppDbContext _context;
        private PersonController _personController;
        public PersonControllerTest()
        {
            _context = TestHelper.GetTestDbCotext();
            _personController = new PersonController(_context);

        }
        [Fact]
        public void Person_GetAll_ReturnsOK()
        {
            // Act
            var people = _personController.GetAllPerson();

            // Assert
            Assert.IsType<OkObjectResult>(people);
        }

        [Fact]
        public void Person_GetAll_Returns_ReturnsAllPerson()
        {
            // Arrange
            _context.Persons.Add(new Person() { GivenName = "Peter", FamilyName = "Casey", Age = 61, Address = "LondonDerry" });
            _context.Persons.Add(new Person() { GivenName = "Michael", FamilyName = "Higgins", Age = 77, Address = "Limerick" });
            _context.SaveChanges();

            // Act
            var result = _personController.GetAllPerson() as OkObjectResult;

            // Asset
            var items = Assert.IsType<List<Person>>(result.Value);
            Assert.Equal(2, items.Count);
        }
    }
}
