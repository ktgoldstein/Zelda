namespace LegendOfZeldaClone
{
    public interface ILinkSprite : ISprite
    {
        public int CurrentFrame { get; set; }
        public bool AnimationDone();
        public void Reset();
    }
}
