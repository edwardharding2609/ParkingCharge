using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingCharge
{
    internal interface ICalculate
    {
        decimal CalculateCost(DateTime dateFrom, DateTime dateTo);
    }
}
