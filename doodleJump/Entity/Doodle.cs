namespace doodleJump.Entity
{
    using doodleJump.Properties;

    public class Doodle : PositibleObject
    {
        public Doodle()
        {
            this.Width = 50;
            this.Height = 90;
            this.PosY = Settings.Default.MonitorHeight / 2;
            this.PosX = Settings.Default.MonitorWigth / 2;
            this.AccelerationY = -2;
            this.Image = Resources.doodle;
        }

        public float AccelerationY { get; set; }

        public float AccelerationX { get; set; }

        /// <summary>
        /// Прыжок
        /// </summary>
        /// <param name="strange">Сила прыжка</param>
        public void Jamp(float strange)
        {
            this.AccelerationY = strange;
        }

        public void MooveY()
        {
            this.PosY -= this.AccelerationY;
        }

        public void MooveX(int speed)
        {
            this.AccelerationX = speed;
            this.PosX += this.AccelerationX;
            this.AccelerationX = this.AccelerationX / 8 * 5;
            if (this.PosX + this.Width > Settings.Default.MonitorWigth)
            {
                this.PosX = 0;
            }
            else if (this.PosX < 0)
            {
                this.PosX = Settings.Default.MonitorWigth - this.Width;
            }
        }
    }
}
