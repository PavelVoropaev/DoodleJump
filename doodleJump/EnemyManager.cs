namespace doodleJump
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class EnemyManager
    {
        private const int Speed = 2;

        private readonly List<Enemy> enemyList = new List<Enemy>();
        private readonly Random rnd = new Random();

        public void DrawEnemy(Graphics canvas)
        {
            foreach (var platform in this.enemyList)
            {
                platform.Draw(canvas);
            }
        }

        public bool KillShot(BulletManager bulletManager)
        {
            foreach (var bullet in bulletManager.BulletList)
            {
                 foreach (var enemy in this.enemyList.Where(enemy =>
                Math.Abs(bullet.PosY - bullet.Height - enemy.PosY + enemy.Height / 2) < enemy.Height &&
                bullet.PosX + bullet.Width > enemy.PosX &&
                bullet.PosX < enemy.PosX + enemy.Width))
            {
                enemyList.Remove(enemy);
                bulletManager.BulletList.Remove(bullet);
                return true;
            }
            }
           
            return false;
        }

        public bool KillDoodle(Doodle doodle)
        {
            if (this.enemyList.Any(enemy => doodle.PosY - doodle.Height < enemy.PosY &&
                                            doodle.PosY > enemy.PosY - enemy.Height &&
                                            doodle.PosX + doodle.Width > enemy.PosX &&
                                            doodle.PosX < enemy.PosX + enemy.Width))
            {
                doodle.PosY = 0;
                return true;
            }

            return false;
        }

        public void MooveY()
        {
            foreach (var enemy in this.enemyList)
            {
                enemy.PosY -= Speed;
                if (enemy.PosY < 0)
                {
                    var rand = new Random((int)enemy.PosX);
                    enemy.PosY = enemy.MonitorHeight;
                    enemy.PosX = rand.Next(10, enemy.MonitorWidth - 70);
                }
            }
        }

        public void Add(int seed)
        {
            enemyList.Add(new Enemy
                              {
                                         PosY = 700,
                                         PosX = rnd.Next(10, 400)
                              });
        }

        /// <summary>
        /// Убирает планформы с экрана.
        /// </summary>
        /// <returns>Убрана ли последняя платформа</returns>
        public bool HideEnemy()
        {
            var disposeCancel = true;
            foreach (var platform in this.enemyList)
            {
                platform.PosY += 10;
                if (platform.PosY < platform.MonitorHeight)
                {
                    disposeCancel = false;
                }
            }

            return disposeCancel;
        }
    }
}
