namespace doodleJump.Entity
{
    using doodleJump.Properties;

    public class Bullet : PositibleObject
    {
        public Bullet()
        {
            this.Image = Resources.Bullet;
            this.Width = 5;
            this.Height = 23;
        }

        public void Moove()
        {
            this.PosY -= 30;
        }

        public override void RefreshValue()
        {
        }
    }
}
