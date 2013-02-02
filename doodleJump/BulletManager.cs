namespace doodleJump
{
    using System.Collections.Generic;
    using System.Drawing;

    using doodleJump.Properties;

    public class BulletManager
    {
        private const int BulletSpeed = 15;

        private readonly List<Bullet> bulletList = new List<Bullet>();

        public void Fire(Doodle doodle)
        {
            bulletList.Add(new Bullet
                               {
                                   PosX = doodle.PosX + doodle.Width / 2,
                                   PosY = doodle.PosY,
                               });
        }

        public void DrawBullets(Graphics canvas)
        {
            foreach (var platform in bulletList)
            {
                platform.Draw(canvas);
            }
        }

        public void MooveY()
        {
            try
            {
                foreach (var platform in bulletList)
                {
                    platform.PosY += BulletSpeed;
                    if (platform.PosY > platform.MonitorHeight + 50)
                    {
                        bulletList.Remove(platform);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
