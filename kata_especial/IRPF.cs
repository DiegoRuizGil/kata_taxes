using System.Diagnostics;

namespace kata_especial;

public static class IRPF
{
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        var irpf = 0f;

        if (TaxBracket.Second().AppliesTo(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.Second());
        
        if (TaxBracket.Third().AppliesTo(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.Third());
        
        if (TaxBracket.Fourth().AppliesTo(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.Fourth());
        
        if (TaxBracket.Fifth().AppliesTo(income))
            irpf += ApplyBracketTaxes(income, TaxBracket.Fifth());
        
        if (TaxBracket.Sixth().AppliesTo(income))
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
        return ApplyBracketTaxes(income, TaxBracket.Sixth().LowerThreshold, income, TaxBracket.Sixth().Percent);
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