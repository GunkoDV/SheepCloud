namespace SC_COM_Emulator
{
    partial class COM_MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Ports_CB = new System.Windows.Forms.ComboBox();
            this.UpdateCOMList_lbl = new System.Windows.Forms.Label();
            this.Port_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveSett_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TwoSB_RB = new System.Windows.Forms.RadioButton();
            this.OneHalfSB_RB = new System.Windows.Forms.RadioButton();
            this.OneSB_RB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ParityEven_RB = new System.Windows.Forms.RadioButton();
            this.ParityOdd_RB = new System.Windows.Forms.RadioButton();
            this.ParityNone_RB = new System.Windows.Forms.RadioButton();
            this.Databits_CB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bdRate_CB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PortState_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Request_lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Response_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя порта";
            // 
            // Ports_CB
            // 
            this.Ports_CB.FormattingEnabled = true;
            this.Ports_CB.Location = new System.Drawing.Point(107, 12);
            this.Ports_CB.Name = "Ports_CB";
            this.Ports_CB.Size = new System.Drawing.Size(121, 28);
            this.Ports_CB.TabIndex = 1;
            // 
            // UpdateCOMList_lbl
            // 
            this.UpdateCOMList_lbl.AutoSize = true;
            this.UpdateCOMList_lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateCOMList_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateCOMList_lbl.Location = new System.Drawing.Point(12, 45);
            this.UpdateCOMList_lbl.Name = "UpdateCOMList_lbl";
            this.UpdateCOMList_lbl.Size = new System.Drawing.Size(139, 20);
            this.UpdateCOMList_lbl.TabIndex = 2;
            this.UpdateCOMList_lbl.Text = "Обновить список";
            this.UpdateCOMList_lbl.Click += new System.EventHandler(this.UpdateCOMList_lbl_Click);
            // 
            // Port_btn
            // 
            this.Port_btn.Location = new System.Drawing.Point(16, 77);
            this.Port_btn.Name = "Port_btn";
            this.Port_btn.Size = new System.Drawing.Size(212, 45);
            this.Port_btn.TabIndex = 3;
            this.Port_btn.Text = "button1";
            this.Port_btn.UseVisualStyleBackColor = true;
            this.Port_btn.Click += new System.EventHandler(this.Port_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveSett_btn);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Databits_CB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bdRate_CB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(234, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 157);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки порта";
            // 
            // SaveSett_btn
            // 
            this.SaveSett_btn.Location = new System.Drawing.Point(10, 99);
            this.SaveSett_btn.Name = "SaveSett_btn";
            this.SaveSett_btn.Size = new System.Drawing.Size(206, 42);
            this.SaveSett_btn.TabIndex = 6;
            this.SaveSett_btn.Text = "Сохранить";
            this.SaveSett_btn.UseVisualStyleBackColor = true;
            this.SaveSett_btn.Click += new System.EventHandler(this.SaveSett_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TwoSB_RB);
            this.groupBox3.Controls.Add(this.OneHalfSB_RB);
            this.groupBox3.Controls.Add(this.OneSB_RB);
            this.groupBox3.Location = new System.Drawing.Point(362, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 125);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Стоп бит";
            // 
            // TwoSB_RB
            // 
            this.TwoSB_RB.AutoSize = true;
            this.TwoSB_RB.Location = new System.Drawing.Point(20, 86);
            this.TwoSB_RB.Name = "TwoSB_RB";
            this.TwoSB_RB.Size = new System.Drawing.Size(36, 24);
            this.TwoSB_RB.TabIndex = 2;
            this.TwoSB_RB.TabStop = true;
            this.TwoSB_RB.Text = "2";
            this.TwoSB_RB.UseVisualStyleBackColor = true;
            // 
            // OneHalfSB_RB
            // 
            this.OneHalfSB_RB.AutoSize = true;
            this.OneHalfSB_RB.Location = new System.Drawing.Point(20, 56);
            this.OneHalfSB_RB.Name = "OneHalfSB_RB";
            this.OneHalfSB_RB.Size = new System.Drawing.Size(49, 24);
            this.OneHalfSB_RB.TabIndex = 1;
            this.OneHalfSB_RB.TabStop = true;
            this.OneHalfSB_RB.Text = "1.5";
            this.OneHalfSB_RB.UseVisualStyleBackColor = true;
            // 
            // OneSB_RB
            // 
            this.OneSB_RB.AutoSize = true;
            this.OneSB_RB.Location = new System.Drawing.Point(20, 26);
            this.OneSB_RB.Name = "OneSB_RB";
            this.OneSB_RB.Size = new System.Drawing.Size(36, 24);
            this.OneSB_RB.TabIndex = 0;
            this.OneSB_RB.TabStop = true;
            this.OneSB_RB.Text = "1";
            this.OneSB_RB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ParityEven_RB);
            this.groupBox2.Controls.Add(this.ParityOdd_RB);
            this.groupBox2.Controls.Add(this.ParityNone_RB);
            this.groupBox2.Location = new System.Drawing.Point(222, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 125);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Бит чётности";
            // 
            // ParityEven_RB
            // 
            this.ParityEven_RB.AutoSize = true;
            this.ParityEven_RB.Location = new System.Drawing.Point(17, 86);
            this.ParityEven_RB.Name = "ParityEven_RB";
            this.ParityEven_RB.Size = new System.Drawing.Size(36, 24);
            this.ParityEven_RB.TabIndex = 2;
            this.ParityEven_RB.TabStop = true;
            this.ParityEven_RB.Text = "2";
            this.ParityEven_RB.UseVisualStyleBackColor = true;
            // 
            // ParityOdd_RB
            // 
            this.ParityOdd_RB.AutoSize = true;
            this.ParityOdd_RB.Location = new System.Drawing.Point(17, 56);
            this.ParityOdd_RB.Name = "ParityOdd_RB";
            this.ParityOdd_RB.Size = new System.Drawing.Size(36, 24);
            this.ParityOdd_RB.TabIndex = 1;
            this.ParityOdd_RB.TabStop = true;
            this.ParityOdd_RB.Text = "1";
            this.ParityOdd_RB.UseVisualStyleBackColor = true;
            // 
            // ParityNone_RB
            // 
            this.ParityNone_RB.AutoSize = true;
            this.ParityNone_RB.Location = new System.Drawing.Point(17, 26);
            this.ParityNone_RB.Name = "ParityNone_RB";
            this.ParityNone_RB.Size = new System.Drawing.Size(57, 24);
            this.ParityNone_RB.TabIndex = 0;
            this.ParityNone_RB.TabStop = true;
            this.ParityNone_RB.Text = "Нет";
            this.ParityNone_RB.UseVisualStyleBackColor = true;
            // 
            // Databits_CB
            // 
            this.Databits_CB.FormattingEnabled = true;
            this.Databits_CB.Location = new System.Drawing.Point(127, 65);
            this.Databits_CB.Name = "Databits_CB";
            this.Databits_CB.Size = new System.Drawing.Size(89, 28);
            this.Databits_CB.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Биты данных";
            // 
            // bdRate_CB
            // 
            this.bdRate_CB.FormattingEnabled = true;
            this.bdRate_CB.Location = new System.Drawing.Point(95, 25);
            this.bdRate_CB.Name = "bdRate_CB";
            this.bdRate_CB.Size = new System.Drawing.Size(121, 28);
            this.bdRate_CB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Скорость";
            // 
            // PortState_lbl
            // 
            this.PortState_lbl.AutoSize = true;
            this.PortState_lbl.Location = new System.Drawing.Point(12, 133);
            this.PortState_lbl.Name = "PortState_lbl";
            this.PortState_lbl.Size = new System.Drawing.Size(51, 20);
            this.PortState_lbl.TabIndex = 5;
            this.PortState_lbl.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Получено запросов:";
            // 
            // Request_lbl
            // 
            this.Request_lbl.AutoSize = true;
            this.Request_lbl.Location = new System.Drawing.Point(240, 178);
            this.Request_lbl.Name = "Request_lbl";
            this.Request_lbl.Size = new System.Drawing.Size(51, 20);
            this.Request_lbl.TabIndex = 7;
            this.Request_lbl.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Отправлено данных, байт:";
            // 
            // Response_label
            // 
            this.Response_label.AutoSize = true;
            this.Response_label.Location = new System.Drawing.Point(240, 212);
            this.Response_label.Name = "Response_label";
            this.Response_label.Size = new System.Drawing.Size(51, 20);
            this.Response_label.TabIndex = 9;
            this.Response_label.Text = "label7";
            // 
            // COM_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 255);
            this.Controls.Add(this.Response_label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Request_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PortState_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Port_btn);
            this.Controls.Add(this.UpdateCOMList_lbl);
            this.Controls.Add(this.Ports_CB);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "COM_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Эмулятор COM устройствва";
            this.Load += new System.EventHandler(this.COM_MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Ports_CB;
        private System.Windows.Forms.Label UpdateCOMList_lbl;
        private System.Windows.Forms.Button Port_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveSett_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton TwoSB_RB;
        private System.Windows.Forms.RadioButton OneHalfSB_RB;
        private System.Windows.Forms.RadioButton OneSB_RB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ParityEven_RB;
        private System.Windows.Forms.RadioButton ParityOdd_RB;
        private System.Windows.Forms.RadioButton ParityNone_RB;
        private System.Windows.Forms.ComboBox Databits_CB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox bdRate_CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PortState_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Request_lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Response_label;
    }
}

