using System.Diagnostics;

namespace kata_especial;

public class Tests
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
    
    [Test]
    public void ExemptMin()
    {
        Assert.That(IRPF(8701), Is.EqualTo(0));
        Assert.That(IRPF(15875), Is.EqualTo(0));
    }

    [Test]
    public void FirstThreshold()
    {
        Assert.That(IRPF(15877), Is.EqualTo(0.24f).Within(0.01f));
        Assert.That(IRPF(15878), Is.EqualTo(0.48f).Within(0.01f));
    }

    [Test]
    public void SecondThreshold()
    {
        Assert.That(IRPF(20201), Is.EqualTo(1038.06f).Within(0.01f));
        Assert.That(IRPF(27542), Is.EqualTo(3240.36f).Within(0.01f));
    }

    [Test]
    public void ThirdThreshold()
    {
        Assert.That(IRPF(35201), Is.EqualTo(5538.13f).Within(0.01f));
        Assert.That(IRPF(47354.67f), Is.EqualTo(10034.98f).Within(0.01f));
    }

    [Test]
    public void FourthThreshold()
    {
        Assert.That(IRPF(60001), Is.EqualTo(14714.21f).Within(0.01f));
        Assert.That(IRPF(230278.48f), Is.EqualTo(91339.07f).Within(0.01f));
    }

    private float IRPF(float income)
    {
        Debug.Assert(income >= 0);

        const float exemptMinThreshold = 15876;
        float irpf = 0f;

        if (income > exemptMinThreshold)
        {
            irpf += ThresholdIncome(income, 20200, exemptMinThreshold) * 0.24f;
        }
        if (income > 20200)
        {
            irpf += ThresholdIncome(income, 35200, 20200) * 0.30f;
        }
        if (income > 35200)
        {
            irpf += ThresholdIncome(income, 60000, 35200) * 0.37f;
        }
        if (income > 60000)
        {
            irpf += ThresholdIncome(income, 300000, 60000) * 0.45f;
        }
        
        return irpf;
    }

    private float ThresholdIncome(float income, float upperThreshold, float lowerThreshold)
    {
        float amountExceeded = income - upperThreshold;
        float thresholdIncome = income - lowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome;
    }
}