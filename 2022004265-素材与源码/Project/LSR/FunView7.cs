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

namespace LSR
{
    public partial class FunView7 : DevExpress.XtraEditors.XtraUserControl
    {
        private SqliteManager manager;
        private bool b1 = false;
        private bool b2 = false;
        private bool b3 = false;
        public FunView7(SqliteManager main_manager)
        {
            InitializeComponent();
            manager = main_manager;
        }

        private void FunView7_Load(object sender, EventArgs e)
        {
            SQLiteDataReader reader = manager.getInfo();
            reader.Read();
            if (reader.HasRows)
            {
                textEdit_words_plan_all.EditValue = int.Parse(reader["Total"].ToString());
                textEdit_words_plan_daily.EditValue = int.Parse(reader["EveryDaySetQuan"].ToString());
                textEdit_new_words_ratio.EditValue = int.Parse(reader["LowestPercent"].ToString());
            }
        }

        private void textEdit_words_plan_all_EditValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            int daily = 0;
            int ratio = 0;
            int.TryParse(textEdit_words_plan_all.Text, out total);
            int.TryParse(textEdit_words_plan_daily.Text, out daily);
            int.TryParse(textEdit_new_words_ratio.Text.Split('.')[0], out ratio);
            manager.setInfo(total, daily, ratio);
            manager.clearRest();
        }

        private void textEdit_words_plan_daily_EditValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            int daily = 0;
            int ratio = 0;
            int.TryParse(textEdit_words_plan_all.Text, out total);
            int.TryParse(textEdit_words_plan_daily.Text, out daily);
            int.TryParse(textEdit_new_words_ratio.Text.Split('.')[0], out ratio);
            manager.setInfo(total, daily, ratio);
            manager.clearRest();
        }

        private void textEdit_new_words_ratio_EditValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            int daily = 0;
            int ratio = 0;
            int.TryParse(textEdit_words_plan_all.Text, out total);
            int.TryParse(textEdit_words_plan_daily.Text, out daily);
            int.TryParse(textEdit_new_words_ratio.Text.Split('.')[0], out ratio);
            manager.setInfo(total, daily, ratio);
            manager.clearRest();
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                double kc = trackBarControl1.Value/10.0;
                Console.WriteLine(trackBarControl1.Value);
                Console.WriteLine(kc);
                manager.setKc(kc);
                manager.clearRest();
            }
            catch
            {

            }
        }


    }
}
