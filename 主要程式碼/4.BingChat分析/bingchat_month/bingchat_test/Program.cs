//測試後可以執行!
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

// 指定 CSV 檔案路徑
string filePath = "news_answer.csv";
string[] news_path = { "2330_1.csv","2330_2.csv","2330_3.csv","2330_4.csv","2330_5.csv",
                       "2330_6.csv","2330_7.csv","2330_8.csv","2330_9.csv","2330_10.csv",
                       "2330_11.csv","2330_12.csv" };
string[] ans_path = { "ans_1.csv","ans_2.csv","ans_3.csv","ans_4.csv","ans_5.csv",
                       "ans_6.csv","ans_7.csv","ans_8.csv","ans_9.csv","ans_10.csv",
                       "ans_11.csv","ans_12.csv" };


string news2330_2022 = "2330_2022.csv";

// 寫入 CSV 標題行
using (StreamWriter writer = new StreamWriter(ans_path[3], false, Encoding.UTF8)) // 使用 UTF-8 編碼
{
    writer.WriteLine("date,title, Y/N");
}


// 定義資料類別以匹配 CSV 檔案中的結構
int num = 0;
var records = new List<Dictionary<string, string>>();
// 讀取 2330_2022.csv(or每個月) 檔案
using (var reader = new StreamReader(news_path[3]))
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
        Console.WriteLine($"Date: {record["date"]}, Title: {record["title"]}");
    }
}
string cookieFilePath = "bingchat.json";
var client = new BingChatClient(new BingChatClientOptions
{
    //如果你遇到可能不行一直問問題的情況，就需要連上cookie(cookie可能會於跳掉網頁後更新)
    //設置自己的 Cookie
    //您可以設置自己的 Cookie，以與 BingChat 伺服器互動，而不是隨機生成一個。
    //要獲取 Cookie，您可以前往 www.bing.com，登錄一個有權限的帳戶，然後打開開發人員工具（F12）> 應用程序標籤 > 存儲 > Cookies，在名為 "_U" 的 Cookie 中查找並複製其值。然後將其傳遞給 BingChatClientOptions 的構造函數。

    CookieU = "_U",
    // Tone used for conversation
    Tone = BingChatTone.Balanced,
    //CookieFilePath = cookieFilePath
    CookieKievRPSSecAuth = "KievRPSSecAuth",
});
//驗證captcha
Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.bing.com/turing/captcha/challenge") { CreateNoWindow = true });
Thread.Sleep(1000);
int i = 0;
//string[] t = { "年底確定來不及！台積電中科2奈米廠用地延至明年交地" , "慘？市場傳三度調降財測 台積電急重訊澄清" };
string[] answer = new string[num];
foreach (var record in records)
{
    
    var message = "假設你是一位財務專家而且您是一位具有股票推薦經驗的金融專家，如果以下新聞標題是好消息請只回答#yes，而如果是壞消息則只回答#no，如果不確定則只回答#unknown，然後於下一行用簡短的句子進行詳細說明，這個標題對公司股價是好還是壞呢? 而以下為要分析的新聞標題:" + record["title"];
    
    answer[i] = await client.AskAsync(message);

    Console.WriteLine($"Answer: {answer[i]}");

    string pattern = @"(#unknown|#no|#yes)";

    MatchCollection matches = Regex.Matches(answer[i], pattern);

    foreach (Match match in matches)
    {
        string keywordText = match.Value;
        // 寫入 CSV 資料行
        using (StreamWriter writer = new StreamWriter(ans_path[3], true, Encoding.UTF8)) // 第二個參數為 true，表示追加模式
        {
            writer.WriteLine(record["date"]+","+record["title"] + ","+ keywordText);
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


















// ***Create a conversation, so we can continue chatting in the same context.

/*
var conversation = await client.CreateConversation();

var firstMessage = "Do you like cats?";
var answer = await conversation.AskAsync(firstMessage);
Console.WriteLine($"First answer: {answer}");

await Task.Delay(TimeSpan.FromSeconds(5));

var secondMessage = "What did I just say?";
answer = await conversation.AskAsync(secondMessage);
Console.WriteLine($"Second answer: {answer}");
*/