using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Iterator
    {
        abstract public Component Next();
        abstract public bool IsDone();
        abstract public Component First();

        static public Component GetParent(Component pNode)
        {
            Debug.Assert(pNode != null);

            return pNode.pParent;

        }
        static public Component GetChild(Component pNode)
        {
            Debug.Assert(pNode != null);

            Component pChild;

            if (pNode.holder == Component.Container.COMPOSITE)
            {
                pChild = pNode.GetFirstChild();
            }
            else
            {
                pChild = null;
            }

            return pChild;
        }
        abstract public Component GetSibling(Component pNode);
        //abstract public bool HasNext();


    }
}
