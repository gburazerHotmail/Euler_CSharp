using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Euler
{
    internal static class Program
    {
        private const bool TestAll = false;

        // ignored if TestAll == true
        private static readonly HashSet<int> ProblemNumbersToTest = new HashSet<int> {12, 18, 35};

        private const int OptimizationTresholdMs = 1000;

        private static readonly Dictionary<int, long> Problems = new Dictionary<int, long>
        {
            {1, 233168},
            {2, 4613732},
            {3, 6857},
            {4, 906609},
            {5, 232792560},
            {6, 25164150},
            {7, 104743},
            {8, 40824},
            {9, 31875000},
            {10, 142913828922},
            {11, 70600674},
            {12, 76576500},
            {13, 5537376230},
            {14, 837799},
            {15, 137846528820},
            {16, 1366},
            {17, 21124},
            {18, 1074},
            {19, 171},
            {20, 648},
            {21, 31626},
            {22, 871198282},
            {23, 4179871},
            {24, 2783915460},
            {25, 4782},
            {26, 983},
            {27, -59231},
            {28, 669171001},
            {29, 9183},
            {30, 443839},
            {31, 73682},
            {32, 45228},
            {33, 100},
            {34, 40730},
            {35, 55},
            {36, 872187},
            {37, 748317},
            {38, 932718654},
            {39, 840},
            {40, 210},
            {41, 7652413},
            {42, 162},
            {43, 16695334890},
            {44, 5482660},
            {45, 1533776805},
            {46, 5777},
            {47, 134043},
            {48, 9110846700},
            {49, 296962999629},
            {50, 997651},
            {51, 121313},
            {52, 142857},
            {53, 4075},
            {54, 376},
            {55, 249},
            {56, 972},
            {57, 153},
            {58, 26241},
            {59, 107359},
            {60, 26033},
            {61, 28684},
            {62, 127035954683},
            {63, 49},
            {64, 1322},
            {65, 272},
            {67, 7273},
            {69, 510510},
            {71, 428570},
            {74, 402},
            {76, 190569291},
            {79, 73162890},
            {81, 427337},
            {82, 260324},
            {83, 425185},
            {89, 743},
            {92, 8581146},
            {96, 24702},
            {97, 8739992577},
            {99, 709}
        };

        private static readonly Stopwatch Sw = new Stopwatch();
        private static int OkCount { get; set; }
        private static long MsTotal { get; set; }
        private static readonly List<int> NeedOptimization = new List<int>(); 

        private static void Main()
        {
            WriteIntro();
            foreach (var p in Problems.Where(p => TestAll || ProblemNumbersToTest.Contains(p.Key)))
                SolveAndWriteStatus(p.Key, p.Value);
            WriteSummary();
        }

        private static void WriteIntro()
        {
            Console.WriteLine("{0} solution(s) registered{1}:", Problems.Count,
                ProblemNumbersToTest.Count > 0
                    ? String.Format(", {0} solution(s) to test", ProblemNumbersToTest.Count)
                    : "");            
        }

        private static void SolveAndWriteStatus(int number, long expected)
        {
            Console.Write("{0,3}", number);
            var actual = -1L;
            var type = Type.GetType("Euler.Solutions.Euler" + number.ToString("D3"));
            Sw.Restart();
            if (type != null)
            {
                var cEuler = Activator.CreateInstance(type);
                if (cEuler is IEuler)
                    actual = (cEuler as IEuler).Exec();
            }
            var ms = Sw.ElapsedMilliseconds;
            Console.Write("{0,10}ms   ", ms);
            MsTotal += ms;
            string str;
            if (actual == expected)
            {
                if (ms >= OptimizationTresholdMs)
                {
                    str = "Needs optimization.";
                    NeedOptimization.Add(number);
                }
                else
                    str = "Ok.";
                OkCount++;
            }
            else
                str = String.Format("Error! Expected {0}.", expected);
            Console.WriteLine("{0,15} {1}", actual, str);
        }

        private static void WriteSummary()
        {
            Console.WriteLine("{0}/{1} solution(s) correct (total {2}ms).",
                OkCount, TestAll ? Problems.Count : ProblemNumbersToTest.Count, MsTotal);
            if (NeedOptimization.Count > 0)
                Console.WriteLine("Need optimization ({0}): {1}.",
                    NeedOptimization.Count, String.Join(", ", NeedOptimization));
            Console.WriteLine("Windows experience index, CPU: " + WindowsCpuIndex());            
        }

        private static string WindowsCpuIndex()
        {
            var file = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%WinDir%\Performance\WinSAT\DataStore\"))
                .EnumerateFileSystemInfos("*Formal.Assessment*.xml")
                .OrderByDescending(fi => fi.LastWriteTime)
                .FirstOrDefault();

            return file == null
                ? "WEI assessment xml not found"
                : XDocument.Load(file.FullName).Descendants("CpuScore").First().Value;
        }
    }
}
