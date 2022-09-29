using Newtonsoft.Json;

namespace MpesaDarajaAPI.Dtos
{
    public class AccessTokenDto
    {
        [JsonProperty("access_token")]
        public string accessToken { get; set; }

        [JsonProperty("expiry_in")]
        public  int expiryIn { get; set; }
    }
}
