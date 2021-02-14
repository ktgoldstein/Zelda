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
        public ISprite CreatedefaultFlatBlock()
        {
            return new FlatBlock(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateflatBlock()
        {
            return new FlatBlock(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateraisedBlock()
        {
            return new RaisedBlock(objectSpriteSheet, 16, 16);
        }
        public ISprite Createstatue()
        {
            return new Statue(objectSpriteSheet, 16, 16);
        }
        public ISprite Createstatue2()
        {
            return new Statue2(objectSpriteSheet, 16, 16);
        }
        public ISprite CreateblueStatue()
        {
            return new blueStatue(objectSpriteSheet, 16, 16);
        }
        //public ISprite CreateblueStatue2()
        //{
        //    return new blueStatue2(objectSpriteSheet, 32, 32);
        //}
        //public ISprite Createsand()
        //{
        //    return new sand(objectSpriteSheet, 32, 32);
        //}
        //public ISprite Createstairs()
        //{
        //    return new stairs(objectSpriteSheet, 32, 32);
        //}
        //public ISprite Createwater()
        //{
        //    return new water(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatekeyDoorUp()
        //{
        //    return new keyDoorUp(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatekeyDoorDown()
        //{
        //    return new keyDoorDown(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatekeyDoorRight()
        //{
        //    return new keyDoorRight(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatekeyDoorLeft()
        //{
        //    return new keyDoorLeft(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatelockedDoorUp()
        //{
        //    return new lockedDoorUp(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatelockedDoorDown()
        //{
        //    return new lockedDoorDown(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatelockedDoorRight()
        //{
        //    return new lockedDoorRight(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreatelockedDoorLeft()
        //{
        //    return new lockedDoorLeft(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreateopenDoorUp()
        //{
        //    return new openDoorUp(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreateopenDoorDown()
        //{
        //    return new openDoorDown(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreateopenDoorLeft()
        //{
        //    return new openDoorLeft(objectSpriteSheet, 32, 32);
        //}
        //public ISprite CreateopenDoorRight()
        //{
        //    return new openDoorDown(objectSpriteSheet, 32, 32);
        //}
    }
}
