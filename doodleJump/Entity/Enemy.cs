namespace doodleJump.Entity
{
    using doodleJump.Properties;

    public sealed class Enemy : PositibleObject
    {
        public Enemy()
        {
            Image = Resources.Enemy;
            Width = 25;
            Height = 25;
            RefreshValue();
        }

        public int SpeedX { get; set; }

        public int SpeedY { get; set; }
        
        public override void RefreshValue()
        {
            this.SpeedX = Rnd.Next(-3, 3);
            this.SpeedY = Rnd.Next(1, 3);
            this.PosY = 0;
            this.PosX = Rnd.Next(10, Settings.Default.MonitorWigth - 30);
        }
    }
}
