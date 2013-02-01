namespace doodleJump
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Platform : PositibleObject
    {
        public Platform()
        {
            Image = Resources.platform;
            Strange = 14;
            Width = 70;
            Height = 13;
        }

        public Image Image { get; set; }

        public int Strange { get; set; }

        public void Draw(Graphics canvas)
        {
            canvas.DrawImage(Image, PosX, MonitorHeight - PosY, Width, Height);
        }
    }
}
