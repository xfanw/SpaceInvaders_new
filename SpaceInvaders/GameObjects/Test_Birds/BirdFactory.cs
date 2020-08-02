
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
            //GameObjectMan.Attach(pGameObj);

            // Attached to Group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxBatch);

            return pGameObj;
        }

        public void LoadAll(BirdGrid pGrid)
        {
            GameObject pGameObj = null;
            // Create Column 0
            GameObject pCol0 = Create(GameObject.Name.BirdColumn_0, BirdCategory.Type.Column);
            pGrid.Add(pCol0);

            pGameObj = Create(GameObject.Name.RedBird, BirdCategory.Type.Red, 250.0f + 50.0f, 400.0f);
            pCol0.Add(pGameObj);

            pGameObj = Create(GameObject.Name.YellowBird, BirdCategory.Type.Yellow, 250.0f + 50.0f, 250.0f);
            pCol0.Add(pGameObj);

            GameObject pCol1 = Create(GameObject.Name.BirdColumn_1, BirdCategory.Type.Column);
            pGrid.Add(pCol1);

            pGameObj = Create(GameObject.Name.GreenBird, BirdCategory.Type.Green, 250.0f + 50.0f, 300.0f);
            pCol1.Add(pGameObj);

            pGameObj = Create(GameObject.Name.WhiteBird, BirdCategory.Type.White, 250.0f + 50.0f, 300.0f);
            pCol1.Add(pGameObj);

            //pGrid.Print();


            //Debug.WriteLine("\n");
            //Debug.WriteLine("Iterator...\n");
            //ForwardIterator pIt = new ForwardIterator(pGrid);

            //Component pNode = pIt.First();
            //while (!pIt.IsDone())
            //{
            //    pNode.Dump();
            //    pNode = pIt.Next();
            //}
        }
        // Data: ---------------------

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pBoxBatch;


    }
}
