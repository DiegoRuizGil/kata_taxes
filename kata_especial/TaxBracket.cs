using System.Diagnostics;

namespace kata_especial;

public readonly struct TaxBracket
{
    private readonly float _lowerThreshold;
    private readonly float _upperThreshold;
    private readonly float _percent;

    private TaxBracket(float lowerThreshold, float upperThreshold, float percent)
    {
        Debug.Assert(lowerThreshold  < upperThreshold);
        
        _lowerThreshold = lowerThreshold;
        _upperThreshold = upperThreshold;
        _percent = percent;
    }

    private static TaxBracket First(Threshold threshold)
    {
        return new TaxBracket(0f, threshold.income, threshold.percent);
    }

    public static IEnumerable<TaxBracket> AllFrom2024()
    {
        return FromThresholds([
            new Threshold(15876, 0.00f),
            new Threshold(20200, 0.24f),
            new Threshold(35200, 0.30f),
            new Threshold(60000, 0.37f),
            new Threshold(300000, 0.45f),
            new Threshold(float.MaxValue, 0.47f)
        ]);
    }

    private static IEnumerable<TaxBracket> FromThresholds(Threshold[] thresholds)
    {
        var brackets = new List<TaxBracket>();
        brackets.Add(First(thresholds.First()));
        thresholds = thresholds.Skip(1).ToArray();
        foreach (var threshold in thresholds)
            brackets.Add(brackets.Last().Next(threshold));

        return brackets;
    }

    public float ApplyTo(float income)
    {
        if (!AppliesTo(income)) return 0;
        
        float amountExceeded = income - _upperThreshold;
        float thresholdIncome = income - _lowerThreshold;
        if (amountExceeded > 0)
            thresholdIncome -= amountExceeded;
        return thresholdIncome * _percent;
    }
    
    private bool AppliesTo(float income)
    {
        return income > _lowerThreshold;
    }

    private TaxBracket Next(Threshold threshold)
    {
        return new TaxBracket(_upperThreshold, threshold.income, threshold.percent);
    }
}