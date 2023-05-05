namespace lab09;

public class Task3
{
    public static void xMain(string[] args)
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
        
        using (Image<Rgb24> image = Image.Load<Rgb24>(@"../../../img.png")) 
        {
                MaxFilter(image, filterX, filterY);
                MinFilter(image, filterX, filterY);
                AvgFilter(image, filterX, filterY);
        }
    }

    private static void MaxFilter(Image<Rgb24> image, int filterX, int filterY)
    {
        Image<Rgb24>my_clone = image.Clone();
        for (int a = filterX/2; a < image.Width-filterX/2; a++)
        for (int b = filterY/2; b < image.Height-filterY/2; b++)
        {
            List<byte> R = new List<byte>();
            List<byte> G = new List<byte>();
            List<byte> B = new List<byte>();
            for(int i = a-filterX/2; i < a+filterX/2; i++){
                for(int j = b-filterY/2; j < b+filterY/2; j++){
                    R.Add(image[i,j].R);
                    G.Add(image[i,j].G);
                    B.Add(image[i,j].B);
                }
            }
            R.Sort();
            G.Sort();
            B.Sort();
                
            my_clone[a,b] = new Rgb24(R.Max(), G.Max(), B.Max());
        }
        Console.WriteLine("MAX OK");
        //zapisanie obrazków
        my_clone.Save(@"../../../Task3_nMAX.png");      
    }
    
    
    private static void MinFilter(Image<Rgb24> image, int filterX, int filterY)
    {
        Image<Rgb24>my_clone = image.Clone();
        for (int a = filterX/2; a < image.Width-filterX/2; a++)
        for (int b = filterY/2; b < image.Height-filterY/2; b++)
        {
            List<byte> R = new List<byte>();
            List<byte> G = new List<byte>();
            List<byte> B = new List<byte>();
            for(int i = a-filterX/2; i < a+filterX/2; i++){
                for(int j = b-filterY/2; j < b+filterY/2; j++){
                    R.Add(image[i,j].R);
                    G.Add(image[i,j].G);
                    B.Add(image[i,j].B);
                }
            }
            R.Sort();
            G.Sort();
            B.Sort();
                
            my_clone[a,b] = new Rgb24(R.Min(), G.Min(), B.Min());
        }
        Console.WriteLine("MIN OK");
        //zapisanie obrazków
        my_clone.Save(@"../../../Task3_nMIN.png");      
    }
    
    private static void AvgFilter(Image<Rgb24> image, int filterX, int filterY)
    {
        Image<Rgb24>my_clone = image.Clone();
        for (int a = filterX/2; a < image.Width-filterX/2; a++)
        for (int b = filterY/2; b < image.Height-filterY/2; b++)
        {
            var rSum = 0;
            var gSum = 0;
            var bSum = 0;
            
            for(int i = a-filterX/2; i < a+filterX/2; i++){
                for(int j = b-filterY/2; j < b+filterY/2; j++){
                    rSum += image[i,j].R;
                    gSum += image[i,j].G;
                    bSum += image[i,j].B;
                }
            }

            my_clone[a,b] = new Rgb24(
                (byte)(rSum/(filterX*filterY)),
                (byte)(gSum/(filterX*filterY)),
                (byte)(bSum/(filterX*filterY))
            );
        }
        Console.WriteLine("AVG OK");
        //zapisanie obrazków
        my_clone.Save(@"../../../Task3_nAVG.png");      
    }
}