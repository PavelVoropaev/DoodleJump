namespace doodleJump.Manager
{
    using doodleJump.Properties;

    public class SoundManager
    {
     //   private readonly WaveManager waveManager = new WaveManager();

        public SoundManager(bool soundOn)
        {
            //this.SoundOn = soundOn;
            //this.waveManager.LoadWave(Resources.fire, "Fire");
            //this.waveManager.LoadWave(Resources.step, "Step");
            //this.waveManager.LoadWave(Resources.GameOwer, "GameOwer");
            //this.waveManager.LoadWave(Resources.death, "Death");
        }

        public bool SoundOn { get; set; }

        public void FireSound()
        {
            if (this.SoundOn)
            {
               // this.waveManager.PlayWave("Fire");
            }
        }

        public void JumpSound()
        {
            if (this.SoundOn)
            {
              //  this.waveManager.PlayWave("Step");
            }
        }

        public void EnemyDeath()
        {
            if (this.SoundOn)
            {
             //   this.waveManager.PlayWave("Death");
            }
        }

        public void GameOwerSound()
        {
            if (this.SoundOn)
            {
             //   this.waveManager.PlayWave("GameOwer");
            }
        }
    }
}
