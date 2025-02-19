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
    public partial class Quanlykhachhang : Form
    {
        string connectionString = "Server=.;Database=QuanLyDoAnNhanh;Integrated Security=True";
        public Quanlykhachhang()
        {
            InitializeComponent();
        }



        private void btnThem_Click_1(object sender, EventArgs e)
        {
            {
                {
                    // Lấy thông tin từ các ô nhập liệu
                    string hoTen = txtHoTen.Text.Trim();
                    string soDienThoai = txtSDT.Text.Trim();
                    string diemTichLuy = txtDiemTichLuy.Text.Trim();

                    // Kiểm tra dữ liệu đầu vào
                    if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm khách hàng vào cơ sở dữ liệu (giả lập)
                    string query = "INSERT INTO KhachHang (HoTen, SDT, DiemTichLuy) VALUES (@HoTen, @SDT, @DiemTichLuy)";

                    using (SqlConnection conn = new SqlConnection(connectionString))

                    {
                        try
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                                cmd.Parameters.AddWithValue("@SDT", soDienThoai);
                                cmd.Parameters.AddWithValue("@DiemTichLuy", string.IsNullOrEmpty(diemTichLuy) ? 0 : int.Parse(diemTichLuy));

                                int rows = cmd.ExecuteNonQuery();
                                if (rows > 0)
                                {
                                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Cập nhật lại danh sách khách hàng
                                    LoadCustomerData();
                                }
                                else
                                {
                                    MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void LoadCustomerData()
        {
            string query = "SELECT * FROM KhachHang";

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dgvKhachHang.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            // Lấy ID khách hàng từ TextBox
            string customerId = txtIDKhachHang.Text.Trim();

            // Kiểm tra nếu ID khách hàng bị rỗng
            if (string.IsNullOrEmpty(customerId))
            {
                MessageBox.Show("Vui lòng nhập ID khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi truy vấn SQL lấy thông tin điểm tích lũy
            string query = "SELECT IDKhachHang, HoTen, SDT, DiemTichLuy FROM KhachHang WHERE IDKhachHang = @IDKhachHang";

            // Kết nối đến CSDL
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDKhachHang", customerId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Hiển thị kết quả lên DataGridView
                    dgvDiemTichLuy.DataSource = dt;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            {
                // Lấy thông tin tìm kiếm từ TextBox
                string searchKeyword = txtDiemTichLuy.Text.Trim(); 

                // Kiểm tra nếu ô tìm kiếm bị rỗng
                if (string.IsNullOrEmpty(searchKeyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuỗi truy vấn SQL để tìm kiếm khách hàng theo Họ Tên hoặc SĐT
                string query = "SELECT IDKhachHang, HoTen, SDT, DiemTichLuy FROM KhachHang " +
                               "WHERE HoTen LIKE @Keyword OR SDT LIKE @Keyword";

                // Kết nối CSDL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Hiển thị kết quả lên DataGridView
                        dgvKhachHang.DataSource = dt;
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            {
                // Hiển thị hộp thoại xác nhận trước khi thoát
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                                                      "Xác nhận",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                // Nếu người dùng chọn "Yes", đóng form
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}      

        
    

