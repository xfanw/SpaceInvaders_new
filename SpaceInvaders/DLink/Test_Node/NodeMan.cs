using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class NodeMan : Manager
    {
        // private Constructor
        private NodeMan(int init = 5, int delta = 3) : base(init, delta)
        {
           
        }

        // public 
        public static void Create(int init = 0, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new NodeMan(init , delta);
            }

        }

        public static Node Add(Node.NAME name, int val)
        {
            Node pNode = (Node)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.SetNode(name, val);
            return pNode;
        }

        public static void Remove(Node pNode)
        {
            Debug.Assert(pNode != null);

            pMan.baseRemove(pNode);
            pNode.Wash();
        }

        public static void Dump()
        {
            pMan.baseDump();
        }

        public static Node Find(Node.NAME name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((Node)ptr).GetName() == name)
                {
                    return (Node)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }

        //protected override bool derivedFind(DLink pSource, DLink pTarget)
        //{
        //    if (((Node)pSource).GetName() == ((Node)pTarget).GetName())
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Node pData = (Node)pLink;
            pData.Dump();
        }


        protected override DLink derivedCreate()
        {
            return new Node();
        }

        // Data: ----------
        private static NodeMan pMan;


    }
}
