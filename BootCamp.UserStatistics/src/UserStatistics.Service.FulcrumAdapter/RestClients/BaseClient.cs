using System;
using Microsoft.Rest;
using Xlent.Lever.Libraries2.WebApi.RestClientHelper;
#pragma warning disable 1591

namespace UserStatistics.Service.FulcrumAdapter.RestClient
{
    public abstract class BaseClient
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
            RestClient = new Xlent.Lever.Libraries2.WebApi.RestClientHelper.RestClient(GetUriStart(baseUri), authenticationCredentials);
        }

    }
}