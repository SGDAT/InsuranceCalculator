using InsuranceCalculator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCalculator.Data.Models
{
    public class Band
    {
        public int SumAssured { get; set; }
        public AgeBand AgeBand { get; set; }
        public float? RiskRate { get; set; }
    }
}
