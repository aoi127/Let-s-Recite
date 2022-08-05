using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseCombine
{
    public partial class Form1 : Form
    {
        public static string[] word_list = new string[12655];
        public static string[] meaning_list = new string[12655];
        public static string[] sentences_list = new string[12655];
        public static string[] pronun_list = new string[12655];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqliteManager manager = new SqliteManager();
            manager.exportWord(word_list);
            manager.exportPronuncaition(pronun_list);
            //manager.exportMeaning(meaning_list);
            //manager.exportSentence(sentences_list);
            //manager.importMeaning(meaning_list, word_list);
            //manager.importSentence(sentences_list, word_list);
            manager.importPronunciation(pronun_list, word_list);
        }
    }
}
