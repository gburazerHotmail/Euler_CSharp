using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Euler
{
    static class Program
    {
        static void Main()
        {
            var test = new HashSet<int>();// {74};
            var solutions = new List<long>
            {
                233168, 4613732, 6857, 906609, 232792560,             // 1  - 5
                25164150, 104743, 40824, 31875000, 142913828922,      // 6  - 10
                70600674, 76576500, 5537376230, 837799, 137846528820, // 11 - 15
                1366, 21124, 1074, 171, 648,                          // 16 - 20
                31626, 871198282, 4179871, 2783915460, 4782,          // 21 - 25
                983, -59231, 669171001, 9183, 443839,                 // 26 - 30
                73682, 45228, 100, 40730, 55,                         // 31 - 36
                872187, 748317, 932718654, 840, 210,                  // 36 - 40
                7652413, 162, 16695334890, 5482660, 1533776805,       // 41 - 45
                5777, 134043, 9110846700, 296962999629, 997651,       // 46 - 50
                121313, 142857, 4075, 376, 249,                       // 51 - 55
                972, 153, 26241, 107359, 26033,                       // 56 - 60
                28684, 127035954683, 49, 1322, 272,                   // 61 - 65
                0, 7273, 0, 510510, 0,                                // 66 - 70
                428570, 0, 0, 402, 0,                                 // 71 - 75
                190569291, 0, 0, 73162890, 0,                         // 76 - 80
                427337, 260324, 425185, 0, 0,                         // 81 - 85
                0, 0, 0, 743, 0,                                      // 86 - 90
                0, 8581146, 0, 0, 0,                                  // 91 - 95
                24702, 8739992577, 0, 0, 0                            // 96 - 100
            };

            var sw = new Stopwatch();
            var count = solutions.Count;
            var testCount = test.Count;
            var okCount = 0;
            long msTotal = 0;
            var needOptimization = new List<int>();
            Console.WriteLine("{0} solution(s) registered{1}:", count,
                testCount > 0 ? String.Format(", {0} solution(s) to test", testCount) : "");
            for (var i = 1; i <= count; i++)
            {
                if (!(testCount == 0 || test.Contains(i)))
                    continue;
                Console.Write("{0,3}", i);
                long actual = -1;
                var type = Type.GetType("Euler.Solutions.Euler" + i.ToString("D3"));
                sw.Restart();
                if (type != null)
                {
                    var cEuler = Activator.CreateInstance(type);
                    if (cEuler is IEuler)
                        actual = (cEuler as IEuler).Exec();
                }
                var ms = sw.ElapsedMilliseconds;
                Console.Write("{0,10}ms   ", ms);
                msTotal += ms;
                var expected = solutions[i-1];
                string str;
                if (actual == expected)
                {
                    if (ms >= 1000)
                    {
                        str = "Needs optimization.";
                        needOptimization.Add(i);
                    }
                    else
                        str = "Ok.";
                    okCount++;
                }
                else
                    str = String.Format("Error! Expected {0}.", expected);
                Console.WriteLine("{0,15} {1}", actual, str);
            }
            Console.WriteLine("{0}/{1} solution(s) correct (total {2}ms).", 
                okCount, testCount > 0 ? testCount : count, msTotal);
            if (needOptimization.Count > 0)
                Console.WriteLine("Need optimization ({0}): {1}.", 
                    needOptimization.Count, String.Join(", ", needOptimization));
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
