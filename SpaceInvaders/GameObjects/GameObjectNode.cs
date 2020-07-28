using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNode : DLink
    {

        public GameObjectNode()
            : base()
        {
            this.pGamObj = null;
        }

        public void Set(GameObject pObj)
        {
            this.pGamObj = pObj;

            Debug.Assert(this.pGamObj != null);
        }

        public void Wash()
        {
            this.pGamObj = null;
        }

        public GameObject GetObj()
        {
            return this.pGamObj;
        }
        // Data: ----------------------------------------------
        public GameObject pGamObj;
    }
}

// End of File
