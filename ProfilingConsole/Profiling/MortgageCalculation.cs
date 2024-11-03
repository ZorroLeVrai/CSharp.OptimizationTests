using ProfilingConsole;

namespace ConsoleApp.Profiling;

internal class MortgageCalculation : IRunnable
{
    public static double CalculateMonthlyPayment(double loanAmount, double annualInterestRate, int termInYears)
    {
        var monthlyInterestRate = annualInterestRate / 12 / 100;
        var numberOfPayments = termInYears * 12;
        var monthlyPayment = loanAmount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));
        return monthlyPayment;
    }

    public static double CalculateMaximumLoanAmount(double monthlyPayment, double annualInterestRate, int termInYears)
    {
        var monthlyInterestRate = annualInterestRate / 12 / 100;
        var numberOfPayments = termInYears * 12;
        var loanAmount = monthlyPayment / (monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments)));
        return loanAmount;
    }

    public static double CalculateMaxInterestRate(double loanAmount, double monthlyPayment, int termInYears)
    {
        var numberOfPayments = termInYears * 12;
        var low = 0.0;
        var high = 100.0; // Assuming a maximum possible interest rate of 100%
        var epsilon = 0.0001; // Precision threshold

        while (high - low > epsilon)
        {
            var mid = (low + high) / 2;
            var monthlyInterestRate = mid / 12 / 100;
            var monthlyPaymentCalc = loanAmount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));

            if (monthlyPaymentCalc < monthlyPayment)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }

        return (low + high) / 2;
    }

    public void Run()
    {
        Console.WriteLine(CalculateMonthlyPayment(100000, 3, 10));

        Console.WriteLine(CalculateMaximumLoanAmount(1200, 3, 20));

        Console.WriteLine(CalculateMaxInterestRate(216373.10, 1200, 20));
    }
}
