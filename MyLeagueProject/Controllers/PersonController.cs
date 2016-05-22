using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITemplateProject;
using WebAPITemplateProject.Models;
using WebAPITemplateProject.Tests.Models;

namespace WebAPITemplateProject.Controllers
{
    public class PersonController : ApiController
    {
        private IPersonRepository databasePlaceholder;

        public PersonController(IDatabaseFactory _databaseFactory)
        {
            databasePlaceholder = _databaseFactory.GetPersonRepository();
        }

        public PersonController()
        {
            //If default constructor is called, means it is "real" request
            //IDatabaseFactory factory = new MongoDBDatabaseFactory();
            IDatabaseFactory factory = new TestDatabaseFactory();
            databasePlaceholder = factory.GetPersonRepository();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return databasePlaceholder.GetAll();
        }

        [Route("api/persons/{id}")]
        [HttpGet]
        public Person GetPersonByID(int id)
        {
            Person person = databasePlaceholder.Get(id);
            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return person;
        }


        public HttpResponseMessage PostPerson(Person person)
        {
            person = databasePlaceholder.Add(person);
            string apiName = WebApiConfig.DEFAULT_ROUTE_NAME;
            //this.Request.SetConfiguration(new HttpConfiguration());
            var response =
                this.Request.CreateResponse<Person>(HttpStatusCode.Created, person);
            string uri = Url.Link(apiName, new { id = person.id, controller = "person" });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [Route("api/persons/{id}")]
        [HttpPut]
        public bool PutPerson(Person person)
        {
            if (!databasePlaceholder.Update(person))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return true;
        }

        public void DeletePerson(int id)
        {
            Person person = databasePlaceholder.Get(id);
            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databasePlaceholder.Remove(id);
        }

        [Route("api/persons/{id}/{subcontroller}/{subid}")]
        [HttpPost]
        public HttpResponseMessage PostNotification(Notification notification)
        {
            notification = databasePlaceholder.Add(notification);
            string apiName = WebApiConfig.DEFAULT_ROUTE_NAME;
            var response =
                this.Request.CreateResponse<Notification>(HttpStatusCode.Created, notification);
            string uri = Url.Link(apiName, new { controller = "notification", id = notification.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
