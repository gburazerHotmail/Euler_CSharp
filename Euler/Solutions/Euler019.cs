using System;

namespace Euler.Solutions
{
    class Euler019 : IEuler
    {
        public long Exec()
        {
            var startDate = new DateTime(1901, 1, 1);
            var endDate = new DateTime(2000, 12, 31);
            var res = 0;
            for (var date = startDate; DateTime.Compare(date, endDate) <= 0; date = date.AddDays(1))
                if (date.DayOfWeek == DayOfWeek.Sunday && date.Day == 1)
                    res++;
            return res;
        }
    }
}
