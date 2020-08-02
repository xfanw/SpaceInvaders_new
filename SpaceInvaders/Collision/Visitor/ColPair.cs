using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ColPair_Link : DLink
    {

    }
    public class ColPair : ColPair_Link
    {
        public ColPair()
            : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.pObserver = new ColObserver();
            Debug.Assert(this.pObserver != null);
        }

        ~ColPair()
        {

        }
        public void Set( GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
        }
        public void Wash()
        {
            this.treeA = null;
            this.treeB = null;

        }

        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    // who is being tested?
                    //Debug.WriteLine("ColPair:    test:  {0}, {1}", pNodeA.name, pNodeB.name);

                    // Get rectangles
                    CollisionRect rectA = pNodeA.GetCollisionObject().poCollisionRect;
                    CollisionRect rectB = pNodeB.GetCollisionObject().poCollisionRect;

                    // test them
                    if (CollisionRect.Intersect(rectA, rectB))
                    {
                        // Boom - it works (Visitor in Action)
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)Iterator.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)Iterator.GetSibling(pNodeA);
            }
        }


        public void Dump()
        {
            // TO DO ...
        }


        // Obserbver
        public void Attach(ColListener Listener)
        {
            this.pObserver.Attach(Listener);
        }
        public void NotifyObservers()
        {
            this.pObserver.Notify();
        }
        public void SetCollision(GameObject pObjA, GameObject pObjB)
        {
            Debug.Assert(pObjA != null);
            Debug.Assert(pObjB != null);

            // GameObject pAlien = AlienCategory.GetAlien(objA, objB);
            //this.pObserver.pObjA = pObjA;
            //this.pObserver.pObjB = pObjB;
        }
        // Data: ---------------
        public GameObject treeA;
        public GameObject treeB;
        private ColObserver pObserver;


    }
}