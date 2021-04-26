using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate.Api.Client.Interfaces
{
    public interface ICalculateApiClientSettings
    {
        string BaseUrl { get; set; }

        //int TimeoutInSec { get; set; }
    }
}
