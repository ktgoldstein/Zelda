using System.Collections.Generic;

namespace LegendOfZeldaClone
{
    public class PlayerInventory 
    {
        public int BombsHeld { get; set; }
        public int KeysHeld { get; set; }
        public int RupeesHeld { get; set; }

        private Dictionary<UsableItemTypes, IUsableItem> heldItems;

        public PlayerInventory(int bombs, int keys, int rupees)
        {
            BombsHeld = bombs;
            KeysHeld = keys;
            RupeesHeld = rupees;

            heldItems = new Dictionary<UsableItemTypes, IUsableItem>();
        }

        public void AddItem(UsableItemTypes itemType, LegendOfZeldaDungeon game)
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
                }
            }
        }

        public IUsableItem GetItem(UsableItemTypes itemType) => heldItems[itemType];
    }
}
