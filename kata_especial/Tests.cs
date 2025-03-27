using NUnit.Framework.Constraints;

namespace kata_especial;

public class Tests
{
    /*
     * IRPF -> impuesto a todas las personas físicas
     * mínimo exento -> 15.876 --> 0% IRPF
     * 8.701
     */
    
    [Test]
    public void ExemptMin()
    {
        Assert.That(IRPF(8701), Is.EqualTo(0));
    }

    private float IRPF(float income)
    {
        return 0;
    }
}