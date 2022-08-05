using DevExpress.XtraBars;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSR
{
    public partial class MainView : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private SqliteManager manager = new SqliteManager();
        public static double Kc = 1.0;
        FunView1 view1;
        FunView2 view2;
        FunView3 view3;
        FunView7 view7;
        public MainView()
        {
            InitializeComponent();
            //manager.setDate();
            manager.refreshKc();
            manager.refreshRecitedWord();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
            view7 = new FunView7(manager);
            CreateDesktopShortcut("Let's Recite");
        }
        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
        }

        private void newWord_Click(object sender, EventArgs e)
        {
            view1 = new FunView1(manager);
            view1.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view1);
        }

        private void reviewWord_Click(object sender, EventArgs e)
        {
            view2 = new FunView2(manager);
            view2.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view2);
        }

        private void selectDic_Click(object sender, EventArgs e)
        {
            view3 = new FunView3(manager);
            view3.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view3);
        }

        private void regret_Click(object sender, EventArgs e)
        {
            FunView4 view4 = new FunView4();
            view4.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view4);
        }

        private void learnCondition_Click(object sender, EventArgs e)
        {
            FunView5 view5 = new FunView5();
            view5.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view5);
        }

        private void sustain_Click(object sender, EventArgs e)
        {
            FunView6 view6 = new FunView6(manager);
            view6.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view6);
        }

        private void set_Click(object sender, EventArgs e)
        {
            view7.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view7);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            view1 = new FunView1(manager);
            view1.Show();
            mView.Controls.Clear();
            mView.Controls.Add(view1);
        }

        /// <summary>
        /// 创建桌面快捷方式
        /// </summary>
        /// <param name="deskTop">桌面的路径</param>
        /// <param name="FileName">文件的名称</param>
        /// <param name="exePath">EXE的路径</param>
        /// <returns>成功或失败</returns>
        public bool CreateDesktopShortcut(string FileName)
        {
            try
            {
                string deskTop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                if (System.IO.File.Exists(deskTop + FileName + ".lnk"))  //
                {
                    System.IO.File.Delete(deskTop + FileName + ".lnk");//删除原来的桌面快捷键方式
                }
                WshShell shell = new WshShell();

                //快捷键方式创建的位置、名称
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(deskTop + FileName + ".lnk");
                string exePath = this.GetType().Assembly.Location; //exePath
                string iconPath = exePath.Substring(0,38)+"\\imgs\\R.ico";
                shortcut.TargetPath = exePath; //目标文件
                                               //该属性指定应用程序的工作目录，当用户没有指定一个具体的目录时，快捷方式的目标应用程序将使用该属性所指定的目录来装载或保存文件。
                shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
                shortcut.WindowStyle = 1; //目标应用程序的窗口状态分为普通、最大化、最小化【1,3,7】
                shortcut.Description = FileName; //描述
                shortcut.IconLocation = iconPath;  //快捷方式图标
                shortcut.Arguments = "";
                shortcut.Save(); //必须调用保存快捷才成创建成功
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
