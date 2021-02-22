namespace LegendOfZeldaClone
{
    public class PreviousItem : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public PreviousItem(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.SwitchItemDelay != 0)
                return;
            else
                myGame.SwitchItemDelay = myGame.SwitchDelayLength;

            myGame.itemIndex--;
            if (myGame.itemIndex < 0)
            {
                myGame.itemIndex = myGame.Items.Length - 1;
            }
            myGame.CurrItem = myGame.Items[myGame.itemIndex];
        }
    }
}

