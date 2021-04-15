using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.LevelLoading;

namespace LegendOfZeldaClone
{

    public class PauseMapRoom 
    {
        public Room Room { get; }

        private Vector2 location;
        private readonly ISprite roomSprite;

        public PauseMapRoom(Room targetRoom)
        {
            Room = targetRoom;
            roomSprite = HUDTextureFactory.Instance.CreatePauseMapRooms(GetRoomType(targetRoom));
            location = RoomOffsetToLocation(targetRoom.RoomOffset);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            roomSprite.Draw(spriteBatch, location);
        }

        private Vector2 RoomOffsetToLocation(Vector2 roomOffset)
        {
            return LoZHelpers.PauseMapRoomLocation
                + new Vector2(roomOffset.X * LoZHelpers.HorizontalPauseMapRoomOffset, roomOffset.Y * LoZHelpers.VerticalPauseMapRoomOffset);
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
    }
}
