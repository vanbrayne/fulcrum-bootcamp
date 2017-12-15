﻿using System;
using Microsoft.Rest;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;
using Xlent.Lever.Libraries2.WebApi.RestClientHelper;

namespace PhilipsHue.Service.FulcrumAdapter.RestClients
{
    /// <summary>
    /// Lever BaseClient
    /// </summary>
    public abstract class BaseClient
    {
        /// <summary>
        /// The rest client we will use for all calls.
        /// </summary>
        public readonly IRestClient RestClient;

        internal static string GetUriStart(string baseUri)
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
        /// <param name="authenticationToken"></param>
        protected BaseClient(string baseUri, AuthenticationToken authenticationToken)
        {
            RestClient = new RestClient(GetUriStart(baseUri), authenticationToken);
        }

        /// <summary>
        /// BaseClient constructor
        /// </summary>
        /// <param name="baseUri"></param>
        protected BaseClient(string baseUri)
        {
            RestClient = new RestClient(GetUriStart(baseUri));
        }
    }
}