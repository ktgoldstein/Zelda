using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class TunnelFaceDown: IDoor
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value - hurtBoxOffset; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }

        private readonly GameStateMachine game;
        private ISprite sprite;
        private readonly int height;
        private readonly int width;
        private readonly Vector2 hurtBoxOffset;

        public TunnelFaceDown(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            sprite = BlockSpriteFactory.Instance.CreateTunnelFaceDown();
            Location = location;
            height = 16;
            width = 32;
            hurtBoxOffset = new Vector2(0, LoZHelpers.Scale(16));
            BlockHeight = ObjectHeight.CanWalkOver;
            IsBombable = false;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.NextRoom = game.CurrentRoom.RoomDown;
                foreach (IBlock block in game.NextRoom.Blocks)
                {
                    if (block is BombableWallUp)
                    {
                        game.NextRoom.Blocks.Remove(block);
                        break;
                    }
                }
                game.NextRoom.LoadRoom();
                game.RoomCamera.CameraTransition(Direction.Down, GameState.ScreenTransition);
                game.HUDMap.UpdateLinkMapLocation(Direction.Down);
                game.PauseMap.MoveRooms(Direction.Down);
            }
        }
        public void Die() { }
    }
}
