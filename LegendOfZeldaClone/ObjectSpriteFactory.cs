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
            return new Object(objectSpriteSheet, 16, 16, 242, 148);
        }
        public ISprite CreateRaisedBlock()
        {
            return new Object(objectSpriteSheet, 16, 16, 260, 129);
        }
        public ISprite CreateDragonStatue()
        {
            return new Object(objectSpriteSheet, 16, 16, 318, 129);
        }
        public ISprite CreateGargoyleStatue()
        {
            return new Object(objectSpriteSheet, 16, 16, 337, 129);
        }
        public ISprite CreateDragonStatueBlue()
        {
            return new Object(objectSpriteSheet, 16, 16, 299, 129);
        }
        public ISprite CreateGargoyleStatueBlue()
        {
            return new Object(objectSpriteSheet, 16, 16, 280, 129);
        }
        public ISprite CreateDottedBlock()
        {
            return new Object(objectSpriteSheet, 16, 16, 356, 148);
        }
        public ISprite CreateStairs()
        {
            return new Object(objectSpriteSheet, 16, 16, 299, 148);
        }
        public ISprite CreateDarkBlock()
        {
            return new Object(objectSpriteSheet, 16, 16, 280, 148);
        }
        public ISprite CreateWater()
        {
            return new Object(objectSpriteSheet, 16, 16, 261, 148);
        }
        public ISprite CreateTunnelOpeningUp()
        {
            return new Object(objectSpriteSheet, 16, 16, 242, 110);
        }
        public ISprite CreateTunnelOpeningDown()
        {
            return new Object(objectSpriteSheet, 16, 16, 261, 110);
        }
        public ISprite CreateKeyDoorUp()
        {
            return new Object(objectSpriteSheet, 16, 32, 243, 86);
        }
        public ISprite CreateKeyDoorDown()
        {
            return new Object(objectSpriteSheet, 16, 32, 279, 86);
        }
        public ISprite CreatekeyDoorRight()
        {
            return new Object(objectSpriteSheet, 32, 16, 314, 74);
        }
        public ISprite CreatekeyDoorLeft()
        {
            return new Object(objectSpriteSheet, 32, 16, 337, 74);
        }
        public ISprite CreatelockedDoorUp()
        {
            return new Object(objectSpriteSheet, 16, 32, 243, 49);
        }
        public ISprite CreatelockedDoorDown()
        {
            return new Object(objectSpriteSheet, 16, 32, 279, 49);
        }
        public ISprite CreatelockedDoorRight()
        {
            return new Object(objectSpriteSheet, 32, 16, 314, 37);
        }
        public ISprite CreatelockedDoorLeft()
        {
            return new Object(objectSpriteSheet, 32, 16, 337, 37);
        }
        public ISprite CreateOpenDoorUp()
        {
            return new Object(objectSpriteSheet, 16, 32, 243, 12);
        }
        public ISprite CreateOpenDoorDown()
        {
            return new Object(objectSpriteSheet, 16, 32, 279, 12);
        }
        public ISprite CreateOpenDoorRight()
        {
            return new Object(objectSpriteSheet, 32, 16, 314, 0);
        }
        public ISprite CreateOpenDoorLeft()
        {
            return new Object(objectSpriteSheet, 32, 16, 337, 0);
        }

    }
}