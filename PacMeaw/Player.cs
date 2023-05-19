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
    public class Player : Group
    {
        public Player() 
        {
            var texture = TextureCache.Get("Guy.png");
            var sprite = new SpriteEntity(texture, new IntRect(0,0,32,48));
            Add(sprite);
            sprite.Origin = new Vector2f(16,40);
            sprite.Scale = new Vector2f(4, 4);

        }
    }
}
