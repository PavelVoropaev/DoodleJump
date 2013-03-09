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
            List.ForEach(x => x.Draw(canvas));
        }

        public void WindowMooveY(float doodleSpeed)
        {
            List.ForEach(x => x.PosY += doodleSpeed);

            foreach (var item in this.List)
            {
                if (item.PosY > Settings.Default.MonitorHeight)
                {
                    item.RefreshValue();
                }
            }
        }

        /// <summary>
        /// Убирает планформы с экрана.
        /// </summary>
        /// <returns>
        /// Убрана ли последняя платформа
        /// </returns>
        public bool HideComplided()
        {
            const int HideSpeed = 40;
            var disposeCancel = true;
            foreach (var item in this.List)
            {
                item.PosY -= HideSpeed;
                if (item.PosY > 0)
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
