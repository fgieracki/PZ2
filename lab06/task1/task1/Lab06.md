# Laboratorium 06: Programowanie sieciowe w oparciu o gniazda TCP/IP
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z programowaniem sieciowym z zastosowaniem gniazd TCP/IP. Proszę wykonać następujące programy.

1. [4 punkty] Proszę napisać program serwera oraz program klienta. Serwer będzie oczekiwał na połączenie jednego klienta. Klient po połączeniu z serwerem ma wysłać na serwer wpisaną z klawiatury tekstową wiadomość. Jeżeli długość wiadomości przekroczy 1024 bajty proszę ograniczyć ją do 1024 bajtów. Serwer ma odebrać wiadomość i wypisać ją w postaci zdekodowanego napisu (String-a, a nie tablicy bajtów) do konsoli. Następnie ma wysłać do klienta wiadomość "odczytalem: " i przesłany przez klienta napis. Jeżeli długość wiadomości przekroczy 1024 bajty proszę ograniczyć ją do 1024 bajtów. Po przesłaniu program serwera ma zakończyć działanie. Klient ma odebrać wiadomość od serwera, wypisać ją na ekran w postaci napisu (String) i zakończyć działanie.
2. [2 punkty] Proszę napisać programy, które będą działały analogicznie jak programy z punktu 1 z tą różnicą, że długość wiadomości nie będzie ograniczona do 1024 bajtów. Proponowane rozwiązanie: załóżmy, że zarówno klient jak i serwer będzie wysyłał na początku 4-bajtową wiadomość, w której prześle rozmiar (jako zakodowany do bajtów int) kolejnej wiadomości, która będzie zawierać właściwe dane.
3. [4 punkty] Napisz program o architekturze klient - serwer. Serwer ma oczekiwać na połączenie jednego klienta i ma "pamiętać" w zmiennej "my_dir" ścieżkę do swojego katalogu startowego. Klient będzie wysyłał na serwer wiadomości tekstowe wczytane z klawiatury a następnie odbierał i wypisywał wiadomości z serwera. Obsługiwane wiadomości:
    - "!end" - zakończ zarówno program serwera jak i klienta.
    - "list" - prześlij do klienta nazwy wszystkich katalogów i plików znajdujących się na ścieżce zmiennej "my_dir" (bez rekurencyjnego wchodzenia do katalogów).
    - "in \[nazwa\]" - jeżeli "nazwa" jest podkatalogiem na ścieżce "my_dir" proszę zmodyfikować ścieżkę tak, aby wskazywała na ten podkatalog i przesłać do klienta nazwy wszystkich katalogów i plików znajdujących się na ścieżce zmiennej "my_dir" (bez rekurencyjnego wchodzenia do katalogów). Jeżeli "nazwa" nie jest podkatalogiem proszę przesłać do klienta wiadomość "katalog nie istnieje". Jeżeli "nazwa" to ".." proszę spróbować wejść do katalogu nadrzędnego i obsłużyć jego odczyt w analogiczny sposób jak dla każdego innego napisu.
    - Każdy inny przypadek - serwer ma przesłać do klienta wiadomość "nieznane polecenie".
    Nieznaną długość bajtowej wiadomości proszę obsłużyć analogicznie jak w zadaniu numer 2. 

Powodzenia! (⊃｡•́‿•̀｡)⊃ 