namespace doodleJump.Manager
{
    using doodleJump.Entity;

    public class BulletManager : BaseManager<Bullet>
    {
        public void Fire(Doodle doodle, bool multiFire)
        {
            this.List.Add(new Bullet
                               {
                                   PosX = doodle.PosX + doodle.Width / 2,
                                   PosY = doodle.PosY,
                               });
            if (multiFire)
            {
                this.List.Add(new Bullet
                {
                    PosX = doodle.PosX + doodle.Width / 2 + 20,
                    PosY = doodle.PosY,
                    SpeedX = 3
                });
                this.List.Add(new Bullet
                {
                    PosX = doodle.PosX + doodle.Width / 2 - 20,
                    PosY = doodle.PosY,
                    SpeedX = -3
                });
            }
        }

        public void Moove()
        {
            List.ForEach(x => x.Moove());
            List.RemoveAll(x => x.PosY < 0);
        }
    }
}
