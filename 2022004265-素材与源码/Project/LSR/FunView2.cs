using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraBars.Docking2010;
using System.Threading;
using System.Reflection;
using System.Media;
using System.Runtime.InteropServices;

namespace LSR
{
    public partial class FunView2 : DevExpress.XtraEditors.XtraUserControl
    {
        private SqliteManager manager;
        private SQLiteDataReader reader;
        private string current_word;
        private int current_index = -1;
        private myWord[] showords = new myWord[1024];
        private myWord[] unwords = new myWord[1024];
        private int read_count = -1;
        private int un_length = 0;
        private int un_count = 0;
        private WindowsUIButtonPanel btn_panel;
        private LabelControl label_2_showonly;
        private int upper_limit = 0;

        public FunView2(SqliteManager main_manager)
        {
            InitializeComponent();
            manager = main_manager;
        }

        private void FunView2_Load(object sender, EventArgs e)
        {
            btn_panel = (WindowsUIButtonPanel)this.webButton1.Controls[0];
            label_2_showonly = (LabelControl)this.webButton1.Controls[1];
            btn_panel.ButtonClick += windowsUIButtonPanel1_ButtonClick;
            reader = manager.getReviewedReader();
            //reader = manager.GetWordDataReader(1);
            if (reader.HasRows)
            {
                dataLayoutControl1.Visible = true;
                webButton1.Visible = true;
                label_sentence_EN_2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                label_sentence_EN_2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;

                SQLiteDataReader info = manager.getInfo();
                info.Read();
                int daily = int.Parse(info["EveryDaySetQuan"].ToString());
                int lowestP =int.Parse(info["LowestPercent"].ToString());
                upper_limit = (daily * (100 - lowestP)) / 100;
                getNextWord();
            }
            else
            {
                noRecitedWords();
            }
            //for(int i = 0; i < this.layoutControlGroup1.Items.Count; i++)
            //{
            //    Console.WriteLine(this.layoutControlGroup1.Items[i].Name);
            //}
        }

        private void noRecitedWords()
        {
            label_word.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            label_meaning.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            webButton1.Visible = false;
            tileBarGroup2.Visible = false;
            label_1_showonly.Text = " ";
            label_sentence_EN_1.Text = " ";
            label_sentence_EN_2.Text = " ";
            label_sentence_EN_3.Text = " ";
            label_sentence_CN_1.Text = "没有要复习的单词哦~";
            label_sentence_CN_1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label_sentence_CN_1.AppearanceItemCaption.ForeColor = System.Drawing.Color.DarkSeaGreen;
            label_sentence_CN_2.Text = " ";
            label_sentence_CN_3.Text = " ";
        }

        private void wordsOver()
        {
            label_word.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            label_meaning.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            webButton1.Visible = false;
            tileBarGroup2.Visible = false;
            label_1_showonly.Text = " ";
            label_sentence_EN_1.Text = " ";
            label_sentence_EN_2.Text = " ";
            label_sentence_EN_3.Text = " ";
            label_sentence_CN_1.Text = "单词背完了哦~";
            label_sentence_CN_1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label_sentence_CN_1.AppearanceItemCaption.ForeColor = System.Drawing.Color.DarkSeaGreen;
            label_sentence_CN_2.Text = " ";
            label_sentence_CN_3.Text = " ";
        }

