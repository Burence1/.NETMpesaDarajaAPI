using Newtonsoft.Json;

namespace MpesaDarajaAPI.Dtos.Reponses
{
    public class STKPushResponse
    {
        [JsonProperty("IsSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("SuccessResponse")]
        public StkPushSuccessResponse SuccessResponse { get; set; }
        [JsonProperty("ErrorResponse")]
        public ErrorResponse ErrorResponse { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
