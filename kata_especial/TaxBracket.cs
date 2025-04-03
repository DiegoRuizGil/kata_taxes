using System.Diagnostics;

namespace kata_especial;

public readonly struct TaxBracket
{
    public float LowerThreshold { get; }
    public float UpperThreshold { get; }
    public float Percent { get; }
    
    private const float ExemptMinThreshold = 15876;
    private const float SecondThreshold = 20200;
    private const float ThirdThreshold = 35200;
    private const float FourthThreshold = 60000;
    private const float FifthThreshold = 300000;

    private TaxBracket(float lowerThreshold, float upperThreshold, float percent)
    {
        Debug.Assert(lowerThreshold  < upperThreshold);
        
        LowerThreshold = lowerThreshold;
        UpperThreshold = upperThreshold;
        Percent = percent;
    }

    public static TaxBracket Second()
    {
        return new TaxBracket(ExemptMinThreshold, SecondThreshold, 0.24f);
    }

    public static TaxBracket Third()
    {
        return new TaxBracket(SecondThreshold, ThirdThreshold, 0.30f);
    }

    public static TaxBracket Fourth()
    {
        return new TaxBracket(ThirdThreshold, FourthThreshold, 0.37f);
    }

    public static TaxBracket Fifth()
    {
        return new TaxBracket(FourthThreshold, FifthThreshold, 0.45f);
    }

    public static TaxBracket Sixth()
    {
        return new TaxBracket(FifthThreshold, float.MaxValue, 0.47f);
    }

    public bool AppliesTo(float income)
    {
        return income > LowerThreshold;
    }
}