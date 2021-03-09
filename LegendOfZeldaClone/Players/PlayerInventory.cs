namespace LegendOfZeldaClone
{
    public class PlayerInventory 
    {
        public int BombsHeld { get; set; }
        public int KeysHeld { get; set; }
        public int RupeesHeld { get; set; }

        public PlayerInventory(int bombs, int keys, int rupees)
        {
            BombsHeld = bombs;
            KeysHeld = keys;
            RupeesHeld = rupees;
        }
    }
}
