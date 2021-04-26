using Calculate.Api.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Api.BusinessLogic.Interfaces
{
    public interface ICalculateService
    {
        Task<string> Sum(ITwoIntNumbersDTO twoIntNumbersDTO);
        Task<string> Subtract(ITwoIntNumbersDTO twoIntNumbersDTO);
        Task<string> Multiply(ITwoIntNumbersDTO twoIntNumbersDTO);
        Task<List<string>> Combination(ITwoIntNumbersDTO twoIntNumberDTO);
    }
}
