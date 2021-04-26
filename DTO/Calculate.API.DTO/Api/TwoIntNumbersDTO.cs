
using Calculate.Api.Dto.Interfaces;
using System;

namespace Calculate.Api.Dto.Api
{
    public class TwoIntNumbersDTO: ITwoIntNumbersDTO
    {
        public Int64 FirstNumber { get; set; }
        public Int64 SecondNumber { get; set; }

    }
}
