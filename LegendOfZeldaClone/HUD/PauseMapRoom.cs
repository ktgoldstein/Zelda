using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class PauseMapRoom 
    {
        private ISprite roomSprite;
        private Vector2 Location;

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
