using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
    }

    public class LinkStandingDown : ILinkState
    {
        private ILinkPlayer link;

        public LinkStandingDown(ILinkPlayer link)
        {
            this.link = link;
        }

        public void MoveUp()
        {

        }
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
    }

    public class LinkStandingUp : ILinkState
    {
        public LinkStandingUp(ILinkPlayer link)
        {

        }
    }

    public class LinkStandingLeft : ILinkState
    {
        public LinkStandingLeft(ILinkPlayer link)
        {

        }
    }

    public class LinkStandingRight : ILinkState
    {
        public LinkStandingRight(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingDown : ILinkState
    {
        public LinkWalkingDown(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingUp : ILinkState
    {
        public LinkWalkingUp(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingLeft : ILinkState
    {
        public LinkWalkingLeft(ILinkPlayer link)
        {

        }
    }

    public class LinkWalkingRight : ILinkState
    {
        public LinkWalkingRight(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemDown : ILinkState
    {
        public LinkUsingItemDown(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemUp : ILinkState
    {
        public LinkUsingItemUp(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemLeft : ILinkState
    {
        public LinkUsingItemLeft(ILinkPlayer link)
        {

        }
    }

    public class LinkUsingItemRight : ILinkState
    {
        public LinkUsingItemRight(ILinkPlayer link)
        {

        }
    }

    public class LinkPickingUpItem : ILinkState
    {
        public LinkPickingUpItem(LinkPlayer link)
        {

        }
    }
}
