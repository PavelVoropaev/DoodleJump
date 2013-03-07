namespace doodleJump.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using doodleJump.Entity;
    using doodleJump.Properties;

    public class BaseManager<T> where T : PositibleObject
    {
        public BaseManager()
        {
            List = new List<T>();
        }

        protected internal List<T> List { get; set; }

        public void Draw(Graphics canvas)
        {
            foreach (var platform in this.List)
            {
                platform.Draw(canvas);
            }
        }

        public void WindowMooveY(float doodleSpeed)
        {
            foreach (var item in this.List)
            {
                item.PosY += doodleSpeed;
                if (item.PosY > Settings.Default.MonitorHeight)
                {
                    item.RefreshValue();
                }
            }
        }

        /// <summary>
        /// Убирает планформы с экрана.
        /// </summary>
        /// <param name="speed">Скорость </param>
        /// <returns>
        /// Убрана ли последняя платформа
        /// </returns>
        public bool Hide(int speed)
        {
            var disposeCancel = true;
            foreach (var element in this.List)
            {
                element.PosY -= speed;
                if (element.PosY > 0)
                {
                    disposeCancel = false;
                }
            }

            return disposeCancel;
        }

        public void AddItem()
        {
            this.List.Add((T)Activator.CreateInstance(typeof(T), new object[] { }));
        }
    }
}
