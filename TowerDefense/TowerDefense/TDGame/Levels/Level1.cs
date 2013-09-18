using System.Collections.Generic;
using System.Drawing;
using TowerDefense.Engine.Elements;
using TowerDefense.Engine.levels;

namespace TowerDefense.TDGame.Levels
{
    public class Level1 : Level
    {
        public Level1()
        {
            Map = Image.FromFile("TDGame/Resources/level1.jpg");
            StartPosition = new Point(0, 113);
            StartWaypoint =
                Waypoint.CreateWaypointList(new[]
                    {
                        new Point(0, 108), new Point(754, 108), new Point(754, 271), new Point(50, 271),
                        new Point(50, 465), new Point(800, 465)
                    });
            Waves = new List<Wave>
                {
                    new Wave
                        {
                            Packs = new List<Enemy[]>
                                {
                                    new[] {
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint)
                                    },
                                    new[] {
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("easy", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("medium", StartWaypoint),
                                        EnemyBuilder.CreateEnemy("medium", StartWaypoint)
                                    }
                                }
                        }
                };

            TowerPositions = new List<Point>
                {
                    new Point(122,31), new Point(326,31), new Point(535,31), new Point(745,31),
                    new Point(29,170), new Point(233,170), new Point(442,170), new Point(652,170),
                    new Point(118,347), new Point(322,347), new Point(531,347), new Point(741,347),
                    new Point(27,529), new Point(231,529), new Point(440,529), new Point(650,529)
                };
        }
    }
}
