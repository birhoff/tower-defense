using System.Drawing;
using System.Linq;
using TowerDefense.Engine.Enums;
using TowerDefense.Engine.Physics;

namespace TowerDefense.Engine.Elements
{
    public class Tower : GameObject
    {
        private Point _towerCenter;
        private Point _towerPosition;

        private int _reloadTime;
        private int _atackLengthTime;

        
        public Tower(int radius, int damage, float fireRate, Color color)
        {
            Size = new Size(28, 28);

            AttackRadius = radius;
            Damage = damage;
            FireRate = fireRate;
            Color = color;
            TargetEnemy = null;
            Status = TowerStatus.Idle;

            _towerCenter = Point.Empty;
            _reloadTime = 0;
            _atackLengthTime = 0;
        }

        public Size Size;
        public Color Color;
        public int AttackRadius;
        public int Damage;
        public float FireRate;
        public TowerStatus Status;

        public Enemy TargetEnemy;

        public new Point Position
        {
            get { return _towerPosition; }
            set
            {
                _towerPosition = value;
                _towerCenter = new Point(_towerPosition.X + Size.Width/2, _towerPosition.Y + Size.Height/2);
            }
        }

        public override void Update()
        {
            base.Update();

            /* Chack can we attack or not */
            if (Status != TowerStatus.Idle)
            {
                _reloadTime--;
                _atackLengthTime--;

                /* If enemy died end fire animation */
                if (TargetEnemy == null || TargetEnemy.Status == EnemyStatus.Dead)
                {
                    _atackLengthTime = 0;
                }

                if (_reloadTime > 0)
                    return;

                Status = TowerStatus.Idle;
            }

            var attackingEnemy = GetEnemyForAttack();
            if (attackingEnemy == null)
                return;

            Status = TowerStatus.Attack;
            _reloadTime = (int) (Settings.TicksPerSecond/FireRate);
            _atackLengthTime = (int) (_reloadTime/10);
            TargetEnemy.HitPoints -= Damage;
            if (TargetEnemy.HitPoints < 0) TargetEnemy.Status = EnemyStatus.Dead;
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
#if DEBUG
            graphics.DrawEllipse(new Pen(Color.Aqua), _towerCenter.X - AttackRadius,
                                 _towerCenter.Y-AttackRadius, AttackRadius*2, AttackRadius*2);
#endif
            graphics.FillRectangle(new SolidBrush(Color), _towerPosition.X, _towerPosition.Y, Size.Width, Size.Height);
            if (Status == TowerStatus.Idle) return;

            if (_atackLengthTime > 0)
            {
                graphics.DrawLine(new Pen(Color.Coral), _towerCenter.X, _towerCenter.Y,
                                  TargetEnemy.Position.X + TargetEnemy.Size.Width/2,
                                  TargetEnemy.Position.Y + TargetEnemy.Size.Height/2);
            }
        }

        private Enemy GetEnemyForAttack()
        {
            var enemies = Scene.Enemies;
            if (enemies == null) return null;
            if (TargetEnemy != null)
            {
                if (IsInRange(TargetEnemy))
                {
                    return TargetEnemy;
                }
                else
                {
                    TargetEnemy = null;
                }
            }

            foreach (var enemy in enemies.Where(IsInRange))
            {
                TargetEnemy = enemy;
                return TargetEnemy;
            }
            return null;
        }

        private bool IsInRange(Enemy enemy)
        {
            if (enemy.Status == EnemyStatus.Dead) return false;
            var enemyCenter = new Point(enemy.Position.X + enemy.Size.Width/2, enemy.Position.Y + enemy.Size.Height/2);
            return Collisions.CheckCircleCollisions(_towerCenter, AttackRadius, enemyCenter, enemy.Size.Width/2);
        }
    }
}
