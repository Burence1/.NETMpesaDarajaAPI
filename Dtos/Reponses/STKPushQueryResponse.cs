using Newtonsoft.Json;

namespace MpesaDarajaAPI.Dtos.Reponses
{
    public class STKPushQueryResponse
    {
        [JsonProperty("IsSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("SuccessResponse")]
        public StkPushQuerySuccessResponse SuccessResponse { get; set; }
        [JsonProperty("ErrorResponse")]
        public ErrorResponse ErrorResponse { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
