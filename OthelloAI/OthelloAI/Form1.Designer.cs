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
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(83, 80);
            button1.Name = "button1";
            button1.Size = new Size(229, 59);
            button1.TabIndex = 0;
            button1.Text = "Human vs Human";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(363, 80);
            button2.Name = "button2";
            button2.Size = new Size(229, 59);
            button2.TabIndex = 3;
            button2.Text = "Human vs Ai";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(645, 80);
            button3.Name = "button3";
            button3.Size = new Size(229, 59);
            button3.TabIndex = 4;
            button3.Text = "Ai vs Ai";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.Black;
            trackBar1.Location = new Point(134, 329);
            trackBar1.Maximum = 4;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(270, 56);
            trackBar1.TabIndex = 5;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.Black;
            trackBar2.Location = new Point(630, 329);
            trackBar2.Maximum = 4;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(277, 56);
            trackBar2.TabIndex = 6;
            // 
            // label1
            // 
            label1.BackColor = Color.Black;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 329);
            label1.Name = "label1";
            label1.Size = new Size(116, 56);
            label1.TabIndex = 7;
            label1.Text = "Ai Difficulty";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Black;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(513, 329);
            label2.Name = "label2";
            label2.Size = new Size(111, 56);
            label2.TabIndex = 8;
            label2.Text = "Ai Difficulty";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(292, 433);
            button4.Name = "button4";
            button4.Size = new Size(342, 70);
            button4.TabIndex = 9;
            button4.Text = "Start Game";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lime;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(945, 563);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
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
    }
}