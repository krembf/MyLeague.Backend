using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Driver;

namespace WebAPITemplateProject.Models
{
    public class MongoDBPersonRepository : IPersonRepository
    {
        public MongoDBPersonRepository()
        {
        }


        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }


        public Person Get(int id)
        {
            throw new NotImplementedException();
        }


        public Person Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            throw new NotImplementedException();
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }


        public bool Update(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            throw new NotImplementedException();
        }
    };

    public class MongoDBDatabaseFactory : IDatabaseFactory
    {
        public IPersonRepository GetPersonRepository()
        {
            return new MongoDBPersonRepository();
        }
    }
}