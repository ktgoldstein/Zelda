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
            return new FlatBlock(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateRaisedBlock()
        {
            return new RaisedBlock(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateDragonStatue()
        {
            return new DragonStatue(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateGargoyleStatue()
        {
            return new GargoyleStatue(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateDragonStatueBlue()
        {
            return new DragonStatueBlue(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateGargoyleStatueBlue()
        {
            return new GargoyleStatueBlue(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateDottedBlock()
        {
            return new DottedBlock(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateStairs()
        {
            return new Stairs(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateDarkBlock()
        {
            return new DarkBlock(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateWater()
        {
            return new Water(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateTunnelOpeningUp()
        {
            return new TunnelOpeningUp(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateTunnelOpeningDown()
        {
            return new TunnelOpeningDown(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateKeyDoorUp()
        {
            return new KeyDoorUp(objectSpriteSheet, 32, 16);
        }
        public ISprite CreateKeyDoorDown()
        {
            return new KeyDoorDown(objectSpriteSheet, 32, 16);
        }
        public ISprite CreatekeyDoorRight()
        {
            return new KeyDoorRight(objectSpriteSheet, 16, 32);
        }
        public ISprite CreatekeyDoorLeft()
        {
            return new KeyDoorLeft(objectSpriteSheet, 16, 32);
        }
        public ISprite CreatelockedDoorUp()
        {
            return new LockedDoorUp(objectSpriteSheet, 32, 16);
        }
        public ISprite CreatelockedDoorDown()
        {
            return new LockedDoorDown(objectSpriteSheet, 32, 16);
        }
        public ISprite CreatelockedDoorRight()
        {
           return new LockedDoorRight(objectSpriteSheet, 16, 32);
        }
        public ISprite CreatelockedDoorLeft()
        {
            return new LockedDoorLeft(objectSpriteSheet, 16, 32);
        }
        public ISprite CreateOpenDoorUp()
        {
            return new OpenDoorUp(objectSpriteSheet, 32, 16);
        }
        public ISprite CreateOpenDoorDown()
        {
            return new OpenDoorDown(objectSpriteSheet, 32, 16);
        }
        public ISprite CreateOpenDoorRight()
        {
            return new OpenDoorRight(objectSpriteSheet, 16, 32);
        }
        public ISprite CreateOpenDoorLeft()
        {
            return new OpenDoorLeft(objectSpriteSheet, 16, 32);
        }
        
    }
}
