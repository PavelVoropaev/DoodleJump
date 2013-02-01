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

        private int mouseX;

        private int score;

        private bool pressedGoToRight;

        private bool pressedGoToLeft;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void NewGameButtonClick(object sender, EventArgs e)
        {
            NewGame();
        }

        private void ResetButton(object sender, EventArgs e)
        {
            NewGame();
        }

        private void GameWindowPaint(object sender, PaintEventArgs e)
        {
            if (MainTimer.Enabled)
            {
                canvas = e.Graphics;
                myDoodle.Draw(canvas);
                int strenge;
                platformManager.DrawPlatforms(canvas);
                if (platformManager.StendToPlatfotm(myDoodle, out strenge))
                {
                    if (SoundCheck.Checked)
                    {
                        var soundPlayer = new System.Media.SoundPlayer(Resources.step);
                        soundPlayer.Play();
                    }

                    myDoodle.Jamp(strenge);
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ScoreDisplay.Text = score.ToString();

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

                myDoodle.KeyMooveX();
            }

            // Движение по оси Y
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
            }
        }

        private void NewGame()
        {
            score = 0;
            platformManager = new PlatformManager();
            myDoodle = new Doodle();
            resetButton.Visible = false;
            NewGameButton.Visible = false;
            Record.Visible = false;
            congratulationText.Visible = false;
            MouseControl.Visible = false;
            KeyControl.Visible = false;
            MainTimer.Start();
        }

        private void GameOver()
        {
            platformManager.Dispose();

            congratulationText.Text = "Счёт:" + score.ToString() + "\n Предыдущий рекорд:"
                                               + Settings.Default.BestScore;
            resetButton.Visible = true;
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

        private void SoundCheckCheckedChanged(object sender, EventArgs e)
        {
            SoundCheck.BackgroundImage = SoundCheck.Checked ? Resources.musicOn : Resources.musicOff;
        }
    }
}