using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FootballCMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Common.Controllers;


using Umbraco.Cms.Web.Website.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballCMS.Controllers
{
    
    [Route("Views/Home[controller]")]
    public class PlayerController : RenderController
    {

        public const string PARTIAL_VIEW_FOLDER = "~/Views/Home/";
        private IPublishedValueFallback publishedValueFallback;

        public PlayerController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }

        public async Task<string> GetplayerAsync()
        {
            string Url = "https://futdb.app/api/players/3";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://futdb.app/api/players/2");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-AUTH-TOKEN", "522b0a4c-2ee6-438d-9a1f-579851e2b96b");

            dynamic response = await client.GetAsync(Url).ConfigureAwait(false);

            string result = response.Content.ReadAsStringAsync().Result;

            dynamic data = JObject.Parse(result);
            string name = data.player.name;


            return name;
        }

        public override IActionResult Index()
        {
            var name = GetplayerAsync();
            PlayerModel showPlayer = new PlayerModel(name);
            showPlayer.fullName = name;
            return View(showPlayer);
        }





    }
}

