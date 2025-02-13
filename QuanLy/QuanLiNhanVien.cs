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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string idTaiKhoan = txtIDTaiKhoan.Text.Trim();

            if (string.IsNullOrEmpty(idTaiKhoan))
            {
                MessageBox.Show("Vui lòng nhập ID Tài Khoản để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // kết nối cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection())
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
                        txtHoten.Text = dt.Rows[0]["HoTen"].ToString();
                        txtSDT.Text = dt.Rows[0]["SoDienThoai"].ToString();
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

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            string idNhanVien = txtIDNhanVien.Text.Trim();
            string hoTen = txtHoten.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();
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
            //kết nối cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection())
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

        // Hàm xóa trắng các ô nhập sau khi thêm nhân viên
        private void ClearFields()
        {
            txtIDNhanVien.Clear();
            txtHoten.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtIDTaiKhoan.Clear();
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



        private void QuanLyNhanVien_load(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;

            // Định dạng tiêu đề lớn hơn
            /*lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;*/

            // Định dạng label
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    lbl.ForeColor = Color.Black;
                }
            }

            // Định dạng textbox
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 12);
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // Định dạng nút bấm
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btn.BackColor = Color.SteelBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    // Hiệu ứng hover cho nút
                    btn.MouseEnter += (s, args) => { btn.BackColor = Color.DarkBlue; };
                    btn.MouseLeave += (s, args) => { btn.BackColor = Color.SteelBlue; };

                }
            }
        }
    }
}


