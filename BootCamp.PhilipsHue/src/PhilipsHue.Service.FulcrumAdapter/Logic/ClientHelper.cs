using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.HSB;
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
        /// The known colors
        /// </summary>
        public enum ColorEnum
        {
#pragma warning disable 1591
            Unknown,
            Green,
            Yellow,
            Red
#pragma warning restore 1591
        };
        internal const string GreenColorHex = "00FF00";
        internal const string YellowColorHex = "FFFF00";
        internal const string RedColorHex = "FF0000";

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

        /// <summary>
        /// Get the rgb color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static RGBColor GetRgbColor(ColorEnum color)
        {
            string colorAsHex;
            switch (color)
            {
                case ColorEnum.Green:
                    colorAsHex = GreenColorHex;
                    break;
                case ColorEnum.Yellow:
                    colorAsHex = YellowColorHex;
                    break;
                case ColorEnum.Red:
                    colorAsHex = RedColorHex;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
            return new RGBColor(colorAsHex);
        }

        /// <summary>
        /// Get the color that a command has.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static ColorEnum GetColorFromCommand(LightCommand command)
        {
            var colorCommand = new LightCommand();
            colorCommand.SetColor(GetRgbColor(ColorEnum.Green));
            if (HasSameColor(colorCommand, command)) return ColorEnum.Green;
            colorCommand.SetColor(GetRgbColor(ColorEnum.Yellow));
            if (HasSameColor(colorCommand, command)) return ColorEnum.Yellow;
            colorCommand.SetColor(GetRgbColor(ColorEnum.Red));
            if (HasSameColor(colorCommand, command)) return ColorEnum.Red;
            return ColorEnum.Unknown;
        }

        private static bool HasSameColor(LightCommand expected, LightCommand actual)
        {
            if (expected.Hue != actual.Hue) return false;
            if (expected.Saturation != actual.Saturation) return false;
            if (expected.Brightness != actual.Brightness) return false;
            return true;
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