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
    public class PersonController : ApiController
    {
        private IPersonRepository databasePlaceholder;

        public PersonController(IDatabaseFactory _databaseFactory)
        {
            databasePlaceholder = _databaseFactory.GetPersonRepository();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return databasePlaceholder.GetAll();
        }

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
            this.Request.SetConfiguration(new HttpConfiguration());
            var response =
                this.Request.CreateResponse<Person>(HttpStatusCode.Created, person);
            string uri = Url.Link(apiName, new { id = person.Id, controller = "person" });
            response.Headers.Location = new Uri(uri);
            return response;
        }


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
    }
}
