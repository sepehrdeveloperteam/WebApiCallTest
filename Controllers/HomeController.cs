using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiCallTest.Models;

namespace WebApiCallTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            HttpResponseMessage message = await client.GetAsync("test01");

            var x = await message.Content.ReadAsStringAsync();
            //var y=Newtonsoft.Json.JsonConvert.DeserializeObject<List<test>>(x);
            //test a = new test();

            //foreach (var u in y)
            //{
            //    a = y.FirstOrDefault();
            //}

            ViewBag.test = x;

            return View();
        }


        public async Task<IActionResult> Index2()
        {
            HttpClient client = new HttpClient();
            var url = "https://api.irbroker.com/api/v1/authenticate";

            //11145
            //3790076929
            

            loginwebservice loginwebservice = new loginwebservice();
            loginwebservice.username = "sepehruser1";
            loginwebservice.password = "tr9qGxHf8QB4";

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(loginwebservice);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;

            ViewBag.r = result;

            return View();
        }


        public async Task<IActionResult> Index3()
        {
            HttpClient client = new HttpClient();
            var url = "https://api.irbroker.com/api/v1/login";

            //11145
            //3790076929
            //dfcdf797-4a43-4c35-a623-d5d9060aeef5
            //dfcdf797-4a43-4c35-a623-d5d9060aeef5

            UserLogin userLogin = new UserLogin();

            userLogin.code = "11145"; 
            userLogin.username = "3790076929";
            userLogin.password = "Mypassword@123";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(userLogin);
            //var content = new FormUrlEncodedContent(json,new[]
            //{
            //    new KeyValuePair<string, string>("Content-Type", "application/json"),
            //    new KeyValuePair<string, string>("X-CLIENT-TOKEN", "Call service 2")
            //});

            //var pairs = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("Content-Type", "application/json"),
            //    new KeyValuePair<string, string>("X-CLIENT-TOKEN", "Call service 2")
            //};

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            data.Headers.Add("X-CLIENT-TOKEN", "dfcdf797-4a43-4c35-a623-d5d9060aeef5");

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;

            ViewBag.r = result;

            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
