﻿using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class OpenDoorLeft : DoorKernel
    {
        private readonly GameStateMachine game;

        public OpenDoorLeft(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                foreach (IBlock block in game.CurrentRoom.RoomLeft.Blocks)
                {
                    if (block is LockedDoor && (block as LockedDoor).Orientation == Direction.Right)
                    {
                        game.CurrentRoom.RoomLeft.Blocks.Remove(block);
                        break;
                    }
                }
                game.MoveRoom(Direction.Left);
            }
        }
    }
}