using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    class ObjectSpriteFactory
    {
        private Texture2D objectSpriteSheet;
        private Texture2D doorSpriteSheet;

        private static ObjectSpriteFactory instance = new ObjectSpriteFactory();

        public static ObjectSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ObjectSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            objectSpriteSheet = content.Load<Texture2D>("ZeldaObjects");
            doorSpriteSheet = content.Load<Texture2D>("WallsDoorBackground");
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
        public ISprite CreateTunnelFaceUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 947, 11);
        }
        public ISprite CreateTunnelFaceDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 947, 110);
        }
        public ISprite CreateWallFaceUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 815, 11);
        }
        public ISprite CreateWallFaceDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 815, 110);
        }
        public ISprite CreateWallFaceRight()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 815, 77);
        }
        public ISprite CreateWallFaceLeft()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 815, 44);
        }
        public ISprite CreateKeyDoorUp()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 32, 243, 86);
        }
        public ISprite CreateKeyDoorDown()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 32, 279, 86);
        }
        public ISprite CreateKeyDoorRight()
        {
            return new ObjectSprite(objectSpriteSheet, 32, 16, 314, 74);
        }
        public ISprite CreateKeyDoorLeft()
        {
            return new ObjectSprite(objectSpriteSheet, 32, 16, 337, 74);
        }
        public ISprite CreateLockedDoorUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 881, 11);
        }
        public ISprite CreateLockedDoorDown()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 32, 279, 49);
        }
        public ISprite CreateLockedDoorRight()
        {
            return new ObjectSprite(objectSpriteSheet, 32, 16, 314, 37);
        }
        public ISprite CreateLockedDoorLeft()
        {
            return new ObjectSprite(objectSpriteSheet, 32, 16, 337, 37);
        }
        public ISprite CreateOpenDoorUp()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 848, 11);
        }
        public ISprite CreateOpenDoorDown()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 848, 110);
        }
        public ISprite CreateOpenDoorRight()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 848, 77);
        }
        public ISprite CreateOpenDoorLeft()
        {
            return new ObjectSprite(doorSpriteSheet, 32, 32, 848, 44);
        }

    }
}