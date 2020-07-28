using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RedBird : BirdCategory
    {
        public RedBird(GameSprite.Name spriteName, GameObject.Name name, float posX, float posY)
     : base(spriteName, name)
        {
            this.x = posX;
            this.y = posY;
            this.speed = 2.0f;
        }

        // Data: ---------------
        ~RedBird()
        {

        }

        public override void Update()
        {
            Move();
            base.Update();
        }
        public void Move()
        {
            this.y += speed;
            if (this.y >400 || y< 200)
            {
                speed *= -1;
            }
        }
        // this is just a placeholder, who knows what data will be stored here

    }
}
