using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingCharge
{
    internal class LongTerm : ICalculate
    {
        private const decimal LongStay = 7.50M;
        public decimal CalculateCost(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var days = Convert.ToDecimal(Math.Ceiling((dateTo - dateFrom).TotalDays));
                if (days == 0)
                {
                    days = 1;
                }
                if (days < 0)
                {
                    System.IO.File.WriteAllText("error.txt", $"End Date set to before Start Date.\r\n------------------------\r\n\r\n");
                    return LongStay;
                }

                return decimal.Multiply(LongStay, days);
            }
            catch(NullReferenceException ex)
            {
                System.IO.File.WriteAllText("error.txt", $"One or both of the dates supplied are null.\r\n\r\nFull Exception: {ex}\r\n------------------------\r\n\r\n");
            }
            catch(Exception ex)
            {
                System.IO.File.WriteAllText("error.txt", $"An error has occurred.\r\n\r\nFull Exception: {ex}\r\n------------------------\r\n\r\n");
            }

            return LongStay;
        }
    }
}
