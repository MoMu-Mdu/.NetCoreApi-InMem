using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using WebApi2.APIProvider;
using WebApi2.Controllers;
using WebApi2.DTOs;
using WebApi2.Model;
using Xunit;

namespace WebAPI2.Test
{
    public class PersonControllerTest
    {
        [Fact]
        public void Person_GetAll_ReturnsOK()
        {
            // Arrang
            var mockAPIProvider = new Mock<IAPIProvider>();
            var personResult = new PersonDto();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Person, PersonDto>(It.IsAny<Person>())).Returns(personResult);
            var personController = new PersonController(mockAPIProvider.Object, mockMapper.Object);

            // Act
            var actioonResult = personController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(actioonResult);
        }

        [Fact]
        public void Person_GetAll_Returns_Empty_WhenAPI_ReturnsEmpty()
        {
            // Arrang
            var dummyPersonDtoList = new List<PersonDto>();
            var mockAPIProvider = new Mock<IAPIProvider>();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<IEnumerable<PersonDto>>(It.Is<List<Person>>(p => p == null))).Returns(dummyPersonDtoList);
            var personController = new PersonController(mockAPIProvider.Object, mockMapper.Object);

            // Act
            var actioonResult = personController.Get() as OkObjectResult;

            // Assert
            var resultItems = Assert.IsType<List<PersonDto>>(actioonResult.Value);
            Assert.Empty(resultItems);
        }

        [Fact]
        public void Person_GetAll_ReturnAllPerson_With_FirstName_LastName()
        {
            // Arrang
            var dummyPersonList = new List<Person>()
            {
                new Person(){Id =1, FamilyName = "TestFName", GivenName = "TestGName", Age=50, Address="Ireland"},
                new Person(){Id =2, FamilyName = "TestFName", GivenName = "TestGName", Age=50, Address="Ireland"}
            };
            var dummyPersonDtoList = new List<PersonDto>()
            {
                new PersonDto(){Id =1, FirstName = "TestFName", LastName = "TestGName", Age=50, Address="Ireland"},
                new PersonDto(){Id =2, FirstName = "TestFName", LastName = "TestGName", Age=50, Address="Ireland"}
            };
            var mockAPIProvider = new Mock<IAPIProvider>();
            mockAPIProvider.Setup(x => x.Get<List<Person>>(It.IsAny<string>())).Returns(dummyPersonList);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<IEnumerable<PersonDto>>(It.Is<List<Person>>(p => p == dummyPersonList))).Returns(dummyPersonDtoList);
            var personController = new PersonController(mockAPIProvider.Object, mockMapper.Object);

            // Act
            var actioonResult = personController.Get() as OkObjectResult;

            // Assert
            var resultItems = Assert.IsType<List<PersonDto>>(actioonResult.Value);
            Assert.Equal(2, resultItems.Count);
            Assert.Equal(dummyPersonList[0].FamilyName, resultItems[0].FirstName);
            Assert.Equal(dummyPersonList[0].GivenName, resultItems[0].LastName);

        }
    }
}
