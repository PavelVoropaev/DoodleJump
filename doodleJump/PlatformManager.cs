namespace doodleJump
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    internal class PlatformManager
    {
        private readonly List<Platform> platformList;

        public PlatformManager()
        {
            var rnd = new Random();
            platformList = new List<Platform>();

            for (int i = 0; i < 13; i++)
            {
                platformList.Add(new Platform
                                     {
                                         PosY = 40 * i,
                                         PosX = rnd.Next(10, Form.ActiveForm.Width - 70)
                                     });
            }
        }

        public void DrawPlatforms(Graphics canvas)
        {
            foreach (var platform in platformList)
            {
                platform.Draw(canvas);
            }
        }

        public bool StendToPlatfotm(Doodle doodle, out int strenge)
        {
            foreach (var platform in this.platformList.Where(platform =>
                doodle.AccelerationY < 0 &&
                Math.Abs(doodle.PosY - doodle.Height - platform.PosY + platform.Height / 2) < platform.Height  &&
                doodle.PosX + doodle.Width > platform.PosX &&
                doodle.PosX < platform.PosX + platform.Width))
            {
                strenge = platform.Strange;
                return true;
            }

            strenge = 0;
            return false;
        }

        public void MooveY(float speed)
        {
            foreach (var platform in platformList)
            {
                var rand = new Random();
                platform.PosY -= speed;
                if (platform.PosY < 0)
                {
                    platform.PosY = platform.MonitorHeight;
                    platform.PosX = rand.Next(0, platform.MonitorWidth);

                    if (rand.Next(0, 20) == 6)
                    {
                        //platform.Image = 
                        platform.Strange = 14;
                    }
                    else
                    {
                        // platform.Image = ;
                        platform.Strange = 16;
                    }
                }
            }
        }

        public void Dispose()
        {
            platformList.Clear();
        }
    }
}
