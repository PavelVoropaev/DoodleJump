namespace doodleJump.Manager
{
    using System;
    using System.Linq;

    using doodleJump.Entity;
    using doodleJump.Properties;

    public class PlatformManager : BaseManager<Platform>
    {
        public PlatformManager()
        {
            for (var tempPosY = 0; tempPosY < Settings.Default.MonitorHeight; tempPosY += 15)
            {
                this.List.Add(new Platform { PosY = tempPosY });
            }
        }

        /// <summary>
        /// Стоит ли дудл на платформе?
        /// </summary>
        /// <param name="doodle">Дудл</param>
        /// <param name="strenge">Сила толчка платформы </param>
        /// <returns>Стоит ли дудл на платформе?</returns>
        public bool StendToPlatfotm(Doodle doodle, out float strenge)
        {
            foreach (var platform in this.List.Where(platform =>
                doodle.AccelerationY < 0 &&
                Math.Abs(doodle.PosY + doodle.Height - platform.PosY - platform.Height / 2) < platform.Height &&
                doodle.PosX + doodle.Width + doodle.AccelerationX > platform.PosX &&
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
            foreach (var platform in this.List)
            {
                if (platform.GoToLeft)
                {
                    platform.PosX -= platform.SpeedX;
                }
                else if (platform.GoToRight)
                {
                    platform.PosX += platform.SpeedX;
                }

                if (platform.PosX + platform.Width > Settings.Default.MonitorWigth)
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
    }
}
