using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;


        static PayPalConfiguration()
        {
            var config = getConfig();
            ClientId = config["clientId"];
            ClientSecret = config["secret"];
        }

        public static Dictionary<string,string> getConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }


        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId,ClientSecret,getConfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext getAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = getConfig();
            return apiContext;
        }

    }
}
