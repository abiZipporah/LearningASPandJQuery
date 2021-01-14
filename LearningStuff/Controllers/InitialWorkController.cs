using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LearningStuff.Models;
using LearningStuff.Models.IndexViewModel;
using Microsoft.AspNetCore.Mvc;
using TextModel = LearningStuff.Models.IndexViewModel.TextModel;

namespace LearningStuff.Controllers
{
    public class InitialWorkController : Controller {
        public IActionResult FullPost()
        {
            return View(new TextModel { Message = "This is a box, it sends its text to the controller" });
        }
        [HttpPost]
        public IActionResult FullPost(TextModel model)
        {
            model.Message = model.TestUpdate;
            model.Message = model.Message + "1";
            return View(model);
        }

        public IActionResult AJAXPost()
        {
            return View(new TextModel { Message = "This is a jox, a box that javascript gets text from" });
        }
        [HttpPost]
        public TextModel AjaxTestUpdate(TextModel model)
        {
            model.Message = model.TestUpdate;
            model.Message = model.Message + "1";
            return model;
        }

        [HttpGet]
        public IActionResult BasicAPICall()
        {
            return View();
        }
        public JsonResult GetBookingTypeCategories() {
            var apiUri = new Uri("https://dev.zipporah.co.uk/api/Booking/BookingTypesCatergories");
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, apiUri);
            var response = client.SendAsync(request).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var bookingtypes = JsonSerializer.Deserialize<btCategories>(content);
            return Json(bookingtypes);
        }
        public async Task<JsonResult> GetBookingTypes()
        {
            var apiUri = new Uri("https://dev.zipporah.co.uk/api/Booking/BookingTypes");
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, apiUri);
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var bookingtypes = JsonSerializer.Deserialize<bTypes>(content);
            return Json(bookingtypes);
        }
        public async Task<JsonResult> GetResources()
        {
            var apiUri = new Uri("https://dev.zipporah.co.uk/api/Booking/Resources");
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, apiUri);
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var bookingtypes = JsonSerializer.Deserialize<Resources>(content);
            return Json(bookingtypes);
        }

        public async Task<JsonResult> GetResourceCategories()
        {
            var apiUri = new Uri("https://dev.zipporah.co.uk/api/Booking/ResourceCatergories");
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, apiUri);
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var bookingtypes = JsonSerializer.Deserialize<Resources>(content);
            return Json(bookingtypes);
        }

        //[HttpPost]
        //public IActionResult ApiCall()
        //{
        //    return View();
        //}
        //public JsonResult GetApiResults(ApiModel model)
        //{
        //    var error = "the controller couldnt get the api results";
        //    var api = model.Value;
        //    var baseUri = new Uri("https://dev.zipporah.co.uk/api/Booking/");
        //    var ApiUri = baseUri + api;
        //    HttpClient client = new HttpClient();
        //    var request = new HttpRequestMessage(HttpMethod.Get, ApiUri);
        //    var response = client.SendAsync(request).Result;
        //    var content = response.Content.ReadAsStringAsync().Result;
        //    if(api == "BookingTypeID")
        //    {
        //        var results = JsonSerializer.Deserialize<bTypes>(content);
        //        return Json(results);
        //    }
        //    if (api == "ResourceID")
        //    {
        //        var results = JsonSerializer.Deserialize<Resources>(content);
        //        return Json(results);
        //    }
        //    if(api == "ResourceCategoryID")
        //    {
        //        var results = JsonSerializer.Deserialize<Resources>(content);
        //        return Json(results);
        //    }
        //    return Json(error);
        //}
    }
}