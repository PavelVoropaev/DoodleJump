namespace doodleJump.Entity
{
    using doodleJump.Properties;

    public sealed class Bonus : PositibleObject
    {
        public Bonus()
        {
            this.Image = Resources.doubleJump;
            this.Strange = 14;
            this.Width = 30;
            this.Height = 30;
            RefreshValue();
        }

        public int Strange { get; set; }

        public bool DoobleJump { get; set; }

        public override void RefreshValue()
        {
            DoobleJump = true;
            PosY = 0;
            PosX = Rnd.Next(10, Settings.Default.MonitorWigth - 30);
        }
    }
}
