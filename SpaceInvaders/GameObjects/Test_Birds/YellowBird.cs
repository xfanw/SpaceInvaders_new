using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class YellowBird : BirdCategory
    {
        public YellowBird(GameSprite.Name spriteName, GameObject.Name name, float posX, float posY)
    : base(spriteName, name)
        {
            this.x = posX;
            this.y = posY;
            this.speed = 4.0f;
        }

        // Data: ---------------
        ~YellowBird()
        {

        }

        public override void Update()
        {
            Move();
            base.Update();
        }
        public void Move()
        {
            this.x += speed;
            if (this.x > 600.0f || this.x < 100)
            {
                speed *= -1;
            }
        }
        // this is just a placeholder, who knows what data will be stored here

    }
}
