# Laboratorium 09: Podstawy przetwarzania obrazów
## Programowanie zaawansowane 2

- Maksymalna liczba punktów: 10

- Skala ocen za punkty:
    - 9-10 ~ bardzo dobry (5.0)
    - 8 ~ plus dobry (4.5)
    - 7 ~ dobry (4.0)
    - 6 ~ plus dostateczny (3.5)
    - 5 ~ dostateczny (3.0)
    - 0-4 ~ niedostateczny (2.0)

Celem laboratorium jest zapoznanie z podstawami przetwarzania obrazów na przykładzie C#. Proszę zaimplementować wszystkie polecenia jako operacje wykonywane na poszczególnych pikselach bez użycia gotowych funkcji, które od razu mogą implementować np. filtr medianowy. Przygotuj kod testujący każdą metodę.

Instalacja pakietu nuget ImageSharp:

```cs

dotnet add package SixLabors.ImageSharp

```

Przykład użycia ImageSharp do wczytania obrazu, operacji na poszczególnych pikselach oraz zapisania obrazu.

```cs

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

using (Image<Rgb24> image = Image.Load<Rgb24>("lena.png")) 
{
    // klon obrazka - pracujemy teraz na kopii danych
    Image<Rgb24>my_clone = image.Clone();
    // pętla po wszystkich pikselach
    for (int a = 0; a < image.Width; a++)
        for (int b = 0; b < image.Height; b++)
        {
            // pobranie składników RGB 
            byte R = image[a,b].R;
            byte G = image[a,b].G;
            byte B = image[a,b].B;
            // zmiana RGB na BGR
            my_clone[a,b] = new Rgb24(B, G, R);
        }
    //zapisanie obrazków
    image.Save("test.png");
    my_clone.Save("test2.png");           
}

```

Załóżmy, że zawsze pracujemy na obrazach klasy Image<Rgb24>.

1. [2 punkty] Napisz metodę, która przekształci obraz wejściowy na obraz w odcieniach szarości. Aby dokonać konwersji obrazu na obraz w odcieniu szarości wykorzystaj "Average Method" [link](https://www.dynamsoft.com/blog/insights/image-processing/image-processing-101-color-space-conversion/).

2. [3 punkty] Zaimplementuj filtr medianowy, parametry metody to obraz oraz rozmiar okna filtra medianowego (szerokość, wysokość). Szerokość i wysokość muszą być wartościami nieparzystymi. Zasada działania filtra medianowego można znaleźć np. na stronie 6: [link](https://www.cs.auckland.ac.nz/courss/compsci373s1c/PatricesLectures/Image%20Filtering.pdf)
3. [2 punkty] Zaimplementuj filtr maksymalny, minimalny, uśredniający. Parametry metody to obraz oraz rozmiar okna filtra (szerokość, wysokość). Szerokość i wysokość muszą być wartościami nieparzystymi. Filtry te działą na tych samych zasadach jak filtr medianowy (również używają okna), ale zamiast brać pod uwagę medianę używają odpowiednio wartości maksymlanej, minimalnej lub średniej w oknie.
4. [3 punkty] Zaimplementuj filtr konwolucyjny, parametry metody to obraz, dwuwymiarowa tablica jądra filtru (kernel). Szerokość i wysokość kernela muszą być wartościami nieparzystymi. Działanie filtra wytłumaczone jest na stronie 36 [link](https://www.cs.auckland.ac.nz/courss/compsci373s1c/PatricesLectures/Image%20Filtering.pdf). Przetestuj działanie filtra używając kerneli z: [link](https://en.wikipedia.org/wiki/Kernel_(image_processing))

Powodzenia! (▰˘◡˘▰)