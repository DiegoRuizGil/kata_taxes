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
     * tramo 1 -> [0, 12450] -> 19%
     * tramo 2 -> (12450, 20200] -> 24%
     * tramo 3 -> (20200, 35200] -> 30%
     * tramo 4 -> (35200, 60000] -> 37%
     * tramo 5 -> (60000, 300000] -> 45%
     * tramo 6 -> (300000, infinito) -> 47%
     *
     * mínimo exento = 15876
     *
     * cifras MUY decimales
     * incluir gastos para los autónomos (solo)
     */

    private const float ExemptMinThreshold = 15876;
    private const float SecondThreshold = 20200;
    private const float ThirdThreshold = 35200;
    private const float FourthThreshold = 60000;
    private const float FifthThreshold = 300000;
    
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        var irpf = 0f;

        if (income > ExemptMinThreshold)
            irpf += IncomeBracketIRPF(income, ExemptMinThreshold, SecondThreshold, 0.24f);
        if (income > SecondThreshold)
            irpf += IncomeBracketIRPF(income, SecondThreshold, ThirdThreshold, 0.30f);
        if (income > ThirdThreshold)
            irpf += IncomeBracketIRPF(income, ThirdThreshold, FourthThreshold, 0.37f);
        if (income > FourthThreshold)
            irpf += IncomeBracketIRPF(income, FourthThreshold, FifthThreshold, 0.45f);
        if (income > FifthThreshold)
            irpf += (income - FifthThreshold) * 0.47f;
        
        return irpf;
    }

    private static float IncomeBracketIRPF(float income, float lowerThreshold, float upperThreshold, float percent)
    {
        float amountExceeded = income - upperThreshold;
        float thresholdIncome = income - lowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome * percent;
    }
}