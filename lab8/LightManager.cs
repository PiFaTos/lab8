using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace lab8
{
    class LightManager
    {
        private List<IlluminatedSpot> _spots; // Список источников света

        public LightManager()
        {
            _spots = new List<IlluminatedSpot>();
        }

        // Добавление нового источника света
        public void AddSpot(IlluminatedSpot spot) => _spots.Add(spot);

        // Удаление источника света
        public void RemoveSpot(IlluminatedSpot spot) => _spots.Remove(spot);

        // Обновление всех источников света
        public void Update(GraphicsDevice graphicsDevice, GameTime gameTime, int speed)
        {
            foreach (var spot in _spots)
            {
                spot.Refresh(graphicsDevice, gameTime, speed);
            }
        }

        // Отрисовка всех источников света
        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

            foreach (var spot in _spots)
            {
                spot.Render(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
