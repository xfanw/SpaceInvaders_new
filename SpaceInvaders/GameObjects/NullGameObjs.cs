using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NullGameObjs: GameObject
    {
        public NullGameObjs()
            : base(0, 0)
        {

        }
        ~NullGameObjs()
        {

        }

        public override void Add(Component c)
        {
            //
        }

        public override void Dump()
        {
            //
        }

        public override Component GetFirstChild()
        {
            return null;
        }


        public override void Print()
        {
            //
        }

        public override void Remove(Component c)
        {
            //
        }

        public override void Update()
        {
            // do nothing - its a null object
        }

    }
}
