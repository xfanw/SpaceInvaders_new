using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SLink
    {
        protected SLink()
        {
            this.pSNext = null;
        }

        public static void AddToFront(ref SLink pHead, SLink pNode)
        {
            Debug.Assert(pNode != null);

            // add node
            if (pHead == null)
            {
                // push to the front
                pHead = pNode;
                pNode.pSNext = null;
            }
            else
            {
                // push to front
                pNode.pSNext = pHead;
                pHead = pNode;
            }

        }

        // Data: ---------------
        public SLink pSNext;
    }
}
