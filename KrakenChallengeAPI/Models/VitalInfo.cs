using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrakenChallengeAPI.Models
{
    public class VitalInfo
    {
        public string HumanVitalId { get; set; }
        public string OrganizationId { get; set; }
        public string BusinessUnitId { get; set; }
        public string DeviceId { get; set; }
        public double HeartRate { get; set; }
        public double Temperature { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ETag { get; set; }

    }
}
