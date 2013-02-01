namespace doodleJump
{
    using System.Windows.Forms;

    public abstract class PositibleObject
    {
        public readonly int MonitorHeight = Form.ActiveForm.Height;

        public readonly int MonitorWidth = Form.ActiveForm.Width;

        public int Width { get; protected set; }
        
        public int Height { get; protected set; }

        public float PosX { get; set; }

        public float PosY { get; set; }
    }
}
