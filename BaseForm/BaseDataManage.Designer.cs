namespace com.zstu.BaseForm
{
    partial class FBaseDataManage
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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.TbComboValue = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tvComboName = new System.Windows.Forms.TreeView();
            this.cmsComboName = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDorefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.tvComboDetail = new System.Windows.Forms.TreeView();
            this.cmsComboDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.UpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DownTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.rbSing = new System.Windows.Forms.RadioButton();
            this.rbMult = new System.Windows.Forms.RadioButton();
            this.lbComboName = new System.Windows.Forms.Label();
            this.lbParentName = new System.Windows.Forms.Label();
            this.tbParent = new System.Windows.Forms.TextBox();
            this.cmsComboName.SuspendLayout();
            this.cmsComboDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(406, 570);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "添加";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDel.Location = new System.Drawing.Point(538, 570);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 3;
            this.BtnDel.Text = "删除";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // TbComboValue
            // 
            this.TbComboValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TbComboValue.Location = new System.Drawing.Point(470, 542);
            this.TbComboValue.Name = "TbComboValue";
            this.TbComboValue.Size = new System.Drawing.Size(224, 21);
            this.TbComboValue.TabIndex = 4;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(668, 570);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "内容";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "下拉框列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(391, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "下拉框内容";
            // 
            // tvComboName
            // 
            this.tvComboName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvComboName.ContextMenuStrip = this.cmsComboName;
            this.tvComboName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvComboName.Location = new System.Drawing.Point(12, 35);
            this.tvComboName.Name = "tvComboName";
            this.tvComboName.Size = new System.Drawing.Size(358, 560);
            this.tvComboName.TabIndex = 9;
            this.tvComboName.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvComboName_AfterLabelEdit);
            this.tvComboName.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvComboName_AfterSelect);
            this.tvComboName.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvComboName_NodeMouseClick);
            // 
            // cmsComboName
            // 
            this.cmsComboName.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsComboName.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDorefresh});
            this.cmsComboName.Name = "contextMenuStrip1";
            this.cmsComboName.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmDorefresh
            // 
            this.tsmDorefresh.Name = "tsmDorefresh";
            this.tsmDorefresh.Size = new System.Drawing.Size(100, 22);
            this.tsmDorefresh.Text = "刷新";
            this.tsmDorefresh.Click += new System.EventHandler(this.tsmDorefresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(152, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "下拉框类型";
            // 
            // tvComboDetail
            // 
            this.tvComboDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvComboDetail.ContextMenuStrip = this.cmsComboDetail;
            this.tvComboDetail.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvComboDetail.Location = new System.Drawing.Point(395, 57);
            this.tvComboDetail.Name = "tvComboDetail";
            this.tvComboDetail.Size = new System.Drawing.Size(358, 415);
            this.tvComboDetail.TabIndex = 14;
            this.tvComboDetail.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvComboDetail_AfterLabelEdit);
            this.tvComboDetail.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvComboDetail_NodeMouseClick);
            this.tvComboDetail.Click += new System.EventHandler(this.ClickBlankAero);
            // 
            // cmsComboDetail
            // 
            this.cmsComboDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTSMI,
            this.DeleteTSMI,
            this.UpTSMI,
            this.DownTSMI,
            this.RefreshTSMI});
            this.cmsComboDetail.Name = "cmsComboDetail";
            this.cmsComboDetail.Size = new System.Drawing.Size(101, 114);
            // 
            // AddTSMI
            // 
            this.AddTSMI.Name = "AddTSMI";
            this.AddTSMI.Size = new System.Drawing.Size(100, 22);
            this.AddTSMI.Text = "添加";
            this.AddTSMI.Click += new System.EventHandler(this.AddTSMI_Click);
            // 
            // DeleteTSMI
            // 
            this.DeleteTSMI.Name = "DeleteTSMI";
            this.DeleteTSMI.Size = new System.Drawing.Size(100, 22);
            this.DeleteTSMI.Text = "删除";
            this.DeleteTSMI.Click += new System.EventHandler(this.DeleteTSMI_Click);
            // 
            // UpTSMI
            // 
            this.UpTSMI.Name = "UpTSMI";
            this.UpTSMI.Size = new System.Drawing.Size(100, 22);
            this.UpTSMI.Text = "向上";
            this.UpTSMI.Click += new System.EventHandler(this.UpTSMI_Click);
            // 
            // DownTSMI
            // 
            this.DownTSMI.Name = "DownTSMI";
            this.DownTSMI.Size = new System.Drawing.Size(100, 22);
            this.DownTSMI.Text = "向下";
            this.DownTSMI.Click += new System.EventHandler(this.DownTSMI_Click);
            // 
            // RefreshTSMI
            // 
            this.RefreshTSMI.Name = "RefreshTSMI";
            this.RefreshTSMI.Size = new System.Drawing.Size(100, 22);
            this.RefreshTSMI.Text = "刷新";
            this.RefreshTSMI.Click += new System.EventHandler(this.RefreshTSMI_Click);
            // 
            // rbSing
            // 
            this.rbSing.AutoSize = true;
            this.rbSing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSing.Location = new System.Drawing.Point(249, 9);
            this.rbSing.Name = "rbSing";
            this.rbSing.Size = new System.Drawing.Size(58, 20);
            this.rbSing.TabIndex = 15;
            this.rbSing.TabStop = true;
            this.rbSing.Text = "单选";
            this.rbSing.UseVisualStyleBackColor = true;
            this.rbSing.CheckedChanged += new System.EventHandler(this.rbSing_CheckedChanged);
            // 
            // rbMult
            // 
            this.rbMult.AutoSize = true;
            this.rbMult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbMult.Location = new System.Drawing.Point(312, 9);
            this.rbMult.Name = "rbMult";
            this.rbMult.Size = new System.Drawing.Size(58, 20);
            this.rbMult.TabIndex = 16;
            this.rbMult.TabStop = true;
            this.rbMult.Text = "多选";
            this.rbMult.UseVisualStyleBackColor = true;
            this.rbMult.CheckedChanged += new System.EventHandler(this.rbMult_CheckedChanged);
            // 
            // lbComboName
            // 
            this.lbComboName.AutoSize = true;
            this.lbComboName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbComboName.Location = new System.Drawing.Point(391, 8);
            this.lbComboName.Name = "lbComboName";
            this.lbComboName.Size = new System.Drawing.Size(157, 14);
            this.lbComboName.TabIndex = 17;
            this.lbComboName.Text = "当前选择的下拉框是：";
            // 
            // lbParentName
            // 
            this.lbParentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbParentName.AutoSize = true;
            this.lbParentName.Location = new System.Drawing.Point(423, 511);
            this.lbParentName.Name = "lbParentName";
            this.lbParentName.Size = new System.Drawing.Size(41, 12);
            this.lbParentName.TabIndex = 18;
            this.lbParentName.Text = "父节点";
            // 
            // tbParent
            // 
            this.tbParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbParent.Location = new System.Drawing.Point(470, 508);
            this.tbParent.Name = "tbParent";
            this.tbParent.ReadOnly = true;
            this.tbParent.Size = new System.Drawing.Size(224, 21);
            this.tbParent.TabIndex = 19;
            // 
            // FBaseDataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 607);
            this.Controls.Add(this.tbParent);
            this.Controls.Add(this.lbParentName);
            this.Controls.Add(this.lbComboName);
            this.Controls.Add(this.rbMult);
            this.Controls.Add(this.rbSing);
            this.Controls.Add(this.tvComboDetail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tvComboName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.TbComboValue);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnAdd);
            this.KeyPreview = true;
            this.Name = "FBaseDataManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下拉框维护";
            this.Load += new System.EventHandler(this.FBaseDataManage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FBaseDataManage_KeyDown);
            this.cmsComboName.ResumeLayout(false);
            this.cmsComboDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.TextBox TbComboValue;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvComboName;
        private System.Windows.Forms.ContextMenuStrip cmsComboName;
        private System.Windows.Forms.ToolStripMenuItem tsmDorefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvComboDetail;
        private System.Windows.Forms.RadioButton rbSing;
        private System.Windows.Forms.RadioButton rbMult;
        private System.Windows.Forms.Label lbComboName;
        private System.Windows.Forms.ContextMenuStrip cmsComboDetail;
        private System.Windows.Forms.ToolStripMenuItem AddTSMI;
        private System.Windows.Forms.ToolStripMenuItem DeleteTSMI;
        private System.Windows.Forms.ToolStripMenuItem UpTSMI;
        private System.Windows.Forms.ToolStripMenuItem DownTSMI;
        private System.Windows.Forms.ToolStripMenuItem RefreshTSMI;
        private System.Windows.Forms.Label lbParentName;
        private System.Windows.Forms.TextBox tbParent;
    }
}