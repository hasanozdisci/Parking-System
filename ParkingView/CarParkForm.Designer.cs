namespace ParkingView
{
    partial class CarParkForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.LawnGreen;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(48, 29);
            label1.Name = "label1";
            label1.Size = new Size(125, 148);
            label1.TabIndex = 0;
            label1.Text = "PARK 1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.LawnGreen;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(297, 29);
            label2.Name = "label2";
            label2.Size = new Size(125, 148);
            label2.TabIndex = 0;
            label2.Text = "PARK 2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.LawnGreen;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(557, 29);
            label3.Name = "label3";
            label3.Size = new Size(125, 148);
            label3.TabIndex = 0;
            label3.Text = "PARK 3";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.LawnGreen;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(48, 269);
            label4.Name = "label4";
            label4.Size = new Size(125, 148);
            label4.TabIndex = 0;
            label4.Text = "PARK 4";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.BackColor = Color.LawnGreen;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(297, 269);
            label5.Name = "label5";
            label5.Size = new Size(125, 148);
            label5.TabIndex = 0;
            label5.Text = "PARK 5";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.BackColor = Color.LawnGreen;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(557, 269);
            label6.Name = "label6";
            label6.Size = new Size(125, 148);
            label6.TabIndex = 0;
            label6.Text = "PARK 6";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(48, 222);
            label7.Name = "label7";
            label7.Size = new Size(125, 7);
            label7.TabIndex = 1;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(297, 222);
            label8.Name = "label8";
            label8.Size = new Size(125, 7);
            label8.TabIndex = 2;
            // 
            // label9
            // 
            label9.BackColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(557, 222);
            label9.Name = "label9";
            label9.Size = new Size(125, 7);
            label9.TabIndex = 3;
            // 
            // CarParkForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(713, 462);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "CarParkForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Otopark";
            Load += CarParkForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}