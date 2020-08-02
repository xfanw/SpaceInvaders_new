
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AliensFactory
    {
        public AliensFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Batch_Boxes);
            Debug.Assert(this.pBoxBatch != null);

        }

        ~AliensFactory()
        {
            Debug.WriteLine("~AliensFactory():");
            this.pSpriteBatch = null;
        }

        public GameObject Create(GameObject.Name name, AlienCategory.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case AlienCategory.Type.Squid:
                    pGameObj = new Alien(GameSprite.Name.Sprite_Squid, name, posX, posY);
                    break;

                case AlienCategory.Type.Crab:
                    pGameObj = new Alien(GameSprite.Name.Sprite_Crab, name, posX, posY);
                    break;

                case AlienCategory.Type.Octopus:
                    pGameObj = new Alien(GameSprite.Name.Sprite_Octopus, name, posX, posY);
                    break;

                case AlienCategory.Type.Grid:
                    pGameObj = new AliensGrid(name);
                    break;

                case AlienCategory.Type.Column:
                    pGameObj = new AliensColumn(name);

                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
           // GameObjectMan.Attach(pGameObj);

            // Attached to Group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(pBoxBatch);

            return pGameObj;
        }

        public void LoadAll(GameObject pAlienGrid)
        {
            GameObject pC0 = Create(GameObject.Name.C0, AlienCategory.Type.Column);
            pAlienGrid.Add(pC0);
            GameObject pC1 = Create(GameObject.Name.C1, AlienCategory.Type.Column);
            pAlienGrid.Add(pC1);
            GameObject pC2 = Create(GameObject.Name.C2, AlienCategory.Type.Column);
            pAlienGrid.Add(pC2);
            GameObject pC3 = Create(GameObject.Name.C3, AlienCategory.Type.Column);
            pAlienGrid.Add(pC3);
            GameObject pC4 = Create(GameObject.Name.C4, AlienCategory.Type.Column);
            pAlienGrid.Add(pC4);
            GameObject pC5 = Create(GameObject.Name.C5, AlienCategory.Type.Column);
            pAlienGrid.Add(pC5);
            GameObject pC6 = Create(GameObject.Name.C6, AlienCategory.Type.Column);
            pAlienGrid.Add(pC6);
            GameObject pC7 = Create(GameObject.Name.C7, AlienCategory.Type.Column);
            pAlienGrid.Add(pC7);
            GameObject pC8 = Create(GameObject.Name.C8, AlienCategory.Type.Column);
            pAlienGrid.Add(pC8);
            GameObject pC9 = Create(GameObject.Name.C9, AlienCategory.Type.Column);
            pAlienGrid.Add(pC9);
            GameObject pC10 = Create(GameObject.Name.C10, AlienCategory.Type.Column);
            pAlienGrid.Add(pC10);

            GameObject pGameObj = null;
            pGameObj = Create(GameObject.Name.R0C0, AlienCategory.Type.Squid, 60.0f + 40.0f * 0, 500.0f - 30.0f * 0);
            pC0.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C0, AlienCategory.Type.Squid, 60f + 40.0f * 0, 500.0f - 30.0f * 1);
            pC0.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C0, AlienCategory.Type.Crab, 60.0f + 40.0f * 0, 500.0f - 30.0f * 2);
            pC0.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C0, AlienCategory.Type.Crab, 60.0f + 40.0f * 0, 500.0f - 30.0f * 3);
            pC0.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C0, AlienCategory.Type.Octopus, 60.0f + 40.0f * 0, 500.0f - 30.0f * 4);
            pC0.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C1, AlienCategory.Type.Squid, 60.0f + 40.0f * 1, 500.0f - 30.0f * 0);
            pC1.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C1, AlienCategory.Type.Squid, 60.0f + 40.0f * 1, 500.0f - 30.0f * 1);
            pC1.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C1, AlienCategory.Type.Crab, 60.0f + 40.0f * 1, 500.0f - 30.0f * 2);
            pC1.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C1, AlienCategory.Type.Crab, 60.0f + 40.0f * 1, 500.0f - 30.0f * 3);
            pC1.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C1, AlienCategory.Type.Octopus, 60.0f + 40.0f * 1, 500.0f - 30.0f * 4);
            pC1.Add(pGameObj);


            pGameObj = Create(GameObject.Name.R0C2, AlienCategory.Type.Squid, 60.0f + 40.0f * 2, 500.0f - 30.0f * 0);
            pC2.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C2, AlienCategory.Type.Squid, 60.0f + 40.0f * 2, 500.0f - 30.0f * 1);
            pC2.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C2, AlienCategory.Type.Crab, 60.0f + 40.0f * 2, 500.0f - 30.0f * 2);
            pC2.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C2, AlienCategory.Type.Crab, 60.0f + 40.0f * 2, 500.0f - 30.0f * 3);
            pC2.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C2, AlienCategory.Type.Octopus, 60.0f + 40.0f * 2, 500.0f - 30.0f * 4);
            pC2.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C3, AlienCategory.Type.Squid, 60.0f + 40.0f * 3, 500.0f - 30.0f * 0);
            pC3.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C3, AlienCategory.Type.Squid, 60.0f + 40.0f * 3, 500.0f - 30.0f * 1);
            pC3.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C3, AlienCategory.Type.Crab, 60.0f + 40.0f * 3, 500.0f - 30.0f * 2);
            pC3.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C3, AlienCategory.Type.Crab, 60.0f + 40.0f * 3, 500.0f - 30.0f * 3);
            pC3.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C3, AlienCategory.Type.Octopus, 60.0f + 40.0f * 3, 500.0f - 30.0f * 4);
            pC3.Add(pGameObj);


            pGameObj = Create(GameObject.Name.R0C4, AlienCategory.Type.Squid, 60.0f + 40.0f * 4, 500.0f - 30.0f * 0);
            pC4.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C4, AlienCategory.Type.Squid, 60.0f + 40.0f * 4, 500.0f - 30.0f * 1);
            pC4.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C4, AlienCategory.Type.Crab, 60.0f + 40.0f * 4, 500.0f - 30.0f * 2);
            pC4.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C4, AlienCategory.Type.Crab, 60.0f + 40.0f * 4, 500.0f - 30.0f * 3);
            pC4.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C4, AlienCategory.Type.Octopus, 60.0f + 40.0f * 4, 500.0f - 30.0f * 4);
            pC4.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C5, AlienCategory.Type.Squid, 60.0f + 40.0f * 5, 500.0f - 30.0f * 0);
            pC5.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C5, AlienCategory.Type.Squid, 60.0f + 40.0f * 5, 500.0f - 30.0f * 1);
            pC5.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C5, AlienCategory.Type.Crab, 60.0f + 40.0f * 5, 500.0f - 30.0f * 2);
            pC5.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C5, AlienCategory.Type.Crab, 60.0f + 40.0f * 5, 500.0f - 30.0f * 3);
            pC5.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C5, AlienCategory.Type.Octopus, 60.0f + 40.0f * 5, 500.0f - 30.0f * 4);
            pC5.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C6, AlienCategory.Type.Squid, 60.0f + 40.0f * 6, 500.0f - 30.0f * 0);
            pC6.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C6, AlienCategory.Type.Squid, 60.0f + 40.0f * 6, 500.0f - 30.0f * 1);
            pC6.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C6, AlienCategory.Type.Crab, 60.0f + 40.0f * 6, 500.0f - 30.0f * 2);
            pC6.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C6, AlienCategory.Type.Crab, 60.0f + 40.0f * 6, 500.0f - 30.0f * 3);
            pC6.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C6, AlienCategory.Type.Octopus, 60.0f + 40.0f * 6, 500.0f - 30.0f * 4);
            pC6.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C7, AlienCategory.Type.Squid, 60.0f + 40.0f * 7, 500.0f - 30.0f * 0);
            pC7.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C7, AlienCategory.Type.Squid, 60.0f + 40.0f * 7, 500.0f - 30.0f * 1);
            pC7.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C7, AlienCategory.Type.Crab, 60.0f + 40.0f * 7, 500.0f - 30.0f * 2);
            pC7.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C7, AlienCategory.Type.Crab, 60.0f + 40.0f * 7, 500.0f - 30.0f * 3);
            pC7.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C7, AlienCategory.Type.Octopus, 60.0f + 40.0f * 7, 500.0f - 30.0f * 4);
            pC7.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C8, AlienCategory.Type.Squid, 60.0f + 40.0f * 8, 500.0f - 30.0f * 0);
            pC8.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C8, AlienCategory.Type.Squid, 60.0f + 40.0f * 8, 500.0f - 30.0f * 1);
            pC8.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C8, AlienCategory.Type.Crab, 60.0f + 40.0f * 8, 500.0f - 30.0f * 2);
            pC8.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C8, AlienCategory.Type.Crab, 60.0f + 40.0f * 8, 500.0f - 30.0f * 3);
            pC8.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C8, AlienCategory.Type.Octopus, 60.0f + 40.0f * 8, 500.0f - 30.0f * 4);
            pC8.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C9, AlienCategory.Type.Squid, 60.0f + 40.0f * 9, 500.0f - 30.0f * 0);
            pC9.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C9, AlienCategory.Type.Squid, 60.0f + 40.0f * 9, 500.0f - 30.0f * 1);
            pC9.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C9, AlienCategory.Type.Crab, 60.0f + 40.0f * 9, 500.0f - 30.0f * 2);
            pC9.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C9, AlienCategory.Type.Crab, 60.0f + 40.0f * 9, 500.0f - 30.0f * 3);
            pC9.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C9, AlienCategory.Type.Octopus, 60.0f + 40.0f * 9, 500.0f - 30.0f * 4);
            pC9.Add(pGameObj);

            pGameObj = Create(GameObject.Name.R0C10, AlienCategory.Type.Squid, 60.0f + 40.0f * 10, 500.0f - 30.0f * 0);
            pC10.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R1C10, AlienCategory.Type.Squid, 60.0f + 40.0f * 10, 500.0f - 30.0f * 1);
            pC10.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R2C10, AlienCategory.Type.Crab, 60.0f + 40.0f * 10, 500.0f - 30.0f * 2);
            pC10.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R3C10, AlienCategory.Type.Crab, 60.0f + 40.0f * 10, 500.0f - 30.0f * 3);
            pC10.Add(pGameObj);
            pGameObj = Create(GameObject.Name.R4C10, AlienCategory.Type.Octopus, 60.0f + 40.0f * 10, 500.0f - 30.0f * 4);
            pC10.Add(pGameObj);

            pAlienGrid.Print();


            Debug.WriteLine("\n");
            Debug.WriteLine("Iterator...\n");
            ForwardIterator pIt = new ForwardIterator(pAlienGrid);

            Component pNode = pIt.First();
            while (!pIt.IsDone())
            {
                pNode.Dump();
                pNode = pIt.Next();
            }
        }
        // Data: ---------------------

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pBoxBatch;


    }
}
