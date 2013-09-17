using System.Drawing;
using TowerDefense.Engine;
using TowerDefense.TDGame.Scenes;

namespace TowerDefense.TDGame
{
    public class TDGame : Game
    {
        private Scene _mainScene;

        public override void Initialize(Device device)
        {
            Device = device;

            _mainScene = new GameScene();
            _mainScene.Initialize(this, device);
        }

        public override void Start()
        {
            _mainScene.Start();
        }

        public override void Update()
        {
            _mainScene.Update();
        }

        public override void Draw(Graphics graphics)
        {
            _mainScene.Draw(graphics);
        }

        public override void Destroy()
        {
            _mainScene.Destroy();
        }
    }
}
