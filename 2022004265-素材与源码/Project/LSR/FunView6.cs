using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSR
{
    public partial class FunView6 : DevExpress.XtraEditors.XtraUserControl
    {
        public static Dictionary<string, List<double>> date_value_list = new Dictionary<string, List<double>>();
        private SqliteManager manager;
        // public static Hashtable date_value_list = new Hashtable();

        DataTable table1 = new DataTable("记忆度低");
        DataTable table2 = new DataTable("记忆度中");
        DataTable table3 = new DataTable("记忆度高");
        DataTable table4 = new DataTable("记忆度极高");

        public FunView6(SqliteManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            manager.refreshRecitedWord();
        }

        // 获取今天是第n天
        public int n;

        //记忆持度
        //已规划 记忆度低 中 高 极高
        private void FunView6_Load(object sender, EventArgs e)
        {
            
            n = manager.getLearningDate();
           

            // Create a line series.
            Series series1 = new Series("已规划", ViewType.Line);
            Series series2 = new Series("记忆度低", ViewType.Line);
            Series series3 = new Series("记忆度中", ViewType.Line);
            Series series4 = new Series("记忆度高", ViewType.Line);
            Series series5 = new Series("记忆度极高", ViewType.Line);

            getMemory();

            // Add points to it.
            series1.DataSource = totalWords();

            // Specify data members to bind the series.
            series1.ArgumentScaleType = ScaleType.Auto;
            series1.ArgumentDataMember = "Time";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "Value" });


            // Access the view-type-specific options of the series.
            //((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle;
            //((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

            series2.DataSource = table1;

            series2.ArgumentScaleType = ScaleType.Auto;
            series2.ArgumentDataMember = "Time";
            series2.ValueScaleType = ScaleType.Numerical;
            series2.ValueDataMembers.AddRange(new string[] { "Value" });


            series3.DataSource = table2;
            series3.ArgumentScaleType = ScaleType.Auto;
            series3.ArgumentDataMember = "Time";
            series3.ValueScaleType = ScaleType.Numerical;
            series3.ValueDataMembers.AddRange(new string[] { "Value" });


            series4.DataSource = table3;
            series4.ArgumentScaleType = ScaleType.Auto;
            series4.ArgumentDataMember = "Time";
            series4.ValueScaleType = ScaleType.Numerical;
            series4.ValueDataMembers.AddRange(new string[] { "Value" });


            series5.DataSource = table4;
            series5.ArgumentScaleType = ScaleType.Auto;
            series5.ArgumentDataMember = "Time";
            series5.ValueScaleType = ScaleType.Numerical;
            series5.ValueDataMembers.AddRange(new string[] { "Value" });

            // Add the series to the chart.
            lineChart.Series.AddRange(new Series[] {
                series1,
                series2,
                series3,
                series4,
                series5
            });

            // Access the type-specific options of the diagram.
            ((XYDiagram)lineChart.Diagram).EnableAxisXZooming = false;

            // Hide the legend (if necessary).
            lineChart.Legend.Visible = true;

            // Add a title to the chart (if necessary).
            lineChart.Titles.Add(new ChartTitle());
            lineChart.Titles[0].Text = "记忆持久度";

            // Add the chart to the form.
            //lineChart.Dock = DockStyle.Fill;
            this.Controls.Add(lineChart);
        }

        private DataTable totalWords()
        {
            
            // Create an empty table.
            DataTable table = new DataTable("已规划单词");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));


            // Add data rows to the table.
            DataRow row;

            
            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                DateTime dt = DateTime.Now.Date;
                DateTime dayBeforei = dt.AddDays((-1) * i).Date;
                string dayBeforei_str = dayBeforei.ToString("yyyy-MM-dd");

                if (date_value_list.ContainsKey(dayBeforei_str))
                {
                    row["Value"] = manager.getWordsNum(i);

                    table.Rows.Add(row);
                }
                else
                {
                    continue;
                }
            }

            return table;
        }

        private void getMemory()
        {


            // Add two columns to the table.
            table1.Columns.Add("Time", typeof(string));
            table1.Columns.Add("Value", typeof(decimal));

            table2.Columns.Add("Time", typeof(string));
            table2.Columns.Add("Value", typeof(decimal));

            table3.Columns.Add("Time", typeof(string));
            table3.Columns.Add("Value", typeof(decimal));

            table4.Columns.Add("Time", typeof(string));
            table4.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row1;
            DataRow row2;
            DataRow row3;
            DataRow row4;

            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;

            for (int i = n; i >= 0; i--)
            {
                row1 = table1.NewRow();
                row2 = table2.NewRow();
                row3 = table3.NewRow();
                row4 = table4.NewRow();

                if (i == 0)
                {
                    row1["Time"] = "今天";
                    row2["Time"] = "今天";
                    row3["Time"] = "今天";
                    row4["Time"] = "今天";

                }
                else if (i == 1)
                {
                    row1["Time"] = "昨天";
                    row2["Time"] = "昨天";
                    row3["Time"] = "昨天";
                    row4["Time"] = "昨天";

                }
                else if (i == 2)
                {
                    row1["Time"] = "前天";
                    row2["Time"] = "前天";
                    row3["Time"] = "前天";
                    row4["Time"] = "前天";
                }
                else
                {
                    row1["Time"] = i + "天前";
                    row2["Time"] = i + "天前";
                    row3["Time"] = i + "天前";
                    row4["Time"] = i + "天前";

                }

                DateTime dt = DateTime.Now.Date;
                // 获取i天前的日期
                DateTime dayBeforei = dt.AddDays((-1) * i).Date;
                //Dictionary<DateTime, List<double>> date_value_list = new Dictionary<DateTime, List<double>>();
                //row1["Value"] = 

                string dayBeforei_str = dayBeforei.ToString("yyyy-MM-dd");

                if (date_value_list.ContainsKey(dayBeforei_str))
                {
                    List<double> value_i = date_value_list[dayBeforei_str];
                    foreach (double v in value_i)
                    {
                        if (v >= 0 && v < 40) count1 += 1;
                        else if (v >= 40 && v < 80) count2 += 1;
                        else if (v >= 80 && v < 100) count3 += 1;
                        else if (v >= 100) count4 += 1;
                    }

                    row1["Value"] = count1;
                    row2["Value"] = count2;
                    row3["Value"] = count3;
                    row4["Value"] = count4;


                    table1.Rows.Add(row1);
                    table2.Rows.Add(row2);
                    table3.Rows.Add(row3);
                    table4.Rows.Add(row4);

                    continue;
                }
                else
                {
                    continue;
                }

            }

        }

        private DataTable tenDays()
        {
            
            // Create an empty table.
            DataTable table = new DataTable("记忆度低");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }


                row["Value"] = manager.lastingTime(i, 0);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable thirtyDays()
        {
            
            // Create an empty table.
            DataTable table = new DataTable("记忆度中");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = manager.lastingTime(i, 1);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable sistyDays()
        {
            
            // Create an empty table.
            DataTable table = new DataTable("记忆度高");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // 获取今天是第n天
            int n;
            n = manager.getLearningDate();

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = manager.lastingTime(i, 3);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable nintyDays()
        {
            
            // Create an empty table.
            DataTable table = new DataTable("记忆度极高");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row;

            for (int i = n; i >= 0; i--)
            {
                row = table.NewRow();
                if (i == 0)
                {
                    row["Time"] = "今天";
                }
                else if (i == 1)
                {
                    row["Time"] = "昨天";
                }
                else if (i == 2)
                {
                    row["Time"] = "前天";
                }
                else
                {
                    row["Time"] = i + "天前";
                }

                row["Value"] = manager.lastingTime(i, 6);

                table.Rows.Add(row);
            }

            return table;
        }

    }
}
