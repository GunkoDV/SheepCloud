namespace SC_Gate
{
    partial class Gate_MainForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Interval_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.Address_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectSckt_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Sckt_State_lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Request_Counter_lbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Current_val_lbl = new System.Windows.Forms.Label();
            this.COM_pack_counter_lbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.COM_connect_stat_lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Test_timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Interval_TB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Port_TB);
            this.groupBox1.Controls.Add(this.Address_TB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(217, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки подключения";
            // 
            // Interval_TB
            // 
            this.Interval_TB.Location = new System.Drawing.Point(76, 114);
            this.Interval_TB.Name = "Interval_TB";
            this.Interval_TB.Size = new System.Drawing.Size(134, 26);
            this.Interval_TB.TabIndex = 5;
            this.Interval_TB.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Интервал опроса, мс";
            // 
            // Port_TB
            // 
            this.Port_TB.Location = new System.Drawing.Point(76, 56);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.Size = new System.Drawing.Size(134, 26);
            this.Port_TB.TabIndex = 3;
            this.Port_TB.Text = "502";
            // 
            // Address_TB
            // 
            this.Address_TB.Location = new System.Drawing.Point(76, 24);
            this.Address_TB.Name = "Address_TB";
            this.Address_TB.Size = new System.Drawing.Size(134, 26);
            this.Address_TB.TabIndex = 2;
            this.Address_TB.Text = "10.0.6.10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Порт:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес:";
            // 
            // ConnectSckt_btn
            // 
            this.ConnectSckt_btn.Location = new System.Drawing.Point(24, 176);
            this.ConnectSckt_btn.Name = "ConnectSckt_btn";
            this.ConnectSckt_btn.Size = new System.Drawing.Size(199, 44);
            this.ConnectSckt_btn.TabIndex = 0;
            this.ConnectSckt_btn.Text = "button1";
            this.ConnectSckt_btn.UseVisualStyleBackColor = true;
            this.ConnectSckt_btn.Click += new System.EventHandler(this.ConnectSckt_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Состояние подключения:";
            // 
            // Sckt_State_lbl
            // 
            this.Sckt_State_lbl.AutoSize = true;
            this.Sckt_State_lbl.Location = new System.Drawing.Point(218, 233);
            this.Sckt_State_lbl.Name = "Sckt_State_lbl";
            this.Sckt_State_lbl.Size = new System.Drawing.Size(51, 20);
            this.Sckt_State_lbl.TabIndex = 3;
            this.Sckt_State_lbl.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Отправлено запросов:";
            // 
            // Request_Counter_lbl
            // 
            this.Request_Counter_lbl.AutoSize = true;
            this.Request_Counter_lbl.Location = new System.Drawing.Point(218, 263);
            this.Request_Counter_lbl.Name = "Request_Counter_lbl";
            this.Request_Counter_lbl.Size = new System.Drawing.Size(51, 20);
            this.Request_Counter_lbl.TabIndex = 5;
            this.Request_Counter_lbl.Text = "label6";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Current_val_lbl);
            this.groupBox2.Controls.Add(this.COM_pack_counter_lbl);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.COM_connect_stat_lbl);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(237, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 154);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные регистров ПЛК";
            // 
            // Current_val_lbl
            // 
            this.Current_val_lbl.AutoSize = true;
            this.Current_val_lbl.Location = new System.Drawing.Point(192, 114);
            this.Current_val_lbl.Name = "Current_val_lbl";
            this.Current_val_lbl.Size = new System.Drawing.Size(51, 20);
            this.Current_val_lbl.TabIndex = 7;
            this.Current_val_lbl.Text = "label8";
            // 
            // COM_pack_counter_lbl
            // 
            this.COM_pack_counter_lbl.AutoSize = true;
            this.COM_pack_counter_lbl.Location = new System.Drawing.Point(192, 78);
            this.COM_pack_counter_lbl.Name = "COM_pack_counter_lbl";
            this.COM_pack_counter_lbl.Size = new System.Drawing.Size(51, 20);
            this.COM_pack_counter_lbl.TabIndex = 6;
            this.COM_pack_counter_lbl.Text = "label8";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Полученное значение:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Принято пакетов:";
            // 
            // COM_connect_stat_lbl
            // 
            this.COM_connect_stat_lbl.AutoSize = true;
            this.COM_connect_stat_lbl.Location = new System.Drawing.Point(192, 44);
            this.COM_connect_stat_lbl.Name = "COM_connect_stat_lbl";
            this.COM_connect_stat_lbl.Size = new System.Drawing.Size(51, 20);
            this.COM_connect_stat_lbl.TabIndex = 2;
            this.COM_connect_stat_lbl.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "COM устройства:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Состояние подключения ";
            // 
            // Test_timer
            // 
            this.Test_timer.Tick += new System.EventHandler(this.Test_timer_Tick);
            // 
            // Gate_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 302);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Request_Counter_lbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Sckt_State_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConnectSckt_btn);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Gate_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Шлюз сбора данных с ПЛК";
            this.Load += new System.EventHandler(this.Gate_MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Port_TB;
        private System.Windows.Forms.TextBox Address_TB;
        private System.Windows.Forms.TextBox Interval_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ConnectSckt_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Sckt_State_lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Request_Counter_lbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label COM_connect_stat_lbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Current_val_lbl;
        private System.Windows.Forms.Label COM_pack_counter_lbl;
        private System.Windows.Forms.Timer Test_timer;
    }
}

