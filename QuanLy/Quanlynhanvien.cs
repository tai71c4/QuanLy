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
    public partial class Quanlynhanvien : Form
    {
        public Quanlynhanvien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            {
                string idNhanVien = txtIDNhanVien.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                string soDienThoai = txtSoDienThoai.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string idTaiKhoan = txtIDTaiKhoan.Text.Trim();

                if (string.IsNullOrEmpty(idNhanVien) || string.IsNullOrEmpty(hoTen) ||
                    string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi) ||
                    string.IsNullOrEmpty(idTaiKhoan))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO NhanVien (ID, HoTen, SoDienThoai, DiaChi, IDTaiKhoan) " +
                               "VALUES (@ID, @HoTen, @SoDienThoai, @DiaChi, @IDTaiKhoan)";

                using (SqlConnection conn = new SqlConnection(QuanLyBanDoAnNhanhDataSet))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", idNhanVien);
                            cmd.Parameters.AddWithValue("@HoTen", hoTen);
                            cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                            cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                            cmd.Parameters.AddWithValue("@IDTaiKhoan", idTaiKhoan);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Hàm xóa trắng các ô nhập sau khi thêm nhân viên
        private void ClearFields()
        {
            txtIDNhanVien.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtIDTaiKhoan.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            {
                string idNhanVien = txtIDNhanVien.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                string soDienThoai = txtSoDienThoai.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();

                if (string.IsNullOrEmpty(idNhanVien))
                {
                    MessageBox.Show("Vui lòng nhập ID Nhân Viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(QuanLyBanDoAnNhanhDataSet))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE NhanVien SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi WHERE ID = @IDNhanVien";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên hoặc sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit(); // Đóng toàn bộ ứng dụng
                }
            }
        }
            // 🟢 Chức năng Tìm kiếm nhân viên theo ID Tài Khoản
private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string idTaiKhoan = txtIDTaiKhoan.Text.Trim(); // Lấy ID tài khoản từ ô nhập liệu

            if (string.IsNullOrEmpty(idTaiKhoan))
            {
                MessageBox.Show("Vui lòng nhập ID Tài Khoản để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(QuanLyBanDoAnNhanhDataSet))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM NhanVien WHERE IDTaiKhoan = @IDTaiKhoan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDTaiKhoan", idTaiKhoan);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtIDNhanVien.Text = dt.Rows[0]["ID"].ToString();
                        txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                        txtSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                        txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
  

