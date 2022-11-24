using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technorix.Models.Models
{
    internal class TokenModel
    {
    }
    
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string Access_token { get; set; }
        [JsonProperty("expires_in")]
        public Nullable<int> Expires_in { get; set; }
        [JsonProperty("token_type")]
        public string Token_type { get; set; }
    }


    public class TokenRequest
    {
        [JsonProperty("clientID")]
        public string ClientID { get; set; }
        [JsonProperty("secretKey")]
        public string SecretKey { get; set; }
        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }
    }
}
