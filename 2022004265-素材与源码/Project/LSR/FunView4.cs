using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
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
    public partial class FunView4 : DevExpress.XtraEditors.XtraUserControl
    {
        
        public FunView4()
        {
            InitializeComponent();
        }

        private void FunView4_Load(object sender, EventArgs e)
        {
            // Create a line series.
            Series series1 = new Series("艾宾浩斯遗忘曲线", ViewType.Line);
            Series series2 = new Series("我的遗忘曲线", ViewType.Line);


            // Add points to it.
            //遗忘曲线
            series1.DataSource = forgottenCurve();

            // Specify data members to bind the series.
            series1.ArgumentScaleType = ScaleType.Auto;
            series1.ArgumentDataMember = "Time";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "Value" });

           

            // Access the view-type-specific options of the series.
            ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Triangle;
            ((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

            // 遗忘率
            series2.DataSource = forgottenRate();

            series2.ArgumentScaleType = ScaleType.Auto;
            series2.ArgumentDataMember = "Time";
            series2.ValueScaleType = ScaleType.Numerical;
            series2.ValueDataMembers.AddRange(new string[] { "Value" });

            // Add the series to the chart.
            lineChart.Series.AddRange(new Series[] {
                series1 ,
                series2 
            });

            // Access the type-specific options of the diagram.
            ((XYDiagram)lineChart.Diagram).EnableAxisXZooming = false;

            // Hide the legend (if necessary).
            lineChart.Legend.Visible = false;

            // Add a title to the chart (if necessary).
            lineChart.Titles.Add(new ChartTitle());
            lineChart.Titles[0].Text = "遗忘曲线";

            // Add the chart to the form.
            //lineChart.Dock = DockStyle.Fill;
            this.Controls.Add(lineChart);
        }

        //遗忘曲线
        private DataTable forgottenCurve()
        {
            SqliteManager sqliteManager = new SqliteManager();
            // Create an empty table.
            DataTable table = new DataTable("艾宾浩斯遗忘曲线");
            int n = sqliteManager.getLearningDate();

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // Add data rows to the table.
            DataRow row = table.NewRow();
            row["Time"] = "第1天";
            row["Value"] = 100;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "第2天";
            row["Value"] = 33;
            table.Rows.Add(row);

            for (int i = 3; i <= n+1; i++)
            {
                row = table.NewRow();
                row["Time"] = "第"+ i + "天";
                
                if (i<=90)
                {
                    row["Value"] = Math.Round((0.276 * Math.Pow(0.991, i))*100,2); //保留两位 四舍五入
                }
                else if(i>90)
                {
                    row["Value"] = Math.Round((0.185 - 0.000369 * i)*100, 2);
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable forgottenRate()
        {
            SqliteManager sqliteManager = new SqliteManager();
            int n = sqliteManager.getLearningDate();

            // Create an empty table.
            DataTable table = new DataTable("我的遗忘曲线");

            // Add two columns to the table.
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("Value", typeof(decimal));

            // 遗忘率=没有遗忘的单词/总学习单词*100%
            // Add data rows to the table.
            for (int i=1;i<= n+1;i++)
            {
                DataRow row = table.NewRow();
                row["Time"] = "第" + i + "天";

                double rate;
                if (i == 1)
                {
                    row["Value"] = 100;
                    table.Rows.Add(row);
                    continue;
                }

                // 计算遗忘率
                int unforgotton_word = sqliteManager.unForgottenRate(i);
                int learning_word_num = sqliteManager.getLearningNumDay(i);
                // if(learning_word_num == 0)
                // {
                //     rate =    
                // }
                rate = Math.Round((double)unforgotton_word / (double)learning_word_num *100,2);
                Console.WriteLine("遗忘率=", rate);
                row["Value"] = rate;
                table.Rows.Add(row);
            }

            return table;
        }

    }
}
