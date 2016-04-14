using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITemplateProject.Models
{
    public interface IDatabaseFactory
    {
        IPersonRepository GetPersonRepository();
        IGenericRepository<League> GetLeagueRepository();
        IGenericRepository<Team> GetTeamRepository();
    };

    public interface IDatabase
    {
    };
}
