using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPITemplateProject.Models;

namespace WebAPITemplateProject.Tests.Models
{
    public class TestDatabaseFactory : IDatabaseFactory
    {
        public IPersonRepository GetPersonRepository()
        {
            return new TestPersonRepository();
        }

        public IGenericRepository<League> GetLeagueRepository()
        {
            return new TestLeagueRepository();
        }

        public IGenericRepository<Team> GetTeamRepository()
        {
            return new TestTeamRepository();
        }
    }
}
