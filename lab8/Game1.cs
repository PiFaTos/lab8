using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lab8
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _backgroundTexture;
        private LightManager _lightingManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1500,  // Ширина окна
                PreferredBackBufferHeight = 1100  // Высота окна
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _lightingManager = new LightManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Загрузка текстур
            _backgroundTexture = Content.Load<Texture2D>("light");
            Texture2D lightTexture = Content.Load<Texture2D>("light");

            // Создание источников света
            _lightingManager.AddSpot(new IlluminatedSpot(new Vector2(600, 600), 1.0f, 1.0f, lightTexture, Color.Red));
            _lightingManager.AddSpot(new IlluminatedSpot(new Vector2(0, 0), 1.0f, 1.2f, lightTexture, Color.Blue));
            _lightingManager.AddSpot(new IlluminatedSpot(new Vector2(500, 500), 1.0f, 0.8f, lightTexture, Color.Green));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _lightingManager.Update(GraphicsDevice, gameTime, 4);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Отрисовка фона
            _spriteBatch.Begin();
            _spriteBatch.Draw(_backgroundTexture, Vector2.Zero, Color.White);
            _spriteBatch.End();

            // Отрисовка источников света
            _lightingManager.Render(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
