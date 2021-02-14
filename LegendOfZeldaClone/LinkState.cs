using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public abstract class LinkState
    {
        public abstract ILinkPlayer Link { };
        public abstract ILinkSprite Sprite { };

        public void MoveUp()
        {
            if (sprite.AnimationDone())
                link.SetState(link.GetStateWalkingingUp());
        }

        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
    }

    public class LinkStandingDown : LinkState
    {
        private ILinkPlayer link;
        private ILinkSprite sprite;

        public LinkStandingDown(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingDownSprite(link.SkinType);
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            if (sprite.AnimationDone())
                link.SetState(link.GetStateWalkingingDown());
        }

        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
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
