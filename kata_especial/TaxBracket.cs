using System.Diagnostics;

namespace kata_especial;

public readonly struct TaxBracket
{
    private readonly float _lowerThreshold;
    private readonly float _upperThreshold;
    private readonly float _percent;
    
    public float LowerThreshold => _lowerThreshold;
    public float UpperThreshold => _upperThreshold;
    public float Percent => _percent;
    
    private const float ExemptMinThreshold = 15876;
    private const float SecondThreshold = 20200;
    private const float ThirdThreshold = 35200;
    private const float FourthThreshold = 60000;
    public const float FifthThreshold = 300000;

    private TaxBracket(float lowerThreshold, float upperThreshold, float percent)
    {
        Debug.Assert(lowerThreshold  < upperThreshold);
        
        _lowerThreshold = lowerThreshold;
        _upperThreshold = upperThreshold;
        _percent = percent;
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
        return BelongToBracket(income, SecondBracket()._lowerThreshold);
    }

    public static bool BelongToThirdBracket(float income)
    {
        return BelongToBracket(income, ThirdBracket()._lowerThreshold);
    }

    public static bool BelongToFourthBracket(float income)
    {
        return BelongToBracket(income, FourthBracket()._lowerThreshold);
    }

    public static bool BelongToFifthBracket(float income)
    {
        return BelongToBracket(income, FifthBracket()._lowerThreshold);
    }

    public static bool BelongToSixthBracket(float income)
    {
        return BelongToBracket(income, SixthBracket()._lowerThreshold);
    }

    private static bool BelongToBracket(float income, float lowerThreshold)
    {
        return income > lowerThreshold;
    }
}