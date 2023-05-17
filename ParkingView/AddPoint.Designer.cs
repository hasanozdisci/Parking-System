namespace ParkingView
{
    partial class AddPoint
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
            mtbPoint = new MaskedTextBox();
            btnAddPoint = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(148, 15);
            label1.TabIndex = 1;
            label1.Text = "Yüklemek İstediğiniz Tutar:";
            // 
            // mtbPoint
            // 
            mtbPoint.Location = new Point(175, 28);
            mtbPoint.Mask = "0000";
            mtbPoint.Name = "mtbPoint";
            mtbPoint.Size = new Size(117, 23);
            mtbPoint.TabIndex = 2;
            mtbPoint.ValidatingType = typeof(int);
            // 
            // btnAddPoint
            // 
            btnAddPoint.Location = new Point(175, 84);
            btnAddPoint.Name = "btnAddPoint";
            btnAddPoint.Size = new Size(117, 23);
            btnAddPoint.TabIndex = 3;
            btnAddPoint.Text = "Yükle";
            btnAddPoint.UseVisualStyleBackColor = true;
            btnAddPoint.Click += btnAddPoint_Click;
            // 
            // AddPoint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 134);
            Controls.Add(btnAddPoint);
            Controls.Add(mtbPoint);
            Controls.Add(label1);
            Name = "AddPoint";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bakiye Yükleme Ekranı";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private MaskedTextBox mtbPoint;
        private Button btnAddPoint;
    }
}