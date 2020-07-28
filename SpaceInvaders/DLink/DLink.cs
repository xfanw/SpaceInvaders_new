using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class DLink
    {
        // protected constractor
        protected DLink()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.pNext = null;
            this.pPrev = null;
        }
        // Step 1:
        // Public Methods
        //public static void AddToFront(ref DLink pHead, DLink pNode)
        //{
        //    Debug.Assert(pNode != null);
        //    if (pHead == null)
        //    {
        //        // pNode is head
        //        pHead = pNode;
        //        pHead.pPrev = null;
        //        pHead.pNext = null;
        //    }
        //    else
        //    {
        //        // update Link
        //        pHead.pPrev = pNode;
        //        pNode.pNext = pHead;

        //        // update pointer
        //        pHead = pNode;
        //        pHead.pPrev = null;
        //    }
        //}

        //public static void AddToEnd(ref DLink pHead, DLink pNode)
        //{
        //    Debug.Assert(pNode != null);
        //    if (pHead == null)
        //    {
        //        // pNode is head
        //        pHead = pNode;
        //        pHead.pPrev = null;
        //        pHead.pNext = null;
        //    }
        //    else
        //    {
        //        DLink ptr = pHead;
        //        while (ptr.pNext != null)
        //        {
        //            ptr = ptr.pNext;
        //        }

        //        ptr.pNext = pNode;
        //        pNode.pPrev = ptr;
        //    }
        //}

        //public static void AddBefore(ref DLink pHead, Node pOld, DLink pNew)
        //{
        //    Debug.Assert(pHead != null);
        //    Debug.Assert(pOld != null);
        //    Debug.Assert(pNew != null);

        //    if (pOld.pPrev != null)
        //    {

        //        pNew.pNext = pOld;
        //        pNew.pPrev = pOld.pPrev;

        //        pOld.pPrev.pNext = pNew;
        //        pOld.pPrev = pNew;


        //    }
        //    else
        //    {
        //        pOld.pPrev = pNew;
        //        pNew.pNext = pOld;
        //        pHead = pNew;
        //        pHead.pPrev = null;
        //    }
        //}

        //public static void AddAfter(ref DLink pHead, Node pOld, DLink pNew)
        //{
        //    Debug.Assert(pHead != null);
        //    Debug.Assert(pOld != null);
        //    Debug.Assert(pNew != null);

        //    if (pOld.pNext != null)
        //    {
        //        pNew.pPrev = pOld;
        //        pNew.pNext = pOld.pNext;

        //        pOld.pNext.pPrev = pNew;
        //        pOld.pNext = pNew;
        //    }
        //    else
        //    {
        //        pOld.pNext = pNew;
        //        pNew.pPrev = pOld;
        //        pNew.pNext = null;
        //    }
        //}

        //public static void Remove(ref DLink pHead, DLink pNode)
        //{
        //    // protection
        //    Debug.Assert(pHead != null);
        //    Debug.Assert(pNode != null);

        //    // fix 
        //    if (pNode.pPrev != null)
        //    {
        //        pNode.pPrev.pNext = pNode.pNext;
        //    }
        //    else
        //    {  // first
        //        pHead = pNode.pNext;
        //    }

        //    if (pNode.pNext != null)
        //    {
        //        pNode.pNext.pPrev = pNode.pPrev;
        //    }

        //    pNode.Clear();
        //}
        //public static DLink RemoveFront(ref DLink pHead)
        //{
        //    Debug.Assert(pHead != null);

        //    // move pHead to next
        //    DLink pLink = pHead;
        //    pHead = pHead.pNext;

        //    // set pHead pPrev
        //    if (pHead != null)
        //    {
        //        pHead.pPrev = null;
        //    }

        //    // clean node
        //    pLink.Clear();
        //    return pLink;
        //}
        // Data
        // Public
        public DLink pNext;
        public DLink pPrev;


    }
}
