using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class PauseMapRoom 
    {
        public Vector2 Location;

        private ISprite roomSprite;

        public PauseMapRoom(PauseMapRoomType type, Vector2 location)
        {
            roomSprite = HUDTextureFactory.Instance.CreatePauseMapRooms(type);
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            roomSprite.Draw(spriteBatch, Location);
        }
    }
}
