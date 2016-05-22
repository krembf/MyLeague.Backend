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
using NUnit.Framework;

namespace WebAPITemplateProject.Tests.Controllers
{
    [TestFixture]
    public class LeagueControllerTest
    {
        private static void SetupControllerForTests(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/league");
            var route = config.Routes.MapHttpRoute(WebApiConfig.DEFAULT_ROUTE_NAME, "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "league" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Url = new UrlHelper(request);
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

            // Web API routes
            config.MapHttpAttributeRoutes();
        }

        [TestCase]
        public void TestGetAllLeagues()
        {
            IDatabaseFactory databaseFactory = new TestDatabaseFactory();
            var leagueController = new LeaguesController(databaseFactory);

            List<League> leagues = null;
            leagues = (List<League>)leagueController.GetAllLeagues();

            Assert.AreEqual(2, leagues.Count);
        }

        [TestCase]
        public void TestGetLeagueByName()
        {
            IDatabaseFactory databaseFactory = new TestDatabaseFactory();
            var leagueController = new LeaguesController(databaseFactory);

            var leagues = (List<League>)leagueController.Get("Soccer", "Coed");

            Assert.That(leagues.Count, Is.EqualTo(2), "The number of leagues should be two");
            Assert.AreEqual("Bucks County Coed", leagues[0].Name);
            Assert.AreEqual("Montgomery County Coed League over 30", leagues[1].Name);
        }

        [TestCase]
        public void TestGetTeamsByLeague()
        {
            IDatabaseFactory databaseFactory = new TestDatabaseFactory();
            var leagueController = new LeaguesController(databaseFactory);

            var teams = leagueController.GetTeamsByLeague(1);

            Assert.That(teams.Count, Is.EqualTo(2), "The number of teams should be two");
            Assert.IsTrue(teams.Contains("1"));
            Assert.IsTrue(teams.Contains("2"));
        }

        //public static IEnumerable<TestCaseData> TestPostLeague_TestData
        //{
        //    get
        //    {
        //        yield return new TestCaseData(
        //            new League
        //            {
        //                Type = "Soccer",
        //                Name = "West Chester coed over 30",
        //                Address = new Address
        //                {
        //                    street = "400 Boot Rd",
        //                    city = "Downingtown",
        //                    state = "PA",
        //                    zip = "19053"
        //                },
        //                Image = "http://editor.swagger.io/photos"
        //            },
        //            null
        //            );
        //        yield return new TestCaseData(
        //            null,
        //            typeof(ArgumentNullException)
        //            );
        //    }
        //}

        //[TestCaseSource("TestPostLeague_TestData")]
        //public void TestPostLeague(League league, Type exceptionType)
        //{
        //    var databaseFactory = new TestDatabaseFactory();
        //    var leagueController = new LeaguesController(databaseFactory);
        //    SetupControllerForTests(leagueController);

        //    System.Net.Http.HttpResponseMessage response;
        //    if(exceptionType == null)
        //    {
        //        response = leagueController.PostLeague(league);

        //        JObject result = response.Content.ReadAsAsync<JObject>().Result;

        //        League addedLeague = result.ToObject<League>();

        //        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "The expected status code is 201 created");
        //        Assert.That(response.Headers.Location.ToString(), Is.Not.Null, "The expected location should not br null");

        //        Assert.NotNull(addedLeague.Id, "League Id should not be null");
        //        Assert.NotNull(addedLeague.LastUpdated, "The last updated field shoul not be null");
        //        Assert.That(addedLeague.Name, Is.EqualTo(league.Name), "Invalid league name");
        //        Assert.That(addedLeague.Address.ToString(), Is.EqualTo(league.Address.ToString()), "Invalid league address");
        //        Assert.That(addedLeague.Type, Is.EqualTo(league.Type), "Invalid league type");
        //        Assert.That(addedLeague.Image, Is.EqualTo(league.Image), "Invalid league image link");
        //        Assert.IsNull(addedLeague.Teams, "Teams collection should be null");
        //        Assert.IsNull(addedLeague.Seasons, "Seasons collection should be null");
        //    }
        //    else
        //    {
        //        var ex = Assert.Throws(exceptionType, ()=> leagueController.PostLeague(league));
        //    }
        //}

        public static IEnumerable<TestCaseData> TestPostLeague_TestData
        {
            get
            {
                yield return new TestCaseData(
                    new League
                    {
                        Type = "Soccer",
                        Name = "West Chester coed over 30",
                        Address = new Address
                        {
                            street = "400 Boot Rd",
                            city = "Downingtown",
                            state = "PA",
                            zip = "19053"
                        },
                        Image = "http://editor.swagger.io/photos"
                    },
                    HttpStatusCode.Created
                    );
                yield return new TestCaseData(
                    null,
                    HttpStatusCode.BadRequest
                    );
            }
        }

        [TestCaseSource("TestPostLeague_TestData")]
        public void TestCreateLeague(League league, HttpStatusCode statusCode)
        {
            var databaseFactory = new TestDatabaseFactory();
            var leagueController = new LeaguesController(databaseFactory);
            SetupControllerForTests(leagueController);

            HttpResponseMessage response;

            response = leagueController.PostLeague(league);

            Assert.That(response.StatusCode, Is.EqualTo(statusCode), "The expected status code is " + statusCode);
        }

        [TestCase]
        public void TestCreateLeagueDuplicateData()
        {
            var league = new League
            {
                Type = "Soccer",
                Name = "West Chester coed over 30",
                Address = new Address
                {
                    street = "400 Boot Rd",
                    city = "Downingtown",
                    state = "PA",
                    zip = "19053"
                },
                Image = "http://editor.swagger.io/photos"
            };

            var databaseFactory = new TestDatabaseFactory();
            var leagueController = new LeaguesController(databaseFactory);
            SetupControllerForTests(leagueController);

            HttpResponseMessage response;
            response = leagueController.PostLeague(league);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "The expected status code is 201 created");

            //Try to add duplicate entry
            response = leagueController.PostLeague(league);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict), "The expected status code is 409 conflict");
            Assert.That(response.Headers.Contains("X-Status-Reason"), Is.True, "The expected response should have \"X-Status-Reason\" header");

