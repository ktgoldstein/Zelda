using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public interface ICommand
    {
        void Execute();
    }

    public class QuitGame : ICommand
    {
        private LegendOfZeldaDungeon game;

        public QuitGame(LegendOfZeldaDungeon game) => this.game = game;
        public void Execute() => game.Exit();
    }

    public class MoveDown : ICommand
    {
        private LegendOfZeldaDungeon game;

        public MoveDown(LegendOfZeldaDungeon game) => this.game = game;
        public void Execute() => game.Player.MoveDown();
    }

    public class MoveUp : ICommand
    {
        private LegendOfZeldaDungeon game;

        public MoveUp(LegendOfZeldaDungeon game) => this.game = game;
        public void Execute() => game.Player.MoveUp();
    }

    public class MoveLeft : ICommand
    {
        private LegendOfZeldaDungeon game;

        public MoveLeft(LegendOfZeldaDungeon game) => this.game = game;
        public void Execute() => game.Player.MoveLeft();
    }

    public class MoveRight : ICommand
    {
        private LegendOfZeldaDungeon game;

        public MoveRight(LegendOfZeldaDungeon game) => this.game = game;
        public void Execute() => game.Player.MoveRight();
    }

    public class ActionA : ICommand
    {
        private LegendOfZeldaDungeon game;

        public ActionA(LegendOfZeldaDungeon game) => this.game = game;
        public void Execute() => game.Player.ActionA();
    }

    public class ActionB : ICommand
    {
        private LegendOfZeldaDungeon game;

        public ActionB(LegendOfZeldaDungeon game) => this.game = game;
        public void Execute() => game.Player.ActionB();
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
