using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Topic__4___Assignment_4
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D bomb;
        Rectangle window;
        Rectangle bombRect;
        SpriteFont titleFont;
        Rectangle timeRect;
        float seconds;
        MouseState mouseState;
        SoundEffect explode;
        MouseState mousestate;
        Texture2D wireCuttersTexture;
        Rectangle mouseRectangle;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 500);
            bombRect = new Rectangle(50, 50, 700, 500);
            seconds = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            titleFont = Content.Load<SpriteFont>("TimeFont");
            bomb = Content.Load<Texture2D>("bomb");
            explode = Content.Load<SoundEffect>("explosion");
            wireCuttersTexture = Content.Load<Texture2D>("pliers");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
                if (bombRect.Contains(mouseState.Position))
                    seconds = 0f;

            

            if (seconds >= 10)
            {
                explode.Play();
                seconds = 0f;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(bomb, bombRect, Color.White);
            _spriteBatch.DrawString(titleFont, (15 - seconds).ToString("0:00"), new Vector2(270, 200), Color.Black);
            mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 64, 64);
            _spriteBatch.Draw(wireCuttersTexture, mouseRectangle, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
