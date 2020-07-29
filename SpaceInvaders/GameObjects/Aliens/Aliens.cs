using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Aliens : AlienCategory
    {
        public Aliens(GameSprite.Name spriteName, GameObject.Name name, float posX, float posY)
    : base(spriteName, name)
        {
            this.x = posX;
            this.y = posY;
        }

        // Data: ---------------
        ~Aliens()
        {

        }

        public override void Update()
        {
            Move();
            base.Update();
        }

        public void Move()
        {
            this.x += Nums.AliensSpeedX;
            if (this.x > 800.0f || this.x < 000.0f)
            {
                Nums.AliensSpeedX *= -1;
            }
        }

        public override void Accept(CollisionVisitor other)
        {
            throw new NotImplementedException();
        }
        // this is just a placeholder, who knows what data will be stored here

    }
}
