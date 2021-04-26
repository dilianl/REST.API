using Calculate.Api.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Api.Client.Interfaces
{
    public interface ICalculateApiClient
    {
        #region General
        Task<string> GetApiStatus();
        Task<string> GetApiStatusExtended();
        #endregion

        #region Main
        Task<string> Sum(ITwoIntNumbersDTO towIntNumbersDTO);
        Task<string> Subtract(ITwoIntNumbersDTO towIntNumbersDTO);
        Task<string> Multiply(ITwoIntNumbersDTO twoIntNumbersDTO);
        Task<List<string>> Combination(ITwoIntNumbersDTO twoIntNumberDTO);
        #endregion
    }
}
