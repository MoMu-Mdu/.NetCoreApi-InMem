using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class PersonRepository : IPersonRepository
    {
        //private readonly WebAPIDbContext _dbContext;
        
        public PersonRepository()
        {
        }

        public List<Person> GetUsers()
        {
            List<Person> fackPersonList = new List<Person>()
            {
                new Person() { Id = 1, GivenName = "Peter", FamilyName = "Casey", Age = 61, Address = "LondonDerry" },
                new Person() { Id = 2, GivenName = "Liadh", FamilyName = "Riada", Age = 51, Address = "Dublin" },
                new Person() { Id = 3, GivenName = "Michael", FamilyName = "Higgins", Age = 77, Address = "Limerick" }
            };

            //if(_dbContext.Persons.Count() <= 0)
            //{
            //    _dbContext.Persons.Add(new Person() { Id = 1, GivenName = "Peter", FamilyName = "Casey", Age = 61, Address = "LondonDerry" });
            //    _dbContext.Persons.Add(new Person() { Id = 2, GivenName = "Liadh", FamilyName = "Riada", Age = 51, Address = "Dublin" });
            //    _dbContext.Persons.Add(new Person() { Id = 3, GivenName = "Michael", FamilyName = "Higgins", Age = 77, Address = "Limerick" });
            //    _dbContext.SaveChanges();
            //}
            //return _dbContext.Persons.ToList();

            return fackPersonList;
        }
    }
}
