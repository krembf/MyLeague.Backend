using MyLeagueProject.Database.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPITemplateProject;
using WebAPITemplateProject.Models;
using WebAPITemplateProject.Tests.Models;

namespace WebAPITemplateProject.Controllers
{
    public class LeaguesController : ApiController
    {
        private IGenericRepository<League> databasePlaceholder;

        public LeaguesController(IDatabaseFactory _databaseFactory)
        {
            databasePlaceholder = _databaseFactory.GetLeagueRepository();
        }

        public LeaguesController()
        {
            //If default constructor is called, means it is "real" request
            //IDatabaseFactory factory = new MongoDBDatabaseFactory();
            IDatabaseFactory factory = new TestDatabaseFactory();
            databasePlaceholder = factory.GetLeagueRepository();
        }

        public IEnumerable<League> GetAllLeagues()
        {
            List<League> leagues = databasePlaceholder.GetAll() as List<League>;

            if (leagues == null || leagues.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return leagues;
        }

        public League GetLeagueByID(int id)
        {
            League league = databasePlaceholder.GetById(id.ToString());
            if (league == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return league;
        }

        /// <summary>
        /// Method returns a league by a given name
        /// http://localhost:53403/api/leagues?latitude=25&longitude=15&type=Soccer&name=Bucks
        /// Case where the latitude and longitude are null
        /// http://localhost:53403/api/leagues?latitude=&longitude=&type=Soccer&name=Bucks
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="HTTPResponseException"></exception>
        public ICollection<League> Get(string latitude, string longitude, string type, string name)
        {
            //Validate arguments
            if(latitude == null || longitude == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var leagues = databasePlaceholder.GetAll() as List<League>;

            if (leagues == null || leagues.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            if(name != null)
            {
                var queryLeaguesByName = from league in leagues
                                         where league.Name.Contains(name) || league.Type.Contains(name)
                                         select league;

                if(queryLeaguesByName.Count() == 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }

            return leagues;
        }

        /// <summary>
        /// Method returns a league by the name and type
        /// http://localhost:53403/api/leagues?type=Soccer&name=Bucks
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ICollection<League> Get(string type, string name)
        {
            //Validate arguments
            if (type == null || name == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var leagues = databasePlaceholder.GetAll() as List<League>;

            if (leagues == null || leagues.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            if (name != null)
            {
                var queryLeaguesByName = from league in leagues
                                         where league.Name.Contains(name) || league.Type.Contains(name)
                                         select league;

                if (queryLeaguesByName.Count() == 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }

            return leagues;
        }

        public HttpResponseMessage PostLeague(League league)
        {
            HttpResponseMessage response;
            try
            {
                league = databasePlaceholder.Add(league);
            }
            catch(ArgumentNullException)
            {
                return this.Request.CreateResponse<League>(HttpStatusCode.BadRequest, league);
            }
            catch(DuplicateEntryException ex)
            {
                response = this.Request.CreateResponse<League>(HttpStatusCode.Conflict, league);
                response.Headers.Add("X-Status-Reason", ex.Message);
                return response;
            }

            string apiName = WebApiConfig.DEFAULT_ROUTE_NAME;
            response =
                this.Request.CreateResponse<League>(HttpStatusCode.Created, league);
            string uri = Url.Link(apiName, new { id = league.Id, controller = "league" });
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


        public void DeleteLeague(string id)
        {
            League league = databasePlaceholder.GetById(id);
            if (league == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databasePlaceholder.Remove(id);
        }

        public ICollection<string> GetTeamsByLeague(int id)
        {
            League league = this.GetLeagueByID(id);

            return league.Teams;
        }
    }
}
