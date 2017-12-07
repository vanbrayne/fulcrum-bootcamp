using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models;
using Q42.HueApi.Models.Groups;
using Xlent.Lever.Libraries2.Core.Logging;

namespace PhilipsHue.Service.FulcrumAdapter.Logic
{
    public class MockHueClient : IHueClient
    {
        public async Task<IEnumerable<WhiteList>> GetWhiteListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Bridge> GetBridgeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateBridgeConfigAsync(BridgeConfigUpdate update)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteWhiteListEntryAsync(string entry)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> SendGroupCommandAsync(ICommandBody command, string @group = "0")
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateGroupAsync(IEnumerable<string> lights, string name = null, RoomClass? roomCLass = null)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> DeleteGroupAsync(string groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Group>> GetGroupsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Group> GetGroupAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateGroupAsync(string id, IEnumerable<string> lights, string name = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Light>> GetLightsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Light> GetLightAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<DeleteDefaultHueResult>> DeleteLightAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> SetLightNameAsync(string id, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> SendCommandRawAsync(string command, IEnumerable<string> lightList = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<HueResults> SendCommandAsync(LightCommand command, IEnumerable<string> lightList = null)
        {
            var color = ClientHelper.GetColorFromCommand(command);
            switch (color)
            {
                case ClientHelper.ColorEnum.Green:
                    Log.LogInformation("=== GREEN ===");
                    break;
                case ClientHelper.ColorEnum.Yellow:
                    Log.LogInformation("~~~~~~ YELLOW ~~~~~~");
                    break;
                case ClientHelper.ColorEnum.Red:
                    Log.LogInformation("!!!!!!!! RED !!!!!!!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return await Task.FromResult((HueResults)null);
        }

        public async Task<HueResults> SearchNewLightsAsync(IEnumerable<string> deviceIds = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Light>> GetNewLightsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Schedule>> GetSchedulesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Schedule> GetScheduleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateScheduleAsync(string id, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> DeleteScheduleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Scene>> GetScenesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateSceneAsync(Scene scene)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateSceneAsync(string sceneId, Scene scene)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateSceneAsync(string sceneId, string name, IEnumerable<string> lights, bool? storeLightState = null,
            TimeSpan? transitionTime = null)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> ModifySceneAsync(string sceneId, string lightId, LightCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> RecallSceneAsync(string sceneId, string groupId = "0")
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> DeleteSceneAsync(string sceneId)
        {
            throw new NotImplementedException();
        }

        public async Task<Scene> GetSceneAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Rule>> GetRulesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Rule> GetRuleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> DeleteRule(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateRule(Rule rule)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateRule(string name, IEnumerable<RuleCondition> conditions, IEnumerable<InternalBridgeCommand> actions)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateRule(Rule rule)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateRule(string id, string name, IEnumerable<RuleCondition> conditions, IEnumerable<InternalBridgeCommand> actions)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Sensor>> GetSensorsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateSensorAsync(Sensor sensor)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> FindNewSensorsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Sensor>> GetNewSensorsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Sensor> GetSensorAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateSensorAsync(string id, string newName)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> ChangeSensorConfigAsync(string id, SensorConfig config)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> ChangeSensorStateAsync(string id, SensorState state)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<DeleteDefaultHueResult>> DeleteSensorAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> DeleteResourceLinkAsync(string resourceLinkId)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<ResourceLink>> GetResourceLinksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResourceLink> GetResourceLinkAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateResourceLinkAsync(ResourceLink resourceLink)
        {
            throw new NotImplementedException();
        }

        public async Task<HueResults> UpdateResourceLinkAsync(string id, ResourceLink resourceLink)
        {
            throw new NotImplementedException();
        }

        public async Task<BridgeCapabilities> GetCapabilitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}