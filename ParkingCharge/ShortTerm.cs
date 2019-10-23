using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingCharge
{
    internal class ShortTerm : ICalculate
    {
        private const decimal ShortStay = 1.10M;
        private TimeSpan ChargingStartTime = new TimeSpan(8, 0, 0);
        private TimeSpan ChargingEndTime = new TimeSpan(18, 0, 0);
        public decimal CalculateCost(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                if (dateFrom > dateTo)
                {
                    System.IO.File.WriteAllText("error.txt", $"End Date set to before Start Date.\r\n------------------------\r\n\r\n");
                    return 0;
                }
                var startTime = dateFrom.TimeOfDay;
                var endTime = dateTo.TimeOfDay;

                if (dateFrom.Date == dateTo.Date)
                {
                    if ((startTime < ChargingStartTime && endTime < ChargingStartTime) || (startTime > ChargingEndTime && endTime > ChargingEndTime))
                        return 0;

                    if (startTime < ChargingStartTime)
                        startTime = ChargingStartTime;

                    if (endTime > ChargingEndTime)
                        endTime = ChargingEndTime;

                    var timeSpent = endTime - startTime;

                    var totalHours = timeSpent.Hours + (timeSpent.Minutes > 0 ? 1 : 0);

                    return decimal.Multiply(totalHours, ShortStay);
                }

                var startTimeSpan = dateFrom.TimeOfDay;
                var endTimeSpan = dateTo.TimeOfDay;
                var dateList = new List<DateTime>();
                for (var date = dateFrom.Date; date <= dateTo.Date; date = date.AddDays(1))
                {
                    dateList.Add(date);
                }

                if (dateList.Count == 2 && startTimeSpan > ChargingEndTime && endTimeSpan < ChargingStartTime)
                    return 0;

                if (startTimeSpan > ChargingEndTime)
                {
                    startTimeSpan = ChargingStartTime;
                    dateList.RemoveAt(0);
                }

                if (endTimeSpan < ChargingStartTime)
                {
                    endTimeSpan = ChargingEndTime;
                    dateList.RemoveAt(dateList.Count - 1);
                }

                if (startTimeSpan < ChargingStartTime)
                    startTimeSpan = ChargingStartTime;

                if (endTimeSpan > ChargingEndTime)
                    endTimeSpan = ChargingEndTime;

                var numberOfDays = 0;
                if (dateList.Count >=2)
                    numberOfDays = dateList.Count - 2;

                var time = endTimeSpan - startTimeSpan;

                var minutes = Convert.ToDecimal(time.TotalHours + (numberOfDays * 10));
                
                return decimal.Multiply(minutes, 1.1M);


            }
            catch (NullReferenceException ex)
            {
                System.IO.File.WriteAllText("error.txt", $"One or both of the dates supplied are null.\r\n\r\nFull Exception: {ex}\r\n------------------------\r\n\r\n");
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("error.txt", $"An error has occurred.\r\n\r\nFull Exception: {ex}\r\n------------------------\r\n\r\n");
            }

            return 0;
        }
        
    }
}