            IEnumerable<string> values;
            response.Headers.TryGetValues("X-Status-Reason", out values);
            var enumerator = values.GetEnumerator();
            Assert.That(enumerator.MoveNext(), Is.True, "X-Status-Reason header in the response should have at least one value");
            Assert.That(enumerator.Current, Is.EqualTo(string.Format("The league with the name {0} already exists in the database", league.Name)), "unexpected response in header");
        }

        [TestCase]
        public void TestUpdateLeagueSuccess()
        {
            var league = new League
            {
                Type = "Soccer",
                Name = "West Chester coed over 30",
                Address = new Address
                {
                    street = "400 Boot Rd",
                    city = "Downingtown",
                    state = "PA",
                    zip = "19053"
                },
                Image = "http://editor.swagger.io/photos"
            };

            var databaseFactory = new TestDatabaseFactory();
            var leagueController = new LeaguesController(databaseFactory);
            SetupControllerForTests(leagueController);

            // Add new league
            var response = leagueController.PostLeague(league);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "The expected status code is 201 created");

            // Get the newly created league
            var leagues = leagueController.Get(league.Type, league.Name);
            Assert.That(leagues.Count, Is.EqualTo(1), "The number of leagues shoud be one");
            var createdLeague = leagues[0];

            // Modify league name
            createdLeague.Name = createdLeague.Name + "_Updated";

            // Update league
            var ret = leagueController.PutLeague(createdLeague.Id, createdLeague);

            // Get updated league
            leagues = leagueController.Get(league.Type, league.Name);
            Assert.That(leagues.Count, Is.EqualTo(1), "The number of leagues should be one");
            var modifiedLeague = leagues[0];

            Assert.That(modifiedLeague.Id, Is.EqualTo(createdLeague.Id), "The league Id should remain the same");
            Assert.That(modifiedLeague.Name, Is.EqualTo(createdLeague.Name), "The league name should remain the same");
        }
    }
}
