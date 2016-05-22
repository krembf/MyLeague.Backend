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
using Newtonsoft.Json.Linq;

namespace WebAPITemplateProject.Tests.Controllers
{
    //[TestClass]
    //public class PersonControllerTest
    //{
    //    private static void SetupControllerForTests(ApiController controller)
    //    {
    //        var config = new HttpConfiguration();
    //        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/person");
    //        var route = config.Routes.MapHttpRoute(WebApiConfig.DEFAULT_ROUTE_NAME, "api/{controller}/{id}");
    //        var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "person" } });

    //        controller.ControllerContext = new HttpControllerContext(config, routeData, request);
    //        controller.Request = request;
    //        controller.Url = new UrlHelper(request);
    //        controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
    //        controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

    //        // Web API routes
    //        config.MapHttpAttributeRoutes();
    //    }

    //    [TestMethod]
    //    public void TestGetAllPeople()
    //    {
    //        IDatabaseFactory databaseFactory = new TestDatabaseFactory();
    //        PersonController personController = new PersonController(databaseFactory);

    //        List<Person> persons = null;
    //        persons = (List<Person>) personController.GetAllPeople();

    //        Assert.AreEqual<int>(2, persons.Count);
    //    }

    //    [TestMethod]
    //    public void TestGetPersonByID()
    //    {
    //        IDatabaseFactory databaseFactory = new TestDatabaseFactory();
    //        PersonController personController = new PersonController(databaseFactory);

    //        Person person = null;
    //        person = personController.GetPersonByID(1);

    //        Assert.AreEqual<int>(1, person.id);
    //        Assert.AreEqual<string>("Boris", person.first_name);
    //        Assert.AreEqual<string>("Kreminski", person.last_name);
    //    }

    //    [TestMethod]
    //    public void TestPostPerson()
    //    {
    //        IDatabaseFactory databaseFactory = new TestDatabaseFactory();
    //        PersonController personController = new PersonController(databaseFactory);
    //        SetupControllerForTests(personController);

    //        Person person = new Person
    //        {
    //            last_name = "Kreminsky",
    //            first_name = "Eugene",
    //            birth = (new DateTime(1977, 1, 18)).ToString(),
    //            gender = "Male",
    //            role = "Left wing-back (LWB)",
    //            status = "Active",
    //            contact = new Contact
    //            {
    //                email = "ekreminsky@gmail.com",
    //                phone = "+12672662380",
    //            },
    //            address = new Address
    //            {
    //                street = "50 Fern Road",
    //                city = "Warminster",
    //                state = "PA",
    //                zip = "19055",
    //            },
    //            access_level = new AccessLevel
    //            {
    //                group = "dev",
    //                level = 5,
    //            },
    //        };

    //        System.Net.Http.HttpResponseMessage response = personController.PostPerson(person);

    //        JObject result = response.Content.ReadAsAsync<JObject>().Result;

    //        Person addedPerson = result.ToObject<Person>();

    //        Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
    //        Assert.AreEqual("http://localhost/api/person/3", response.Headers.Location.ToString());
    //    }

    //    [TestMethod]
    //    public void TestPostPersonNotification()
    //    {
    //        IDatabaseFactory databaseFactory = new TestDatabaseFactory();
    //        PersonController personController = new PersonController(databaseFactory);
    //        SetupControllerForTests(personController);

    //        Notification notification = new Notification()
    //        {
    //            personid = 1,
    //            category = "Action",
    //            priority = "1",
    //            type = "JoinTeam",
    //            status = "unread"
    //        };

    //        System.Net.Http.HttpResponseMessage response = personController.PostNotification(notification);

    //        JObject result = response.Content.ReadAsAsync<JObject>().Result;

    //        Notification addedNotification = result.ToObject<Notification>();

    //        Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
    //        Assert.AreEqual("http://localhost/api/notification/1", response.Headers.Location.ToString());
    //    }
    //}
}
