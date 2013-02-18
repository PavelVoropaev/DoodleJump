namespace doodleJump.Entity
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Bonus : PositibleObject
    {
        public Bonus()
        {
            this.Image = Resources.doubleJump;
            this.Strange = 14;
            this.Width = 30;
            this.Height = 30;
        }

        public int Strange { get; set; }

        public bool DoobleJump { get; set; }

        public bool Immortality { get; set; }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(this.Image, this.PosX, this.MonitorHeight - this.PosY, this.Width, this.Height);
        }
    }
}
