using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    class ObjectSpriteFactory
    {
        private Texture2D objectSpriteSheet;

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
            return new ObjectSprite(objectSpriteSheet, 16, 16, 242, 110);
        }
        public ISprite CreateTunnelFaceDown()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 16, 261, 110);
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
            return new ObjectSprite(objectSpriteSheet, 16, 32, 243, 49);
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
            return new ObjectSprite(objectSpriteSheet, 16, 32, 243, 12);
        }
        public ISprite CreateOpenDoorDown()
        {
            return new ObjectSprite(objectSpriteSheet, 16, 32, 279, 12);
        }
        public ISprite CreateOpenDoorRight()
        {
            return new ObjectSprite(objectSpriteSheet, 32, 16, 314, 0);
        }
        public ISprite CreateOpenDoorLeft()
        {
            return new ObjectSprite(objectSpriteSheet, 32, 16, 337, 0);
        }

    }
}