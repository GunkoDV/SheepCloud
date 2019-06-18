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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ConnectSckt_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Sckt_State_lbl = new System.Windows.Forms.Label();
            this.PLCData_GB = new System.Windows.Forms.GroupBox();
            this.Current_val_lbl = new System.Windows.Forms.Label();
            this.COM_pack_counter_lbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.COM_connect_stat_lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PLC_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Settings_btn = new System.Windows.Forms.Button();
            this.Stoptimer = new System.Windows.Forms.Timer(this.components);
            this.PLCData_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PLC_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectSckt_btn
            // 
            this.ConnectSckt_btn.Location = new System.Drawing.Point(12, 14);
            this.ConnectSckt_btn.Name = "ConnectSckt_btn";
            this.ConnectSckt_btn.Size = new System.Drawing.Size(217, 44);
            this.ConnectSckt_btn.TabIndex = 0;
            this.ConnectSckt_btn.Text = "button1";
            this.ConnectSckt_btn.UseVisualStyleBackColor = true;
            this.ConnectSckt_btn.Click += new System.EventHandler(this.ConnectSckt_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Состояние подключения:";
            // 
            // Sckt_State_lbl
            // 
            this.Sckt_State_lbl.AutoSize = true;
            this.Sckt_State_lbl.Location = new System.Drawing.Point(12, 148);
            this.Sckt_State_lbl.Name = "Sckt_State_lbl";
            this.Sckt_State_lbl.Size = new System.Drawing.Size(51, 20);
            this.Sckt_State_lbl.TabIndex = 1;
            this.Sckt_State_lbl.Text = "label5";
            // 
            // PLCData_GB
            // 
            this.PLCData_GB.Controls.Add(this.Current_val_lbl);
            this.PLCData_GB.Controls.Add(this.COM_pack_counter_lbl);
            this.PLCData_GB.Controls.Add(this.label11);
            this.PLCData_GB.Controls.Add(this.label9);
            this.PLCData_GB.Controls.Add(this.COM_connect_stat_lbl);
            this.PLCData_GB.Controls.Add(this.label7);
            this.PLCData_GB.Controls.Add(this.label6);
            this.PLCData_GB.Location = new System.Drawing.Point(889, 14);
            this.PLCData_GB.Name = "PLCData_GB";
            this.PLCData_GB.Size = new System.Drawing.Size(301, 154);
            this.PLCData_GB.TabIndex = 6;
            this.PLCData_GB.TabStop = false;
            this.PLCData_GB.Text = "Данные регистров ПЛК";
            // 
            // Current_val_lbl
            // 
            this.Current_val_lbl.AutoSize = true;
            this.Current_val_lbl.Location = new System.Drawing.Point(192, 114);
            this.Current_val_lbl.Name = "Current_val_lbl";
            this.Current_val_lbl.Size = new System.Drawing.Size(99, 20);
            this.Current_val_lbl.TabIndex = 7;
            this.Current_val_lbl.Text = "Нет данных";
            // 
            // COM_pack_counter_lbl
            // 
            this.COM_pack_counter_lbl.AutoSize = true;
            this.COM_pack_counter_lbl.Location = new System.Drawing.Point(192, 78);
            this.COM_pack_counter_lbl.Name = "COM_pack_counter_lbl";
            this.COM_pack_counter_lbl.Size = new System.Drawing.Size(99, 20);
            this.COM_pack_counter_lbl.TabIndex = 6;
            this.COM_pack_counter_lbl.Text = "Нет данных";
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
            this.COM_connect_stat_lbl.Size = new System.Drawing.Size(99, 20);
            this.COM_connect_stat_lbl.TabIndex = 2;
            this.COM_connect_stat_lbl.Text = "Нет данных";
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
            // PLC_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.PLC_chart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.PLC_chart.Legends.Add(legend2);
            this.PLC_chart.Location = new System.Drawing.Point(12, 174);
            this.PLC_chart.Name = "PLC_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.PLC_chart.Series.Add(series2);
            this.PLC_chart.Size = new System.Drawing.Size(1182, 376);
            this.PLC_chart.TabIndex = 7;
            this.PLC_chart.Text = "chart1";
            // 
            // Settings_btn
            // 
            this.Settings_btn.Location = new System.Drawing.Point(12, 68);
            this.Settings_btn.Name = "Settings_btn";
            this.Settings_btn.Size = new System.Drawing.Size(217, 44);
            this.Settings_btn.TabIndex = 8;
            this.Settings_btn.Text = "Настройки";
            this.Settings_btn.UseVisualStyleBackColor = true;
            this.Settings_btn.Click += new System.EventHandler(this.Settings_btn_Click);
            // 
            // Stoptimer
            // 
            this.Stoptimer.Tick += new System.EventHandler(this.Stoptimer_Tick);
            // 
            // Gate_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 557);
            this.Controls.Add(this.Settings_btn);
            this.Controls.Add(this.PLC_chart);
            this.Controls.Add(this.PLCData_GB);
            this.Controls.Add(this.Sckt_State_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConnectSckt_btn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Gate_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Шлюз сбора данных с ПЛК";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Gate_MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Gate_MainForm_Load);
            this.PLCData_GB.ResumeLayout(false);
            this.PLCData_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PLC_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConnectSckt_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Sckt_State_lbl;
        private System.Windows.Forms.GroupBox PLCData_GB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label COM_connect_stat_lbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Current_val_lbl;
        private System.Windows.Forms.Label COM_pack_counter_lbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart PLC_chart;
        private System.Windows.Forms.Button Settings_btn;
        private System.Windows.Forms.Timer Stoptimer;
    }
}

