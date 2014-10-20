using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using BullsAndCows.Models;
using BullsAndCows.Data.Repositories;
using System.Linq;
using BullsAndCows.Web.Controllers;
using BullsAndCows.Data;
using System.Web.Http;
using System.Net.Http;
using System.Threading;
using BullsAndCows.Web.Models;
using System.Collections.Generic;
using System.Web.Http.Routing;

namespace Acticles.Test
{
    [TestClass]
    public class BullsAndCowsControllerTest
    {
        [TestMethod]
        //public void GetAll()
        //{
        //    User[] users = this.GenerateValidTestUsers(1);

        //    var repo = Mock.Create<IRepository<User>>();
        //    Mock.Arrange(() => repo.All())
        //        .Returns(() => users.AsQueryable());

        //    var data = Mock.Create<IBullsAndCowsData>();

        //    Mock.Arrange(() => data.Users)
        //        .Returns(() => repo);

        //    var controller = new User(data);
        //    this.SetupController(controller);

        //    var actionResult = controller.Get();

        //    var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

        //    var actual = response.Content.ReadAsAsync<IEnumerable<BullsAndCowsData>>().Result.Select(a => a.ID).ToList();

        //    var expected = users.AsQueryable().Select(a => a.UserId).ToList();

        //    CollectionAssert.AreEquivalent(expected, actual);
        //}

        private User[] GenerateValidTestUsers(int count)
        {
            User[] users = new User[count];
            
            for (int i = 0; i < count; i++)
            {
                var user = new User
                {
                    // todo
                };
                users[i] = user;
            }

            return users;
        }
        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "users" }
                    });
        }
    }
}