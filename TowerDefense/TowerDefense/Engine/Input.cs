using TowerDefense.Engine.DeviceControllers;

namespace TowerDefense.Engine
{
    public class Input
    {
        public MouseController Mouse;

        public Input()
        {
            Mouse = new MouseController();
        }
    }
}
