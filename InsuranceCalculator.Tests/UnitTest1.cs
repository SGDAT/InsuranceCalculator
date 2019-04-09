using InsuranceCalculator.Common;
using InsuranceCalculator.Data;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private IRiskBand riskBandRepository;
        private IRiskRate riskRate;
        private ICalculations calculations;

        [SetUp]
        public void Setup()
        {
            riskBandRepository = new RiskBand();
            riskRate = new RiskRate(riskBandRepository);
            calculations = new Calculations(riskRate);
        }

        [Test]
        public void Does_Get_Age_Band_Return_Correct_Age()
        {
            Assert.AreEqual(AgeBand.AgeLessThanOr30, riskRate.GetAgeBand(30));
            Assert.AreEqual(AgeBand.Age31To50, riskRate.GetAgeBand(35));
            Assert.AreEqual(AgeBand.AgeOver50, riskRate.GetAgeBand(52));
            Assert.AreEqual(AgeBand.NoBand, riskRate.GetAgeBand(0));
        }

        [Test]
        public void Does_Get_Risk_Rate_Fuction_Work()
        {
            Assert.AreEqual(0.0172f, riskRate.GetRiskRate(30, 25000));
            Assert.AreEqual(0.0165f, riskRate.GetRiskRate(30, 50000));
            Assert.AreEqual(0.0165f, riskRate.GetRiskRate(30, 49000));
            Assert.IsNull(riskRate.GetRiskRate(50, 500000));
            Assert.AreEqual(0.2285f, riskRate.GetRiskRate(57, 1000000));
        }

        [Test]
        public void Does_Risk_Premuim_Fuction_Work()
        {
            Assert.AreEqual(0.43f, calculations.GetRiskPremium(0.0172f, 25000));
        }

        [Test]
        public void Does_Renewal_Commision_Fuction_Work()
        {
            Assert.AreEqual(0.005547f, calculations.GetRenewalCommission(0.43f));
        }

        [Test]
        public void Does_Net_Premium_Fuction_Work()
        {
            Assert.AreEqual(0.435547f, calculations.GetNetPremium(0.43f, 0.005547f));
        }

        [Test]
        public void Does_Initial_Commission_Fuction_Work()
        {
            Assert.AreEqual(57.85886f, calculations.GetInitialCommission(0.435547f));
        }

        [Test]
        public void Does_Gross_Premium_Fuction_Work()
        {
            Assert.AreEqual(58.2944069f, calculations.GetGrossPremium(0.435547f, 57.85886f));
        }
    }
}