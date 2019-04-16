namespace Base_Function.BLL_DOCTOR.HisInStance.PACS
{
    partial class ucPasc
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOutPutYxxyj = new DevComponents.DotNetBar.ButtonX();
            this.btnOutPutYxxbx = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblImageNo = new System.Windows.Forms.Label();
            this.lblSickNo = new System.Windows.Forms.Label();
            this.lblCheckDoctor = new System.Windows.Forms.Label();
            this.lblReportDoctor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Controls.Add(this.panel1);
            this.tabControlPanel5.Controls.Add(this.tabControl1);
            this.tabControlPanel5.Controls.Add(this.panel2);
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 0);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(1083, 446);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.White;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.panel3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = -1;
            this.tabControl1.Size = new System.Drawing.Size(1081, 406);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Text = "tabControl2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel2.Controls.Add(this.btn_ok);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOutPutYxxyj);
            this.panel2.Controls.Add(this.btnOutPutYxxbx);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 407);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 38);
            this.panel2.TabIndex = 11;
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ok.Location = new System.Drawing.Point(393, 6);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(92, 25);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "导出";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(506, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "退出";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOutPutYxxyj
            // 
            this.btnOutPutYxxyj.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOutPutYxxyj.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOutPutYxxyj.Location = new System.Drawing.Point(245, 6);
            this.btnOutPutYxxyj.Name = "btnOutPutYxxyj";
            this.btnOutPutYxxyj.Size = new System.Drawing.Size(92, 25);
            this.btnOutPutYxxyj.TabIndex = 1;
            this.btnOutPutYxxyj.Text = "导出影像学意见";
            this.btnOutPutYxxyj.Visible = false;
            // 
            // btnOutPutYxxbx
            // 
            this.btnOutPutYxxbx.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOutPutYxxbx.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOutPutYxxbx.Location = new System.Drawing.Point(140, 6);
            this.btnOutPutYxxbx.Name = "btnOutPutYxxbx";
            this.btnOutPutYxxbx.Size = new System.Drawing.Size(92, 25);
            this.btnOutPutYxxbx.TabIndex = 0;
            this.btnOutPutYxxbx.Text = "导出影像学表现";
            this.btnOutPutYxxbx.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "年龄";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "出生日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "影像号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "病历号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(587, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "审核医生";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(705, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "报告医生";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(62, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "姓名";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(143, 21);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(29, 12);
            this.lblSex.TabIndex = 10;
            this.lblSex.Text = "性别";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAge.Location = new System.Drawing.Point(213, 21);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 12);
            this.lblAge.TabIndex = 11;
            this.lblAge.Text = "年龄";
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBirthday.Location = new System.Drawing.Point(307, 21);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(53, 12);
            this.lblBirthday.TabIndex = 12;
            this.lblBirthday.Text = "出生日期";
            // 
            // lblImageNo
            // 
            this.lblImageNo.AutoSize = true;
            this.lblImageNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImageNo.Location = new System.Drawing.Point(428, 21);
            this.lblImageNo.Name = "lblImageNo";
            this.lblImageNo.Size = new System.Drawing.Size(41, 12);
            this.lblImageNo.TabIndex = 13;
            this.lblImageNo.Text = "影像号";
            // 
            // lblSickNo
            // 
            this.lblSickNo.AutoSize = true;
            this.lblSickNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSickNo.Location = new System.Drawing.Point(522, 21);
            this.lblSickNo.Name = "lblSickNo";
            this.lblSickNo.Size = new System.Drawing.Size(41, 12);
            this.lblSickNo.TabIndex = 14;
            this.lblSickNo.Text = "病历号";
            // 
            // lblCheckDoctor
            // 
            this.lblCheckDoctor.AutoSize = true;
            this.lblCheckDoctor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckDoctor.Location = new System.Drawing.Point(646, 21);
            this.lblCheckDoctor.Name = "lblCheckDoctor";
            this.lblCheckDoctor.Size = new System.Drawing.Size(53, 12);
            this.lblCheckDoctor.TabIndex = 16;
            this.lblCheckDoctor.Text = "审核医生";
            // 
            // lblReportDoctor
            // 
            this.lblReportDoctor.AutoSize = true;
            this.lblReportDoctor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReportDoctor.Location = new System.Drawing.Point(764, 21);
            this.lblReportDoctor.Name = "lblReportDoctor";
            this.lblReportDoctor.Size = new System.Drawing.Size(53, 12);
            this.lblReportDoctor.TabIndex = 17;
            this.lblReportDoctor.Text = "报告医生";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.lblReportDoctor);
            this.panel1.Controls.Add(this.lblCheckDoctor);
            this.panel1.Controls.Add(this.lblSickNo);
            this.panel1.Controls.Add(this.lblImageNo);
            this.panel1.Controls.Add(this.lblBirthday);
            this.panel1.Controls.Add(this.lblAge);
            this.panel1.Controls.Add(this.lblSex);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 52);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1082, 354);
            this.panel3.TabIndex = 1;
            // 
            // ucPasc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlPanel5);
            this.Name = "ucPasc";
            this.Size = new System.Drawing.Size(1083, 446);
            this.Load += new System.EventHandler(this.ucPasc_Load);
            this.tabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        public DevComponents.DotNetBar.TabControl tabControl1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOutPutYxxyj;
        private DevComponents.DotNetBar.ButtonX btnOutPutYxxbx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReportDoctor;
        private System.Windows.Forms.Label lblCheckDoctor;
        private System.Windows.Forms.Label lblSickNo;
        private System.Windows.Forms.Label lblImageNo;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}
