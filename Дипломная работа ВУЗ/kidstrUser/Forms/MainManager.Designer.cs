
namespace kidstrUser.Forms
{
    partial class MainManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainManager));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.Button();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.menuAdminServ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminAddServ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminOrders = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kidstrUser.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(282, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(282, 124);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(109, 34);
            this.exit.TabIndex = 4;
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
            this.menuAdminServ,
            this.menuAdminAddServ,
            this.menuAdminOrders});
            this.menuAdmin.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(188, 173);
            this.menuAdmin.TabIndex = 12;
            this.menuAdmin.Text = "menuStrip1";
            // 
            // menuAdminServ
            // 
            this.menuAdminServ.Name = "menuAdminServ";
            this.menuAdminServ.Size = new System.Drawing.Size(182, 36);
            this.menuAdminServ.Text = "Мероприятия";
            this.menuAdminServ.Click += new System.EventHandler(this.menuAdminServ_Click);
            // 
            // menuAdminAddServ
            // 
            this.menuAdminAddServ.Name = "menuAdminAddServ";
            this.menuAdminAddServ.Size = new System.Drawing.Size(157, 36);
            this.menuAdminAddServ.Text = "Доп. услуги";
            this.menuAdminAddServ.Click += new System.EventHandler(this.menuAdminAddServ_Click);
            // 
            // menuAdminOrders
            // 
            this.menuAdminOrders.Name = "menuAdminOrders";
            this.menuAdminOrders.Size = new System.Drawing.Size(106, 36);
            this.menuAdminOrders.Text = "Заказы";
            this.menuAdminOrders.Click += new System.EventHandler(this.menuAdminOrders_Click);
            // 
            // MainManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 173);
            this.Controls.Add(this.menuAdmin);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KidStr - Менеджмент";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainManager_FormClosed);
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
        private System.Windows.Forms.ToolStripMenuItem menuAdminServ;
        private System.Windows.Forms.ToolStripMenuItem menuAdminAddServ;
        private System.Windows.Forms.ToolStripMenuItem menuAdminOrders;
    }
}