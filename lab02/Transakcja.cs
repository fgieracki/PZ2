namespace lab02;

public class Transakcja
{
    private RachunekBankowy rachunekZrodlowy;
    private RachunekBankowy rachunekDocelowy;
    private Decimal kwota;
    private String opis;

    public Transakcja(RachunekBankowy rachunekZrodlowy, RachunekBankowy rachunekDocelowy, decimal kwota, string opis)
    {
        if (this.rachunekZrodlowy == null)
            throw new ArgumentNullException("rachunek zrodlowy nie moze byc pusty");

        if (this.rachunekDocelowy == null)
            throw new ArgumentNullException("rachunek docelowy nie moze byc pusty");

        this.rachunekZrodlowy = rachunekZrodlowy;
        this.rachunekDocelowy = rachunekDocelowy;
        this.kwota = kwota;
        this.opis = opis;
    }


    public RachunekBankowy RachunekZrodlowy
    {
        get => rachunekZrodlowy;
        set => rachunekZrodlowy = value ?? throw new ArgumentNullException(nameof(value));
    }

    public RachunekBankowy RachunekDocelowy
    {
        get => rachunekDocelowy;
        set => rachunekDocelowy = value ?? throw new ArgumentNullException(nameof(value));
    }

    public decimal Kwota
    {
        get => kwota;
        set => kwota = value;
    }

    public string Opis
    {
        get => opis;
        set => opis = value ?? throw new ArgumentNullException(nameof(value));
    }


    public override string ToString()
    {
        return "Transakcja: z " + rachunekZrodlowy + " do " + rachunekDocelowy + ", kwota:  " + kwota + ", opis: " + opis;
    }
}