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
            soundManager = new SoundManager(SoundCheck.Checked);
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
                enemyManager.DrawEnemy(canvas);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            time++;
            ScoreDisplay.Text = score.ToString();

            if (pressedFire && time % 4 == 0)
            {
                bulletManager.Fire(myDoodle);
                soundManager.FireSound();
            }

            enemyManager.KillEnemy(bulletManager.BulletList);
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
            enemyManager.MooveY();

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

        private void NewGame()
        {
            score = 0;
            myDoodle = new Doodle();
            platformManager = new PlatformManager();
            bulletManager = new BulletManager();
            enemyManager = new EnemyManager();
            NewGameButton.Visible = false;
            Record.Visible = false;
            congratulationText.Visible = false;
            MouseControl.Visible = false;
            KeyControl.Visible = false;
            MainTimer.Start();
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
                congratulationText.Text = "Счёт:" + score +
                                "\n Предыдущий рекорд:" + Settings.Default.BestScore;
                NewGameButton.Text = "Начать с начала";
                NewGameButton.Visible = true;
                congratulationText.Visible = true;
                MouseControl.Visible = true;
                KeyControl.Visible = true;
                if (score > Settings.Default.BestScore)
                {
                    congratulationText.Text = "\n Новый рекорд!" + score +
                               "\n Предыдущий рекорд:" + Settings.Default.BestScore;
                    Settings.Default.BestScore = score;
                    Settings.Default.Save();
                }

                MainTimer.Stop();
            }
        }
    }
}