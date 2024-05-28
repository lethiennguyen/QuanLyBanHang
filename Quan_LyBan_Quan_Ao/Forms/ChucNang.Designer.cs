
namespace Quan_LyBan_Quan_Ao.Forms
{
    partial class ChucNang
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Search_SanPham = new MetroFramework.Controls.MetroButton();
            this.txt_SanPham = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_XoaSP = new Guna.UI2.WinForms.Guna2Button();
            this.ThemSanPham = new Guna.UI2.WinForms.Guna2Button();
            this.iconSplitButton1 = new FontAwesome.Sharp.IconSplitButton();
            this.iconSplitButton2 = new FontAwesome.Sharp.IconSplitButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_XoaSP);
            this.splitContainer1.Panel2.Controls.Add(this.ThemSanPham);
            this.splitContainer1.Size = new System.Drawing.Size(1090, 667);
            this.splitContainer1.SplitterDistance = 778;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(778, 667);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Search_SanPham);
            this.panel1.Controls.Add(this.txt_SanPham);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 86);
            this.panel1.TabIndex = 1;
            // 
            // btn_Search_SanPham
            // 
            this.btn_Search_SanPham.BackColor = System.Drawing.Color.White;
            this.btn_Search_SanPham.BackgroundImage = global::Quan_LyBan_Quan_Ao.Properties.Resources.IconSearch;
            this.btn_Search_SanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Search_SanPham.Location = new System.Drawing.Point(167, 23);
            this.btn_Search_SanPham.Name = "btn_Search_SanPham";
            this.btn_Search_SanPham.Size = new System.Drawing.Size(48, 33);
            this.btn_Search_SanPham.TabIndex = 50;
            this.btn_Search_SanPham.UseSelectable = true;
            this.btn_Search_SanPham.Click += new System.EventHandler(this.txt_Search_SanPham_Click);
            // 
            // txt_SanPham
            // 
            this.txt_SanPham.BorderColor = System.Drawing.Color.Black;
            this.txt_SanPham.BorderRadius = 10;
            this.txt_SanPham.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_SanPham.DefaultText = "Tìm kiếm sản phẩm";
            this.txt_SanPham.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_SanPham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_SanPham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_SanPham.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_SanPham.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_SanPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_SanPham.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_SanPham.Location = new System.Drawing.Point(3, 20);
            this.txt_SanPham.Name = "txt_SanPham";
            this.txt_SanPham.PasswordChar = '\0';
            this.txt_SanPham.PlaceholderText = "";
            this.txt_SanPham.SelectedText = "";
            this.txt_SanPham.Size = new System.Drawing.Size(158, 36);
            this.txt_SanPham.TabIndex = 0;
            this.txt_SanPham.TextChanged += new System.EventHandler(this.txt_SanPham_TextChanged);
            // 
            // btn_XoaSP
            // 
            this.btn_XoaSP.BorderRadius = 10;
            this.btn_XoaSP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_XoaSP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_XoaSP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_XoaSP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_XoaSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_XoaSP.ForeColor = System.Drawing.Color.White;
            this.btn_XoaSP.Location = new System.Drawing.Point(73, 472);
            this.btn_XoaSP.Name = "btn_XoaSP";
            this.btn_XoaSP.Size = new System.Drawing.Size(180, 45);
            this.btn_XoaSP.TabIndex = 0;
            this.btn_XoaSP.Text = "Xóa Sản Phẩm";
            this.btn_XoaSP.Click += new System.EventHandler(this.btn_XoaSP_Click);
            // 
            // ThemSanPham
            // 
            this.ThemSanPham.BorderRadius = 10;
            this.ThemSanPham.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ThemSanPham.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ThemSanPham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ThemSanPham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ThemSanPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ThemSanPham.ForeColor = System.Drawing.Color.White;
            this.ThemSanPham.Location = new System.Drawing.Point(73, 538);
            this.ThemSanPham.Name = "ThemSanPham";
            this.ThemSanPham.Size = new System.Drawing.Size(180, 45);
            this.ThemSanPham.TabIndex = 0;
            this.ThemSanPham.Text = "Thêm Sản Phẩm";
            this.ThemSanPham.Click += new System.EventHandler(this.ThemSanPham_Click);
            // 
            // iconSplitButton1
            // 
            this.iconSplitButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconSplitButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconSplitButton1.IconColor = System.Drawing.Color.Black;
            this.iconSplitButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSplitButton1.IconSize = 48;
            this.iconSplitButton1.Name = "iconSplitButton1";
            this.iconSplitButton1.Rotation = 0D;
            this.iconSplitButton1.Size = new System.Drawing.Size(23, 23);
            this.iconSplitButton1.Text = "iconSplitButton1";
            // 
            // iconSplitButton2
            // 
            this.iconSplitButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconSplitButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconSplitButton2.IconColor = System.Drawing.Color.Black;
            this.iconSplitButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSplitButton2.IconSize = 48;
            this.iconSplitButton2.Name = "iconSplitButton2";
            this.iconSplitButton2.Rotation = 0D;
            this.iconSplitButton2.Size = new System.Drawing.Size(23, 23);
            this.iconSplitButton2.Text = "iconSplitButton2";
            // 
            // ChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 667);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChucNang";
            this.Text = "ChucNang";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FontAwesome.Sharp.IconSplitButton iconSplitButton1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_SanPham;
        private Guna.UI2.WinForms.Guna2Button btn_XoaSP;
        private Guna.UI2.WinForms.Guna2Button ThemSanPham;
        private FontAwesome.Sharp.IconSplitButton iconSplitButton2;
        private MetroFramework.Controls.MetroButton btn_Search_SanPham;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}