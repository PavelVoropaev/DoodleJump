namespace doodleJump.Entity
{
    using System.Drawing;

    using doodleJump.Properties;

    public abstract class PositibleObject
    {
        public int Width { get; protected set; }

        public int Height { get; protected set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)PosX, (int)PosY, Width, Height);
            }
        }

        public Image Image { get; set; }

        public void Draw(Graphics canvas)
        {
            canvas.DrawImage(this.Image, Rectangle);
        }
    }
}
