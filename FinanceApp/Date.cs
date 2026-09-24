using System;

namespace FinanceApp
{
    internal class Date
    {
        public T MinDate<T>(T[] finance) where T : Finance
        {
            T min = finance[0];

            foreach (T item in finance)
            {
                if (item.Date < min.Date)
                {
                    min = item;
                }
            }

            return min;
        }

        public void PlusDay<T>(T obj) where T : Finance
        {
            obj.Date = obj.Date.AddDays(1);
        }

        public T BetweenDays<T>(T[] finance) where T : Finance
        {
            T min = finance[0];
            T max = finance[0];

            foreach (T item in finance)
            {
                if (item.Date < min.Date)
                {
                    min = item;
                }

                if (item.Date > max.Date)
                {
                    max = item;
                }
            }

            DateTime middle =
                min.Date.AddDays((max.Date - min.Date).Days / 2);

            T close = finance[0];

            foreach (T item in finance)
            {
                if (Math.Abs((item.Date - middle).Days) <
                    Math.Abs((close.Date - middle).Days))
                {
                    close = item;
                }
            }

            return close;
        }
    }
}