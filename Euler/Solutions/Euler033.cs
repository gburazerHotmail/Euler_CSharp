namespace Euler.Solutions
{
    class Euler033 : Euler
    {
        public override long Exec()
        {
            int solnom = 1, solden = 1;
            for (var nom = 10; nom <= 98; nom++)
                for (var den = nom + 1; den <= 99; den++)
                {
                    var n1 = nom / 10; var n2 = nom % 10;
                    var d1 = den / 10; var d2 = den % 10;
                    if (n2 == 0 && d2 == 0)
                        continue; // trivial
                    var d = Gcd(nom, den);
                    var minnom = nom / d;
                    var minden = den / d;
                    int dd;
                    if (n1 == d1 && n2 != 0 && d2 != 0)
                    {
                        dd = Gcd(n2, d2);
                        if (minnom != n2/dd || minden != d2/dd) continue;
                        solnom *= nom;
                        solden *= den;
                    }
                    else if (n1 == d2 && n2 != 0 && d1 != 0)
                    {
                        dd = Gcd(n2, d1);
                        if (minnom != n2/dd || minden != d1/dd) continue;
                        solnom *= nom;
                        solden *= den;
                    }
                    else if (n2 == d1 && n1 != 0 && d2 != 0)
                    {
                        dd = Gcd(n1, d2);
                        if (minnom != n1/dd || minden != d2/dd) continue;
                        solnom *= nom;
                        solden *= den;
                    }
                    else if (n2 == d2 && n1 != 0 && d1 != 0)
                    {
                        dd = Gcd(n1, d1);
                        if (minnom != n1/dd || minden != d1/dd) continue;
                        solnom *= nom;
                        solden *= den;
                    }
                }
            return solden / Gcd(solnom, solden);
        }
    }
}
