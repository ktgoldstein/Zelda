﻿using Microsoft.Xna.Framework;

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
        private GameStateMachine game;

        public MoveDown(GameStateMachine game) => this.game = game;
        public void Execute() => game.Player.MoveDown();
    }

    public class MoveUp : ICommand
    {
        private GameStateMachine game;

        public MoveUp(GameStateMachine game) => this.game = game;
        public void Execute() => game.Player.MoveUp();
    }

    public class MoveLeft : ICommand
    {
        private GameStateMachine game;

        public MoveLeft(GameStateMachine game) => this.game = game;
        public void Execute() => game.Player.MoveLeft();
    }

    public class MoveRight : ICommand
    {
        private GameStateMachine game;

        public MoveRight(GameStateMachine game) => this.game = game;
        public void Execute() => game.Player.MoveRight();
    }

    public class ActionA : ICommand
    {
        private GameStateMachine game;

        public ActionA(GameStateMachine game) => this.game = game;
        public void Execute() => game.Player.ActionA();
    }

    public class ActionB : ICommand
    {
        private GameStateMachine game;

        public ActionB(GameStateMachine game) => this.game = game;
        public void Execute() => game.Player.ActionB();
    }

    public class DamageLink : ICommand
    {
        private GameStateMachine game;

        public DamageLink(GameStateMachine game) => this.game = game;
        public void Execute() => game.Player.Damage(1, Direction.None);
    }
        
    public class ResetGame : ICommand
    {
        private GameStateMachine game;

        public ResetGame(GameStateMachine game) => this.game = game;

        public void Execute() => game.Reset();
    }

    public class MoveRoomDown : ICommand
    {
        private GameStateMachine game;

        public MoveRoomDown(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomDown == null)
                return;
            else
                game.SwitchRoomDelay = game.SwitchDelayLength;

            game.CurrentRoom = game.CurrentRoom.RoomDown;
            game.CurrentRoom.LoadRoom();
        }
    }

    public class MoveRoomUp : ICommand
    {
        private GameStateMachine game;

        public MoveRoomUp(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomUp == null)
                return;
            else
                game.SwitchRoomDelay = game.SwitchDelayLength;

            game.CurrentRoom = game.CurrentRoom.RoomUp;
            game.CurrentRoom.LoadRoom();
        }
    }

    public class MoveRoomLeft : ICommand
    {
        private GameStateMachine game;

        public MoveRoomLeft(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomLeft == null)
                return;
            else
                game.SwitchRoomDelay = game.SwitchDelayLength;

            game.CurrentRoom = game.CurrentRoom.RoomLeft;
            game.CurrentRoom.LoadRoom();
        }
    }

    public class MoveRoomRight : ICommand
    {
        private GameStateMachine game;

        public MoveRoomRight(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomRight == null)
                return;
            else
                game.SwitchRoomDelay = game.SwitchDelayLength;

            game.CurrentRoom = game.CurrentRoom.RoomRight;
            game.CurrentRoom.LoadRoom();
        }
    }
}
