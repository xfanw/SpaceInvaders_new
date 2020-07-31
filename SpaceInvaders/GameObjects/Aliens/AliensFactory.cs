﻿
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
            GameObjectMan.Attach(pGameObj);

            // Attached to Group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(pBoxBatch);

            return pGameObj;
        }

        // Data: ---------------------

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pBoxBatch;

    }
}
