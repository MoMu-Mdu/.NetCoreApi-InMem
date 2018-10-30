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
    public class RestAPIProviderTest
    {
        private readonly RestAPIProvder _restAPIProvder;
        public RestAPIProviderTest()
        {
            _restAPIProvder = new RestAPIProvder();
        }

        [Theory]
        [InlineData("")]
        [InlineData("InvalidResource")]
        public void RestAPIProvider_Get_Returns_Null_ForEmptyResource(string resource)
        {
            // Act
            var actionResult = _restAPIProvder.Get<List<Person>>(resource);

            // Assert
            Assert.Null(actionResult);
        }

        [Theory]
        [InlineData("api/Person")]
        public void RestAPIProvider_Get_Returns_ValidData(string resource)
        {
            // Act
            var actionResult = _restAPIProvder.Get<List<Person>>(resource);

            // Assert
            Assert.NotNull(actionResult);
        }
    }
}
