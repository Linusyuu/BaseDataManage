using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.zstu.BaseForm
{
    public partial class FBaseDataManage : Form
    {
        public FBaseDataManage()
        {
            InitializeComponent();
        }

        private void FBaseDataManage_Load(object sender, EventArgs e)
        {
            DoRefresh();
            //CreateComboDataTree();
            rbSing.Enabled = false;
            rbMult.Enabled = false;
        }

        public void DoRefresh()
        {
            try
            {
                CreateComboDataTree();
            }
            catch
            {
                MessageBox.Show("数据库连接失败！", "提示");
            }
        }

        //生成下拉框树
        private void CreateComboDataTree()
        {
            tvComboName.Nodes.Clear();
            DataTable dt = SQLDBBase.ExecuteDataTable("select * from ComboData order by ComboDataIndex asc");
            if (dt == null || dt.Rows.Count < 1)
            {
                return;
            }
            LoadComboData(dt, null, "0");
            tvComboName.CheckBoxes = false;
            tvComboName.ExpandAll();
            tvComboName.TopNode = tvComboName.Nodes[0];//第一个可见的节点是树里的第一个节点，滚动条就会上去了
        }

        //加载下拉框名字
        private void LoadComboData(DataTable dt, TreeNode ParentNode, String sParentIndex)
        {
            //过滤
            dt.DefaultView.RowFilter = " ParentIndex = " + sParentIndex;
            DataTable dtComboName = dt.DefaultView.ToTable();

            for (int i = 0; i < dtComboName.Rows.Count; i++)
            {
                string sComboName = dtComboName.Rows[i]["ComboName"].ToString();
                string sComboIndex = dtComboName.Rows[i]["ComboDataIndex"].ToString();
                string sComboType = dtComboName.Rows[i]["ComboType"].ToString();

                //在末尾显示单选/多选
                string ssComboType = "";
                if (sComboType == "-1")
                    ssComboType = "";
                else if (sComboType == "0")
                    ssComboType = " （单选）";
                else if (sComboType == "1")
                    ssComboType = " （多选）";
                TreeNode Item = new TreeNode(sComboName + ssComboType);
                Item.Tag = sComboIndex;
                if (ParentNode == null)
                {
                    tvComboName.Nodes.Add(Item);
                    LoadComboData(dt, Item, sComboIndex);
                }
                else
                {
                    ParentNode.Nodes.Add(Item);
                    LoadComboData(dt, Item, sComboIndex);
                }
            }
        }

        private void rbSing_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDropType();
        }
        private void rbMult_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDropType();
        }
        private void ChangeDropType()
        {
            if (tvComboName.SelectedNode != null)
            {
                string sComboIndex = tvComboName.SelectedNode.Tag.ToString();
                string sComboType = "-2";
                string ssComboType = "";
                
                DataTable dtCombo = SQLDBBase.ExecuteDataTable("select * from ComboData where comboDataIndex = '" + sComboIndex + "'");
                string ssComboName = dtCombo.Rows[0]["ComboName"].ToString();//为了实时刷新显示类型
                sComboType = dtCombo.Rows[0]["ComboType"].ToString();                

                //重选类型后刷新下拉框名表内信息                
                if (sComboType == "-1")
                    ssComboType = "";
                else if (sComboType == "0")
                    ssComboType = " （单选）";
                else if (sComboType == "1")
                    ssComboType = " （多选）";

                if (rbSing.Checked)
                {
                    sComboType = "0";                    
                    tvComboName.SelectedNode.Text = ssComboName + ssComboType;
                }
                else if (rbMult.Checked)
                {
                    sComboType = "1";
                    tvComboName.SelectedNode.Text = ssComboName + ssComboType;
                }

                if (sComboType != null)
                {
                    SQLDBBase.ExecuteSql("update ComboData set ComboType = '" + sComboType + "'where ComboDataIndex = '" + sComboIndex + "'");                    
                }
            }
        }

        private void tvComboName_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tvComboName.SelectedNode;
            string str = node.Text.ToString();
            string str1 = str.Remove(str.Length - 4, 4);

            if (node == null)
                return;
            //只有最后一层是下拉框名称 可选择单选/复选框
            if (tvComboName.SelectedNode.FirstNode == null)
            {
                rbMult.Enabled = true;
                rbSing.Enabled = true;
                lbComboName.Text = "当前选择的下拉框是：" + str1;
            }
            else
            {
                lbComboName.Text = "当前选择的下拉框是：";
                rbMult.Enabled = false;
                rbMult.Checked = false;
                rbSing.Enabled = false;
                rbSing.Checked = false;
            }
            //读取选中项是单选或复选的
            int sComboDataIndex = Convert.ToInt16(node.Tag.ToString());
            DataTable dt1 = SQLDBBase.ExecuteDataTable("select ComboType from ComboData where ComboDataIndex = '" + sComboDataIndex + "'");

            //cbComboType.Text = dt1.Rows[0][0].ToString();
            if (dt1.Rows[0][0].ToString() == "0")
            {
                rbSing.Checked = true;
            }
            else if (dt1.Rows[0][0].ToString() == "1")
            {
                rbMult.Checked = true;
            }

            CreateDetailTree();
        }


        //加载下拉框内容
        private void CreateDetailTree()
        {
            tvComboDetail.Nodes.Clear();
            if (tvComboName.SelectedNode == null)
                return;
            //string slctName = tvComboName.SelectedNode.Tag.ToString();
            DataTable dt = SQLDBBase.ExecuteDataTable("select ComboDataDetail.* from ComboDataDetail,ComboData where ComboDataDetail.ComboDataIndex = ComboData.ComboDataIndex and ComboData.ComboDataIndex= '" + tvComboName.SelectedNode.Tag.ToString() + "' ORDER BY ComboDataDetail.ComboValueOrder asc");
            if (dt == null || dt.Rows.Count < 1)
            {
                return;
            }
            string sParentIndex = dt.Rows[0]["ComboParentIndex"].ToString();

            int nDetailIndex = Convert.ToInt16(dt.Rows[0]["DetailIndex"].ToString());
            int nComboDataIndex = Convert.ToInt16(dt.Rows[0]["ComboDataIndex"].ToString());
            string sComboValue = dt.Rows[0]["ComboValue"].ToString();
            int nComboValueOrder = Convert.ToInt16(dt.Rows[0]["ComboValueOrder"].ToString());

            //TreeNode node = tvComboDetail.Nodes.Add(sComboValue);
            //node.Tag = nDetailIndex;
            LoadSubDetail(dt, null, "0");
            tvComboDetail.CheckBoxes = false;
            //tvComboDetail.ExpandAll();            
        }

        private void LoadSubDetail(DataTable dt, TreeNode ParentNode, string sParentIndex)
        {
            //过滤
            dt.DefaultView.RowFilter = " ComboParentIndex = " + sParentIndex;
            DataTable dtDetail = dt.DefaultView.ToTable();

            if (dtDetail.Rows.Count < 1)
            {
                return;
            }
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                string sDetailIndex = dtDetail.Rows[i]["DetailIndex"].ToString();

                string sComboDataIndex = dtDetail.Rows[i]["ComboDataIndex"].ToString();
                string sComboValue = dtDetail.Rows[i]["ComboValue"].ToString();
                string sOrder = dtDetail.Rows[i]["ComboValueOrder"].ToString();
                string sComboParentIndex = dtDetail.Rows[i]["ComboParentIndex"].ToString();

                TreeNode Item = new TreeNode(sComboValue);
                //Item.ToolTipText = sDetailIndex;
                Item.Tag = sDetailIndex;

                if (sComboParentIndex == "0")
                {
                    tvComboDetail.Nodes.Add(Item);//没有父节点在首层生成
                    LoadSubDetail(dt, Item, sDetailIndex);
                }
                else
                {
                    ParentNode.Nodes.Add(Item);//有父节点则在父节点下生成
                    LoadSubDetail(dt, Item, sDetailIndex);
                }
            }
        }

        //添加下拉框内容
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tvComboName.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("请选择下拉框输入数据","提示");
                return;
            }
            if (DoRepeat() == true)
            {
                MessageBox.Show("下拉框中已存在的数据，请重新输入！", "提示");
                return;
            }
            //tvComboDetail.SelectedNode.FirstNode;
            if (TbComboValue.Text == "" || tvComboName.SelectedNode == null)
                return;
            string sComboDataIndex = tvComboName.SelectedNode.Tag.ToString();
            int ssMxOrder = GetMaxOrder(sComboDataIndex);
            
            //没有选中项 则在最后一项后面添加
            if (tvComboDetail.SelectedNode == null)
            {

                SQLDBBase.FieldDataItem[] FieldItem = new SQLDBBase.FieldDataItem[15];

                int nFieldIndex = -1;

                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboDataIndex", sComboDataIndex, SQLDBBase.FieldDataType.Int);
                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboValue", TbComboValue.Text.Trim());
                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboValueOrder", ssMxOrder + 1, SQLDBBase.FieldDataType.Int);
                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboParentIndex", "0", SQLDBBase.FieldDataType.Int);//在第一层级中添加

                if (SQLDBBase.InsertRecord("ComboDataDetail", nFieldIndex + 1, FieldItem) == 1)
                {
                    //TreeNode node = tvComboDetail.SelectedNode.Nodes.Add(TbComboValue.Text.Trim());BUG 出错！！！
                    object ob = SQLDBBase.GetSingle("select * from ComboDataDetail where ComboParentIndex = '0' and ComboValue='" + TbComboValue.Text.Trim() + "'");
                    if (ob != null)
                    {
                        TbComboValue.Text = "";
                        DoRefreshDetail();
                    }
                }
            }
            else if (tvComboDetail.SelectedNode != null)//有选中项，在选中项中添加子节点
            {
                if (tvComboDetail.SelectedNode == null)
                    return;
                string sDetailIndex = tvComboDetail.SelectedNode.Tag.ToString();

                SQLDBBase.FieldDataItem[] FieldItem = new SQLDBBase.FieldDataItem[15];
                int nFieldIndex = -1;
                //FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("DetailIndex", nodeData.nDetailIndex, SQLDBBase.FieldDataType.Int);
                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboDataIndex", sComboDataIndex, SQLDBBase.FieldDataType.Int);
                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboValue", TbComboValue.Text.Trim());
                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboValueOrder", ssMxOrder + 1, SQLDBBase.FieldDataType.Int);
                FieldItem[++nFieldIndex] = new SQLDBBase.FieldDataItem("ComboParentIndex", sDetailIndex, SQLDBBase.FieldDataType.Int);

                if (SQLDBBase.InsertRecord("ComboDataDetail", nFieldIndex + 1, FieldItem) == 1)
                {
                    TreeNode node = tvComboDetail.SelectedNode.Nodes.Add(TbComboValue.Text.Trim());

                    TbComboValue.Text = "";
                    DoRefreshDetail();
                }
            }
        }

        //检验数据是否重复录入,返回true则已存在，禁止添加；返回false则不存在，可以添加。
        private bool DoRepeat()
        {
            string sSQL = "SELECT * FROM ComboDataDetail as c, ComboData as cd WHERE c.ComboDataIndex = cd.ComboDataIndex and cd.ComboDataIndex = '" + tvComboName.SelectedNode.Tag.ToString() + "' and c.ComboValue = '" + TbComboValue.Text.Trim() + "'";
            return SQLDBBase.RecordExists(sSQL);
        }

        //获取ComboDataDetail表中，当前选择的下拉框的最大Order
        private int GetMaxOrder(string sComboDataIndex/*, string mxOrder*/)
        {
            string ssql = "select Max(b.ComboValueOrder) from ComboDataDetail as b,ComboData as a where b.ComboDataIndex = a.ComboDataIndex and a.ComboDataIndex = '" + sComboDataIndex + "'";
            DataTable dt = SQLDBBase.ExecuteDataTable(ssql);
            int mxOrder;
            if (dt.Rows.Count <= 1)
            {
                mxOrder = '0';
            }
            else
            {
                mxOrder = Convert.ToInt16(dt.Rows[0][0].ToString());//Order最大值
            }            
            return mxOrder;
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void tvComboName_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            tvComboName.LabelEdit = false;
            string sComboIndex = tvComboName.SelectedNode.Tag.ToString();
            string sComboName = e.Label;
            SQLDBBase.ExecuteSql(" update ComboData set ComboName ='" + sComboName + "' where ComboDataIndex ='" + sComboIndex + "'");
        }


        private void tsmDorefresh_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }

        //按F5键刷新
        private void FBaseDataManage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 116)
            {
                DoRefresh();
            }
        }


        //private void bt_down_Click(object sender, EventArgs e)
        //{
        //    string sComboDataIndex = tvComboName.SelectedNode.Tag.ToString();
        //    int index = LbComboDetail.SelectedIndex;
        //    if (index == -1)
        //    {
        //        return;
        //    }
        //    else if (index < LbComboDetail.Items.Count - 1)
        //    {
        //        string cache = "";
        //        string str = LbComboDetail.Items[index].ToString();
        //        string str2 = LbComboDetail.Items[(index + 1)].ToString();
        //        LbComboDetail.Items.RemoveAt(index);
        //        LbComboDetail.Items.Insert(index + 1, str);
        //        LbComboDetail.SelectedIndex = index + 1;
        //    }
        //}
        //private void bt_up_Click(object sender, EventArgs e)
        //{
        //    string sComboDataIndex = tvComboName.SelectedNode.Tag.ToString();
        //    int index = LbComboDetail.SelectedIndex;
        //    if (index == -1)
        //    {
        //        return;
        //    }
        //    else if (index > 0)
        //    {
        //        string str = LbComboDetail.Items[index].ToString();
        //        LbComboDetail.Items.RemoveAt(index);
        //        LbComboDetail.Items.Insert(index - 1, str);
        //        LbComboDetail.SelectedIndex = index - 1;
        //    }

        //}

        //改变下拉框类型
        private void tvComboDetail_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

        }

        private void tvComboDetail_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        //刷新内容
        private void RefreshTSMI_Click(object sender, EventArgs e)
        {
            DoRefreshDetail();
        }

        //刷新内容
        private void DoRefreshDetail()
        {
            try
            {
                CreateDetailTree();
            }
            catch
            {
                MessageBox.Show("获取下拉框内容数据异常！", "提示");
            }
        }

        //新增内容
        private void AddTSMI_Click(object sender, EventArgs e)
        {
            TreeNode node = tvComboDetail.SelectedNode;
            if (node == null)
            {
                return;
            }
            tbParent.Text = tvComboDetail.SelectedNode.Text.ToString();
            TbComboValue.Focus();
        }

        private void DeleteTSMI_Click(object sender, EventArgs e)
        {
            if (tvComboDetail.SelectedNode == null)
                return;
            string sDetailIndex = tvComboDetail.SelectedNode.Tag.ToString();//有bug，第二次选中某项 点删除无效
            DeleteDetail(sDetailIndex);
        }

        //删除下拉框内容
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (tvComboDetail.SelectedNode != null)
            {
                string sDetailIndex = tvComboDetail.SelectedNode.Tag.ToString();
                DeleteDetail(sDetailIndex);
            }
        }
        //判断当前下拉框内容是否使用过，使用过返回true(不可被删除)，没使用过返回false(可以被删除)。
        private bool DoValidData(string sDetailIndex, string sComboValue)
        {
            string sql = "select TableName,FieldName from ComboData as c,ComboDataDetail as cd where c.ComboDataIndex = cd.ComboDataIndex and cd.DetailIndex = '" + sDetailIndex + "'";
            DataTable dt = SQLDBBase.ExecuteDataTable(sql);
            string sTableName = dt.Rows[0]["TableName"].ToString();
            string sFieldName = dt.Rows[0]["FieldName"].ToString();
            string sSQL = "select * from " + sTableName + " where " + sFieldName + " = '" + sComboValue + "'";//
            return SQLDBBase.RecordExists(sSQL);
        }
        private void DeleteDetail(string sDetailIndex)
        {
            if (tvComboDetail.SelectedNode == null)
                return;
            if (tvComboDetail.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("该节点有子节点，不允许删除");
                return;
            }

            string sComboValue = tvComboDetail.SelectedNode.Text.ToString();

            if (tvComboName.SelectedNode != null)
            {
                if (DoValidData(sDetailIndex, sComboValue) == true)
                {
                    MessageBox.Show("该数据已被使用，禁止删除！", "提示");
                    return;
                }
                else if (DoValidData(sDetailIndex, sComboValue) == false)
                {
                    sDetailIndex = tvComboDetail.SelectedNode.Tag.ToString();
                    if (SQLDBBase.ExecuteSql("delete from ComboDataDetail where DetailIndex =" + sDetailIndex) > 1)
                    {
                        tvComboDetail.Nodes.Remove(tvComboDetail.SelectedNode);
                    }
                    DoRefreshDetail();
                }
            }
        }

        //将选中节点上移一个位置
        private void UpTSMI_Click(object sender, EventArgs e)
        {
            if (tvComboDetail.SelectedNode == null)
                return;
            TreeNode objNode = tvComboDetail.SelectedNode;
            //如果该节点为所在层的最上面节点，则无需上移
            if (objNode.PrevNode == null)
                return;
            TreeNode newNode = (TreeNode)objNode.Clone();
            //如果为最上层节点
            if (objNode.Level == 0)
            {
                tvComboDetail.Nodes.Insert(objNode.PrevNode.Index, newNode);
                tvComboDetail.Nodes.Remove(objNode);

            }//如果不是最上层节点
            else
            {
                objNode.Parent.Nodes.Insert(objNode.PrevNode.Index, newNode);
                objNode.Parent.Nodes.Remove(objNode);
            }
            tvComboDetail.SelectedNode = newNode;
        }

        //将选中节点下移一个位置
        private void DownTSMI_Click(object sender, EventArgs e)
        {
            if (tvComboDetail.SelectedNode == null)
                return;
            TreeNode objNode = tvComboDetail.SelectedNode;
            //如果该节点为该节点所在层的的最后一个节点，则无需下移
            if (objNode.NextNode == null)
                return;
            TreeNode newNode = (TreeNode)objNode.Clone();
            //如果为最上层节点
            if (objNode.Level == 0)
            {
                tvComboDetail.Nodes.Insert(objNode.NextNode.Index + 1, newNode);
                tvComboDetail.Nodes.Remove(objNode);
            }//如果不是最上层节点
            else
            {
                objNode.Parent.Nodes.Insert(objNode.NextNode.Index + 1, newNode);
                objNode.Parent.Nodes.Remove(objNode);
            }
            tvComboDetail.SelectedNode = newNode;
        }

        //单击空白处时 取消节点选中
        private void ClickBlankAero(object sender, EventArgs e)
        {
            //tvComboDetail.SelectedNode.
            //DoRefreshDetail();
        }

        private void tvComboDetail_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null)
                return;
            if (e.Node.Parent == null)
                return;
            if (tvComboDetail.SelectedNode == null)
            {
                return;
            }
            tbParent.Text = tvComboDetail.SelectedNode.Text.ToString();

        }

        private void tvComboName_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //    TreeNode node = tvComboName.SelectedNode;
            //    string str = node.Text.ToString();
            //    string str1 = str.Remove(str.Length - 4, 4);

            //    if (node == null)
            //        return;
            //    //只有最后一层是下拉框名称 可选择单选/复选框
            //    if (tvComboName.SelectedNode.FirstNode == null)
            //    {
            //        rbMult.Enabled = true;
            //        rbSing.Enabled = true;
            //        lbComboName.Text = "当前选择的下拉框是：" + str1;
            //    }
            //    else
            //    {
            //        lbComboName.Text = "当前选择的下拉框是：";
            //        rbMult.Enabled = false;
            //        rbMult.Checked = false;
            //        rbSing.Enabled = false;
            //        rbSing.Checked = false;
            //    }
            //    //读取选中项是单选或复选的
            //    int sComboDataIndex = Convert.ToInt16(node.Tag.ToString());
            //    DataTable dt1 = SQLDBBase.ExecuteDataTable("select ComboType from ComboData where ComboDataIndex = '" + sComboDataIndex + "'");

            //    //cbComboType.Text = dt1.Rows[0][0].ToString();
            //    if (dt1.Rows[0][0].ToString() == "0")
            //    {
            //        rbSing.Checked = true;
            //    }
            //    else if (dt1.Rows[0][0].ToString() == "1")
            //    {
            //        rbMult.Checked = true;
            //    }

            //    CreateDetailTree();
            //}
        }



        public class NodeData
        {
            public int nDetailIndex;
            public int nComboDataIndex;
            public string sComboValue;
            public int nComboValueOrder;
            public int nComboParentIndex;

            public string sFieldType = ""; //数据类型
            public string sFieldUnit = "";//单位
            public string sFieldDefaultValue = ""; //默认值
        }
    }
}
