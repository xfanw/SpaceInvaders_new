using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    public class SpriteBatchMan : Manager
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private SpriteBatchMan(int reserveNum = 3, int reserveGrow = 1)
        : base(reserveNum, reserveGrow) // <--- Kick the can (delegate)
        {
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pMan == null);

            // Do the initialization
            if (pMan == null)
            {
                pMan = new SpriteBatchMan(reserveNum, reserveGrow);
            }


        }
        public static void Destroy()
        {

            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton

            pMan.baseDestroy();
            pMan = null;
        }

        public static SpriteBatch Add(SpriteBatch.Name name, int reserveNum = 3, int reserveGrow = 1)
        {

            Debug.Assert(pMan != null);

            SpriteBatch pBatch = (SpriteBatch)pMan.baseAdd();
            Debug.Assert(pBatch != null);

            pBatch.Set(name, reserveNum, reserveGrow);
            return pBatch;
        }

        public static void Draw()
        {

            Debug.Assert(pMan != null);

            // walk through the list and render
            SpriteBatch pSpriteBatch = (SpriteBatch)pMan.poActive;

            while (pSpriteBatch != null)
            {
                SpriteNodeMan pSBNodeMan = pSpriteBatch.GetSpriteNodeMan();
                Debug.Assert(pSBNodeMan != null);

                // Kick the can
                pSBNodeMan.Draw();

                pSpriteBatch = (SpriteBatch)pSpriteBatch.pNext;
            }

        }

        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((SpriteBatch)ptr).GetName() == name)
                {
                    return (SpriteBatch)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }
        public static void Remove(SpriteBatch pNode)
        {

            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
            pNode.Wash();
        }
        public static void Dump()
        {
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected DLink derivedCreate()
        {
            DLink pNode = new SpriteBatch();
            Debug.Assert(pNode != null);

            return pNode;
        }



        protected override void derivedDump(DLink pNode)
        {
            throw new NotImplementedException();
        }


        //----------------------------------------------------------------------
        // Data - unique data for this manager 
        //----------------------------------------------------------------------
        private static SpriteBatchMan pMan = null;
    }
}

// End of File
