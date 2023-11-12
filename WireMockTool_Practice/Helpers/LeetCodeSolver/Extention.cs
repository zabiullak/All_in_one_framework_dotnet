using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  WireMockTool_Practice.LeetCodeSolver
{
    public static class Extention
    {
        public static bool IsCharArrayMatched(this char[] arrayA, char[] arrayB)
        {
            for(int i = 0; i < arrayA.Length-1; i++)
            {
                if (arrayA[i] != arrayB[i]) return false;
            }
            return true;
        }
    }
}
