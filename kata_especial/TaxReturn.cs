namespace kata_especial;

public enum Region
{
    Andalucia, Aragon, Asturias, Baleares, Canarias, Cantabria, Castilla_La_Mancha, Castilla_Y_Leon, Cataluña,
    Extremadura, Galicia, La_Rioja, Madrid, Murcia, Navarra, Pais_Vasco, Comunidad_Valenciana
}

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

    public bool IsRentDeductible(Region region) => _salary.GrossIncome >= DeductibleRentIncome(region);

    private float DeductibleRentIncome(Region region)
    {
        return region switch
        {
            Region.Andalucia => 19000.00f,
            Region.Aragon => 19000.00f,
            Region.Asturias => 19000.00f,
            Region.Baleares => 19000.00f,
            Region.Canarias => 19000.00f,
            Region.Cantabria => 19000.00f,
            Region.Castilla_La_Mancha => 19000.00f,
            Region.Castilla_Y_Leon => 19000.00f,
            Region.Cataluña => 19000.00f,
            Region.Extremadura => 19000.00f,
            Region.Galicia => 19000.00f,
            Region.La_Rioja => 19000.00f,
            Region.Madrid => 19000.00f,
            Region.Murcia => 19000.00f,
            Region.Navarra => 19000.00f,
            Region.Pais_Vasco => 19000.00f,
            Region.Comunidad_Valenciana => 19000.00f,
            _ => 0.00f
        };
    }
}