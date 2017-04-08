using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Diagnostics;

namespace Euler
{
    abstract class Euler : IEuler
    {
        public abstract long Exec();

        public static string InputText { get { return File.ReadAllText(FilePath); } }
        public static string[] InputLines { get { return File.ReadAllLines(FilePath); } }

        public static int Gcd(int a, int b)
        {
            while (b > 0)
            {
                var tmp = a % b;
                a = b;
                b = tmp;
            }
            return a;
        }

        public static BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (b > 0)
            {
                var tmp = a % b;
                a = b;
                b = tmp;
            }
            return a;
        }

        protected static string FilePath
        {
            get
            {
                return Path.Combine("Input", ClassName + ".txt");
            }
        }

        protected static string ClassName
        {
            get
            {
                var className = string.Empty;
                var frameInd = 1;
                var stackTrace = new StackTrace();
                do
                {
                    className = stackTrace.GetFrame(frameInd++).GetMethod().DeclaringType.Name;
                } while (className != null && !(className.StartsWith("Euler") && className.Length > "Euler".Length));
                return className;
            }
        }

        protected static int PrimeSieveLimit { get; private set; }
        protected static bool[] NotPrime { get; private set; }
        protected static List<int> Primes { get; private set; }
        protected static List<int> OddPrimes { get; private set; } 

        protected static void SievePrimes(int primeSieveLimit)
        {
            PrimeSieveLimit = primeSieveLimit;
            NotPrime = new bool[PrimeSieveLimit];
            NotPrime[0] = NotPrime[1] = true;
            for (var i = 2; i * i < PrimeSieveLimit; i++)
                if (!NotPrime[i])
                    for (var j = i * 2; j < PrimeSieveLimit; j += i)
                        NotPrime[j] = true;
        }

        protected static void CalcPrimes(int primeSieveLimit)
        {
            SievePrimes(primeSieveLimit);
            Primes = new List<int>(NotPrime.AsEnumerable()
                .Select((notPrime, ind) => new {notPrime, ind})
                .Where(el => !el.notPrime)
                .Select(el => el.ind));
            OddPrimes = Primes.Skip(1).ToList();
        }

        protected static bool IsPrime(long n)
        {
            if (n < 2 || n % 2 == 0)
                return false;
            for (var i = 3; i * i <= n; i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }

        protected static bool IsPrimeUsingPrimes(int p)
        {
            if (p < PrimeSieveLimit)
                return !NotPrime[p];

            foreach (var t in Primes)
                if (t * t > p)
                    return true;
                else if (p % t == 0)
                    return false;

            return true;
        }

        protected static int DigitCount(long n)
        {
            var res = 0;
            while (n > 0)
            {
                res++;
                n /= 10;
            }
            return res;
        }

        protected static int DigitSum(BigInteger n)
        {
            var ret = 0;
            while (n > 0)
            {
                ret += (int)(n % 10);
                n /= 10;
            }
            return ret;
        }

        protected static long[,] LoadMatrix(int n, string fileName)
        {
            var matrix = new long[n, n];
            var rows = InputLines;
            for (var row = 0; row < n; row++)
            {
                var cols = rows[row].Split(new[] { ',' });
                for (var col = 0; col < n; col++)
                    matrix[row, col] = long.Parse(cols[col]);
            }
            return matrix;
        }
    }
}
