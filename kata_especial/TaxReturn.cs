namespace kata_especial;

public class TaxReturn
{
    private readonly Salary _salary;
    
    public float ActualTaxes => IRPF.Of(_salary.GrossIncome);
    public float WithholdingTaxes => _salary.GrossIncome - _salary.NetIncome;
    public bool IsTaxRefund => ActualTaxes - WithholdingTaxes < 0;
    public bool IsTaxDue => ActualTaxes - WithholdingTaxes > 0;
    public bool RequiredToSubmit => _salary.GrossIncome > 22000.00f;

    public TaxReturn(Salary salary)
    {
        _salary = salary;
    }
}