namespace doodleJump.Entity
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Bullet : PositibleObject
    {
        public Bullet()
        {
            this.Image = Resources.Bullet;
            this.Width = 5;
            this.Height = 23;
        }
        
        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(this.Image, this.PosX, this.MonitorHeight - this.PosY, this.Width, this.Height);
        }

        public void MooveY()
        {
            this.PosY += 30;
        }
    }
}
