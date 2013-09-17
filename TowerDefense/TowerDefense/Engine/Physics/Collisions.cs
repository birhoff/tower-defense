using System.Drawing;

namespace TowerDefense.Engine.Physics
{
    public static class Collisions
    {
        public static bool CheckCircleCollisions(Point circle1Center, int circle1Radius, Point circle2Center, int circle2Radius)
        {
            var radius = circle1Radius + circle2Radius;
            var deltaX = circle1Center.X - circle2Center.X;
            var deltaY = circle1Center.Y - circle2Center.Y;
            return deltaX * deltaX + deltaY * deltaY <= radius * radius;
        }
    }
}
