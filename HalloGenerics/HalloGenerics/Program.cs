using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloGenerics
{
    class Program
    {
        static void Main(string[] args)
        {

            Hallo<DateTime>();
            Hallo(typeof(DateTime));

            var zwei = GetZweiOfThis<ASCIIEncoding>();

            Save<Version>(new Version());

            Console.WriteLine("Ende");
            Console.ReadKey();
        }

        static void Hallo<EinTyp>()
        {
            Console.WriteLine(typeof(EinTyp).ToString());
        }

        static bool Compare<EinTyp>(EinTyp one, EinTyp two) where EinTyp : class
        {
            return one == two;
        }

        static void Save<EinTyp>(EinTyp instanceOfEinTyp)
        {
            if (typeof(EinTyp) is Version)
            {
                //todo save in VersionFile
            }
        }

        static EinTyp[] GetZweiOfThis<EinTyp>()
        {
            Console.WriteLine(typeof(EinTyp).ToString());
            return new[] {
                           (EinTyp)Activator.CreateInstance(typeof(EinTyp)),
                           (EinTyp)Activator.CreateInstance(typeof(EinTyp))
                         };
        }

        static void Hallo(Type eintyp) //old-school
        {
            Console.WriteLine(eintyp.FullName);
        }

    }


    class MyList<T>:IEnumerable<T>
    {
        T[] daten = new T[12];

        public void Add(T einDing)
        {
            daten[0] = einDing;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> GetAll()
        {
            return daten;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
