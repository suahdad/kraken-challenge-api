using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using KrakenChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KrakenChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanVitalController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public HumanVitalController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET api/<HumanVitalController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HumanVital>> Get(string id)
        {
            var KrakenAPI = $"{configuration.GetValue<string>("KrakenAPI:HumanVitals")}/{id}";
                        var token = configuration.GetValue<string>("Token");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync(KrakenAPI);
                var apiResponse = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<HumanVital>(apiResponse);
            }
        }

        // POST api/<HumanVitalController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] VitalInfoRequest model)
        {
            var KrakenAPI = configuration.GetValue<string>("KrakenAPI:HumanVitals");
            var token = configuration.GetValue<string>("Token");

            using (var client = new HttpClient())
            {
                var jsonText = JsonConvert.SerializeObject(model);
                using (var content = new StringContent(jsonText, Encoding.UTF8, "application/json"))
                {

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.PostAsync(KrakenAPI, content);
                    Console.WriteLine(content);
                    response.EnsureSuccessStatusCode();

                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return response;
                }

            }

        }

    }
}
