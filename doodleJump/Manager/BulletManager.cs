namespace doodleJump.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using doodleJump.Entity;

    public class BulletManager
    {

        public readonly List<Bullet> BulletList = new List<Bullet>();

        private const int BulletSpeed = 15;

        public void Fire(Doodle doodle)
        {
            this.BulletList.Add(new Bullet
                               {
                                   PosX = doodle.PosX + doodle.Width / 2,
                                   PosY = doodle.PosY,
                               });
        }

        public void DrawBullets(Graphics canvas)
        {
            foreach (var platform in this.BulletList)
            {
                platform.Draw(canvas);
            }
        }

        public void MooveY()
        {
            try
            {
                foreach (var bullet in this.BulletList)
                {
                    bullet.PosY += BulletSpeed;
                    if (bullet.PosY > bullet.MonitorHeight + 50)
                    {
                        this.BulletList.Remove(bullet);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                // В другом потоке был удалён объект из листа, так что падаем сюда каждый раз когда убираем пулю с экрана.
            }
        }
    }
}
