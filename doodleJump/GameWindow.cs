namespace doodleJump
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using doodleJump.Entity;
    using doodleJump.Manager;
    using doodleJump.Properties;

    /// <summary>
    /// Главный цикл
    /// </summary>
    public partial class GameWindow : Form
    {
        private const int DefaultDoodleSpeedX = 10;

        private readonly SoundManager soundManager;

        private Doodle myDoodle;

        private Graphics canvas;

        private PlatformManager platformManager;

        private BulletManager bulletManager;

        private EnemyManager enemyManager;

        private int mouseX;

        private int score;

        private int time;

        private bool pressedGoToRight;

        private bool pressedGoToLeft;

        private bool pressedFire;

        public GameWindow()
        {
            InitializeComponent();

            // Позиционирование элементов на экране
            soundManager = new SoundManager(SoundCheck.Checked);
            Settings.Default.MonitorHeight = SystemInformation.PrimaryMonitorSize.Height;
            Settings.Default.MonitorWigth = SystemInformation.PrimaryMonitorSize.Width;

            this.SoundCheck.Location = new Point(0, Settings.Default.MonitorHeight - SoundCheck.Height);

            this.ExitButton.Location = new Point(Settings.Default.MonitorWigth - ExitButton.Width, 0);

            this.ScoreLabel.Location = new Point(
                Settings.Default.MonitorWigth - ScoreLabel.Width * 2,
                Settings.Default.MonitorHeight - ScoreLabel.Height);

            this.GameControlPanel.Location = new Point(
                Settings.Default.MonitorWigth / 2 - GameControlPanel.Width / 2,
                Settings.Default.MonitorHeight / 2 - GameControlPanel.Height / 2);
        }

        private void NewGameButtonClick(object sender, EventArgs e)
        {
            this.score = 0;
            this.myDoodle = new Doodle();
            this.platformManager = new PlatformManager();
            this.bulletManager = new BulletManager();
            this.enemyManager = new EnemyManager();
            this.GameControlPanel.Visible = false;
            this.MainTimer.Start();
        }

        private void GameWindowPaint(object sender, PaintEventArgs e)
        {
            if (MainTimer.Enabled)
            {
                canvas = e.Graphics;
                myDoodle.Draw(canvas);
                platformManager.DrawPlatforms(canvas);
                bulletManager.DrawBullets(canvas);
                enemyManager.DrawEnemy(canvas);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            time++;
            ScoreLabel.Text = "Счёт: " + score.ToString();

            if (pressedFire && time % 4 == 0)
            {
                bulletManager.Fire(myDoodle);
                soundManager.FireSound();
            }

            if (enemyManager.KillEnemy(bulletManager.BulletList))
            {
                soundManager.EnemyDeath();
                score += 50;
            }

            enemyManager.KillDoodle(myDoodle);

            int strenge;
            if (platformManager.StendToPlatfotm(myDoodle, out strenge))
            {
                myDoodle.Jamp(strenge);
                soundManager.JumpSound();
            }

            if (MouseControl.Checked)
            {
                RefreshMousePosition(mouseX);
            }

            if (pressedGoToLeft)
            {
                myDoodle.MooveX(-DefaultDoodleSpeedX);
            }
            else if (pressedGoToRight)
            {
                myDoodle.MooveX(DefaultDoodleSpeedX);
            }

            bulletManager.MooveY();
            enemyManager.Moove();
            platformManager.Moove();

            myDoodle.AccelerationY--;
            if (myDoodle.PosY > myDoodle.MonitorHeight / 2 && myDoodle.AccelerationY > 0)
            {
                platformManager.WindowMooveY(myDoodle.AccelerationY);
                enemyManager.WindowMooveY(myDoodle.AccelerationY);
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

            if (time % 25 == 0)
            {
                enemyManager.Add(time);
            }

            Invalidate();
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            pressedFire = true;
        }

        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            pressedFire = false;
        }

        private void RefreshMousePosition(int mousePosX)
        {
            if (MouseControl.Checked && MainTimer.Enabled)
            {
                if (myDoodle.PosX + myDoodle.Width / 4 > mousePosX)
                {
                    pressedGoToLeft = true;
                    pressedGoToRight = false;
                }
                else if (myDoodle.PosX + 3 * myDoodle.Width / 4 < mousePosX)
                {
                    pressedGoToLeft = false;
                    pressedGoToRight = true;
                }
                else
                {
                    pressedGoToLeft = false;
                    pressedGoToRight = false;
                }
            }
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
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
                   || keyData == Keys.Up ||
                    keyData == Keys.Space)
                {
                    pressedFire = isPress;
                }
            }
        }

        private void SoundCheckChangedEvent(object sender, EventArgs e)
        {
            SoundCheck.BackgroundImage = SoundCheck.Checked ? Resources.musicOn : Resources.musicOff;
            soundManager.SoundOn = !soundManager.SoundOn;
        }

        private bool gameOverMusicPlaying;

        private void GameOver()
        {
            if (!this.gameOverMusicPlaying)
            {
                soundManager.GameOwerSound();
                this.gameOverMusicPlaying = true;
            }

            enemyManager.HideEnemy();
            if (platformManager.HidePlatformsCompleted())
            {
                this.gameOverMusicPlaying = false;
                Record.Text = "Счёт:" + score +
                                "\n Предыдущий рекорд:" + Settings.Default.BestScore;
                NewGameButton.Text = "Начать с начала";
                GameControlPanel.Visible = true;
                if (score > Settings.Default.BestScore)
                {
                    Record.Text = "\n Новый рекорд!" + score +
                               "\n Предыдущий рекорд:" + Settings.Default.BestScore;
                    Settings.Default.BestScore = score;
                    Settings.Default.Save();
                }

                MainTimer.Stop();
            }
        }

        private void ExitClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}