namespace doodleJump.Entity
{
    using doodleJump.Properties;

    public sealed class Platform : PositibleObject
    {
        public Platform()
        {
            this.Image = Resources.platform;
            this.Strange = 14;
            this.Width = 55;
            this.Height = 10;
            RefreshValue();
        }

        public int Strange { get; set; }

        public bool GoToRight { get; set; }

        public bool GoToLeft { get; set; }

        public int SpeedX { get; set; }

        public int SpeedY { get; set; }

        public override void RefreshValue()
        {
            PosX = Rnd.Next(10, Settings.Default.MonitorWigth - 70);
            GoToRight = Rnd.Next(1, 15) % 5 == 0;
            GoToLeft = Rnd.Next(1, 15) % 5 == 0;
            SpeedX = Rnd.Next(1, 3);
            PosY = 0;
            SpeedY = Rnd.Next(1, 3);
            PosX = Rnd.Next(10, Settings.Default.MonitorWigth - 70);

            if (Rnd.Next(0, 20) == 6)
            {
                Image = Resources.GreenPlatform;
                Strange = 20;
            }
            else if (Rnd.Next(0, 60) == 12)
            {
                Image = Resources.RedPlatform;
                Strange = 30;
            }
            else
            {
                Image = Resources.platform;
                Strange = 14;
            }
        }
    }
}
