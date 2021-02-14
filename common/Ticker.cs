using Newtonsoft.Json;
using System;

namespace common
{
    public class Ticker
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
