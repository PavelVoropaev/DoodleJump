namespace doodleJump
{
    using doodleJump.Properties;

    public class SoundManager
    {
        private readonly WaveManager waveManager = new WaveManager();

        public SoundManager()
        {
            SoundOn = true;
            waveManager.LoadWave(Resources.fire, "Fire");
            waveManager.LoadWave(Resources.step, "Step");
            waveManager.LoadWave(Resources.GameOwer, "GameOwer");
        }

        public bool SoundOn { get; set; }

        public void FireSound()
        {
            if (SoundOn)
            {
                waveManager.PlayWave("Fire");
            }
        }

        public void JumpSound()
        {
            if (this.SoundOn)
            {
                waveManager.PlayWave("Step");
            }
        }

        public void GameOwerSound()
        {
            if (SoundOn)
            {
                waveManager.PlayWave("GameOwer");
            }
        }
    }
}
