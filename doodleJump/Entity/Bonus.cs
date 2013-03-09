namespace doodleJump.Entity
{
    using doodleJump.Properties;

    public sealed class Bonus : PositibleObject
    {
        public Bonus()
        {
            this.Width = 35;
            this.Height = 35;
            RefreshValue();
        }

        public bool DoobleJump { get; set; }

        public bool MultFire { get; set; }

        public override void RefreshValue()
        {
            if (Rnd.Next(2) % 2 == 0)
            {
                DoobleJump = true;
                this.Image = Resources.doubleJump;
            }
            else
            {
                MultFire = true;
                this.Image = Resources.SBonus;
            }

            PosY = 0;
            PosX = Rnd.Next(10, Settings.Default.MonitorWigth - 30);
        }
    }
}
