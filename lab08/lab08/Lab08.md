# Laboratorium 08: SQLite
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z działaniem funkcji pozwalających na bezpośrednią komunikację z bazą danych SQLite. Po wykonaniu wszystkich poleceń powinien powstać program, który pozwala na wczytanie danych z pliku CSV do tabeli w bazie SQLite oraz wyświetla te dane. Ta tabela ma zostać utworzona automatycznie na podstawie danych, które zawarte są w pliku. Przykład pliku:


```cs
pole1,pole2,pole3
1,abc,4
3,dxx,
5,asdaa,5.6
7,,0.12
```

Powyższy plik to struktura danych z trzema kolumnami o nazwach pole1, pole2 oraz pole3 - kolumn w tabeli jest dokładnie tyle, ile kolumn w nagłówku (headerze) pliku. Pierwsza kolumna jest typu integer, druga typu text, trzecia typu real - należy to wywnioskować na podstawie wartości w pliku. Druga i trzecia kolumna może zawierać wartości null - brak wpisanej w danej kolumnie wartości (pusty napis) powinien być zinterpretowany jako null. Wartości kolumny pole1: 1, 3, 5, 7; wartości kolumny pole2: abc, dxx, asdaa, NULL; wartości kolumny pole3: 4,NULL,5.6,0.12.

Instalcja pakietu Sqlite

```cs

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

```

może wymagać dodanie do głównego katalogu projektu pliku Nuget.config:


```cs

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
      <clear /> <!-- (optional) this is for clear sources like default Offline repo -->
      <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>


```

Laboratorium składa się z kilku podpunktów - każdy przetestuj przed pokazaniem go prowadzącemu.

1. [3 punkty] Napisz metodę wczytującą dane z pliku CSV do dowolnej struktury danych (na przykład na List<List<String>>). Metoda ma zwrócić tą strukturę danych oraz informację o nazwach kolumn - nazwy kolumn proszę wczytać z headera pliku. Metoda jako argument ma przyjmować nazwę pliku csv oraz separator dzielący od siebie poszczególne wartości w kolumnach. Zakładamy, że ten separator nie występuje nigdzie jako wartość kolumny, na przykład, jeśli separatorem jest przecinek, to przecinek nie występuje w kolumnach z napisami.

2. [2 punkty] Napisz metodę, która jako parametr pobiera dane zwrócone przez metodę z punktu 1. Metoda na podstawie tych danych ma zwracać typy danych dla poszczególnych kolumn oraz czy kolumna może przyjmować wartości NULL czy też nie. Zakładamy, że jeśli kolumna nigdy nie ma wartości NULL, to nie może przyjmować wartości NULL. Jeżeli wszystkie pola tej kolumny można zrzutować na int, kolumna jest typu INTEGER, jeżeli kolumna nie jest typu INTEGER a wszystkie jej pola można zrzutować na double, to jest typu REAL. W pozostałym przypadku kolumna jest typu TEXT.

3. [2 punkty] Napisz metodę, która jako parametry przyjmuje dane zwrócone przez metodę z punktu 2, nazwę tabeli do utworzenia oraz obiekt klasy SqliteConnection. Metoda na podstawie danych ma utworzyć w bazie odpowiednią tabelę (o zdanych nazwach kolumn i typach) i nazwie zgodnej z przekazaną. Połączenie z bazą przekazywane jest w obiekcie SqliteConnection.

4. [2 punkty] Napisz metodę, która jako parametry przyjmuje dane, które mają znaleźć się w tabeli (dane zostały wczytane metodą z punktu 1), nazwę tabeli oraz obiekt klasy SqliteConnection. Metoda ma wypełnić tabelę utworzoną w punkcie 3 tymi danymi.

5. [1 punkt] Napisz metodę, która jako parametr przyjmuje nazwę tabeli oraz obiekt klasy SqliteConnection. Metoda przy pomocy kwerendy SELECT ma wypisać do konsoli wszystkie dane, które znajdują się w tej tabeli. Proszę wypisać również nazwy kolumn.

Powodzenia! ⚆ _ ⚆

