using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkWalkingLeft : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public LinkWalkingLeft(ILinkPlayer link, int frame = 0)
        {
            this.linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeftSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            linkPlayer.SetState(linkPlayer.GetStateUsingItemLeft());
            return Direction.Left;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingLeft, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);

        public void Update()
        {
            linkPlayer.Location -= new Vector2(linkPlayer.Speed, 0);
            linkSprite.Update();
            if (linkSprite.AnimationDone())
                linkPlayer.SetState(linkPlayer.GetStateStandingLeft());
        }
    }
}
