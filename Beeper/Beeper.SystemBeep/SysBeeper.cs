using System.Media;

namespace Beeper.SystemBeep
{
    public class SysBeeper : IBeep
    {
        public void Beep()
        {
            SystemSounds.Beep.Play();
        }
    }
}
