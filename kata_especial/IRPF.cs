using System.Diagnostics;

namespace kata_especial;

public static class IRPF
{
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        var irpf = 0f;

        irpf += TaxBracket.Second().ApplyTo(income);
        irpf += TaxBracket.Third().ApplyTo(income);
        irpf += TaxBracket.Fourth().ApplyTo(income);
        irpf += TaxBracket.Fifth().ApplyTo(income);
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