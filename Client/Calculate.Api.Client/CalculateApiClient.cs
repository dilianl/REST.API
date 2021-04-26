using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Calculate.Api.Client.Interfaces;
using Calculate.Api.Dto.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace Calculate.Api.Client
{
    public class CalculateApiClient : ICalculateApiClient
    {
        #region Constructors

        private ICalculateApiClientSettings _settings;

        private static readonly HttpClient _httpClient = new HttpClient();


        static CalculateApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public CalculateApiClient(ICalculateApiClientSettings settings)
        {
            this._settings = settings;
        }

        #endregion Constructors

        #region General

        private string BaseUrl { get { return _settings.BaseUrl; } }


        public async Task<string> GetApiStatus()
        {
            Uri url = new Uri($"{this.BaseUrl.TrimEnd('/')}/{Constants.API_ROUTE_STATUS}");
            return await _httpClient.GetStringAsync(url);
        }

        public async Task<string> GetApiStatusExtended()
        {
            Uri url = new Uri($"{this.BaseUrl.TrimEnd('/')}/{Constants.API_ROUTE_STATUS}/{Constants.API_ROUTE_PARAMETER_Extended}");
            return await _httpClient.GetStringAsync(url);
        }

        #endregion General

        #region Main
        public async Task<string> Sum(ITwoIntNumbersDTO twoIntNumbersDTO)
        {
            Uri url = new Uri($"{this.BaseUrl.TrimEnd('/')}/{Constants.API_ROUTE_SUM}");

            var myContent = JsonConvert.SerializeObject(twoIntNumbersDTO);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, byteContent);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());

            return result;
        }
        
        public async Task<string> Subtract(ITwoIntNumbersDTO twoIntNumbersDTO)
        {
            Uri url = new Uri($"{this.BaseUrl.TrimEnd('/')}/{Constants.API_ROUTE_SUM}");

            var myContent = JsonConvert.SerializeObject(twoIntNumbersDTO);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, byteContent);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<string> Multiply(ITwoIntNumbersDTO twoIntNumbersDTO)
        {
            Uri url = new Uri($"{this.BaseUrl.TrimEnd('/')}/{Constants.API_ROUTE_SUM}");

            var myContent = JsonConvert.SerializeObject(twoIntNumbersDTO);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, byteContent);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<List<string>> Combination(ITwoIntNumbersDTO twoIntNumbersDTO)
        {
            Uri url = new Uri($"{this.BaseUrl.TrimEnd('/')}/{Constants.API_ROUTE_COMBINATION}");

            var myContent = JsonConvert.SerializeObject(twoIntNumbersDTO);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, byteContent);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());

            return result;
        }

        #endregion
    }
}
