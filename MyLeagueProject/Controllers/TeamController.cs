using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITemplateProject.Models;

namespace WebAPITemplateProject.Controllers
{
    public class TeamController : ApiController
    {
        private IGenericRepository<Team> databasePlaceholder;

        public TeamController(IDatabaseFactory _databaseFactory)
        {
            databasePlaceholder = _databaseFactory.GetTeamRepository();
        }

        public TeamController()
        {
            //If default constructor is called, means it is "real" request
            IDatabaseFactory factory = new MongoDBDatabaseFactory();
            databasePlaceholder = factory.GetTeamRepository();
        }

        public IEnumerable<Team> GetAllPeople()
        {
            return databasePlaceholder.GetAll();
        }

        [Route("api/{controller}/{id}")]
        [HttpGet]
        public Team GetTeamByID(int id)
        {
            Team team = databasePlaceholder.Get(id);
            if (team == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return team;
        }


        public HttpResponseMessage PostTeam(Team team)
        {
            team = databasePlaceholder.Add(team);
            string apiName = WebApiConfig.DEFAULT_ROUTE_NAME;
            var response =
                this.Request.CreateResponse<Team>(HttpStatusCode.Created, team);
            string uri = Url.Link(apiName, new { id = team.id, controller = "team" });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        public bool PutTeam(Team team)
        {
            if (!databasePlaceholder.Update(team))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return true;
        }


        public void DeleteTeam(int id)
        {
            Team team = databasePlaceholder.Get(id);
            if (team == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databasePlaceholder.Remove(id);
        }
    }
}
