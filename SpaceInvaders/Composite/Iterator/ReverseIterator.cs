using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ReverseIterator : Iterator
    {
        public ReverseIterator(Component pStart)
        {
            Debug.Assert(pStart != null);
            Debug.Assert(pStart.holder == Component.Container.COMPOSITE);

            // Horrible HACK need to clean up.. but its late
            ForwardIterator it = new ForwardIterator(pStart);

            this.pRoot = pStart;
            this.pCurr = this.pRoot;
            this.pPrev = null;

            Component pPrevNode = this.pRoot;

            // Initialize the reverse pointer
            Component pNode = it.First();

            while (!it.IsDone())
            {
                // Squirrel away
                pPrevNode = pNode;

                // Advance
                pNode = it.Next();

                if (pNode != null)
                {
                    pNode.pReverse = pPrevNode;
                }
            }

            pRoot.pReverse = pPrevNode;

        }

        override public Component First()
        {
            Debug.Assert(this.pRoot != null);

            this.pCurr = this.pRoot.pReverse;

            return this.pCurr;
        }

        override public Component Next()
        {
            Debug.Assert(this.pCurr != null);

            this.pPrev = this.pCurr;
            this.pCurr = this.pCurr.pReverse;
            return this.pCurr;
        }

        override public bool IsDone()
        {
            return (this.pPrev == this.pRoot);
        }

        private Component pRoot;
        private Component pCurr;
        private Component pPrev;

    }
}
