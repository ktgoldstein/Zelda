using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class HUDMap
    {
        public LinkOnMiniMap link;
        public TriForceOnMap triForce;
        public MiniMap miniMap;

        private bool hasMap;
        private bool hasCompass;

        private readonly GameStateMachine game;

        public HUDMap(GameStateMachine game)
        {
            this.game = game;

            miniMap = new MiniMap(LoZHelpers.MiniMapLocation, game);
            link = new LinkOnMiniMap(LoZHelpers.LinkLocationTrackerMini, game);
            triForce = new TriForceOnMap(LoZHelpers.TriForceLocation, game);
            hasCompass = game.Player.Inventory.HasMap;
            hasMap = game.Player.Inventory.HasCompass;  
        }

        public void Update() {

            hasMap = game.Player.Inventory.HasMap;
            hasCompass = game.Player.Inventory.HasCompass;

            if(hasCompass)
                triForce.Update();

            link.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (hasMap)
                miniMap.Draw(spriteBatch, LoZHelpers.MiniMapLocation);
            if (hasCompass)
                triForce.Draw(spriteBatch, LoZHelpers.TriForceLocation);

            link.Draw(spriteBatch);
        }

        public void UpdateLinkMapLocation(Direction direction) => link.moveLinkOnMiniMap(direction);

        public void Reset()
        {
            link.Reset();
        }
    }
}
