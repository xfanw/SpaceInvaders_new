using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class ColPairMan : Manager
    {
        // private Constructor
        private ColPairMan(int init = 2, int delta = 3) : base(init, delta)
        {
        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new ColPairMan(init, delta);
            }
        }

        public static void Destroy()
        {
            Debug.Assert(pMan != null);
            pMan.baseDestroy();

            // invalidate the singleton
            pMan = null;
        }
        public static ColPair Add(GameObject treeRootA, GameObject treeRootB)
        {
            // Get the instance           
            Debug.Assert(pMan != null);

            // Go to Man, get a node from reserve, add to active, return it
            ColPair pColPair = (ColPair)pMan.baseAdd();
            Debug.Assert(pColPair != null);

            // Initialize Image
            pColPair.Set(treeRootA, treeRootB);

            return pColPair;
        }

        public static void Process()
        {
            // get the singleton
            Debug.Assert(pMan != null);

            ColPair pColPair = (ColPair)pMan.poActive;

            while (pColPair != null)
            {
                pMan.pActiveColPair = pColPair;

                // do the check for a single pair
                pColPair.Process();

                // advance to next
                pColPair = (ColPair)pColPair.pNext;
            }
        }
        public static void Remove(ColPair pColPair)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pColPair != null);

            pMan.baseRemove(pColPair);
            pColPair.Wash();
        }

        public static ColPair GetActivePair()
        {
            Debug.Assert(pMan != null);
            return pMan.pActiveColPair;
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }


        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ColPair pData = (ColPair)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new ColPair();
        }


        // Data: ----------
        private static ColPairMan pMan;
        private ColPair pActiveColPair;
    }
}
