
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BirdFactory
    {
        public BirdFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Batch_Boxes);
            Debug.Assert(this.pBoxBatch != null);

        }

        ~BirdFactory()
        {
            Debug.WriteLine("~BirdFactory():");
            this.pSpriteBatch = null;
        }

        public GameObject Create(GameObject.Name name, BirdCategory.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case BirdCategory.Type.Green:
                    pGameObj = new GreenBird(GameSprite.Name.GreenBird, name,posX, posY);
                    break;

                case BirdCategory.Type.Red:
                    pGameObj = new RedBird(GameSprite.Name.RedBird, name,posX, posY);
                    break;

                case BirdCategory.Type.White:
                    pGameObj = new WhiteBird(GameSprite.Name.WhiteBird, name,posX, posY);
                    break;

                case BirdCategory.Type.Yellow:
                    pGameObj = new YellowBird(GameSprite.Name.YellowBird, name, posX, posY);
                    break;

                case BirdCategory.Type.Grid:
                    pGameObj = new BirdGrid(name);
                    break;

                case BirdCategory.Type.Column:
                    pGameObj = new BirdColumn(name);

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
