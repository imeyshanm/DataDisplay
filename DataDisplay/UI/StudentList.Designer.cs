
namespace DataDisplay.UI
{
    partial class StudentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentList));
            this.dgStudentList = new System.Windows.Forms.DataGridView();
            this.ToolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnAddStudent = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).BeginInit();
            this.ToolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgStudentList
            // 
            this.dgStudentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudentList.Location = new System.Drawing.Point(12, 30);
            this.dgStudentList.Name = "dgStudentList";
            this.dgStudentList.RowHeadersWidth = 51;
            this.dgStudentList.Size = new System.Drawing.Size(1146, 446);
            this.dgStudentList.TabIndex = 0;
            this.dgStudentList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgStudentList_MouseDoubleClick);
            // 
            // ToolStrip3
            // 
            this.ToolStrip3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ToolStrip3.AllowMerge = false;
            this.ToolStrip3.BackColor = System.Drawing.Color.White;
            this.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ToolStrip3.Font = new System.Drawing.Font("Arial", 8F);
            this.ToolStrip3.GripMargin = new System.Windows.Forms.Padding(0);
            this.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnRefresh,
            this.btnAddStudent});
            this.ToolStrip3.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip3.Name = "ToolStrip3";
            this.ToolStrip3.Padding = new System.Windows.Forms.Padding(0);
            this.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip3.Size = new System.Drawing.Size(1170, 27);
            this.ToolStrip3.TabIndex = 186;
            this.ToolStrip3.Text = "ToolStrip3";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 24);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 24);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStudent.Image")));
            this.btnAddStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(91, 24);
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.ToolTipText = "Default Settings";
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // StudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1170, 488);
            this.Controls.Add(this.ToolStrip3);
            this.Controls.Add(this.dgStudentList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student List";
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).EndInit();
            this.ToolStrip3.ResumeLayout(false);
            this.ToolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgStudentList;
        internal System.Windows.Forms.ToolStrip ToolStrip3;
        internal System.Windows.Forms.ToolStripButton btnClose;
        internal System.Windows.Forms.ToolStripButton btnAddStudent;
        internal System.Windows.Forms.ToolStripButton btnRefresh;
    }
}