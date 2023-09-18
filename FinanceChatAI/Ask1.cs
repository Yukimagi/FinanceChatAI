using BingChat;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceChatAI
{
    public partial class Ask1 : Form
    {
        private List<string> newsTitles = new List<string>();
        public Ask1()
        {
            InitializeComponent();
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            pictureBox1_ask.Visible = false;
            re_button.Enabled = false;
            re_button.Visible = false;
            start_button.Enabled = true;
            start_button.Visible = true;
            ans_textBox.Visible = false;
            ans_textBox.Text = "";
            newsTitles.Clear();
            title_listBox.Items.Clear();
            MessageBox.Show("請記得貼上您的www.bing.com的cookie path於bing_cookies_myaccount.json");
            try
            {
                // 檢查文件夾是否已存在，如果不存在則創建它
                if (!Directory.Exists("ask"))
                {
                    Directory.CreateDirectory("ask");
                    Console.WriteLine("資料夾建立成功！");
                }
                else
                {
                    Console.WriteLine("資料夾已存在。");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"資料夾建立時發生錯誤：{ex.Message}");
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            string inputTitle = title_textBox.Text.Trim();
            if (!string.IsNullOrEmpty(inputTitle))
            {
                newsTitles.Add(inputTitle);
                title_listBox.Items.Add(inputTitle);
                title_textBox.Clear();
            }
        }
        string keyword = "台積電";
        string date;
        private void start_button_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;

            // 获取日期
            DateTime selectedDate = selectedDateTime.Date;
            date = selectedDate.ToString("yyyy-MM-dd");
            ans_textBox.Text = date;
            keyword = Interaction.InputBox("輸入查詢的股票(ex: 台積電)", "確定", "台積電", 50, 50);//50,50視窗座標位置
            DialogResult result = MessageBox.Show("Bing chat聊天會耗時很久\n如果已有資料(預設是有的)請按否\n不要重跑!\n請問是否繼續?", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                InitializeAsync(); // 用異步初始化方法
                start_button.Enabled = false;
                start_button.Visible = false;
               
            }
        }


        private async void InitializeAsync()
        {
            ans_textBox.Visible = true;
            start_button.Enabled = false;
            start_button.Visible = false;
            label1.Visible = false;
            dateTimePicker1.Visible = false;
            label2.Visible = false;
            add_button.Visible = false;
            title_textBox.Visible = false;
            label3.Visible = false;
            start_button.Visible = false;
            title_listBox.Visible = false;
            label7.Visible = true;
            pictureBox1_ask.Visible = true;

            // 指定 CSV 檔案路徑
            string ans_path = "ask/ans_ask.csv";

            using (StreamWriter writer = new StreamWriter(ans_path, false, Encoding.UTF8)) // 使用 UTF-8 編碼
            {
                writer.WriteLine("date,title, Y/N");
            }

            // 定義資料類別以匹配 CSV 檔案中的結構


            string cookieFilePath = "bing_cookies_myaccount.json";
            var client = new BingChatClient(new BingChatClientOptions
            {
                //如果你遇到可能不行一直問問題的情況，就需要連上cookie(cookie可能會於跳掉網頁後更新)
                //設置自己的 Cookie
                //您可以設置自己的 Cookie，以與 BingChat 伺服器互動，而不是隨機生成一個。
                //要獲取 Cookie，您可以前往 www.bing.com，登錄一個有權限的帳戶，然後打開開發人員工具（F12）> 應用程序標籤 > 存儲 > Cookies，在名為 "_U" 的 Cookie 中查找並複製其值。然後將其傳遞給 BingChatClientOptions 的構造函數。

                //CookieU = "1o499k1A7QHlmVyL9_N5TFly3djBOO1b50fNiRcSRQlhDVcBDOIHEAHQxwib3us4kF0dNcauIo4_sXbmVEfed682jowhjmA6YUcP6o6NUFxXzJWn-ikeNZNRqMNlbuYoziVlWj6rL_r6XjeP9bgSNeboLpyaMWfOXEdMuL_t9vxfsWvxHnf2Ijp06DcSReiVN8k0fUxy4TZ3f3X-wWR2Mjw1kbEcOKPysdT2Y-H1DQUY",
                // Tone used for conversation
                Tone = BingChatTone.Creative,
                CookieFilePath = cookieFilePath
                //CookieKievRPSSecAuth = "FAByBBRaTOJILtFsMkpLVWSG6AN6C/svRwNmAAAEgAAACLpd12T3FdQBMATGoyc293Bh9nJ1mK2vpk+jh4Mp/YqXomqhViuTDv+R9WN7qJ2b1ac8aGalzFesGRcp0FtOSQOShMrXBV8KHAuWlG7IbiXU5j4zH8JyE25mM2ADiaCBoA11vsTFmz5LaaiB6ztra/2d3V7NvreyehurX/wdswwXTMxDEAmEPLX/wuuYmGDdldKZ4wAc6ZnCWS7RJpSoad9MezDKcGjCzlCg5u8vcVAZyrCH5mT3g3TItSNiDhc0rOM9mPrfBk7FsB4/Fgm5l21kiSLWVZH/uERzsBOLTtjcwa/Meo0y50eKNXLNpbHTQ2u9OwFv9x+196K5UKGjx12LPH3IrUPvsKAyfgLJy9gzIxrQSCz54Iwf142Jm4scalcGQTqMOlxSagYnJQdQhw4z/KeqVzgtR7KHCT0r49uK5PSh5oOLNkwOMjl2jwHhks3qsdyBtDmU0CL6iVqOMk1oE9wXOXh5eG2iT/jrEvyAe+pGEmv+lB73ItV9o3DCqqURZVZ3mfnlybp9rSGp06c0CAL4xdujVVuWlTbh7Hy2OIWeusOfjMpBpP+if1G9dK3tJRD9GF31PpkqOy2ZMsO4xIagyueF+dc6UTNCaDtxI5j1GwFxDUphzJuUwuHzDPCUJBqqsJjGK6Z8ojKOabKcy0mC+X1oE4LX++f//BN0Jr6V8zuHEx9CBZZSefQuyry2h9tPC47hYs/Qd96BZggDHTSnBHkX5FEVOo064qMdtkXFN1kbk977DqLKu1Bi/ossv7jOopkUZA8Idq0vRIv4c2KuXmy2w8Hb34w26HmpRzpJuBdw/ly4VVO0MpjT903E1wxSBRwr7096ZGU8d9B+TQXCa4nEjjmKXP3jAQtobl/fIKqPArxAmU5R4lO1eKnoR/6ROShGnwjh4ppsQYu5De1LxN0q9M/54rCbFvqMfHE5r5aKufLALoW3OAjBq6C1jZZ00Up1MvEHSxGDBy1TkhYn3bojwr+2OfA3soTG9ztYJpeJvYv0kDmMq+IIuFaVT/nE2+sQV6WmGlOIpDkQQaFMGimI4cIdgH+GJ/2lOEp94vS5SOHmR7OHguHNtAhDL9Vju2kl2jlTI7h0BjmYb7Ww/8IXC/OTEU6CiyN8/9Xp9OHlPdlkKFYOBpz6bfRjMNV+fqTG7vApa6t83ojPaxXj0GqPY+UofU/GsDAo4lgDP71vfFtdfCJV4FgGELhzfiu8BphgzWrVDjlSDojInCfmZoCa/Hcnelz7uxLSLD9YGJVjkNKpzh3rRaFVdnAUu0iSuIJDS+NPbOwcr1lNoZQHS+Q/Vd6sTZ7Gt8DPyy4gi3EA+YqO0yISjN/51CBPntXX92TdsXtt4A+wVZy0PPBcbBiaRWdqgfhPcr701cTN03Gt4BLwEXwFTZ3CfOn6ja+cE/oEvWOq4ReFpY0WJQVvt+xcA87/FACMMhx+6pwIko+H9pQ0/OvzMucbrg==",
            });
            //驗證captcha
            Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.bing.com/turing/captcha/challenge") { CreateNoWindow = true });
            Thread.Sleep(1000);
            int i = 0;
            //string[] t = { "年底確定來不及！台積電中科2奈米廠用地延至明年交地" , "慘？市場傳三度調降財測 台積電急重訊澄清" };
            string[] answer = new string[newsTitles.Count];
            foreach (var record in newsTitles)
            {
                string keyword2 = keyword;
                //假設你是一位財務專家而且您是一位具有股票推薦經驗的金融專家，如果以下新聞標題是好消息請只回答#yes，而如果是壞消息則只回答#no，如果不確定則只回答#unknown，然後於下一行用簡短的句子進行詳細說明，這個標題對公司股價是好還是壞呢? 而以下為要分析的新聞標題   
                var message = "請您拿" + date + "當下前5日內" + keyword2 + "的均線漲跌進行分析為漲還是跌，接著對以下新聞標題與其5日均線之漲跌經過綜合分析，並請考慮到當沖要獲利的話，必須價差超過股價的 0.435％才能獲利，那麼這個標題對公司隔日股票當沖是好(會賺錢)還是壞(不會賺錢)，接著請注意回答重點是:如果隔日股票會漲(會賺錢)請只回答#yes，而如果隔日股票會跌(不會賺錢)則只回答#no，如果不確定則只回答#unknown，請盡可能的不要回答#unknown，然後於下一行用簡短的句子進行詳細說明， 而以下為要分析的新聞標題:" + record;
                ans_textBox.AppendText(message + Environment.NewLine + Environment.NewLine);

                answer[i] = await client.AskAsync(message);

                ans_textBox.AppendText($"Answer: {answer[i]}" + Environment.NewLine + Environment.NewLine);
                //Console.WriteLine($"Answer: {answer[i]}");

                string pattern = @"(#unknown|#no|#yes)";

                MatchCollection matches = Regex.Matches(answer[i], pattern);

                foreach (Match match in matches)
                {
                    string keywordText = match.Value;
                    // 寫入 CSV 資料行
                    using (StreamWriter writer = new StreamWriter(ans_path, true, Encoding.UTF8)) // 第二個參數為 true，表示追加模式
                    {
                        writer.WriteLine(date + "," + record + "," + keywordText);
                    }
                }

                i++;
            }

            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            using (StreamWriter sw = new StreamWriter("ask/output_ask.TXT"))   //小寫TXT     
            {
                i = 0;
                foreach (var record in newsTitles)
                {
                    // Add some text to the file.
                    sw.WriteLine(date);
                    sw.WriteLine(record);
                    sw.WriteLine(answer[i]);
                    // Arbitrary objects can also be written to the file.
                    //sw.Write("The date is: ");
                    //sw.WriteLine(DateTime.Now);
                    i++;
                }
            }

            conclusion();
        }
        void conclusion()
        {

            //此處的py檔有修改(應該會放在.exe同層)，如果您的資料夾沒有我提供的py檔，請向使用者索取
            string stockSymbol = Interaction.InputBox("請輸入股票代號(ex:2330)", "確定", "2330", 50, 50);//50,50視窗座標位置
            string pythonScriptPath = "Conclusion_ask.py";
            string pythonInterpreter = "C:\\Users\\USER\\AppData\\Local\\Programs\\Python\\Python311\\python.exe";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = pythonInterpreter;
            psi.Arguments = $"{pythonScriptPath} \"{stockSymbol}\""; // 傳遞股票代號作為參數
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true; // 捕獲輸出
            psi.CreateNoWindow = true;
            label7.Visible = false;
            pictureBox1_ask.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();

                // 捕獲 Python 腳本的輸出
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // 從輸出中解析平均結論值
                string averageConclusionText = "平均結論值：";
                int index = output.IndexOf(averageConclusionText);
                if (index != -1)
                {
                    string averageValue = output.Substring(index + averageConclusionText.Length);
                    label6.Text = (averageValue);
                    label8.Visible = true;
                }
            }
            re_button.Visible = true;
            re_button.Enabled = true;
        }

        private void re_button_Click(object sender, EventArgs e)
        {

            start_button.Enabled = true;
            start_button.Visible = true;
            label1.Visible = true;
            dateTimePicker1.Visible = true;
            label2.Visible = true;
            add_button.Visible = true;
            title_textBox.Visible = true;
            label3.Visible = true;
            start_button.Visible = true;
            title_listBox.Visible = true;

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            pictureBox1_ask.Visible = false;
            re_button.Enabled = false;
            re_button.Visible = false;
            start_button.Enabled = true;
            start_button.Visible = true;
            ans_textBox.Visible = false;
            MessageBox.Show("請記得貼上您的www.bing.com的cookie path於bing_cookies_myaccount.json");
            try
            {
                // 檢查文件夾是否已存在，如果不存在則創建它
                if (!Directory.Exists("ask"))
                {
                    Directory.CreateDirectory("ask");
                    Console.WriteLine("資料夾建立成功！");
                }
                else
                {
                    Console.WriteLine("資料夾已存在。");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"資料夾建立時發生錯誤：{ex.Message}");
            }
            ans_textBox.Text = "";
            newsTitles.Clear();
            title_listBox.Items.Clear();
        }
    }
}
