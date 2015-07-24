using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPITemplateProject.Controllers;
using WebAPITemplateProject.Tests.Models;
using WebAPITemplateProject.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;

namespace WebAPITemplateProject.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        private static void SetupControllerForTests(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/person");
            var route = config.Routes.MapHttpRoute(WebApiConfig.DEFAULT_ROUTE_NAME, "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "person" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Url = new UrlHelper(request);
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

            // Web API routes
            config.MapHttpAttributeRoutes();
        }

        [TestMethod]
        public void TestGetAllPeople()
        {
            IDatabaseFactory databaseFactory = new TestDatabaseFactory();
            PersonController personController = new PersonController(databaseFactory);

            List<Person> persons = null;
            persons = (List<Person>) personController.GetAllPeople();

            Assert.AreEqual<int>(2, persons.Count);
        }

        [TestMethod]
        public void TestGetPersonByID()
        {
            IDatabaseFactory databaseFactory = new TestDatabaseFactory();
            PersonController personController = new PersonController(databaseFactory);

            Person person = null;
            person = personController.GetPersonByID(1);

            Assert.AreEqual<int>(1, person.Id);
            Assert.AreEqual<string>("Boris", person.FirstName);
            Assert.AreEqual<string>("Kreminski", person.LastName);
        }

        [TestMethod]
        public void TestPostPerson()
        {
            IDatabaseFactory databaseFactory = new TestDatabaseFactory();
            PersonController personController = new PersonController(databaseFactory);
            SetupControllerForTests(personController);

            Person person = null;
            person = personController.GetPersonByID(1);

            System.Net.Http.HttpResponseMessage response = personController.PostPerson(person);
        }
    }
}
