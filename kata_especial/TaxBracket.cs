namespace kata_especial;

public readonly struct TaxBracket
{
    private readonly float _lowerThreshold;
    private readonly float _upperThreshold;
    private readonly float _percent;
    
    public float LowerThreshold => _lowerThreshold;
    public float UpperThreshold => _upperThreshold;
    public float Percent => _percent;
    
    public const float ExemptMinThreshold = 15876;
    public const float SecondThreshold = 20200;
    public const float ThirdThreshold = 35200;
    public const float FourthThreshold = 60000;
    public const float FifthThreshold = 300000;

    private TaxBracket(float lowerThreshold, float upperThreshold, float percent)
    {
        _lowerThreshold = lowerThreshold;
        _upperThreshold = upperThreshold;
        _percent = percent;
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
        return new TaxBracket(FifthThreshold, -1f, 0.47f);
    }
}