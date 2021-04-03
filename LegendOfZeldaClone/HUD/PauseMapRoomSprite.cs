using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class PauseMapRoomSprite : ISprite
    {
        private ISprite room;
        private Vector2 location;

        public PauseMapRoomSprite(PauseMapRoomType roomType, Vector2 location)
        {
            room = HUDTextureFactory.Instance.CreatePauseMapRooms(roomType);
            this.location = location;
        }

        public void Update() {}
        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => room.Draw(spriteBatch, location);

    }
}
