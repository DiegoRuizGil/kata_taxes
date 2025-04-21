namespace kata_especial;

public class TaxReturn
{
    private readonly Salary _salary;
    
    public float LastYearWithholdingTaxes => _salary.WithholdingTaxes;
    public float ActualTaxes => IRPF.Of(_salary.GrossIncome);

    public TaxReturn(Salary salary)
    {
        _salary = salary;
    }
}