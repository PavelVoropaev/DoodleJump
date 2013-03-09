namespace doodleJump.Entity
{
    using doodleJump.Properties;

    public class Bullet : PositibleObject
    {
        public Bullet()
        {
            this.Image = Resources.Bullet;
            this.Width = 10;
            this.Height = 10;
            this.SpeedY = 25;
        }

        public int SpeedX { get; set; }

        public int SpeedY { get; set; }

        public void Moove()
        {
            PosX += SpeedX;
            PosY -= SpeedY;
        }

        public override void RefreshValue()
        {
        }
    }
}
