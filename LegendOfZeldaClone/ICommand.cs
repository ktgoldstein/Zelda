using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZeldaClone
{
    public interface ICommand
    {
        void Execute();
    }

    public class QuitGame : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public QuitGame(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }

    public class MoveDown : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public MoveDown(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.MoveDown();
        }
    }

    public class MoveUp : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public MoveUp(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.MoveUp();
        }
    }

    public class MoveLeft : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public MoveLeft(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.MoveLeft();
        }
    }

    public class MoveRight : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public MoveRight(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.MoveRight();
        }
    }

    public class ActionA : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public ActionA(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.ActionA();
        }
    }

    public class ActionB : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public ActionB(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Link.ActionB();
        }
    }

    public class PickUpBlueRing : ICommand
    {
        private IUsableItem blueRing;

        public PickUpBlueRing(LegendOfZeldaDungeon game)
        {
            blueRing = new BlueRing(game);
        }

        public void Execute()
        {
            blueRing.Use();
        }
    }

    public class ResetLink : ICommand
    {
        private LegendOfZeldaDungeon game;

        public ResetLink(LegendOfZeldaDungeon game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Link = new LinkPlayer(game, LoZHelpers.LinkStartingLocation);
        }
    }

    public class ResetEnemy : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public ResetEnemy(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Stalfos(LoZHelpers.EnemyStartingLocation);
        }

    }

    public class SetSpriteEnemy : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public SetSpriteEnemy(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            // Cycle counter
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                myGame.switchEnemyNum++;
                myGame.switchEnemyNum %= 7;

            }
            else
            {
                this.myGame.switchEnemyNum--;
                if (myGame.switchEnemyNum == -1)
                {
                    myGame.switchEnemyNum = 6;
                }
            }

            int pickSprite = myGame.switchEnemyNum;
            switch (pickSprite)
            {
                case 1:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Aquamentus(LoZHelpers.EnemyStartingLocation);
                        break;
                    }
                case 2:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Goriya(LoZHelpers.EnemyStartingLocation);
                        break;
                    }
                case 3:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.BladeTrap(LoZHelpers.EnemyStartingLocation);
                        break;
                    }
                case 4:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Keese(LoZHelpers.EnemyStartingLocation);
                        break;
                    }
                case 5:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Gel(LoZHelpers.EnemyStartingLocation);
                        break;
                    }
                case 6:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Wallmaster(LoZHelpers.EnemyStartingLocation);
                        break;
                    }
                default:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Stalfos(LoZHelpers.EnemyStartingLocation);
                        break;
                    }
            }
        }
    }

    public class PreviousItem : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public PreviousItem(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.ItemIndex == 0)
            {
                myGame.ItemIndex = myGame.Items.Length - 1;
                myGame.CurrItem = myGame.Items[myGame.ItemIndex];
            }
            else
            {
                myGame.ItemIndex -= 1;
                myGame.CurrItem = myGame.Items[myGame.ItemIndex];
            }
        }
    }

    public class NextItem : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public NextItem(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.ItemIndex == myGame.Items.Length - 1)
            {
                myGame.ItemIndex = 0;
                myGame.CurrItem = myGame.Items[0];
            }
            else
            {
                myGame.ItemIndex += 1;
                myGame.CurrItem = myGame.Items[myGame.ItemIndex];
            }
        }
    }
    public class NextObject : ICommand
    {
        private LegendOfZeldaDungeon myGame;
        public static int index { get; set; }
        public NextObject(LegendOfZeldaDungeon game)
        {
            myGame = game;
            index = 1;
        }

        public void Execute()
        {

            if (index < myGame.objList.Count - 1)
            {
                index++;
                myGame.currentObject = myGame.objList[index];
            }

        }
    }
    public class PreviousObject : ICommand
    {
        private LegendOfZeldaDungeon myGame;
        public PreviousObject(LegendOfZeldaDungeon game)
        {
            myGame = game;

        }

        public void Execute()
        {

            if (NextObject.index > 0)
            {
                NextObject.index--;
                myGame.currentObject = myGame.objList[NextObject.index];
            }
        }
    }
}

