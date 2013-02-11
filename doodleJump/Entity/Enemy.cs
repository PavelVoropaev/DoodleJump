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

        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(this.Image, this.PosX, this.MonitorHeight - this.PosY, this.Width, this.Height);
        }
    }
}
