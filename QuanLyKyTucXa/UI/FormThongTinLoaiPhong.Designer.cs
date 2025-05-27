namespace QuanLyKyTucXa.UI
{
    partial class FormThongTinLoaiPhong
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
            dataGridView1 = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(202, 18);
            label1.Name = "label1";
            label1.Size = new Size(404, 46);
            label1.TabIndex = 16;
            label1.Text = "THÔNG TIN LOẠI PHÒNG";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-13, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(811, 329);
            dataGridView1.TabIndex = 17;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(11, 20);
            button2.Name = "button2";
            button2.Size = new Size(144, 51);
            button2.TabIndex = 18;
            button2.Text = "QUAY LẠI";
            button2.UseVisualStyleBackColor = false;
            // 
            // FormThongTinLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 463);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            ForeColor = Color.Blue;
            Name = "FormThongTinLoaiPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormThongTinLoaiPhong";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private DataGridView dataGridView1;
        private Button button2;
    }
}