using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballCMS.Controllers
{
    
    [Route("api/[controller]")]
    public class PlayerController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Home/";
        

        public PlayerController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {

        }

       
        public async Task GetplayerAsync()
        {
            string Url = "https://futdb.app/api/players/3";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://futdb.app/api/players/2");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-AUTH-TOKEN", "522b0a4c-2ee6-438d-9a1f-579851e2b96b");

            dynamic response = await client.GetAsync(Url).ConfigureAwait(false);
            string fullname = response.player.name;
            ViewBag.fullname = fullname;
            

            //string result = response.Content.ReadAsStringAsync().Result;
        }

        //public string GetPlayer()
        //{ 
        //    return fullname;
        //}
        



        
    }
}

