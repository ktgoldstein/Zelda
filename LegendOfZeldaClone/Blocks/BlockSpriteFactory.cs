using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    class BlockSpriteFactory
    {
        private Texture2D objectSpriteSheet;
        private Texture2D doorSpriteSheet;

        public static BlockSpriteFactory Instance { get; } = new BlockSpriteFactory();
        private BlockSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            objectSpriteSheet = content.Load<Texture2D>("ZeldaObjects");
            doorSpriteSheet = content.Load<Texture2D>("Background");
        }
        public ISprite CreateFlatBlock()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 242, 148);
        }
        public ISprite CreateRaisedBlock()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 260, 129);
        }
        public ISprite CreateDragonStatue()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 318, 129);
        }
        public ISprite CreateGargoyleStatue()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 337, 129);
        }
        public ISprite CreateBlueDragonStatue()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 299, 129);
        }
        public ISprite CreateBlueGargoyleStatue()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 280, 129);
        }
        public ISprite CreateDottedBlock()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 356, 148);
        }
        public ISprite CreateStairs()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 299, 148);
        }
        public ISprite CreateDarkBlock()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 280, 148);
        }
        public ISprite CreateWater()
        {
            return new BlockSprite(objectSpriteSheet, 16, 16, 261, 148);
        }
        public ISprite CreateStoneWall()
        {
            return new BlockSprite(doorSpriteSheet, 16, 16, 985, 45);
        }
        public ISprite CreateLadder()
        {
            return new BlockSprite(doorSpriteSheet, 16, 16, 1002, 45);
        }
        public ISprite CreateTunnelFaceUp()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 948, 11);
        }
        public ISprite CreateTunnelFaceDown()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 948, 110);
        }
        public ISprite CreateWallFaceUp()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 816, 11);
        }
        public ISprite CreateWallFaceDown()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 816, 110);
        }
        public ISprite CreateWallFaceRight()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 816, 77);
        }
        public ISprite CreateWallFaceLeft()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 816, 44);
        }
        public ISprite CreateKeyDoorUp()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 882, 11);
        }
        public ISprite CreateKeyDoorDown()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 882, 110);
        }
        public ISprite CreateKeyDoorRight()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 882, 77);
        }
        public ISprite CreateKeyDoorLeft()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 882, 44);
        }
        public ISprite CreateLockedDoorUp()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 915, 11);
        }
        public ISprite CreateLockedDoorDown()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 915, 110);
        }
        public ISprite CreateLockedDoorRight()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 915, 77);
        }
        public ISprite CreateLockedDoorLeft()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 915, 44);
        }
        public ISprite CreateOpenDoorUp()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 849, 11);
        }
        public ISprite CreateOpenDoorDown()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 849, 110);
        }
        public ISprite CreateOpenDoorRight()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 849, 77);
        }
        public ISprite CreateOpenDoorLeft()
        {
            return new BlockSprite(doorSpriteSheet, 32, 32, 849, 44);
        }
        public ISprite CreateBlueSwitch()
        {
            return new OrbSprite(objectSpriteSheet, 16, 8, 378, 59);
        }
    }
}