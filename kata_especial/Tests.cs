using System.Diagnostics;
using NUnit.Framework.Constraints;

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
     * primer tramo -> [15876, 25000]
     * segundo tramo -> (25000, infinito)
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
        Assert.That(IRPF(15877), Is.EqualTo(0.1f).Within(0.01f));
        Assert.That(IRPF(15878), Is.EqualTo(0.2f).Within(0.01f));
    }

    private float IRPF(float income)
    {
        const float exemptMinThreshold = 15876;
        Debug.Assert(income >= 0);
        
        if (income > exemptMinThreshold)
            return (income - exemptMinThreshold) * 0.1f;
        return 0;
    }
}