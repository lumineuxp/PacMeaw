using GameLib;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMeaw
{
    public class LifePoint : KinematicBody
    {
        public LifePoint() 
        {
            //รูป1
            var texture = TextureCache.Get("lifepoint.png");
            var sprite = new SpriteEntity(texture);
            Add(sprite);
            sprite.Origin = new Vector2f(16, 23);
            sprite.Scale = new Vector2f(0.1f,0.1f);
            //รูป2
            var sprite2 = new SpriteEntity(texture);
            sprite2.Origin = new Vector2f(16, 23);
            sprite2.Scale = new Vector2f(0.1f, 0.1f);
            sprite2.Position = new Vector2f(60, 0);
            Add(sprite2);
            //รูป3
            var sprite3 = new SpriteEntity(texture);
            sprite3.Origin = new Vector2f(16, 23);
            sprite3.Scale = new Vector2f(0.1f, 0.1f);
            sprite3.Position = new Vector2f(-60, 0);
            Add(sprite3);


        }
        private int life;

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
