using System.Collections.Generic;
using TowerDefense.Engine.Elements;

namespace TowerDefense.Engine.Scenes
{
    public abstract class TDGameScene : Scene
    {
        public List<Enemy> Enemies;
        public List<Tower> Towers;
    }
}
