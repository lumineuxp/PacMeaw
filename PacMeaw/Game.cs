using GameLib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics;
using System.Security.Policy;


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
        Enemy enemy2;
        Enemy enemy3;
        Enemy enemy4;

        //ScoreCount score = new ScoreCount();
        Label scoreLabel;

        const int scaling = 4;
        const int tileSize = 16 * scaling;
        Vector2f scailngVector = new Vector2f(scaling, scaling);
        int i = 0;

        Random random = new Random();


        public Game()
        {
           
            scoreLabel = new Label(String.Format("Score: {0}", GameData.Score.ToString()), "Early GameBoy.ttf", 35);
            scoreLabel.Position = new Vector2f(750, 25);
            allObjs.Add(scoreLabel);

            visual.Position = new Vector2f(75, 100);
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
                { 56,  1, 1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0, 58},
                { 56,  1, 92,  1,  0,  0, 80, 81, 45, 81, 82,  0,  0,  0, 94,  0,58},
                { 56,  1,104, 57,106,  0,  0,  1,  1,  1,  0,  0, 47,  0, 57,  0,58},
                { 56,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0, 59,  0,  0,  0,58},
                { 68, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45,70},
            };

            tileMap = new TileMap<SpriteEntity>(tileSize, tileArray, CreateTile);
            visual.Add(tileMap);


            // 0 - coin , 1 - fish , 2 - wall , 3 - empty
            itemFragments = FragmentArray.Create("Sprite/item.png", 417, 417, 2, 2 * 2);
            var itemArray = new int[13, 17]
            {
                { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                { 2, 3, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2 },
                { 2, 0, 2, 2, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2 },
                { 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2 },
                { 2, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2 },
                { 2, 2, 2, 0, 2, 0, 2, 2, 3, 2, 2, 0, 0, 0, 2, 2, 2 },
                { 3, 3, 3, 0, 2, 0, 2, 3, 3, 3, 2, 0, 0, 0, 3, 3, 3 },
                { 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2 },
                { 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2 },
                { 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 2, 0, 2 },
                { 2, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2 },
                { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2 },
                { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }
            };
            itemMap = new TileMap<SpriteEntity>(tileSize, itemArray, CreateTileItem);
            visual.Add(itemMap);

            player = new Player();
            player.Position = new Vector2f(50, 50);
            visual.Add(player);

            enemy = new Enemy();
            enemy.Position = new Vector2f(500, 350);
            visual.Add(enemy);

            enemy2 = new Enemy();
            enemy2.Position = new Vector2f(500, 350);
            visual.Add(enemy2);

            enemy3 = new Enemy();
            enemy3.Position = new Vector2f(700, 600);
            visual.Add(enemy3);

            enemy4 = new Enemy();
            enemy4.Position = new Vector2f(300, 600);
            visual.Add(enemy4);

        }

        public void GameMain()
        {
            allObjs.Add(visual);
            allObjs.Add(this); //สำคัญในการดัก event       
            GameData.LifePoint = 3;
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

        Queue<Vector2f> keyQueueEnemy = new Queue<Vector2f>();
        LinearMotion enemyMotion;
        Vector2f randomDirection;
        Queue<Vector2f> keyQueueEnemy2 = new Queue<Vector2f>();
        LinearMotion enemyMotion2;
        Vector2f randomDirection2;
        Queue<Vector2f> keyQueueEnemy3 = new Queue<Vector2f>();
        LinearMotion enemyMotion3;
        Vector2f randomDirection3;
        Queue<Vector2f> keyQueueEnemy4 = new Queue<Vector2f>();
        LinearMotion enemyMotion4;
        Vector2f randomDirection4;
        float speed = 150;
        public void EnemyRandomPath()
        {
           
            randomDirection = GetRandomDirection();

            if (enemyMotion == null)
                enemyMotion = LinearMotion.Empty();

            if (IsAllowMoveEnemy(randomDirection, enemy))
            {
                keyQueueEnemy.Enqueue(randomDirection);
                if (!enemyMotion.IsFinished())
                    return;

                if (keyQueueEnemy.Count > 0)
                {
                    var e = keyQueueEnemy.Dequeue();
                    randomDirection = e;
                }
                else if (randomDirection != new Vector2f(0, 0))
                    ;
                else
                    randomDirection = enemyMotion.GetNormalizedDirection();

                if (!IsAllowMoveEnemy(randomDirection, enemy))
                    return;

                
                enemyMotion = new LinearMotion(enemy, speed, randomDirection * tileSize);
            }
        }
        public void Enemy2RandomPath()
        {
           
            randomDirection2 = GetRandomDirection();

            if (enemyMotion2 == null)
                enemyMotion2 = LinearMotion.Empty();

            if (IsAllowMoveEnemy(randomDirection2, enemy2))
            {
                keyQueueEnemy2.Enqueue(randomDirection2);
                if (!enemyMotion2.IsFinished())
                    return;

                if (keyQueueEnemy2.Count > 0)
                {
                    var e = keyQueueEnemy2.Dequeue();
                    randomDirection2 = e;
                }
                else if (randomDirection2 != new Vector2f(0, 0))
                    ;
                else
                    randomDirection2 = enemyMotion2.GetNormalizedDirection();

                if (!IsAllowMoveEnemy(randomDirection2,enemy2))
                    return;

               
                enemyMotion2 = new LinearMotion(enemy2, speed, randomDirection2 * tileSize);
            }
        }

        public void Enemy3RandomPath()
        {

            randomDirection3 = GetRandomDirection();

            if (enemyMotion3 == null)
                enemyMotion3 = LinearMotion.Empty();

            if (IsAllowMoveEnemy(randomDirection3, enemy3))
            {
                keyQueueEnemy3.Enqueue(randomDirection3);
                if (!enemyMotion3.IsFinished())
                    return;

                if (keyQueueEnemy3.Count > 0)
                {
                    var e = keyQueueEnemy3.Dequeue();
                    randomDirection3 = e;
                }
                else if (randomDirection3 != new Vector2f(0, 0))
                    ;
                else
                    randomDirection3 = enemyMotion3.GetNormalizedDirection();

                if (!IsAllowMoveEnemy(randomDirection3, enemy3))
                    return;


                enemyMotion3 = new LinearMotion(enemy3, speed, randomDirection3 * tileSize);
            }
        }

        public void Enemy4RandomPath()
        {

            randomDirection4 = GetRandomDirection();

            if (enemyMotion4 == null)
                enemyMotion4 = LinearMotion.Empty();

            if (IsAllowMoveEnemy(randomDirection4, enemy4))
            {
                keyQueueEnemy4.Enqueue(randomDirection4);
                if (!enemyMotion4.IsFinished())
                    return;

                if (keyQueueEnemy4.Count > 0)
                {
                    var e = keyQueueEnemy4.Dequeue();
                    randomDirection4 = e;
                }
                else if (randomDirection4 != new Vector2f(0, 0))
                    ;
                else
                    randomDirection4 = enemyMotion4.GetNormalizedDirection();

                if (!IsAllowMoveEnemy(randomDirection4, enemy4))
                    return;


                enemyMotion4 = new LinearMotion(enemy4, speed, randomDirection4 * tileSize);
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
            var randomDirection = directions[random.Next(0, 4)];

            return randomDirection;
        }

        private bool IsAllowMoveEnemy(Vector2f direction,Transformable enemy)
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
          
            return tileCode != 2;
        }

        public override void PhysicsUpdate(float fixTime)
        {
            base.PhysicsUpdate(fixTime);
            if (enemyMotion == null )
            {
                EnemyRandomPath();
                Enemy2RandomPath();
                Enemy3RandomPath();
                Enemy4RandomPath();
            }
            else
            {
                enemyMotion.Update(fixTime);
                enemyMotion2.Update(fixTime);
                enemyMotion3.Update(fixTime);
                enemyMotion4.Update(fixTime);
                motion.Update(fixTime);
                SmoothMovement();
                EnemyRandomPath();
                Enemy2RandomPath();
                Enemy3RandomPath();
                Enemy4RandomPath();

            }
            scoreLabel.SetText(String.Format("Score: {0}", GameData.Score.ToString()));

            if (GameData.LifePoint == 0 & i == 0)
            {
                window.SetVisible(false);
                Score scoreboard = new Score();
                scoreboard.SetScore(GameData.Score);
                scoreboard.Show();

                i++;
            }

         
        }

        private Vector2f ChasePlayer()
        {
            Vector2i enemyIndex = itemMap.CalcIndex(enemy.Position);
            Vector2i playerIndex = itemMap.CalcIndex(player.Position);

            // คำนวณทิศทางเคลื่อนที่ตามตำแหน่งของผู้เล่น
            Vector2i direction = playerIndex - enemyIndex;

            // ปรับให้เป็นทิศทาง 4 ทิศทางเท่านั้น (ข้ามทิศทางเชิงเส้นตรง)
            if (direction.X != 0)
                direction.Y = 0;

            // ปรับให้เป็นทิศทางเดียวกันที่มีความยาวเท่ากัน
            if (direction.X < 0)
                direction.X = -1;
            else if (direction.X > 0)
                direction.X = 1;
            if (direction.Y < 0)
                direction.Y = -1;
            else if (direction.Y > 0)
                direction.Y = 1;

            return new Vector2f(direction.X, direction.Y);
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

        private SpriteEntity CreateTileItem(int tileCode)
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
                if (tileCode == 1)
                    ChangeMode();

                itemMap.SetTileCode(index, 3);
                itemMap.Clear();
                itemMap.CreateTileMap();

                CountScore(tileCode);
            }

            if (!itemMap.CheckExistItemOnTile() & i == 0)
            {
                window.SetVisible(false);
                Score scoreboard = new Score();
                scoreboard.SetScore(GameData.Score);
                scoreboard.Show();

                i += 1;
            }
        }
        public void CountScore(int tileCode)
        {
            if (tileCode == 0)
                //score.AddToScore(10);
                GameData.Score += 10;
            else if (tileCode == 1) //fish
                GameData.Score += 100;
           
            scoreLabel.SetText(String.Format("Score: {0}", GameData.Score.ToString()));
        }

        void ChangeMode()
        {
            player.ChangeMode(1);
            enemy.ChangeMode(1);
            enemy2.ChangeMode(1);
            enemy3.ChangeMode(1);
            enemy4.ChangeMode(1);

        }

    }
}
