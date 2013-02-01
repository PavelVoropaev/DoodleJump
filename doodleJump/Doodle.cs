namespace doodleJump
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Doodle : PositibleObject
    {
        private const int SpeedX = 10;

        public Doodle()
        {
            Width = 50;
            Height = 90;
            PosY = 300;
            PosX = 50;
            AccelerationY = -2;
        }

        public float AccelerationY { get; set; }

        public float AccelerationX { get; set; }

        public void Draw(Graphics canvas)
        {
            canvas.DrawImage(Resources.doodle, PosX, this.MonitorHeight - PosY, Width, Height);
        }

        public void Jamp(int strange)
        {
            this.AccelerationY = strange;
        }

        public void MooveY()
        {
            PosY += AccelerationY;
            AccelerationY--;
        }

        public void MouseMooveX(float mouseX)
        {
            if (PosX + Width / 3 > mouseX)
            {
                PosX -= SpeedX;
            }
            else if (PosX + 2 * Width / 3 < mouseX)
            {
                PosX += SpeedX;
            }
        }

        public void KeyMooveX()
        {
            PosX += AccelerationX;
            AccelerationX = AccelerationX / 8 * 5;
            if (PosX > MonitorWidth)
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
