using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;


namespace LegendOfZeldaClone.Objects
{
    public class OpenDoorRight : IDoor
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }

        private readonly GameStateMachine game;
        private ISprite openDoorRight;
        private readonly int height;
        private readonly int width;
        private readonly Vector2 hurtBoxOffset;

        public OpenDoorRight(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            openDoorRight = ObjectSpriteFactory.Instance.CreateOpenDoorRight();
            Location = location;
            height = 32;
            width = 8;
            hurtBoxOffset = new Vector2(LoZHelpers.Scale(32 - width), 0);
            BlockHeight = ObjectHeight.CanWalkOver;
            IsBombable = false;
            Alive = true;
        }
        
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => openDoorRight.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.NextRoom = game.CurrentRoom.RoomRight;
                foreach (IObject block in game.NextRoom.Blocks)
                {
                    if (block is LockedDoorLeft)
                    {
                        game.NextRoom.Blocks.Remove(block);
                        break;
                    }
                }
                game.NextRoom.LoadRoom();
                game.Camera.CameraTransition(Direction.Right);
                game.HUDMap.UpdateLinkMapLocation(Direction.Right);
                game.PauseMap.MoveRooms(Direction.Right);
            }
        }
        public void Die() { }
    }
}