﻿using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models.DTOs;
using NZWalks.UI.Models.ViewModels;
using System.Collections;
using System.Text;
using System.Text.Json;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {

        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDTO> response = new List<RegionDTO>();
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7121/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.
                            ReadFromJsonAsync<IEnumerable<RegionDTO>>());


            }
            catch(Exception ex)
            {

            }
            


            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionVM model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7121/api/regions"),
                Content = new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8,"application/json"),


            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if(ModelState.IsValid)
            {
                if (response is not null)
                {

                    return RedirectToAction("Index", "Regions");
                }
            }


            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<RegionDTO>($"https://localhost:7121/api/regions/{id.ToString()}");

            if(response is not null)
            {
                return View(response);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDTO request)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7121/api/regions/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request),Encoding.UTF8,"application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (response is not null)
            {
                return RedirectToAction("Edit", "Regions");
            }

            return View();
        }
    }
}
