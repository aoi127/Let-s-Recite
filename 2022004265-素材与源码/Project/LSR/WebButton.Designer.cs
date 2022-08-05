
namespace LSR
{
    partial class WebButton
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebButton));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions8 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions9 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions10 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions11 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions12 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "词典";
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.AllowGlyphSkinning = false;
            this.windowsUIButtonPanel1.AppearanceButton.Normal.BorderColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel1.AppearanceButton.Normal.Options.UseBorderColor = true;
            windowsUIButtonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions7.Image")));
            windowsUIButtonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions8.Image")));
            windowsUIButtonImageOptions9.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions9.Image")));
            windowsUIButtonImageOptions10.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions10.Image")));
            windowsUIButtonImageOptions11.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions11.Image")));
            windowsUIButtonImageOptions12.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions12.Image")));
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("有道", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("必应", true, windowsUIButtonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("柯林斯", true, windowsUIButtonImageOptions9, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("剑桥", true, windowsUIButtonImageOptions10, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("牛津", true, windowsUIButtonImageOptions11, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("韦氏", true, windowsUIButtonImageOptions12, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(2, 28);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(57, 407);
            this.windowsUIButtonPanel1.TabIndex = 1;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            // 
            // WebButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.windowsUIButtonPanel1);
            this.Controls.Add(this.labelControl1);
            this.Name = "WebButton";
            this.Size = new System.Drawing.Size(48, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
    }
}
