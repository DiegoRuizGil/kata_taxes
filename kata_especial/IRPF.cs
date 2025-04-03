using System.Diagnostics;

namespace kata_especial;

public static class IRPF
{
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        var irpf = 0f;

        if (TaxBracket.Second().AppliesTo(income))
            irpf += TaxBracket.Second().ApplyTo(income);
        
        if (TaxBracket.Third().AppliesTo(income))
            irpf += TaxBracket.Third().ApplyTo(income);
        
        if (TaxBracket.Fourth().AppliesTo(income))
            irpf += TaxBracket.Fourth().ApplyTo(income);
        
        if (TaxBracket.Fifth().AppliesTo(income))
            irpf += TaxBracket.Fifth().ApplyTo(income);
        
        if (TaxBracket.Sixth().AppliesTo(income))
            irpf += TaxBracket.Sixth().ApplyTo(income);
        
        return irpf;
    }

    public static float Of(float income, float freelanceExpenses)
    {
        Debug.Assert(freelanceExpenses >= 0);
        Debug.Assert(income > freelanceExpenses);
        
        return Of(income - freelanceExpenses);
    }
}