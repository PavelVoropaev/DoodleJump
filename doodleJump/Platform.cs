﻿namespace doodleJump
{
    using System.Drawing;

    using doodleJump.Properties;

    public class Platform : PositibleObject
    {
        public Platform()
        {
            Image = Resources.platform;
            Strange = 14;
            Width = 55;
            Height = 10;
        }

        public int Strange { get; set; }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawImage(Image, PosX, MonitorHeight - PosY, Width, Height);
        }
    }
}
