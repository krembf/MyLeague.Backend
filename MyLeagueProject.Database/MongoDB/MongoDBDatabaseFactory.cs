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

        public Notification Add(Notification notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }
            throw new NotImplementedException();
        }
    };

    public class MongoDBLeagueRepository : IGenericRepository<League>
    {
        public MongoDBLeagueRepository()
        {
        }


        public IEnumerable<League> GetAll()
        {
            throw new NotImplementedException();
        }

        public League GetById(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<League> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public League Add(League league)
        {
            if (league == null)
            {
                throw new ArgumentNullException("league");
            }
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }


        public bool Update(League league)
        {
            if (league == null)
            {
                throw new ArgumentNullException("league");
            }
            throw new NotImplementedException();
        }
    };

    public class MongoDBTeamRepository : IGenericRepository<Team>
    {
        public MongoDBTeamRepository()
        {
        }


        public IEnumerable<Team> GetAll()
        {
            throw new NotImplementedException();
        }


        public Team GetById(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Team> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Team Add(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("team");
            }
            throw new NotImplementedException();
        }


        public void Remove(string id)
        {
            throw new NotImplementedException();
        }


        public bool Update(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("team");
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

        public IGenericRepository<League> GetLeagueRepository()
        {
            return new MongoDBLeagueRepository();
        }

        public IGenericRepository<Team> GetTeamRepository()
        {
            return new MongoDBTeamRepository();
        }
    }
}