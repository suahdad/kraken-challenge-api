using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrakenChallengeAPI.Models
{
    public class HumanVital
    {
        public HashSet<VitalInfo> HumanVitals { get; set; }
        public string Message { get; set; }
    }
}
