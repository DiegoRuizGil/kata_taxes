namespace kata_especial;

public class IRPFTest
{
    [Test]
    public void ExemptMin()
    {
        Assert.That(IRPF.Of(8701), Is.EqualTo(0));
        Assert.That(IRPF.Of(15875), Is.EqualTo(0));
    }

    [Test]
    public void FirstThreshold()
    {
        Assert.That(IRPF.Of(15877), Is.EqualTo(0.24f).Within(0.01f));
        Assert.That(IRPF.Of(15878), Is.EqualTo(0.48f).Within(0.01f));
    }

    [Test]
    public void SecondThreshold()
    {
        Assert.That(IRPF.Of(20201), Is.EqualTo(1038.06f).Within(0.01f));
        Assert.That(IRPF.Of(27542), Is.EqualTo(3240.36f).Within(0.01f));
    }

    [Test]
    public void ThirdThreshold()
    {
        Assert.That(IRPF.Of(35201), Is.EqualTo(5538.13f).Within(0.01f));
        Assert.That(IRPF.Of(47354.67f), Is.EqualTo(10034.98f).Within(0.01f));
    }

    [Test]
    public void FourthThreshold()
    {
        Assert.That(IRPF.Of(60001), Is.EqualTo(14714.21f).Within(0.01f));
        Assert.That(IRPF.Of(230278.48f), Is.EqualTo(91339.07f).Within(0.01f));
    }

    [Test]
    public void FifthThreshold()
    {
        Assert.That(IRPF.Of(300001), Is.EqualTo(122714.23f).Within(0.01f));
        Assert.That(IRPF.Of(705640.81f), Is.EqualTo(313364.94f).Within(0.01f));
    }

    [Test]
    public void FreelancerIRPF()
    {
        Assert.That(IRPF.Of(262278.48f, 32000), Is.EqualTo(91339.07f).Within(0.01f));
    }
}