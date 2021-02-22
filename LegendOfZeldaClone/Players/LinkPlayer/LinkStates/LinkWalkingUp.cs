using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkWalkingUp : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingUp(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingUpSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemUp());
            return Direction.Up;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingUp, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location -= new Vector2(0, link.Speed);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingUp());
        }
    }
}
