using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace lab8
{
    class IlluminatedSpot
    {
        // Свойства круга света
        private Vector2 _position;
        private float _intensity; 
        private float _spread; 
        private readonly Texture2D _image; 
        private Color _shade; 

        private int _xDirection = 1; 
        private int _yDirection = 1; 

        public IlluminatedSpot(Vector2 position, float intensity, float spread, Texture2D image, Color shade)
        {
            _position = position;
            _intensity = intensity;
            _spread = spread;
            _image = image;
            _shade = shade;
        }
        // Логика перемещения объекта света
        public void Move(GraphicsDevice graphicsDevice, int velocity)
        {
            int screenWidth = graphicsDevice.Viewport.Width;
            int screenHeight = graphicsDevice.Viewport.Height;

            // Изменяем положение объекта
            _position += new Vector2(_xDirection * velocity, _yDirection * velocity);

            // Проверка границ экрана
            if (_position.X + _image.Width / 2 > screenWidth || _position.X - _image.Width / 2 < 0)
            {
                _xDirection *= -1;
                _position.X = Math.Clamp(_position.X, _image.Width / 2, screenWidth - _image.Width / 2);
            }

            if (_position.Y + _image.Height / 2 > screenHeight || _position.Y - _image.Height / 2 < 0)
            {
                _yDirection *= -1;
                _position.Y = Math.Clamp(_position.Y, _image.Height / 2, screenHeight - _image.Height / 2);
            }
        }

        // Обновление состояние объекта света
        public void Refresh(GraphicsDevice graphicsDevice, GameTime gameTime, int velocity)
        {
            Move(graphicsDevice, velocity);
        }

        // Рисование текстуру источника света
        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _image,
                _position,
                null,
                _shade * _intensity,
                0f,
                new Vector2(_image.Width / 2f, _image.Height / 2f),
                new Vector2(_spread, _spread),
                SpriteEffects.None,
                0f
            );
        }
   

        // Свойства доступа
        public Vector2 Position { get => _position; set => _position = value; }
        public float Intensity { get => _intensity; set => _intensity = value; }
        public float Spread { get => _spread; set => _spread = value; }
        public Texture2D Image => _image;
        public Color Shade { get => _shade; set => _shade = value; }
    }
}
