using System;

namespace LegendOfZeldaClone
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new LegendOfZeldaDungeon())
                game.Run();
        }
    }
}
