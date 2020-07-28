using System;
using System.Diagnostics;
using System.Xml;

namespace SpaceInvaders
{
    public abstract class Manager
    {
        public Manager(int InitialNumReserved = 5, int DeltaGrow = 3)
        {
            // Check:
            Debug.Assert(InitialNumReserved >= 0);
            Debug.Assert(DeltaGrow > 0);

            // Initialize All data
            this.mDeltaGrow = DeltaGrow;

            this.mNumReserved = 0;
            this.mNumActive = 0;
            this.mTotalNumNodes = 0;

            this.poActive = null;
            this.poReserve = null;

            // fill reserved
            this.privFillReservedPool(InitialNumReserved);
        }

        // Public Methods:

        // STEP 2: ABSTRACT MANAGER
        // Step 2.1 move Clean DLink
        public DLink baseAdd()
        {
            // check/fill reserve list
            if (this.poReserve == null)
            {
                this.privFillReservedPool(this.mDeltaGrow);
            }

            // remove node from reserve
            // 2.1
            //DLink pLink = DLink.RemoveFront(ref this.poReserve);
            DLink pLink = privPopFront(ref this.poReserve);
            Debug.Assert(pLink != null);
            Debug.Assert(pLink.pNext == null);
            Debug.Assert(pLink.pPrev == null);

            // add node to active
            privAddToFront(ref this.poActive, pLink);

            // Update stats
            this.mNumActive++;
            this.mNumReserved--;

            return pLink;

        }

        private void privAddToFront(ref DLink pHead, DLink pLink)
        {
            Debug.Assert(pLink != null);
            if (pHead == null)
            {
                // pNode is head
                pHead = pLink;
                pHead.pPrev = null;
                pHead.pNext = null;
            }
            else
            {
                // update Link
                pHead.pPrev = pLink;
                pLink.pNext = pHead;

                // update pointer
                pHead = pLink;
                pHead.pPrev = null;
            }
        }

        public void baseRemove(DLink pLink)
        {
            privRemove(ref this.poActive, pLink);

            pLink.Clear();
            //derivedWash(pLink);
            privAddToFront(ref this.poReserve, pLink);

            // update stats
            this.mNumActive--;
            this.mNumReserved++;

        }

        private void privRemove(ref DLink pHead, DLink pLink)
        {
            // protection
            Debug.Assert(pHead != null);
            Debug.Assert(pLink != null);

            // fix 
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
            }

            pLink.Clear();
        }

        public void baseDestroy()
        {
            this.mTotalNumNodes = 0;
            this.mNumActive = 0;
            this.mNumReserved = 0;

            DLink pCurLink = poActive;
            DLink pNextLink = pCurLink.pNext;

            while(pNextLink != null)
            {
                pCurLink.Clear();
                pCurLink = pNextLink;
                pNextLink = pNextLink.pNext;
            }
            pCurLink.Clear();

            pCurLink = poReserve;
            pNextLink = pCurLink.pNext;

            while (pNextLink != null)
            {
                pCurLink.Clear();
                pCurLink = pNextLink;
                pNextLink = pNextLink.pNext;
            }
            pCurLink.Clear();
        }

        // STEP 1:
        // ADD
        //public Node AddToFront(Node.NAME name, int val)
        //{
        //    // check/fill reserve list
        //    if (this.poReserve == null)
        //    {
        //        this.privFillReservedPool(this.mDeltaGrow);
        //    }

        //    // remove node from reserve
        //    DLink pLink = DLink.RemoveFront(ref this.poReserve);
        //    Debug.Assert(pLink != null);
        //    Debug.Assert(pLink.pNext == null);
        //    Debug.Assert(pLink.pPrev == null);

        //    // set node
        //    Node pNode = (Node)pLink;
        //    pNode.SetNode(name, val);

        //    // add node to active
        //    DLink.AddToFront(ref this.poActive, pLink);

        //    // Update stats
        //    this.mNumActive++;
        //    this.mNumReserved--;

        //    return pNode;

        //}

        //public Node AddToEnd(Node.NAME name, int val)
        //{
        //    // check/fill reserve list
        //    if (this.poReserve == null)
        //    {
        //        this.privFillReservedPool(this.mDeltaGrow);
        //    }

        //    // remove node from reserve
        //    DLink pLink = DLink.RemoveFront(ref this.poReserve);
        //    Debug.Assert(pLink != null);
        //    Debug.Assert(pLink.pNext == null);
        //    Debug.Assert(pLink.pPrev == null);

        //    // set node
        //    Node pNode = (Node)pLink;
        //    pNode.SetNode(name, val);

        //    // add node to active
        //    DLink.AddToEnd(ref this.poActive, pLink);

        //    // Update stats
        //    this.mNumActive++;
        //    this.mNumReserved--;

        //    return pNode;
        //}


        //public Node AddBeforeNode(Node pNode, Node.NAME name, int val)
        //{
        //    Debug.Assert(pNode != null);

        //    // check/fill reserve list
        //    if (this.poReserve == null)
        //    {
        //        this.privFillReservedPool(this.mDeltaGrow);
        //    }

