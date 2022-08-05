
namespace LSR
{
    partial class FunView4
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunView4));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.svgImageBox2 = new DevExpress.XtraEditors.SvgImageBox();
            this.svgImageBox3 = new DevExpress.XtraEditors.SvgImageBox();
            this.lineChart = new DevExpress.XtraCharts.ChartControl();
            this.svgImageBox4 = new DevExpress.XtraEditors.SvgImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(123, 640);
            this.svgImageBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(279, 273);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 5;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // svgImageBox2
            // 
            this.svgImageBox2.Location = new System.Drawing.Point(373, -30);
            this.svgImageBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.svgImageBox2.Name = "svgImageBox2";
            this.svgImageBox2.Size = new System.Drawing.Size(599, 227);
            this.svgImageBox2.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Squeeze;
            this.svgImageBox2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox2.SvgImage")));
            this.svgImageBox2.TabIndex = 6;
            this.svgImageBox2.Text = "svgImageBox2";
            // 
            // svgImageBox3
            // 
            this.svgImageBox3.ImageAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.svgImageBox3.Location = new System.Drawing.Point(538, 640);
            this.svgImageBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.svgImageBox3.Name = "svgImageBox3";
            this.svgImageBox3.Size = new System.Drawing.Size(279, 273);
            this.svgImageBox3.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
            this.svgImageBox3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox3.SvgImage")));
            this.svgImageBox3.TabIndex = 7;
            this.svgImageBox3.Text = "svgImageBox3";
            // 
            // lineChart
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.lineChart.Diagram = xyDiagram1;
            this.lineChart.IndicatorsPaletteName = "Northern Lights";
            this.lineChart.Location = new System.Drawing.Point(123, 201);
            this.lineChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineChart.Name = "lineChart";
            this.lineChart.PaletteName = "Red Violet";
            series1.Name = "Series 1";
            series1.View = lineSeriesView1;
            this.lineChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.lineChart.Size = new System.Drawing.Size(1122, 433);
            this.lineChart.TabIndex = 8;
            // 
            // svgImageBox4
            // 
            this.svgImageBox4.Location = new System.Drawing.Point(959, 638);
            this.svgImageBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.svgImageBox4.Name = "svgImageBox4";
            this.svgImageBox4.Size = new System.Drawing.Size(286, 271);
            this.svgImageBox4.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
            this.svgImageBox4.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox4.SvgImage")));
            this.svgImageBox4.TabIndex = 9;
            this.svgImageBox4.Text = "svgImageBox4";
            // 
            // FunView4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.svgImageBox4);
            this.Controls.Add(this.lineChart);
            this.Controls.Add(this.svgImageBox2);
            this.Controls.Add(this.svgImageBox3);
            this.Controls.Add(this.svgImageBox1);
            this.Name = "FunView4";
            this.Size = new System.Drawing.Size(1338, 963);
            this.Load += new System.EventHandler(this.FunView4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox2;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox3;
        private DevExpress.XtraCharts.ChartControl lineChart;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox4;
    }
}
