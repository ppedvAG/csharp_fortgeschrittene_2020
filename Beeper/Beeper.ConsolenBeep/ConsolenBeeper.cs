using System;

namespace Beeper
{
    public class ConsolenBeeper : IBeep
    {
        public void Beep()
        {
            Console.Beep();
        }
    }
}
