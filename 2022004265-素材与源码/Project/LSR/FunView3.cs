using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace LSR
{
    public partial class FunView3 : DevExpress.XtraEditors.XtraUserControl
    {
        private SqliteManager manager;  //数据库操作对象
        private int restWords;   //剩余单词数

        public FunView3(SqliteManager main_manager)
        {
            bool is_set = false; 
            int set_min_quan = 0;
            int total = 0;
            int have_planed;
            int review;
            InitializeComponent();
            manager = main_manager;

            this.dicTreeList.OptionsView.ShowCheckBoxes = true;// //是否显示CheckBox

            this.dicTreeList.OptionsBehavior.AllowIndeterminateCheckState = true;// //设置节点是否有中间状态，即一部分子节点选中，一部分子节点没有选中

            dicTreeList.RowHeight = 25;

            SQLiteDataReader date_reader = manager.getDateReader();
            while(date_reader.Read())
            {
                if (Regex.Match(date_reader["Date"].ToString(), @"[\S]+").ToString() == (Regex.Match(DateTime.Now.Date.ToString(), @"[\S]+").ToString()))
                {
                    restWords = int.Parse(date_reader["RestWords"].ToString());
                    is_set = true;
                }
            }
            if (!is_set)
            {
                SQLiteDataReader reader = manager.getInfo();
                if (reader.Read())
                {
                    set_min_quan = (int)(int.Parse(reader["EveryDaySetQuan"].ToString()) * double.Parse(reader["LowestPercent"].ToString()) / 100);
                    total = int.Parse(reader["EveryDaySetQuan"].ToString());
                }
                have_planed = main_manager.getPlannedCount();
                review = manager.getForgetNum();
                restWords = (total - review - have_planed) > set_min_quan ? (total - review - have_planed) : set_min_quan;
                manager.setRestWords(restWords);
            }
            
            restQuan.Text = restWords.ToString();

            //鼠标经过label时变为手形
            this.randomLbl.Cursor = Cursors.Hand;
            this.confirmLbl.Cursor = Cursors.Hand;

            //List初始化
            for (int i = 0; i < 8; i++)
            {
                List<int> a = new List<int>();
                learned_position.Add(a);
            }
        }

        private void FunView3_Load(object sender, EventArgs e)
        {
            refreshTree();
        }

        private void refreshTree()
        {
            List<DicTreeNode> word_list = new List<DicTreeNode>();//声明一个泛型List存放结点信息
            int word_id = -1;
            for (int i = 1; i <= 8; i++)
            {
                //获取单词表DataReader
                SQLiteDataReader word_reader = manager.GetWordDataReader(i);

                //读取单词表数据并存入List
                while (word_reader.Read())
                {
                    DicTreeNode node = new DicTreeNode();
                    node.ID = word_id;
                    node.name = word_reader["Word"].ToString();
                    node.ParentID = int.Parse(word_reader["DicCate"].ToString());
                    word_list.Add(node);
                    word_id--;
                }
            }

            //获取DicList表的DataReader
            SQLiteDataReader dic_reader = manager.GetCateDataReader();
            //读取AppCate表数据并存入List
            while (dic_reader.Read())
            {
                DicTreeNode node = new DicTreeNode();
                node.ID = int.Parse(dic_reader["DicCate"].ToString());
                node.name = dic_reader["Name"].ToString();
                node.ParentID = 0;   //类型节点为顶级节点
                word_list.Add(node);
            }

            this.dicTreeList.DataSource = DataTableConvert(word_list);//将word_list数据转换为DataTable形式后绑定到dicTreeList上
            this.dicTreeList.RefreshDataSource();//刷新dicTreeList
        }

        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.ForeColor = Color.SteelBlue;
            Font font = new Font("黑体", 13);
            e.Appearance.Font = new Font(font, FontStyle.Bold);
        }

        //将数据源转换成DataTable格式
        private DataTable DataTableConvert(List<DicTreeNode> Array)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("ParentID", typeof(int));

            for (int i = 0; i < Array.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = Array[i].ID;
                dr["name"] = Array[i].name.ToString();
                dr["ParentID"] = Array[i].ParentID;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        private bool isLearned = false;
        // 节点选中前事件
        private void dicTreeList_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 && (e.PrevState == CheckState.Indeterminate))   //如选中已学习单词
            {
                isLearned = true;
                return;
            }
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);   //状态变化
            //实时更新已勾选单词的显示内容
            if (e.Node.Nodes.Count == 0 && !(e.PrevState == CheckState.Checked))
                wordQuan.Text = (int.Parse(wordQuan.Text) + 1).ToString();
            else if (e.Node.Nodes.Count == 0 && (e.PrevState == CheckState.Checked))
                wordQuan.Text = (int.Parse(wordQuan.Text) - 1).ToString();
            isLearned = false;

        }

        // 节点选中后事件
        private void dicTreeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            bool isEmpty = true;
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
            if (isLearned)   //已规划的结点状态不可变
                e.Node.CheckState = CheckState.Indeterminate;
            if(e.Node.Nodes.Count == 0)   //当改变子结点状态时，检查其父结点的所有子结点是否都未被选中
            {
                foreach (TreeListNode node in e.Node.ParentNode.Nodes)
                {
                    if (node.CheckState == CheckState.Checked)
                        isEmpty = false;
                }
                if (isEmpty)
                    e.Node.ParentNode.CheckState = CheckState.Unchecked;
            }
        }


        // 设置父节点的状态
        private void SetCheckedParentNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private List<List<int>> learned_position = new List<List<int>>();  //记录已学单词序号
        private void setLearnedWordState(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            int dic_cate;
            switch (e.Node.Id)
            {
                case 57529: dic_cate = 0; break;
                case 57530: dic_cate = 1; break;
                case 57531: dic_cate = 2; break;
                case 57532: dic_cate = 3; break;
                case 57533: dic_cate = 4; break;
                case 57534: dic_cate = 5; break;
                case 57535: dic_cate = 6; break;
                case 57536: dic_cate = 7; break;
                default: dic_cate = 0; break;
            }
            List<string> word = new List<string>();
            DataRowView drv = dicTreeList.GetDataRecordByNode(e.Node) as DataRowView;
            string name = drv["name"].ToString();
            SQLiteDataReader reader = manager.GetLearnedWord(name);
            while (reader.Read())
            {
                word.Add(reader["Word"].ToString());
            }
            int cnt = 0;
            int position = 0;
            foreach (TreeListNode node in e.Node.Nodes)
            {
                if (cnt >= word.Count())
                    break;
                DataRowView drv2 = dicTreeList.GetDataRecordByNode(node) as DataRowView;
                if (drv2 != null)
                {
                    if (drv2["name"].ToString() == word[cnt])
                    {
                        node.CheckState = CheckState.Indeterminate;
                        learned_position[dic_cate].Add(position);   //记录单词结点序号
                        cnt++;
                    }
                }
                position++;
            }
        }

        //获取选中的根节点数据
        private List<string> dic_name = new List<string>(); //声明list存储选中项的name值
        private TreeListNode select_dic_node;
        private void GetCheckedRootName(TreeListNode parent_node)
        {
            //选中子节点为空的父节点时，不进行信息存储
            if ((parent_node).Nodes.Count == 0)
            {
                return;
            }
            //存在子节点时，存储词典名称
            else
            {
                if (parent_node.CheckState == CheckState.Checked || parent_node.CheckState == CheckState.Indeterminate)
                {
                    select_dic_node = parent_node;
                    DataRowView drv = dicTreeList.GetDataRecordByNode(parent_node) as DataRowView;
                    if (drv != null)
                    {
                        string name = drv["name"].ToString();
                        dic_name.Add(name);
                    }
                }
            }
        }

        //获取选中的子结点数据
        private List<string> word_list = new List<string>(); //声明list存储选中项的name值
        private void GetCheckedWord(TreeListNode parent_node)
        {
            word_list.Clear();
            //选中子节点为空的父节点时，不进行信息存储
            if ((parent_node).Nodes.Count == 0)
            {
                return;
            }
            //存在子节点时，存储词典名称
            else
            {
                foreach (TreeListNode node in parent_node.Nodes)
                {
                    if (node.CheckState == CheckState.Checked)
                    {
                        DataRowView drv = dicTreeList.GetDataRecordByNode(node) as DataRowView;
                        if (drv != null)
                        {
                            string name = drv["name"].ToString();
                            word_list.Add(name);
                        }
                    }
                }
            }
        }

        private void ClearCheckedState(TreeListNode parent_node)
        {
            if ((parent_node).Nodes.Count == 0)
            {
                return;
            }
            else
            {
                foreach (TreeListNode node in parent_node.Nodes)
                {
                    if (node.Nodes.Count == 0 && node.CheckState == CheckState.Checked)   //已规划的结点状态不可变,仅勾选状态的结点被重置           
                        node.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void RandomSelect_Click(object sender, EventArgs e)
        {
            int quan = restWords;
            List<int> selected_word_list = new List<int>();
            int cnt = 1;   //记录生成的随机数数量
            int dic_cate;   //记录选择的词典
            dic_name.Clear();   //清空选中词典记录
            //获取所有选中的根节点的name
            if (dicTreeList.Nodes.Count > 0)
            {
                foreach (TreeListNode parent in dicTreeList.Nodes)
                {
                    GetCheckedRootName(parent);
                }
            }
            if (dic_name.Count() > 1)
            {
                MessageBox.Show("不可同时勾选多个词典");
                return;
            }
            else if (dic_name.Count == 0)
            {
                MessageBox.Show("请勾选词典");
                return;
            }

            //重置选中状态
            if (dicTreeList.Nodes.Count > 0)
            {
                foreach (TreeListNode parent in dicTreeList.Nodes)
                {
                    parent.CheckState = CheckState.Unchecked;
                    ClearCheckedState(parent);
                }
            }
            select_dic_node.CheckState = CheckState.Indeterminate;
            switch (select_dic_node.Id)
            {
                case 57529: dic_cate = 0; break;
                case 57530: dic_cate = 1; break;
                case 57531: dic_cate = 2; break;
                case 57532: dic_cate = 3; break;
                case 57533: dic_cate = 4; break;
                case 57534: dic_cate = 5; break;
                case 57535: dic_cate = 6; break;
                case 57536: dic_cate = 7; break;
                default: dic_cate = 0; break;
            }

            //随机选择单词
            //生成范围内不相同的quan个随机数
            Random random = new Random();
            while (cnt <= quan)
            {
                int a = random.Next(0, select_dic_node.Nodes.Count);
                if (!learned_position[dic_cate].Contains(a) && !selected_word_list.Contains(a))   //不勾选已学单词且不重复勾选同一单词
                {
                    select_dic_node.Nodes[a].CheckState = CheckState.Checked;
                    selected_word_list.Add(a);
                    cnt++;
                }
            }

            wordQuan.Text = quan.ToString();
        }

        //确认选择
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            dic_name.Clear();
            //获取所有选中的根节点的name
            if (dicTreeList.Nodes.Count > 0)
            {
                foreach (TreeListNode parent in dicTreeList.Nodes)
                {
                    GetCheckedRootName(parent);
                }
            }
            if (dic_name.Count() > 1)
            {
                MessageBox.Show("不可同时勾选多个词典");
                return;
            }
            else if (dic_name.Count == 0)
            {
                MessageBox.Show("请勾选词典");
                return;
            }
            DataRowView drv = dicTreeList.GetDataRecordByNode(select_dic_node) as DataRowView;
            string name = drv["name"].ToString();
            //获取选择信息
            GetCheckedWord(select_dic_node);
            //导入学习规划
            if(restWords >= word_list.Count)
            {
                manager.setPlanedWord(name, word_list);   //将选择单词的isPlaned改为1
                restWords -= word_list.Count;   
                restQuan.Text = restWords.ToString();
                manager.updateRestWords(restWords);   //更新单词余量
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("所选词汇数超过今日剩余所需学习数量，请重新勾选");
            }
        }
    }
}