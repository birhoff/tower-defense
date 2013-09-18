using System.Collections.Generic;
using System.Drawing;

namespace TowerDefense.Engine.levels
{
    public class Level
    {
        public Image Map;
        public Point StartPosition;
        public Waypoint StartWaypoint;
        public List<Wave> Waves;
        public List<Point> TowerPositions;
    }
}
