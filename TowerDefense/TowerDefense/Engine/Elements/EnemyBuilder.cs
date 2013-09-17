using System.Collections.Generic;
using System.Drawing;
using TowerDefense.Engine.levels;

namespace TowerDefense.Engine.Elements
{
    public static class EnemyBuilder
    {
        private static readonly Dictionary<string, Enemy> Enemies = new Dictionary<string, Enemy>
            {
                {"easy", new Enemy(4, 1, new Size(10, 10), Color.Red)},
                {"medium", new Enemy(6, 1, new Size(14, 14), Color.Sienna)}
            };

        public static Enemy CreateEnemy(string type, Waypoint startWaypoint)
        {
            if (!Enemies.ContainsKey(type)) return null;
            var enemy = (Enemy) Enemies[type].Clone();
            enemy.Waypoint = startWaypoint;
            return enemy;
        }
    }
}
