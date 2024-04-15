
namespace kidstrUser.Forms
{
    partial class MainAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAdmin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.Button();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.menuAdminParam = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminParamType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminParamDirect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminReports = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kidstrUser.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(399, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(399, 125);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(109, 34);
            this.exit.TabIndex = 3;
            this.exit.Text = "Выйти";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // menuAdmin
            // 
            this.menuAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuAdmin.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdminParam,
            this.menuAdminUsers,
            this.menuAdminReports});
            this.menuAdmin.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(320, 174);
            this.menuAdmin.TabIndex = 11;
            this.menuAdmin.Text = "menuStrip1";
            // 
            // menuAdminParam
            // 
            this.menuAdminParam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdminParamType,
            this.menuAdminParamDirect});
            this.menuAdminParam.Name = "menuAdminParam";
            this.menuAdminParam.Size = new System.Drawing.Size(312, 36);
            this.menuAdminParam.Text = "Параметры мероприятий";
            // 
            // menuAdminParamType
            // 
            this.menuAdminParamType.Name = "menuAdminParamType";
            this.menuAdminParamType.Size = new System.Drawing.Size(252, 36);
            this.menuAdminParamType.Text = "Типы";
            this.menuAdminParamType.Click += new System.EventHandler(this.menuAdminParamType_Click);
            // 
            // menuAdminParamDirect
            // 
            this.menuAdminParamDirect.Name = "menuAdminParamDirect";
            this.menuAdminParamDirect.Size = new System.Drawing.Size(252, 36);
            this.menuAdminParamDirect.Text = "Направления";
            this.menuAdminParamDirect.Click += new System.EventHandler(this.menuAdminParamDirect_Click);
            // 
            // menuAdminUsers
            // 
            this.menuAdminUsers.Name = "menuAdminUsers";
            this.menuAdminUsers.Size = new System.Drawing.Size(161, 36);
            this.menuAdminUsers.Text = "Сотрудники";
            this.menuAdminUsers.Click += new System.EventHandler(this.menuAdminUsers_Click);
            // 
            // menuAdminReports
            // 
            this.menuAdminReports.Name = "menuAdminReports";
            this.menuAdminReports.Size = new System.Drawing.Size(111, 36);
            this.menuAdminReports.Text = "Отчеты";
            this.menuAdminReports.Click += new System.EventHandler(this.menuAdminReports_Click);
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 174);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuAdmin;
            this.MaximizeBox = false;
            this.Name = "MainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KidStr - Администрирование";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainAdmin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuAdminParam;
        private System.Windows.Forms.ToolStripMenuItem menuAdminParamType;
        private System.Windows.Forms.ToolStripMenuItem menuAdminParamDirect;
        private System.Windows.Forms.ToolStripMenuItem menuAdminUsers;
        private System.Windows.Forms.ToolStripMenuItem menuAdminReports;
    }
}