using Newtonsoft.Json;

namespace MpesaDarajaAPI.Dtos.Reponses
{
    public class SuccessResponse
    {
        public class BaseSuccessResponse
        {
            [JsonProperty("ResponseDescription")]
            public string ResponseDescription { get; set; }
            [JsonProperty("ResponseCode")]
            public string ResponseCode { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }

    public class CommonSuccessResponse : SuccessResponse.BaseSuccessResponse
    {
        [JsonProperty("ConversationID")]
        public string ConversationID { get; set; }

        [JsonProperty("OriginatorConversationID")]
        public string OriginatorConversationID { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
