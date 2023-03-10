namespace lab02;

public class RachunekBankowy
{
    private string _numer;
    private Boolean _czyDozwolonyDebet;
    private Decimal _stanRachunku;
    private List<PosiadaczRachunku> _posiadaczeRachunku = new List<PosiadaczRachunku>();
    private List<Transakcja> _transakcje = new List<Transakcja>();

    public static void DokonajTransakcji(
        RachunekBankowy rachunekZrodlowy, 
        RachunekBankowy rachunekDocelowy,
        Decimal kwota,
        String opis)
    {
        if(kwota <= 0)
            throw new Exception("Kwota musi być większa od 0");
        
        if(rachunekZrodlowy == null && rachunekDocelowy == null)
            throw new Exception("Rachunek zrodlowy i docelowy nie mogą być jednocześnie puste");
        
        if(rachunekZrodlowy != null && rachunekZrodlowy.CzyDozwolonyDebet == false && rachunekZrodlowy.StanRachunku < kwota)
            throw new Exception("Nie można dokonać transakcji, brak środków na koncie");

        if (rachunekZrodlowy == null)
        {
            rachunekDocelowy.StanRachunku += kwota;
            Transakcja transakcja = new Transakcja(
                rachunekZrodlowy,
                rachunekDocelowy,
                kwota,
                opis);
            rachunekDocelowy._transakcje.Add(transakcja);
        }
        
        else if (rachunekDocelowy == null)
        {
            rachunekZrodlowy.StanRachunku -= kwota;
            Transakcja transakcja = new Transakcja(
                rachunekZrodlowy,
                rachunekDocelowy,
                kwota,
                opis);
            rachunekZrodlowy._transakcje.Add(transakcja);
        }
        else
        {
            rachunekZrodlowy.StanRachunku -= kwota;
            rachunekDocelowy.StanRachunku += kwota;
            Transakcja transakcja = new Transakcja(
                rachunekZrodlowy,
                rachunekDocelowy,
                kwota,
                opis);
            
            rachunekZrodlowy._transakcje.Add(transakcja);
            rachunekDocelowy._transakcje.Add(transakcja);
        }
    }
    
    public string Numer
    {
        get { return _numer; }
        set { _numer = value; }
    }
    
    public Decimal StanRachunku
    {
        get { return _stanRachunku; }
        set { _stanRachunku = value; }
    }
    
    public Boolean CzyDozwolonyDebet
    {
        get { return _czyDozwolonyDebet; }
        set { _czyDozwolonyDebet = value; }
    }
    

    public RachunekBankowy(
        string numer,
        decimal stanRachunku, 
        bool czyDozwolonyDebet, 
        List<PosiadaczRachunku> posiadaczeRachunku)
    {
        if (posiadaczeRachunku.Count == 0) 
            throw new Exception("Lista posiadaczy nie może być pusta");
        _posiadaczeRachunku = posiadaczeRachunku;
        _numer = numer;
        _stanRachunku = stanRachunku;
        _czyDozwolonyDebet = czyDozwolonyDebet;
    }

    public List<PosiadaczRachunku> PosiadaczeRachunku
    {
        get { return _posiadaczeRachunku; }
        set { _posiadaczeRachunku = value; }
    }
    
    public static RachunekBankowy operator +(
        RachunekBankowy rachunek, 
        PosiadaczRachunku posiadacz
        ) {
        if (rachunek._posiadaczeRachunku.Contains(posiadacz))
            throw new Exception("Posiadacz już jest na liście");
            
        rachunek._posiadaczeRachunku.Add(posiadacz);
        return rachunek;
    }
    
    public static RachunekBankowy operator -(
        RachunekBankowy rachunek, 
        PosiadaczRachunku posiadacz
        ) {
        if (rachunek._posiadaczeRachunku.Count == 1)
            throw new Exception("Nie można usunąć ostatniego posiadacza rachunku");
        if (!rachunek._posiadaczeRachunku.Contains(posiadacz))
            throw new Exception("Nie można usunąć posiadacza, który nie jest na liście");
        rachunek._posiadaczeRachunku.Remove(posiadacz);
        return rachunek;
    }

    public override string ToString()
    {
        String posiadacze = "";
        foreach(PosiadaczRachunku posiadaczRachunku in _posiadaczeRachunku)
            posiadacze += posiadaczRachunku + "; ";

        String transakcje = "";
        foreach(Transakcja transakcja in _transakcje)
            transakcje += transakcja + "; ";
        
        return $"Numer rachunku: {_numer}, " +
               $"stan rachunku: {_stanRachunku}," +
               $"posiadacze rachunku: [{posiadacze}]," +
               $"transakcje rachunku: [{transakcje}]";
    }
}