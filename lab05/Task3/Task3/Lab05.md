# Laboratorium 05: Programowanie współbieżne i synchronizacja (Thread)
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z programowaniem współbieżnym i synchronizacją procesów przy użyciu klasy Thread. Zakładamy, że nie używamy wątków tła (Thread.IsBackground == false). Pamiętaj o sekcjach krytycznych! Proszę wykonać następujące programy.

1. [4 punkty] Napisz program modelujący problem producent-konsument. Program ma uruchomić n wątków generujących dane oraz m wątków pobierających dane. Każdy z wątków ma  przechowywać informację o swoim numerze porządkowym, załóżmy, że są numerowane od 0..n-1 i odpowiednio od 0..m-1. Generowanie i odpowiednio odczytywanie danych przez każdy wątek ma odbywać się w losowych przedziałach czasu, które będą podawane jako parametr dla danego wątku. Generowane dane mają być umieszczane na liście (lub innej strukturze), załóżmy, że dane to obiekty klasy,  które będą miały identyfikator informujący o numerze porządkowym wątku, który je wygenerował. Wątek pobierający dane pobiera i usuwa zawsze pierwszy element ze struktury danych   i "zapamiętuje", jaki był identyfikator wątku producenta, który te dane tam umieścił. Program ma zatrzymywać wszystkie wątki jeśli wciśniemy klawisz q i kończyć swoje działanie. Każdy zatrzymywany wątek ma wypisać ile "skonsumował" danych od poszczególnych producentów,
np. Producent 0 - 4, Producent 1 - 5 itd.

2. [2 punkty] Napisz program, który będzie monitorował w czasie rzeczywistym zmiany zachodzące w wybranym katalogu polegające na usuwaniu lub dodawaniu do niego plików (nie trzeba monitorować podkatalogów). Jeżeli w katalogu pojawi się nowy plik program ma wypisać: "dodano plik [nazwa pliku]" a jeśli usunięto plik "usunięto plik [nazwa pliku]". Program ma się zatrzymywać po wciśnięciu litery "q". Monitorowanie ma być  w osobnym wątku niż oczekiwanie na wciśnięcie klawisza! 

3. [2 punkty] Napisz program, który począwszy od zadanego katalogu będzie wyszukiwał pliki, których nazwa będzie posiadała zadany napis (podnapis, np. makaron.txt posiada "ron"). Wyszukiwanie ma brać pod uwagę podkatalogi. Wyszukiwanie ma odbywać się w wątku. Kiedy wątek wyszukujący znajdzie plik pasujący do wzorca wątek główny ma wypisać nazwę tego pliku do konsoli (wątek wyszukujący ma nie zajmować się bezpośrednio wypisywaniem znalezionych plików do konsoli). 

4. [2 punkty] Napisz program, który uruchomi n wątków i poczeka, aż wszystkie z tych wątków zaczną się wykonywać. Uruchomienie Thread.Start() nie jest równoznaczne z tym, że dany wątek zaczął się już wykonywać. Uznajmy, że wykonanie zaczyna się wtedy, kiedy wątek wykonał co najmniej jedną instrukcje w swoim kodzie. Kiedy wszystkie wątki zostaną uruchomione główny wątek ma o tym poinformować (wypisać informację do konsoli) a następnie zainicjować zamknięcie wszystkich wątków. Po otrzymaniu informacji, że wszystkie wątki zostaną zamknięte, główny program
ma o tym poinformować oraz sam zakończyć działanie. 

Powodzenia!