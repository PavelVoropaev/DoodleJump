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

        public void Draw(Graphics canvas)
        {
            foreach (var platform in this.BulletList)
            {
                platform.Draw(canvas);
            }
        }

        public void MooveY()
        {
            foreach (var bullet in this.BulletList)
            {
                bullet.PosY -= BulletSpeed;
                if (bullet.PosY < 0)
                {
                    this.BulletList.Remove(bullet);
                    break;
                }
            }
        }
    }
}
