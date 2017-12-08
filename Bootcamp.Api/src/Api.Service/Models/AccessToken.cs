using System;

namespace Api.Service.Models
{
    public class AccessToken
    {
        public string Token { get; set; }
        public string Type => "Bearer";
        public DateTimeOffset ExpiresOnUtc { get; set; }
    }
}