        private void getNextWord()
        {
            if (label_back.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never && current_index > 0)
            {
                label_back.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            current_index++;
            if (showords[current_index] == null)
            {
                if (read_count == upper_limit || !reader.Read())
                {
                    if (un_count < un_length)
                    {
                        showords[current_index] = unwords[un_count];
                        un_count++;
                        current_word = showords[current_index].word;
                        updateScreen(current_word);
                    }
                    else
                    {
                        wordsOver();
                        return;
                    }
                }
                else
                {
                    bool empty_flag = false;
                    while (!notTooEarly())
                    {
                        if (!reader.Read())
                        {
                            empty_flag = true;
                            break;
                        }
                    }
                    if(empty_flag)
                    {
                        if (read_count == upper_limit || !reader.Read())
                        {
                            if (un_count < un_length)
                            {
                                showords[current_index] = unwords[un_count];
                                un_count++;
                                current_word = showords[current_index].word;
                                updateScreen(current_word);
                            }
                            else
                            {
                                wordsOver();
                                return;
                            }
                        }
                    }
                    else
                    {
                        read_count++;
                        showords[current_index] = new myWord();
                        current_word = reader["word"].ToString();
                        showords[current_index].word = current_word;
                        showords[current_index].sentences_raw = reader["sentences"].ToString().Replace('\"', '\'');
                        showords[current_index].meaning_raw = reader["meaning"].ToString().Replace('\"', '\'');
                        showords[current_index].pronun_raw = reader["pronun"].ToString().Replace('\"', '\'');
                        showords[current_index].operated = false;
                        updateScreen(current_word);
                    }
                }
            }
            else
            {
                current_word = showords[current_index].word;
                updateScreen(current_word);
            }
            if (current_index == read_count)
            {
                hideAll();
            }
        }

        private bool notTooEarly()
        {
            DateTime lastest_date = DateTime.Parse(reader["date"].ToString());
            int V_T = SqliteManager.getTimeSpan(lastest_date);
            
            if (V_T > 60) return false;
            else return true;
        }

        private void getLastWord()
        {
            if (current_index > 0)
            {
                current_index--;
                showAll();
                if (current_index == 0)
                {
                    label_back.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                current_word = showords[current_index].word;
                updateScreen(current_word);
            }
        }

        private void updateScreen(string word)
        {
            label_word.Text = word;
            string pronun_raw = showords[current_index].pronun_raw;
            if (pronun_raw == "null" || pronun_raw == "")
            {
                label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                string[] pronun_EN_US = pronun_raw.Split('|');
                if (pronun_EN_US[1] == "")
                {
                    label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    label_pronun_US.Text = pronun_EN_US[0];
                }
                else
                {
                    label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    label_pronun_EN.Text = pronun_EN_US[0];
                    label_pronun_US.Text = pronun_EN_US[1];
                }
            }

            string meaning_raw = showords[current_index].meaning_raw;
            if (meaning_raw != null && meaning_raw != "")
            {
                foreach (string meaning in meaning_raw.Split('|'))
                {
                    if (meaning == meaning_raw.Split('|')[0])
                    {
                        label_meaning.Text = meaning;
                    }
                    else
                    {
                        label_meaning.Text += "\r\n" + meaning;
                    }
                }
            }
            string sentences_raw = showords[current_index].sentences_raw;
            while (sentences_raw.IndexOf("<dt>") >= 0)
            {
                int k1 = sentences_raw.IndexOf("</p>");
                int k2 = sentences_raw.IndexOf("<dt>") + 7;
                string temp = sentences_raw;
                sentences_raw = temp.Substring(0, k1) + "|" + temp.Substring(k2, sentences_raw.Length - k2);
            }
            if (sentences_raw != null && sentences_raw != "")
            {
                string[] sentences = sentences_raw.Split('|');
                foreach (SimpleLabelItem label in this.layoutControlGroup2.Items)
                {
                    if (label.Name == "label_1_showonly")
                    {
                        label.Text = "例句:";
                        continue;
                    }
                    int order = int.Parse(label.Name.Split('_')[3]);
                    string type = label.Name.Split('_')[2];
                    if (order >= sentences.Length)
                    {
                        label.Text = " ";
                        continue;
                    }
                    else
                    {
                        string sentence = sentences[order - 1];
                        if (sentence.Length == 0) continue;
                        int first_CC_index = 0;//第一个汉字下标;
                        while ((int)sentence[first_CC_index] < 127)
                        {
                            first_CC_index++;
                            if (first_CC_index == sentence.Length - 1) break;
                        }
                        int EN_CN_separator = first_CC_index;
                        while (sentence[EN_CN_separator] != ' ')
                        {
                            EN_CN_separator--;
                            if (EN_CN_separator == 1) break;
                        }

                        if (type == "EN")
                        {
                            string sentence_EN = sentence.Substring(0, EN_CN_separator);
                            if (sentence_EN.Length <= 90)
                            {
                                label.Text = order.ToString() + "." + sentence_EN;
                            }
                            else
                            {
                                label.Text = order.ToString() + "." + sentence_EN.Substring(0,90) + "\r\n" +
                                    sentence_EN.Substring(90,sentence_EN.Length - 90);
                            }
                        }
                        else
                        {
                            string sentence_CN = sentence.Substring(EN_CN_separator + 1, sentence.Length - EN_CN_separator - 1);
                            if (sentence_CN.Length <= 90)
                            {
                                label.Text = sentence_CN;
                            }
                            else
                            {
                                label.Text = sentence_CN.Substring(0, 90) + "\r\n" + sentence_CN.Substring(90, sentence_CN.Length - 90);
                            }

                        }
                    }
                }
            }
        }

        private void tile_known_ItemClick(object sender, TileItemEventArgs e)
        {

            if (!showords[current_index].operated)
            {
                showords[current_index].operated = true;
                manager.updateRecitedWords(current_word, 1);
            }
            getNextWord();
        }

        private void tile_unsure_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!showords[current_index].operated)
            {
                showords[current_index].operated = true;
                manager.updateRecitedWords(current_word, 2);
            }
            unwords[un_length++] = showords[current_index];
            getNextWord();
        }

