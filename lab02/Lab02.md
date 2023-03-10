# Laboratorium 02: Programowanie obiektowe w języku C# .NET Framework Core 7.0.
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z metodami programowania obiektowego w języku C#. W tym celu zbudujemy uproszczony model obsługujący transakcje bankowe. Model będzie składał się z rachunków bankowych, których właścicielami będą osoby fizyczne lub/i osoby prawne. Każdy rachunek będzie musiał mieć co najmniej jednego właściciela. Transakcje bankowe będą mogły odbywać się pomiędzy rachunkami (bezgotówkowe przelewy) lub będą wpłatą lub wypłatą funduszy z rachunku.

1. [1 punkt] Stwórz publiczną, abstrakcyjną klasę PosiadaczRachunku w której będzie znajdować się przeciążenie metody String ToString() z klasy object. Metoda przeciążająca ma być również abstrakcyjna.

2. [1 punkt] Stwórz klasę OsobaFizyczna, która będzie dziedziczyć z klasy PosiadaczRachunku. Klasa ma zawierać pola: imie, nazwisko, drugieImie, PESEL, numerPaszportu. Pola mają być prywatne a dostęp do nich będzie odbywał się przez publiczne właściwości (properties).  Metoda String ToString() ma zwracać napis informujący, że jest to osoba fizyczna oraz imie i nazwisko.

3. [1 punkt] Stwórz konstruktor do klasy OsobaFizyczna, który będzie pobierał wartości do wszystkich pól tej klasy. Jeżeli w konstruktorze równocześnie podane zostanie, że PESEL oraz numerPaszportu jest równy null, ma zostać rzucony wyjątek.

```cs

//przykładowe rzucenie wyjątku
throw new Exception("PESEL albo numer paszportu muszą być nie null");
    
```

4. [1 punkt] Stwórz klasę OsobaPrawna, która będzie dziedziczyć z klasy PosiadaczRachunku. Klasa ma zawierać pola: nazwa, siedziba. Pola mają być prywatne a dostęp do nich będzie odbywał się przez publiczne właściwości (properties). Właściwości mają pozwalać jedynie na odczyt wartości (a nie na ich zmianę). Metoda String ToString() ma zwracać napis informujący, że jest to osoba prawna oraz nazwa i siedziba.

5. [1 punkt] Stwórz konstruktor do klasy OsobaPrawna, który będzie pobierał wartości do wszystkich pól tej klasy.

6. [1 punkt] Stwórz klasę RachunekBankowy, która będzie miała pola: numer (typu String), stanRachunku (typu Decimal), czyDozwolonyDebet (typu bool), listę posiadaczeRachunku:

```cs

List<PosiadaczRachunku>_PosiadaczeRachunku = new List<PosiadaczRachunku>();

```

Podstawowe operacje na liście (przydadzą się w dalszej części laboratorium):

```cs

//dodawnie
lo.Add(o);
//sprawdzenie, czy lista ma element
if (lo.Contains(o))
    //usuwanie
    lo.Remove(o);
//liczba elementów na liście
Console.WriteLine(lo.Count);

```

Pola mają być prywatne a dostęp do nich będzie odbywał się przez publiczne właściwości (properties).

7. [1 punkt] Stwórz konstruktor do klasy RachunekBankowy, który będzie pobierał wartości do wszystkich pól tej klasy. Konstruktor musi sprawdzać, czy lista posiadaczy rachunku zawiera co najmniej jedną pozycję (jeśli nie ma rzucać wyjątek).

8. [1 punkt] Stwórz klasę Transakcja, która będzie miała pola: rachunekZrodlowy oraz rachunekDocelowy (typu RachunekBankowy), kwota (typu Decimal), opis (typu string). Pola mają być prywatne a dostęp do nich będzie odbywał się przez publiczne właściwości (properties).

9. [1 punkt] Stwórz konstruktor do klasy Transakcja, który będzie pobierał wartości do wszystkich pól tej klasy. Konstruktor musi sprawdzać, czy rachunek docelowy i źródłowy jest różny od null (jeśli nie, ma rzucać wyjątek).

10. [1 punkt] Do klasy RachunekBankowy dodaj listę transakcji:

```cs

List<Transakcja> _Transakcje = new List<Transakcja>();

```

Do klasy RachunekBankowy dodaj publiczną statyczną metodę DokonajTransakcji. Metoda ma pobierać jako parametry rachunek źródłowy, rachunek docelowy, kwotę oraz opis. Jeżeli:
- kwota jest ujemna lub,
- oba rachunki są równe null lub,
- rachunek źródłowy nie pozwala na debet (czyDozwolonyDebet == false), a kwota transakcji przekroczy stanRachunku,

metoda ma rzucić wyjątek.

- jeżeli rachunek źródłowy jest równy null, to zakładamy, że jest to wpłata gotówkowa. Do stanRachunku rachunku docelowego dodajemy kwotę transakcji i tworzymy nowy obiekt klasy Transakcja, do którego przekazujemy parametry wywołania metody DokonajTransakcji. Tak stworzony obiekt klasy Transakcja dodajemy do listy _Transakcje obiektu rachunku docelowego.
- jeżeli rachunek docelowy jest równy null, to zakładamy, że jest to wypłata gotówkowa. Od stanRachunku rachunku źródłowego odejmujemy kwotę transakcji i tworzymy nowy obiekt klasy Transakcja, do którego przekazujemy parametry wywołania metody DokonajTransakcji. Tak stworzony obiekt klasy Transakcja dodajemy do listy _Transakcje obiektu rachunku źródłowego.
- jeżeli żadne z poprzednich nie zachodzi, to zakładamy, że jest to przelew. Od stanRachunku rachunku źródłowego odejmujemy kwotę transakcji a do stanRachunku rachunku docelowego dodajemy kwotę transakcji i tworzymy nowy obiekt klasy Transakcja, do którego przekazujemy parametry wywołania metody DokonajTransakcji. Tak stworzony obiekt klasy Transakcja dodajemy do listy _Transakcje obiektu rachunku źródłowego i obiektu rachunku docelowego.

### ❤❤❤ Zadanie dodatkowe (za rozwiązanie dodatkowa ocena 5.0) ❤❤❤


 Po wykonaniu wszystkich poleceń obowiązkowych zrealizuj wszystkie poniższe punkty aby otrzymać dodatkową ocenę bardzo dobrą:
 - W klasie Transakcja dodaj przeciążenie metody String  ToString() z klasy object, która zwróci napis z numerem rachunku źródłowego i docelowego, kwotę oraz opis.
 - W klasie RachunekBankowy dodaj możliwość dodawania i usuwania posiadaczy rachunku przy pomocy przeciążenia operatorów + oraz -. Jeżeli:
    - liczba posiadaczy spadłaby poniżej 1 lub,
    - posiadacz już jest na liście posiadaczy rachunku lub,
    - posiadacza nie ma na liście posiadaczy rachunku

    metoda ma rzucać wyjątek.

- W klasie RachunekBankowy dodaj przeciążenie metody String ToString() z klasy object, która zwróci napis z numerem rachunku, stan rachunku oraz wszystkich posiadaczy oraz wszystkie transakcje tego rachunku.
- Zabezpiecz klasę OsobaFizyczna w ten sposób, aby przy pomocy metod publicznych (konstruktora oraz właściwości (properties)) nie dało się podstawić PESELA o innej liczbie cyfr niż 11 lub o wartości null. 

Powodzenia! ʘ‿ʘ