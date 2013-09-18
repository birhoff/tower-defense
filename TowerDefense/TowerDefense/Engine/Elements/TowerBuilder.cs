using System.Collections.Generic;
using System.Drawing;
using TowerDefense.TDGame.Scenes;

namespace TowerDefense.Engine.Elements
{
    public class TowerBuilder
    {
        private static readonly Dictionary<string, Tower> Towers = new Dictionary<string, Tower>
            {
                {"standart1", new Tower(125,3,1.25f, Color.Tomato)},
                {"standart2", new Tower(125,6,1.25f, Color.Tomato)}
            };

        public static Tower CreateTower(string type, Point position, GameScene scene)
        {
            if (!Towers.ContainsKey(type)) return null;
            var tower = (Tower)Towers[type].Clone();
            tower.Position = position;
            tower.Scene = scene;
            return tower;
        }
    }
}
