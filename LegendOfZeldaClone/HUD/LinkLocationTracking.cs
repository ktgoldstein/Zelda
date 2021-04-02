using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class LinkLocationTracking : ISprite
    {
        private readonly ISprite linkMapLocation;
        private Vector2 location;
        private readonly GameStateMachine game;

        public LinkLocationTracking(Vector2 location, GameStateMachine game)
        {
            linkMapLocation = HUDTextureFactory.Instance.CreateLocationTracker();
            this.location = location;
            this.game = game;
        }

        public void Update() {}

        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => linkMapLocation.Draw(spriteBatch, location);

        public void moveLinkOnMiniMap(Direction room)
        {
            switch (room)
            {
                case Direction.Left:
                    location.X -= LoZHelpers.RightLeftRoomMiniMapOffset + 2;
                    break;

                case Direction.Right:
                    location.X += LoZHelpers.RightLeftRoomMiniMapOffset + 2;
                    break;

                case Direction.Down:
                    location.Y += LoZHelpers.UpDownRoomMiniMapOffset + 2;
                    break;
                case Direction.Up:
                    location.Y -= LoZHelpers.UpDownRoomMiniMapOffset + 2;
                    break;

            }
        }
        public void moveLinkOnPauseMap(Direction room) { }
        
        public void Reset()
        {
            this.location = LoZHelpers.LinkLocationTrackerMini;
        }

    }
}
