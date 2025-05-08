using System.Diagnostics;

namespace kata_especial;

public static class IRPF
{
    /*
     * IRPF -> pasar a clase no estatica si veo que es necesario
     */
    
    public static float Of(float income, float freelanceExpenses)
    {
        Debug.Assert(freelanceExpenses >= 0);
        Debug.Assert(income > freelanceExpenses);
        
        return Of(income - freelanceExpenses);
    }
    
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        return TaxBracket.AllFrom2024().Sum(bracket => bracket.ApplyTo(income));
    }
}