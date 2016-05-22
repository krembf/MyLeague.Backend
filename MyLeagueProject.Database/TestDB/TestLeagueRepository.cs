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
                Type = "Soccer",
                Name = "Bucks County Coed",
                Teams = new List<string>(new string[] { "1", "2" }),
                Seasons = null,
                Address = new Address
                {
                    street = "501 Upper Holland Rd",
                    city = "Richboro",
                    state = "PA",
                    zip = "55451"
                },
                Association = null,
                Image = "http://editor.swagger.io/photos/Bucks_County_Coed",
                LastUpdated = DateTime.Now.ToString()
            }
            );

            this.Add(new League
            {
                Type = "Soccer",
                Name = "Montgomery County Coed League over 30",
                Teams = new List<string>(new string[] { "3", "4" }),
                Seasons = null,
                Address = new Address
                {
                    street = "21 Heaton Rd",
                    city = "Hutington Valley",
                    state = "PA",
                    zip = "19006"
                },
                Association = null,
                Image = "http://editor.swagger.io/photos/Montgomery_County_Coed",
                LastUpdated = DateTime.Now.ToString()
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
                throw new DuplicateEntryException(
                    string.Format("The league with the name {0} already exists in the database", league.Name));
            }

            league.Id = _fakeDatabaseID++.ToString();
            league.LastUpdated = DateTime.Now.ToString();
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
