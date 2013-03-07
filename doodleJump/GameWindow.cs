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

        private Doodle myDoodle;

        private PlatformManager platformManager;

        private BonusManager bonusManager;

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
            this.bonusManager = new BonusManager();
            this.bulletManager = new BulletManager();
            this.enemyManager = new EnemyManager();
            this.GameControlPanel.Visible = false;
            this.MainTimer.Start();
        }

        private void GameWindowPaint(object sender, PaintEventArgs e)
        {
            if (this.MainTimer.Enabled)
            {
                myDoodle.Draw(e.Graphics);
                platformManager.Draw(e.Graphics);
                bonusManager.Draw(e.Graphics);
                bulletManager.Draw(e.Graphics);
                enemyManager.Draw(e.Graphics);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            time++;
            ScoreLabel.Text = "Счёт: " + this.score;

            if (pressedFire && time % 5 == 0)
            {
                bulletManager.Fire(myDoodle);
            }

            if (enemyManager.KillEnemy(bulletManager.List))
            {
                score += 50;
            }

            enemyManager.KillDoodle(myDoodle);

            bonusManager.IsTakenBonus(myDoodle);

            bonusManager.TimeRefresh();

            float strenge;
            if (platformManager.StendToPlatfotm(myDoodle, out strenge))
            {
                if (bonusManager.DoobleJumpActive())
                {
                    strenge *= 1.5F;
                }

                myDoodle.Jamp(strenge);
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

            bulletManager.Moove();
            enemyManager.Moove();
            platformManager.Moove();

            myDoodle.AccelerationY--;
            if (myDoodle.PosY < Settings.Default.MonitorHeight / 2 && myDoodle.AccelerationY > 0)
            {
                platformManager.WindowMooveY(myDoodle.AccelerationY);
                enemyManager.WindowMooveY(myDoodle.AccelerationY);
                bonusManager.WindowMooveY(myDoodle.AccelerationY);
                bulletManager.WindowMooveY(myDoodle.AccelerationY);
                score++;
            }
            else
            {
                myDoodle.MooveY();
            }

            if (myDoodle.PosY > Settings.Default.MonitorHeight)
            {
                GameOver();
            }

            if (time % 40 == 0)
            {
                enemyManager.AddItem();
            }

            if (time % 100 == 0)
            {
                bonusManager.AddItem();
            }

            Invalidate();
        }

        private void GameOver()
        {
            const int HideSpeed = 40;
            enemyManager.Hide(HideSpeed);
            bonusManager.Hide(HideSpeed);
            bulletManager.Hide(HideSpeed);
            if (platformManager.Hide(HideSpeed))
            {
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

        private void ExitClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}