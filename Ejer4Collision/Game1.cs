using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ejer4Collision
{
    /// <summary>
    /// Con un objeto en pantalla que se mueva por teclado y otro que se mueva por pantalla.
    /// Haz un chequeo de colisiones y cuando estos colisionen haz que ocurra algo.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D soldadoTex;
        public Texture2D balaTex;
        public Vector2 enemyPosition;
        public float speed;
        public Rectangle soldado;
        public Rectangle bala;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            soldadoTex = Content.Load<Texture2D>("combatir");
            balaTex = Content.Load<Texture2D>("bala");
            enemyPosition = new Vector2(1000, 200);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            enemyPosition.X -= speed;
            soldado = new Rectangle(200, 200, 100, 100);
            bala = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, 70, 50);

            if (enemyPosition.X + balaTex.Width < 0)
            {
                enemyPosition.X = 900;
            }
            if (soldado.Intersects(bala))
            {
                speed = 1;

            }
            else
            {
                speed = 10;
            }
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(soldadoTex, soldado, Color.White);
            spriteBatch.Draw(balaTex, bala, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}