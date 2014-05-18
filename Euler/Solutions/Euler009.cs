namespace Euler.Solutions
{
    class Euler009 : IEuler
    {
        public long Exec()
        {
            for (var a = 1; a < 1000 - 6; a++)
                for (var b = a + 1; b < 1000 - 3; b++)
                {
                    var c = 1000 - (a + b);
                    if (a * a + b * b != c * c) continue;
                    return a * b * c;
                }
            return 0;
        }
    }
}
