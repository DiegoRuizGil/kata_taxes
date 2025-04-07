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
        Assert.That(paySheet.AnnualSalary(12), Is.EqualTo(18360.00f));
    }

    [Test]
    public void TotalAnnualEmployerSocialSecurityContribution()
    {
        var paySheet = new PaySheet(1800.00f, 0.00f, 2450.00f);
        Assert.That(paySheet.AnnualSocialSecurityCompanyContribution(12), Is.EqualTo(7800.00f));
    }
}