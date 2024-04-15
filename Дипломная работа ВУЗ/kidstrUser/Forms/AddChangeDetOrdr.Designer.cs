
namespace kidstrUser.Forms
{
    partial class AddChangeDetOrdr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddChangeDetOrdr));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.school = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.party = new System.Windows.Forms.NumericUpDown();
            this.accom = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.contact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.datetime = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.meetpoint = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cost = new System.Windows.Forms.Label();
            this.prepay = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guide = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gridAServ = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.serv = new System.Windows.Forms.ComboBox();
            this.price = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.party)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAServ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kidstrUser.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(889, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save.Location = new System.Drawing.Point(380, 690);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(171, 40);
            this.save.TabIndex = 22;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(47, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "Организация";
            // 
            // school
            // 
            this.school.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.school.Location = new System.Drawing.Point(287, 39);
            this.school.Name = "school";
            this.school.Size = new System.Drawing.Size(319, 34);
            this.school.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 29);
            this.label2.TabIndex = 25;
            this.label2.Text = "Возраст/Класс";
            // 
            // age
            // 
            this.age.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age.FormattingEnabled = true;
            this.age.Location = new System.Drawing.Point(287, 81);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(201, 37);
            this.age.TabIndex = 26;
            this.age.SelectedValueChanged += new System.EventHandler(this.age_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 29);
            this.label3.TabIndex = 27;
            this.label3.Text = "Участников";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "Сопровождающих";
            // 
            // party
            // 
            this.party.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.party.Location = new System.Drawing.Point(11, 73);
            this.party.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.party.Name = "party";
            this.party.Size = new System.Drawing.Size(79, 34);
            this.party.TabIndex = 29;
            this.party.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.party.ValueChanged += new System.EventHandler(this.memb_ValueChanged);
            // 
            // accom
            // 
            this.accom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accom.Location = new System.Drawing.Point(11, 142);
            this.accom.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.accom.Name = "accom";
            this.accom.Size = new System.Drawing.Size(79, 34);
            this.accom.TabIndex = 30;
            this.accom.ValueChanged += new System.EventHandler(this.memb_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(44, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 29);
            this.label5.TabIndex = 31;
            this.label5.Text = "Контактное лицо";
            // 
            // contact
            // 
            this.contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contact.Location = new System.Drawing.Point(287, 124);
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(319, 34);
            this.contact.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(44, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 58);
            this.label6.TabIndex = 34;
            this.label6.Text = "Дата и время\r\nвстречи";
            // 
            // datetime
            // 
            this.datetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datetime.Location = new System.Drawing.Point(287, 180);
            this.datetime.Mask = "00/00/0000 90:00";
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(201, 34);
            this.datetime.TabIndex = 36;
            this.datetime.ValidatingType = typeof(System.DateTime);
            this.datetime.Validated += new System.EventHandler(this.datetime_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(44, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 29);
            this.label7.TabIndex = 37;
            this.label7.Text = "Точка встречи";
            // 
            // meetpoint
            // 
            this.meetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.meetpoint.Location = new System.Drawing.Point(287, 233);
            this.meetpoint.Name = "meetpoint";
            this.meetpoint.Size = new System.Drawing.Size(319, 34);
            this.meetpoint.TabIndex = 38;
            this.meetpoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 29);
            this.label8.TabIndex = 39;
            this.label8.Text = "Стоимость: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 29);
            this.label9.TabIndex = 40;
            this.label9.Text = "Предоплата: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(6, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 29);
            this.label10.TabIndex = 41;
            this.label10.Text = "Статус: ";
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cost.Location = new System.Drawing.Point(171, 18);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(26, 29);
            this.cost.TabIndex = 42;
            this.cost.Text = "0";
            // 
            // prepay
            // 
            this.prepay.AutoSize = true;
            this.prepay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prepay.Location = new System.Drawing.Point(172, 47);
            this.prepay.Name = "prepay";
            this.prepay.Size = new System.Drawing.Size(26, 29);
            this.prepay.TabIndex = 43;
            this.prepay.Text = "0";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status.Location = new System.Drawing.Point(127, 76);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(21, 29);
            this.status.TabIndex = 44;
            this.status.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(47, 403);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 29);
            this.label14.TabIndex = 45;
            this.label14.Text = "Экскурсовод";
            // 
            // guide
            // 
            this.guide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guide.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guide.FormattingEnabled = true;
            this.guide.Location = new System.Drawing.Point(232, 400);
            this.guide.Name = "guide";
            this.guide.Size = new System.Drawing.Size(319, 37);
            this.guide.TabIndex = 46;
            this.guide.DropDown += new System.EventHandler(this.ComboBox_DropDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(47, 288);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(174, 29);
            this.label15.TabIndex = 49;
            this.label15.Text = "Мероприятие";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(47, 342);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 29);
            this.label16.TabIndex = 50;
            this.label16.Text = "Вид цены";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(47, 460);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(161, 29);
            this.label17.TabIndex = 51;
            this.label17.Text = "Доп. услуги*:";
            // 
            // gridAServ
            // 
            this.gridAServ.AllowUserToAddRows = false;
            this.gridAServ.AllowUserToDeleteRows = false;
            this.gridAServ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridAServ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAServ.Location = new System.Drawing.Point(49, 501);
            this.gridAServ.Name = "gridAServ";
            this.gridAServ.RowHeadersWidth = 51;
            this.gridAServ.RowTemplate.Height = 24;
            this.gridAServ.Size = new System.Drawing.Size(535, 173);
            this.gridAServ.TabIndex = 52;
            this.gridAServ.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAServ_CellValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(332, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 29);
            this.label11.TabIndex = 53;
            this.label11.Text = "₽";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(332, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 29);
            this.label12.TabIndex = 54;
            this.label12.Text = "₽";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.party);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.accom);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(634, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 193);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Число";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cost);
            this.groupBox2.Controls.Add(this.prepay);
            this.groupBox2.Controls.Add(this.status);
            this.groupBox2.Location = new System.Drawing.Point(634, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 122);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(590, 612);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(316, 51);
            this.label13.TabIndex = 57;
            this.label13.Text = "*Для удаления доп. услуги из заказа\r\nудалите количество единиц предоставляемой\r\nу" +
    "слуги или замените их на 0.";
            // 
            // serv
            // 
            this.serv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serv.FormattingEnabled = true;
            this.serv.Location = new System.Drawing.Point(232, 285);
            this.serv.Name = "serv";
            this.serv.Size = new System.Drawing.Size(374, 37);
            this.serv.TabIndex = 58;
            this.serv.DropDown += new System.EventHandler(this.ComboBox_DropDown);
            // 
            // price
            // 
            this.price.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price.FormattingEnabled = true;
            this.price.Location = new System.Drawing.Point(232, 339);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(374, 37);
            this.price.TabIndex = 59;
            this.price.DropDown += new System.EventHandler(this.ComboBox_DropDown);
            this.price.SelectedIndexChanged += new System.EventHandler(this.price_SelectedIndexChanged);
            // 
            // AddChangeDetOrdr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 751);
            this.Controls.Add(this.price);
            this.Controls.Add(this.serv);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridAServ);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.guide);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.meetpoint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.datetime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.contact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.age);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.school);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddChangeDetOrdr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddChangeOrdr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.party)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAServ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox school;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox age;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown party;
        private System.Windows.Forms.NumericUpDown accom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox datetime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox meetpoint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Label prepay;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox guide;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView gridAServ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox serv;
        private System.Windows.Forms.ComboBox price;
    }
}