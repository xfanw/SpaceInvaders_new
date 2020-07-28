using System.Diagnostics;

namespace SpaceInvaders
{
    public class Leaf : GameObject
    {
        public Leaf(GameSprite.Name spriteName, GameObject.Name name)
        : base(spriteName, name)
        {
            holder = Container.LEAF;
        }
        override public  void Add(Component c)
        {
            Debug.Assert(false);
        }

        override public void Remove(Component c)
        {
            Debug.Assert(false);
        }

        override public void Print()
        {
            Debug.WriteLine(" Leaf: ");
            Debug.WriteLine(" GameObject Name: {0}  ({1})", this.GetName(), this.GetHashCode());
        }

        override public void Dump()
        {
            Debug.WriteLine(" GameObject Name: {0} ({1}) parent:{2}", this.GetName(), this.GetHashCode(),((Composite) Iterator.GetParent(this)).GetName());
        }
        public override Component GetFirstChild()
        {
            Debug.Assert(false);
            return null;
        }

    }
}
