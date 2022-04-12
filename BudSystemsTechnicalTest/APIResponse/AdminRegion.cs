using Newtonsoft.Json;

namespace BudSystemsTechnicalTest
{
    public class AdminRegion
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("iso2code")]
        public string iso2code { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }
}
