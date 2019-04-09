using System;
using InsuranceCalculator.Common;
using InsuranceCalculator.Data;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICalculations, Calculations>()
                .AddSingleton<IRiskBand, RiskBand>()
                .AddSingleton<IRiskRate, RiskRate>()
                .BuildServiceProvider();

            while (true)
            {
                Console.WriteLine("Enter age");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter sum assured");
                int sumAssured = int.Parse(Console.ReadLine());

                //calculate life insurance here
                var bar = serviceProvider.GetService<ICalculations>();

                float lifeInsurance = bar.CalculateLifeInsurance(age, sumAssured);
                Console.WriteLine($"Life insurance: {lifeInsurance}");
                Console.WriteLine("---");
            }
            
        }
    }
}
