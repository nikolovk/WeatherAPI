using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WeatheAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult GetWeather(string latitude, string longitude)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string url = "http://api.worldweatheronline.com/free/v1/weather.ashx?";
            string data = "key=5phbpfubtbrbc3usc9kg2fw3&q=" + latitude + "," + longitude +
                "&cc=no&date=" + today + "&format=json";
            WebRequest webRequest = WebRequest.Create(url+data);
            WebResponse response = webRequest.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return Json(responseFromServer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
