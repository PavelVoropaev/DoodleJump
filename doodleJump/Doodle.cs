namespace doodleJump
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Doodle : PositibleObject
    {
        public Doodle()
        {
            Width = 50;
            Height = 90;
            PosY = 300;
            PosX = 50;
            this.AccelerationY = -2;
            Image = Resources.doodle;
        }

        public float AccelerationY { get; set; }

        public float AccelerationX { get; set; }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(Image, PosX, this.MonitorHeight - PosY, Width, Height);
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
            PosY += this.AccelerationY;
        }

        public void KeyMooveX(int speed)
        {
            this.AccelerationX = speed;
            PosX += this.AccelerationX;
            this.AccelerationX = this.AccelerationX / 8 * 5;
            if (PosX + Width > MonitorWidth)
            {
                PosX = 0;
            }
            else if (PosX < 0)
            {
                PosX = MonitorWidth;
            }
        }
    }
}
