using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColObserver
    {
        public ColObserver()
        {
            //this.pObjB = null;
            //this.pObjA = null;
            this.pHead = null;
        }

        ~ColObserver()
        {
            //this.pObjB = null;
            //this.pObjA = null;
            // ToDo
            // Need to walk and nuke the list
            this.pHead = null;
        }

        public void Attach(ColListener Listener)
        {
            // protection
            Debug.Assert(Listener != null);

            Listener.pSubject = this;

            // add to front
            if (pHead == null)
            {
                pHead = Listener;
                Listener.pNext = null;
                Listener.pPrev = null;
            }
            else
            {
                Listener.pNext = pHead;
                pHead.pPrev = Listener;
                pHead = Listener;
            }

        }

        public void Notify()
        {
            ColListener pNode = this.pHead;

            while (pNode != null)
            {
                // Fire off Observer
                pNode.Notify();

                pNode = (ColListener)pNode.pNext;
            }

        }

        public void Detach()
        {
        }


        // Data: ------------------------
        private ColListener pHead;
        //public GameObject pObjA;
        //public GameObject pObjB;


    }
}
