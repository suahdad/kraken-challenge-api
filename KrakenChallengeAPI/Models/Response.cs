using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrakenChallengeAPI.Models
{
    public class Response
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
