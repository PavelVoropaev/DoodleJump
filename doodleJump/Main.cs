namespace doodleJump
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using doodleJump.Properties;

    /// <summary>
    /// Главный цикл
    /// </summary>
    public partial class GameWindow : Form
    {
        private Doodle myDoodle;

        private Graphics canvas;

        private PlatformManager platformManager;

        private BulletManager bulletManager;

        private SoundManager soundManager;

        private int mouseX;

        private int score;

        private int time;

        private bool pressedGoToRight;

        private bool pressedGoToLeft;

        private bool pressedFire;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void NewGameButtonClick(object sender, EventArgs e)
        {
            NewGame();
        }

        private void GameWindowPaint(object sender, PaintEventArgs e)
        {
            if (MainTimer.Enabled)
            {
                canvas = e.Graphics;
                myDoodle.Draw(canvas);
                platformManager.DrawPlatforms(canvas);
                bulletManager.DrawBullets(canvas);

                int strenge;
                if (platformManager.StendToPlatfotm(myDoodle, out strenge))
                {
                    myDoodle.Jamp(strenge);
                    soundManager.JumpSound();
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ScoreDisplay.Text = score.ToString();
            time++;

            // Движение по оси X
            if (MouseControl.Checked)
            {
                myDoodle.MouseMooveX(mouseX);
            }
            else if (KeyControl.Checked)
            {
                const int Speed = 10;
                if (pressedGoToLeft)
                {
                    myDoodle.AccelerationX = -Speed;
                }
                else if (pressedGoToRight)
                {
                    myDoodle.AccelerationX = Speed;
                }

                if (pressedFire && time % 3 == 0)
                {

                    bulletManager.Fire(myDoodle);
                    soundManager.FireSound();
                }

                myDoodle.KeyMooveX();
            }

            // Движение по оси Y
            bulletManager.MooveY();

            if (myDoodle.PosY > myDoodle.MonitorHeight / 1.5 && myDoodle.AccelerationY > 0)
            {
                platformManager.MooveY(myDoodle.AccelerationY);
                myDoodle.AccelerationY--;
                score++;
            }
            else
            {
                myDoodle.MooveY();
            }

            if (myDoodle.PosY < 0)
            {
                GameOver();
            }

            Invalidate();
        }

        private void MainMouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
        }

        private void MainKeyDown(object sender, KeyEventArgs e)
        {
            RefreshKeyBoard(e.KeyData, true);
        }

        private void MainKeyUp(object sender, KeyEventArgs e)
        {
            RefreshKeyBoard(e.KeyData, false);
        }

        private void RefreshKeyBoard(Keys keyData, bool isPress)
        {
            if (KeyControl.Checked)
            {
                if (keyData == Keys.A
                    || keyData == Keys.Left)
                {
                    pressedGoToLeft = isPress;
                }
                else if (keyData == Keys.D
                      || keyData == Keys.Right)
                {
                    pressedGoToRight = isPress;
                }
                else if (keyData == Keys.W
                   || keyData == Keys.Up)
                {
                    pressedFire = isPress;
                }
            }
        }

        private void NewGame()
        {
            score = 0;
            platformManager = new PlatformManager();
            bulletManager = new BulletManager();
            myDoodle = new Doodle();
            soundManager = new SoundManager();
            NewGameButton.Visible = false;
            Record.Visible = false;
            congratulationText.Visible = false;
            MouseControl.Visible = false;
            KeyControl.Visible = false;
            MainTimer.Start();
        }

        private bool isAlreadyPlays;

        private void GameOver()
        {
            if (!isAlreadyPlays)
            {
                soundManager.GameOwerSound();
                isAlreadyPlays = true;
            }
            if (platformManager.HidePlatformsCompleted())
            {
                isAlreadyPlays = false;
                congratulationText.Text = "Счёт:" + score.ToString() + "\n Предыдущий рекорд:"
                                          + Settings.Default.BestScore;
                NewGameButton.Visible = true;
                NewGameButton.Text = "Начать с начала";
                congratulationText.Visible = true;
                MouseControl.Visible = true;
                KeyControl.Visible = true;
                if (score > Settings.Default.BestScore)
                {
                    congratulationText.Text = "\n Новый рекорд!" + score + "\n Предыдущий рекорд:"
                                              + Settings.Default.BestScore;
                    Settings.Default.BestScore = score;
                    Settings.Default.Save();
                }
                MainTimer.Stop();
            }
        }

        private void SoundCheckCheckedChanged(object sender, EventArgs e)
        {
            SoundCheck.BackgroundImage = SoundCheck.Checked ? Resources.musicOn : Resources.musicOff;
            soundManager.SoundOn = !soundManager.SoundOn;
        }
    }
}