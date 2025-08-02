namespace DesktopPsychologist_WF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAboutMe = new System.Windows.Forms.Button();
            this.btnThemes = new System.Windows.Forms.Button();
            this.btnPrice = new System.Windows.Forms.Button();
            this.btnRewiews = new System.Windows.Forms.Button();
            this.btnContacts = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel_empty = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Miama Nueva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(121)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(101, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 101);
            this.label1.TabIndex = 1;
            this.label1.Text = "Услуги психолога";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::DesktopPsychologist_WF.Properties.Resources.psy;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnAboutMe
            // 
            this.btnAboutMe.AutoSize = true;
            this.btnAboutMe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAboutMe.FlatAppearance.BorderSize = 0;
            this.btnAboutMe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orchid;
            this.btnAboutMe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnAboutMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutMe.Font = new System.Drawing.Font("Sober", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAboutMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnAboutMe.Location = new System.Drawing.Point(0, 0);
            this.btnAboutMe.Margin = new System.Windows.Forms.Padding(0);
            this.btnAboutMe.Name = "btnAboutMe";
            this.btnAboutMe.Size = new System.Drawing.Size(138, 50);
            this.btnAboutMe.TabIndex = 4;
            this.btnAboutMe.Text = "Обо мне";
            this.btnAboutMe.UseVisualStyleBackColor = true;
            this.btnAboutMe.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnThemes
            // 
            this.btnThemes.AutoSize = true;
            this.btnThemes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemes.FlatAppearance.BorderSize = 0;
            this.btnThemes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orchid;
            this.btnThemes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnThemes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemes.Font = new System.Drawing.Font("Sober", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnThemes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnThemes.Location = new System.Drawing.Point(0, 50);
            this.btnThemes.Margin = new System.Windows.Forms.Padding(0);
            this.btnThemes.Name = "btnThemes";
            this.btnThemes.Size = new System.Drawing.Size(138, 50);
            this.btnThemes.TabIndex = 4;
            this.btnThemes.Text = "Услуги";
            this.btnThemes.UseVisualStyleBackColor = true;
            this.btnThemes.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnPrice
            // 
            this.btnPrice.AutoSize = true;
            this.btnPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrice.FlatAppearance.BorderSize = 0;
            this.btnPrice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orchid;
            this.btnPrice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrice.Font = new System.Drawing.Font("Sober", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnPrice.Location = new System.Drawing.Point(0, 100);
            this.btnPrice.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(138, 50);
            this.btnPrice.TabIndex = 4;
            this.btnPrice.Text = "Стоимость";
            this.btnPrice.UseVisualStyleBackColor = true;
            this.btnPrice.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnRewiews
            // 
            this.btnRewiews.AutoSize = true;
            this.btnRewiews.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRewiews.FlatAppearance.BorderSize = 0;
            this.btnRewiews.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orchid;
            this.btnRewiews.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnRewiews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRewiews.Font = new System.Drawing.Font("Sober", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRewiews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnRewiews.Location = new System.Drawing.Point(0, 150);
            this.btnRewiews.Margin = new System.Windows.Forms.Padding(0);
            this.btnRewiews.Name = "btnRewiews";
            this.btnRewiews.Size = new System.Drawing.Size(138, 50);
            this.btnRewiews.TabIndex = 4;
            this.btnRewiews.Text = "Отзывы";
            this.btnRewiews.UseVisualStyleBackColor = true;
            this.btnRewiews.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnContacts
            // 
            this.btnContacts.AutoSize = true;
            this.btnContacts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContacts.FlatAppearance.BorderSize = 0;
            this.btnContacts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orchid;
            this.btnContacts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.btnContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContacts.Font = new System.Drawing.Font("Sober", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnContacts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnContacts.Location = new System.Drawing.Point(0, 200);
            this.btnContacts.Margin = new System.Windows.Forms.Padding(0);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(138, 50);
            this.btnContacts.TabIndex = 4;
            this.btnContacts.Text = "Контакты";
            this.btnContacts.UseVisualStyleBackColor = true;
            this.btnContacts.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.73577F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.26423F));
            this.tableLayoutPanel.Controls.Add(this.panelMenu, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panelContent, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.panel_empty, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 146);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(984, 811);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnContacts);
            this.panelMenu.Controls.Add(this.btnRewiews);
            this.panelMenu.Controls.Add(this.btnPrice);
            this.panelMenu.Controls.Add(this.btnThemes);
            this.panelMenu.Controls.Add(this.btnAboutMe);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(3, 70);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(138, 738);
            this.panelMenu.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.AutoSize = true;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(147, 53);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(834, 755);
            this.panelContent.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Orchid;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(144, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(840, 50);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Название текущего раздела";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_empty
            // 
            this.panel_empty.BackColor = System.Drawing.Color.Orchid;
            this.panel_empty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_empty.Location = new System.Drawing.Point(0, 0);
            this.panel_empty.Margin = new System.Windows.Forms.Padding(0);
            this.panel_empty.Name = "panel_empty";
            this.panel_empty.Size = new System.Drawing.Size(144, 50);
            this.panel_empty.TabIndex = 3;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Controls.Add(this.pictureBox1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 45);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(984, 101);
            this.panelTitle.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orchid;
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 45);
            this.panel1.TabIndex = 7;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogin.AutoSize = true;
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(121)))), ((int)(((byte)(196)))));
            this.btnLogin.Location = new System.Drawing.Point(882, 8);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 30);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Вход";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelUser
            // 
            this.labelUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUser.Location = new System.Drawing.Point(481, 13);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(385, 20);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "label2";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAboutMe;
        private System.Windows.Forms.Button btnThemes;
        private System.Windows.Forms.Button btnPrice;
        private System.Windows.Forms.Button btnRewiews;
        private System.Windows.Forms.Button btnContacts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panel_empty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label labelUser;
    }
}

