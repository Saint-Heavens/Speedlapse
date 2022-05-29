using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Speedlapse.States;


namespace Speedlapse
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Invader inv = new Invader();
        Player ship = new Player();

        private State _currentState;
        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = 1900; //Colocar os extremos do ecra, da esquerda para a direita é 1900 pixeis
            this.graphics.PreferredBackBufferHeight= 900; //de cima para baixo é 900 pixeis
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);



            inv.Load(Content);
            ship.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {

            if(_nextState!= null)
            {
                _currentState = _nextState;

                _nextState = null;
            }


            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            inv.Update(gameTime);
            ship.Update(gameTime);


            //colisao de balas contra os inimigos

            if (ship.hasFired) 
            {
                if (ship.bulletRect.Intersects(inv.invaderRect))
                {
                    inv.HitPoints = inv.HitPoints - 1;

                    if (inv.HitPoints == 0)
                    {
                        inv.invaderAlive = "NO";
                        ship.hasFired = false;
                    }
                    ship.hasFired = false;
                
                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _currentState.Draw(gameTime, spriteBatch);

            spriteBatch.Begin();

            inv.Draw(spriteBatch);
            ship.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
