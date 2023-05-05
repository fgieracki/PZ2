namespace lab09;

public class Task2
{
    public static void sMain(string[] args)
    {
        int filterX = 7;
        int filterY = 7;
     
        if(args.Length >= 2){
            filterX = int.Parse(args[0]);
            filterY = int.Parse(args[1]);
        }

        if (filterX % 2 == 0 || filterY % 2 == 0)
        {
            Console.WriteLine("Wrong input");
            return;
        }
        
        using (Image<Rgb24> image = Image.Load<Rgb24>(@"../../../noise.png")) 
        {
            // klon obrazka - pracujemy teraz na kopii danych
            Image<Rgb24>my_clone = image.Clone();
            // pętla po wszystkich pikselach
            for (int a = 0; a < image.Width; a++)
            for (int b = 0; b < image.Height; b++)
            {
                List<byte> R = new List<byte>();
                List<byte> G = new List<byte>();
                List<byte> B = new List<byte>();
                for(int i = a-filterX/2; i < a+filterX/2; i++){
                    for(int j = b-filterY/2; j < b+filterY/2; j++){
                        if(i < 0 || j < 0 || i >= image.Width || j >= image.Height)
                            continue;
                        R.Add(image[i,j].R);
                        G.Add(image[i,j].G);
                        B.Add(image[i,j].B);
                    }
                }
                R.Sort();
                G.Sort();
                B.Sort();
                
                my_clone[a,b] = new Rgb24(getMedian(R), getMedian(G), getMedian(B));
                    
            }
            Console.WriteLine("OK");
            //zapisanie obrazków
            my_clone.Save(@"../../../Task2.png");             
        }
    }

    private static byte getMedian(List<byte> input)
    {
        if (input.Count % 2 == 1) return input[input.Count / 2 + 1];
        return (byte)((input[input.Count / 2 + 1] + input[input.Count / 2]) / 2);
    }
}