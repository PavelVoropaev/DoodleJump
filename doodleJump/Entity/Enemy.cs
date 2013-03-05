namespace doodleJump.Entity
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Enemy : PositibleObject
    {
        public Enemy()
        {
            this.Image = Resources.Enemy;
            this.Width = 25;
            this.Height = 25;
        }

        public bool GoToRight { get; set; }

        public bool GoToLeft { get; set; }

        public int SpeedX { get; set; }

        public int SpeedY { get; set; }
    }
}
