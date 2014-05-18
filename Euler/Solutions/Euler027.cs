namespace Euler.Solutions
{
    class Euler027 : Euler
    {
        public override long Exec()
        {
            var res = 0;
            var max = 0;
            const int limit = 1000;
            for (var absa = 0; absa < limit; absa++)
                for (var absb = 0; absb < limit; absb++)
                    for (var minusa = 0; minusa < 2; minusa++)
                        for (var minusb = 0; minusb < 2; minusb++)
                        {
                            var a = (minusa > 0 ? -1 : 1) * absa;
                            var b = (minusb > 0 ? -1 : 1) * absb;
                            var cp = ConsecutivePrimes(a, b);
                            if (cp < max) continue;
                            max = cp;
                            res = a * b;
                        }
            return res;
        }

        private static int ConsecutivePrimes(int a, int b)
        {
            var res = 0;
            for (var n = 0; IsPrime(n*n + a*n + b); n++)
                res++;
            return res;
        }
    }
}
