using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[0];
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
                        data = Encoding.UTF8.GetBytes(File.ReadAllText(@"C:\ks\lab1\Vasilkiv.txt", Encoding.Default)); break;
                    case 2:
                        isCorrect = true;
                        data = Encoding.UTF8.GetBytes(File.ReadAllText(@"C:\ks\lab1\Vasilkiv1.txt", Encoding.Default)); break;
                    case 3:
                        isCorrect = true;
                        data = Encoding.UTF8.GetBytes(File.ReadAllText(@"C:\ks\lab1\Vasilkiv2.txt", Encoding.Default)); break;
                    default:
                        isCorrect = false;
                        break;
                }
            }
            while (!isCorrect);
            char[] value = Base64Encoding(data);
            Console.WriteLine(value);

            string sValue = "";
            for (int i = 0; i < value.LongLength; i++)
            {
                sValue += value[i].ToString();
            }

            switch (caseSwitch)
            {
                case 1:
                    File.WriteAllText(@"C:\ks\lab1\Vasilkiv(Encoded).txt", sValue, Encoding.Default);
                    break;
                case 2:
                    File.WriteAllText(@"C:\ks\lab1\Vasilkiv1(Encoded).txt", sValue, Encoding.Default);
                    break;
                case 3:
                    File.WriteAllText(@"C:\ks\lab1\Vasilkiv2(Encoded).txt", sValue, Encoding.Default);
                    break;
                default:
                    break;
            }
            Console.ReadKey();

        }
        public static char[] Base64Encoding(byte[] data)
        {
            int length, length2;
            int blockCount;
            int paddingCount;
            length = data.Length;

            if ((length % 3) == 0)
            {
                paddingCount = 0;
                blockCount = length / 3;
            }
            else
            {
                paddingCount = 3 - (length % 3);
                blockCount = (length + paddingCount) / 3;
            }

            length2 = length + paddingCount;

            byte[] source2 = new byte[length2];

            for (int x = 0; x < length2; x++)
            {
                if (x < length)
                {
                    source2[x] = data[x];
                }
                else
                {
                    source2[x] = 0;
                }
            }

            byte b1, b2, b3;
            byte temp, temp1, temp2, temp3, temp4;
            byte[] buffer = new byte[blockCount * 4];
            char[] result = new char[blockCount * 4];

            for (int x = 0; x < blockCount; x++)
            {
                b1 = source2[x * 3];
                b2 = source2[x * 3 + 1];
                b3 = source2[x * 3 + 2];

                temp1 = (byte)((b1 & 252) >> 2);

                temp = (byte)((b1 & 3) << 4);
                temp2 = (byte)((b2 & 240) >> 4);
                temp2 += temp;

                temp = (byte)((b2 & 15) << 2);
                temp3 = (byte)((b3 & 192) >> 6);
                temp3 += temp;

                temp4 = (byte)(b3 & 63);

                buffer[x * 4] = temp1;
                buffer[x * 4 + 1] = temp2;
                buffer[x * 4 + 2] = temp3;
                buffer[x * 4 + 3] = temp4;

            }

            for (int x = 0; x < blockCount * 4; x++)
            {
                result[x] = GetCharFromIndexTable(buffer[x]);
            }

            switch (paddingCount)
            {
                case 0:
                    break;
                case 1:
                    result[blockCount * 4 - 1] = '=';
                    break;
                case 2:
                    result[blockCount * 4 - 1] = '=';
                    result[blockCount * 4 - 2] = '=';
                    break;
                default:
                    break;
            }

            return result;
        }
        private static char GetCharFromIndexTable(byte b)
        {
            char[] indexTable = new char[64] {
        'A','B','C','D','E','F','G','H','I','J','K','L','M',
        'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        'a','b','c','d','e','f','g','h','i','j','k','l','m',
        'n','o','p','q','r','s','t','u','v','w','x','y','z',
        '0','1','2','3','4','5','6','7','8','9','+','/'};

            if ((b >= 0) && (b <= 63))
            {
                return indexTable[b];
            }
            else
            {
                return ' ';
            }
        }
    }

}
