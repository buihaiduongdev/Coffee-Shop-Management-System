using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;

namespace Restaurant_Management_System.Setting
{
    public partial class frmSettingView : Form
    {
        private int id;
        private string language = ucLogin.languages;

        public frmSettingView(int id)
        {
            InitializeComponent();
            this.id = id;
            txtEmployeeID.Enabled = false;

            // Thêm danh sách vai trò cố định vào cbbRole
            cbbRole.DataSource = language == "en" ? new List<string> () {"Manager", "Receptionist" }: new List<string>() { "Quản lý", "Tiếp tân" };

            // Cấu hình nền và màu chữ tổng thể
            txtAbout.BackColor = Color.FromArgb(245, 238, 230);
            txtAbout.ForeColor = Color.FromArgb(40, 26, 13); 
            txtAbout.BorderStyle = BorderStyle.None;          
            txtAbout.ReadOnly = true;
            txtAbout.Font = new Font("Segoe UI", 10.5f, FontStyle.Regular);
            cbbRole.Enabled = false;
           
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            txtLastName.Enabled = false;
            txtFirstName.Enabled = false;
            txtPhone.Enabled = false;
            cbbRole.Enabled = false;
            string query = "SELECT EmployeeID, LastName, FirstName, Phone, Role, Image FROM Employees WHERE EmployeeID = @EmployeeID";
            SqlParameter[] parameters = { new SqlParameter("@EmployeeID", id) };

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtEmployeeID.Text = dt.Rows[0]["EmployeeID"].ToString();
                    txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                    txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    string role = dt.Rows[0]["Role"].ToString();
                    if (language == "vi") role = role == "Mangaer" ? "Quản lý" : role == "Receptionist" ? "Tiếp tân" : role;
                    cbbRole.SelectedItem = role;

                    if (dt.Rows[0]["Image"] != DBNull.Value && dt.Rows[0]["Image"] != null)
                    {
                        byte[] imageData = (byte[])dt.Rows[0]["Image"];
                        if (imageData.Length > 0)
                        {
                            try
                            {
                                picEmployeeImage.Image = ConvertByteArrayToImage(imageData);
                                picEmployeeImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            catch (Exception)
                            {
                                picEmployeeImage.Image = null;
                            }
                        }
                        else
                        {
                            picEmployeeImage.Image = null;
                        }
                    }
                    else
                    {
                        picEmployeeImage.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy nhân viên với ID {id}!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                throw new ArgumentException("Dữ liệu byte trống hoặc null.");
            }

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                if (ms.Length == 0)
                {
                    throw new InvalidOperationException("MemoryStream trống.");
                }

                Image image = Image.FromStream(ms);
                if (image.Width <= 0 || image.Height <= 0)
                {
                    throw new InvalidOperationException("Kích thước ảnh không hợp lệ.");
                }
                return image;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô nhập liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                cbbRole.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin! Không được để trống bất kỳ ô nào.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số điện thoại (chỉ chứa chữ số)
            string phonePattern = @"^\d+$";
            if (!Regex.IsMatch(txtPhone.Text, phonePattern))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa các chữ số (0-9)!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tiến hành lưu dữ liệu
            string updateQuery = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Phone = @Phone, Role = @Role WHERE EmployeeID = @EmployeeID";
            SqlParameter[] parameters = {
                new SqlParameter("@LastName", txtLastName.Text),
                new SqlParameter("@FirstName", txtFirstName.Text),
                new SqlParameter("@Phone", txtPhone.Text),
                new SqlParameter("@Role", cbbRole.SelectedItem.ToString()),
                new SqlParameter("@EmployeeID", id)
            };

            try
            {
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(updateQuery, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtLastName.Enabled = true;
            txtFirstName.Enabled = true;
            txtPhone.Enabled = true;
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (language == "en") openFileDialog.Title = "Choose your image";
            else openFileDialog.Title = "Chọn ảnh của bạn";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picEmployeeImage.Image = Image.FromFile(openFileDialog.FileName);
                    picEmployeeImage.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] imageBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picEmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }

                    string query = "UPDATE Employees SET Image = @Image WHERE EmployeeID = @EmployeeID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@Image", imageBytes),
                        new SqlParameter("@EmployeeID", id)
                    };

                    int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                    if (rowsAffected > 0)
                    {
                        if (language == "en") MessageBox.Show("Image has been updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Ảnh đã được cập nhật thành công!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (language == "en") MessageBox.Show("No chang were made", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Không có thay đổi nào được thực hiện.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    if (language == "en") MessageBox.Show($"Error when update images: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show($"Lỗi khi tải ảnh lên: {ex.Message}\nStack Trace: {ex.StackTrace}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picEmployeeImage.Image = null;
                }
            }
        }

