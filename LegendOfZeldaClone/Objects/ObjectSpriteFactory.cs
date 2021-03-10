using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    class ObjectSpriteFactory
    {
        private Texture2D objectSpriteSheet;
        private Texture2D doorSpriteSheet;

        public static ObjectSpriteFactory Instance { get { return instance; } }


        private static ObjectSpriteFactory instance = new ObjectSpriteFactory();

        private ObjectSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            objectSpriteSheet = content.Load<Texture2D>("ZeldaObjects");
            doorSpriteSheet = content.Load<Texture2D>("Background");
        }
        public ISprite CreateFlatBlock()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 242, 148);
        }
        public ISprite CreateRaisedBlock()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 260, 129);
        }
        public ISprite CreateDragonStatue()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 318, 129);
        }
        public ISprite CreateGargoyleStatue()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 337, 129);
        }
        public ISprite CreateBlueDragonStatue()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 299, 129);
        }
        public ISprite CreateBlueGargoyleStatue()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 280, 129);
        }
        public ISprite CreateDottedBlock()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 356, 148);
        }
        public ISprite CreateStairs()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 299, 148);
        }
        public ISprite CreateDarkBlock()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 280, 148);
        }
        public ISprite CreateWater()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 261, 148);
        }
        public ISprite CreateStoneWall()
        {
            return new ObjectSprite(doorSpriteSheet, 16, 16, 985, 45);
        }
        public ISprite CreateLadder()
        {
            return new ObjectSprite(doorSpriteSheet, 16, 16, 1002, 45);
        }
        public ISprite CreateTunnelFaceUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 948, 11);
        }
        public ISprite CreateTunnelFaceDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 948, 110);
        }
        public ISprite CreateWallFaceUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 816, 11);
        }
        public ISprite CreateWallFaceDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 816, 110);
        }
        public ISprite CreateWallFaceRight()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 816, 77);
        }
        public ISprite CreateWallFaceLeft()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 816, 44);
        }
        public ISprite CreateKeyDoorUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 882, 11);
        }
        public ISprite CreateKeyDoorDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 882, 110);
        }
        public ISprite CreateKeyDoorRight()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 882, 77);
        }
        public ISprite CreateKeyDoorLeft()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 882, 44);
        }
        public ISprite CreateLockedDoorUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 915, 11);
        }
        public ISprite CreateLockedDoorDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 915, 110);
        }
        public ISprite CreateLockedDoorRight()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 915, 77);
        }
        public ISprite CreateLockedDoorLeft()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 915, 44);
        }
        public ISprite CreateOpenDoorUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 849, 11);
        }
        public ISprite CreateOpenDoorDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 849, 110);
        }
        public ISprite CreateOpenDoorRight()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 849, 77);
        }
        public ISprite CreateOpenDoorLeft()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 849, 44);
        }

    }
}