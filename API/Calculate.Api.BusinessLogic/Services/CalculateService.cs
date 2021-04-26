using Calculate.Api.BusinessLogic.Interfaces;
using Calculate.Api.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Threading.Tasks;

namespace Calculate.Api.BusinessLogic
{
    public class CalculateService: ICalculateService
    {
       
        public CalculateService()
        {
           
        }
        
        public async Task<string> Sum(ITwoIntNumbersDTO twoIntNumbersDTO)
        {
            BigInteger result = (BigInteger)twoIntNumbersDTO.FirstNumber + (BigInteger)twoIntNumbersDTO.SecondNumber;

            return result.ToString();
        }

        public async Task<string> Subtract(ITwoIntNumbersDTO twoIntNumbersDTO)
        {
            BigInteger result = (BigInteger)twoIntNumbersDTO.FirstNumber - (BigInteger)twoIntNumbersDTO.SecondNumber;

            return result.ToString();
        }

        public async Task<string> Multiply(ITwoIntNumbersDTO twoIntNumbersDTO)
        {
            BigInteger result = (BigInteger)twoIntNumbersDTO.FirstNumber * (BigInteger)twoIntNumbersDTO.SecondNumber;

            return result.ToString();
        }

        public async Task<List<string>> Combination(ITwoIntNumbersDTO twoIntNumberDTO)
        {
            Int64 numberOfDigits = twoIntNumberDTO.FirstNumber;
            Int64 sumOfDigits = twoIntNumberDTO.SecondNumber;

            List<string> resultCheckSum = new List<string>();
            
            String[] operation = new String[] { "+", "-", "" };
            int numberOfResults = 0;
            long maxValue = 0;

            List<string> previousList = new List<string>{"1","-1"}; 
            List<string> currentList; 

            for (int i = 1; i < numberOfDigits; i++)
            {
                currentList = new List<string>();

                for (int k = 0; k < previousList.Count; k++)
                {
                    foreach (string oper in operation)
                    {
                        string value = new string(previousList[k].ToString() + oper + (i + 1).ToString());
                        currentList.Add(value);

                        if (i == (numberOfDigits - 1))
                        {
                            long sum = CalculateService.Evaluate(value.ToString());

                            if (sum == sumOfDigits)
                            {
                                numberOfResults++;
                                resultCheckSum.Add(value + "=" + sumOfDigits.ToString());
                            }

                            if (sum > maxValue)
                                maxValue = sum;
                        }
                    }
                }

                previousList = currentList;
            }

            return resultCheckSum;
        }

        static long Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(long), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (long)(loDataTable.Rows[0]["Eval"]);
        }
    }
}
