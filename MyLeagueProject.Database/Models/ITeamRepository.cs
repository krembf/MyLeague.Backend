using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITemplateProject.Models
{
    interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        Team Get(int id);
        Team Add(Team team);
        void Remove(int id);
        bool Update(Team team);
    }
}
