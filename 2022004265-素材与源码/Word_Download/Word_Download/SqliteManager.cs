using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Word_Download
{
    class SqliteManager
    {
        SQLiteConnection db_connection;

        public SqliteManager()
        {
            db_connection = new SQLiteConnection("Data Source=LSR.sqlite;Version=3;");

            db_connection.Open();
        }

        public void importWord(string[] word_list)
        {
            for(int i = 0;i < word_list.Length;i++)
            {
                if (word_list[i] == null)
                    continue;
                // 构造sql语句
                string sql = string.Format("INSERT INTO Cet4(Word) " +
                                           "VALUES('{0}');", word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection);
                command.ExecuteNonQuery();
            }       
        }

        public void importMeaning(string[] meaning_list, string[] word_list)
        {
            for (int i = 7000; i < meaning_list.Length; i++)   //这里的循环起始数字记得也要改
            {
                if (meaning_list[i] == null)
                    continue;
                // 构造sql语句
                string sql = string.Format("UPDATE GRE " +
                                           "SET Meaning = '{0}' " +
                                           "WHERE Word = '{1}';", meaning_list[i], word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection);
                command.ExecuteNonQuery();
            }
        }

        public void importSentences(string[] sentences_list, string[] word_list)
        {
            for (int i = 7000; i < sentences_list.Length; i++)   //这里的循环起始数字记得也要改
            {
                if (sentences_list[i] == null)
                    continue;
                // 构造sql语句
                string sql = string.Format("UPDATE GRE " +
                                           "SET Sentences = '{0}' " +
                                           "WHERE Word = '{1}';", sentences_list[i], word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection);
                command.ExecuteNonQuery();
            }
        }

        public void importPronunciation(string[] pronun_list, string[] word_list)
        {
            for (int i = 12453; i < pronun_list.Length; i++)   //这里的循环起始数字记得也要改
            {
                if (pronun_list[i] == null)
                    continue;
                // 构造sql语句
                string sql = string.Format("UPDATE Tem8 " +
                                           "SET Pronun = '{0}' " +
                                           "WHERE Word = '{1}';", pronun_list[i], word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection);
                command.ExecuteNonQuery();
            }
        }

        public int exportWord(string[] word_list)
        {
            int cnt = 0;
            // 构造sql语句
            string sql = string.Format("select * " +
                                       "FROM Tem8 ");

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                word_list[cnt] = reader["Word"].ToString();
                cnt++;
            }
            return cnt;
        }

        //这个函数没啥用，之前测试用的
        public List<string> checkPrimary()
        {
            List<string> a = new List<string>();
            // 构造sql语句
            string sql = string.Format("select * " +
                                       "FROM Cet6 as x, Cet6 as y " +
                                       "WHERE x.Word = y.Word and x.rowid != y.rowid;");

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                a.Add(reader["Word"].ToString());
            return a;
        }
    }
}
