using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CognizantTest.DataEntities;

namespace CognizantTest.LoadedEntities
{
    public class IncEntity
    {

        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("cars")]
        public Car Cars { get; set; }

    }
    public class Location
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }
    }

    public class Car
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
