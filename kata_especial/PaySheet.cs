using System.Diagnostics;

namespace kata_especial;

public class PaySheet
{
    public float WithholdingTaxRate { get; private set; }
    public float CompanyContribution { get; private set; }
    public float GrossSalary { get; private set; }

    public float NetSalary => GrossSalary * (1 - WithholdingTaxRate);

    public PaySheet(float grossSalary, float withholdingTaxRate, float companyContribution)
    {
        Debug.Assert(grossSalary > 0);
        Debug.Assert(companyContribution >= grossSalary);

        GrossSalary = grossSalary;
        WithholdingTaxRate = withholdingTaxRate;
        CompanyContribution = companyContribution;
    }
    
    
}