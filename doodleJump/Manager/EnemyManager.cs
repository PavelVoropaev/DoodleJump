namespace doodleJump.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using doodleJump.Entity;
    using doodleJump.Properties;

    public class EnemyManager
    {
        private readonly List<Enemy> enemyList = new List<Enemy>();

        private readonly Random rnd = new Random();

        public void Draw(Graphics canvas)
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
                foreach (var enemy in this.enemyList.Where(enemy => !Rectangle.Intersect(bullet.Rectangle, enemy.Rectangle).IsEmpty))
                {
                    this.enemyList.Remove(enemy);
                    bulletList.Remove(bullet);
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
            if (this.enemyList.Any(enemy => !Rectangle.Intersect(doodle.Rectangle, enemy.Rectangle).IsEmpty))
            {
                doodle.PosY = 3000;
                doodle.PosX = 3000;
                return true;
            }

            return false;
        }

        public void Moove()
        {
            foreach (var enemy in this.enemyList)
            {
                if (enemy.GoToLeft)
                {
                    enemy.PosX -= enemy.SpeedX;
                }
                else if (enemy.GoToRight)
                {
                    enemy.PosX += enemy.SpeedX;
                }

                if (enemy.PosX + enemy.Width > Settings.Default.MonitorWigth)
                {
                    enemy.GoToLeft = true;
                    enemy.GoToRight = false;
                }
                else if (enemy.PosX < 0)
                {
                    enemy.GoToLeft = false;
                    enemy.GoToRight = true;
                }

                enemy.PosY += enemy.SpeedY;
                if (enemy.PosY > Settings.Default.MonitorWigth)
                {
                    enemy.PosY = 0;
                    enemy.PosX = rnd.Next(0, Settings.Default.MonitorWigth - 30);
                }
            }
        }

        public void WindowMooveY(float doodleSpeed)
        {
            foreach (var enemy in this.enemyList)
            {
                enemy.PosY += doodleSpeed;
                if (enemy.PosY > Settings.Default.MonitorWigth)
                {
                    enemy.PosY = 0;
                    enemy.PosX = rnd.Next(0, Settings.Default.MonitorWigth - 30);
                }
            }
        }

        public void Add()
        {
            this.enemyList.Add(new Enemy
                              {
                                  GoToRight = rnd.Next(1, 6) % 3 == 0,
                                  GoToLeft = rnd.Next(1, 6) % 3 == 0,
                                  SpeedX = rnd.Next(1, 3),
                                  SpeedY = rnd.Next(1, 3),
                                  PosY = 0,
                                  PosX = rnd.Next(10, Properties.Settings.Default.MonitorWigth - 30)
                              });
        }

        /// <summary>
        /// Убирает планформы с экрана.
        /// </summary>
        public void HideEnemy()
        {
            foreach (var platform in this.enemyList)
            {
                platform.PosY -= 20;
            }
        }
    }
}
