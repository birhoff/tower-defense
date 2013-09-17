using System.Drawing;

namespace TowerDefense.Engine.levels
{
    public class Waypoint
    {
        public Waypoint(int pointX, int pointY)
        {
            Point = new Point(pointX, pointY);
            Next = null;
        }
        
        public Waypoint(Point point)
        {
            Point = point;
            Next = null;
        }
        public Point Point;
        public Waypoint Next;

        /// <summary>
        /// Creates a waypoint linked list from array of points
        /// </summary>
        /// <param name="points">array of wapoints coordinates</param>
        /// <returns></returns>
        public static Waypoint CreateWaypointList(Point[] points)
        {
            if (points == null || points.Length == 0) return null;

            var i = 1;
            var startWaypoint = new Waypoint(points[0]);
            var currentWaypoint = startWaypoint;

            while (i < points.Length)
            {
                var newWaypoint = new Waypoint(points[i]);
                currentWaypoint.Next = newWaypoint;
                currentWaypoint = newWaypoint;
                i++;
            }

            return startWaypoint;
        }
    }
}
