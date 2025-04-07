using System.Diagnostics;

namespace kata_especial;

public class PaySheetTests
{
    /*
     * nomina (paysheet):
     *  - (derivado) sueldo neto del trabajador (employee's net salary)
     *  - porcentaje IRPF deducido (15%) (withholding tax rate)
     *  - aportacion empresa -> bruto + seguridad social (company's contribution)
     *  - sueldo bruto trabajador (employee's gross salary)
     *
     * obtener:
     *  - sueldo neto trabajador
     *  - salario anual (indicar pagas 12 o 14)
     *  - seguridad social anual total que aporta la empresa
     */

    [Test]
    public void NetSalaryWithWithholdingTaxRateAt0()
    {
        var paySheet = new PaySheet(1800.00f, 0.00f, 1800.00f);
        Assert.That(paySheet.NetSalary, Is.EqualTo(1800.00f));
    }

    [Test]
    public void NetSalaryWithWithholdingTaxRateAt15()
    {
        var paySheet = new PaySheet(1800.00f, 0.15f, 1800.00f);
        Assert.That(paySheet.NetSalary, Is.EqualTo(1530.00f));
    }

    [Test]
    public void AnnualSalaryWith12Payments()
    {
        var paySheet = new PaySheet(1800.00f, 0.15f, 1800.00f);
        Assert.That(AnnualSalary(12, paySheet), Is.EqualTo(18360.00f));
    }

    [Test]
    public void TotalAnnualEmployerSocialSecurityContribution()
    {
        Assert.That(AnnualSocialSecurityContribution(2450.00f, 1800.00f, 12), Is.EqualTo(7800.00f));
    }

    private static float AnnualSocialSecurityContribution(float companyContribution, float grossSalary, int payments)
    {
        Debug.Assert(companyContribution > grossSalary);
        
        return (companyContribution - grossSalary) * payments;
    }

    private static float AnnualSalary(int payments, PaySheet paySheet)
    {
        return paySheet.NetSalary * payments;
    }
}