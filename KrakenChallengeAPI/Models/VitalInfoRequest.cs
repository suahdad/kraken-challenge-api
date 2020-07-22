using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrakenChallengeAPI.Models
{
    public class VitalInfoRequest
    {
        public string organizationId { get; set; }
        public string businessUnitId { get; set; }
        public string deviceId { get; set; }
        public Int32 heartRate { get; set; }
        public double temperature { get; set; }
    }
}
