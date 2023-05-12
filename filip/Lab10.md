# Laboratorium 10: Podstawy ASP.NET core MVC - kontrolery i widoki
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z podstawami pisania aplikacji webowych przy pomocy ASP.NET core MVC przy wykorzystaniu kontrolerów i widoków. Aplikacja będzie wykorzystywała mechanizm sesji do zapamiętania faktu zalogowania przez użytkownika. Dane wprowadzane do aplikacji będą zapamiętywane w bazie danych SQLite. Hasło w bazie będzie przechowywane w postaci skrótu (hash-u).

1. [4 punktów] Stwórz nową aplikację ASP.NET core MVC:
- Stwórz kontroler (albo użyj istniejącego w szablonie kontrolera) i dodaj do niego metodę obsługującą sprawdzanie prawidłowości wpisanego hasła i loginu. Stwórz dla tej metody odpowiedni widok Razor, który będzie zawierał formularz z polami, które będą pobierały login i hasło. Para hasło i login mogą być na razie wpisane w kodzie kontrolera na potrzeby testów (w poleceniu 2 zastąpimy je poprzez zapisanie loginu i hasła w bazie). 
- Jeśli login i hasło zostały wprowadzone prawidłowo, po zatwierdzeniu formularza powinien zostać wyświetlony widok Razor informujący o fakcie zalogowania. Na widoku informującym o fakcie zalogowania powinien być formularz umożliwiający wylogowanie. Fakt zalogowania powinien być zapamiętany w sesji. 
- Jedynie zalogowani użytkownicy powinni mieć dostęp do innych zasobów aplikacji poza stroną logowania. "Zasoby aplikacja" to metody kontrolera, widoki Razor i strony Razor. 
- Jeżeli ktoś nie jest zalogowany a wpisze adres URL jakiegoś zasobu powinien być przekierowywany na stronę logowania.
- Proszę tak zmodyfikować plik _Layout.cshtml, aby menu znajdująca się tagu <header> zawierało linki do istniejących zasobów aplikacji. Niezalogowany użytkownik powinien widzieć jedynie link do strony logowania.

Poniższy kod dodany do Program.cs powoduje, że jeżeli użytkownik wpisze adres nieistniejącego zasobu zostaje przekierowany do zasobu "/IO/Logowanie".

```cs

app.Use(async (ctx, next) =>
{
    await next();

    if(ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
    {
        //Re-execute the request so the user gets the error page
        string originalPath = ctx.Request.Path.Value;
        ctx.Items["originalPath"] = originalPath;
        ctx.Request.Path = "/IO/Logowanie";
        await next();
    }
});

```

2. [2 punkty] Dodaj do aplikacji obsługę bazy danych SQLite. Przy starcie aplikacji mają być tworzone tabele: "loginy" (tabela zawiera informacje o loginie i haśle) oraz "dane" (tabela ma mieć pole tekstowe z danymi). Dodaj klucze główne! Wypełnij obie tabele przykładowymi danymi. Prawidłowość logowania powinna być sprawdzana na podstawie danych, które są w tabeli loginy.

3. [2 punkty] Dodaj metodę kontrolera + widok razor pozwalający na dodawanie nowych danych do tabeli "dane" oraz wyświetlanie rekordów, które się już znajdują w tej tabeli.

4. [2 punkty] Zmodyfikuj aplikację w taki sposób, aby hasła trzymane w tabeli "loginy" były przechowywane jako skróty obliczone algorytmem MD5.

Powodzenia! <(^_^)>
