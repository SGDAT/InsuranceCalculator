using System;
using System.Collections.Generic;
using System.Text;
using InsuranceCalculator.Data;

namespace InsuranceCalculator.Common
{
    public interface ICalculations
    {
        float CalculateLifeInsurance(int age, int sumAssured);

        float GetRiskPremium(float riskRate, int sumAssured);
        float GetRenewalCommission(float riskPremium);
        float GetNetPremium(float riskPremium, float renewalCommission);
        float GetInitialCommission(float netPremium);
        float GetGrossPremium(float netPremium, float initialCommision);

        float GetMonthlyPremium(float riskRate, int sumAssured);
    }

    public class Calculations : ICalculations
    {
        private readonly IRiskRate riskRate;

        public Calculations(IRiskRate riskRate)
        {
            this.riskRate = riskRate;
        }

        public float CalculateLifeInsurance(int age, int sumAssured)
        {
            float? riskRateValue = riskRate.GetRiskRate(age, sumAssured);
            float monthlyPremium = 0;

            if (riskRateValue != null)
                monthlyPremium = GetMonthlyPremium((float)riskRateValue, sumAssured);

            return monthlyPremium;
        }

        public float GetMonthlyPremium(float riskRate, int sumAssured)
        {
            float riskPremium = GetRiskPremium(riskRate, sumAssured);
            float renewalCommission = GetRenewalCommission(riskPremium);
            float netPremium = GetNetPremium(riskPremium, renewalCommission);
            float initialCommision = GetInitialCommission(netPremium);
            float grossPremium = GetGrossPremium(netPremium, initialCommision);

            return grossPremium;
        }

        public float GetGrossPremium(float netPremium, float initialCommision)
        {
            return netPremium + initialCommision;
        }

        public float GetInitialCommission(float netPremium)
        {
            float percent = 305f;
            return netPremium * (percent * netPremium);
        }

        public float GetNetPremium(float riskPremium, float renewalCommission)
        {
            return riskPremium + renewalCommission;
        }

        public float GetRenewalCommission(float riskPremium)
        {
            float percent = 0.03f;
            return (percent * riskPremium) * riskPremium;
        }

        public float GetRiskPremium(float riskRate, int sumAssured)
        {
            return riskRate * (sumAssured / 1000);
        }
    }
}