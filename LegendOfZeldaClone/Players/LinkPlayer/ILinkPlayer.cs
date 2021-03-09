namespace LegendOfZeldaClone
{
    public interface ILinkPlayer : IPlayer
    {
        public IUsableItem Sword { get; set; }
        public IUsableItem HeldItem { get; set; }
        public LinkSkinType SkinType { get; set; }
        public void SetState(ILinkState linkState);
        public ILinkState GetStateStandingDown();
        public ILinkState GetStateStandingUp();
        public ILinkState GetStateStandingLeft();
        public ILinkState GetStateStandingRight();
        public ILinkState GetStateWalkingingDown();
        public ILinkState GetStateWalkingingUp();
        public ILinkState GetStateWalkingingLeft();
        public ILinkState GetStateWalkingingRight();
        public ILinkState GetStateUsingItemDown();
        public ILinkState GetStateUsingItemUp();
        public ILinkState GetStateUsingItemLeft();
        public ILinkState GetStateUsingItemRight();
        public ILinkState GetStatePickingUpItem(IItem item);
    }
}
