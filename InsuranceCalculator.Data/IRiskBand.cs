using InsuranceCalculator.Common;
using InsuranceCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsuranceCalculator.Data
{
    public interface IRiskBand
    {
        List<Band> GetAllBands();

    }

    public class RiskBand : IRiskBand
    {
        public List<Band> Bands { get; set; }

        public RiskBand()
        {
            Bands = new List<Band>();
            Bands.Add(new Band { SumAssured = 25000, AgeBand = AgeBand.AgeLessThanOr30, RiskRate = 0.0172f });
            Bands.Add(new Band { SumAssured = 50000, AgeBand = AgeBand.AgeLessThanOr30, RiskRate = 0.0165f });
            Bands.Add(new Band { SumAssured = 100000, AgeBand = AgeBand.AgeLessThanOr30, RiskRate = 0.0154f });
            Bands.Add(new Band { SumAssured = 200000, AgeBand = AgeBand.AgeLessThanOr30, RiskRate = 0.0147f });
            Bands.Add(new Band { SumAssured = 300000, AgeBand = AgeBand.AgeLessThanOr30, RiskRate = 0.0144f });
            Bands.Add(new Band { SumAssured = 500000, AgeBand = AgeBand.AgeLessThanOr30, RiskRate = 0.0146f });

            Bands.Add(new Band { SumAssured = 25000, AgeBand = AgeBand.Age31To50, RiskRate = 0.1043f });
            Bands.Add(new Band { SumAssured = 50000, AgeBand = AgeBand.Age31To50, RiskRate = 0.0999f });
            Bands.Add(new Band { SumAssured = 100000, AgeBand = AgeBand.Age31To50, RiskRate = 0.0932f });
            Bands.Add(new Band { SumAssured = 200000, AgeBand = AgeBand.Age31To50, RiskRate = 0.0887f });
            Bands.Add(new Band { SumAssured = 300000, AgeBand = AgeBand.Age31To50, RiskRate = 0.0872f });
            Bands.Add(new Band { SumAssured = 500000, AgeBand = AgeBand.Age31To50, RiskRate = null });

            Bands.Add(new Band { SumAssured = 25000, AgeBand = AgeBand.AgeOver50, RiskRate = 0.2677f });
            Bands.Add(new Band { SumAssured = 50000, AgeBand = AgeBand.AgeOver50, RiskRate = 0.2565f });
            Bands.Add(new Band { SumAssured = 100000, AgeBand = AgeBand.AgeOver50, RiskRate = 0.2393f });
            Bands.Add(new Band { SumAssured = 200000, AgeBand = AgeBand.AgeOver50, RiskRate = 0.2285f });
            //Bands.Add(new Band { SumAssured = 300000, AgeBand = AgeBand.AgeOver50, RiskRate = null });
            //Bands.Add(new Band { SumAssured = 500000, AgeBand = AgeBand.AgeOver50, RiskRate = null });
        }

        public List<Band> GetAllBands()
        {
            return Bands;
        }

    }
}
