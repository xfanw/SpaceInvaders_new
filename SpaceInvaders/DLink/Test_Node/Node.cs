using System.Diagnostics;

namespace SpaceInvaders
{
    public class NodeLink : DLink
    {
        public NodeLink() : base()
        {

        }
    }
    public class Node : NodeLink
    {

        public enum NAME
        {
            CAT,
            DOG,
            BIRD,
            FISH,
            RABBIT,
            WORM,
            UNITIALIZED,
        }

        // Constractor
        public Node()
        {
            this.SetNode(Node.NAME.UNITIALIZED, 0);
        }
        public Node(NAME name, int val) : base()
        {
            this.SetNode(name, val);
        }

        // Accessors
        public void SetNode(NAME name, int val)
        {
            this.name = name;
            this.val = val;
        }

        public Node.NAME GetName()
        {
            return this.name;
        }

        public int GetVal()
        {
            return this.val;
        }

        // Clean
        public void Wash()
        {
            this.name = NAME.UNITIALIZED;
            this.val = 0;
        }

        // Print
        public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Prev Node
            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                Node pTmp = (Node)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            // Next Node
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Node pTmp = (Node)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }


            //Current Data:
            Debug.WriteLine("      x: {0}", this.val);
        }

        // Data: ----------
        // Private:
        private NAME name;
        private int val;
    }
}