        //    // remove node from reserve
        //    DLink pLink = DLink.RemoveFront(ref this.poReserve);
        //    Debug.Assert(pLink != null);
        //    Debug.Assert(pLink.pNext == null);
        //    Debug.Assert(pLink.pPrev == null);

        //    // set node
        //    Node pNewNode = (Node)pLink;
        //    pNewNode.SetNode(name, val);

        //    // add node to active
        //    DLink.AddBefore(ref this.poActive, pNode, pLink);

        //    // Update stats
        //    this.mNumActive++;
        //    this.mNumReserved--;

        //    return pNewNode;
        //}

        //public Node AddAfterNode(Node pNode, Node.NAME name, int val)
        //{
        //    Debug.Assert(pNode != null);

        //    // check/fill reserve list
        //    if (this.poReserve == null)
        //    {
        //        this.privFillReservedPool(this.mDeltaGrow);
        //    }

        //    // remove node from reserve
        //    DLink pLink = DLink.RemoveFront(ref this.poReserve);
        //    Debug.Assert(pLink != null);
        //    Debug.Assert(pLink.pNext == null);
        //    Debug.Assert(pLink.pPrev == null);

        //    // set node
        //    Node pNewNode = (Node)pLink;
        //    pNewNode.SetNode(name, val);

        //    // add node to active
        //    DLink.AddAfter(ref this.poActive, pNode, pLink);

        //    // Update stats
        //    this.mNumActive++;
        //    this.mNumReserved--;

        //    return pNewNode;
        //}
        //// REMOVE
        //public void Remove(Node pNode)
        //{
        //    DLink.Remove(ref this.poActive, pNode);

        //    pNode.Wash();
        //    pNode.Clear();

        //    DLink.AddToFront(ref this.poReserve, pNode);

        //    // update stats
        //    this.mNumActive--;
        //    this.mNumReserved++;

        //}

        //private DLink privCreateNode()
        //{
        //    DLink pNode = new Node(Node.NAME.UNITIALIZED, 0);
        //    Debug.Assert(pNode != null);

        //    return pNode;
        //}

        // FIND

        //public DLink baseFind(DLink pLink)
        //{
        //    DLink ptr = poActive;
        //    while (ptr != null)
        //    {
        //        if (derivedFind(ptr, pLink))
        //        {
        //            return ptr;
        //        }

        //        ptr = ptr.pNext;
        //    }

        //    return null;
        //}

        // Print
        protected void baseDump()
        {
            Debug.WriteLine("");
            Debug.WriteLine("   ****** Manager Begin ****************\n");

            Debug.WriteLine("         mDeltaGrow: {0} ", mDeltaGrow);
            Debug.WriteLine("     mTotalNumNodes: {0} ", mTotalNumNodes);
            Debug.WriteLine("       mNumReserved: {0} ", mNumReserved);
            Debug.WriteLine("         mNumActive: {0} \n", mNumActive);

            if (this.poActive == null)
            {
                Debug.WriteLine("    Active Head: null");
            }
            else
            {
             
                Debug.WriteLine("    Active Head: ");
                derivedDump(poActive);
            }


            if (this.poReserve == null)
            {
                Debug.WriteLine("   Reserve Head: null\n");
            }
            else
            {

                Debug.WriteLine("   Reserve Head:  \n");
                derivedDump(poReserve);
            }

            Debug.WriteLine("   ------ Active List: -----------\n");

            DLink pNode = this.poActive;

            int i = 0;
            while (pNode != null)
            {
                
                Debug.WriteLine("   {0}: -------------", i);
                derivedDump(pNode);
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("   ------ Reserve List: ----------\n");

            pNode = this.poReserve;
            i = 0;
            while (pNode != null)
            {
                //Node pData = (Node)pNode;
                Debug.WriteLine("   {0}: -------------", i);
                //pData.Dump();
                derivedDump(pNode);
                i++;
                pNode = pNode.pNext;
            }
            Debug.WriteLine("\n   ****** Manager End ******************\n");
        }


        // Private Methods:
        private void privFillReservedPool(int count)
        {
            // Check:
            Debug.Assert(count >= 0);

            this.mTotalNumNodes += count;
            this.mNumReserved += count;

            for (int i = 0; i < count; i++)
            {
                DLink pNode = derivedCreate();
                Debug.Assert(pNode != null);
                privAddToFront(ref this.poReserve, pNode);
            }

        }



        private DLink privPopFront(ref DLink pHead)
        {
            Debug.Assert(pHead != null);

            // move pHead to next
            DLink pLink = pHead;
            pHead = pHead.pNext;

            // set pHead pPrev
            if (pHead != null)
            {
                pHead.pPrev = null;
            }

            // clean node
            pLink.Clear();
            return pLink;
        }
        // abstract Methods
        
        abstract protected void derivedDump(DLink pNode);
        //abstract protected void derivedWash(DLink pNode);

        abstract protected DLink derivedCreate();
        //abstract protected bool derivedFind(DLink pSource, DLink pTarget);
        // Data : ----------------------------
        // Private:
        protected DLink poActive;        
        private DLink poReserve;
        
        private readonly int mDeltaGrow;
        private int mTotalNumNodes;
        protected int mNumReserved;
        protected int mNumActive;
    }
}
