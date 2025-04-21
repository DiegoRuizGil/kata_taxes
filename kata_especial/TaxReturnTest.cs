namespace kata_especial;

public class TaxReturnTest
{
    /*
     * - porcetanje real IRPF año anterior
     * - trabajador asalariado:
     *  - ingresos:
     *      - sueldo bruto en las nominas
     *  - IRPF retenido
     *
     * clase TaxReturn (Salary)
     *  X metodo: cantidad de impuestos año anterior (IRPF retenido)
     *  X metodo: porcentaje real IRPF año anterior
     *  - metodos: sale a pagar y a devolver
     *  - metodo: obligado o no a presentar (22.000)
     *  - metodo: deducir o no el alquiler (depende de la comunidad autonoma, ej: Andalucia, 19.000)
     * 
     */

    [Test]
    public void PreviousYearWithholdingTaxes()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(1800.00f, 0.15f, 1800.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.LastYearWithholdingTaxes, Is.EqualTo(3240.00f));
    }

    [Test]
    public void ActualTaxesFromPreviousYear()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(2400.00f, 0.15f, 2400.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.ActualTaxes, Is.EqualTo(3617.76f).Within(0.01f));
    }
}