using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNodeMan : Manager
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteNodeMan(int reserveNum = 3, int reserveGrow = 1)
        : base(reserveNum, reserveGrow) // <--- Kick the can (delegate)
        {

        }

        //----------------------------------------------------------------------
        // public Methods
        //----------------------------------------------------------------------
        public SpriteNode Attach(GameSprite.Name name)
        {
            SpriteNode pNode = (SpriteNode)this.baseAdd();
            Debug.Assert(pNode != null);

            // Initialize SpriteBatchNode
            pNode.Set(name);

            return pNode;
        }


        public SpriteNode Attach(BoxSprite pBox)
        {
            SpriteNode pNode = (SpriteNode)this.baseAdd();
            Debug.Assert(pNode != null);

            // Initialize SpriteBatchNode
            pNode.Set(pBox);

            return pNode;
        }

        public SpriteNode Attach(ProxySprite pProxy)
        {
            SpriteNode pNode = (SpriteNode)this.baseAdd();
            Debug.Assert(pNode != null);

            // Initialize SpriteBatchNode
            pNode.Set(pProxy);

            return pNode;
        }
        public void Draw()
        {
            
            DLink pNode = this.poActive;

            while (pNode != null)
            {
                ((SpriteNode)pNode).pSpriteBase.Render();
                pNode = pNode.pNext;
            }
        }
        public void Remove(SpriteNode pNode)
        {
            Debug.Assert(pNode != null);
            this.baseRemove(pNode);
            pNode.Wash();
        }
        public void Dump()
        {
            this.baseDump();
        }
        protected override DLink derivedCreate()
        {
            DLink pNode = new SpriteNode();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SpriteNode pData = (SpriteNode)pLink;
            // pData.Dump();
        }

    }
}
