using System;
using System.Drawing;
using TowerDefense.Engine.Enums;
using TowerDefense.Engine.Physics;
using TowerDefense.Engine.levels;

namespace TowerDefense.Engine.Elements
{
    public class Enemy : GameObject, ICloneable
    {
        public Enemy(int hp, int speed, Size size, Color color)
        {
            HitPoints = hp;
            Speed = speed;
            Size = size;
            Color = color;
            Status = EnemyStatus.Alive;
        }

        public int Speed;
        public int HitPoints;
        public Waypoint Waypoint;
        public EnemyStatus Status;

        /* Size and color, for enemy presentation, becouse we don't use sprites */
        public Size Size;
        public Color Color;

        public override void Update()
        {
            base.Update();

            var positionCenter = new Point(Position.X + Size.Width/2, Position.Y + Size.Height/2);

            var isWaypointReached = Collisions.CheckCircleCollisions(positionCenter, Settings.CircleCollisionsRadius,
                                                                     Waypoint.Point, Settings.CircleCollisionsRadius);
            if (isWaypointReached)
            {
                /* Check, if we at last waypoint, if that destroy enemy, and notify player get damaged */
                if (Waypoint.Next == null)
                {
                    Status = EnemyStatus.Dead;
                    return;
                }

                /* Move to next waypoint */
                Waypoint = Waypoint.Next;
            }

            var directionX = Waypoint.Point.X - positionCenter.X != 0
                                 ? (Waypoint.Point.X - positionCenter.X) / Math.Abs(Waypoint.Point.X - positionCenter.X)
                                 : 0;
            var directionY = Waypoint.Point.Y - positionCenter.Y != 0
                                 ? (Waypoint.Point.Y - positionCenter.Y) / Math.Abs(Waypoint.Point.Y - positionCenter.Y)
                                 : 0;

            Position.X += (directionX * Speed);
            Position.Y += (directionY * Speed);
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            if (Position.X < 0) return;

            graphics.FillRectangle(new SolidBrush(Color), Position.X, Position.Y, Size.Width, Size.Height);
        }

        public object Clone()
        {
            var newEnemy = new Enemy(HitPoints, Speed, Size, Color) {Status = this.Status, Waypoint = this.Waypoint};
            return newEnemy;
        }
    }
}
