using GameLib;
using SFML.System;
using System;
using System.Collections.Generic;

namespace PacMeaw
{
    public class LifePoint : KinematicBody
    {
        public List<SpriteEntity> lifeSprites;
        public int life;
        

        public LifePoint(int initialLife)
        {
            life = initialLife;
            lifeSprites = new List<SpriteEntity>();

            var texture = TextureCache.Get("lifepoint.png");

            for (int i = 0; i < initialLife; i++)
            {
                var sprite = new SpriteEntity(texture);
                sprite.Origin = new Vector2f(16, 23);
                sprite.Scale = new Vector2f(0.1f, 0.1f);
                sprite.Position = new Vector2f(i * 60 - 60, 0);
                Add(sprite);
                lifeSprites.Add(sprite);
            }
        }

        public int GetPoint()
        {
            return life;
        }

        public void SetPoint(int value)
        {
            life = value;
        }

        public void RemoveToScore(int value)
        {
            life -= value;

        }

        

    }
}
