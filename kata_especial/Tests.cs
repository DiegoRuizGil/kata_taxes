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

    private float IRPF(float income)
    {
        Debug.Assert(income >= 0);

        const float exemptMinThreshold = 15876;
        float percent = 0;

        if (income > exemptMinThreshold)
            percent += (income - exemptMinThreshold) * 0.24f;
        return percent;
    }
}