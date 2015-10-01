using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITemplateProject;
using WebAPITemplateProject.Models;

namespace WebAPITemplateProject.Controllers
{
    public class LeagueController : ApiController
    {
        private IGenericRepository<League> databasePlaceholder;

        public LeagueController(IDatabaseFactory _databaseFactory)
        {
            databasePlaceholder = _databaseFactory.GetLeagueRepository();
        }

        public LeagueController()
        {
            //If default constructor is called, means it is "real" request
            IDatabaseFactory factory = new MongoDBDatabaseFactory();
            databasePlaceholder = factory.GetLeagueRepository();
        }

        public IEnumerable<League> GetAllLeagues()
        {
            return databasePlaceholder.GetAll();
        }

        public League GetLeagueByID(int id)
        {
            League league = databasePlaceholder.Get(id);
            if (league == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return league;
        }

        public ICollection<League> GetLeagueByName(string name)
        {
            List<League> leagues = databasePlaceholder.Get(name) as List<League>;

            if (leagues == null || leagues.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return leagues;
        }

        public HttpResponseMessage PostLeague(League league)
        {
            league = databasePlaceholder.Add(league);
            string apiName = WebApiConfig.DEFAULT_ROUTE_NAME;
            //this.Request.SetConfiguration(new HttpConfiguration());
            var response =
                this.Request.CreateResponse<League>(HttpStatusCode.Created, league);
            string uri = Url.Link(apiName, new { id = league.id, controller = "league" });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        public bool PutLeague(League league)
        {
            if (!databasePlaceholder.Update(league))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return true;
        }


        public void DeleteLeague(int id)
        {
            League league = databasePlaceholder.Get(id);
            if (league == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databasePlaceholder.Remove(id);
        }

        public List<int> GetTeamsByLeague(int id)
        {
            League league = this.GetLeagueByID(id);

            return league.teams;
        }
    }
}
