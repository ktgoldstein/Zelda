using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class LocationTrackingMini : ISprite
    {
        private readonly ISprite linkMapLocation;
        private Vector2 location;
        private readonly GameStateMachine game;

        public LocationTrackingMini(Vector2 location, GameStateMachine game)
        {
            linkMapLocation = HUDTextureFactory.Instance.CreateLocationTracker();
            this.location = location;
            this.game = game;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => linkMapLocation.Draw(spriteBatch, location);

        public void moveLinkOnMiniMap(Direction room)
        {
            switch (room)
            {
                case Direction.Left:
                    location.X -= LoZHelpers.RightLeftRoomMapOffset + 2;
                    break;

                case Direction.Right:
                    location.X += LoZHelpers.RightLeftRoomMapOffset + 2;
                    break;

                case Direction.Down:
                    location.Y += LoZHelpers.UpDownRoomMapOffset + 2;
                    break;
                case Direction.Up:
                    location.Y -= LoZHelpers.UpDownRoomMapOffset + 2;
                    break;

            }
        }
        
        public void Reset()
        {
            this.location = LoZHelpers.LinkLocationTrackerMini;
        }

    }
}
