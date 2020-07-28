
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AliensFactory
    {
        public AliensFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

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
                    pGameObj = new Aliens(GameSprite.Name.Sprite_Squid, name, posX, posY);
                    break;

                case AlienCategory.Type.Crab:
                    pGameObj = new Aliens(GameSprite.Name.Sprite_Crab, name, posX, posY);
                    break;

                case AlienCategory.Type.Octopus:
                    pGameObj = new Aliens(GameSprite.Name.Sprite_Octopus, name, posX, posY);
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
            GameObjectMan.Attach(pGameObj);

            // Attached to Group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pSpriteBatch);

            return pGameObj;
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;

    }
}
