﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PhilipsHue.Service.FulcrumAdapter.Contract;
using PhilipsHue.Service.FulcrumAdapter.Logic;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.Interfaces;
using Q42.HueApi.ColorConverters.HSB;
using Xlent.Lever.Authentication.Sdk.Attributes;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace PhilipsHue.Service.FulcrumAdapter.Controllers
{
    /// <inheritdoc cref="IVisualNotificationController" />
    [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api/Notifications")]
    public class VisualNotificationController : ApiController, IVisualNotificationController
    {
        private readonly IHueClient _hueClient;
        private readonly List<string> _lamps;
        private static string _status = "No requests";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hueClient">The client to use for communication with the Philips Hue</param>
        public VisualNotificationController(IHueClient hueClient)
        {
            _hueClient = hueClient;
            _lamps = new List<string> { "1" };
        }

        [AllowAnonymous]
        [Route("Status")]
        [HttpGet]
        public string GetStatus()
        {
            return $"<html><h1>{_status}</h1></html>";
        }

        /// <inheritdoc />
        [HttpPost]
        [Route("Success")]
        public async Task SuccessAsync()
        {
            FulcrumAssert.IsNotNull(_hueClient, null, "Must have a valid HueClient.");
            var command = new LightCommand();
            command.SetColor(ClientHelper.GetRgbColor(ClientHelper.ColorEnum.Green));
            command.Alert = Alert.Once;
            _status = "Success";
            await _hueClient.SendCommandAsync(command, _lamps);
        }

        /// <inheritdoc />
        [HttpPost]
        [Route("Warning")]
        public async Task WarningAsync()
        {
            FulcrumAssert.IsNotNull(_hueClient, null, "Must have a valid HueClient.");
            var command = new LightCommand();
            command.SetColor(ClientHelper.GetRgbColor(ClientHelper.ColorEnum.Yellow));
            command.Alert = Alert.Once;
            _status = "Warning";
            await _hueClient.SendCommandAsync(command, _lamps);
        }

        /// <inheritdoc />
        [HttpPost]
        [Route("Error")]
        public async Task ErrorAsync()
        {
            FulcrumAssert.IsNotNull(_hueClient, null, "Must have a valid HueClient.");
            var command = new LightCommand();
            command.SetColor(ClientHelper.GetRgbColor(ClientHelper.ColorEnum.Red));
            command.Alert = Alert.Once;
            _status = "Error";
            await _hueClient.SendCommandAsync(command, _lamps);
        }
    }
}
