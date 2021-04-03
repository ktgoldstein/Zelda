using LegendOfZeldaClone.Objects;
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
        private GameStateMachine game;

        public MoveDown(GameStateMachine game) => this.game = game;
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Player.MoveDown();
            else if (game.CurrentGameState == GameState.Pause)
                game.InventoryBox.Update(Direction.Down);
        }
    }

    public class MoveUp : ICommand
    {
        private GameStateMachine game;

        public MoveUp(GameStateMachine game) => this.game = game;
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Player.MoveUp();
            else if (game.CurrentGameState == GameState.Pause)
                game.InventoryBox.Update(Direction.Up);
        }
    }

    public class MoveLeft : ICommand
    {
        private GameStateMachine game;

        public MoveLeft(GameStateMachine game) => this.game = game;
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Player.MoveLeft();
            else if (game.CurrentGameState == GameState.Pause)
                game.InventoryBox.Update(Direction.Left);
        }
    }

    public class MoveRight : ICommand
    {
        private GameStateMachine game;

        public MoveRight(GameStateMachine game) => this.game = game;
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Player.MoveRight();
            else if (game.CurrentGameState == GameState.Pause)
                game.InventoryBox.Update(Direction.Right);
        }
    }

    public class ActionA : ICommand
    {
        private GameStateMachine game;

        public ActionA(GameStateMachine game) => this.game = game;
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Player.ActionA();
        }
    }

    public class ActionB : ICommand
    {
        private GameStateMachine game;

        public ActionB(GameStateMachine game) => this.game = game;
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Player.ActionB();
        }
    }

    public class DamageLink : ICommand
    {
        private GameStateMachine game;

        public DamageLink(GameStateMachine game) => this.game = game;
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Player.Damage(1, Direction.None);
        }
    }
        
    public class ResetGame : ICommand
    {
        private GameStateMachine game;

        public ResetGame(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.Reset();
        }
    }

    public class MoveRoomDown : ICommand
    {
        private GameStateMachine game;

        public MoveRoomDown(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.CurrentGameState != GameState.Play) return;
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomDown == null) return;
            game.SwitchRoomDelay = game.SwitchDelayLength;
            foreach(IObject block in game.Objects)
            {
                if(block is OpenDoorDown || block is TunnelFaceDown)
                {
                    game.Player.Location = block.Location + new Vector2(LoZHelpers.Scale(8), LoZHelpers.Scale(0));
                    (block as IDoor).ChangeRoom();
                    return;
                }
                else if(block is Stairs)
                {
                    (block as IDoor).ChangeRoom();
                    return;
                }
            }
        }
    }

    public class MoveRoomUp : ICommand
    {
        private GameStateMachine game;

        public MoveRoomUp(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.CurrentGameState != GameState.Play) return;
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomUp == null) return;
            game.SwitchRoomDelay = game.SwitchDelayLength;

            foreach (IObject block in game.Objects)
            {
                if (block is OpenDoorUp || block is TunnelFaceUp)
                {
                    game.Player.Location = block.Location + new Vector2(LoZHelpers.Scale(8), LoZHelpers.Scale(14));
                    (block as IDoor).ChangeRoom();
                    return;
                }
                else if(block is LadderDoor)
                {
                    (block as IDoor).ChangeRoom();
                    return;
                }
            }
        }
    }

    public class MoveRoomLeft : ICommand
    {
        private GameStateMachine game;

        public MoveRoomLeft(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.CurrentGameState != GameState.Play) return;
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomLeft == null) return;
            game.SwitchRoomDelay = game.SwitchDelayLength;

            foreach (IObject block in game.Objects)
            {
                if (block is OpenDoorLeft)
                {
                    game.Player.Location = block.Location + new Vector2(LoZHelpers.Scale(0), LoZHelpers.Scale(8));
                    (block as IDoor).ChangeRoom();
                    return;
                }
            }
        }
    }

    public class MoveRoomRight : ICommand
    {
        private GameStateMachine game;

        public MoveRoomRight(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.CurrentGameState != GameState.Play) return;
            if (game.SwitchRoomDelay != 0 || game.CurrentRoom.RoomRight == null) return;
            game.SwitchRoomDelay = game.SwitchDelayLength;
            foreach (IObject block in game.Objects)
            {
                if (block is OpenDoorRight)
                {
                    game.Player.Location = block.Location + new Vector2(LoZHelpers.Scale(16), LoZHelpers.Scale(8));
                    (block as IDoor).ChangeRoom();
                    return;
                }
            }
        }
    }

    public class PauseGame : ICommand
    {
        private GameStateMachine game;
        public PauseGame(GameStateMachine game) => this.game = game;

        public void Execute()
        {
            if (game.CurrentGameState == GameState.Play)
                game.CurrentGameState = GameState.Pause;
            else
                game.CurrentGameState = GameState.Play;
        }
    }

    public class SelectItem : ICommand
    {
        private GameStateMachine game;

        public SelectItem(GameStateMachine game) => this.game = game; 
        
        public void Execute()
        {
            if (game.CurrentGameState == GameState.Pause)
                game.InventoryBoxB.Update();
        }
    }
}
