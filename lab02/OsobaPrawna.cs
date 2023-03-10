namespace lab02;

class OsobaPrawna : PosiadaczRachunku
{
    private string nazwa;
    public string Nazwa
    {
        get { return nazwa; }
    }

    private string siedziba;
    public string Siedziba
    {
        get { return siedziba; }
    }
    
    
    public override string ToString()
    {
        return "Osoba prawna: " + nazwa + " " + siedziba;
    }

    public OsobaPrawna(string nazwa, string siedziba)
    {
        this.nazwa = nazwa;
        this.siedziba = siedziba;
    }
}