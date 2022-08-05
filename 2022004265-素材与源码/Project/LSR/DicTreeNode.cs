using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSR
{
    //树结点类型
    class DicTreeNode
    {
        //子节点ID字段
        private int m_ID = 0;

        //父节点ID字段
        private int m_ParentID;

        // 类别/应用名称字段
        private string m_name = string.Empty;

        public int ID
        {
            get

            {
                return m_ID;
            }

            set
            {
                m_ID = value;
            }
        }

        public int ParentID
        {
            get
            {
                return m_ParentID;
            }

            set
            {
                m_ParentID = value;
            }
        }


        public string name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }


    }
}
