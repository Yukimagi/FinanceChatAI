using BingChat;
using CsvHelper.Configuration;
using CsvHelper;
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
using Microsoft.VisualBasic;//1.到“專案” → “加入參考(visualbasic” → “參考管理員”
                            //2.並最後using就可使用input box

namespace FinanceChatAI
{
    public partial class Research1 : Form
    {
        public Research1()
        {
            InitializeComponent();
            MessageBox.Show("請記得貼上您的www.bing.com的cookie path於bing_cookies_myaccount.json");
            //InitializeAsync(); // 用異步初始化方法
            MessageBox.Show("請注意是否有為自己的電腦裝好需要的python import檔~");
        }

        private void btn_NewsCatch_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("爬整年資料會耗時很久\n如果已有資料(預設是有的)請按否\n不要重跑!\n請問是否繼續?", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // 設定 Python 檔案的路徑
                string pythonScriptPath = "news_catch.py";

                // 設定 Python 執行器的路徑(自己去搜尋自己電腦的python.exe的路徑)
                string pythonInterpreter = "C:\\Users\\USER\\AppData\\Local\\Programs\\Python\\Python311\\python.exe";

                // 建立 ProcessStartInfo 物件來設定執行參數
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = pythonInterpreter;
                psi.Arguments = pythonScriptPath;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                // 執行 Python 腳本
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    process.WaitForExit();
                }
                MessageBox.Show("爬蟲新聞成功");
            }
        }

        private void btn_NewsFilter_Click(object sender, EventArgs e)
        {
                // 獲取輸入用戶的關鍵字和股票代號
                string keyword = Interaction.InputBox("輸入查詢的股票的台灣代稱(ex: 台積電)", "確定", "台積電", 50, 50);
                string stockCode = Interaction.InputBox("輸入股票代碼(ex: 2330)", "確定", "2330", 50, 50);


                string folderPath = keyword+"過濾新聞"; // 指定要创建的文件夹路径

                try
                {
                // 檢查文件夾是否已存在，如果不存在則創建它
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
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

                string pythonScriptPath = "news_filter.py";
                string pythonInterpreter = "C:\\Users\\USER\\AppData\\Local\\Programs\\Python\\Python311\\python.exe";

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = pythonInterpreter;
                psi.Arguments = $"{pythonScriptPath} \"{keyword}\" \"{stockCode}\""; // 将关键字和股票代号作为参数传递
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    process.WaitForExit();
                }
                MessageBox.Show("新聞過濾成功");

        }

        private void btn_IntradayReturn_Click(object sender, EventArgs e)
        {

            try
            {
                // 檢查文件夾是否已存在，如果不存在則創建它
                if (!Directory.Exists("Intraday return"))
                {
                    Directory.CreateDirectory("Intraday return");
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

            //此處的py檔有修改(應該會放在.exe同層)，如果您的資料夾沒有我提供的py檔，請向使用者索取
            string stockSymbol = Interaction.InputBox("輸入查詢的股票檔案(ex:2330.TW)\n詳情可搜尋yahoo finance", "確定", "2330.TW", 50, 50);//50,50視窗座標位置
            string pythonScriptPath = "Intraday_return.py";
            string pythonInterpreter = "C:\\Users\\USER\\AppData\\Local\\Programs\\Python\\Python311\\python.exe";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = pythonInterpreter;
            psi.Arguments = $"{pythonScriptPath} \"{stockSymbol}\""; // 傳遞關鍵字作為參數
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();
            }
            MessageBox.Show("Intraday return成功");
        }
        string month = "1";
        string stock="2330";
        string keyword2="台積電";

        void check()
        {
            if (0 < Convert.ToInt32(month) && Convert.ToInt32(month) < 13)
            {
                keyword2 = Interaction.InputBox("輸入查詢的股票的台灣代稱(ex: 台積電)", "確定", "台積電", 50, 50);
                stock = Interaction.InputBox("輸入股票代碼(ex: 2330)", "確定", "2330", 50, 50);
                DialogResult result=MessageBox.Show("請問是要查詢2023年"+month+"月的嗎\n如果是請按是\n如果是2022年請按否", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result== DialogResult.Yes)
                {
                    month = "23_" + month;
                }
                InitializeAsync(); // 用異步初始化方法
            }
            else
            {
                DialogResult result = MessageBox.Show("月份輸入錯誤，請重新輸入，或按取消已結束此動作", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    check();
                }
            }
        }
        private void btn_BingChat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bing chat聊天會耗時很久\n如果已有資料(預設是有的)請按否\n不要重跑!\n請問是否繼續?", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                month = Interaction.InputBox("請輸入月份(ex:1)", "確定", "1", 50, 50);//50,50視窗座標位置
                check();
            }
        }
        private async void InitializeAsync()
        {
            // 指定 CSV 檔案路徑

            int path = 10;

            int j = 0;

            try
            {
                // 檢查文件夾是否已存在，如果不存在則創建它
                if (!Directory.Exists(stock+"ans"))
                {
                    Directory.CreateDirectory(stock+"ans");
                    textBox1.Text=("資料夾建立成功！"+ Environment.NewLine);
                }
                else
                {
                    textBox1.Text = ("資料夾已存在。" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ($"資料夾建立時發生錯誤：{ex.Message}" + Environment.NewLine);
            }

            // 寫入 CSV 標題行
            using (StreamWriter writer = new StreamWriter(stock + "ans" + "/" + stock+"ans_"+month+".csv", false, Encoding.UTF8)) // 使用 UTF-8 編碼
            {
                writer.WriteLine("date,title, Y/N");
            }


            // 定義資料類別以匹配 CSV 檔案中的結構
            int num = 0;
            var records = new List<Dictionary<string, string>>();
            // 讀取 2330_2022.csv(or每個月) 檔案
            using (var reader = new StreamReader(keyword2+"過濾新聞" + "/" + stock + "_" + month + ".csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read(); // 讀取第一行作為欄位標題
                csv.ReadHeader(); // 將第一行設定為欄位標題

                // 將 news_1.csv 檔案中的資料讀取為字典列表
                //var records = new List<Dictionary<string, string>>();
                while (csv.Read())
                {
                    var record = new Dictionary<string, string>();
                    foreach (var header in csv.HeaderRecord)
                    {
                        record[header] = csv.GetField(header);
                    }
                    records.Add(record);
                    num++;
                }

                // 處理字典列表中的資料
                foreach (var record in records)
                {
                    textBox1.AppendText($"Date: {record["date"]}, Title: {record["title"]}\n" + Environment.NewLine);
                }
            }
            string cookieFilePath = "bing_cookies_myaccount.json";
            var client = new BingChatClient(new BingChatClientOptions
            {
                //如果你遇到可能不行一直問問題的情況，就需要連上cookie(cookie可能會於跳掉網頁後更新)
                //設置自己的 Cookie
                //您可以設置自己的 Cookie，以與 BingChat 伺服器互動，而不是隨機生成一個。
                //要獲取 Cookie，您可以前往 www.bing.com，登錄一個有權限的帳戶，然後打開開發人員工具（F12）> 應用程序標籤 > 存儲 > Cookies，在名為 "_U" 的 Cookie 中查找並複製其值。然後將其傳遞給 BingChatClientOptions 的構造函數。

                //CookieU = "1tYxbaSS8z-IlvNPYq_6q5B5qGLDX0s-D9Wiv45lfbuLCVazbtsK6N8lm-ABNU752-xG1F0L9OmCItsuW76KnBUNXKk4LmZLxk720nQQAnHcGv7SNCmPcW8Bso1v47VXI4_QVZyO1wQIvpWYlum8xUQ4fuFwgg2pzr_m82kKUYA8AdkW3fJ9kNGIo9ZNzLIELc33UHIdzZC58-9lV0nOTEDoP7-6MOjuAaWYJ2Z8EBZM",
                // Tone used for conversation
                Tone = BingChatTone.Creative,
                CookieFilePath = cookieFilePath
                //CookieKievRPSSecAuth = "FABiBBRaTOJILtFsMkpLVWSG6AN6C/svRwNmAAAEgAAACK8zGycxlLSLIAQeaSBcLEynl9RchnVMDkPGkHr1OPttubdB3kSey7ApMwV9zgBJOFXhah9KNOUFEjvulHFUqnMvzLg14yKiT3ydkg6T50a0fgdbNZlcQvBrc7vdnD3XBwmeZmAHbl75mSSD7H9Au0awEaWfjgKOuMhRqiK4HpFcYCt4YTWDeH0J9CppvW7LuoqyOYVu7BlR/8LJYdJOGobA790nl2DA0aaaB98TQ/NiVIX/z2AgIlkDhzThide0aqvTLGLVVWim6Up/NybYe6qvwcFJ8kGQou0tHtwl0FP5TqZVvr3qBT5MUR3v4om1LcZ1clDtbnJgGz/l3BeCaYSlMYOIF+d7FRWerVMyift/55TOQS11XcYIizsl8M2ePXmve4mknA1mTVbGkADrXZe8V5yYT7cCq1dsU3wak4giCa+Mj/sHBPXfGUmueh3d4AZo0+rbRF4zyJDhQhkrbJ67TB9ZOWo3E4vUVq11LRZvE0dimbk9ONGLpUo1eAW2WwGE8bwQ05y5OnBtwaJagJ4QoJNOYT3wFIazxlU5dz9Ag/DTwNoqhLimMcGR+e/0sHYXVdKo4PYf9m8ISkfcXwceNJykQvuapCKFq7WeyiFRCD+MxXkiW//Y6HSVl1Uii2kz09eX+vl+O7oI6WmZfH+uC4MdJTsG04swQnmejfu6ANdVF8IqjPVW5BkNNLNKqlwbpNocKrLcXficvMFZTp548OJKijOfoFLong9uJ8eIv3bsfL9U4+eZBw+VH1Lvih08J7A5DlEXSp9YQIzRBTf10H8nAd+sM7mX8jJVoO3/clHiA6q4/5z2btXTDb9EWtBbsTajkC+kkDvEUUDlkB7jD0PUNTlU5SlpbqLQAySULLIiOr1WtOWU/GfmrLyFTdmyvvrANVLRch+cZVd7d5VV/PfcL8efZGoVru3sIKSqZVOr0W64fxo4+Tw2H2fcI8Gi9CcOfWz69DshlLRJFyNj+Dvx6S67Rca8wukhpuFtxCey0nB4w512MX4vJ5mNxLQPkHTvCSMfXG3WnzBA3duVuaHJtE0zRuM+TZ4QChhDIUZoewW3C+lgcSdVYd7vYgDWP+r9XE1D5Tv+Ela4xAxfEhPRxkcl4PsMNJLuN43Qb+3S6Dv5daKocEuT/vNzNQkhwfRqp+XjJQDgwgBTJLltMeaPgM7+vH63s9qxMa6O+4b6XL/mKh/Vo4yDpBDSaxpeFN2do2odJyviaNWQThTDvbebbyaWDmnHsNj7qDS8q8uMDq6AcUziaFUaF4Gt1nsnqwnbh8S+mguz3gcFyR26USbHxjBK3zRv6GSSD9Rf0q3zP6u98Chd9CqHF/XW+jwbXV/AbUaCgSHEPvkIk5W+5rT8pYtoCIBYcmJQm7tKI61eQPUrkakNwLsISX/7DWK4t2dXzhIg0BYUAEsFP4wWc35d7no1byYUGgxBc12Z",
            });
            //驗證captcha
            Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.bing.com/turing/captcha/challenge") { CreateNoWindow = true });
            Thread.Sleep(1000);
            int i = 0;
            //string[] t = { "年底確定來不及！台積電中科2奈米廠用地延至明年交地" , "慘？市場傳三度調降財測 台積電急重訊澄清" };
            string[] answer = new string[num];
            foreach (var record in records)
            {
                //Create a conversation, so we can continue chatting in the same context.
                //var conversation = await client.CreateConversation();

                //var firstMessage = "請你先查詢股票" + keyword[1] + "於"+ record["date"] + "前5日內均線為漲還是跌?";
                //answer[i] = await conversation.AskAsync(firstMessage);
                //Console.WriteLine($"First answer: {answer[i]}");

                //await Task.Delay(TimeSpan.FromSeconds(1));

                //假設你是一位財務專家而且您是一位具有股票推薦經驗的金融專家，如果以下新聞標題是好消息請只回答#yes，而如果是壞消息則只回答#no，如果不確定則只回答#unknown，然後於下一行用簡短的句子進行詳細說明，這個標題對公司股價是好還是壞呢? 而以下為要分析的新聞標題   
                //"請您拿" + record["date"] + "當下前5日內台積電的均線漲跌進行分析為漲還是跌，接著對以下新聞標題與其5日均線之漲跌經過綜合分析，並請考慮到當沖要獲利的話，必須價差至少超過股價的 0.15％才能獲利，那麼這個標題對公司隔日股票當沖是好(會賺錢)還是壞(不會賺錢)，接著請注意回答重點是:如果隔日股票會漲(會賺錢)請只回答#yes，而如果隔日股票會跌(不會賺錢)則只回答#no，如果不確定則只回答#unknown，請盡可能的不要回答#unknown，然後於下一行用簡短的句子進行詳細說明， 而以下為要分析的新聞標題:" + record["title"];
                var secondMessage = "請您拿" + record["date"] + "當下前5日內" + keyword2 + "的均線漲跌進行分析為漲還是跌，接著對以下新聞標題與其5日均線之漲跌經過綜合分析，並請考慮到當沖要獲利的話，必須價差超過股價的 0.435％才能獲利，那麼這個標題對公司隔日股票當沖是好(會賺錢)還是壞(不會賺錢)，接著請注意回答重點是:如果隔日股票會漲(會賺錢)請只回答#yes，而如果隔日股票會跌(不會賺錢)則只回答#no，如果不確定則只回答#unknown，請盡可能的不要回答#unknown，然後於下一行用簡短的句子進行詳細說明， 而以下為要分析的新聞標題:" + record["title"];

                answer[i] = await client.AskAsync(secondMessage);

                textBox1.AppendText($"answer: {answer[i]}\n" + Environment.NewLine + Environment.NewLine);

                string pattern = @"(#unknown|#no|#yes)";

                MatchCollection matches = Regex.Matches(answer[i], pattern);

                foreach (Match match in matches)
                {
                    string keywordText = match.Value;
                    // 寫入 CSV 資料行
                    using (StreamWriter writer = new StreamWriter(stock + "ans" + "/" + stock + "ans_" + month + ".csv", true, Encoding.UTF8)) // 第二個參數為 true，表示追加模式
                    {
                        writer.WriteLine(record["date"] + "," + record["title"] + "," + keywordText);
                    }
                }

                i++;
            }

            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            using (StreamWriter sw = new StreamWriter(stock + "ans" + "/" +"output_"+ stock + "ans_" + month + ".TXT"))   //小寫TXT     
            {
                i = 0;
                foreach (var record in records)
                {
                    // Add some text to the file.
                    sw.WriteLine(record["date"]);
                    sw.WriteLine(record["title"]);
                    sw.WriteLine(answer[i]);
                    // Arbitrary objects can also be written to the file.
                    //sw.Write("The date is: ");
                    //sw.WriteLine(DateTime.Now);
                    i++;
                }
            }
            MessageBox.Show("Bing Chat回答完成!" + Environment.NewLine);
        }

        private void btn_Conclusion_Click(object sender, EventArgs e)
        {
            //此處的py檔有修改(應該會放在.exe同層)，如果您的資料夾沒有我提供的py檔，請向使用者索取
            string stockSymbol = Interaction.InputBox("請輸入股票代號(ex:2330)", "確定", "2330", 50, 50);//50,50視窗座標位置

            try
            {
                // 檢查文件夾是否已存在，如果不存在則創建它
                if (!Directory.Exists(stockSymbol + "_conclusion"))
                {
                    Directory.CreateDirectory(stockSymbol + "_conclusion");
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

            string pythonScriptPath = "Conclusion.py";
            string pythonInterpreter = "C:\\Users\\USER\\AppData\\Local\\Programs\\Python\\Python311\\python.exe";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = pythonInterpreter;
            psi.Arguments = $"{pythonScriptPath} \"{stockSymbol}\""; // 傳遞股票代號作為參數
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true; // 捕獲輸出
            psi.CreateNoWindow = true;

            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();

                // 捕獲 Python 腳本的輸出
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                string averageConclusionText2 = "總獲利期望值：";
                int index2 = output.IndexOf(averageConclusionText2);
                if (index2 != -1)
                {
                    string profitValue = output.Substring(index2 + averageConclusionText2.Length);
                    MessageBox.Show($"總獲利期望值：{profitValue}元");
                }
            }
            MessageBox.Show("結論已產生!");
        }
    }
}
