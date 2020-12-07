using System.Collections.Generic;

namespace Challenges
{
    /// <summary>
    /// TDD
    /// </summary>
    public class Day1Solver
    {
        public int SolveDay1(List<int> testData)
        {
            for (int i = 0; i < testData.Count; i++)
            {
                var iValue = testData[i];
                for (int j = 0; j < testData.Count; j++)
                {
                    var jValue = testData[j];
                    if (iValue + jValue == 2020)
                    {
                        return iValue * jValue;
                    }
                }
            }

            return -1;
        }
        
        public int SolveDay1B(List<int> testData)
        {
            for (int i = 0; i < testData.Count; i++)
            {
                var iValue = testData[i];
                for (int j = 0; j < testData.Count; j++)
                {
                    var jValue = testData[j];
                    for (int k = 0; k < testData.Count; k++)
                    {
                        var kValue = testData[k];
                        if (iValue + jValue + kValue  == 2020)
                        {
                            return iValue * jValue * kValue;
                        }    
                    }
                }
            }

            return -1;
        }
    }
}