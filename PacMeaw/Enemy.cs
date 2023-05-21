using GameLib;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMeaw
{
    internal class Enemy : KinematicBody
    {
        AnimationStates states;
        public Enemy(String textureName) 
        {
            var texture = TextureCache.Get(textureName);
            var sprite = new SpriteEntity();
            Add(sprite);
            sprite.Origin = new Vector2f(16, 23);
            sprite.Scale = new Vector2f(3, 3);

            var fragments = FragmentArray.Create(texture, 32, 32);
            var duration = 0.75f;
            var stay = new Animation(sprite, fragments.SubArray(6, 1), duration);
            var left = new Animation(sprite, fragments.SubArray(18, 3), duration);
            var right = new Animation(sprite, fragments.SubArray(30, 3), duration);
            var up = new Animation(sprite, fragments.SubArray(42, 3), duration);
            var down = new Animation(sprite, fragments.SubArray(6, 3), duration);

            states = new AnimationStates(stay, left, right, up, down);
            Add(states);
        }
    }
}
