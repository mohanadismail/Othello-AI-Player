namespace OthelloAI
{
    partial class boardWindow
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
            boardLayout = new TableLayoutPanel();
            label1 = new Label();
            whiteScoreLabel = new Label();
            label3 = new Label();
            blackScoreLabel = new Label();
            turnLabel = new Label();
            nextMoveButton = new Button();
            SuspendLayout();
            // 
            // boardLayout
            // 
            boardLayout.BackColor = Color.Black;
            boardLayout.ColumnCount = 8;
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardLayout.Location = new Point(108, 164);
            boardLayout.Name = "boardLayout";
            boardLayout.RowCount = 8;
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardLayout.Size = new Size(1005, 740);
            boardLayout.TabIndex = 0;
            boardLayout.Paint += boardLayout_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(65, 58);
            label1.Name = "label1";
            label1.Size = new Size(213, 35);
            label1.TabIndex = 0;
            label1.Text = "White Score:";
            label1.Click += label1_Click;
            // 
            // whiteScoreLabel
            // 
            whiteScoreLabel.AutoSize = true;
            whiteScoreLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            whiteScoreLabel.Location = new Point(307, 58);
            whiteScoreLabel.Name = "whiteScoreLabel";
            whiteScoreLabel.Size = new Size(28, 35);
            whiteScoreLabel.TabIndex = 1;
            whiteScoreLabel.Text = "2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(755, 58);
            label3.Name = "label3";
            label3.Size = new Size(205, 35);
            label3.TabIndex = 2;
            label3.Text = "Black Score:";
            // 
            // blackScoreLabel
            // 
            blackScoreLabel.AutoSize = true;
            blackScoreLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            blackScoreLabel.Location = new Point(1000, 58);
            blackScoreLabel.Name = "blackScoreLabel";
            blackScoreLabel.Size = new Size(113, 35);
            blackScoreLabel.TabIndex = 3;
            blackScoreLabel.Text = "label4";
            blackScoreLabel.Click += blackScoreLabel_Click;
            // 
            // turnLabel
            // 
            turnLabel.AutoSize = true;
            turnLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            turnLabel.Location = new Point(450, 99);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new Size(90, 35);
            turnLabel.TabIndex = 4;
            turnLabel.Text = "Turn";
            turnLabel.Click += turnLabel_Click;
            // 
            // nextMoveButton
            // 
            nextMoveButton.BackColor = Color.Black;
            nextMoveButton.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
            nextMoveButton.ForeColor = Color.White;
            nextMoveButton.Location = new Point(1128, 823);
            nextMoveButton.Name = "nextMoveButton";
            nextMoveButton.Size = new Size(94, 81);
            nextMoveButton.TabIndex = 5;
            nextMoveButton.Text = "Next Move";
            nextMoveButton.UseVisualStyleBackColor = false;
            nextMoveButton.Click += button1_Click;
            // 
            // boardWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1234, 945);
            Controls.Add(nextMoveButton);
            Controls.Add(turnLabel);
            Controls.Add(blackScoreLabel);
            Controls.Add(label3);
            Controls.Add(whiteScoreLabel);
            Controls.Add(label1);
            Controls.Add(boardLayout);
            MaximumSize = new Size(1252, 992);
            MinimumSize = new Size(1252, 992);
            Name = "boardWindow";
            Text = "boardWindow";
            Load += boardWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel boardLayout;
        private Label label1;
        private Label whiteScoreLabel;
        private Label label3;
        private Label blackScoreLabel;
        private Label turnLabel;
        private Button nextMoveButton;
    }
}