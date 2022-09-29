using Newtonsoft.Json;

namespace MpesaDarajaAPI.Dtos.Requests;

public class C2BRequest
{

    [JsonProperty("ValidationURL")]
    public string validationURL { get; set; }

    [JsonProperty("ConfirmationURL")]
    public string confirmationURL { get; set; }

    [JsonProperty("ResponseType")]
    public string responseType { get; set; }

    [JsonProperty("ShortCode")]
    public string shortCode { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}