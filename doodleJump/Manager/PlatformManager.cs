namespace doodleJump.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using doodleJump.Entity;
    using doodleJump.Properties;

    public class PlatformManager
    {
        private readonly List<Platform> platformList;

        private readonly Random rnd = new Random();

        public PlatformManager()
        {
            this.platformList = new List<Platform>();
            int tmpPosY = 0;
            while (tmpPosY < Settings.Default.MonitorHeight)
            {
                this.platformList.Add(new Platform
                {
                    PosY = tmpPosY,
                    PosX = rnd.Next(10, Settings.Default.MonitorWigth - 70),
                    GoToRight = rnd.Next(1, 15) % 5 == 0,
                    GoToLeft = rnd.Next(1, 15) % 5 == 0,
                    SpeedX = rnd.Next(1, 3),
                    SpeedY = rnd.Next(1, 3),
                });

                tmpPosY += 20;
            }
        }

        public void DrawPlatforms(Graphics canvas)
        {
            foreach (var platform in this.platformList)
            {
                platform.Draw(canvas);
            }
        }

        /// <summary>
        /// Стоит ли дудл на платформе?
        /// </summary>
        /// <param name="doodle">Дудл</param>
        /// <param name="strenge">Сила толчка платформы </param>
        /// <returns>Стоит ли дудл на платформе?</returns>
        public bool StendToPlatfotm(Doodle doodle, out int strenge)
        {
            foreach (var platform in this.platformList.Where(platform =>
                doodle.AccelerationY < 0 &&
                Math.Abs(doodle.PosY - doodle.Height - platform.PosY + platform.Height / 2) < platform.Height &&
                doodle.PosX + doodle.Width + doodle.AccelerationX  > platform.PosX &&
                doodle.PosX < platform.PosX + platform.Width))
            {
                strenge = platform.Strange;
                return true;
            }

            strenge = 0;
            return false;
        }

        public void Moove()
        {
            foreach (var platform in this.platformList)
            {
                if (platform.GoToLeft)
                {
                    platform.PosX -= platform.SpeedX;
                }
                else if (platform.GoToRight)
                {
                    platform.PosX += platform.SpeedX;
                }

                if (platform.PosX + platform.Width > platform.MonitorWidth)
                {
                    platform.GoToLeft = true;
                    platform.GoToRight = false;
                }
                else if (platform.PosX < 0)
                {
                    platform.GoToLeft = false;
                    platform.GoToRight = true;
                }
            }
        }


        public void WindowMooveY(float speed)
        {
            foreach (var platform in this.platformList)
            {
                platform.PosY -= speed;
                if (platform.PosY < 0)
                {
                    platform.PosY = platform.MonitorHeight;
                    platform.PosX = rnd.Next(10, platform.MonitorWidth - 70);

                    if (rnd.Next(0, 20) == 6)
                    {
                        platform.Image = platform.Image = Resources.GreenPlatform;
                        platform.Strange = 20;
                    }
                    else if (rnd.Next(0, 60) == 12)
                    {
                        platform.Image = platform.Image = Resources.RedPlatform;
                        platform.Strange = 30;
                    }
                    else
                    {
                        platform.Image = Resources.platform;
                        platform.Strange = 14;
                    }
                }
            }
        }

        /// <summary>
        /// Убирает планформы с экрана.
        /// </summary>
        /// <returns>Убрана ли последняя платформа</returns>
        public bool HidePlatformsCompleted()
        {
            var disposeCancel = true;
            foreach (var platform in this.platformList)
            {
                platform.PosY += 20;
                if (platform.PosY < platform.MonitorHeight)
                {
                    disposeCancel = false;
                }
            }

            return disposeCancel;
        }
    }
}
