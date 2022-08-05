
namespace LSR
{
    partial class FunView3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunView3));
            this.dicTreeList = new DevExpress.XtraTreeList.TreeList();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.wordQuan = new System.Windows.Forms.Label();
            this.confirmLbl = new DevExpress.XtraEditors.LabelControl();
            this.randomLbl = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.svgImageBox2 = new DevExpress.XtraEditors.SvgImageBox();
            this.svgImageBox3 = new DevExpress.XtraEditors.SvgImageBox();
            this.restQuan = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dicTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dicTreeList
            // 
            this.dicTreeList.Location = new System.Drawing.Point(19, 85);
            this.dicTreeList.Name = "dicTreeList";
            this.dicTreeList.Size = new System.Drawing.Size(1014, 859);
            this.dicTreeList.TabIndex = 0;
            this.dicTreeList.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.setLearnedWordState);
            this.dicTreeList.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.dicTreeList_BeforeCheckNode);
            this.dicTreeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.dicTreeList_AfterCheckNode);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 16.12605F);
            this.label1.Location = new System.Drawing.Point(440, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "词汇选择";
            // 
            // labelControl1
            // 
            this.labelControl1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl1.ImageOptions.SvgImage")));
            this.labelControl1.Location = new System.Drawing.Point(369, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 40);
            this.labelControl1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(65, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "已选择单词数：";
            // 
            // wordQuan
            // 
            this.wordQuan.AutoSize = true;
            this.wordQuan.Font = new System.Drawing.Font("黑体", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordQuan.Location = new System.Drawing.Point(220, 51);
            this.wordQuan.Name = "wordQuan";
            this.wordQuan.Size = new System.Drawing.Size(19, 20);
            this.wordQuan.TabIndex = 5;
            this.wordQuan.Text = "0";
            // 
            // confirmLbl
            // 
            this.confirmLbl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("confirmLbl.ImageOptions.SvgImage")));
            this.confirmLbl.Location = new System.Drawing.Point(858, 26);
            this.confirmLbl.Name = "confirmLbl";
            this.confirmLbl.Size = new System.Drawing.Size(40, 40);
            this.confirmLbl.TabIndex = 7;
            this.confirmLbl.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // randomLbl
            // 
            this.randomLbl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("randomLbl.ImageOptions.SvgImage")));
            this.randomLbl.Location = new System.Drawing.Point(662, 26);
            this.randomLbl.Name = "randomLbl";
            this.randomLbl.Size = new System.Drawing.Size(40, 40);
            this.randomLbl.TabIndex = 8;
            this.randomLbl.Click += new System.EventHandler(this.RandomSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(895, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "确认选择";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(708, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "随机选择";
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(1051, 63);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(284, 244);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 11;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // svgImageBox2
            // 
            this.svgImageBox2.Location = new System.Drawing.Point(1051, 682);
            this.svgImageBox2.Name = "svgImageBox2";
            this.svgImageBox2.Size = new System.Drawing.Size(284, 262);
            this.svgImageBox2.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
            this.svgImageBox2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox2.SvgImage")));
            this.svgImageBox2.TabIndex = 12;
            this.svgImageBox2.Text = "svgImageBox2";
            // 
            // svgImageBox3
            // 
            this.svgImageBox3.Location = new System.Drawing.Point(1051, 348);
            this.svgImageBox3.Name = "svgImageBox3";
            this.svgImageBox3.Size = new System.Drawing.Size(284, 268);
            this.svgImageBox3.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
            this.svgImageBox3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox3.SvgImage")));
            this.svgImageBox3.TabIndex = 13;
            this.svgImageBox3.Text = "svgImageBox3";
            // 
            // restQuan
            // 
            this.restQuan.AutoSize = true;
            this.restQuan.Font = new System.Drawing.Font("黑体", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restQuan.Location = new System.Drawing.Point(268, 18);
            this.restQuan.Name = "restQuan";
            this.restQuan.Size = new System.Drawing.Size(19, 20);
            this.restQuan.TabIndex = 15;
            this.restQuan.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(45, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "今日还需学习新单词数：";
            // 
            // FunView3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.restQuan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.svgImageBox3);
            this.Controls.Add(this.svgImageBox2);
            this.Controls.Add(this.svgImageBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.randomLbl);
            this.Controls.Add(this.confirmLbl);
            this.Controls.Add(this.wordQuan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dicTreeList);
            this.Name = "FunView3";
            this.Size = new System.Drawing.Size(1338, 963);
            this.Load += new System.EventHandler(this.FunView3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dicTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList dicTreeList;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label wordQuan;
        private DevExpress.XtraEditors.LabelControl confirmLbl;
        private DevExpress.XtraEditors.LabelControl randomLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox2;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox3;
        private System.Windows.Forms.Label restQuan;
        private System.Windows.Forms.Label label6;
    }
}
