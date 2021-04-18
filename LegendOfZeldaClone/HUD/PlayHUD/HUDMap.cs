using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.LevelLoading;

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


        private bool HasMap { get { return game.Player.Inventory.HasMap; } }
        private bool HasCompass { get { return game.Player.Inventory.HasCompass; } }

        private readonly GameStateMachine game;

        public HUDMap(GameStateMachine game)
        {
            this.game = game;

            miniMapLocation = LoZHelpers.MiniMapLocation;
            miniMap = HUDTextureFactory.Instance.CreateMiniMap();

            linkLocation = LoZHelpers.HUDMapLinkStartingLocation;
            link = HUDTextureFactory.Instance.CreateLocationTrackerHUD();

            triForceOnMap = LoZHelpers.TriForceLocation;
            triForce = HUDTextureFactory.Instance.CreateTriForceIndicator();

        }

        public void Update() {
            if(HasCompass)
                triForce.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (HasMap)
                miniMap.Draw(spriteBatch, miniMapLocation);
            if (HasCompass)
                triForce.Draw(spriteBatch, triForceOnMap);

            link.Draw(spriteBatch, linkLocation);
        }

        public void UpdateLink(Room targetRoom)
        {
            linkLocation = LoZHelpers.HUDMapLinkStartingLocation
                + new Vector2(targetRoom.RoomOffset.X * LoZHelpers.HUDMapHorizontalRoomOffset,
                              targetRoom.RoomOffset.Y * LoZHelpers.HUDMapVerticalRoomOffset);
        }

        public void Reset()
        {
            linkLocation = LoZHelpers.HUDMapLinkStartingLocation;
        }
    }
}
