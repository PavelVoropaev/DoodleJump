namespace doodleJump.Entity
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Platform : PositibleObject
    {
        public Platform()
        {
            this.Image = Resources.platform;
            this.Strange = 14;
            this.Width = 55;
            this.Height = 10;
        }

        public int Strange { get; set; }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(this.Image, this.PosX, this.MonitorHeight - this.PosY, this.Width, this.Height);
        }
    }
}
