
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallFactory
    {
        public WallFactory()
        {
            this.pBoxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Batch_Boxes);
            Debug.Assert(this.pBoxBatch != null);

        }

        ~WallFactory()
        {
            Debug.WriteLine("~WallFactory():");
            this.pBoxBatch = null;
        }

        public GameObject Create(GameObject.Name name, WallCategory.Type type, float posX = 0.0f, float posY = 0.0f,float width = 0, float height = 0)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case WallCategory.Type.Wall_Left:
                    pGameObj = new WallLeft(GameSprite.Name.Sprite_NullObject, name, posX, posY, width, height);
                    break;
                case WallCategory.Type.Wall_Right:
                    pGameObj = new WallRight(GameSprite.Name.Sprite_NullObject, name, posX, posY, width, height);
                    break;
                case WallCategory.Type.Wall_Top:
                    pGameObj = new WallTop(GameSprite.Name.Sprite_NullObject, name, posX, posY, width, height);
                    break;
                case WallCategory.Type.Wall_Bottom:
                    pGameObj = new WallBottom(GameSprite.Name.Sprite_NullObject, name, posX, posY, width, height);
                    break;
                case WallCategory.Type.Wall_Grid:
                    pGameObj = new WallGrid(name);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            //GameObjectMan.Attach(pGameObj);

            // Attached to Group
            //pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxBatch);

            return pGameObj;
        }

        // Data: ---------------------

       // private SpriteBatch pSpriteBatch;
        private SpriteBatch pBoxBatch;

    }
}
