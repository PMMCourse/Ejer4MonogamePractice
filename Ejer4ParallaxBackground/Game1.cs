using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ejer4ParallaxBackground
{
    /// <summary>
    /// Busca un escenario o crealo tu mismo. Ponlo en pantalla y haz que este se desplace como 
    /// un parallax background sin perderlo por pantalla.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Moverse mov;
        Moverse mov2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mov = new Moverse(Content.Load<Texture2D>("Fondo2"), new Rectangle(0, 0, 1280, 500));
            mov2 = new Moverse(Content.Load<Texture2D>("Fondo2"), new Rectangle(1280, 0, 1280, 500));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if(mov.rectangulo.X + mov.textura.Width <= 0)
            {
                mov.rectangulo.X = mov2.rectangulo.X + mov2.textura.Width;
            }
                  
            if (mov2.rectangulo.X + mov2.textura.Width <= 0)
            {
                mov2.rectangulo.X = mov.rectangulo.X + mov.textura.Width;
            }
            
            mov.Actualizar();
            mov2.Actualizar();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            mov.dibujar(spriteBatch);
            mov2.dibujar(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
