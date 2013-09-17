using System.Drawing;

namespace TowerDefense.Engine
{
    public abstract class Scene
    {
        public abstract void Initialize(Game game, Device device);
        public abstract void Start();
        public abstract void Update();
        public abstract void Draw(Graphics graphics);
        public abstract void Destroy();
    }
}
