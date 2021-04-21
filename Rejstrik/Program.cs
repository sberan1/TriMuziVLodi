using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        private Dictionary<string, List<int>> Slova = new Dictionary<string, List<int>>();
        public void VytvoreniRejstriku(string cestaCteni)
        {
            PrecteniRadku(cestaCteni);
            using (var writer = new StreamWriter(@"D:\KlonovatelneProjekty\Rejstrik\Rejstrik\Rejstrik.txt"))
            {
                foreach (var slovo in Slova)
                {
                    writer.WriteLine(slovo.Key + " - " + string.Join(", ",slovo.Value.Select(x => x.ToString()).ToArray()));
                }
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
                    string[] slovaNaRadku = reader.ReadLine().Split(' ', '-','"', ',','.','?','!','[',']','(',')','_','*','—','“','#','”',':',';');
                    for (int i = 0; i < slovaNaRadku.Length; i++)
                    {
                        string slovo = slovaNaRadku[i].ToLower();
                        if (slovo == "" || slovo.Length < 2) 
                        {
                            continue;
                        }
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