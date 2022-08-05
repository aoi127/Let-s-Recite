using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace LSR
{
    public class SqliteManager
    {
        SQLiteConnection db_connection;

        public SqliteManager()
        {
            db_connection = new SQLiteConnection("Data Source=LSR.sqlite;Version=3;");
            db_connection.Open();
        }

        //获取单词表的DataReader
        public SQLiteDataReader GetWordDataReader(int dic)
        {
            string[] dictionary = { "", "Cet4", "Cet6", "GRE", "IELTS", "Tem4", "Tem8", "TOEFL", "UNGEE" };
            // 构造sql语句
            string sql = string.Format("SELECT * FROM {0};", dictionary[dic]);

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        //获取单词表的DataReader
        public SQLiteDataReader GetCateDataReader()
        {
            // 构造sql语句
            string sql = "SELECT * FROM DicList;";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SQLiteDataReader getPlannedReader()
        {
            string[] dictionary = { "", "Cet4", "Cet6", "GRE", "IELTS", "Tem4", "Tem8", "TOEFL", "UNGEE" };
            // 构造sql语句
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql = "";
            for (int dic = 1; dic <= 8; dic++)
            {
                sql += string.Format("SELECT * FROM {0} WHERE isPlaned = 1;", dictionary[dic]);
            }
            // 执行sql语句
            command = new SQLiteCommand(sql, db_connection);
            reader = command.ExecuteReader();
            return reader;
        }

        public SQLiteDataReader getDateReader()
        {
            // 构造sql语句
            string sql = "SELECT * FROM RestNewWords;";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void setRestWords(int rest)
        {
            // 构造sql语句
            string date = DateTime.Now.Date.ToString("u");
            string sql = string.Format("INSERT INTO RestNewWords (Date, RestWords) " +
                                       "VALUES('{0}',{1});", date, rest);
            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        public void updateRestWords(int rest)
        {
            // 构造sql语句
            string date = DateTime.Now.Date.ToString("u");
            string sql = string.Format("UPDATE RestNewWords " +
                                       "SET RestWords = {0} " +
                                       "WHERE Date = '{1}';", rest, date);
            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        public int getPlannedCount()
        {
            int count = 0;
            string[] dictionary = { "", "Cet4", "Cet6", "GRE", "IELTS", "Tem4", "Tem8", "TOEFL", "UNGEE" };
            // 构造sql语句
            string sql = "";
            for (int dic = 1; dic <= 8; dic++)
            {
                sql = string.Format("SELECT COUNT(*) FROM {0} WHERE isPlaned = 1;", dictionary[dic]);
                SQLiteCommand command = new SQLiteCommand(sql, db_connection);

                // 执行sql语句
                count += Convert.ToInt32(command.ExecuteScalar());
            }
            return count;
        }

        public void setPlanedWord(string dic_name, List<string> word_list)
        {
            for (int i = 0; i < word_list.Count(); i++)
            {
                // 构造sql语句
                string sql = string.Format("UPDATE '{0}' " +
                                           "SET IsPlaned = 1 " +
                                           "WHERE Word = '{1}';", dic_name, word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection);
                command.ExecuteNonQuery();
            }
        }

        public SQLiteDataReader GetLearnedWord(string dic_name)
        {
            // 构造sql语句
            string sql = string.Format("SELECT * " +
                                       "FROM {0} " +
                                       "WHERE IsPlaned = 1 or IsRecited = 1;", dic_name);

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }



        /*--------------------------------------------------------------------------------------------------*/
        // 从数据库中获取数据

        // 获取与当前时间的时间差 （天数）
        public static int getTimeSpan(DateTime timeA)
        {
            DateTime timeB = DateTime.Now;	//获取当前时间
            TimeSpan ts = timeB - timeA;	//计算时间差
            int time = (int)ts.TotalDays;	//将时间差转换为天
            return time;
        }

        //获取距离第一天day天的日子
        public DateTime getTimeSpanTillFirstDay(int day)
        {
            // 查询最旧的数据
            string sql = "SELECT Date FROM RecitedWord ORDER BY Date ASC LIMIT 1;";

            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();

            DateTime dateTime = DateTime.Now;
            while (reader.Read())
            {
                dateTime = DateTime.Parse(reader["Date"].ToString());
            }

            //返回day天后的日期
            DateTime dateTime_day = dateTime.AddDays(day);
            return dateTime_day;
        }

        // 获取第一天
        public DateTime getFirstDay()
        {
            // 查询最旧的数据
            string sql = "SELECT Date FROM RecitedWord ORDER BY Date ASC LIMIT 1;";

            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();

            DateTime dateTime = DateTime.Now;
            while (reader.Read())
            {
                dateTime = DateTime.Parse(reader["Date"].ToString());
            }

            return dateTime;
        }


        //获取学习时长
        public int getLearningDate()
        {
            // 查询最旧的数据
            string sql = "SELECT Date FROM RecitedWord ORDER BY Date ASC LIMIT 1;";

            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();

            int timespan = 0;
            while (reader.Read())
            {
                DateTime dateTime = DateTime.Parse(reader["Date"].ToString());
                timespan = getTimeSpan(dateTime);
            }
            Console.WriteLine(timespan);

            if (FunView6.date_value_list.ContainsKey(DateTime.Now.Date.AddDays((-1) * timespan - 1).Date.ToString("yyyy-MM-dd")))
            {
                timespan += 1;
            }

            return timespan;
        }

        // 获取day天前总的学习单词
        public int getWordsNum(int day)
        {
            // 获取day天前的日期
            string date_before = DateTime.Now.AddDays(-1 * day + 1).ToString("yyyy-MM-dd");
            string sql = $"SELECT COUNT(*) FROM RecitedWord WHERE Date < '{date_before}'";
            //    $"WHERE Value<60 AND DateDiff(GetDate()-Date) > { day };";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            return count;
        }

        // 获取第day天总的学习单词数量
        public int getLearningNumDay(int day)
        {
            //距离第一天背单词，day天之后的日期
            DateTime date_till_1stday = getTimeSpanTillFirstDay(day);
            DateTime date_1stday = getFirstDay();
            string date_till_1stday_str = date_till_1stday.ToString("yyyy-MM-dd");
            string date_1stday_str = date_1stday.ToString("yyyy-MM-dd");
            string sql = $"SELECT COUNT(*) FROM RecitedWord WHERE Date BETWEEN '{date_1stday_str}' AND '{date_till_1stday_str}'";
            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            //Console.WriteLine("count1=", count);

            return count;
        }

        //获取遗忘曲线的数值
        // 获取在第day天没有遗忘的单词数
        public int unForgottenRate(int day)
        {
            //距离第一天背单词，day天之后的日期
            DateTime date_till_1stday = getTimeSpanTillFirstDay(day);
            DateTime date_1stday = getFirstDay();
            string date_till_1stday_str = date_till_1stday.ToString("yyyy-MM-dd");
            string date_1stday_str = date_1stday.ToString("yyyy-MM-dd");
            string sql = $"SELECT COUNT(*) FROM RecitedWord WHERE Value>100 AND Date BETWEEN '{date_1stday_str}' AND '{date_till_1stday_str}'";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            //Console.WriteLine("count1=", count);

            return count;
        }


        // 返回每一天不同的Identity数量
        private Dictionary<int, int> forgotton = new Dictionary<int, int>();
        private Dictionary<int, int> blurred = new Dictionary<int, int>();
        private Dictionary<int, int> familiar = new Dictionary<int, int>();
        private Dictionary<int, int> remember = new Dictionary<int, int>();

        // key=距离现在第my_date天 value=数量
        public Dictionary<int, int> Forgotton
        {
            get { return forgotton; }
        }
        public Dictionary<int, int> Blurred
        {
            get { return blurred; }
        }
        public Dictionary<int, int> Familiar
        {
            get { return familiar; }
        }
        public Dictionary<int, int> Remember
        {
            get { return remember; }
        }


        //获取每天的学习情况（新） day天前
        // key=距离现在第my_date天 value=Identify数值
        public void studyIdentity(int day)
        {
            DateTime dt = DateTime.Now;
            string target_year = dt.AddDays(-1 * day).ToString("yyyy");
            string target_month = dt.AddDays(-1 * day).ToString("MM");
            string target_day = dt.AddDays(-1 * day).ToString("dd");
            string sql = "SELECT Identify,Date FROM RecitedWord " +
                $"WHERE strftime('%Y',Date)='{target_year}' AND strftime('%m',Date)='{target_month}' AND strftime('%d',Date)='{target_day}';";
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int my_date = day;
                int my_identity = int.Parse(reader["Identify"].ToString());

                switch (my_identity)
                {
                    case 3:
                        if (forgotton.ContainsKey(my_date))
                        {
                            forgotton[my_date] += 1;
                        }
                        else forgotton.Add(my_date, 1);
                        break;

                    case 2:
                        if (blurred.ContainsKey(my_date))
                        {
                            blurred[my_date] += 1;
                        }
                        else blurred.Add(my_date, 1);
                        break;

                    case 1:
                        if (familiar.ContainsKey(my_date))
                        {
                            familiar[my_date] += 1;
                        }
                        else familiar.Add(my_date, 1);
                        break;
                    case 0:
                        if (remember.ContainsKey(my_date))
                        {
                            remember[my_date] += 1;
                        }
                        else remember.Add(my_date, 1);
                        break;

                    default: //数值为空 直接跳过
                        break;
                }
            }
        }

        //记忆持久度
        // thisday+day 天前背过的总量 - thisday天前， day天以内Value>100的单词数量
        public int lastingTime(int thisday, int day)
        {
            DateTime dt = DateTime.Now;
            // thisday天前背过的总量
            int count1 = getWordsNum(thisday + day);

            if (count1 == 0) return 0;
            // thisday天以前
            string right_day = dt.AddDays(-1 * thisday).ToString("yyyy-MM-dd");

            //day天以内
            string left_day = dt.AddDays(-1 * (thisday + day)).ToString("yyyy-MM-dd");

            string sql = $"SELECT COUNT(DISTINCT Word) FROM RecitedWord WHERE Value>100 " +
                $"AND Date BETWEEN '{left_day}' and '{right_day}'";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            int count2 = Convert.ToInt32(command.ExecuteScalar());
            int count = count1 - count2;
            if (count < 0) return 0;
            return count;
        }

        public void setRecited(string word)
        {
            string[] dictionary = { "", "Cet4", "Cet6", "GRE", "IELTS", "Tem4", "Tem8", "TOEFL", "UNGEE" };
            // 构造sql语句
            string sql = "";
            for (int dic = 1; dic <= 8; dic++)
            {
                sql += string.Format("UPDATE {0} " +
                                    "SET isRecited = 1 " +
                                    "WHERE Word = '{1}';", dictionary[dic], word);
            }

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        public void setUnplaned(string word)
        {
            string[] dictionary = { "", "Cet4", "Cet6", "GRE", "IELTS", "Tem4", "Tem8", "TOEFL", "UNGEE" };
            // 构造sql语句
            string sql = "";
            for (int dic = 1; dic <= 8; dic++)
            {
                sql += string.Format("UPDATE {0} " +
                                    "SET isPlaned = 0 " +
                                    "WHERE Word = '{1}';", dictionary[dic], word);
            }

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        public void insertRecitedWords(string word, string meaning, string sentences, string pronun, int identify)
        {
            // 构造sql语句
            //string date = DateTime.Now.ToString("u").Substring(0, DateTime.Now.ToString("u").Length - 1);
            string date = DateTime.Now.ToString("s");
            double value = countValue(identify, DateTime.Now, 0, 0, 0);
            string sql = string.Format(@"INSERT INTO RecitedWord (Word, Meaning, Sentences, Pronun, Identify, Date, Value, ReviewKnownTimes, ReviewUncertainTimes, ReviewUnknownTimes, IsReviewedToday) " +
                                       @"VALUES('{0}','{1}','{2}','{3}',{4},'{5}',{6}, 0, 0, 0, 0);",
                                       @word,
                                       meaning.Replace('\'', '\"'),
                                       sentences.Replace('\'', '\"'),
                                       pronun.Replace('\'', '\"'),
                                       identify,
                                       @date,
                                       value);
            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        public void updateRecitedWords(string word, int identify)
        {
            string coloum = "";
            int Cmp = 0;
            if (identify == 1)
            {
                coloum = "ReviewKnownTimes";
                Cmp = 30;
            }
            else if (identify == 2)
            {
                coloum = "ReviewUncertainTimes";
                Cmp = 15;
            }
            else if (identify == 3)
            {
                coloum = "ReviewUnknownTimes";
                Cmp = 9;
            }
            string date = DateTime.Now.ToString();

            // 构造sql语句
            string sql;
            if (identify == 0)
                sql = string.Format("UPDATE RecitedWord " +
                      "SET Identify = 0, value = 150 " +
                      "WHERE word = '{0}'", word);
            else
                sql = string.Format(@"UPDATE RecitedWord " +
                                       @"SET {0} = {1} + 1, value = value + {2}, IsReviewedToday = 1 , LatestReviewDate = '{3}' " +
                                       @"WHERE word = '{4}'", coloum, coloum, Cmp, date, word
                                       );
            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        public SQLiteDataReader getReviewedReader()
        {
            // 构造sql语句
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql = "";
            sql = string.Format("SELECT * FROM " +
                "(SELECT Word,Meaning,Sentences,Pronun,MAX(Date) Date,Value " +
                "FROM RecitedWord " +
                "GROUP BY Word " +
                "HAVING Identify != 0 AND value < 100 AND IsReviewedToday = 0)" +
                "ORDER BY Value DESC;");

            // 执行sql语句
            command = new SQLiteCommand(sql, db_connection);
            reader = command.ExecuteReader();
            return reader;
        }

        public double countValue(int identify, DateTime origin_date, int review_known, int review_uncertain, int review_unknown)
        {
            int hi = 110;
            int hs = 0;
            double k = 0;
            int t = DateTime.Now.Day - origin_date.Day + 30 * (DateTime.Now.Month - origin_date.Month);
            switch (identify)
            {
                case 0: return 150;
                case 1: k = 0.1; break;
                case 2: k = 0.3; break;
                case 3: k = 0.8; break;
            }
            return hi * Math.Pow(2.72, -k * MainView.Kc * t) + hs + 30 * review_known + 15 * review_uncertain + 9 * review_unknown;
        }


        public SQLiteDataReader getInfo()
        {
            // 构造sql语句
            string sql = "SELECT * FROM SetInfo;";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void setInfo(int total, int everyday, int lowestP)
        {
            // 构造sql语句
            string sql = string.Format("UPDATE SetInfo " +
                                       "SET Total = {0}, EveryDaySetQuan = {1}, LowestPercent = {2};", total, everyday, lowestP);

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        // 统计遗忘的单词数(即需要复习的单词数)
        public int getForgetNum()
        {
            string sql = "SELECT COUNT(DISTINCT Word) " +
                "FROM RecitedWord " +
                "WHERE Value<=100";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count;
        }

        //应用启动时更新value值
        public void refreshRecitedWord()
        {
            List<string> sql_list = new List<string>();
            List<string> word_list = new List<string>();
            List<int> identify_list = new List<int>();
            List<DateTime> date_list = new List<DateTime>();
            List<int> known_list = new List<int>();
            List<int> uncertain_list = new List<int>();
            List<int> unknown_list = new List<int>();
            List<DateTime> latest_date_list = new List<DateTime>();
            int cnt = 0;
            double value;
            double value_last;
            List<double> value_list = new List<double>();

            FunView6.date_value_list.Clear();

            //查询数据
            // 构造查询sql语句
            string sql0 = "SELECT * " +
                "FROM RecitedWord ";
            // 执行sql语句
            SQLiteCommand command0 = new SQLiteCommand(sql0, db_connection);
            SQLiteDataReader reader = command0.ExecuteReader();
            //存取参数值
            while (reader.Read())
            {
                word_list.Add((reader["Word"].ToString()));
                identify_list.Add(int.Parse(reader["Identify"].ToString()));
                date_list.Add(DateTime.Parse(reader["Date"].ToString()));
                known_list.Add(int.Parse(reader["ReviewKnownTimes"].ToString()));
                uncertain_list.Add(int.Parse(reader["ReviewUncertainTimes"].ToString()));
                unknown_list.Add(int.Parse(reader["ReviewUnknownTimes"].ToString()));
                if (reader["LatestReviewDate"].ToString() == "")
                    latest_date_list.Add(DateTime.Now.AddDays(1));
                else
                    latest_date_list.Add(DateTime.Parse(reader["LatestReviewDate"].ToString()));
                cnt++;
            }

            // 构造更新sql语句
            for (int i = 0; i < cnt; i++)
            {
                string sql;
                value = countValue(identify_list[i], date_list[i], known_list[i], uncertain_list[i], unknown_list[i]);
                value_last = countValue(identify_list[i], date_list[i].AddDays(-3), known_list[i], uncertain_list[i], unknown_list[i]);
                value_list.Add(value_last);
                // 已经添加过这个日期的value
                if (FunView6.date_value_list.ContainsKey(date_list[i].ToString("yyyy-MM-dd")))
                {
                    List<double> value_list_temp = FunView6.date_value_list[date_list[i].ToString("yyyy-MM-dd")];
                    value_list_temp.Add(value_last);
                    FunView6.date_value_list[date_list[i].ToString("yyyy-MM-dd")] = value_list_temp;
                }
                // 未添加过这个日期的value
                else
                {
                    List<double> value_list_temp = new List<double>();
                    value_list_temp.Add(value_last);
                    FunView6.date_value_list.Add(date_list[i].ToString("yyyy-MM-dd"), value_list_temp);
                }

                // FunView6.date_value_list.Add(date_list[i].ToString("yyyy-MM-dd"), value_last);
                if (latest_date_list[i].Day != DateTime.Now.Day)
                {
                    sql = string.Format("UPDATE RecitedWord " +
                                          "SET value = {0}, IsReviewedToday = 0 " +
                                          "WHERE Word = '{1}'", value, word_list[i]);
                }
                else
                {
                    sql = string.Format("UPDATE RecitedWord " +
                                           "SET value = {0} " +
                                           "WHERE Word = '{1}'", value, word_list[i]);
                }
                sql_list.Add(sql);
            }

            // FunView6.date_value_list.Add(DateTime.Now.ToString("yyyy-MM-dd"), value_list);
            //执行sql语句
            for (int j = 0; j < cnt; j++)
            {
                SQLiteCommand command = new SQLiteCommand(sql_list[j], db_connection);
                command.ExecuteNonQuery();
            }
        }

        //应用启动时更新Kc
        public void refreshKc()
        {
            // 构造sql语句
            string sql = "SELECT Kc " +
                         "FROM SetInfo";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            MainView.Kc = (double)command.ExecuteScalar();
        }

        //根据用户设置信息设置Kc
        public void setKc(double Kc)
        {
            // 构造sql语句
            string sql = string.Format("UPDATE SetInfo " +
                                       "SET Kc = {0}", Kc);

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        //清空RestNewWords表
        public void clearRest()
        {
            // 构造sql语句
            string sql = "DELETE FROM RestNewWords ";

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            command.ExecuteNonQuery();
        }

        //测试方法，调整单词记忆时间
        public void setDate()
        {
            List<string> sql_list = new List<string>();
            List<string> word_list = new List<string>();
            List<string> Date_list = new List<string>();
            int cnt = 0;
            //查询数据
            // 构造查询sql语句
            string sql0 = "SELECT * " +
                "FROM RecitedWord ";
            // 执行sql语句
            SQLiteCommand command0 = new SQLiteCommand(sql0, db_connection);
            SQLiteDataReader reader = command0.ExecuteReader();
            //存取参数值
            while (reader.Read())
            {
                word_list.Add((reader["Word"].ToString()));
                DateTime dateTime = DateTime.Parse(reader["Date"].ToString()).AddDays(1);
                if (dateTime.Day == DateTime.Now.Day)
                    dateTime.AddDays(1);
                Date_list.Add(dateTime.ToString("s"));
                cnt++;
            }

            string latest = DateTime.Now.AddDays(-1).ToString();
            // 构造更新sql语句
            for (int i = 0; i < cnt; i++)
            {
                string sql = string.Format("UPDATE RecitedWord " +
                                           "SET Date = '{0}',LatestReviewDate = '{1}' " +
                                           "WHERE Word = '{2}'", Date_list[i], latest, word_list[i]);
                sql_list.Add(sql);
            }
            //执行sql语句
            for (int j = 0; j < cnt; j++)
            {
                SQLiteCommand command = new SQLiteCommand(sql_list[j], db_connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
