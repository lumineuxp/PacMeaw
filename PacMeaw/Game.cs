using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PacMeaw
{
    public class Game : BlankEntity
    {
        GameWindow window = new GameWindow(new VideoMode(1280, 1024), "PacMeaw");

        Group allObjs = new Group();
        Group visual = new Group();
        FragmentArray fragments;
        TileMap<SpriteEntity> tileMap;
        Player player;
        TileMap<SpriteEntity> itemMap;
        FragmentArray itemFragments;
        Enemy enemy;

        const int scaling = 4;
        const int tileSize = 16 * scaling;
        Vector2f scailngVector = new Vector2f(scaling, scaling);

        Random random = new Random();


        public Game()
        {
            visual.Position = new Vector2f(75, 75);
            //visual.Add(new SpriteEntity(""));
            fragments = FragmentArray.Create("Sprite/bg/Tilemap/tilemap_packed.png", 16, 16, 12, 12 * 11);

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
                { 56,  1, 1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,58},
                { 56,  1, 92,  1,  0,  0, 80, 81, 45, 81, 82,  0,  0,  0, 94,  0,58},
                { 56,  1,104, 57,106,  0,  0,  1,  1,  1,  0,  0, 47,  0, 57,  0,58},
                { 56,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0, 59,  0,  0,  0,58},
                { 68, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45,70},
            };

            tileMap = new TileMap<SpriteEntity>(tileSize, tileArray, CreateTile);
            visual.Add(tileMap);


            // 0 - coin , 1 - fish , 2 - wall , 3 - empty
            itemFragments = FragmentArray.Create("Sprite/item2.png", 417, 417, 2, 2*2);
            var itemArray = new int[13, 17]
            {
                { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                { 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2 },
                { 2, 0, 2, 2, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2 },
                { 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2 },
                { 2, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2 },
                { 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2 },
                { 3, 3, 3, 0, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 3, 3, 3 },
                { 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2 },
                { 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2 },
                { 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 0, 2 },
                { 2, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2 },
                { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2 },
                { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }
            };
            itemMap = new TileMap<SpriteEntity>(tileSize, itemArray, CreateItem);
            visual.Add(itemMap);

            player = new Player();
            player.Position = new Vector2f(50, 50);
            visual.Add(player);

            enemy = new Enemy();
            enemy.Position = new Vector2f(50, 50);
            visual.Add(enemy);

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

            EatItem(direction);
            float speed = 250;
            motion = new LinearMotion(player, speed, direction * tileSize);

        }

        LinearMotion enemyMotion;
        public void Start()
        {
            float speed = 250;  // ความเร็วของศัตรู
            Vector2f randomDirection = GetRandomDirection();

            if (IsAllowMoveEnemy(randomDirection))
            {
                enemyMotion = new LinearMotion(enemy, speed, randomDirection * tileSize);
            }
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

        private bool IsAllowMoveEnemy(Vector2f direction)
        {
            Vector2i index = itemMap.CalcIndex(enemy, direction);
            return itemMap.IsInside(index) && IsAllowTile(index);
        }
        private bool IsAllowMove(Vector2f direction)
        {
            Vector2i index = itemMap.CalcIndex(player, direction);
            return itemMap.IsInside(index) && IsAllowTile(index);

        }

        private bool IsAllowTile(Vector2i index)
        {
            int tileCode = itemMap.GetTileCode(index);
            //int[] edges = { 5, 17, 27, 28, 44, 45, 46, 47, 56, 57, 58, 59, 68, 70, 71, 80, 81, 82, 83, 94, 95, 104, 106, 107 };
            //return !edges.Contains(tileCode);
            return tileCode != 2;
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
            if (enemyMotion == null || enemyMotion.IsFinished())
            {
                Start();
            }
            else
            {
                enemyMotion.Update(fixTime);
                motion.Update(fixTime);
                SmoothMovement();
            }

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

        private SpriteEntity CreateItem(int tileCode)
        {
            var fragment = itemFragments.Fragments[tileCode];
            var sprite = new SpriteEntity(fragment);
            sprite.Origin = ((FloatRect)fragment.Rect).GetSize() / 2;
            sprite.Scale = scailngVector / 25;
            return sprite;
        }

        private void EatItem(Vector2f direction)
        {
            Vector2i index = itemMap.CalcIndex(player, direction);
            int tileCode = itemMap.GetTileCode(index);
            if (tileCode == 0 ^ tileCode == 1)
            {
                itemMap.SetTileCode(index, 3);
            }
            itemMap.Clear();
            itemMap.CreateTileMap();

        }

    }
}