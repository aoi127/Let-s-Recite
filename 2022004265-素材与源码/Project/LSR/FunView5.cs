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
    public partial class FunView5 : DevExpress.XtraEditors.XtraUserControl
    {
        public FunView5()
        {
            InitializeComponent();
        }

        private Dictionary<int, int> remember_dic = new Dictionary<int, int>();
        private Dictionary<int, int> familiar_dic = new Dictionary<int, int>();
        private Dictionary<int, int> blurred_dic = new Dictionary<int, int>();
        private Dictionary<int, int> forgotton_dic = new Dictionary<int, int>();
        private void FunView5_Load(object sender, EventArgs e)
        {
            SqliteManager sqliteManager = new SqliteManager();
            int n = sqliteManager.getLearningDate();
            for(int i=0;i<n+1;i++)
            {
                sqliteManager.studyIdentity(i);
            }
            remember_dic = sqliteManager.Remember;
            familiar_dic = sqliteManager.Familiar;
            blurred_dic = sqliteManager.Blurred;
            forgotton_dic = sqliteManager.Forgotton;

            // Create a line series.
            Series series1 = new Series("熟知", ViewType.StackedBar);
            Series series2 = new Series("认识", ViewType.StackedBar);
            Series series3 = new Series("模糊", ViewType.StackedBar);
            Series series4 = new Series("忘记", ViewType.StackedBar);

            // 获取词典中的值， key=date value=对应的单词数量
            // Add points to it.
            // 忘记
            series1.DataSource = remember();

            // Specify data members to bind the series.
            series1.ArgumentScaleType = ScaleType.Auto;
            series1.ArgumentDataMember = "Time";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "Value" });

            series2.DataSource = familiar();

            // Specify data members to bind the series.
            series2.ArgumentScaleType = ScaleType.Auto;
            series2.ArgumentDataMember = "Time";
            series2.ValueScaleType = ScaleType.Numerical;
            series2.ValueDataMembers.AddRange(new string[] { "Value" });

            series3.DataSource = blurred();

            // Specify data members to bind the series.
            series3.ArgumentScaleType = ScaleType.Auto;
            series3.ArgumentDataMember = "Time";
            series3.ValueScaleType = ScaleType.Numerical;
            series3.ValueDataMembers.AddRange(new string[] { "Value" });

            series4.DataSource = forgotten();

            // Specify data members to bind the series.
            series4.ArgumentScaleType = ScaleType.Auto;
            series4.ArgumentDataMember = "Time";
            series4.ValueScaleType = ScaleType.Numerical;
            series4.ValueDataMembers.AddRange(new string[] { "Value" });

            // Add both series to the chart.
            barChart.Series.AddRange(new Series[] { series1, series2, series3, series4 });

            // Access the type-specific options of the diagram.
            ((XYDiagram)barChart.Diagram).EnableAxisXZooming = true;

            // Hide the legend (if necessary).
            barChart.Legend.Visible = true;

            // Add a title to the chart (if necessary).
            barChart.Titles.Add(new ChartTitle());
            barChart.Titles[0].Text = "学习情况";

            // Add the chart to the form.
            //barChart.Dock = DockStyle.Fill;
            this.Controls.Add(barChart);
        }

        //从词典中获取键值对，date需要处理成“n天前”

        private DataTable remember()
        {
            DataTable table = new DataTable("熟知");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            if(remember_dic != null)
            {
                var dicSort = from pair in remember_dic orderby pair.Key descending select pair; //以字典Key值逆序排序
                foreach (KeyValuePair<int, int> kvp1 in dicSort)
                {
                    DataRow row = table.NewRow();
                    if (kvp1.Key == 0)
                    {
                        row["Time"] = "今天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if (kvp1.Key == 1)
                    {
                        row["Time"] = "昨天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if (kvp1.Key == 2)
                    {
                        row["Time"] = "前天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else
                    {
                        row["Time"] = kvp1.Key + "天前";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                }
            }
            
            return table;
        }

        private DataTable familiar()
        {
            // Create an empty table.
            DataTable table = new DataTable("认识");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));


            if(familiar_dic != null)
            {
                 var dicSort = from pair in familiar_dic orderby pair.Key descending select pair; //以字典Key值逆序排序

                 foreach (KeyValuePair<int, int> kvp1 in dicSort)
                 {
                    // Add data rows to the table.
                    DataRow row = table.NewRow();
                    if (kvp1.Key == 0)
                    {
                        row["Time"] = "今天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if (kvp1.Key == 1)
                    {
                        row["Time"] = "昨天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if (kvp1.Key == 2)
                    {
                        row["Time"] = "前天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else
                    {
                        row["Time"] = kvp1.Key + "天前";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                }
            }
            

            return table;
        }

        private DataTable blurred()
        {
            // Create an empty table.
            DataTable table = new DataTable("模糊");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            if(blurred_dic != null)
            {
                var dicSort = from pair in blurred_dic orderby pair.Key descending select pair; //以字典Key值逆序排序

                foreach (KeyValuePair<int, int> kvp1 in dicSort)
                {
                    DataRow row = table.NewRow();
                    if (kvp1.Key == 0)
                    {
                        row["Time"] = "今天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if(kvp1.Key == 1)
                    {
                        row["Time"] = "昨天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if (kvp1.Key == 2)
                    {
                        row["Time"] = "前天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else
                    {
                        row["Time"] = kvp1.Key + "天前";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    
                }
            }
            return table;
        }

        private DataTable forgotten()
        {
            // Create an empty table.
            DataTable table = new DataTable("");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));


            if(forgotton_dic != null)
            {
                var dicSort = from pair in forgotton_dic orderby pair.Key descending select pair; //以字典Key值逆序排序

                foreach (KeyValuePair<int, int> kvp1 in dicSort)
                {
                    DataRow row = table.NewRow();
                    if (kvp1.Key == 0)
                    {
                        row["Time"] = "今天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if (kvp1.Key == 1)
                    {
                        row["Time"] = "昨天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else if (kvp1.Key == 2)
                    {
                        row["Time"] = "前天";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                    else
                    {
                        row["Time"] = kvp1.Key + "天前";
                        row["Value"] = kvp1.Value;
                        table.Rows.Add(row);
                    }
                }
            }
            

            return table;
        }
    }
}
