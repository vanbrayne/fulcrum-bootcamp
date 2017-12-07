using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Xlent.Lever.Libraries2.Core.Error.Logic;

namespace PhilipsHue.Service.FulcrumAdapter.Logic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// https://github.com/Q42/Q42.HueApi/blob/master/RemoteApi.md
    /// https://github.com/Q42/Q42.HueApi/blob/master/src/Q42.HueApi.RemoteApi.Sample/MainPage.xaml.cs
    public static class ClientHelper
    {
        /// <summary>
        /// Get a Philips Hue remote client
        /// </summary>
        /// <returns></returns>
        public static async Task<IHueClient> GetClient()
        {
            var appId = "";
            var clientId = "";
            var clientSecret = "";

            IRemoteAuthenticationClient authClient = new RemoteAuthenticationClient(clientId, clientSecret, appId);

            //If you already have an accessToken, call:
            //AccessTokenResponse storedAccessToken = SomehwereFrom.Storage();
            //authClient.Initialize(storedAccessToken);
            //IRemoteHueClient client = new RemoteHueClient(authClient.GetValidToken);

            //Else, reinitialize:

            var authorizeUri = authClient.BuildAuthorizeUri("sample", "consoleapp");
            var callbackUri = new Uri("https://localhost/q42hueapi");

            //var webAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, authorizeUri, callbackUri);

            //if (webAuthenticationResult != null)
            //{
            //    var result = authClient.ProcessAuthorizeResponse(webAuthenticationResult.ResponseData);

            //    if (!string.IsNullOrEmpty(result.Code))
            //    {
            //        //You can store the accessToken for later use
            //        var accessToken = await authClient.GetToken(result.Code);

            //        IRemoteHueClient client = new RemoteHueClient(authClient.GetValidToken);
            //        var bridges = await client.GetBridgesAsync();

            //        if (bridges != null)
            //        {
            //            //Register app
            //            //var key = await client.RegisterAsync(bridges.First().Id, "Sample App");

            //            //Or initialize with saved key:
            //            client.Initialize(bridges.First().Id, "C95sK6Cchq2LfbkbVkfpRKSBlns2CylN-VxxDD8F");

            //            //Turn all lights on
            //            var lightResult = await client.SendCommandAsync(new LightCommand().TurnOn());

            //        }
            //        return client;
            //    }
            //}
            return await Task.FromResult((IHueClient)null);
        }

        private static string CalculateHash(string clientId, string clientSecret, string nonce)
        {
            var hash1 = MD5($"{clientId}:oauth2_client@api.meethue.com:{clientSecret}");
            var hash2 = MD5("POST:/oauth2/token");
            var response = MD5(hash1 + ":" + nonce + ":" + hash2);

            return response;
        }

        private static string MD5(string str)
        {
            //var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            //IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            //var hashed = alg.HashData(buff);
            //var res = CryptographicBuffer.EncodeToHexString(hashed);
            //return res;
            throw new FulcrumNotImplementedException();
        }

    }
}