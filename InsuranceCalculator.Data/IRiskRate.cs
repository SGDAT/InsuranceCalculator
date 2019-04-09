using InsuranceCalculator.Common;
using InsuranceCalculator.Data.Models;
using System;
using System.Linq;

namespace InsuranceCalculator.Data
{

    public interface IRiskRate
    {
        float? GetRiskRate(int age, int sumAssured);
        AgeBand GetAgeBand(int age);
    }

    public class RiskRate : IRiskRate
    {
        private readonly IRiskBand riskBand;

        public RiskRate(IRiskBand riskBand)
        {
            this.riskBand = riskBand;
        }
        public float? GetRiskRate(int age, int sumAssured)
        {
            AgeBand ageBand = GetAgeBand(age);
            //IOrderedEnumerable<Band> bands = Bands.Where(b => b.AgeBand == ageBand && b.SumAssured <= sumAssured).OrderByDescending(b=>b.SumAssured);
            Band band = riskBand.GetAllBands().
                Where(b => b.AgeBand == ageBand).
                OrderByDescending(b => b.SumAssured).
                Aggregate((x, y) => Math.Abs(x.SumAssured - sumAssured) < Math.Abs(y.SumAssured - sumAssured) ? x : y);
            if (band == null)
                return null;

            return band.RiskRate;
        }

        public AgeBand GetAgeBand(int age)
        {
            if (age <= 0)
                return AgeBand.NoBand;
            if (age <= 30)
                return AgeBand.AgeLessThanOr30;
            if (age > 30 && age <= 50)
                return AgeBand.Age31To50;
            if (age > 50)
                return AgeBand.AgeOver50;

            return AgeBand.NoBand;
        }
    }


   
}
