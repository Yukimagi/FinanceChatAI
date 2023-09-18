namespace FinanceChatAI
{
    partial class Ask1
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
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            title_textBox = new TextBox();
            label2 = new Label();
            add_button = new Button();
            groupBox1 = new GroupBox();
            title_listBox = new ListBox();
            start_button = new Button();
            label3 = new Label();
            ans_textBox = new TextBox();
            re_button = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(130, 12);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 1;
            label1.Text = "請選擇日期";
            // 
            // title_textBox
            // 
            title_textBox.Location = new Point(6, 63);
            title_textBox.Multiline = true;
            title_textBox.Name = "title_textBox";
            title_textBox.ScrollBars = ScrollBars.Both;
            title_textBox.Size = new Size(368, 76);
            title_textBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(132, 25);
            label2.TabIndex = 3;
            label2.Text = "新增新聞標題";
            // 
            // add_button
            // 
            add_button.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            add_button.Location = new Point(176, 18);
            add_button.Name = "add_button";
            add_button.Size = new Size(106, 34);
            add_button.TabIndex = 4;
            add_button.Text = "新增";
            add_button.UseVisualStyleBackColor = true;
            add_button.Click += add_button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(add_button);
            groupBox1.Controls.Add(title_textBox);
            groupBox1.Location = new Point(12, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 149);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // title_listBox
            // 
            title_listBox.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            title_listBox.FormattingEnabled = true;
            title_listBox.ItemHeight = 19;
            title_listBox.Location = new Point(433, 14);
            title_listBox.MultiColumn = true;
            title_listBox.Name = "title_listBox";
            title_listBox.ScrollAlwaysVisible = true;
            title_listBox.Size = new Size(257, 365);
            title_listBox.TabIndex = 6;
            // 
            // start_button
            // 
            start_button.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            start_button.Location = new Point(150, 272);
            start_button.Name = "start_button";
            start_button.Size = new Size(80, 52);
            start_button.TabIndex = 7;
            start_button.Text = "開始";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += start_button_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(34, 227);
            label3.Name = "label3";
            label3.Size = new Size(330, 25);
            label3.TabIndex = 8;
            label3.Text = "標題已全部新增完成請按\"開始\"分析";
            // 
            // ans_textBox
            // 
            ans_textBox.Location = new Point(712, 16);
            ans_textBox.Multiline = true;
            ans_textBox.Name = "ans_textBox";
            ans_textBox.ScrollBars = ScrollBars.Both;
            ans_textBox.Size = new Size(449, 363);
            ans_textBox.TabIndex = 9;
            // 
            // re_button
            // 
            re_button.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            re_button.ForeColor = Color.Red;
            re_button.Location = new Point(130, 272);
            re_button.Name = "re_button";
            re_button.Size = new Size(120, 52);
            re_button.TabIndex = 10;
            re_button.Text = "重新開始";
            re_button.UseVisualStyleBackColor = true;
            re_button.Click += re_button_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(1167, 16);
            label4.Name = "label4";
            label4.Size = new Size(132, 25);
            label4.TabIndex = 11;
            label4.Text = "您的平均新聞";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(1167, 41);
            label5.Name = "label5";
            label5.Size = new Size(157, 25);
            label5.TabIndex = 12;
            label5.Text = "預測股票指數為:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(1206, 157);
            label6.Name = "label6";
            label6.Size = new Size(139, 50);
            label6.TabIndex = 13;
            label6.Text = "label6";
            // 
            // Ask1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1348, 372);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ans_textBox);
            Controls.Add(label3);
            Controls.Add(start_button);
            Controls.Add(title_listBox);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(re_button);
            Name = "Ask1";
            Text = "Ask1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private TextBox title_textBox;
        private Label label2;
        private Button add_button;
        private GroupBox groupBox1;
        private ListBox title_listBox;
        private Button start_button;
        private Label label3;
        private TextBox ans_textBox;
        private Button re_button;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}