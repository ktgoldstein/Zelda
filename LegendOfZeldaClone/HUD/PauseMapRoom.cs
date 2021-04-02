using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class PauseMapRoom 
    {
        public bool Visited {get; set;}
        private ISprite roomSprite;
        private Vector2 location;

        public PauseMapRoom(PauseMapRoomType type)
        {
            roomSprite = HUDTextureFactory.Instance.CreatePauseMapRooms(type);
            Visited = false;
            location = LoZHelpers.PauseMapRoomLocation;
        }

        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visited)
                roomSprite.Draw(spriteBatch, location);
        }

        public void placeRoomWhenVisited(Direction room)
        {
            Visited = true;
            switch (room)
            {
                case Direction.Left:
                    location.X -= LoZHelpers.RightLeftRoomPauseMapOffset;

                    break;

                case Direction.Right:
                    location.X += LoZHelpers.RightLeftRoomPauseMapOffset;

                    break;

                case Direction.Down:
                    location.Y += LoZHelpers.UpDownRoomPauseMapOffset;

                    break;
                case Direction.Up:
                    location.Y -= LoZHelpers.UpDownRoomPauseMapOffset;

                    break;
            }
        }

    }
}
