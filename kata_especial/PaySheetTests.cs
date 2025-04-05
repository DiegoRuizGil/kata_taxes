using NUnit.Framework.Constraints;

namespace kata_especial;

public class PaySheetTests
{
    /*
     * nomina:
     *  - (derivado) sueldo neto del trabajador (employee's net salary)
     *  - porcentaje IRPF deducido (15%)
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
        Assert.That(NetSalary(1800.00f, 0.00f), Is.EqualTo(1800.00f));
    }

    [Test]
    public void NetSalaryWithWithholdingTaxRateAt15()
    {
        Assert.That(NetSalary(1800.00f, 0.15f), Is.EqualTo(1530.00f));
    }

    private float NetSalary(float grossSalary, float withholdingTaxRate)
    {
        return grossSalary * (1 - withholdingTaxRate);
    }
}