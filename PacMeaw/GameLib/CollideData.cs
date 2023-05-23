using SFML.Graphics;
using SFML.System;

namespace GameLib
{
    public struct CollideData
    {
        public FloatRect OverlapRect;
        public bool FirstContact;

        //public Vector2i TileIndex { get; set; }
    }
}
