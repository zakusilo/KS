using System;
using System.Text;
using System.IO;
using System.IO.Compression;


namespace Lab1_part1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            string s = "";
            bool isCorrect;
            int caseSwitch;
            Console.WriteLine("Enter wishful text:");
            do
            {
                caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        isCorrect = true;
                        s = File.ReadAllText(@"C:\ks\lab1\Vasilkiv(Encoded).xz", Encoding.Default).Replace("\r\n", "");
                        break;
                    case 2:
                        isCorrect = true;
                        s = File.ReadAllText(@"C:\ks\lab1\Vasilkiv1(Encoded).xz", Encoding.Default).Replace("\r\n", "");
                        break;
                    case 3:
                        s = File.ReadAllText(@"C:\ks\lab1\Vasilkiv2(Encoded).xz", Encoding.Default).Replace("\r\n", "");
                        isCorrect = true;
                        break;
                    default:
                        isCorrect = false;
                        break;
                }
            }
            while (!isCorrect);

            int[] c = new int[char.MaxValue];
            foreach (char t in s)
            {
                c[t]++;//визначення к-сті кожного символу
            }

            double frequency, entropy = 0, information;
            for (int i = 0; i < char.MaxValue; i++)
            {
                if (c[i] > 0)
                {
                    frequency = (double)c[i] / s.Length;
                    entropy += frequency * Math.Log(1 / frequency, 2);
                    Console.WriteLine("Symbol: {0}  imovirnist symbol: {1}", (char)i, frequency);
                }
            }
            information = entropy * s.Length / 8.0;
            Console.WriteLine("serednya entropy :{0} bit         kilkist info : {1} byte", entropy, information);
            switch (caseSwitch)
            {
                case 1:
                    FileInfo file = new FileInfo(@"C:\ks\lab1\Vasilkiv(Encoded).xz");
                    Console.WriteLine("Size: {0} bite", file.Length);
                    break;
                case 2:
                    file = new FileInfo(@"C:\ks\lab1\Vasilkiv1(Encoded).xz");
                    Console.WriteLine("Size: {0} bite", file.Length);
                    break;
                case 3:
                    file = new FileInfo(@"C:\ks\lab1\Vasilkiv2(Encoded).xz");
                    Console.WriteLine("Size: {0} bite", file.Length);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
