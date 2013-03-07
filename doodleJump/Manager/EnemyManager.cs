namespace doodleJump.Manager
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using doodleJump.Entity;
    using doodleJump.Properties;

    public class EnemyManager : BaseManager<Enemy>
    {
        /// <summary>
        /// Просчитывает попадания пуль в противника
        /// </summary>
        /// <param name="bulletList">Все пули</param>
        /// <returns>Были ли попадания?</returns>
        public bool KillEnemy(List<Bullet> bulletList)
        {
            foreach (var bullet in bulletList)
            {
                foreach (var enemy in this.List.Where(enemy => !Rectangle.Intersect(bullet.Rectangle, enemy.Rectangle).IsEmpty))
                {
                    this.List.Remove(enemy);
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
            if (this.List.Any(enemy => !Rectangle.Intersect(doodle.Rectangle, enemy.Rectangle).IsEmpty))
            {
                doodle.PosY = 3000;
                doodle.PosX = 3000;
                return true;
            }

            return false;
        }

        public void Moove()
        {
            foreach (var enemy in this.List)
            {
                enemy.PosX += enemy.SpeedX;

                if (enemy.PosX + enemy.Width > Settings.Default.MonitorWigth || enemy.PosX < 0)
                {
                    enemy.SpeedX = -enemy.SpeedX;
                }

                enemy.PosY += enemy.SpeedY;
                if (enemy.PosY > Settings.Default.MonitorWigth)
                {
                    enemy.PosY = 0;
                    enemy.PosX = enemy.Rnd.Next(0, Settings.Default.MonitorWigth - 30);
                }
            }
        }
    }
}