        private void tile_unknown_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!showords[current_index].operated)
            {
                showords[current_index].operated = true;
                manager.updateRecitedWords(current_word, 3);
            }
            unwords[un_length++] = showords[current_index];
            getNextWord();
        }

        private void tile_shutdown_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!showords[current_index].operated)
            {
                manager.updateRecitedWords(current_word, 0);
                showords[current_index].operated = true;
            }
            shutDownOneWord(current_index);
            current_index--;
            getNextWord();
        }

        private void shutDownOneWord(int index)
        {
            for (int i = index + 1; i < read_count; i++)
            {
                showords[index - 1].word = showords[index].word;
                showords[index - 1].sentences_raw = showords[index].sentences_raw;
                showords[index - 1].meaning_raw = showords[index].meaning_raw;
                showords[index - 1].pronun_raw = showords[index].pronun_raw;
                showords[index - 1].operated = showords[index].operated;
            }
            showords[index] = null;
            read_count--;
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string web;
            switch (e.Button.ToString())
            {
                case "Caption = '有道'":
                    web = string.Format("http://www.youdao.com/w/eng/{0}/#keyfrom=dict2.index", current_word);
                    System.Diagnostics.Process.Start(web);
                    break;
                case "Caption = '必应'":
                    web = string.Format("https://cn.bing.com/dict/search?q={0}", current_word);
                    System.Diagnostics.Process.Start(web);
                    break;
                case "Caption = '柯林斯'":
                    web = string.Format("https://www.collinsdictionary.com/zh/dictionary/english/{0}", current_word);
                    System.Diagnostics.Process.Start(web);
                    break;
                case "Caption = '剑桥'":
                    web = string.Format("https://cn.bing.com/dict/search?q={0}", current_word);
                    System.Diagnostics.Process.Start(web);
                    break;
                case "Caption = '牛津'":
                    web = string.Format("https://www.oxfordlearnersdictionaries.com/definition/english/{0}", current_word);
                    System.Diagnostics.Process.Start(web);
                    break;
                case "Caption = '韦氏'":
                    web = string.Format("https://www.merriam-webster.com/dictionary/{0}", current_word);
                    System.Diagnostics.Process.Start(web);
                    break;
            }
        }

        private void label_back_Click(object sender, EventArgs e)
        {
            getLastWord();
        }

        private void hideAll()
        {
            btn_panel.Visible = false;
            label_2_showonly.Visible = false;
            label_meaning.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            tileBarGroup2.Visible = false;
            label_1_showonly.Text = " ";
            label_sentence_EN_1.Text = "请把中文发音和英文解释说出口";
            label_sentence_EN_1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label_sentence_EN_2.Text = " ";
            label_sentence_EN_3.Text = " ";
            label_sentence_CN_1.Text = "点击此处显示答案";
            label_sentence_CN_1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label_sentence_CN_1.AppearanceItemCaption.ForeColor = System.Drawing.Color.DarkSeaGreen;
            label_sentence_CN_2.Text = " ";
            label_sentence_CN_3.Text = " ";
            label_back.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void showAll()
        {
            if (current_index > 0)
            {
                label_back.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            btn_panel.Visible = true;
            label_2_showonly.Visible = true;
            label_meaning.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            label_word.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            string pronun_raw = showords[current_index].pronun_raw;
            if (pronun_raw == "null" || pronun_raw == "")
            {
                label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                string[] pronun_EN_US = pronun_raw.Split('|');
                if (pronun_EN_US[1] == "")
                {
                    label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    label_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    img_pronun_EN.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    label_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    img_pronun_US.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
            tileBarGroup2.Visible = true;
            label_sentence_EN_1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            label_sentence_CN_1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            label_sentence_CN_1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
        }

        private void label_sentence_CN_1_Click(object sender, EventArgs e)
        {
            if (label_sentence_CN_1.Text == "点击此处显示答案")
            {
                manager.setRecited(current_word);
                showAll();
                updateScreen(current_word);
            }
        }

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength, uint hWndCallback);
        public void playMp3(int type)
        {
            mciSendString(@"close temp_alias", null, 0, 0);
            string command;
            if (type == 0) command = string.Format(@"open ""MP3_UK/{0}.mp3"" alias temp_alias", current_word);
            else command = string.Format(@"open ""MP3_US/{0}.mp3"" alias temp_alias", current_word);
            mciSendString(command, null, 0, 0); //音乐文件
            mciSendString("play temp_alias", null, 0, 0);
        }

        private void img_pronun_EN_Click(object sender, EventArgs e)
        {
            playMp3(0);
            img_pronun_EN.ImageOptions.Image = global::LSR.Properties.Resources.speak1;
            Delay(1000);
            img_pronun_EN.ImageOptions.Image = global::LSR.Properties.Resources.speak0;
        }

        private void img_pronun_US_Click(object sender, EventArgs e)
        {
            playMp3(1);
            img_pronun_US.ImageOptions.Image = global::LSR.Properties.Resources.speak1;
            Delay(1000);
            img_pronun_US.ImageOptions.Image = global::LSR.Properties.Resources.speak0;
        }

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

    }
}
