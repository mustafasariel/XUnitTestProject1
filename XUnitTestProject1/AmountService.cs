using System;

namespace XUnitTestProject1
{
    public class AmountService
    {
        private IInflationRate _rate;
        private ILogger _log;

        public AmountService(IInflationRate object1, ILogger object2)
        {
            this._rate = object1;
            this._log = object2;
        }

        public double GetAmountByYear(double amount, int year)
        {
            if (year < 2000)
            {
                throw new ArgumentException("Yıl 2000 den küçük olamaz");
            }
            if (amount < 0)
            {
                throw new Exception("Amount 0 dan küçük olamaz");
            }
            double rate = _rate.GetRateByYear(year);

            return amount + amount * rate;
        }
    }
}