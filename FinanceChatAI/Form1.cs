using BingChat;//需下載 dotnet add package --prerelease BingChat
using System;
using System.IO;
using System.Text;
using CsvHelper;//需下載 dotnet add package CsvHelper
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;
using CsvHelper.Configuration;
using System.Globalization;
using System.Threading;
using System.IO.Pipes;
namespace FinanceChatAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeAsync(); // ?用异步初始化方法
                               // 寫入 CSV 標題行

        }
        private async void InitializeAsync()
        {
            // 指定 CSV 檔案路徑
            string filePath = "news_answer.csv";
            string[] news_path = { "2330_1.csv","2330_2.csv","2330_3.csv","2330_4.csv","2330_5.csv",
                       "2330_6.csv","2330_7.csv","2330_8.csv","2330_9.csv","2330_10.csv",
                       "2330_11.csv","2330_12.csv" };
            string[] ans_path = { "ans_1.csv","ans_2.csv","ans_3.csv","ans_4.csv","ans_5.csv",
                       "ans_6.csv","ans_7.csv","ans_8.csv","ans_9.csv","ans_10.csv",
                       "ans_11.csv","ans_12.csv" };
            string news2330_2022 = "2330_2022.csv";
            using (StreamWriter writer = new StreamWriter(ans_path[8], false, Encoding.UTF8)) // 使用 UTF-8 編碼
            {
                writer.WriteLine("date,title, Y/N");
            }

            // 定義資料類別以匹配 CSV 檔案中的結構
            int num = 0;
            var records = new List<Dictionary<string, string>>();
            // 讀取 2330_2022.csv(or每個月) 檔案
            using (var reader = new StreamReader(news_path[8]))
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
                    textBox1.AppendText($"Date: {record["date"]}, Title: {record["title"]}\n");
                    //Console.WriteLine($"Date: {record["date"]}, Title: {record["title"]}");
                }
            }
            string cookieFilePath = "bing_cookies_myaccount.json";
            var client = new BingChatClient(new BingChatClientOptions
            {
                //如果你遇到可能不行一直問問題的情況，就需要連上cookie(cookie可能會於跳掉網頁後更新)
                //設置自己的 Cookie
                //您可以設置自己的 Cookie，以與 BingChat 伺服器互動，而不是隨機生成一個。
                //要獲取 Cookie，您可以前往 www.bing.com，登錄一個有權限的帳戶，然後打開開發人員工具（F12）> 應用程序標籤 > 存儲 > Cookies，在名為 "_U" 的 Cookie 中查找並複製其值。然後將其傳遞給 BingChatClientOptions 的構造函數。

                //CookieU = "1o499k1A7QHlmVyL9_N5TFly3djBOO1b50fNiRcSRQlhDVcBDOIHEAHQxwib3us4kF0dNcauIo4_sXbmVEfed682jowhjmA6YUcP6o6NUFxXzJWn-ikeNZNRqMNlbuYoziVlWj6rL_r6XjeP9bgSNeboLpyaMWfOXEdMuL_t9vxfsWvxHnf2Ijp06DcSReiVN8k0fUxy4TZ3f3X-wWR2Mjw1kbEcOKPysdT2Y-H1DQUY",
                // Tone used for conversation
                Tone = BingChatTone.Balanced,
                CookieFilePath = cookieFilePath
                //CookieKievRPSSecAuth = "FAByBBRaTOJILtFsMkpLVWSG6AN6C/svRwNmAAAEgAAACLpd12T3FdQBMATGoyc293Bh9nJ1mK2vpk+jh4Mp/YqXomqhViuTDv+R9WN7qJ2b1ac8aGalzFesGRcp0FtOSQOShMrXBV8KHAuWlG7IbiXU5j4zH8JyE25mM2ADiaCBoA11vsTFmz5LaaiB6ztra/2d3V7NvreyehurX/wdswwXTMxDEAmEPLX/wuuYmGDdldKZ4wAc6ZnCWS7RJpSoad9MezDKcGjCzlCg5u8vcVAZyrCH5mT3g3TItSNiDhc0rOM9mPrfBk7FsB4/Fgm5l21kiSLWVZH/uERzsBOLTtjcwa/Meo0y50eKNXLNpbHTQ2u9OwFv9x+196K5UKGjx12LPH3IrUPvsKAyfgLJy9gzIxrQSCz54Iwf142Jm4scalcGQTqMOlxSagYnJQdQhw4z/KeqVzgtR7KHCT0r49uK5PSh5oOLNkwOMjl2jwHhks3qsdyBtDmU0CL6iVqOMk1oE9wXOXh5eG2iT/jrEvyAe+pGEmv+lB73ItV9o3DCqqURZVZ3mfnlybp9rSGp06c0CAL4xdujVVuWlTbh7Hy2OIWeusOfjMpBpP+if1G9dK3tJRD9GF31PpkqOy2ZMsO4xIagyueF+dc6UTNCaDtxI5j1GwFxDUphzJuUwuHzDPCUJBqqsJjGK6Z8ojKOabKcy0mC+X1oE4LX++f//BN0Jr6V8zuHEx9CBZZSefQuyry2h9tPC47hYs/Qd96BZggDHTSnBHkX5FEVOo064qMdtkXFN1kbk977DqLKu1Bi/ossv7jOopkUZA8Idq0vRIv4c2KuXmy2w8Hb34w26HmpRzpJuBdw/ly4VVO0MpjT903E1wxSBRwr7096ZGU8d9B+TQXCa4nEjjmKXP3jAQtobl/fIKqPArxAmU5R4lO1eKnoR/6ROShGnwjh4ppsQYu5De1LxN0q9M/54rCbFvqMfHE5r5aKufLALoW3OAjBq6C1jZZ00Up1MvEHSxGDBy1TkhYn3bojwr+2OfA3soTG9ztYJpeJvYv0kDmMq+IIuFaVT/nE2+sQV6WmGlOIpDkQQaFMGimI4cIdgH+GJ/2lOEp94vS5SOHmR7OHguHNtAhDL9Vju2kl2jlTI7h0BjmYb7Ww/8IXC/OTEU6CiyN8/9Xp9OHlPdlkKFYOBpz6bfRjMNV+fqTG7vApa6t83ojPaxXj0GqPY+UofU/GsDAo4lgDP71vfFtdfCJV4FgGELhzfiu8BphgzWrVDjlSDojInCfmZoCa/Hcnelz7uxLSLD9YGJVjkNKpzh3rRaFVdnAUu0iSuIJDS+NPbOwcr1lNoZQHS+Q/Vd6sTZ7Gt8DPyy4gi3EA+YqO0yISjN/51CBPntXX92TdsXtt4A+wVZy0PPBcbBiaRWdqgfhPcr701cTN03Gt4BLwEXwFTZ3CfOn6ja+cE/oEvWOq4ReFpY0WJQVvt+xcA87/FACMMhx+6pwIko+H9pQ0/OvzMucbrg==",
            });
            //驗證captcha
            Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.bing.com/turing/captcha/challenge") { CreateNoWindow = true });
            Thread.Sleep(1000);
            int i = 0;
            //string[] t = { "年底確定來不及！台積電中科2奈米廠用地延至明年交地" , "慘？市場傳三度調降財測 台積電急重訊澄清" };
            string[] answer = new string[num];
            foreach (var record in records)
            {
                //假設你是一位財務專家而且您是一位具有股票推薦經驗的金融專家，如果以下新聞標題是好消息請只回答#yes，而如果是壞消息則只回答#no，如果不確定則只回答#unknown，然後於下一行用簡短的句子進行詳細說明，這個標題對公司股價是好還是壞呢? 而以下為要分析的新聞標題   
                var message = "假設你是一位財務專家而且您是一位具有股票推薦經驗的金融專家，如果以下新聞標題是好消息請只回答#yes，而如果是壞消息則只回答#no，如果不確定則只回答#unknown，然後於下一行用簡短的句子進行詳細說明，這個標題對公司股價是好還是壞呢? 而以下為要分析的新聞標題:" + record["title"];

                answer[i] = await client.AskAsync(message);

                textBox1.AppendText($"Answer: {answer[i]}\n");
                //Console.WriteLine($"Answer: {answer[i]}");

                string pattern = @"(#unknown|#no|#yes)";

                MatchCollection matches = Regex.Matches(answer[i], pattern);

                foreach (Match match in matches)
                {
                    string keywordText = match.Value;
                    // 寫入 CSV 資料行
                    using (StreamWriter writer = new StreamWriter(ans_path[8], true, Encoding.UTF8)) // 第二個參數為 true，表示追加模式
                    {
                        writer.WriteLine(record["date"] + "," + record["title"] + "," + keywordText);
                    }
                }

                i++;
            }

            // Create an instance of StreamWriter to write text to a file.
            // The using statement also closes the StreamWriter.
            using (StreamWriter sw = new StreamWriter("output.TXT"))   //小寫TXT     
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
        }
    }
}