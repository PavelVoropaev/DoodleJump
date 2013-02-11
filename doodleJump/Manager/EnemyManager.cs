namespace doodleJump.Manager
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using doodleJump.Entity;

    public class EnemyManager
    {
        private const int Speed = 1;

        private readonly List<Enemy> enemyList = new List<Enemy>();

        private readonly Random rnd = new Random();

        public void DrawEnemy(Graphics canvas)
        {
            foreach (var platform in this.enemyList)
            {
                platform.Draw(canvas);
            }
        }

        /// <summary>
        /// Просчитывает попадания пуль в противника
        /// </summary>
        /// <param name="bulletList">Все пули</param>
        /// <returns>Были ли попадания?</returns>
        public bool KillEnemy(List<Bullet> bulletList)
        {
            foreach (var bullet in bulletList)
            {
                foreach (var enemy in this.enemyList.Where(enemy =>
               Math.Abs(bullet.PosY - bullet.Height - enemy.PosY + enemy.Height / 2) < enemy.Height &&
                        bullet.PosX + bullet.Width > enemy.PosX &&
                        bullet.PosX < enemy.PosX + enemy.Width))
                {
                    this.enemyList.Remove(enemy);
                    lock (((ICollection)bulletList).SyncRoot)
                    {
                        bulletList.Remove(bullet);
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Были ли попадания в Дудла 
        /// </summary>
        /// <param name="doodle">Дудл</param>
        /// <returns>Были ли попадания в Дудла?</returns>
        public bool KillDoodle(Doodle doodle)
        {
            if (this.enemyList.Any(enemy => doodle.PosY - doodle.Height < enemy.PosY &&
                                            doodle.PosY > enemy.PosY - enemy.Height &&
                                            doodle.PosX + doodle.Width > enemy.PosX &&
                                            doodle.PosX < enemy.PosX + enemy.Width))
            {
                doodle.PosY = -300;
                doodle.PosX = -300;
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
                    enemy.PosY = enemy.MonitorHeight;
                    enemy.PosX = rnd.Next(10, enemy.MonitorWidth - 70);
                }
            }
        }

        public void WindowMooveY(float speed)
        {
            foreach (var enemy in this.enemyList)
            {
                enemy.PosY -= speed;
                if (enemy.PosY < 0)
                {
                   enemy.PosY = enemy.MonitorHeight;
                   enemy.PosX = rnd.Next(10, enemy.MonitorWidth - 70);
                }
            }
        }

        public void Add(int seed)
        {
            this.enemyList.Add(new Enemy
                              {
                                  PosY = 700,
                                  PosX = this.rnd.Next(10, 400)
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
