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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.ScoreDisplay = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.congratulationText = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.Record = new System.Windows.Forms.Label();
            this.SoundCheck = new System.Windows.Forms.CheckBox();
            this.MouseControl = new System.Windows.Forms.RadioButton();
            this.KeyControl = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 35;
            this.MainTimer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // ScoreDisplay
            // 
            this.ScoreDisplay.AutoSize = true;
            this.ScoreDisplay.BackColor = System.Drawing.Color.Transparent;
            this.ScoreDisplay.Font = new System.Drawing.Font("Mistral", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreDisplay.Location = new System.Drawing.Point(285, 434);
            this.ScoreDisplay.Name = "ScoreDisplay";
            this.ScoreDisplay.Size = new System.Drawing.Size(19, 23);
            this.ScoreDisplay.TabIndex = 1;
            this.ScoreDisplay.Text = "0";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLabel.Font = new System.Drawing.Font("Mistral", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(244, 434);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(44, 23);
            this.ScoreLabel.TabIndex = 1;
            this.ScoreLabel.Text = "Счёт";
            // 
            // congratulationText
            // 
            this.congratulationText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.congratulationText.BackColor = System.Drawing.Color.Transparent;
            this.congratulationText.Font = new System.Drawing.Font("Mistral", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.congratulationText.Location = new System.Drawing.Point(76, 67);
            this.congratulationText.Name = "congratulationText";
            this.congratulationText.Size = new System.Drawing.Size(172, 93);
            this.congratulationText.TabIndex = 2;
            this.congratulationText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.congratulationText.Visible = false;
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.Transparent;
            this.NewGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGameButton.Font = new System.Drawing.Font("Mistral", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGameButton.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.NewGameButton.Location = new System.Drawing.Point(80, 177);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(168, 121);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "Новая игра";
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButtonClick);
            // 
            // Record
            // 
            this.Record.BackColor = System.Drawing.Color.Transparent;
            this.Record.Font = new System.Drawing.Font("Mistral", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(76, 317);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(172, 59);
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
            this.SoundCheck.Checked = true;
            this.SoundCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SoundCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SoundCheck.FlatAppearance.BorderSize = 0;
            this.SoundCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SoundCheck.ForeColor = System.Drawing.Color.Transparent;
            this.SoundCheck.Location = new System.Drawing.Point(1, 419);
            this.SoundCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SoundCheck.Name = "SoundCheck";
            this.SoundCheck.Size = new System.Drawing.Size(40, 40);
            this.SoundCheck.TabIndex = 100;
            this.SoundCheck.TabStop = false;
            this.SoundCheck.UseVisualStyleBackColor = false;
            this.SoundCheck.CheckedChanged += new System.EventHandler(this.SoundCheckChangedEvent);
            // 
            // MouseControl
            // 
            this.MouseControl.AutoSize = true;
            this.MouseControl.BackColor = System.Drawing.Color.Transparent;
            this.MouseControl.Font = new System.Drawing.Font("Mistral", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MouseControl.Location = new System.Drawing.Point(97, 433);
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
            this.KeyControl.Location = new System.Drawing.Point(169, 433);
            this.KeyControl.Name = "KeyControl";
            this.KeyControl.Size = new System.Drawing.Size(64, 26);
            this.KeyControl.TabIndex = 3;
            this.KeyControl.TabStop = true;
            this.KeyControl.Text = "Клава";
            this.KeyControl.UseVisualStyleBackColor = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(334, 461);
            this.Controls.Add(this.SoundCheck);
            this.Controls.Add(this.KeyControl);
            this.Controls.Add(this.MouseControl);
            this.Controls.Add(this.congratulationText);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.ScoreDisplay);
            this.Controls.Add(this.NewGameButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameWindow";
            this.Text = "Space Jump";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameWindowPaint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainKeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Label ScoreDisplay;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label congratulationText;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Label Record;
        private System.Windows.Forms.CheckBox SoundCheck;
        private System.Windows.Forms.RadioButton MouseControl;
        private System.Windows.Forms.RadioButton KeyControl;
    }
}

