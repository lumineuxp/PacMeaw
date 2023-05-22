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
        Random random;
        float movementTimer;
        float movementInterval;
        int tileSize = 16 * 4;
        TileMap<SpriteEntity> tileMap;
        Queue<int> directionQueue;  // สร้างคิวเพื่อเก็บค่าทิศทาง

        public Enemy()
        {
            //this.tileMap = itemMap;
            random = new Random();
            //movementInterval = 1.0f;  // ช่วงเวลาที่ศัตรูจะเปลี่ยนทิศทางสุ่ม (เปลี่ยนตามความต้องการ)
            //directionQueue = new Queue<int>();  // สร้างคิวเมื่อสร้างออบเจ็กต์ Enemy

            var texture = TextureCache.Get("Sprite/enemy/dog.png");
            var sprite = new SpriteEntity();
            Add(sprite);
            sprite.Origin = new Vector2f(16, 23);
            sprite.Scale = new Vector2f(3, 3);

            var fragments = FragmentArray.Create(texture, 32, 32);
            var duration = 0.75f;
            var stay = new Animation(sprite, fragments.SubArray(0,1), duration);
            var left = new Animation(sprite, fragments.SubArray(6,5), duration);
            var right = new Animation(sprite, fragments.SubArray(12,5), duration);
            var up = new Animation(sprite, fragments.SubArray(18,5), duration);
            var down = new Animation(sprite, fragments.SubArray(0,5), duration);

            states = new AnimationStates(stay, left, right, up, down);
            Add(states);
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);

        }
        
        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);

            //Vector2f randomDirection = GetRandomDirection();

            //    if (randomDirection == new Vector2f(1, 0))
            //        states.Animate(2);
            //    else if (randomDirection == new Vector2f(-1, 0))
            //        states.Animate(1);
            //    else if (randomDirection == new Vector2f(0, 1))
            //        states.Animate(4);
            //    else if (randomDirection == new Vector2f(0, -1))
            //        states.Animate(3);
        }


        private Vector2f GetRandomDirection()
        {
            Vector2f[] directions = {
                    new Vector2f(1, 0),   // ขวา
                    new Vector2f(-1, 0),  // ซ้าย
                    new Vector2f(0, 1),   // ลง
                    new Vector2f(0, -1)   // ขึ้น
             };

            return directions[random.Next(0, 4)];
        }


    }
}
