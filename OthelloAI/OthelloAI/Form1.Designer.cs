namespace OthelloAI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseDownBackColor = Color.Black;
            button1.FlatAppearance.MouseOverBackColor = Color.Green;
            button1.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(91, 50);
            button1.Name = "button1";
            button1.Size = new Size(270, 71);
            button1.TabIndex = 0;
            button1.Text = "Human vs Human";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.BackColor = Color.Black;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatAppearance.BorderSize = 2;
            button2.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(441, 50);
            button2.Name = "button2";
            button2.Size = new Size(268, 71);
            button2.TabIndex = 3;
            button2.Text = "Human vs Ai";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.FlatAppearance.BorderSize = 2;
            button3.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(805, 50);
            button3.Name = "button3";
            button3.Size = new Size(270, 71);
            button3.TabIndex = 4;
            button3.Text = "Ai vs Ai";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.BackColor = Color.Black;
            trackBar1.Location = new Point(157, 329);
            trackBar1.Maximum = 4;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(323, 56);
            trackBar1.TabIndex = 5;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            trackBar2.BackColor = Color.Black;
            trackBar2.Location = new Point(778, 329);
            trackBar2.Maximum = 4;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(369, 56);
            trackBar2.TabIndex = 6;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Black;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 329);
            label1.Name = "label1";
            label1.Size = new Size(116, 64);
            label1.TabIndex = 7;
            label1.Text = "White Difficulty";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = Color.Black;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(630, 321);
            label2.Name = "label2";
            label2.Size = new Size(116, 64);
            label2.TabIndex = 8;
            label2.Text = "Black Difficulty";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.Black;
            button4.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(420, 495);
            button4.Name = "button4";
            button4.Size = new Size(358, 79);
            button4.TabIndex = 9;
            button4.Text = "Start Game";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            button4.MouseDown += button4_MouseDown;
            button4.MouseUp += button4_MouseUp;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button5.BackColor = Color.White;
            button5.FlatAppearance.BorderColor = Color.Black;
            button5.FlatAppearance.BorderSize = 2;
            button5.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.Location = new Point(769, 321);
            button5.Name = "button5";
            button5.Size = new Size(268, 71);
            button5.TabIndex = 10;
            button5.Text = "Play as White";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1185, 609);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1203, 656);
            MinimumSize = new Size(1203, 656);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private Label label1;
        private Label label2;
        private Button button4;
        private Button button5;
    }
}