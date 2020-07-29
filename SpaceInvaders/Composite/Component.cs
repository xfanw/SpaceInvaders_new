
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Component : CollisionVisitor
    {
        public abstract void Add(Component c);

        public abstract void Remove(Component c);

        public abstract void Print();

        public enum Container
        {
            LEAF,
            COMPOSITE,
            Unknown
        }
        public abstract Component GetFirstChild();
        public abstract void Dump();
        // --------------------------------------
        // Data:
        // --------------------------------------
        public Component pParent = null;
        public Component pReverse = null;
        public Container holder = Container.Unknown;
    }
}
