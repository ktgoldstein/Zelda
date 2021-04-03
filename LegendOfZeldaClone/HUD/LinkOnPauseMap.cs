using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class LinkOnPauseMap
    {
        private readonly ISprite linkOnMap;
        private Vector2 linkPauseLocation;
        private readonly GameStateMachine game;

        public LinkOnPauseMap(Vector2 location, GameStateMachine game)
        {
            linkOnMap = HUDTextureFactory.Instance.CreateLocationTracker();
            linkPauseLocation = location;
            this.game = game;
        }

        public void Update() {}

        public void Draw(SpriteBatch spriteBatch)
        {
            linkOnMap.Draw(spriteBatch, linkPauseLocation);
        }

        public void moveLinkOnPauseMap(Direction room)
        {
            
            switch (room)
            {
                case Direction.Left:
                    linkPauseLocation.X -= LoZHelpers.RightLeftRoomPauseMapOffset;
                    break;

                case Direction.Right:
                    linkPauseLocation.X += LoZHelpers.RightLeftRoomPauseMapOffset;
                    break;

                case Direction.Down:
                    linkPauseLocation.Y += LoZHelpers.UpDownRoomPauseMapOffset;
                    break;
                case Direction.Up:
                    linkPauseLocation.Y -= LoZHelpers.UpDownRoomPauseMapOffset;
                    break;
            }
        }
        public void Reset()
        {
            this.linkPauseLocation = LoZHelpers.LinkLocationTrackerPause;
        }

    }
}
