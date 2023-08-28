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
            panel1 = new Panel();
            btn_Research = new Button();
            btn_Forecast = new Button();
            btn_Ask = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(160, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 457);
            panel1.TabIndex = 1;
            // 
            // btn_Research
            // 
            btn_Research.Location = new Point(14, 97);
            btn_Research.Name = "btn_Research";
            btn_Research.Size = new Size(140, 62);
            btn_Research.TabIndex = 2;
            btn_Research.Text = "Research";
            btn_Research.UseVisualStyleBackColor = true;
            btn_Research.Click += btn_Research_Click;
            // 
            // btn_Forecast
            // 
            btn_Forecast.Location = new Point(14, 183);
            btn_Forecast.Name = "btn_Forecast";
            btn_Forecast.Size = new Size(140, 62);
            btn_Forecast.TabIndex = 3;
            btn_Forecast.Text = "Forecast";
            btn_Forecast.UseVisualStyleBackColor = true;
            btn_Forecast.Click += btn_Forecast_Click;
            // 
            // btn_Ask
            // 
            btn_Ask.Location = new Point(12, 265);
            btn_Ask.Name = "btn_Ask";
            btn_Ask.Size = new Size(140, 62);
            btn_Ask.TabIndex = 4;
            btn_Ask.Text = "Ask";
            btn_Ask.UseVisualStyleBackColor = true;
            btn_Ask.Click += btn_Ask_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1253, 542);
            Controls.Add(btn_Ask);
            Controls.Add(btn_Forecast);
            Controls.Add(btn_Research);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btn_Research;
        private Button btn_Forecast;
        private Button btn_Ask;
    }
}