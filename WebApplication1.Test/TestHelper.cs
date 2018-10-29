using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Test
{
    public static class TestHelper
    {
        public static AppDbContext GetTestDbCotext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestAppDatabase")
                .Options;
            var dbContext = new AppDbContext(dbContextOptions);
            return dbContext;
        }
    }
}
