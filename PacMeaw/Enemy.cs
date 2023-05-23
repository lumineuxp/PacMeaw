using GameLib;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        CollisionObj collisionObj;
        int mode = 0;

        public Enemy()
        {
            //this.tileMap = itemMap;
            random = new Random();
            
            //movementInterval = 1.0f;  // ช่วงเวลาที่ศัตรูจะเปลี่ยนทิศทางสุ่ม (เปลี่ยนตามความต้องการ)
            //directionQueue = new Queue<int>();  // สร้างคิวเมื่อสร้างออบเจ็กต์ Enemy

            var texture = TextureCache.Get("Sprite/enemy/floating skulls.png");
            var sprite = new SpriteEntity();
            Add(sprite);
            sprite.Origin = new Vector2f(20, 40);
            sprite.Scale = new Vector2f(2,2);

            var fragments = FragmentArray.Create(texture, 48, 48);
            var duration = 0.75f;
            var escape = new Animation(sprite, fragments.SubArray(57,3), duration);
     
            var chase = new Animation(sprite, fragments.SubArray(0,3), duration);

            states = new AnimationStates(chase, escape);
            Add(states);

           
            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.4f,0.5f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        private void OnCollide(CollisionObj objB, CollideData GameData)
        {

        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
        }
        
        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);

        }

        public void ChangeMode(int mode)
        {
            this.mode = mode;
            if (mode == 0)
            {
                states.Animate(0);
            }else if (mode == 1)
            {
                states.Animate(1);
            }
        }

    }
}
