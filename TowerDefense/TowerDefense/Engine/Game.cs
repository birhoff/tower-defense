using System.Drawing;

namespace TowerDefense.Engine
{
    /// <summary>
    /// Represent abstract game.
    /// </summary>
    public abstract class Game
    {
        public Device Device;

        /// <summary>
        /// Initialize game resourses, called when game is loading
        /// </summary>
        /// <param name="device">Represent all device info (e.g. size, graphics etc.)</param>
        public abstract void Initialize(Device device);

        public abstract void Start();

        /// <summary>
        /// Call every time game need to update
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Call every time game need to draw
        /// </summary>
        /// <param name="graphics">Graphics device reference</param>
        public abstract void Draw(Graphics graphics);

        /// <summary>
        /// call before game destroyed
        /// </summary>
        public abstract void Destroy();
    }
}
