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
    
    public static float Of(float income)
    {
        Debug.Assert(income >= 0);

        const float exemptMinThreshold = 15876;
        float irpf = 0f;

        if (income > exemptMinThreshold)
            irpf += ThresholdIncome(income, 20200, exemptMinThreshold) * 0.24f;
        if (income > 20200)
            irpf += ThresholdIncome(income, 35200, 20200) * 0.30f;
        if (income > 35200)
            irpf += ThresholdIncome(income, 60000, 35200) * 0.37f;
        if (income > 60000)
            irpf += ThresholdIncome(income, 300000, 60000) * 0.45f;
        if (income > 300000)
            irpf += (income - 300000) * 0.47f;
        
        return irpf;
    }
    
    private static float ThresholdIncome(float income, float upperThreshold, float lowerThreshold)
    {
        float amountExceeded = income - upperThreshold;
        float thresholdIncome = income - lowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome;
    }
}