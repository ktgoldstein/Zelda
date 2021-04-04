using System.Collections.Generic;

namespace LegendOfZeldaClone
{
    public class PlayerInventory 
    {
        public int BombsHeld
        {
            get { return bombsHeld; }
            set
            {
                bombsHeld = value < 0 ? 0 : value;
                bombsHeld = value > 8 ? 8 : value;
            }
        }
        public int KeysHeld
        {
            get { return keysHeld; }
            set { keysHeld = value < 0 ? 0 : value; }
        }
        public int RupeesHeld
        {
            get { return rupeesHeld; }
            set { rupeesHeld = value < 0 ? 0 : value; }
        }
        public bool HasMap { get; set; } = false;
        public bool HasCompass { get; set; } = false;
        public bool HasArrow { get; set; } = false;

        private int bombsHeld;
        private int keysHeld;
        private int rupeesHeld;
        public Dictionary<UsableItemTypes, IUsableItem> heldItems;

        public PlayerInventory(int bombs, int keys, int rupees, bool hasMap, bool hasCompass)
        {
            BombsHeld = bombs;
            KeysHeld = keys;
            RupeesHeld = rupees;
            HasMap = hasMap;
            HasCompass = hasCompass;

            heldItems = new Dictionary<UsableItemTypes, IUsableItem>();
        }

        public void AddItem(UsableItemTypes itemType, GameStateMachine game)
        {
            if (!heldItems.ContainsKey(itemType))
            {
                switch (itemType)
                {
                    case UsableItemTypes.BlueCandle:
                        heldItems.Add(itemType, new UsableBlueCandle(game));
                        break;
                    case UsableItemTypes.BlueRing:
                        heldItems.Add(itemType, new UsableBlueRing(game));
                        break;
                    case UsableItemTypes.Bomb:
                        heldItems.Add(itemType, new UsableBomb(game));
                        break;
                    case UsableItemTypes.BoomerangNormal:
                        heldItems.Add(itemType, new UsableBoomerang(game, BoomerangSkinType.Normal));
                        break;
                    case UsableItemTypes.BoomerangMagic:
                        heldItems.Add(itemType, new UsableBoomerang(game, BoomerangSkinType.Magical));
                        break;
                    case UsableItemTypes.BowWooden:
                        heldItems.Add(itemType, new UsableBow(game, ArrowSkinType.Wooden));
                        break;
                    case UsableItemTypes.BowSilver:
                        heldItems.Add(itemType, new UsableBow(game, ArrowSkinType.Silver));
                        break;
                    case UsableItemTypes.LifePotion:
                        heldItems.Add(itemType, new UsablePotion(game));
                        break;
                }
            }
        }

        public IUsableItem GetItem(UsableItemTypes itemType) => heldItems[itemType];
        public bool HasItem(UsableItemTypes itemTypes) => heldItems.ContainsKey(itemTypes);
    }
}
