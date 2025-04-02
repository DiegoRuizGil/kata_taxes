using System.Diagnostics;

namespace kata_especial;

public static class IRPF
{
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        var irpf = 0f;

        if (TaxBracket.BelongToSecondBracket(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.SecondBracket());
        
        if (TaxBracket.BelongToThirdBracket(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.ThirdBracket());
        
        if (TaxBracket.BelongToFourthBracket(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.FourthBracket());
        
        if (TaxBracket.BelongToFifthBracket(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.FifthBracket());
        
        if (TaxBracket.BelongToSixthBracket(income))
            irpf += ApplySixthBracketTaxes(income);
        
        return irpf;
    }

    public static float Of(float income, float freelanceExpenses)
    {
        Debug.Assert(freelanceExpenses >= 0);
        Debug.Assert(income > freelanceExpenses);
        
        return Of(income - freelanceExpenses);
    }

    private static float ApplyBracketTaxes(float income, TaxBracket bracket)
    {
        float amountExceeded = income - bracket.UpperThreshold;
        float thresholdIncome = income - bracket.LowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome * bracket.Percent;
    }
    
    private static float ApplySixthBracketTaxes(float income)
    {
        return (income - TaxBracket.FifthThreshold) * TaxBracket.SixthBracket().Percent;
    }
}