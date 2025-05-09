using System.Diagnostics;

namespace Model;

public class Salary
{
    private readonly PaySheet[] _paySheets;

    public float GrossIncome => _paySheets.Sum(paySheet => paySheet.grossWage);
    public float NetIncome => _paySheets.Sum(paySheet => paySheet.grossWage * (1 - paySheet.withholdingTaxRate));
    public float SocialSecurityCompanyContribution => _paySheets.Sum(paySheet => paySheet.companyContribution - paySheet.grossWage);
    
    public Salary(PaySheet[] paySheets)
    {
        Debug.Assert(paySheets.Length is 12 or 14);
        
        _paySheets = paySheets;
    }
}