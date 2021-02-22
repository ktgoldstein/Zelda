using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkWalkingRight : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingRight(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingRightSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemRight());
            return Direction.Right;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingRight, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location += new Vector2(link.Speed, 0);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingRight());
        }
    }
}
