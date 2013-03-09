namespace doodleJump.Manager
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using doodleJump.Entity;

    public class BonusManager : BaseManager<Bonus>
    {
        private readonly Dictionary<Bonus, int> activeBonusList;

        public BonusManager()
        {
            this.activeBonusList = new Dictionary<Bonus, int>();
        }

        /// <summary>
        /// Взял ли дудл бонус?
        /// </summary>
        /// <param name="doodle">Дудл</param>
        /// <returns>Взял ли дудл бонус?</returns>
        public bool IsTakenBonus(Doodle doodle)
        {
            foreach (var bonus in this.List.Where(bonus => !Rectangle.Intersect(doodle.Rectangle, bonus.Rectangle).IsEmpty))
            {
                activeBonusList.Add(bonus, 200);
                this.List.Remove(bonus);
                return true;
            }

            return false;
        }

        public bool DoobleJumpIsActive()
        {
            return this.activeBonusList.Any(bonuse => bonuse.Key.DoobleJump);
        }

        public bool MultiFireIsActive()
        {
            return this.activeBonusList.Any(bonuse => bonuse.Key.MultFire);
        }

        /// <summary>
        /// Удалить бонусы из активных если их действие закончилось
        /// </summary>
        public void TimeRefresh()
        {
            try
            {
                foreach (var bonusTime in activeBonusList)
                {
                    activeBonusList[bonusTime.Key] = bonusTime.Value - 1;
                    if (bonusTime.Value < 0)
                    {
                        activeBonusList.Remove(bonusTime.Key);
                        break;
                    }
                }
            }
            catch 
            {
            }
        }
    }
}
