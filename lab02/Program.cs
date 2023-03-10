// See https://aka.ms/new-console-template for more information

using lab02;

class MainClass
{
    static public void Main(string[] args)
    {
        OsobaFizyczna osoba = new OsobaFizyczna();
        osoba.Imie = "Jan";
        osoba.Nazwisko = "Kowalski";
        osoba.DrugieImie = "Janusz";
        osoba.Pesel = "12345678901";
        osoba.NumerPaszportu = "123456789";
        

        Console.WriteLine(osoba.ToString());
    }
}





