﻿namespace Game_dev_S2_project_1
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
            IbIDisplay = new Label();
            textBox1 = new TextBox();
            Up = new Button();
            Down = new Button();
            Right = new Button();
            Left = new Button();
            SuspendLayout();
            // 
            // IbIDisplay
            // 
            IbIDisplay.AutoSize = true;
            IbIDisplay.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point);
            IbIDisplay.Location = new Point(443, 213);
            IbIDisplay.Name = "IbIDisplay";
            IbIDisplay.Size = new Size(61, 15);
            IbIDisplay.TabIndex = 0;
            IbIDisplay.Text = "label1";
            IbIDisplay.Click += IbIDisplay_Click;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(14, 532);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(867, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Up
            // 
            Up.Location = new Point(730, 333);
            Up.Margin = new Padding(3, 4, 3, 4);
            Up.Name = "Up";
            Up.Size = new Size(86, 31);
            Up.TabIndex = 2;
            Up.Text = "Up";
            Up.UseVisualStyleBackColor = true;
            Up.Click += Up_Click;
            // 
            // Down
            // 
            Down.Location = new Point(730, 389);
            Down.Margin = new Padding(3, 4, 3, 4);
            Down.Name = "Down";
            Down.Size = new Size(86, 31);
            Down.TabIndex = 3;
            Down.Text = "Down";
            Down.UseVisualStyleBackColor = true;
            Down.Click += Down_Click;
            // 
            // Right
            // 
            Right.Location = new Point(816, 361);
            Right.Margin = new Padding(3, 4, 3, 4);
            Right.Name = "Right";
            Right.Size = new Size(86, 31);
            Right.TabIndex = 4;
            Right.Text = "Right";
            Right.UseVisualStyleBackColor = true;
            Right.Click += Right_Click;
            // 
            // Left
            // 
            Left.Location = new Point(638, 361);
            Left.Margin = new Padding(3, 4, 3, 4);
            Left.Name = "Left";
            Left.Size = new Size(86, 31);
            Left.TabIndex = 5;
            Left.Text = "Left";
            Left.UseVisualStyleBackColor = true;
            Left.Click += Left_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(Left);
            Controls.Add(Right);
            Controls.Add(Down);
            Controls.Add(Up);
            Controls.Add(textBox1);
            Controls.Add(IbIDisplay);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IbIDisplay;
        private TextBox textBox1;
        private Button Up;
        private Button Down;
        private Button Right;
        private Button Left;
    }
}