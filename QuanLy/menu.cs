using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void btnChonanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh sản phẩm";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picAnh.ImageLocation = openFileDialog.FileName;
            }
        }

        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenSanPham = txtTenSP.Text;
            decimal gia = decimal.Parse(txtGia.Text);
            string hinhAnhPath = picAnh.ImageLocation;

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                conn.Open();
                string query = "INSERT INTO SanPham (TenSanPham, Gia, HinhAnh) VALUES (@TenSP, @Gia, @HinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSP", tenSanPham);
                cmd.Parameters.AddWithValue("@Gia", gia);
                cmd.Parameters.AddWithValue("@HinhAnh", hinhAnhPath);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công!");
            }
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                conn.Open();
                string query = "SELECT * FROM SanPham"; // Lấy tất cả sản phẩm từ bảng
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSanPham.DataSource = dt; // Đổ dữ liệu vào DataGridView
            }
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu ngay khi mở form
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1️⃣ Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtGia.Text) ||
                string.IsNullOrWhiteSpace(picAnh.ImageLocation))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Lấy dữ liệu từ form
            string tenSanPham = txtTenSP.Text;
            if (!decimal.TryParse(txtGia.Text, out decimal gia))
            {
                MessageBox.Show("Giá sản phẩm phải là một số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hinhAnhPath = picAnh.ImageLocation;

            // 3️⃣ Thêm dữ liệu vào CSDL
            try
            {
                using (SqlConnection conn = new SqlConnection("your_connection_string"))
                {
                    conn.Open();
                    string query = "INSERT INTO SanPham (TenSanPham, Gia, HinhAnh) VALUES (@TenSP, @Gia, @HinhAnh)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenSP", tenSanPham);
                    cmd.Parameters.AddWithValue("@Gia", gia);
                    cmd.Parameters.AddWithValue("@HinhAnh", hinhAnhPath);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Cập nhật lại DataGridView
                        ClearForm(); // Xóa dữ liệu trên form
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ClearForm()
        {
            txtTenSP.Clear();
            txtGia.Clear();
            picAnh.Image = null;
            picAnh.ImageLocation = string.Empty;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1️⃣ Kiểm tra có chọn hàng không
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Lấy ID sản phẩm từ hàng được chọn
            string maSanPham = dgvSanPham.SelectedRows[0].Cells["IDSanPham"].Value.ToString();

            // 3️⃣ Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm mã {maSanPham} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 4️⃣ Thực hiện xóa trong CSDL
                try
                {
                    using (SqlConnection conn = new SqlConnection("your_connection_string"))
                    {
                        conn.Open();
                        string query = "DELETE FROM SanPham WHERE IDSanPham = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", maSanPham);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // 5️⃣ Kiểm tra kết quả xóa
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // 1️⃣ Xóa trắng các ô nhập liệu
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGia.Clear();

            // 2️⃣ Xóa hình ảnh trong PictureBox
            picAnh.Image = null;

            // 3️⃣ Đặt lại trạng thái các nút (nếu cần)
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            // 4️⃣ Thông báo hoàn tất
            MessageBox.Show("Đã hủy thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // 1️⃣ Lấy từ khóa tìm kiếm
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Tìm kiếm trong CSDL
            try
            {
                using (SqlConnection conn = new SqlConnection("your_connection_string"))
                {
                    conn.Open();

                    // 3️⃣ Câu lệnh SQL tìm kiếm
                    string query = @"
                SELECT * FROM SanPham
                WHERE TenSanPham LIKE @TuKhoa OR IDSanPham LIKE @TuKhoa";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", $"%{tuKhoa}%");

                    // 4️⃣ Đổ dữ liệu vào DataGridView
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSanPham.DataSource = dt;

                    // 5️⃣ Thông báo nếu không tìm thấy
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm nào!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

