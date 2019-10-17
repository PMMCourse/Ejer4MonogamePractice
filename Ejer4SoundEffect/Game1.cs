using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Ejer4SoundEffect
{
    /// <summary>
    /// Añade un efecto de sonido y haz que se reproduzca al pulsar una tecla.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song song;
        List<SoundEffect> soundEffects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            soundEffects = new List<SoundEffect>();
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
            soundEffects.Add(Content.Load<SoundEffect>("punch"));
            soundEffects.Add(Content.Load<SoundEffect>("shocked"));
            //soundEffects[1].Play();

            var instance = soundEffects[1].CreateInstance();
            instance.IsLooped = false;
            instance.Play();
            
            song = Content.Load<Song>("bso");
            MediaPlayer.Play(song);
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e) {
            MediaPlayer.Volume = -0.1f;
            MediaPlayer.Play(song);
        }
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

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.D1)) {
                soundEffects[0].CreateInstance().Play();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2)) {
                soundEffects[1].CreateInstance().Play();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                if (SoundEffect.MasterVolume == 0.0) {
                    SoundEffect.MasterVolume = 1.0f;
                } else {
                    SoundEffect.MasterVolume = 0.0f;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
