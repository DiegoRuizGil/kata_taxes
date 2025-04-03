namespace kata_especial;

public readonly struct Threshold
{
    public readonly float income;
    public readonly float percent;

    public Threshold(float income, float percent)
    {
        this.income = income;
        this.percent = percent;
    }
}