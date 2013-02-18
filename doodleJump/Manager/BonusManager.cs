namespace doodleJump.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using doodleJump.Entity;

    public class BonusManager
    {
        private readonly List<Bonus> bonusList;

        private readonly Random rnd = new Random();

        private readonly Dictionary<Bonus, int> activeBonusList;

        public BonusManager()
        {
            this.bonusList = new List<Bonus>();
            this.activeBonusList = new Dictionary<Bonus, int>();
        }

        public void Draw(Graphics canvas)
        {
            foreach (var platform in this.bonusList)
            {
                platform.Draw(canvas);
            }
        }

        /// <summary>
        /// Взял ли дудл бонус?
        /// </summary>
        /// <param name="doodle">Дудл</param>
        /// <returns>Взял ли дудл бонус?</returns>
        public bool IsTakenBonus(Doodle doodle)
        {
            foreach (var bonus in this.bonusList.Where(platform =>
                doodle.AccelerationY < 0 &&
                Math.Abs(doodle.PosY - doodle.Height - platform.PosY + platform.Height / 2) < platform.Height &&
                doodle.PosX + doodle.Width + doodle.AccelerationX > platform.PosX &&
                doodle.PosX < platform.PosX + platform.Width))
            {
                activeBonusList.Add(bonus, 200);
                bonusList.Remove(bonus);
                return true;
            }

            return false;
        }

        public void WindowMooveY(float speed)
        {
            foreach (var bonus in this.bonusList)
            {
                bonus.PosY -= speed;
                if (bonus.PosY < 0)
                {
                    bonus.PosY = bonus.MonitorHeight;
                    bonus.PosX = rnd.Next(10, bonus.MonitorWidth - 70);
                }
            }
        }

        /// <summary>
        /// Убирает планформы с экрана.
        /// </summary>
        public void HideBonus()
        {
            foreach (var platform in this.bonusList)
            {
                platform.PosY += 20;
            }
        }

        public bool DoobleJumpActive()
        {
            return this.activeBonusList.Any(bonuse => bonuse.Key.DoobleJump);
        }

        public void TimeRefresh()
        {
            try
            {
                foreach (var bonusTime in activeBonusList)
                {
                    activeBonusList[bonusTime.Key] = bonusTime.Value + 1;
                    if (bonusTime.Value < 0)
                    {
                        activeBonusList.Remove(bonusTime.Key);
                    }
                }
            }
            catch 
            {
            }
        }

        public void Add()
        {
            this.bonusList.Add(new Bonus
            {
                DoobleJump = rnd.Next(1, 6) % 3 == 0,
                Immortality = rnd.Next(1, 6) % 3 == 0,
                PosY = Properties.Settings.Default.MonitorHeight,
                PosX = rnd.Next(10, Properties.Settings.Default.MonitorWigth - 30)
            });
        }

    }
}
