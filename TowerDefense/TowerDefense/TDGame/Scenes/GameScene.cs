using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TowerDefense.Engine;
using TowerDefense.Engine.Elements;
using TowerDefense.Engine.Enums;
using TowerDefense.Engine.Physics;
using TowerDefense.Engine.levels;
using TowerDefense.TDGame.Levels;

namespace TowerDefense.TDGame.Scenes
{
    public class GameScene : Engine.Scenes.TDGameScene
    {
        private Game _game;
        private Device _device;
        private Level _currentLevel;
        private Wave _currentWave;

        private List<Enemy> _enemies;
        private List<Tower> _towers;

        private int _nextPackTimeLeft;

        public override void Initialize(Game game, Device device)
        {
            _game = game;
            _device = device;
            _currentLevel = new Level1();
            _currentWave = _currentLevel.Waves[0];
            _enemies = new List<Enemy>();
            _towers = new List<Tower>();

            _nextPackTimeLeft = 0;
        }

        public override void Start()
        {
            LoadNextPack();
        }

        public override void Update()
        {
            _nextPackTimeLeft--;

            var enemiesToRemove = _enemies.Where(enemy => enemy.Status == EnemyStatus.Dead).ToList();
            foreach (var enemyToRemove in enemiesToRemove)
            {
                _enemies.Remove(enemyToRemove);
            }

            if (_nextPackTimeLeft < 0)
            {
                if (_currentWave.Packs.Count != 0)
                {
                    LoadNextPack();
                }
                else
                {
                    
                }
            }

            /* check inputs */
            if (_device.Input.Mouse.IsMouseDown)
            {
                foreach (var towerPosition in _currentLevel.TowerPositions)
                {
                    if (!Collisions.CheckPointInRectangle(_device.Input.Mouse.Position,
                                                          new Rectangle(towerPosition, Settings.TowerSize))) continue;

                    var freeSpot = _towers.All(tower => tower.Position != towerPosition);
                    if(!freeSpot) break;
                    _towers.Add(TowerBuilder.CreateTower("standart1", towerPosition, this));
                }
            }

            foreach (var enemy in _enemies)
            {
                enemy.Update();
            }

            foreach (var tower in _towers)
            {
                tower.Update();
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.Clear(Color.DarkGray);

            /* Draw background map */
            graphics.DrawImage(_currentLevel.Map, 0, 0, Settings.MapSize.Width, Settings.MapSize.Height);

            var background = new Rectangle(0, 0, Settings.MapSize.Width, Settings.MapSize.Height);
            var penDraw = new Pen(Color.Black, 1);
            graphics.DrawRectangle(penDraw, background);

#if DEBUG
            var waypoint = _currentLevel.StartWaypoint;
            while (waypoint.Next != null)
            {
                if (waypoint.Next != null)
                {
                    graphics.DrawLine(new Pen(Color.WhiteSmoke), waypoint.Point.X, waypoint.Point.Y, waypoint.Next.Point.X,
                                  waypoint.Next.Point.Y);
                }

                graphics.FillEllipse(new SolidBrush(Color.GreenYellow), waypoint.Point.X - 5, waypoint.Point.Y - 5, 10, 10);

                graphics.DrawLine(new Pen(Color.DarkSeaGreen), waypoint.Point.X-5, waypoint.Point.Y-5, waypoint.Point.X-5,
                                  waypoint.Point.Y-5);
                
                waypoint = waypoint.Next;
            }
#endif


            foreach (var enemy in _enemies)
            {
                enemy.Draw(graphics);
            }

            foreach (var tower in _towers)
            {
                tower.Draw(graphics);
            }

        }

        public override void Destroy()
        {
            
        }

        public new List<Enemy> Enemies
        {
            get { return _enemies; }
        }

        private void LoadNextPack()
        {
            /* Create first pack, and start timer for second */
            var firstPack = _currentWave.Packs[0];
            _currentWave.Packs.RemoveAt(0);

            for (int i = 0; i < firstPack.Length; i++)
            {
                var enemy = firstPack[i];
                enemy.Position =
                    new Point(
                        (_currentLevel.StartPosition.X - enemy.Size.Width) -
                        (i * (Settings.EnemiesStartDistance + enemy.Size.Width)),
                        _currentLevel.StartPosition.Y);

                _enemies.Add(enemy);
            }
            _nextPackTimeLeft = Settings.NextPackTime;
        }
    }
}
