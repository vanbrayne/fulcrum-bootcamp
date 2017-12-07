using System;
using Microsoft.Rest;
using Xlent.Lever.Libraries2.WebApi.RestClientHelper;

namespace CustomerMaster.Service.FulcrumAdapter.RestClients
{
    /// <summary>
    /// Lever BaseClient
    /// </summary>
    public abstract class BaseClient
    {
        #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected readonly IRestClient RestClient;


        private static string GetUriStart(string baseUri)
        {
            if (string.IsNullOrWhiteSpace(baseUri)) throw new ArgumentException($"{nameof(baseUri)} can't be null or empty");
            var isWelFormedUri = Uri.IsWellFormedUriString(baseUri, UriKind.Absolute);
            if (!isWelFormedUri) throw new ArgumentException($"{nameof(baseUri)} must be a welformed uri");

            return $"{baseUri}";
        }

        /// <summary>
        /// BaseClient constructor
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="authenticationCredentials"></param>
        protected BaseClient(string baseUri, ServiceClientCredentials authenticationCredentials)
        {
            RestClient = new RestClient(GetUriStart(baseUri), authenticationCredentials);
        }

    }
}