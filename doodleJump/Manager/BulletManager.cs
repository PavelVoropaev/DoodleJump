namespace doodleJump.Manager
{
    using doodleJump.Entity;

    public class BulletManager : BaseManager<Bullet>
    {
        private const int BulletSpeed = 25;

        public void Fire(Doodle doodle)
        {
            this.List.Add(new Bullet
                               {
                                   PosX = doodle.PosX + doodle.Width / 2,
                                   PosY = doodle.PosY,
                               });
        }

        public void Moove()
        {
            foreach (var bullet in this.List)
            {
                bullet.PosY -= BulletSpeed;
                if (bullet.PosY < 0)
                {
                    this.List.Remove(bullet);
                    break;
                }
            }
        }
    }
}
