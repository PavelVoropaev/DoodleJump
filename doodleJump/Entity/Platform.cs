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

        public bool GoToRight { get; set; }

        public bool GoToLeft { get; set; }

        public int SpeedX { get; set; }

        public int SpeedY { get; set; }
    }
}
