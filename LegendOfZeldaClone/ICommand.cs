using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
            myGame.Player.MoveDown();
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
            myGame.Player.MoveUp();
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
            myGame.Player.MoveLeft();
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
            myGame.Player.MoveRight();
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
            myGame.Player.ActionA();
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
            myGame.Player.ActionB();
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
            ((ILinkPlayer)game.Player).HeldItem = bow;
            game.Player.ActionB();
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
            ((ILinkPlayer)game.Player).HeldItem = boomerang;
            game.Player.ActionB();
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
            ((ILinkPlayer)game.Player).HeldItem = bomb;
            game.Player.ActionB();
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
            ((ILinkPlayer)game.Player).HeldItem = blueCandle;
            game.Player.ActionB();
        }
    }

    public class PickUpBlueRing : ICommand
    {
        private IUsableItem blueRing;

        public PickUpBlueRing(LegendOfZeldaDungeon game)
        {
            blueRing = new UsableBlueRing(game);
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
            game.Player.Damage(2, Direction.None);
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
            IUsableItem woodenSword = new UsableWoodenSword(game);
            game.Player = new LinkPlayer(game, LoZHelpers.LinkStartingLocation, woodenSword);
            game.PlayerProjectiles.Clear();
        }
    }
    public class PreviousRoom : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public PreviousRoom(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.SwitchRoomDelay != 0)
                return;
            else
                myGame.SwitchRoomDelay = myGame.SwitchDelayLength;
            myGame.RoomListIndex--;
            if (myGame.RoomListIndex < 0)
                myGame.RoomListIndex = myGame.roomList.Count - 1;

            myGame.roomList[myGame.RoomListIndex].LoadRoom();
        }
    }

    public class NextRoom : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public NextRoom(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.SwitchRoomDelay != 0)
                return;
            else
                myGame.SwitchRoomDelay = myGame.SwitchDelayLength;

            myGame.RoomListIndex++;
            if (myGame.RoomListIndex >= myGame.roomList.Count)
                myGame.RoomListIndex = 0;

            myGame.roomList[myGame.RoomListIndex].LoadRoom();
        }
    }

    public class MapChangeRoom : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public MapChangeRoom(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.SwitchRoomDelay != 0)
                return;
            else
                myGame.SwitchRoomDelay = myGame.SwitchDelayLength;

            myGame.RoomListIndex++;
            if (myGame.RoomListIndex == myGame.roomList.Count)
                myGame.RoomListIndex = 0;

            myGame.roomList[myGame.RoomListIndex].LoadRoom();
        }
    }

}
