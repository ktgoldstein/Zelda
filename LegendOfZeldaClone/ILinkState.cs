using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public LinkPlayer Link { get; set; }

        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
    }

    public class LinkNormalStandingDown : ILinkState
    {

    }

    // Simon edit after this comment

    public class LinkUsingItemDown : ILinkState
    {
        public LinkPlayer Link { get; set; }

        public LinkUsingItemDown(LinkPlayer link)
        {
            Link = link;
        }
    }

    public class LinkUsingItemUp : ILinkState
    {
        public LinkPlayer Link { get; set; }

        public LinkUsingItemUp(LinkPlayer link)
        {
            Link = link;
        }
    }

    public class LinkUsingItemLeft : ILinkState
    {
        public LinkPlayer Link { get; set; }

        public LinkUsingItemLeft(LinkPlayer link)
        {
            Link = link;
        }
    }

    public class LinkUsingItemRight : ILinkState
    {
        public LinkPlayer Link { get; set; }

        public LinkUsingItemRight(LinkPlayer link)
        {
            Link = link;
        }
    }

    public class LinkPickingUpItem : ILinkState
    {
        public LinkPlayer Link { get; set; }

        public LinkPickingUpItem(LinkPlayer link)
        {
            Link = link;
        }
    }
}
