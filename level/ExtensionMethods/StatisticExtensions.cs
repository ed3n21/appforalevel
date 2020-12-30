using BL.ModelsBL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace level.ExtensionMethods
{
    public static class StatisticExtensions
    {
        public static decimal[] GetStatistic(this IEnumerable<TransactionBL> data, StatisticDateMode mode, int categoryId)
        {
            decimal[] spends;
            if (mode == StatisticDateMode.Days)
            {
                spends = new decimal[7];
                for (int i = 0; i < 7; i++)
                {
                    spends[i] = data.Where(t => t.CategoryId == categoryId)
                    .Where(t => t.Date.Day == DateTime.Now.Day - 6 + i)
                    .Select(t => t.Value)
                    .Sum();
                }
                return spends;
            }

            if (mode == StatisticDateMode.Months)
            {
                return null;
            }

            if (mode == StatisticDateMode.All)
            {
                return null;
            }

            return null;
        }





        public enum StatisticDateMode
        {
            Days = 1,
            Months = 2,
            All = 3
        }
    }
}