namespace doodleJump
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.Record = new System.Windows.Forms.Label();
            this.SoundCheck = new System.Windows.Forms.CheckBox();
            this.MouseControl = new System.Windows.Forms.RadioButton();
            this.KeyControl = new System.Windows.Forms.RadioButton();
            this.GameControlPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.GameControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 40;
            this.MainTimer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLabel.Font = new System.Drawing.Font("Mistral", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.ScoreLabel.Location = new System.Drawing.Point(583, 444);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(87, 48);
            this.ScoreLabel.TabIndex = 1;
            this.ScoreLabel.Text = "Счёт";
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.Transparent;
            this.NewGameButton.CausesValidation = false;
            this.NewGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGameButton.Font = new System.Drawing.Font("Mistral", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGameButton.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.NewGameButton.Location = new System.Drawing.Point(93, 19);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(168, 121);
            this.NewGameButton.TabIndex = 999;
            this.NewGameButton.Text = "Новая игра";
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButtonClick);
            // 
            // Record
            // 
            this.Record.BackColor = System.Drawing.Color.Transparent;
            this.Record.Font = new System.Drawing.Font("Mistral", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(89, 159);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(172, 90);
            this.Record.TabIndex = 1;
            this.Record.Text = "Текущий рекорд: 0";
            this.Record.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SoundCheck
            // 
            this.SoundCheck.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.SoundCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.SoundCheck.BackColor = System.Drawing.Color.Transparent;
            this.SoundCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SoundCheck.BackgroundImage")));
            this.SoundCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SoundCheck.CausesValidation = false;
            this.SoundCheck.Checked = true;
            this.SoundCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SoundCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SoundCheck.FlatAppearance.BorderSize = 0;
            this.SoundCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SoundCheck.ForeColor = System.Drawing.Color.Transparent;
            this.SoundCheck.Location = new System.Drawing.Point(0, 444);
            this.SoundCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SoundCheck.Name = "SoundCheck";
            this.SoundCheck.Size = new System.Drawing.Size(40, 40);
            this.SoundCheck.TabIndex = 100;
            this.SoundCheck.TabStop = false;
            this.SoundCheck.UseVisualStyleBackColor = false;
            this.SoundCheck.Visible = false;
            // 
            // MouseControl
            // 
            this.MouseControl.AutoSize = true;
            this.MouseControl.BackColor = System.Drawing.Color.Transparent;
            this.MouseControl.Font = new System.Drawing.Font("Mistral", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MouseControl.Location = new System.Drawing.Point(112, 252);
            this.MouseControl.Name = "MouseControl";
            this.MouseControl.Size = new System.Drawing.Size(67, 26);
            this.MouseControl.TabIndex = 3;
            this.MouseControl.Text = "Мышь";
            this.MouseControl.UseVisualStyleBackColor = false;
            // 
            // KeyControl
            // 
            this.KeyControl.AutoSize = true;
            this.KeyControl.BackColor = System.Drawing.Color.Transparent;
            this.KeyControl.Checked = true;
            this.KeyControl.Font = new System.Drawing.Font("Mistral", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyControl.Location = new System.Drawing.Point(184, 252);
            this.KeyControl.Name = "KeyControl";
            this.KeyControl.Size = new System.Drawing.Size(64, 26);
            this.KeyControl.TabIndex = 3;
            this.KeyControl.TabStop = true;
            this.KeyControl.Text = "Клава";
            this.KeyControl.UseVisualStyleBackColor = false;
            // 
            // GameControlPanel
            // 
            this.GameControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.GameControlPanel.Controls.Add(this.NewGameButton);
            this.GameControlPanel.Controls.Add(this.Record);
            this.GameControlPanel.Controls.Add(this.KeyControl);
            this.GameControlPanel.Controls.Add(this.MouseControl);
            this.GameControlPanel.Location = new System.Drawing.Point(173, 95);
            this.GameControlPanel.Name = "GameControlPanel";
            this.GameControlPanel.Size = new System.Drawing.Size(357, 335);
            this.GameControlPanel.TabIndex = 101;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Mistral", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.Crimson;
            this.ExitButton.Location = new System.Drawing.Point(657, -1);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(34, 54);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitClick);
            // 
            // DrawTimer
            // 
            this.DrawTimer.Enabled = true;
            this.DrawTimer.Interval = 40;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTick);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::doodleJump.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(713, 490);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.GameControlPanel);
            this.Controls.Add(this.SoundCheck);
            this.Controls.Add(this.ScoreLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameWindow";
            this.Text = "Space Jump";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameWindowPaint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainKeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpEvent);
            this.GameControlPanel.ResumeLayout(false);
            this.GameControlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Label Record;
        private System.Windows.Forms.CheckBox SoundCheck;
        private System.Windows.Forms.RadioButton MouseControl;
        private System.Windows.Forms.RadioButton KeyControl;
        private System.Windows.Forms.Panel GameControlPanel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Timer DrawTimer;
    }
}

