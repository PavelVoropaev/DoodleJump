namespace doodleJump.Entity
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Doodle : PositibleObject
    {
        public Doodle()
        {
            this.Width = 50;
            this.Height = 90;
            this.PosY = this.MonitorHeight / 2;
            this.PosX = this.MonitorWidth / 2;
            this.AccelerationY = -2;
            this.Image = Resources.doodle;
        }

        public float AccelerationY { get; set; }

        public float AccelerationX { get; set; }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(this.Image, this.PosX, this.MonitorHeight - this.PosY, this.Width, this.Height);
        }

        /// <summary>
        /// Прыжок
        /// </summary>
        /// <param name="strange">Сила прыжка</param>
        public void Jamp(int strange)
        {
            this.AccelerationY = strange;
        }

        public void MooveY()
        {
            this.PosY += this.AccelerationY;
        }

        public void MooveX(int speed)
        {
            this.AccelerationX = speed;
            this.PosX += this.AccelerationX;
            this.AccelerationX = this.AccelerationX / 8 * 5;
            if (this.PosX + this.Width > this.MonitorWidth)
            {
                this.PosX = 0;
            }
            else if (this.PosX < 0)
            {
                this.PosX = this.MonitorWidth - this.Width;
            }
        }
    }
}
