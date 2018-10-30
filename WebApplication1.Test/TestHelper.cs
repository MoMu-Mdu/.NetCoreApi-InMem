using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Test
{
    public static class TestHelper
    {
        public static WebAPIDbContext GetTestDbCotext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<WebAPIDbContext>()
                .UseInMemoryDatabase("TestAppDatabase")
                .Options;
            var dbContext = new WebAPIDbContext(dbContextOptions);
            return dbContext;
        }
    }
}
