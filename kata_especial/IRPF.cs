using System.Diagnostics;

namespace kata_especial;

public static class IRPF
{
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        var irpf = 0f;

        if (income > TaxBracket.ExemptMinThreshold)
            irpf += IncomeBracketIRPF(income, TaxBracket.Second());
        if (income > TaxBracket.SecondThreshold)
            irpf += IncomeBracketIRPF(income, TaxBracket.Third());
        if (income > TaxBracket.ThirdThreshold)
            irpf += IncomeBracketIRPF(income, TaxBracket.Fourth());
        if (income > TaxBracket.FourthThreshold)
            irpf += IncomeBracketIRPF(income, TaxBracket.Fifth());
        if (income > TaxBracket.FifthThreshold)
            irpf += (income - TaxBracket.FifthThreshold) * TaxBracket.Sixth().Percent;
        
        return irpf;
    }

    public static float Of(float income, float freelanceExpenses)
    {
        Debug.Assert(freelanceExpenses >= 0);
        Debug.Assert(income > freelanceExpenses);
        
        return Of(income - freelanceExpenses);
    }

    private static float IncomeBracketIRPF(float income, TaxBracket bracket)
    {
        float amountExceeded = income - bracket.UpperThreshold;
        float thresholdIncome = income - bracket.LowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome * bracket.Percent;
    }
}