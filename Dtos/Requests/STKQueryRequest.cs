using Newtonsoft.Json;

namespace MpesaDarajaAPI.Dtos.Requests
{
    public class STKQueryRequest
    {
        [JsonProperty("BusinessShortCode")]
        public string BusinessShortCode { get; set; }
        [JsonProperty("CheckoutRequestID")]
        public string CheckoutRequestID { get; set; }

        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
