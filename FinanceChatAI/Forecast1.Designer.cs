namespace FinanceChatAI
{
    partial class Forecast1
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
            Forecast_label1 = new Label();
            Forecast_comboBox1 = new ComboBox();
            Forecast_label2 = new Label();
            Forecast_textBox1 = new TextBox();
            Forecast_label3 = new Label();
            Forecast_label4 = new Label();
            Forecast_label5 = new Label();
            Forecast_label6 = new Label();
            Forecast_label7_point = new Label();
            Forecast_label8 = new Label();
            btn_check = new Button();
            Forecast_label9 = new Label();
            SuspendLayout();
            // 
            // Forecast_label1
            // 
            Forecast_label1.AutoSize = true;
            Forecast_label1.Font = new Font("Microsoft JhengHei UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label1.ForeColor = Color.Red;
            Forecast_label1.Location = new Point(190, 9);
            Forecast_label1.Name = "Forecast_label1";
            Forecast_label1.Size = new Size(377, 47);
            Forecast_label1.TabIndex = 0;
            Forecast_label1.Text = "Auto Forecast Stock";
            // 
            // Forecast_comboBox1
            // 
            Forecast_comboBox1.FormattingEnabled = true;
            Forecast_comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            Forecast_comboBox1.Location = new Point(450, 92);
            Forecast_comboBox1.Name = "Forecast_comboBox1";
            Forecast_comboBox1.Size = new Size(38, 27);
            Forecast_comboBox1.TabIndex = 1;
            // 
            // Forecast_label2
            // 
            Forecast_label2.AutoSize = true;
            Forecast_label2.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label2.Location = new Point(190, 59);
            Forecast_label2.Name = "Forecast_label2";
            Forecast_label2.Size = new Size(363, 29);
            Forecast_label2.TabIndex = 2;
            Forecast_label2.Text = "請問您想以近10天內過濾的資料中";
            // 
            // Forecast_textBox1
            // 
            Forecast_textBox1.Location = new Point(688, 9);
            Forecast_textBox1.Multiline = true;
            Forecast_textBox1.Name = "Forecast_textBox1";
            Forecast_textBox1.ScrollBars = ScrollBars.Both;
            Forecast_textBox1.Size = new Size(713, 421);
            Forecast_textBox1.TabIndex = 3;
            // 
            // Forecast_label3
            // 
            Forecast_label3.AutoSize = true;
            Forecast_label3.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label3.Location = new Point(190, 143);
            Forecast_label3.Name = "Forecast_label3";
            Forecast_label3.Size = new Size(276, 29);
            Forecast_label3.TabIndex = 4;
            Forecast_label3.Text = "正在產生Bing Chat結果...";
            // 
            // Forecast_label4
            // 
            Forecast_label4.AutoSize = true;
            Forecast_label4.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label4.Location = new Point(612, 92);
            Forecast_label4.Name = "Forecast_label4";
            Forecast_label4.Size = new Size(70, 29);
            Forecast_label4.TabIndex = 5;
            Forecast_label4.Text = "好的!";
            // 
            // Forecast_label5
            // 
            Forecast_label5.AutoSize = true;
            Forecast_label5.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label5.Location = new Point(190, 190);
            Forecast_label5.Name = "Forecast_label5";
            Forecast_label5.Size = new Size(323, 29);
            Forecast_label5.TabIndex = 6;
            Forecast_label5.Text = "新聞每日預測股票分數已產生!";
            // 
            // Forecast_label6
            // 
            Forecast_label6.AutoSize = true;
            Forecast_label6.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label6.Location = new Point(195, 232);
            Forecast_label6.Name = "Forecast_label6";
            Forecast_label6.Size = new Size(318, 29);
            Forecast_label6.TabIndex = 7;
            Forecast_label6.Text = "您的平均新聞預測股票指數為:";
            // 
            // Forecast_label7_point
            // 
            Forecast_label7_point.AutoSize = true;
            Forecast_label7_point.Font = new Font("Microsoft JhengHei UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label7_point.ForeColor = Color.Red;
            Forecast_label7_point.Location = new Point(308, 294);
            Forecast_label7_point.Name = "Forecast_label7_point";
            Forecast_label7_point.Size = new Size(109, 60);
            Forecast_label7_point.TabIndex = 8;
            Forecast_label7_point.Text = "100";
            // 
            // Forecast_label8
            // 
            Forecast_label8.AutoSize = true;
            Forecast_label8.Font = new Font("Microsoft JhengHei UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label8.ForeColor = Color.Red;
            Forecast_label8.Location = new Point(513, 294);
            Forecast_label8.Name = "Forecast_label8";
            Forecast_label8.Size = new Size(67, 60);
            Forecast_label8.TabIndex = 9;
            Forecast_label8.Text = "%";
            // 
            // btn_check
            // 
            btn_check.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_check.Location = new Point(516, 90);
            btn_check.Name = "btn_check";
            btn_check.Size = new Size(64, 29);
            btn_check.TabIndex = 10;
            btn_check.Text = "確定!";
            btn_check.UseVisualStyleBackColor = true;
            btn_check.Click += btn_check_Click;
            // 
            // Forecast_label9
            // 
            Forecast_label9.AutoSize = true;
            Forecast_label9.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Forecast_label9.Location = new Point(190, 90);
            Forecast_label9.Name = "Forecast_label9";
            Forecast_label9.Size = new Size(254, 29);
            Forecast_label9.TabIndex = 11;
            Forecast_label9.Text = "幾日內的新聞進行預測?";
            // 
            // Forecast1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1348, 372);
            Controls.Add(Forecast_label9);
            Controls.Add(btn_check);
            Controls.Add(Forecast_label8);
            Controls.Add(Forecast_label7_point);
            Controls.Add(Forecast_label6);
            Controls.Add(Forecast_label5);
            Controls.Add(Forecast_label4);
            Controls.Add(Forecast_label3);
            Controls.Add(Forecast_textBox1);
            Controls.Add(Forecast_label2);
            Controls.Add(Forecast_comboBox1);
            Controls.Add(Forecast_label1);
            Name = "Forecast1";
            Text = "Forecast1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Forecast_label1;
        private ComboBox Forecast_comboBox1;
        private Label Forecast_label2;
        private TextBox Forecast_textBox1;
        private Label Forecast_label3;
        private Label Forecast_label4;
        private Label Forecast_label5;
        private Label Forecast_label6;
        private Label Forecast_label7_point;
        private Label Forecast_label8;
        private Button btn_check;
        private Label Forecast_label9;
    }
}