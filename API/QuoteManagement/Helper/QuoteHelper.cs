using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteManagement.Helper
{
    public class QuoteHelper : IQuoteHelper
    {
        public double GetMaturityAmount(DateTime startDate, DateTime endDate, decimal amount)
        {
            var dateDifference = (endDate - startDate).TotalDays;
            double interestAmount = 0;
            if (dateDifference <= 30)
            {
                interestAmount = (0.5 / 100) * (double)amount;
            }
            else if (dateDifference <= 90)
            {
                interestAmount = (1.5 / 100) * (double)amount;
            }
            else if (dateDifference <= 120)
            {
                interestAmount = (2 / 100) * (double)amount;
            }
            else
            {
                interestAmount = (5 / 100) * (double)amount;
            }

            return ((double)amount + interestAmount);
        }
    }
}
