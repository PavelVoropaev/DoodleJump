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

        public void MooveY()
        {
            this.PosY -= 30;
        }
    }
}
