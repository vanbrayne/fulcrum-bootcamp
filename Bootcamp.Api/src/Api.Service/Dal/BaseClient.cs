using System;
using System.Threading.Tasks;
using Microsoft.Rest;
using Xlent.Lever.Libraries2.Core.Health.Model;
using Xlent.Lever.Libraries2.WebApi.RestClientHelper;

namespace Api.Service.Dal
{
    public interface IBaseClient
    {
        Task<HealthResponse> GetServiceHealthAsync();
        string BaseUri { get; }
    }

    public abstract class BaseClient : IBaseClient
    {
        protected readonly IRestClient RestClient;

        private static string GetUriStart(string baseUri)
        {
            if (string.IsNullOrWhiteSpace(baseUri)) throw new ArgumentException($"{nameof(baseUri)} can't be null or empty");
            var isWelFormedUri = Uri.IsWellFormedUriString(baseUri, UriKind.Absolute);
            if (!isWelFormedUri) throw new ArgumentException($"{nameof(baseUri)} must be a welformed uri");

            return $"{baseUri}";
        }

        protected BaseClient(string baseUri, ServiceClientCredentials authenticationCredentials)
        {
            BaseUri = baseUri;
            RestClient = new RestClient(GetUriStart(baseUri), authenticationCredentials);
        }

        public async Task<HealthResponse> GetServiceHealthAsync()
        {
            var relativeUrl = "api/ServiceMetas/ServiceHealth";
            return await RestClient.GetAsync<HealthResponse>(relativeUrl);
        }

        public string BaseUri { get; }
    }
}