using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.LevelLoading;

namespace LegendOfZeldaClone
{
    public class PauseMapLink
    {
        private readonly Room startingRoom;
        private readonly ISprite linkOnMap;
        private Vector2 location;

        public PauseMapLink(Room startingRoom)
        {
            this.startingRoom = startingRoom;
            linkOnMap = HUDTextureFactory.Instance.CreateLocationTrackerPause();
            location = RoomOffsetToLocation(startingRoom.RoomOffset);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            linkOnMap.Draw(spriteBatch, location);
        }

        public void MoveLinkOnPauseMap(Room targetRoom)
        {
            location = RoomOffsetToLocation(targetRoom.RoomOffset);
        }

        public void Reset()
        {
            location = RoomOffsetToLocation(startingRoom.RoomOffset);
        }

        private Vector2 RoomOffsetToLocation(Vector2 roomOffset)
        {
            return LoZHelpers.PauseMapTrackerStartingLocation
                + new Vector2(roomOffset.X * LoZHelpers.HorizontalPauseMapRoomOffset, roomOffset.Y * LoZHelpers.VerticalPauseMapRoomOffset);
        }
    }
}
