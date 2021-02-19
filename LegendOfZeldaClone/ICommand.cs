﻿using Microsoft.Xna.Framework;
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

    public class UseBow : ICommand
    {
        private IUsableItem bow;
        private LegendOfZeldaDungeon game;

        public UseBow(LegendOfZeldaDungeon game, ArrowSkinType skinType)
        {
            this.game = game;
            bow = new UsableBow(game, skinType);
        }

        public void Execute()
        {
            ((ILinkPlayer)game.Link).HeldItem = bow;
            game.Link.ActionB();
        }
    }

    public class UseBoomerang : ICommand
    {
        private IUsableItem boomerang;
        private LegendOfZeldaDungeon game;

        public UseBoomerang(LegendOfZeldaDungeon game, BoomerangSkinType skinType)
        {
            this.game = game;
            boomerang = new UsableBoomerang(game, skinType);
        }

        public void Execute()
        {
            ((ILinkPlayer)game.Link).HeldItem = boomerang;
            game.Link.ActionB();
        }
    }

    public class UseBomb : ICommand
    {
        private IUsableItem bomb;
        private LegendOfZeldaDungeon game;

        public UseBomb(LegendOfZeldaDungeon game)
        {
            this.game = game;
            bomb = new UsableBomb(game);
        }

        public void Execute()
        {
            ((ILinkPlayer)game.Link).HeldItem = bomb;
            game.Link.ActionB();
        }
    }

    public class UseBlueCandle : ICommand
    {
        private IUsableItem blueCandle;
        private LegendOfZeldaDungeon game;

        public UseBlueCandle(LegendOfZeldaDungeon game)
        {
            this.game = game;
            blueCandle = new UsableBlueCandle(game);
        }

        public void Execute()
        {
            ((ILinkPlayer)game.Link).HeldItem = blueCandle;
            game.Link.ActionB();
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
            blueRing.Use(new Vector2(), Direction.None);
        }
    }

    public class DamageLink : ICommand
    {
        private LegendOfZeldaDungeon game;

        public DamageLink(LegendOfZeldaDungeon game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Link.Damage(2);
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
            if (myGame.SwitchEnemyDelay != 0)
                return;
            else
                myGame.SwitchEnemyDelay = myGame.SwitchDelayLength;

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
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Aquamentus();
                        break;
                    }
                case 2:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Goriya();
                        break;
                    }
                case 3:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.BladeTrap();
                        break;
                    }
                case 4:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Keese();
                        break;
                    }
                case 5:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Gel();
                        break;
                    }
                case 6:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Wallmaster();
                        break;
                    }
                default:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Stalfos();
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
            if (myGame.SwitchItemDelay != 0)
                return;
            else
                myGame.SwitchItemDelay = myGame.SwitchDelayLength;

            if (myGame.itemIndex == 0)
            {
                myGame.itemIndex = myGame.Items.Length - 1;
                myGame.CurrItem = myGame.Items[myGame.itemIndex];
            }
            else
            {
                myGame.itemIndex -= 1;
                myGame.CurrItem = myGame.Items[myGame.itemIndex];
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
            if (myGame.SwitchItemDelay != 0)
                return;
            else
                myGame.SwitchItemDelay = myGame.SwitchDelayLength;

            if (myGame.itemIndex == myGame.Items.Length - 1)
            {
                myGame.itemIndex = 0;
                myGame.CurrItem = myGame.Items[0];
            }
            else
            {
                myGame.itemIndex += 1;
                myGame.CurrItem = myGame.Items[myGame.itemIndex];
            }
        }
    }
    public class NextObject : ICommand
    {
        private LegendOfZeldaDungeon myGame;
        
        public NextObject(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.SwitchObjectDelay != 0)
                return;
            else
                myGame.SwitchObjectDelay = myGame.SwitchDelayLength;

            myGame.ObjectIndex++;
            if (myGame.ObjectIndex > myGame.Objects.Count - 1)
                myGame.ObjectIndex = 0;
            myGame.CurrentObject = myGame.Objects[myGame.ObjectIndex];
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
            if (myGame.SwitchObjectDelay != 0)
                return;
            else
                myGame.SwitchObjectDelay = myGame.SwitchDelayLength;

            myGame.ObjectIndex--;
            if (myGame.ObjectIndex < 0)
                myGame.ObjectIndex = myGame.Objects.Count - 1;
            myGame.CurrentObject = myGame.Objects[myGame.ObjectIndex];
        }
    }

    public class ResetGame : ICommand
    {
        private LegendOfZeldaDungeon game;

        public ResetGame(LegendOfZeldaDungeon game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.itemIndex = 0;
            game.CurrItem = game.Items[game.itemIndex];

            game.ObjectIndex = 0;
            game.CurrentObject = game.Objects[game.ObjectIndex];

            IUsableItem woodenSword = new UsableWoodenSword(game);
            game.Link = new LinkPlayer(game, LoZHelpers.LinkStartingLocation, woodenSword);
            game.LinkProjectiles.Clear();

            game.SpriteEnemy = new LegendOfZeldaClone.Enemy.Stalfos();
        }
    }
}

