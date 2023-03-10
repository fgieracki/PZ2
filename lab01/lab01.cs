// See https://aka.ms/new-console-template for more information
// Autor: Filip Gieracki

//2
// List<string> words = new List<string>();
// while(words.Count == 0 || words.Last() != "koniec!"){
//     words.Add(Console.ReadLine());
// }
// words.Remove("koniec!");
// words.Sort();

// StreamWriter sw = new StreamWriter("out2.txt", append:true);
// foreach(var word in words){
//     sw.WriteLine(word);
// }
// sw.Close();



//3
// string fileName = Console.ReadLine();
// string phrase = Console.ReadLine();
// int lineNo = 1;

// StreamReader inputFile = new StreamReader(fileName);

// while(!inputFile.EndOfStream){
//     string line = inputFile.ReadLine();
//     if(line.Contains(phrase)){
//         Console.WriteLine($"linijka: {lineNo}, pozycja: {line.IndexOf(phrase)+1}");
//     }
//     lineNo++;
// }
// inputFile.Close();



//4
// int seed = 0;
// int numberOfNumbers = 10;
// string fileName = "fileName.txt";
// long begg = 0;
// long endd = 100;
// bool isreal = false;

// if(args.Length > 0){
//     fileName = args[0];
//     numberOfNumbers = int.Parse(args[1]);
//     begg = int.Parse(args[2]);
//     endd = int.Parse(args[3]);
//     seed = int.Parse(args[4]);
//     isreal = bool.Parse(args[5]);
// }

// StreamWriter sw = new StreamWriter(fileName, true);
// Random random = new Random(seed);

// for (int i = 0; i < numberOfNumbers; i++){
//     if (isreal)
//         sw.WriteLine(random.NextDouble()*(endd-begg)+begg);
//     else
//         sw.WriteLine(random.NextInt64(begg, endd));
// }
// sw.Close();

//5
// int seed = 0;
// int numberOfNumbers = 10;
// string fileName = "fileName.txt";
// long begg = 0;
// long endd = 100;
// bool isreal = false;

// if(args.Length > 0){
//     fileName = args[0];
//     numberOfNumbers = int.Parse(args[1]);
//     begg = int.Parse(args[2]);
//     endd = int.Parse(args[3]);
//     seed = int.Parse(args[4]);
//     isreal = bool.Parse(args[5]);
// }

// StreamWriter sw = new StreamWriter(fileName, true);
// Random random = new Random(seed);
// double minn = 9999999;
// double maxx = -9999999;
// int numberOfChars = 0;
// double avgCounter = 0;
// List<double> nums = new List<double>();
// for (int i = 0; i < numberOfNumbers; i++){
//     if (isreal){
//         double tmp = random.NextDouble()*(endd-begg)+begg;
//         sw.WriteLine(tmp);
//         avgCounter += tmp;
//         numberOfChars+=tmp.ToString().Length;
//         if(minn>tmp) minn = tmp;
//         if(maxx<tmp) maxx = tmp;
//         nums.Add(tmp);
//         }
//     else{
//         double tmp = random.NextInt64(begg, endd);
//         sw.WriteLine(tmp);
//         avgCounter += tmp;
//         numberOfChars+=tmp.ToString().Length;
//         if(minn>tmp) minn = tmp;
//         if(maxx<tmp) maxx = tmp;
//         nums.Add(tmp);
//     }

// }

// sw.Close();
// Console.WriteLine($"Liczba linii: {nums.Count}\nLiczba znakow: {numberOfChars}\nNajwieksza liczba: {maxx}\nNajmniejsza liczba: {minn}\nSrednia: {avgCounter/nums.Count}");


//6
string fileName1 = "file.txt";
string fileName2 = "file.txt";
string fileName3 = "file.txt";

if(args.Length > 0){
    fileName1 = args[0];
    fileName2 = args[1];
    fileName3 = args[2];
}


StreamReader sw1 = new StreamReader(fileName1, true);
StreamReader sw2 = new StreamReader(fileName2, true);
StreamWriter sr1 = new StreamWriter(fileName3);
double val1 = 0;
double val2 = 0;

if(!sw1.EndOfStream) val1 = double.Parse(sw1.ReadLine());
if(!sw2.EndOfStream) val2 = double.Parse(sw2.ReadLine());

while(!sw1.EndOfStream || !sw2.EndOfStream) {
    if(sw1.EndOfStream) {
        sr1.WriteLine(val2);
        val2 = double.Parse(sw2.ReadLine());
    }
    else if(sw2.EndOfStream) {
        sr1.WriteLine(val1);
        val1 = double.Parse(sw1.ReadLine());
    }
    else {
        if(val1 < val2) {
            sr1.WriteLine(val1);
            val1 = double.Parse(sw1.ReadLine());
        }
        else{
            sr1.WriteLine(val2);
            val2 = double.Parse(sw2.ReadLine());
        }
    }
}

sw1.Close();
sw2.Close();
sr1.Close();