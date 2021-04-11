using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class HUDMap
    {
        private Vector2 linkLocation;
        private ISprite link;

        private Vector2 miniMapLocation;
        private ISprite miniMap;

        private Vector2 triForceOnMap;
        private ISprite triForce;


        private bool hasMap { get { return game.Player.Inventory.HasMap; } }
        private bool hasCompass { get { return game.Player.Inventory.HasCompass; } }

        private readonly GameStateMachine game;

        public HUDMap(GameStateMachine game)
        {
            this.game = game;

            miniMapLocation = LoZHelpers.MiniMapLocation;
            miniMap = HUDTextureFactory.Instance.CreateMiniMap();

            linkLocation = LoZHelpers.LinkLocationTrackerMini;
            link = HUDTextureFactory.Instance.CreateLocationTracker();

            triForceOnMap = LoZHelpers.TriForceLocation;
            triForce = HUDTextureFactory.Instance.CreateTriForceIndicator();

        }

        public void Update() {
            if(hasCompass)
                triForce.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (hasMap)
                miniMap.Draw(spriteBatch, miniMapLocation);
            if (hasCompass)
                triForce.Draw(spriteBatch, triForceOnMap);

            link.Draw(spriteBatch, linkLocation);
        }

        public void UpdateLinkMapLocation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    linkLocation.X -= LoZHelpers.RightLeftRoomMiniMapOffset;
                    break;

                case Direction.Right:
                    linkLocation.X += LoZHelpers.RightLeftRoomMiniMapOffset;
                    break;

                case Direction.Down:
                    linkLocation.Y += LoZHelpers.UpDownRoomMiniMapOffset;
                    break;
                case Direction.Up:
                    linkLocation.Y -= LoZHelpers.UpDownRoomMiniMapOffset;
                    break;
            }
        }

        public void Reset()
        {
            linkLocation = LoZHelpers.LinkLocationTrackerMini;
        }
    }
}
