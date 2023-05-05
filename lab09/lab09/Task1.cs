namespace lab09;

public class Task1
{
    public static void xMain(string[] args)
    {
        using (Image<Rgb24> image = Image.Load<Rgb24>(@"../../../img.png")) 
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
                // my_clone[a,b] = new Rgb24(B, G, R);
                int average = (R + G + B) / 3;
                my_clone[a,b] = new Rgb24((byte)average, (byte)average, (byte)average);
            }
            Console.WriteLine("OK");
            //zapisanie obrazków
            my_clone.Save(@"../../../Task1.png");           
        }

    }
}