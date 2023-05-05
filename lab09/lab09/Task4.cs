namespace lab09;

public class Task4
{
    public static void Main(string[] args)
    {
        int[,] filter = new int[3,3]{
            {-1,-1,-1},
            {-1,8,-1},
            {-1,-1,-1}
        };
        int filterX = filter.GetLength(0);
        int filterY = filter.GetLength(1);

        using (Image<Rgb24> image = Image.Load<Rgb24>(@"../../../img.png")) 
        {
            // klon obrazka - pracujemy teraz na kopii danych
            Image<Rgb24>my_clone = image.Clone();
            // pętla po wszystkich pikselach
            for (int x = 0; x < image.Width; x++)
            for (int y = 0; y < image.Height; y++)
            {
                // pobranie składników RGB 
                byte R = image[x,y].R;
                byte G = image[x,y].G;
                byte B = image[x,y].B;
                    
                int sumR = 0;
                int sumG = 0;
                int sumB = 0;
                
                
                for(int i = x-filterX/2; i <= x+filterX/2; i++){
                    for(int j = y-filterY/2; j <= y+filterY/2; j++){
                        if(i < 0 || j < 0 || i >= image.Width || j >= image.Height)
                            continue;
                        sumR += image[i,j].R * filter[i-x+filterX/2,j-y+filterY/2];
                        sumG += image[i,j].G * filter[i-x+filterX/2,j-y+filterY/2];
                        sumB += image[i,j].B * filter[i-x+filterX/2,j-y+filterY/2];
                    }
                }
                
                
                
                if (sumB > 256) sumB %= 256;
                if (sumR > 256) sumR %= 256;
                if (sumG > 256) sumG %= 256;
                if (sumB < 0) sumB = 0;
                if (sumG < 0) sumG = 0;
                if (sumR < 0) sumR = 0;
                
                
                my_clone[x,y] = new Rgb24((byte)sumR, (byte)sumG, (byte)sumB);

                // int average = (R + G + B) / 3;
                // my_clone[a,b] = new Rgb24((byte)average, (byte)average, (byte)average);
            }
            Console.WriteLine("OK");
            //zapisanie obrazków
            my_clone.Save(@"../../../Task4.png");           
        }
    }
}