
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileFactory
    {
        public MissileFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Batch_Boxes);
            Debug.Assert(this.pBoxBatch != null);

        }

        ~MissileFactory()
        {
            Debug.WriteLine("~MissleFactory():");
            this.pSpriteBatch = null;
        }

        public GameObject Create(GameObject.Name name, MissileCategory.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case MissileCategory.Type.Missile:
                    pGameObj = new Missile(GameSprite.Name.Sprite_Missle, name, posX, posY);
                    break;

                case MissileCategory.Type.Missile_Grid:
                    pGameObj = new MissileGrid(name);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            GameObjectMan.Attach(pGameObj);

            // Attached to Group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxBatch);

            return pGameObj;
        }

        // Data: ---------------------

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pBoxBatch;

    }
}
