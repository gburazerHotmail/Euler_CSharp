namespace Euler.Solutions
{
    class Euler040 : IEuler
    {
        public long Exec()
        {
            var count = 0;
            var mult = 1;
            for (var i = 1; count <= 1000000; i++)
                foreach (var c in i.ToString())
                {
                    count++;
                    if (count == 1 || count == 10 || count == 100 || count == 1000 || count == 10000 || count == 100000 || count == 1000000)
                        mult *= int.Parse(c.ToString());
                }
            return mult;
        }
    }
}
