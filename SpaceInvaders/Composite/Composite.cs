using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        public Composite()
        {
            this.holder = Container.COMPOSITE;
            this.poHead = null;
            this.poLast = null;
            Debug.Write(" creating--> ");
            this.Dump();
        }
        public Composite(GameObject.Name gameName)
: base(GameSprite.Name.Sprite_NullObject, gameName)
        {
            this.holder = Container.COMPOSITE;
            this.poHead = null;
            this.poLast = null;
            Debug.Write(" creating--> ");
            this.Dump();
        }


        public override void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            this.privAddToEnd(ref this.poHead, ref this.poLast, pComponent);
            pComponent.pParent = this;
        }

        public override void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            this.privRemoveNode(ref this.poHead, ref poLast, pComponent);
        }

        protected void baseUpdateBoundingBox(/*Component pStart*/)
        {
            //GameObject pNode = (GameObject)pStart;

            // point to ColTotal
            CollisionRect ColTotal = GetCollisionObject().poCollisionRect;

            // Get the first child
            GameObject pNode = (GameObject)Iterator.GetChild(this);

            // Initialized the union to the first block
            ColTotal.Set(pNode.GetCollisionObject().poCollisionRect);

            // loop through sliblings
            while (pNode != null)
            {
                ColTotal.Union(pNode.GetCollisionObject().poCollisionRect);

                // go to next sibling
                pNode = (GameObject)Iterator.GetSibling(pNode);
            }

            //this.poColObj.poColRect.Set(201, 201, 201, 201);
            this.x = this.GetCollisionObject().poCollisionRect.x;
            this.y = this.GetCollisionObject().poCollisionRect.y;

            //  Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", ColTotal.x, ColTotal.y, ColTotal.width, ColTotal.height);
        }
        public override void Print()
        {
            DLink pNode = this.poHead;

            while (pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.Print();

                pNode = pNode.pNext;
            }
        }

        override public void Dump()
        {
            if (Iterator.GetParent(this) != null)
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:{1} <---- Composite", this.GetName(), ((Composite)Iterator.GetParent(this)).GetName());
            }
            else
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:null <---- Composite", this.GetName());
            }
        }

        private void privRemoveNode(ref DLink pHead,  ref DLink pLast, DLink pLink)
        {
            // protection
            Debug.Assert(pHead != null);
            Debug.Assert(pLink != null);


            if (pLink.pPrev != null)
            {
                pLink.pPrev.pNext = pLink.pNext;
            }
            else
            {  // first
                pHead = pLink.pNext;
            }

            if (pLink.pNext != null)
            {
                pLink.pNext.pPrev = pLink.pPrev;
            } else
            {
                pLast = pLink.pPrev;
            }

            pLink.Clear();

            // make sure its disconnected
            Debug.Assert(pLink.pNext == null);
            Debug.Assert(pLink.pPrev == null);
        }
        private void privAddToEnd(ref DLink pHead, ref DLink pLast, DLink pNode)
        {
            Debug.Assert(pNode != null);

            // add node
            if (pHead == null)
            {                
                pHead = pNode;
                pLast = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                pLast.pNext = pNode;
                pNode.pPrev = pLast;

                pLast = pNode;
                pLast.pNext = null;
            }

            Debug.Assert(pHead != null);
            Debug.Assert(pLast != null);
        }

        public override Component GetFirstChild()
        {
            return (Component)poHead;
        }
        // Data : ---------
        private DLink poHead;
        public DLink poLast;
    }
}
