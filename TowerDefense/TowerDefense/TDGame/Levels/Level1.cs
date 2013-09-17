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
        }
    }
}
