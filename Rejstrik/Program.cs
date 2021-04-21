using System;
using System.Collections.Generic;
using System.IO;

namespace Rejstrik
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\KlonovatelneProjekty\Rejstrik\Rejstrik\ThreeMenInABoatEnglish.txt";
            Rejstrik rejstrik = new Rejstrik();
            rejstrik.VytvoreniRejstriku(path);
        }
    }

    class Rejstrik
    {
        public Dictionary<string, List<int>> Slova;
        public void VytvoreniRejstriku(string cestaCteni)
        {
            PrecteniRadku(cestaCteni);
            using (var writer = new StreamWriter(@"D:\KlonovatelneProjekty\Rejstrik\Rejstrik\Rejstrik.txt"))
            {
                
            }
        }

        private void PrecteniRadku(string cesta)
        {
            int radek = 0;
            using (var reader = new StreamReader(cesta))
            {
                while (!reader.EndOfStream)
                {
                    radek++;
                    string[] slovaNaRadku = reader.ReadLine().Split(' ', '-','"', ',','.','?','!');
                    for (int i = 0; i < slovaNaRadku.Length; i++)
                    {
                        string slovo = slovaNaRadku[i].ToLower();
                        if (!Slova.ContainsKey(slovo))
                        {
                            List<int> radky = new List<int>();
                            radky.Add(radek);
                            Slova.Add(slovo, radky);
                            continue;
                        }
                        List<int> radky1 = Slova[slovo];
                        radky1.Add(radek);
                        Slova[slovo] = radky1;
                    }

                }
            }
        }
    }
    
}