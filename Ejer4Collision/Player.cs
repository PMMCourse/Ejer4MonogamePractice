using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ejer4Collision
{
    public class Player : Sprite
    {
        public Player(Texture2D texture) : base(texture)
        {
        }
        public override void Update(GameTime gameTime, List<Sprite> listSprite)
        {
            Move();

            foreach (var sprite in listSprite)
            {
                if (sprite == this)
                {
                    continue;
                }
                if ((this.velocity.X > 0 && this.IsTouchingLeft(sprite)) || (this.velocity.X < 0 && this.IsTouchingRight(sprite)))
                {
                    this.velocity.X = 0;
                }
                if ((this.velocity.Y > 0 && this.IsTouchingTop(sprite)) || (this.velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                {
                    this.velocity.Y = 0;
                }
                position += velocity;
                velocity = Vector2.Zero;
            }
        }
        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(input.Left))
            {
                velocity.X = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(input.Right))
            {
                velocity.X = speed;
            }
            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                velocity.Y = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                velocity.Y = speed;
            }
        }
    }
}
