using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkWalkingDown : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingDown(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingDownSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemDown());
            return Direction.Down;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingDown, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location += new Vector2(0, link.Speed);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingDown());
        }
    }
}
