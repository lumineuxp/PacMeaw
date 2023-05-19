using GameLib;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using SFML.Graphics;
using System;

namespace PacMeaw
{
    public class Game : BlankEntity
    {
        GameWindow window = new GameWindow(new VideoMode(1280, 720), "PacMeaw");
        Group allObjs = new Group();
        Group visual = new Group();
        FragmentArray fragments;
        TileMap<SpriteEntity> tileMap;
        Player player;

        const int scaling = 4;
        const int tileSize = 32 * scaling;
        Vector2f scailngVector = new Vector2f(scaling, scaling); 


        public Game()
        {
            visual.Position = new Vector2f(200, 200);
            //visual.Add(new SpriteEntity(""));
            fragments = FragmentArray.Create("TileSet.png" ,32,32,14, 14*25);

            var tileArray = new int[3, 4] 
            {
                { 2,3,3,2},
                { 3,1,1,3},
                { 2,1,8,2}
            };

            tileMap = new TileMap<SpriteEntity>(tileSize, tileArray, CreateTile);
            visual.Add(tileMap);

            player = new Player();
            visual.Add(player);
        }

        public void GameMain()
        {
            allObjs.Add(visual);
            allObjs.Add(this); //สำคัญในการดัก event
           
            window.SetKeyRepeatEnabled(false);
            window.RunGameLoop(allObjs);
        }

        Queue<KeyEventArgs> keyQueue = new Queue<KeyEventArgs>();
        LinearMotion motion = LinearMotion.Empty();

        public override void KeyPressed(KeyEventArgs e)
        {
            base.KeyPressed(e);
            //StepJumpMovement(e);
            keyQueue.Enqueue(e);
            SmoothMovement();

        }

        private void SmoothMovement()
        {
            if (!motion.IsFinished())
                return;

            Vector2f direction;
            if (keyQueue.Count > 0)
            {
                var e = keyQueue.Dequeue();
                direction = DirectionKey.Direction4(e.Code);
            }
            else if ((direction = DirectionKey.Normalized4) != new Vector2f(0, 0))
                ;
            else
                direction = motion.GetNormalizedDirection();

            if (!IsAllowMove(direction))
                return;
            float speed = 500;
            motion = new LinearMotion(player, speed, direction * tileSize);

        }
        private bool IsAllowMove(Vector2f direction)
        {
            Vector2i index = tileMap.CalcIndex(player, direction);
            return tileMap.IsInside(index) && IsAllowTile(index);
        }

        private bool IsAllowTile(Vector2i index)
        {
            int tileCode = tileMap.GetTileCode(index);
            return tileCode != 2;
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
            motion.Update(fixTime);
            SmoothMovement();
        }

        private void StepJumpMovement(KeyEventArgs e)
        {
            var direction = DirectionKey.Direction4(e.Code);
            player.Position += direction * tileSize;
        }

        private void SlideShow()
        {
            var sprite = new SpriteEntity();
            sprite.Scale = scailngVector;
            var animation = new Animation(sprite, fragments, 200);

            visual.Add(sprite);
            visual.Add(animation);
        }

        private SpriteEntity CreateTile(int tileCode)
        {
            var fragment = fragments.Fragments[tileCode];
            var sprite = new SpriteEntity(fragment);
            sprite.Origin = new Vector2f(16, 16);
            sprite.Scale = scailngVector;
            return sprite;
        }
    }
}