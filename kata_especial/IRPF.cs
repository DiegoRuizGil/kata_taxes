using System.Diagnostics;

namespace kata_especial;

public static class IRPF
{
    /*
     * IRPF -> impuesto a todas las personas físicas
     *  - va por tramos (umbral superior - inferior)
     *  - IRPF >= 0
     *
     * más ingresos -> más beneficios
     *
     * cifras MUY decimales
     * incluir gastos para los autónomos (solo)
     */
    
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

    private static float IncomeBracketIRPF(float income, TaxBracket bracket)
    {
        float amountExceeded = income - bracket.UpperThreshold;
        float thresholdIncome = income - bracket.LowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome * bracket.Percent;
    }
}