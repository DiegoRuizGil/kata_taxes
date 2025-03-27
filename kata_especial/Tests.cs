using System.Diagnostics;
using NUnit.Framework.Constraints;

namespace kata_especial;

public class Tests
{
    /*
     * IRPF -> impuesto a todas las personas físicas
     *  - va por tramos (umbral superior - inferior)
     * mínimo exento -> 15.876 --> 0% IRPF
     *  - tramo -> [0, 15.876] (NO SABEMOS SI ES ABIERTO O CERRADO)
     *
     * tramo inventado -> [15.876, infinito) -> IRPF = 10%
     *
     * no se aceptan valores negativos
     */
    
    [Test]
    public void ExemptMin()
    {
        Assert.That(IRPF(8701), Is.EqualTo(0));
    }

    private float IRPF(float income)
    {
        Debug.Assert(income >= 0);
        return 0;
    }
}