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
    public const float FifthThreshold = 300000;

    private TaxBracket(float lowerThreshold, float upperThreshold, float percent)
    {
        Debug.Assert(lowerThreshold  < upperThreshold);
        
        LowerThreshold = lowerThreshold;
        UpperThreshold = upperThreshold;
        Percent = percent;
    }

    public static TaxBracket SecondBracket()
    {
        return new TaxBracket(ExemptMinThreshold, SecondThreshold, 0.24f);
    }

    public static TaxBracket ThirdBracket()
    {
        return new TaxBracket(SecondThreshold, ThirdThreshold, 0.30f);
    }

    public static TaxBracket FourthBracket()
    {
        return new TaxBracket(ThirdThreshold, FourthThreshold, 0.37f);
    }

    public static TaxBracket FifthBracket()
    {
        return new TaxBracket(FourthThreshold, FifthThreshold, 0.45f);
    }

    public static TaxBracket SixthBracket()
    {
        return new TaxBracket(FifthThreshold, float.MaxValue, 0.47f);
    }

    public static bool BelongToSecondBracket(float income)
    {
        return BelongToBracket(income, SecondBracket().LowerThreshold);
    }

    public static bool BelongToThirdBracket(float income)
    {
        return BelongToBracket(income, ThirdBracket().LowerThreshold);
    }

    public static bool BelongToFourthBracket(float income)
    {
        return BelongToBracket(income, FourthBracket().LowerThreshold);
    }

    public static bool BelongToFifthBracket(float income)
    {
        return BelongToBracket(income, FifthBracket().LowerThreshold);
    }

    public static bool BelongToSixthBracket(float income)
    {
        return BelongToBracket(income, SixthBracket().LowerThreshold);
    }

    private static bool BelongToBracket(float income, float lowerThreshold)
    {
        return income > lowerThreshold;
    }
}