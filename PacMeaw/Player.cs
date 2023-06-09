﻿using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PacMeaw
{
    public class Player : KinematicBody
    {
        AnimationStates states;
        CollisionObj collisionObj;
        int mode = 0;
        
        public Player() 
        {
         
            var texture = TextureCache.Get("Sprite/cat/cat1cut.png");
            var sprite = new SpriteEntity();
            Add(sprite);
            sprite.Origin = new Vector2f(16,23);
            sprite.Scale = new Vector2f(3, 3);

            var fragments = FragmentArray.Create(texture, 32,32);
            var duration = 0.75f;
            var stay = new Animation(sprite, fragments.SubArray(0, 1), duration);
            var left = new Animation(sprite, fragments.SubArray(3, 3), duration);
            var right = new Animation(sprite, fragments.SubArray(6, 3), duration); 
            var up = new Animation(sprite, fragments.SubArray(9, 3), duration);
            var down = new Animation(sprite, fragments.SubArray(0, 3), duration);

            states = new AnimationStates(stay, left, right, up ,down);
            Add(states);

            var shape = new CollisionRect(sprite.GetGlobalBounds().AdjustSize(0.4f, 0.5f));
            collisionObj = new CollisionObj(shape);
            collisionObj.DebugDraw = false;
            collisionObj.OnCollide += OnCollide;
            Add(collisionObj);

        }


        private void OnCollide(CollisionObj objB, CollideData Data)
        {
            if (mode == 0) // dog eat cat
            {
                if (objB.Parent is Enemy)
                {
                    
                    this.Position = new Vector2f(50, 50);
                    GameData.LifePoint -= 1;
                }
            }
            else if (mode == 1) //power cat
            {
                if (objB.Parent is Enemy)
                {
                    var enemy = objB.Parent as Enemy;
                    enemy.Position = new Vector2f(500, 350);
                    GameData.Score += 500;

                }
            }
        }

   
        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
        }

        public override void FrameUpdate(float deltaTime)
        {
            base.FrameUpdate(deltaTime);
            var direction = DirectionKey.Normalized;

            if (direction.X < 0)
                states.Animate(1);
            else if (direction.X > 0)
                states.Animate(2);
            else if (direction.Y < 0)
                states.Animate(3);
            else if (direction.Y > 0)
                states.Animate(4);
        }
        public void ChangeMode(int mode)
        {
            this.mode = mode;
        }
    }
}
