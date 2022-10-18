using Newtonsoft.Json;

namespace MpesaDarajaAPI.Dtos.Requests
{
    public class AccountBalRequest
    {
        [JsonProperty("CommandID")]
        public string CommandID { get; set; }

        [JsonProperty("PartyA")]
        public string PartyA { get; set; }

        [JsonProperty("IdentifierType")]
        public string IdentifierType { get; set; }

        [JsonProperty("Remarks")]
        public string Remarks { get; set; }

        [JsonProperty("Initiator")]
        public string Initiator { get; set; }

        [JsonProperty("SecurityCredential")]
        public string SecurityCredential { get; set; }

        [JsonProperty("QueueTimeOutUrl")]
        public string QueueTimeOutURL { get; set; }

        [JsonProperty("ResultUrl")]
        public string ResultURL { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
