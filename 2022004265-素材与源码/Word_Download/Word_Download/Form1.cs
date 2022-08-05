using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace Word_Download
{
    public partial class Form1 : Form
    {
        public static string[] word_list = new string[12655];
        public static string[] meaning_list = new string[12655];
        public static string[] sentences_list = new string[12655];
        public static string[] pronun_list = new string[12655];
        public static int dic = 0;
        public static int[] pages = {0, 292, 402, 440, 199, 274, 244, 227, 375 };
        public static int[] word_count = { 0, 5818, 8003, 8713, 12655, 5467, 4866, 4523, 7485 };
        public static int quan; 

        /* dic代表爬取不同的词典
        case 1:pages = 292;break;  //四级词汇共292页
                case 2:pages = 402;break;  //六级词汇共402页
                case 3:pages = 443;break;  //专业四级共440页
                case 4:pages = 199;break;  //专业八级共199页（此外还包括专业四级所有词汇）
                case 5:pages = 274;break;  //考研词汇共274页
                case 6:pages = 244;break;  //托福词汇共244页
                case 7:pages = 227;break;  //雅思词汇共227页
                case 8:pages = 375;break;  //GRE词汇共375页
        */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dic = 8;
            ThreadPool.SetMaxThreads(22, 22);
            for (int i = 0; i < 22; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getWordList), i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqliteManager manager = new SqliteManager();
            manager.importWord(word_list);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqliteManager manager = new SqliteManager();
            quan = manager.exportWord(word_list);
            getMeaningSentencesList(1);
            ThreadPool.SetMaxThreads(20, 20);
            for (int i = 0; i < 20; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getMeaningSentencesList), i);
            }          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqliteManager manager = new SqliteManager();
            manager.importMeaning(meaning_list, word_list);
            manager.importSentences(sentences_list, word_list);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqliteManager manager = new SqliteManager();
            quan = manager.exportWord(word_list);
   
            ThreadPool.SetMaxThreads(20, 20);
            for (int i = 0; i < 20; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getPronunciation), i);
            }           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqliteManager manager = new SqliteManager();
            manager.importPronunciation(pronun_list, word_list);
        }

        private void getWordList(object i)   
        {
            this.Invoke(new Action(() =>
            {
                int cnt;   //单词计数
                string url;  
                int begin_page = int.Parse(i.ToString()) * 20;   //本次爬取起始页编号
                if (dic == 0)
                    return;
                for (int j = begin_page; j < pages[dic] && j < begin_page + 20; j++)   //每个线程爬取20页词汇  
                {
                    url = string.Format("https://www.quword.com/ciku/id_{0}_0_0_0_{1}.html", dic, j);
                    StreamReader sr = new StreamReader(Download.DownloadFile(url));
                    string html = sr.ReadToEnd();
                    MatchCollection words = Regex.Matches(html, @"/w/[a-zA-Z]+");   //正则表达式匹配词汇
                    cnt = 0;
                    foreach (Match word in words)
                    {
                        word_list[j * 20 + cnt] = word.ToString().Substring(3);    //存储词汇内容
                        cnt++;
                    }
                }
            }));
        }

        private void getMeaningSentencesList(object i)
        {
            this.Invoke(new Action(() =>
            {
                string url;
                int begin_word = int.Parse(i.ToString()) * 25 + 7000 ;  //爬取起始单词数-1，如从第337个单词开始爬取则该数字为336
                for (int j = begin_word; j < quan && j < begin_word + 25; j++)
                {
                    url = string.Format("https://www.quword.com/w/{0}", word_list[j]);
                    StreamReader sr = new StreamReader(Download.DownloadFile(url));
                    string html = sr.ReadToEnd();

                    //正则表达式匹配单词释义
                    MatchCollection meanings = Regex.Matches(html, @"<li>((n.)|(v.)|(adj.)|(adv.)|(conj.)|(pron.)|(prep.)|(int.)|(abbr.)|(num.)|(art.))+[a-zA-Z,.;；·：:，—!！?？%、\-""“”\u4e00-\u9fa5();\s\[\]（）()$￥…]+");
                    foreach (Match match1 in meanings)
                    {
                        meaning_list[j] += match1.ToString().Substring(4) + "|";   //存储词汇释义
                    }

                    //正则表达式匹配例句及其释义
                    MatchCollection sentences = Regex.Matches(html, @"<dl><dt>[(1)||(2)]+[\u4e00-\u9fa5().,！!？?;\sa-zA-Z0-9'：:，—%、·；\-""“”<>/()（）$￥…]+");
                    foreach (Match match2 in sentences)
                    {
                        string sen = match2.ToString().Replace("<b>","").Replace("</b>", "").Replace("</dt>", "").Replace("<dd>", "").Replace("</dd>", "").Replace("'", "''").Replace("“", "").Replace("”", "").Replace("\"", "").Replace("<p>来自", "");//单引号替换为双引号以实现sql语句转义
                        sentences_list[j] += sen.ToString().Substring(11) + "|";   //存储例句及其释义内容
                    }
                }
            }));
        }

        private void getPronunciation(object i)
        {
            this.Invoke(new Action(() =>
            {
                string url;
                int begin_word = int.Parse(i.ToString()) * 25 + 12453;  //爬取起始单词数-1，如从第337个单词开始爬取则该数字为336
                for (int j = begin_word; j < quan && j < begin_word + 25; j++)   //每个线程爬取25个
                {
                    url = string.Format("https://www.quword.com/w/{0}", word_list[j]);
                    StreamReader sr = new StreamReader(Download.DownloadFile(url));
                    string html = sr.ReadToEnd();

                    //正则表达式匹配音标
                    MatchCollection pronuns = Regex.Matches(html, @"([英美]{1}[\s]{1}[\[]{1}[^(\n)^<]+)|(\[,[^(\n)^<]+)");
                    foreach (Match match in pronuns)
                    {
                        pronun_list[j] += match.ToString().Replace("'", "''") + "|";   //存储音标
                    }
                }
            }));
        }
    }
}
