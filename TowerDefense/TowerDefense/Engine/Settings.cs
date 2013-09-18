using System.Drawing;

namespace TowerDefense.Engine
{
    public static class Settings
    {
        public static int EnemiesStartDistance = 10;
        public static int CircleCollisionsRadius = 5;

        public static Size MapSize = new Size(800, 600);

        public static Size TowerSize = new Size(28, 28);

        public const int TicksPerSecond = 60;
        public const int NextPackTime = TicksPerSecond * 4;
    }
}
