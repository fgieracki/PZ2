# Laboratorium 04: LINQ
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z zastosowaniem LINQ do obsługi danych w kolekcjach. W celu realizacji laboratorium należy wczytać pliki zawierające dane zakodowane w formacie CSV a następnie dokonać na nich szeregu operacji.

1. [3 punkty] odwzoruj rekordy danych z plików regions.csv, territories.csv, employee_territories.csv, employees.csv przy pomocy odpowiednich klas. Dla uproszczenia uznaj, że każde pole jest typu String. Wczytaj wszystkie dane do czterech kolekcji typu List zawierających obiekty tych klas. 

Wygodnym sposobem wczytania może być stworzenie uniwersalnej klasy wczytującej, która przy wczytywaniu rekordów będzie korzystać z metody, do której przekazywany będzie delegat tworzący obiekt odpowiedniej klasy, np.:

```cs

class wczytywacz<T>
{
    public List<T> wczytajListe(String path, Func<String[], T> generuj)
    {
        //...
    }
}

```

Przykładowe wywołanie:

```cs

wczytywacz<OrderDetails> od = new wczytywacz<OrderDetails>();
List<OrderDetails>lOrderDetailss = od.wczytajListe("c:\\projekt04\\cvs\\orders_details.csv",
    x => new OrderDetails(x[0], x[1], x[2], x[3], x[4]));

```

Gdzie OrderDetails jest konstruktorem klasy, x to tablica String ze sparsowanymi polami rekordów. Powyższy sposób to tylko sugestia - dane proszę wczytać w dowolny sposób.

Po wczytaniu wielokrotnie będziemy wybierać dane z list przy pomocy LINQ i wypisywać rekordy do konsoli. W niektórych przypadkach lista będzie już gotowa i nie będzie trzeba dokonywać na niej żadnej selekcji a jedynie wypisanie. W wypadku wypisywania danych pracownika można zwrócić np. jego nazwisko albo identyfikator. W wypadku pozostałych kolekcji proszę zwracać pole opisowe (nie identyfikator).

2. [1 punkt] wybierz nazwiska wszystkich pracowników.

3. [1 punkt] wypisz nazwiska pracowników oraz dla każdego z nich nazwę regionu i terytorium gdzie pracuje. Rezultatem kwerendy LINQ będzie "płaska" lista, więc nazwiska mogą się powtarzać (ale każdy rekord będzie unikalny).

4. [1 punkt] wypisz nazwy regionów oraz nazwiska pracowników, którzy pracują w tych regionach, pracownicy mają być zagregowani po regionach, rezultatem ma być lista regionów z podlistą pracowników (odpowiednik groupjoin).

5. [1 punkt] wypisz nazwy regionów oraz liczbę pracowników w tych regionach.

6. [3 punkty] wczytaj do odpowiednich struktur dane z plików orders.csv oraz orders_details.csv. Następnie dla każdego pracownika wypisz liczbę dokonanych przez niego zamówień, średnią wartość zamówienia oraz maksymalną wartość zamówienia.

Schemat danych:
![link](schemat.jpeg)

Powodzenia!
