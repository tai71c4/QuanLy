namespace QuanLy
{
    partial class menu
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.txtTimKiem = new System.Windows.Forms.Button();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.grbDanhsach = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnChonanh = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.grbDanhsach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(624, 56);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(146, 22);
            this.txtGia.TabIndex = 34;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(311, 124);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(177, 22);
            this.txtTenSP.TabIndex = 33;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(310, 59);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(178, 22);
            this.txtMaSP.TabIndex = 32;
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(63, 24);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(100, 122);
            this.picAnh.TabIndex = 31;
            this.picAnh.TabStop = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(808, 195);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(108, 32);
            this.txtTimKiem.TabIndex = 30;
            this.txtTimKiem.Text = "Tìm Kiếm";
            this.txtTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(678, 201);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(124, 22);
            this.txtTK.TabIndex = 29;
            // 
            // grbDanhsach
            // 
            this.grbDanhsach.Controls.Add(this.dgvSanPham);
            this.grbDanhsach.Location = new System.Drawing.Point(48, 245);
            this.grbDanhsach.Name = "grbDanhsach";
            this.grbDanhsach.Size = new System.Drawing.Size(880, 169);
            this.grbDanhsach.TabIndex = 28;
            this.grbDanhsach.TabStop = false;
            this.grbDanhsach.Text = "Danh sách";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(155, 197);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(63, 197);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(247, 197);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 32);
            this.btnSua.TabIndex = 25;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(520, 195);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 34);
            this.btnHuy.TabIndex = 24;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnChonanh
            // 
            this.btnChonanh.Location = new System.Drawing.Point(337, 197);
            this.btnChonanh.Name = "btnChonanh";
            this.btnChonanh.Size = new System.Drawing.Size(75, 32);
            this.btnChonanh.TabIndex = 23;
            this.btnChonanh.Text = "Chọn ảnh";
            this.btnChonanh.UseVisualStyleBackColor = true;
            this.btnChonanh.Click += new System.EventHandler(this.btnChonanh_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(430, 197);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 32);
            this.btnLuu.TabIndex = 22;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(197, 62);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(88, 16);
            this.lblMaSP.TabIndex = 20;
            this.lblMaSP.Text = "Mã sản phẩm";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(578, 62);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(28, 16);
            this.lblGia.TabIndex = 19;
            this.lblGia.Text = "Giá";
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(192, 130);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(93, 16);
            this.lblTenSP.TabIndex = 18;
            this.lblTenSP.Text = "Tên sản phẩm";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Location = new System.Drawing.Point(503, 9);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(47, 16);
            this.lblMenu.TabIndex = 17;
            this.lblMenu.Text = "MENU";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.Location = new System.Drawing.Point(3, 18);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(874, 148);
            this.dgvSanPham.TabIndex = 35;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 467);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.picAnh);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.grbDanhsach);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnChonanh);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblMaSP);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.lblMenu);
            this.Name = "menu";
            this.Text = "menu";
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.grbDanhsach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button txtTimKiem;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.GroupBox grbDanhsach;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnChonanh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.DataGridView dgvSanPham;
    }
}