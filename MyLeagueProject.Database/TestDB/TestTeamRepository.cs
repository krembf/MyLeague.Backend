using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAPITemplateProject.Models;

namespace WebAPITemplateProject.Tests.Models
{
    class TestTeamRepository : IGenericRepository<Team>
    {
        private List<Team> _teams = new List<Team>();
        private int _fakeDatabaseID = 1;

        public TestTeamRepository()
        {
            this.Add(new Team
            {
                id = 1,
                name = "FC InterStars",
                captainid = 1,
                coachid = 1,
                colors = new Colors() { home = "Yellow", away = "Green"},
                logo = "",
                status = "Active",
                players = new List<Player>(new Player[] 
                { 
                    new Player() { id = 1, personid = 1, role = "Right wing-back (RWB)", shirt_number = "9" },
                    new Player() { id = 2, personid = 2, role = "Center-back (CB)", shirt_number = "9" } 
                }),
            }
            );
        }

        public IEnumerable<Team> GetAll()
        {
            return _teams;
        }

        public Team GetById(string id)
        {
            return _teams.Find(p => p.id.Equals(id));
        }

        public ICollection<Team> GetByName(string name)
        {
            return _teams.FindAll(x => x.name.Contains(name));
        }

        public Team Add(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("team");
            }
            team.id = _fakeDatabaseID++;
            _teams.Add(team);
            return team;
        }

        public void Remove(string id)
        {
            _teams.RemoveAll(p => p.id.Equals(id));
        }

        public bool Update(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException("team");
            }
            int index = _teams.FindIndex(p => p.id == team.id);
            if (index == -1)
            {
                return false;
            }
            _teams.RemoveAt(index);
            _teams.Add(team);
            return true;
        }
    }
}
