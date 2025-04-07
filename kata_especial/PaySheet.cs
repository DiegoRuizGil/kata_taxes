using System.Diagnostics;

namespace kata_especial;

public class PaySheet
{
    private readonly float _withholdingTaxRate;
    private readonly float _companyContribution;
    private readonly float _grossSalary;

    public float NetSalary => _grossSalary * (1 - _withholdingTaxRate);

    public PaySheet(float grossSalary, float withholdingTaxRate, float companyContribution)
    {
        Debug.Assert(grossSalary > 0);
        Debug.Assert(companyContribution >= grossSalary);
        Debug.Assert(withholdingTaxRate is >= 0 and <= 1);

        _grossSalary = grossSalary;
        _withholdingTaxRate = withholdingTaxRate;
        _companyContribution = companyContribution;
    }

    public float AnnualSalary(int payments)
    {
        return NetSalary * payments;
    }

    public float AnnualSocialSecurityCompanyContribution(int payments)
    {
        return (_companyContribution - _grossSalary) * payments;
    }
}