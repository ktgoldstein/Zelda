using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkStandingLeft : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingLeft(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingLeftSprite(link.SkinType, frame);
        }

        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemLeft());
            return Direction.Left;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingLeft, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }
}
