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
     * 
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
        Assert.That(IRPF(15877), Is.EqualTo(1587.7f).Within(0.01f));
        Assert.That(IRPF(15878), Is.EqualTo(1587.8f).Within(0.01f));
    }

    private float IRPF(float income)
    {
        Debug.Assert(income >= 0);
        Debug.Assert(income != 15876, "No sabemos que hacer con esta cantidad de ingresos");
        
        if (income > 15876)
            return income * 0.1f;
        return 0;
    }
}