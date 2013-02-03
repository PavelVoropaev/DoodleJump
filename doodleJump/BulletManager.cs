namespace doodleJump
{
    using System.Collections.Generic;
    using System.Drawing;

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
                foreach (var platform in this.BulletList)
                {
                    platform.PosY += BulletSpeed;
                    if (platform.PosY > platform.MonitorHeight + 50)
                    {
                        this.BulletList.Remove(platform);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
