using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAPITemplateProject.Models;
using MyLeagueProject.Database.Exceptions;

namespace WebAPITemplateProject.Tests.Models
{
    class TestLeagueRepository : IGenericRepository<League>
    {
        private List<League> _leagues = new List<League>();
        private int _fakeDatabaseID = 1;

        public TestLeagueRepository()
        {
            this.Add(new League
            {
                Name = "Bucks County Coed",
                Type = "Soccer",
                Teams = new List<string>(new string[] { "1", "2" })
            }
            );

            this.Add(new League
            {
                Name = "Montgomery County Coed League over 30",
                Type = "Soccer",
                Teams = new List<string>(new string[] { "3", "4" })
            }
            );
        }

        public IEnumerable<League> GetAll()
        {
            return _leagues;
        }

        public League GetById(string id)
        {
            return _leagues.Find(p => p.Id == id);
        }

        public ICollection<League> GetByName(string name)
        {
            return _leagues.FindAll(x => (x.Name.Contains(name) && x.Type.Contains(name)));
        }

        public League Add(League league)
        {
            if (league == null)
            {
                throw new ArgumentNullException("league");
            }

            //Search for duplicate leagues
            var found = _leagues.Where(l => l.Name == league.Name);
            if(found.Any())
            {
                throw new DuplicateEntryException("There is already a league with the same name");
            }

            league.Id = _fakeDatabaseID++.ToString();
            league.LastUpdated = DateTime.Now.ToString();
            league.Association = string.Empty;
            _leagues.Add(league);
            return league;
        }

        public void Remove(string id)
        {
            _leagues.RemoveAll(p => p.Id == id);
        }

        public bool Update(League league)
        {
            if (league == null)
            {
                throw new ArgumentNullException("league");
            }
            int index = _leagues.FindIndex(p => p.Id == league.Id);
            if (index == -1)
            {
                return false;
            }
            _leagues.RemoveAt(index);
            _leagues.Add(league);
            return true;
        }
    }
}
