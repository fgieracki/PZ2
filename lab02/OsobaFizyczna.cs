namespace lab02;

class OsobaFizyczna : PosiadaczRachunku
{
    private string _imie;
    public string Imie
    {
        get { return _imie; }
        set { _imie = value; }
    }
    
    private string _nazwisko;
    public string Nazwisko
    {
        get { return _nazwisko; }
        set { _nazwisko = value; }
    }

    private string _drugieImie;
    public string DrugieImie
    {
        get { return _drugieImie; }
        set { _drugieImie = value; }
    }
        
    private string _pesel;
    public string Pesel
    {
        get { return _pesel; }
        set
        {
            if(value == null)
                throw new Exception("Pesel nie moze byc pusty");
            
            if(value != null && value.Length != 11)
                throw new Exception("Pesel musi mieć 11 znaków");
            
            if(!value.All(char.IsDigit))
                throw new Exception("Pesel musi składać się tylko z cyfr");
            
            _pesel = value;
        }
    }

    private string _numerPaszportu;
    public string NumerPaszportu
    {
        get { return _numerPaszportu; }
        set { _numerPaszportu = value; }
    }


    public OsobaFizyczna()
    {
    }

    public OsobaFizyczna(string imie, string nazwisko, string drugieImie, string pesel, string numerPaszportu)
    {
        if(pesel == null && numerPaszportu == null)
            throw new Exception("Pesel i numer paszportu nie mogą być jednocześnie puste");
        
        if(pesel != null && pesel.Length != 11)
            throw new Exception("Pesel musi mieć 11 znaków");
        
        if(!pesel.All(char.IsDigit))
            throw new Exception("Pesel musi składać się tylko z cyfr");

        this._imie = imie;
        this._nazwisko = nazwisko;
        this._drugieImie = drugieImie;
        this._pesel = pesel;
        this._numerPaszportu = numerPaszportu;
    }

    public override string ToString()
    {
        return "Osoba fizyczna: " + _imie + " " + _nazwisko;
    }
}