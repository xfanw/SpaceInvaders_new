using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNode : DLink
    {

        public SpriteNode()
            : base()
        {
            this.pSpriteBase = null;
        }

        public void Set(GameSprite.Name name)
        {
            // Go find it
            this.pSpriteBase = GameSpriteMan.Find(name);
            Debug.Assert(this.pSpriteBase != null);
        }

        public void Set(BoxSprite pBox)
        {
            this.pSpriteBase = pBox;
            Debug.Assert(this.pSpriteBase != null);
        }

        public void Set(ProxySprite pProxy)
        {
            this.pSpriteBase = pProxy;

            Debug.Assert(this.pSpriteBase != null);
        }

        public SpriteBase GetSpriteBase()
        {
            return this.pSpriteBase;
        }

        public void Wash()
        {
            this.pSpriteBase = null;
        }

        // Data: ----------------------------------------------
        public SpriteBase pSpriteBase;
    }
}

// End of File
