using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Bookstore
{
    public static class PaypalConfiguration
    {
        //Variables for storing the clientID and clientSecret key
        public readonly static string clientId;
        public readonly static string clientSecret;
        //Constructor
        static PaypalConfiguration()
        {
            var config = GetConfig();
            clientId = "AXQZ3iHEPoo_ANshfJJxgBsIfa8nRE3XKN7EN3CzOzBJViGRzpZD5lswRWVk4t3eYUC55xySbVUlXWw7";
            clientSecret = "EKo9jBM5bYvwT2SqTqKZ0QkzTZsE8cj2lBAuF8n_jnnfn4o2NBIxwDlnWHyCvrT1H9mAlyB9JvvNcnCw";
        }
        // getting properties from the web.config
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            // getting access tocken from paypal
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}