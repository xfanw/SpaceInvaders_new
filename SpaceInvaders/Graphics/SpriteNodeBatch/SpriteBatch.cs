using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    public class SpriteBatch : DLink
    {
        public enum Name
        {
            PacMan,
            AngryBirds,
            Boxes,
            Aliens,

            Uninitialized
        }

        public SpriteBatch()
            : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.pNodeMan = new SpriteNodeMan();
            Debug.Assert(this.pNodeMan != null);
        }


        public void Set(SpriteBatch.Name name, int reserveNum = 3, int reserveGrow = 1)
        {
            this.name = name;
        }
        public SpriteNode Attach(GameSprite.Name name)
        {
            SpriteNode pNode = this.pNodeMan.Attach(name);
            return pNode;
        }

        public SpriteNode Attach(BoxSprite pBox)
        {
            Debug.Assert(this.pNodeMan != null);
            SpriteNode pNode = this.pNodeMan.Attach(pBox);
            return pNode;
        }

        public SpriteNode Attach(ProxySprite pNode)
        {
            Debug.Assert(this.pNodeMan != null);
            SpriteNode pSBNode = this.pNodeMan.Attach(pNode);
            return pSBNode;
        }
        public void Wash()
        {
        }

        public void Dump()
        {
        }

        public void SetName(SpriteBatch.Name inName)
        {
            this.name = inName;
        }

        public SpriteBatch.Name GetName()
        {
            return this.name;
        }

        public SpriteNodeMan GetSpriteNodeMan()
        {
            return this.pNodeMan;
        }

        // Data -------------------------------
        public SpriteBatch.Name name;
        private readonly SpriteNodeMan pNodeMan;

    }
}

// End of File
