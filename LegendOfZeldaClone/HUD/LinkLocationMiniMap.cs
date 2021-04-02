using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class LinkLocationMiniMap
    {
        private readonly ISprite linkOnMap;
        private Vector2 linkMiniLocation;
        private readonly GameStateMachine game;

        public LinkLocationMiniMap(Vector2 location, GameStateMachine game)
        {
            linkOnMap = HUDTextureFactory.Instance.CreateLocationTracker();
            linkMiniLocation = location;
            this.game = game;
        }

        public void Update() {}

        public void Draw(SpriteBatch spriteBatch)
        {
            linkOnMap.Draw(spriteBatch, linkMiniLocation);
        }

        public void moveLinkOnMiniMap(Direction room)
        {
            switch (room)
            {
                case Direction.Left:
                    linkMiniLocation.X -= LoZHelpers.RightLeftRoomMiniMapOffset + 2;
                    break;

                case Direction.Right:
                    linkMiniLocation.X += LoZHelpers.RightLeftRoomMiniMapOffset + 2;
                    break;

                case Direction.Down:
                    linkMiniLocation.Y += LoZHelpers.UpDownRoomMiniMapOffset + 2;
                    break;
                case Direction.Up:
                    linkMiniLocation.Y -= LoZHelpers.UpDownRoomMiniMapOffset + 2;
                    break;
            }
        }
        
        public void Reset()
        {
            this.linkMiniLocation = LoZHelpers.LinkLocationTrackerMini;
        }

    }
}
