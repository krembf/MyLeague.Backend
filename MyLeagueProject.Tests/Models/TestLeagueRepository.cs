using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAPITemplateProject.Models;

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
                name = "Bucks County Coed",
                type = "Soccer",
                teams = new List<int>(new int[] {1, 2})
            }
            );

            this.Add(new League
            {
                name = "Montgomery County Coed League over 30",
                type = "Soccer",
                teams = new List<int>(new int[] { 3, 4 })
            }
            );
        }

        public IEnumerable<League> GetAll()
        {
            return _leagues;
        }

        public League Get(int id)
        {
            return _leagues.Find(p => p.id == id);
        }

        public ICollection<League> Get(string name)
        {
            return _leagues.FindAll(x => x.name.Contains(name));
        }

        public League Add(League league)
        {
            if (league == null)
            {
                throw new ArgumentNullException("league");
            }
            league.id = _fakeDatabaseID++;
            _leagues.Add(league);
            return league;
        }

        public void Remove(int id)
        {
            _leagues.RemoveAll(p => p.id == id);
        }

        public bool Update(League league)
        {
            if (league == null)
            {
                throw new ArgumentNullException("league");
            }
            int index = _leagues.FindIndex(p => p.id == league.id);
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
