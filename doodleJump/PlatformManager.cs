﻿namespace doodleJump
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using doodleJump.Properties;

    public class PlatformManager
    {
        private readonly List<Platform> platformList;

        public PlatformManager()
        {
            var rnd = new Random();
            platformList = new List<Platform>();

            for (var i = 1; i < 11; i++)
            {
                platformList.Add(new Platform
                                     {
                                         PosY = 50 * i,
                                         PosX = rnd.Next(10, Properties.Settings.Default.MonitorWigth - 70)
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
                platform.PosY -= speed;
                if (platform.PosY < 0)
                {
                    var rand = new Random((int)platform.PosX);
                    platform.PosY = platform.MonitorHeight;
                    platform.PosX = rand.Next(10, platform.MonitorWidth - 70);

                    if (rand.Next(0, 20) == 6)
                    {
                        platform.Image = platform.Image = Resources.GreenPlatform;
                        platform.Strange = 25;
                    }
                    else if (rand.Next(0, 60) == 12)
                    {
                        platform.Image = platform.Image = Resources.RedPlatform;
                        platform.Strange = 50;
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
            foreach (var platform in platformList)
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
