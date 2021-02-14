using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public abstract class LinkState
    {
        public abstract ILinkPlayer Link { get; set; }
        public abstract ILinkSprite Sprite { get; set; }

        public void MoveUp()
        {
            if (Sprite.AnimationDone())
                Link.SetState(Link.GetStateWalkingingUp());
        }

        public void MoveDown()
        {
            if (Sprite.AnimationDone())
                Link.SetState(Link.GetStateWalkingingDown());
        }

        public void MoveLeft()
        {
            if (Sprite.AnimationDone())
                Link.SetState(Link.GetStateWalkingingLeft());
        }

        public void MoveRight()
        {
            if (Sprite.AnimationDone())
                Link.SetState(Link.GetStateWalkingingRight());
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }

        public abstract void Action();
        public abstract void Damage();
        public abstract void Update(Vector2 location);
    }

    public class LinkStandingDown : LinkState
    {
        public override ILinkPlayer Link { get; set; }
        public override ILinkSprite Sprite { get; set; }

        public LinkStandingDown(ILinkPlayer link)
        {
            Link = link;
            Sprite = LinkSpriteFactory.Instance.CreateLinkStandingDownSprite(Link.SkinType);
        }

        public override void Action()
        {
            if (Sprite.AnimationDone())
                Link.SetState(Link.GetStateUsingItemDown());
        }

        public override void Damage() { }

        public override void Update(Vector2 location) { }
    }

    public class LinkStandingUp : LinkState
    {
        public LinkStandingUp(ILinkPlayer link)
        {

        }
    }

    public class LinkStandingLeft : LinkState
    {
        public LinkStandingLeft(ILinkPlayer link)
        {

        }
    }

    public class LinkStandingRight : LinkState
    {
        public LinkStandingRight(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingDown : LinkState
    {
        public LinkWalkingDown(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingUp : LinkState
    {
        public LinkWalkingUp(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingLeft : LinkState
    {
        public LinkWalkingLeft(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingRight : LinkState
    {
        public LinkWalkingRight(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemDown : LinkState
    {
        public LinkUsingItemDown(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemUp : LinkState
    {
        public LinkUsingItemUp(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemLeft : LinkState
    {
        public LinkUsingItemLeft(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemRight : LinkState
    {
        public LinkUsingItemRight(ILinkPlayer link)
        {

        }
    }

    public class LinkPickingUpItem : LinkState
    {
        public LinkPickingUpItem(LinkPlayer link)
        {

        }
    }
}
