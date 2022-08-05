
namespace LSR
{
    partial class MainView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.mView = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControlSeparator4 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.set = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator3 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.regret = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.learnCondition = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.sustain = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator2 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.selectDic = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.newWord = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.reviewWord = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1408, 38);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(LSR.MainViewModel);
            // 
            // mView
            // 
            this.mView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mView.Location = new System.Drawing.Point(60, 38);
            this.mView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mView.Name = "mView";
            this.mView.Size = new System.Drawing.Size(1348, 966);
            this.mView.TabIndex = 0;
            // 
            // accordionControlSeparator4
            // 
            this.accordionControlSeparator4.Name = "accordionControlSeparator4";
            // 
            // set
            // 
            this.set.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("set.ImageOptions.SvgImage")));
            this.set.Name = "set";
            this.set.Text = "设置";
            this.set.Click += new System.EventHandler(this.set_Click);
            // 
            // accordionControlSeparator3
            // 
            this.accordionControlSeparator3.Name = "accordionControlSeparator3";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.regret,
            this.learnCondition,
            this.sustain});
            this.accordionControlElement3.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Left),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl)});
            this.accordionControlElement3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement3.ImageOptions.SvgImage")));
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "统计";
            // 
            // regret
            // 
            this.regret.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("regret.ImageOptions.SvgImage")));
            this.regret.Name = "regret";
            this.regret.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.regret.Text = "遗忘曲线";
            this.regret.Click += new System.EventHandler(this.regret_Click);
            // 
            // learnCondition
            // 
            this.learnCondition.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("learnCondition.ImageOptions.SvgImage")));
            this.learnCondition.Name = "learnCondition";
            this.learnCondition.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.learnCondition.Text = "学习情况";
            this.learnCondition.Click += new System.EventHandler(this.learnCondition_Click);
            // 
            // sustain
            // 
            this.sustain.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sustain.ImageOptions.SvgImage")));
            this.sustain.Name = "sustain";
            this.sustain.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.sustain.Text = "记忆持久度";
            this.sustain.Click += new System.EventHandler(this.sustain_Click);
            // 
            // accordionControlSeparator2
            // 
            this.accordionControlSeparator2.Name = "accordionControlSeparator2";
            // 
            // selectDic
            // 
            this.selectDic.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("selectDic.ImageOptions.SvgImage")));
            this.selectDic.Name = "selectDic";
            this.selectDic.Text = "选词";
            this.selectDic.Click += new System.EventHandler(this.selectDic_Click);
            // 
            // accordionControlSeparator1
            // 
            this.accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.newWord,
            this.reviewWord});
            this.accordionControlElement1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement1.ImageOptions.SvgImage")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "单词背记";
            // 
            // newWord
            // 
            this.newWord.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("newWord.ImageOptions.SvgImage")));
            this.newWord.Name = "newWord";
            this.newWord.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.newWord.Text = "新单词";
            this.newWord.Click += new System.EventHandler(this.newWord_Click);
            // 
            // reviewWord
            // 
            this.reviewWord.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("reviewWord.ImageOptions.SvgImage")));
            this.reviewWord.Name = "reviewWord";
            this.reviewWord.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.reviewWord.Text = "复习";
            this.reviewWord.Click += new System.EventHandler(this.reviewWord_Click);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accordionControl1.Appearance.AccordionControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.accordionControl1.Appearance.AccordionControl.Options.UseFont = true;
            this.accordionControl1.Appearance.AccordionControl.Options.UseForeColor = true;
            this.accordionControl1.Appearance.Group.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.73109F, System.Drawing.FontStyle.Bold);
            this.accordionControl1.Appearance.Group.Default.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Default.Font = new System.Drawing.Font("楷体", 13.91597F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accordionControl1.Appearance.Item.Default.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.accordionControl1.Appearance.Item.Default.Options.UseFont = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlSeparator1,
            this.selectDic,
            this.accordionControlSeparator2,
            this.accordionControlElement3,
            this.accordionControlSeparator3,
            this.set,
            this.accordionControlSeparator4});
            this.accordionControl1.Location = new System.Drawing.Point(0, 38);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(60, 966);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 1004);
            this.ControlContainer = this.mView;
            this.Controls.Add(this.mView);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MainView.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Let\'s Recite";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mView;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement newWord;
        private DevExpress.XtraBars.Navigation.AccordionControlElement reviewWord;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement selectDic;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement regret;
        private DevExpress.XtraBars.Navigation.AccordionControlElement learnCondition;
        private DevExpress.XtraBars.Navigation.AccordionControlElement sustain;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement set;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator4;
    }
}

