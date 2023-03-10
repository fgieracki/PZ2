namespace lab02;

class OsobaFizyczna : PosiadaczRachunku
{
    private string imie;
    public string Imie
    {
        get { return imie; }
        set { imie = value; }
    }
    
    private string nazwisko;
    public string Nazwisko
    {
        get { return nazwisko; }
        set { nazwisko = value; }
    }

    private string drugieImie;
    public string DrugieImie
    {
        get { return drugieImie; }
        set { drugieImie = value; }
    }
        
    private string pesel;
    public string Pesel
    {
        get { return pesel; }
        set { pesel = value; }
    }

    private string numerPaszportu;
    public string NumerPaszportu
    {
        get { return numerPaszportu; }
        set { numerPaszportu = value; }
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

        this.imie = imie;
        this.nazwisko = nazwisko;
        this.drugieImie = drugieImie;
        this.pesel = pesel;
        this.numerPaszportu = numerPaszportu;
    }

    public override string ToString()
    {
        return "Osoba fizyczna: " + imie + " " + nazwisko;
    }
}