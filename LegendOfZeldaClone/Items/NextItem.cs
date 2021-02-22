namespace LegendOfZeldaClone
{
    public class NextItem : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public NextItem(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.SwitchItemDelay != 0)
                return;
            else
                myGame.SwitchItemDelay = myGame.SwitchDelayLength;

            myGame.itemIndex++;
            if (myGame.itemIndex > myGame.Items.Length - 1)
            {
                myGame.itemIndex = 0;
            }
            myGame.CurrItem = myGame.Items[myGame.itemIndex];
        }
    }
}

