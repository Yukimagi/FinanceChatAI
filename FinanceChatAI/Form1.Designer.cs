namespace FinanceChatAI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            btn_Research = new Button();
            btn_Forecast = new Button();
            btn_Ask = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(251, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(1421, 437);
            panel1.TabIndex = 1;
            // 
            // btn_Research
            // 
            btn_Research.BackColor = Color.FromArgb(255, 255, 128);
            btn_Research.Location = new Point(48, 132);
            btn_Research.Name = "btn_Research";
            btn_Research.Size = new Size(140, 62);
            btn_Research.TabIndex = 2;
            btn_Research.Text = "Research";
            btn_Research.UseVisualStyleBackColor = false;
            btn_Research.Click += btn_Research_Click;
            // 
            // btn_Forecast
            // 
            btn_Forecast.BackColor = Color.FromArgb(255, 255, 128);
            btn_Forecast.Location = new Point(48, 256);
            btn_Forecast.Name = "btn_Forecast";
            btn_Forecast.Size = new Size(140, 62);
            btn_Forecast.TabIndex = 3;
            btn_Forecast.Text = "Forecast";
            btn_Forecast.UseVisualStyleBackColor = false;
            btn_Forecast.Click += btn_Forecast_Click;
            // 
            // btn_Ask
            // 
            btn_Ask.BackColor = Color.FromArgb(255, 255, 128);
            btn_Ask.Location = new Point(48, 362);
            btn_Ask.Name = "btn_Ask";
            btn_Ask.Size = new Size(140, 62);
            btn_Ask.TabIndex = 4;
            btn_Ask.Text = "Ask";
            btn_Ask.UseVisualStyleBackColor = false;
            btn_Ask.Click += btn_Ask_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 255, 128);
            label1.Font = new Font("Microsoft JhengHei UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(48, 39);
            label1.Name = "label1";
            label1.Size = new Size(510, 50);
            label1.TabIndex = 5;
            label1.Text = "Finance Stock Forecast AI";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1731, 698);
            Controls.Add(label1);
            Controls.Add(btn_Ask);
            Controls.Add(btn_Forecast);
            Controls.Add(btn_Research);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button btn_Research;
        private Button btn_Forecast;
        private Button btn_Ask;
        private Label label1;
    }
}