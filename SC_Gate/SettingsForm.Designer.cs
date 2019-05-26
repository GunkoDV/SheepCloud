namespace SC_Gate
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.Address_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Save_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NHist_TB = new System.Windows.Forms.TextBox();
            this.Interval_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Port_TB);
            this.groupBox1.Controls.Add(this.Address_TB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.groupBox1.Size = new System.Drawing.Size(388, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки подключения";
            // 
            // Port_TB
            // 
            this.Port_TB.Location = new System.Drawing.Point(317, 36);
            this.Port_TB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.Size = new System.Drawing.Size(58, 26);
            this.Port_TB.TabIndex = 3;
            // 
            // Address_TB
            // 
            this.Address_TB.Location = new System.Drawing.Point(83, 36);
            this.Address_TB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Address_TB.Name = "Address_TB";
            this.Address_TB.Size = new System.Drawing.Size(162, 26);
            this.Address_TB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Порт:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес:";
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(20, 209);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(175, 53);
            this.Save_btn.TabIndex = 2;
            this.Save_btn.Text = "Сохранить";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Число столбцов гистограммы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "(должно быть степенью двух)";
            // 
            // NHist_TB
            // 
            this.NHist_TB.Location = new System.Drawing.Point(337, 132);
            this.NHist_TB.Name = "NHist_TB";
            this.NHist_TB.Size = new System.Drawing.Size(58, 26);
            this.NHist_TB.TabIndex = 5;
            // 
            // Interval_TB
            // 
            this.Interval_TB.Location = new System.Drawing.Point(337, 170);
            this.Interval_TB.Name = "Interval_TB";
            this.Interval_TB.Size = new System.Drawing.Size(58, 26);
            this.Interval_TB.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Интервал формирования отчёта, мин";
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(233, 209);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(175, 53);
            this.Cancel_btn.TabIndex = 8;
            this.Cancel_btn.Text = "Отменить";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 290);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Interval_TB);
            this.Controls.Add(this.NHist_TB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки программы";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Port_TB;
        private System.Windows.Forms.TextBox Address_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NHist_TB;
        private System.Windows.Forms.TextBox Interval_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Cancel_btn;
    }
}