using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App
{
    public class InputData
    {
        public int N { get; set; }
        public int K { get; set; }
        public int W { get; set; }
        public int DW { get; set; }
        public int S { get; set; }
        public HashSet<int> ForbiddenWeekdays { get; set; } = [];
        public HashSet<int> ForbiddenMonthDays { get; set; } = [];

        public static InputData ReadFromFile(string filePath, IFileReader fileReader)
        {
            var input = fileReader.ReadLines(filePath);

            var firstLine = input[0].Split().Select(int.Parse).ToArray();
            int n = firstLine[0], k = firstLine[1];

            var secondLine = input[1].Split().Select(int.Parse).ToArray();
            int w = secondLine[0], dw = secondLine[1], s = secondLine[2];

            var forbiddenWeekdays = input[2].Split().Select(int.Parse).ToHashSet();

            int dm = int.Parse(input[3]);
            var forbiddenMonthDays = input[4].Split().Select(int.Parse).ToHashSet();

            return new InputData
            {
                N = n,
                K = k,
                W = w,
                DW = dw,
                S = s,
                ForbiddenWeekdays = forbiddenWeekdays,
                ForbiddenMonthDays = forbiddenMonthDays
            };
        }

        public override string ToString()
        {
            return $"N: {N}, K: {K}, W: {W}, DW: {DW}, S: {S}, ForbiddenWeekdays: {string.Join(", ", ForbiddenWeekdays)}, ForbiddenMonthDays: {string.Join(", ", ForbiddenMonthDays)}";
        }
    }
}