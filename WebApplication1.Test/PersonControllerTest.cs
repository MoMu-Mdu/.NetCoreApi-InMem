using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;
using Xunit;

namespace WebApplication1.Test
{
    public class PersonControllerTest
    {
        private PersonController _personController;
        public PersonControllerTest()
        {

        }
        [Fact]
        public void Person_GetAll_ReturnsOK()
        {
            // Arrange
            var mockRepo = new Mock<IPersonRepository>();
            _personController = new PersonController(mockRepo.Object);
            // Act
            var people = _personController.GetAllPerson();

            // Assert
            Assert.IsType<OkObjectResult>(people);
        }

        [Fact]
        public void Person_GetAll_Returns_ReturnsAllPerson()
        {
            // Arrange
            var fackPersonList = new List<Person>() {
            new Person() { GivenName = "Peter", FamilyName = "Casey", Age = 61, Address = "LondonDerry" },
            new Person() { GivenName = "Michael", FamilyName = "Higgins", Age = 77, Address = "Limerick" }};
            var mockRepo = new Mock<IPersonRepository>();
            mockRepo.Setup(x => x.GetUsers()).Returns(fackPersonList);
            _personController = new PersonController(mockRepo.Object);

            // Act
            var result = _personController.GetAllPerson() as OkObjectResult;

            // Asset
            var items = Assert.IsType<List<Person>>(result.Value);
            Assert.Equal(2, items.Count);
        }
    }
}
