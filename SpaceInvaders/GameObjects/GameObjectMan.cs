using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class GameObjectMan : Manager
    {
        // private Constructor
        private GameObjectMan(int init = 2, int delta = 3) : base(init, delta)
        {

        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new GameObjectMan(init, delta);
            }

        }

        public static void Destroy()
        {

            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            pMan.baseDestroy();
            // invalidate the singleton            
            pMan = null;
        }

        public static GameObjectNode Attach(GameObject pObj)
        {
            Debug.Assert(pMan != null);

            GameObjectNode pGameObject = (GameObjectNode)pMan.baseAdd();
            Debug.Assert(pGameObject != null);



            pGameObject.Set(pObj);
            return pGameObject;
        }

        public static void Update()
        {
            Debug.Assert(pMan != null);

            GameObjectNode pNode = (GameObjectNode)pMan.poActive;

            while (pNode != null)
            {
                // Update the node
                Debug.Assert(pNode.GetObj() != null);

                pNode.GetObj().Update();

                pNode = (GameObjectNode)pNode.pNext;
            }
        }
        public static void Remove(GameObjectNode pObj)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pObj != null);

            pMan.baseRemove(pObj);
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }

        public static GameObject Find(GameObject.Name name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((GameObjectNode)ptr).GetObj().GetName() == name)
                {
                    return ((GameObjectNode)ptr).GetObj();
                }

                ptr = ptr.pNext;
            }

            return null;
        }


        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameObjectNode pData = (GameObjectNode)pLink;
            //pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new GameObjectNode();
        }


        // Data: ----------
        private static GameObjectMan pMan;
    }
}
