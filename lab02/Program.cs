// See https://aka.ms/new-console-template for more information

using lab02;

class MainClass
{
    static public void Main(string[] args)
    {
        OsobaFizyczna osoba1 = new OsobaFizyczna();
        osoba1.Imie = "Jan";
        osoba1.Nazwisko = "Kowalski";
        osoba1.DrugieImie = "Janusz";
        osoba1.Pesel = "12345678901";
        osoba1.NumerPaszportu = "123456789";
        
        OsobaFizyczna osoba2 = new OsobaFizyczna(
            "Adam", 
            "Nowak", 
            "Janz", 
            "12345678901", 
            "123456789"
        );
        
        OsobaFizyczna osoba3 = new OsobaFizyczna(
            "Kacper", 
            "Testowy", 
            "Filip", 
            "12345678901", 
            "123456789"
        );

        OsobaPrawna osoba4 = new OsobaPrawna("Firma", "Warszawa");

        List<PosiadaczRachunku> posiadacz1 = new List<PosiadaczRachunku>();
        posiadacz1.Add(osoba1);
        RachunekBankowy rachunek1 = new RachunekBankowy(
            "12345678901",
            10000,
            true,
            posiadacz1
        );
        
        List<PosiadaczRachunku> posiadacz2 = new List<PosiadaczRachunku>();
        posiadacz2.Add(osoba2);
        posiadacz2.Add(osoba3);
        
        RachunekBankowy rachunek2 = new RachunekBankowy(
            "123456789012",
            5000,
            false,
            posiadacz2
        );
        
        RachunekBankowy.DokonajTransakcji(
            rachunek1,
            rachunek2,
            1000,
            "cukierki");
        
        RachunekBankowy.DokonajTransakcji(
            null,
            rachunek2,
            1000,
            "wplata");

        try
        {
          RachunekBankowy.DokonajTransakcji(
              rachunek2,
              rachunek1,
              100000,
              "za duzy :D");  
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        try
        {
            RachunekBankowy.DokonajTransakcji(
                null,
                null,
                100000,
                "2 nulle");  
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        try
        {
            osoba1.Pesel = "1234567890";
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            osoba1.Pesel = "fffffffffff";
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        rachunek1+=osoba4;
        try
        {
            rachunek1+=osoba4;
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            rachunek1-=osoba3;
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        RachunekBankowy.DokonajTransakcji(
            rachunek1,
            rachunek2,
            100000,
            "cukierki");
        
        Console.WriteLine(rachunek1.ToString());
        Console.WriteLine(rachunek2.ToString());
        
        Console.WriteLine(osoba1.ToString());
    }
    
}





