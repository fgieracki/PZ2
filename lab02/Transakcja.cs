namespace lab02;

public class Transakcja
{
    private RachunekBankowy _rachunekZrodlowy;
    private RachunekBankowy _rachunekDocelowy;
    private Decimal _kwota;
    private String _opis;

    public Transakcja(RachunekBankowy rachunekZrodlowy, RachunekBankowy rachunekDocelowy, decimal kwota, string opis)
    {
        if (rachunekZrodlowy == null && rachunekDocelowy == null)
            throw new Exception("Oba rachunki nie mogą być puste");

        this._rachunekZrodlowy = rachunekZrodlowy;
        this._rachunekDocelowy = rachunekDocelowy;
        this._kwota = kwota;
        this._opis = opis;
    }


    public RachunekBankowy RachunekZrodlowy
    {
        get => _rachunekZrodlowy;
        set => _rachunekZrodlowy = value ?? throw new ArgumentNullException(nameof(value));
    }

    public RachunekBankowy RachunekDocelowy
    {
        get => _rachunekDocelowy;
        set => _rachunekDocelowy = value ?? throw new ArgumentNullException(nameof(value));
    }

    public decimal Kwota
    {
        get => _kwota;
        set => _kwota = value;
    }

    public string Opis
    {
        get => _opis;
        set => _opis = value ?? throw new ArgumentNullException(nameof(value));
    }


    public override string ToString()
    {
        String rachunekZrodlowy = _rachunekZrodlowy == null ? " wpłata " : _rachunekZrodlowy.Numer;
        String rachunekDocelowy = _rachunekDocelowy == null ? " wypłata " : _rachunekDocelowy.Numer;
        return "Transakcja: z " + rachunekZrodlowy + " do " + rachunekDocelowy + ", kwota:  " + _kwota + ", opis: " + _opis;
    }
}