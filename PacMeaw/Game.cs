using GameLib;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using SFML.Graphics;
using System;
using System.Linq;

namespace PacMeaw
{
    public class Game : BlankEntity
    {
        GameWindow window = new GameWindow(new VideoMode(1280, 1024), "PacMeaw");
        //window.BackgroundColor = "#88c46c"
        

        Group allObjs = new Group();
        Group visual = new Group();
        FragmentArray fragments;
        TileMap<SpriteEntity> tileMap;
        Player player;

        const int scaling = 4;
        const int tileSize = 16 * scaling;
        Vector2f scailngVector = new Vector2f(scaling, scaling); 


        public Game()
        {
            visual.Position = new Vector2f(75, 75);
            //visual.Add(new SpriteEntity(""));
            fragments = FragmentArray.Create("Sprite/bg/Tilemap/tilemap_packed.png", 16,16,12, 12*11);

            var tileArray = new int[13, 17] 
            {
                { 44, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45,46},
                { 56,  1,  0,  0,  1,  0,  0,  0, 59,  1,  0,  0,  5,  0,  0,  1,58},
                { 56,  1,  5,  5,  5,  0,107,  0, 71,  1,106,  1,  5,  0, 92,  0,58},
                { 56,  1, 95,  0,  0,  0, 17,  0,  0,  0,  0,  0, 83,  0,104,  0,58},
                { 56,  1,  0,  0, 27,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,58},
                { 68, 45, 82,  0, 28,  0, 44, 82,  1, 80, 46,  0,  1,  0, 80, 45,70},
                { 43, 43, 43,  0, 27,  0, 56,  1,  1,  1, 56,  0,  1,  1, 43, 43,43},
                { 44, 45, 82,  0, 28,  0, 68, 45, 45, 45, 70,  0,  1,  1, 80, 45,46},
                { 56,  1, 29,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,58},
                { 56,  1, 92,  1,  0,  0, 80, 81, 45, 81, 82,  0,  0,  0, 94,  0,58},
                { 56,  1,104, 57,106,  0,  0,  1,  1,  1,  0,  0, 47,  0, 57,  0,58},
                { 56,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0, 59,  0,  0,  0,58},
                { 68, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45,70},
            };

            tileMap = new TileMap<SpriteEntity>(tileSize, tileArray, CreateTile);
            visual.Add(tileMap);

            player = new Player();
            player.Position = new Vector2f(50,50);
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
            float speed = 300;
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
            int[] edges = { 5, 17,27, 28, 44, 45, 46,47, 56, 57, 58, 59, 68,70, 71, 80, 81, 82,83, 94, 95, 104, 106 };
            return !edges.Contains(tileCode);
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
            motion.Update(fixTime);
            SmoothMovement();
        }

        private SpriteEntity CreateTile(int tileCode)
        {
            var fragment = fragments.Fragments[tileCode];
            var sprite = new SpriteEntity(fragment);
            sprite.Origin = new Vector2f(8, 8);
            //sprite.Origin = ((FloatRect)fragment.Rect).GetSize()/2;
            sprite.Scale = scailngVector;
            return sprite;
        }
    }
}