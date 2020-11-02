using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Navigation;

namespace KatzenFakten
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string text);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            Action meineAction = EinfacheMethode;
            Action meineActionAno = delegate () { Console.WriteLine("Halölo"); };
            Action meineActionAno2 = () => { Console.WriteLine("Hallo"); };
            Action meineActionAno3 = () => Console.WriteLine("Hallo");

            DelegateMitPara deleMitPara = MethodeMitPara;
            Action<string> deleMitParaAction = MethodeMitPara;
            DelegateMitPara deleMitParaAno = (string msg) => { Console.WriteLine(msg); };
            DelegateMitPara deleMitParaAno2 = (msg) => Console.WriteLine(msg);
            DelegateMitPara deleMitParaAno3 = x => Console.WriteLine(x);

            CalcDelegate calc = Multi;
            Func<int, int, long> calcFunc = Sum;
            CalcDelegate calcAno = (x, y) => { return x + y; };
            CalcDelegate calcAno2 = (x, y) =>  x + y;

            var text = new List<string>();
            text.Where(x => x.StartsWith("b"));
            text.Where(Filter);

            long res = calc.Invoke(1, 5);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Multi(int x, int y)
        {
            return x * y;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string text)
        {
            Console.WriteLine(text);
        }

        void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}
