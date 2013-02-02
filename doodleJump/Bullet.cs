namespace doodleJump
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Bullet : PositibleObject
    {
        public Bullet()
        {
            Image = Resources.Bullet;
            Width = 5;
            Height = 23;
        }
        
        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(Image, PosX, MonitorHeight - PosY, Width, Height);
        }

        public void MooveY()
        {
            PosY += 30;
        }
    }
}
