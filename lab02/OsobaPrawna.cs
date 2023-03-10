namespace lab02;

class OsobaPrawna : PosiadaczRachunku
{
    private string _nazwa;
    public string Nazwa
    {
        get { return _nazwa; }
    }

    private string _siedziba;
    public string Siedziba
    {
        get { return _siedziba; }
    }
    
    
    public override string ToString()
    {
        return "Osoba prawna: " + _nazwa + " " + _siedziba;
    }

    public OsobaPrawna(string nazwa, string siedziba)
    {
        this._nazwa = nazwa;
        this._siedziba = siedziba;
    }
}