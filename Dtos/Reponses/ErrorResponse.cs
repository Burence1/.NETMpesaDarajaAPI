using Newtonsoft.Json;


namespace MpesaDarajaAPI.Dtos.Reponses;

public class ErrorResponse
{
    [JsonProperty("requestId")]
    public string RequestId { get; set; }
    [JsonProperty("errorCode")]
    public string ErrorCode { get; set; }
    [JsonProperty("errorMessage")]
    public string ErrorMessage { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}