        // Thêm sự kiện cho nút "About Project"
        private void btnAboutProject_Click(object sender, EventArgs e)
        {
            txtAbout.Clear(); // Xoá nội dung cũ
            txtAbout.DetectUrls = true;

            // Hàm chèn văn bản định dạng
            void AppendText(string text, FontStyle style, float size = 12.5f)
            {
                txtAbout.SelectionStart = txtAbout.TextLength;
                txtAbout.SelectionLength = 0;
                txtAbout.SelectionFont = new Font("Segoe UI", size, style);
                txtAbout.AppendText(text);
            }

            // Tiêu đề
            AppendText("  🔷 THÔNG TIN DỰ ÁN\n", FontStyle.Bold, 13);
            AppendText("  ────────────────────────────\n", FontStyle.Regular);

            // Nội dung dự án
            AppendText("  📌 Tên dự án: ", FontStyle.Bold);
            AppendText("  Coffee Shop Management System\n", FontStyle.Bold);

            AppendText("  📖 Mô tả: ", FontStyle.Bold);
            AppendText("  Hệ thống quản lý quán cà phê,nhân viên, sản phẩm, đơn hàng.\n", FontStyle.Regular);

            AppendText("  📅 Ngày tạo: ", FontStyle.Bold);
            AppendText("  17/01/2025\n", FontStyle.Regular);

            AppendText("  ✅ Ngày hoàn thành: ", FontStyle.Bold);
            AppendText("  17/04/2025\n", FontStyle.Regular);

            AppendText("  ⏱️ Thời gian thực hiện: ", FontStyle.Bold);
            AppendText("   3 tháng\n", FontStyle.Regular);

            AppendText("  🧑‍💻 Ngôn ngữ: ", FontStyle.Bold);
            AppendText("  C# (Windows Forms)\n\n", FontStyle.Regular);

            // GitHub project
            AppendText("  🌐 Link GitHub Project:\n", FontStyle.Bold);
            AppendText("  https://github.com/buihaiduongdev/Coffee-Shop-Management-System\n\n", FontStyle.Regular);

            // GitHub ClockIn
            AppendText("  🕒 Chức năng chấm công:\n", FontStyle.Bold);
            AppendText("  https://github.com/buihaiduongdev/WinFormClockIn\n\n", FontStyle.Regular);

            // Thành viên
            AppendText("  👥 Thành viên nhóm:\n", FontStyle.Bold);
            AppendText("  - Đinh Văn Sáng: https://github.com/SangDinhVan\n", FontStyle.Regular);
            AppendText("  - Châu Kim Lương: https://github.com/ChauKimLuong\n", FontStyle.Regular);
            AppendText("  - Thái Quang Huy: https://github.com/HuyQuangThai\n", FontStyle.Regular);
            AppendText("  - Võ An Thái: https://github.com/Anthai2\n", FontStyle.Regular);
            AppendText("  - Bùi Hải Dương: https://github.com/buihaiduongdev\n", FontStyle.Regular);
        }


        private void txtAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở liên kết: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAbout_TextChanged(object sender, EventArgs e)
        {

        }

        private void picEmployeeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn ảnh nhân viên";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picEmployeeImage.Image = Image.FromFile(openFileDialog.FileName);
                    picEmployeeImage.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] imageBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picEmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }

                    string query = "UPDATE Employees SET Image = @Image WHERE EmployeeID = @EmployeeID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@Image", imageBytes),
                        new SqlParameter("@EmployeeID", id)
                    };

                    int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                    if (rowsAffected > 0)
                    {
                        if (language == "en")
                            MessageBox.Show("Image has been updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Ảnh đã được cập nhật thành công!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (language == "en")
                            MessageBox.Show("No changes were made.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Không có thay đổi nào được thực hiện.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    if (language == "en")
                        MessageBox.Show($"Error uploading image: {ex.Message}\nStack Trace: {ex.StackTrace}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show($"Lỗi khi tải ảnh lên: {ex.Message}\nStack Trace: {ex.StackTrace}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picEmployeeImage.Image = null;
                }
            }
        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            lblFirstname.Text = LocalizationHelper.GetString("lblFirstName");
            lblLastname.Text = LocalizationHelper.GetString("lblLastName");
            lblPhone.Text = LocalizationHelper.GetString("lblPhone");
            lblRole.Text = LocalizationHelper.GetString("lblRole");
        }

        private void frmSettingView_Load(object sender, EventArgs e)
        {
            load_language(language);
        }
    }
}