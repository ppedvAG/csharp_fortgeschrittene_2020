using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpIsCool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C#");

            TypPrüfungUndUmwandlung(DateTime.Now);
            HalloTupel();
            HalloYield();


            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private async static void HalloYield()
        {
            foreach (var item in GetTexte())
            {
                Console.WriteLine(item);
            }

            await foreach (var item in GetTexteAsync())
            {
                Console.WriteLine($"A: {item}");
            }
        }

        private static IEnumerable<string> GetTexte()
        {
            //var liste = new List<string>();
            //liste.Add("Hallo");
            //liste.Add("Welt");
            //liste.Add("Was");
            //liste.Add("geht");
            //liste.Add("ab?");
            //return liste;

            yield return "Hallo";
            yield return "Welt";
            yield return "Was";
            yield return "geht";
            yield return "ab?";
        }

        static async IAsyncEnumerable<string> GetTexteAsync()
        {
            await Task.Delay(1000);
            yield return "Hallo";
            await Task.Delay(1000);
            yield return "Welt";
            await Task.Delay(1000);
            yield return "Was";
            await Task.Delay(1000);
            yield return "geht";
            await Task.Delay(1000);
            yield return "ab?";
        }

        private static void HalloTupel()
        {
            var anoDatenTyp = new { Name = "Fred", GebDatum = DateTime.Now.AddYears(-100), Nummer = 12 };

            Tuple<int, string, DateTime> tuple = new Tuple<int, string, DateTime>(12, "Fred", DateTime.Now);

            var doppelResult = FunctionMitMehrerenRückgaben();
            var (alterDesFred, JahrDesFreds) = FunctionMitMehrerenRückgaben();

        }

        public static (int alter, int jahr) FunctionMitMehrerenRückgaben()
        {
            return (17, 12);
        }


        private static void TypPrüfungUndUmwandlung(object obj)
        {
            //old-school (.NET 1.1)
            if (obj is DateTime) //prüfung
            {
                DateTime dtttt = (DateTime)obj; //casting
            }

            //ab .net 2.0 Boxing
            Version ver = obj as Version;
            if (ver != null)
            {

            }

            //ab vs2019 patter matching
            if (obj is Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
