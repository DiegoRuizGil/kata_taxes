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
     *  - metodo: cantidad de impuestos año anterior (IRPF retenido)
     *  - metodo: porcentaje real IRPF año anterior
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
        
        Assert.That(taxReturn.WithholdingTaxes, Is.EqualTo(3240.00f).Within(0.01f));
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

    [Test]
    public void TaxReturnIsRefunded()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(2400.00f, 0.15f, 2400.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.IsTaxRefund, Is.True);
    }
    
    [Test]
    public void TaxReturnIsNotRefundable()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(2400.00f, 0.00f, 2400.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.IsTaxRefund, Is.False);
    }
    
    [Test]
    public void TaxReturnIsPayable()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(2400.00f, 0.00f, 2400.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.IsTaxDue, Is.True);
    }
    
    [Test]
    public void TaxReturnIsNotPayable()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(2400.00f, 0.15f, 2400.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.IsTaxDue, Is.False);
    }

    [Test]
    public void RequiredToSubmitTaxReturn()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(2400.00f, 0.15f, 2400.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.RequiredToSubmit, Is.True);
    }
    
    [Test]
    public void NotRequiredToSubmitTaxReturn()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(1800.00f, 0.15f, 1800.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.RequiredToSubmit, Is.False);
    }

    [Test]
    public void RentIsDeductible()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(1584.00f, 0.15f, 1800.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.IsRentDeductible(Region.Andalucia), Is.True);
    }
    
    [Test]
    public void RentIsNotDeductible()
    {
        int payments = 12;
        var paySheets = new PaySheet[payments];
        for (var i = 0; i < payments; i++)
            paySheets[i] = new PaySheet(1582.00f, 0.15f, 1800.00f);

        var salary = new Salary(paySheets);
        var taxReturn = new TaxReturn(salary);
        
        Assert.That(taxReturn.IsRentDeductible(Region.Andalucia), Is.False);
    }
}