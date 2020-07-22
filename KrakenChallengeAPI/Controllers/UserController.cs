﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using KrakenChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KrakenChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<Response>> Get([FromBody] User model)
        {
            var KrakenAPI = configuration.GetValue<string>("KrakenAPI:Authentication");

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(KrakenAPI),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"),
                };

                var response = await client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<Response>(responseBody);
            }


        }

        [HttpPost("Register")]
        public async Task<ActionResult<object>> Put([FromBody] User model)
        {
            var KrakenAPI = configuration.GetValue<string>("KrakenAPI:Authentication");

            using (var client = new HttpClient())
            {
                using(var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"))
                {
                    var response = await client.PostAsync(KrakenAPI, content);
                    return response;
                }
            }

        }

    }
}
