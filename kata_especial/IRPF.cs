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
    
    private static float ApplySixthBracketTaxes(float income)
    {
        return ApplyBracketTaxes(income, TaxBracket.SixthBracket().LowerThreshold, income, TaxBracket.SixthBracket().Percent);
    }

    private static float ApplyBracketTaxes(float income, TaxBracket bracket)
    {
        return ApplyBracketTaxes(income, bracket.LowerThreshold, bracket.UpperThreshold, bracket.Percent);
    }

    private static float ApplyBracketTaxes(float income, float lowerThreshold, float upperThreshold, float percent)
    {
        float amountExceeded = income - upperThreshold;
        float thresholdIncome = income - lowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome * percent;
    }
}