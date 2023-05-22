﻿using GameLib;
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
        CollisionObj collisionObj;

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
            sprite.Scale = new Vector2f(3,3);

            var fragments = FragmentArray.Create(texture, 32, 32);
            var duration = 0.75f;
            var stay = new Animation(sprite, fragments.SubArray(0,1), duration);
            var left = new Animation(sprite, fragments.SubArray(12,4), duration);
            var right = new Animation(sprite, fragments.SubArray(4,4), duration);
            var up = new Animation(sprite, fragments.SubArray(8,4), duration);
            var down = new Animation(sprite, fragments.SubArray(0,4), duration);

            states = new AnimationStates(stay, left, right, up, down);
            Add(states);

           
            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.4f,0.5f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);
        }

        private void OnCollide(CollisionObj objB, CollideData collideData)
        {
            var player = objB.Parent as Player;
            player!.Detach();
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
        }
        
        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
        }


    }
}
