namespace LegendOfZeldaClone
{
    public interface IPlayer : IGameObject
    {
        public float Speed { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public Direction BlockingDirection { get; }
        public PlayerInventory Inventory { get; }
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void ActionA();
        public void ActionB();
        public void Damage(int amount, Direction direction);
        public void Heal(int amount);
        public void PickUpUsableItem(UsableItemTypes itemType, IItem item);
        public void Equip(UsableItemTypes itemType);
    }
}
