using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace WebGameTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class WebGameTestGame : Game
    {
        Texture2D axeTexture;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Blazored.LocalStorage.ISyncLocalStorageService localStorage;

        public WebGameTestGame(Blazored.LocalStorage.ISyncLocalStorageService blazoredLocalStorage)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            localStorage = blazoredLocalStorage;
            Console.WriteLine(localStorage);
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

            // TODO: Use this.Content to load your game content here
            axeTexture = Content.Load<Texture2D>("2h_axe20_000_001");
            Console.WriteLine(axeTexture);
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
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if (keyboardState.IsKeyDown(Keys.A)) {
                //localStorage.SetItem("name", "John Doe");
                var name = localStorage.GetItem<string>("name");
                Console.WriteLine(name);
                //Console.WriteLine(File.ReadAllText("save.json"));
                //File.WriteAllText("save.json", "{\"hello\": true}");
                //Console.WriteLine(File.ReadAllText("save.json"));
            }
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                File.WriteAllText("save.json", "{\"hello\": true}");
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                Console.WriteLine(File.ReadAllText("save.json"));
            }

            if (keyboardState.IsKeyDown(Keys.Escape) ||
                keyboardState.IsKeyDown(Keys.Back) ||
                gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                try { Exit(); }
                catch (PlatformNotSupportedException e) { /* ignore */ }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

            // TODO: Add your drawing code here

            //Console.WriteLine(graphics.PreferredBackBufferWidth);
            //Console.WriteLine(graphics.PreferredBackBufferHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(axeTexture, new Vector2(graphics.PreferredBackBufferWidth / 2 - axeTexture.Width / 2, graphics.PreferredBackBufferHeight / 2 - axeTexture.Height / 2), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
