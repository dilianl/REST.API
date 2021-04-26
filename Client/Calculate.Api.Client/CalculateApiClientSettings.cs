using Calculate.Api.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate.Api.Client
{
    public class CalculateApiClientSettings : ICalculateApiClientSettings
    {
        public string BaseUrl { get; set; }
    }
}
