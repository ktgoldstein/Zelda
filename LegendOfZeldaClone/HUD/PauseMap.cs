using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LegendOfZeldaClone.LevelLoading;

namespace LegendOfZeldaClone
{

    public class PauseMap
    {
        public ISprite backgroundSprite;

        public List<PauseMapRoom> mapRooms;
        public PauseMapRoom currentRoom;
        
        private LinkOnPauseMap link;

        private readonly GameStateMachine game;

        public PauseMap(GameStateMachine game)
        {
            this.game = game;

            backgroundSprite = HUDTextureFactory.Instance.CreatePauseMap();

            currentRoom = new PauseMapRoom(GetRoomType(game.CurrentRoom), LoZHelpers.PauseMapRoomLocation);
            mapRooms = new List<PauseMapRoom> { currentRoom };

            link = new LinkOnPauseMap(LoZHelpers.LinkLocationTrackerPause, game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundSprite.Draw(spriteBatch, LoZHelpers.PauseMapLocation);

            foreach (PauseMapRoom room in mapRooms)
                room.Draw(spriteBatch);

            link.Draw(spriteBatch);
        }

        public void MoveRooms(Direction direction)
        {
            link.moveLinkOnPauseMap(direction);
            Vector2 targetLocation = currentRoom.Location;
            switch (direction)
            {
                case Direction.Left:
                    targetLocation.X -= LoZHelpers.RightLeftRoomPauseMapOffset;
                    break;
                case Direction.Right:
                    targetLocation.X += LoZHelpers.RightLeftRoomPauseMapOffset;
                    break;
                case Direction.Down:
                    targetLocation.Y += LoZHelpers.UpDownRoomPauseMapOffset;
                    break;
                case Direction.Up:
                    targetLocation.Y -= LoZHelpers.UpDownRoomPauseMapOffset;
                    break;
            }
            foreach (PauseMapRoom room in mapRooms)
            {
                if (room.Location == targetLocation)
                {
                    currentRoom = room;
                    return;
                }
            }
            currentRoom = new PauseMapRoom(GetRoomType(game.CurrentRoom), targetLocation);
            mapRooms.Add(currentRoom);
        }

        private PauseMapRoomType GetRoomType(Room target)
        {
            int roomType = 0;
            roomType += (target.RoomUp != null) ? 0b1000 : 0;
            roomType += (target.RoomDown != null) ? 0b0100 : 0;
            roomType += (target.RoomLeft != null) ? 0b0010 : 0;
            roomType += (target.RoomRight != null) ? 0b0001 : 0;
            return (PauseMapRoomType)roomType;
        }

        public void Reset()
        {
            currentRoom = new PauseMapRoom(GetRoomType(game.CurrentRoom), LoZHelpers.PauseMapRoomLocation);
            mapRooms = new List<PauseMapRoom> { currentRoom };

            link.Reset();
        }
    }
}
