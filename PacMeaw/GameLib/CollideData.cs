using SFML.Graphics;
using SFML.System;

namespace GameLib
{
    public struct CollideData
    {
        public FloatRect OverlapRect;
        public bool FirstContact;

        public object LifePoint { get; internal set; }

        //public Vector2i TileIndex { get; set; }
    }
}
