namespace FinanceChatAI
{
    partial class Research1
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
            textBox1 = new TextBox();
            btn_NewsCatch = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_NewsFilter = new Button();
            label4 = new Label();
            btn_IntradayReturn = new Button();
            label5 = new Label();
            btn_BingChat = new Button();
            label6 = new Label();
            btn_Conclusion = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(323, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(756, 395);
            textBox1.TabIndex = 0;
            // 
            // btn_NewsCatch
            // 
            btn_NewsCatch.Location = new Point(35, 28);
            btn_NewsCatch.Name = "btn_NewsCatch";
            btn_NewsCatch.Size = new Size(126, 29);
            btn_NewsCatch.TabIndex = 1;
            btn_NewsCatch.Text = "News Catch";
            btn_NewsCatch.UseVisualStyleBackColor = true;
            btn_NewsCatch.Click += btn_NewsCatch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 6);
            label1.Name = "label1";
            label1.Size = new Size(282, 19);
            label1.TabIndex = 2;
            label1.Text = "以下是執行此研究的步驟，請按步驟執行:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 33);
            label2.Name = "label2";
            label2.Size = new Size(21, 19);
            label2.TabIndex = 3;
            label2.Text = "1.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 70);
            label3.Name = "label3";
            label3.Size = new Size(21, 19);
            label3.TabIndex = 4;
            label3.Text = "2.";
            // 
            // btn_NewsFilter
            // 
            btn_NewsFilter.Location = new Point(35, 65);
            btn_NewsFilter.Name = "btn_NewsFilter";
            btn_NewsFilter.Size = new Size(126, 29);
            btn_NewsFilter.TabIndex = 5;
            btn_NewsFilter.Text = "News Filter";
            btn_NewsFilter.UseVisualStyleBackColor = true;
            btn_NewsFilter.Click += btn_NewsFilter_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 106);
            label4.Name = "label4";
            label4.Size = new Size(21, 19);
            label4.TabIndex = 6;
            label4.Text = "3.";
            // 
            // btn_IntradayReturn
            // 
            btn_IntradayReturn.Location = new Point(35, 101);
            btn_IntradayReturn.Name = "btn_IntradayReturn";
            btn_IntradayReturn.Size = new Size(126, 29);
            btn_IntradayReturn.TabIndex = 7;
            btn_IntradayReturn.Text = "Intraday Return";
            btn_IntradayReturn.UseVisualStyleBackColor = true;
            btn_IntradayReturn.Click += btn_IntradayReturn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 142);
            label5.Name = "label5";
            label5.Size = new Size(21, 19);
            label5.TabIndex = 8;
            label5.Text = "4.";
            // 
            // btn_BingChat
            // 
            btn_BingChat.Location = new Point(34, 137);
            btn_BingChat.Name = "btn_BingChat";
            btn_BingChat.Size = new Size(127, 29);
            btn_BingChat.TabIndex = 9;
            btn_BingChat.Text = "Bing Chat";
            btn_BingChat.UseVisualStyleBackColor = true;
            btn_BingChat.Click += btn_BingChat_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 180);
            label6.Name = "label6";
            label6.Size = new Size(21, 19);
            label6.TabIndex = 10;
            label6.Text = "5.";
            // 
            // btn_Conclusion
            // 
            btn_Conclusion.Location = new Point(37, 179);
            btn_Conclusion.Name = "btn_Conclusion";
            btn_Conclusion.Size = new Size(124, 29);
            btn_Conclusion.TabIndex = 11;
            btn_Conclusion.Text = "Conclusion";
            btn_Conclusion.UseVisualStyleBackColor = true;
            btn_Conclusion.Click += btn_Conclusion_Click;
            // 
            // Research1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1082, 410);
            Controls.Add(btn_Conclusion);
            Controls.Add(label6);
            Controls.Add(btn_BingChat);
            Controls.Add(label5);
            Controls.Add(btn_IntradayReturn);
            Controls.Add(label4);
            Controls.Add(btn_NewsFilter);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_NewsCatch);
            Controls.Add(textBox1);
            Name = "Research1";
            Text = "Research1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btn_NewsCatch;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_NewsFilter;
        private Label label4;
        private Button btn_IntradayReturn;
        private Label label5;
        private Button btn_BingChat;
        private Label label6;
        private Button btn_Conclusion;
    }
}