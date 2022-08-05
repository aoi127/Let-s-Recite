using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseCombine
{
    class SqliteManager
    {
        SQLiteConnection db_connection1;
        SQLiteConnection db_connection2;
        SQLiteConnection db_connection3;

        public SqliteManager()
        {
            db_connection1 = new SQLiteConnection("Data Source=LSR.sqlite;Version=3;");
            db_connection2 = new SQLiteConnection("Data Source=LSRcln.sqlite;Version=3;");
            db_connection3 = new SQLiteConnection("Data Source=LSRljy.sqlite;Version=3;");

            db_connection1.Open();
            db_connection2.Open();
            db_connection3.Open();
        }

        public int exportWord(string[] word_list)
        {
            int cnt = 0;
            // 构造sql语句
            string sql = string.Format("select * " +
                                        "FROM Tem8 ");

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection1);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                word_list[cnt] = reader["Word"].ToString();
                cnt++;
            }
            return cnt;
        }

        public void exportSentence(string[] sentences_list)
        {
            int cnt = 0;
            // 构造sql语句
            string sql = string.Format("select * " +
                                        "FROM UNGEE ");

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection3);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sentences_list[cnt] = reader["Sentences"].ToString();
                cnt++;
            }
        }

        public void exportMeaning(string[] meaning_list)
        {
            int cnt = 0;
            // 构造sql语句
            string sql = string.Format("select * " +
                                       "FROM UNGEE ");

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection3);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                meaning_list[cnt] = reader["Meaning"].ToString();
                cnt++;
            }
        }

        public void exportPronuncaition(string[] pronun_list)
        {
            int cnt = 0;
            // 构造sql语句
            string sql = string.Format("select * " +
                                       "FROM Tem8 ");

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                pronun_list[cnt] = reader["Pronun"].ToString();
                cnt++;
            }
        }

        public void importMeaning(string[] meaning_list, string[] word_list)
        {
            for (int i = 0; i < meaning_list.Length; i++)   
            {
                if (meaning_list[i] == null)
                    continue;
                // 构造sql语句
                string sql = string.Format("UPDATE UNGEE " +
                                           "SET Meaning = '{0}' " +
                                           "WHERE Word = '{1}';", meaning_list[i], word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection1);
                command.ExecuteNonQuery();
            }
        }

        public void importSentence(string[] sentences_list, string[] word_list)
        {
            for (int i = 0; i < sentences_list.Length; i++)   
            {
                if (sentences_list[i] == null)
                    continue;
                // 构造sql语句
                string sql = string.Format("UPDATE UNGEE " +
                                            "SET Sentences = '{0}' " +
                                            "WHERE Word = '{1}';", sentences_list[i].Replace("'", "''"), word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection1);
                command.ExecuteNonQuery();
            }
        }

        public void importPronunciation(string[] pronun_list, string[] word_list)
        {
            for (int i = 0; i < pronun_list.Length; i++)   
            {
                if (pronun_list[i] == null)
                    continue;
                // 构造sql语句
                string sql = string.Format("UPDATE Tem8 " +
                                           "SET Pronun = '{0}' " +
                                           "WHERE Word = '{1}';", pronun_list[i].Replace("'", "''"), word_list[i]);

                // 执行sql语句
                SQLiteCommand command = new SQLiteCommand(sql, db_connection1);
                command.ExecuteNonQuery();
            }
        }
    }
}
