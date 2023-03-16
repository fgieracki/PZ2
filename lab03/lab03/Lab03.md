# Laboratorium 03: Praca z kolekcjami
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z metodami programowania przy użyciu kolekcji w języku C#. W tym celu należy wczytać plik zawierający dane zakodowane w formacie JSON a następnie dokonać na nich szeregu operacji.

1. [1 punkt] Wczytaj dane z pliku favorite-tweets.jsonl Po wczytaniu poszczególne tweety powinny znajdować się w osobnych obiektach a obiekty na liście.  Możesz dowolnie modyfikować strukturę pliku, ale nie modyfikuj danych poszczególnych tweetów. https://home.agh.edu.pl/~thachaj/l/favorite-tweets.jsonl

2. [1 punkt] Napisz funkcję, który pozwoli na przekonwertowanie wczytanych w punkcie 1 danych do formatu XML. Funkcja ma pozwalać zarówno na zapis do pliku w formacie XML danych o tweetach jak i wczytanie tych danych z pliku.    

3. [1 punkt] Napisz funkcję sortujące tweety po nazwie użytkowników jak i funkcję sortującą użytkowników po dacie utworzenie tweetu.

4. [1 punkt] Wypisz najnowszy i najstarszy tweet znaleziony względem daty jego utworzenia.

5. [1 punkt] Stwórz słownik, który będzie indeksowany po username i będzie przechowywał jako listę tweety użytkownika o danym username.

6. [1 punkt] Oblicz częstość występowania słów, które w treści tweetów (w polu TEXT).

7. [2 punkty] Znajdź i wypisz 10 najczęściej występujących w tweetach wyrazów o długości co najmniej 5 liter.

8. [2 punkty] Policz IDF dla wszystkich słów w tweetach zgodnie z definicją podaną http://www.tfidf.com/ Posortuj IDF malejąco i wypisz 10 wyrazów o największej wartości IDF.

Powodzenia!
