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
    public class Invader
    {
        Texture2D invader;
        public Rectangle invaderRect;
        String direction;
        public string invaderAlive = "YES";

        int invaderSpeed;
        int rightSide;
        int leftSide;
        public int cols;
        public int rows;
        public int HitPoints;

        public Invader()
        {
            HitPoints = 10;
            invaderSpeed = 2;
            rightSide = 1900;
            leftSide = 0;
            rows = 10;
            cols = 5;
            direction = "RIGHT";

        }

        public void Load(ContentManager Content)
        {
            invader = Content.Load<Texture2D>("enemy3");

            invaderRect = new Rectangle();
            //invaderAlive = new string;


            //colocar os inimigos no jogo
            
                    invaderRect.Width = invader.Width;
                    invaderRect.Height = invader.Height;
                    invaderAlive = "YES";
                    direction = "RIGHT";



        }

        public void Update(GameTime gameTime)
        {

            //Movimento dos inimigos para a esquerda e direita
            String changeDir = "N";
            

                    if (invaderAlive.Equals("YES"))
                    {

                        if (direction.Equals("RIGHT"))
                        {
                            invaderRect.X += invaderSpeed;
                        }

                        if (direction.Equals("LEFT"))
                        {
                            invaderRect.X -= invaderSpeed;
                        }
                    }

                    

            //verificar se os inimigos collidem com as paredes da direita e esquerda
            
                    if (invaderAlive.Equals("YES"))
                    {

                        if (invaderRect.X + invaderRect.Width > rightSide)
                        {
                            direction = "LEFT";
                            changeDir = "Y";
                        }
                        if (invaderRect.X < leftSide)
                        {
                            direction = "RIGHT";
                            changeDir = "Y";
                        }
                    }

            //mexer os inimigos para baixo quando tocarem nos lados
            if (changeDir.Equals("Y"))
            {
                

                        invaderRect.Y += 15;

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
                    if (invaderAlive.Equals("YES"))
                    {
                        spriteBatch.Draw(invader, invaderRect, Color.White);
                    }
              
        }

    }
}


/*
 //verificar se está a mudar de direção na esquerda ou na direita
                        if (invaderRect[r, c].X < leftSide)
                        {
                            direction = "RIGHT";
                            changeDir = "Y";
                        }

                        if (invaderRect[r, c].X + invaderRect[r, c].Height > rightSide)
                        {
                            direction = "LEFT";
                            changeDir = "Y";
                        }
*/
