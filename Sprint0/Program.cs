using System;

namespace LegendOfZelda
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new LegendOfZeldaClone())
                game.Run();
        }
    }
}
