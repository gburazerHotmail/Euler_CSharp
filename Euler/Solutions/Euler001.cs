using System.Linq;

namespace Euler.Solutions
{
    class Euler001 : IEuler
    {
        public long Exec()
        {
            return Enumerable.Range(1, 999).Where(n => n%3 == 0 || n%5 == 0).Sum();
        }
    }
}
