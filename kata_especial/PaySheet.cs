using System.Diagnostics;

namespace kata_especial;

public class PaySheet
{
    /*
     * payments -> atributo
     * salario -> año
     * sueldo -> mes (wage)
     *
     * salario -> nuevo objeto
     *  - lista de nominas
     */
    
    public readonly float withholdingTaxRate;
    public readonly float companyContribution;
    public readonly float grossWage;

    public float NetSalary => grossWage * (1 - withholdingTaxRate);

    public PaySheet(float grossWage, float withholdingTaxRate, float companyContribution)
    {
        Debug.Assert(grossWage > 0);
        Debug.Assert(companyContribution >= grossWage);
        Debug.Assert(withholdingTaxRate is >= 0 and <= 1);

        this.grossWage = grossWage;
        this.withholdingTaxRate = withholdingTaxRate;
        this.companyContribution = companyContribution;
    }
}