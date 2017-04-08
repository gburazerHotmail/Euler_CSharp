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
        private static void Main(string[] args)
        {
            if (!ProcessArgs(args))
                return;

            WriteIntro();
            foreach (var p in Problems.Where(p => TestAll || ProblemList.Contains(p.Key)))
                SolveAndWriteStatus(p.Key, p.Value);
            WriteSummary();
        }

        private static bool ProcessArgs(string[] args)
        {
            const string optionName = "optimizationTresholdMs";

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: {0} all|<problem_list> [-{1}=x]", AppDomain.CurrentDomain.FriendlyName, optionName);
                Console.WriteLine("   <problem_list> = semicolon separated list of problem id's (i.e. \"2;3;57;12\")");
                Console.WriteLine("Full problem list in \"{0}\".", ProblemsFileName);

                return false;
            }

            if (args[0] == "all")
                TestAll = true;
            else
            {
                TestAll = false;
                args[0].Split(';').ToList().ForEach(id => ProblemList.Add(int.Parse(id)));
            }

            if (args.Length > 1)
            {
                var option = args[1].Split('=');
                if (option.Length != 2
                    || option[0] != String.Format("-{0}", optionName)
                    || !int.TryParse(option[1], out OptimizationTresholdMs))
                {
                    Console.WriteLine("Invalid option: {0}", args[1]);

                    return false;
                }
            }

            return true;
        }

        private static bool TestAll;

        // ignored if TestAll
        private static HashSet<int> ProblemList = new HashSet<int>();

        private static int OptimizationTresholdMs = 1000;

        private const string ProblemsFileName = "Problems.txt";
        private static readonly Dictionary<int, long> Problems = LoadProblems(ProblemsFileName);

        private static Dictionary<int, long> LoadProblems(string fileName)
        {
            var problems = new Dictionary<int, long>();
            foreach (var line in File.ReadAllLines(fileName))
                if (!String.IsNullOrWhiteSpace(line))
                {
                    var data = line.Split(' ');
                    problems.Add(int.Parse(data[0]), long.Parse(data[1]));
                }
            return problems;
        }

        private static int InstancesCount { get { return ProblemList.Intersect(Problems.Keys).Count(); } }

        private static readonly Stopwatch Sw = new Stopwatch();
        private static int OkCount { get; set; }
        private static long MsTotal { get; set; }
        private static readonly List<int> NeedOptimization = new List<int>(); 

        private static void WriteIntro()
        {
            Console.WriteLine("{0} solution(s) registered{1}:", Problems.Count,
                ProblemList.Count > 0
                    ? String.Format(", {0} solution(s) to test", InstancesCount)
                    : "");
            Console.WriteLine("Optimization treshold (ms): {0}", OptimizationTresholdMs);
        }

        private static void SolveAndWriteStatus(int problemId, long expected)
        {
            Console.Write("{0,3}", problemId);
            var actual = -1L;
            var type = Type.GetType("Euler.Solutions.Euler" + problemId.ToString("D3"));
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
                    NeedOptimization.Add(problemId);
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
                OkCount, TestAll ? Problems.Count : InstancesCount, MsTotal);
            if (NeedOptimization.Count > 0)
                Console.WriteLine("Need optimization ({0}): {1}.",
                    NeedOptimization.Count, String.Join(", ", NeedOptimization));
            if (!TestAll && ProblemList.Count > InstancesCount)
                Console.WriteLine("Problems not found in \"{0}\": {1}", ProblemsFileName, 
                    String.Join(";", ProblemList.Except(Problems.Keys).Select(i => i.ToString())));
            WriteWindowsCpuIndex();
        }

        private static void WriteWindowsCpuIndex()
        {
            var file = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%WinDir%\Performance\WinSAT\DataStore\"))
                .EnumerateFileSystemInfos("*Formal.Assessment*.xml")
                .OrderByDescending(fi => fi.LastWriteTime)
                .FirstOrDefault();
            if (file != null)
                Console.WriteLine("Windows experience index, CPU: {0}",
                    XDocument.Load(file.FullName).Descendants("CpuScore").First().Value);
        }
    }
}
