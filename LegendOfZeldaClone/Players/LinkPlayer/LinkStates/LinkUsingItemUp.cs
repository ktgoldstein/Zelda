using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkUsingItemUp : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public LinkUsingItemUp(ILinkPlayer link, int frame = 0)
        {
            this.linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkUsingItemUpSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.UsingItemUp, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);

        public void Update()
        {
            linkSprite.Update();
            if (linkSprite.AnimationDone())
                linkPlayer.SetState(linkPlayer.GetStateStandingUp());
        }
    }
}
