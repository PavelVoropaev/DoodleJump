namespace doodleJump.Entity
{
    using System.Drawing;

    public abstract class PositibleObject
    {
        public readonly int MonitorHeight = Properties.Settings.Default.MonitorHeight;

        public readonly int MonitorWidth = Properties.Settings.Default.MonitorWigth;

        public int Width { get; protected set; }
        
        public int Height { get; protected set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public Image Image { get; set; }

        public abstract void Draw(Graphics canvas);
    }
}
