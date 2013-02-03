namespace doodleJump
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Enemy : PositibleObject
    {
        public Enemy()
        {
            Image = Resources.Enemy;
            Width = 25;
            Height = 25;
        }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(Image, PosX, MonitorHeight - PosY, Width, Height);
        }
    }
}
