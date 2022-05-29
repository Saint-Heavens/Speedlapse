using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Speedlapse
{
    class Player
    {
        Texture2D ship, bullet;
        public Rectangle shipRect, bulletRect;
        public bool hasFired;
        int bulletSpeed, shipSpeed;
        int screenWidth, screenHeight;


        public Player()
        {
            hasFired = false;
            bulletSpeed = 10;
            shipSpeed = 4;
            screenWidth = 1900;
            screenHeight = 500;
        }

        public void Load(ContentManager Content)
        {
            ship = Content.Load<Texture2D>("ship");
            bullet = Content.Load<Texture2D>("bullet");

            //posição inicial do jogador 
            shipRect.Width = ship.Width;
            shipRect.Height = ship.Height;
            shipRect.X = screenWidth /2 - (shipRect.Width);
            shipRect.Y = screenHeight - (shipRect.Height);

            bulletRect.Width = bullet.Width;
            bulletRect.Height = bullet.Height;
            bulletRect.X = 0;
            bulletRect.Y = 0;


        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                shipRect.Y -= shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                shipRect.Y += shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                shipRect.X += shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                shipRect.X -= shipSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasFired == false)
            {
                hasFired = true;
                bulletRect.X = shipRect.X+40;
                bulletRect.Y = (shipRect.Y - bulletRect.Height); //posição da bala quando a tecla do espaço é carregado
            }
            
            if (hasFired)
            {
                bulletRect.Y -= bulletSpeed;
            }
            //dar reset á bala se for para offscreen
            if (bulletRect.Y < -50)
            {
                hasFired = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ship, shipRect, Color.White);
            if (hasFired)
            {
                spriteBatch.Draw(bullet, bulletRect, Color.White);
            }

        }

    }
}
