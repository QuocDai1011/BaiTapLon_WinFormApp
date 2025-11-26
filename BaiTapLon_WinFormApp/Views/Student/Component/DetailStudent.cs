using BaiTapLon_WinFormApp.Services.Interfaces;

namespace EnglishCenterManagement.UI.Views.Student.Component
{
    public partial class DetailStudent : UserControl
    {
        private readonly IStudentService _context;
        private int _currentStudentId;
        public DetailStudent(IStudentService context)
        {
            InitializeComponent();
            _context = context;
        }

        public void LoadDetailStudent(int studentId)
        {
            _currentStudentId = studentId;
            var student = _context.GetStudentById(_currentStudentId);
            if (student == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên");
                return;
            }

            string genderValue = student.Gender ? "Nam" : "Nữ";

            guna2HtmlLabelUserName.Text = student.UserName;
            guna2TextBoxFullName.Text = student.FullName;
            guna2TextBoxEmail.Text = student.Email;
            guna2TextBoxGender.Text = genderValue;
            guna2TextBoxDateBirth.Text = student.DateOfBirth.ToString();
            guna2TextBoxPhone.Text = student.PhoneNumber;
            guna2TextBoxPhoneParent.Text = student.PhoneNumberOfParents.ToString();
            guna2TextBoxAddress.Text = student.Address;

            if (guna2TextBoxGender.Text == "Nam")
                guna2RadioButtonBoy.Checked = true;
            else if (guna2TextBoxGender.Text == "Nữ")
                guna2RadioButtonGirl.Checked = true;
        }

        private void guna2ButtonEdit_Click(object sender, EventArgs e)
        {
            guna2TextBoxFullName.ReadOnly = false;

            guna2TextBoxDateBirth.Visible = false;
            guna2DateTimePickerDateBirth.Visible = true;

            guna2TextBoxPhone.ReadOnly = false;
            guna2TextBoxPhoneParent.ReadOnly = false;
            guna2TextBoxAddress.ReadOnly = false;

            guna2TextBoxGender.Visible = false;
            guna2RadioButtonBoy.Visible = true;
            guna2RadioButtonGirl.Visible = true;

            guna2ButtonEdit.Visible = false;
            guna2ButtonSave.Visible = true;
        }

        private void guna2ButtonSave_Click(object sender, EventArgs e)
        {
            string phone = guna2TextBoxPhone.Text.Trim();
            string parentPhone = guna2TextBoxPhoneParent.Text.Trim();

            // --- KIỂM TRA SỐ ĐIỆN THOẠI 10 SỐ, BẮT ĐẦU BẰNG 0 ---
            bool IsValidPhone(string p) =>
                p.Length == 10 && p.StartsWith("0") && p.All(char.IsDigit);

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Số điện thoại học sinh phải gồm 10 số và bắt đầu bằng số 0.");
                return;
            }

            if (!IsValidPhone(parentPhone))
            {
                MessageBox.Show("Số điện thoại phụ huynh phải gồm 10 số và bắt đầu bằng số 0.");
                return;
            }

            if(phone == parentPhone)
            {
                MessageBox.Show("Số điện thoại bị trùng với nhau");
                return;
            }

            if (guna2RadioButtonBoy.Checked)
                guna2TextBoxGender.Text = "Nam";
            else if (guna2RadioButtonGirl.Checked)
                guna2TextBoxGender.Text = "Nữ";

            // Lấy ngày sinh từ DatePicker
            DateOnly dob = DateOnly.FromDateTime(guna2DateTimePickerDateBirth.Value);
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            // --- KIỂM TRA NGÀY THÁNG SO VỚI HIỆN TẠI ---
            // tuổi < 4 => không hợp lệ
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--; // điều chỉnh nếu chưa qua sinh nhật năm nay

            if (age < 4)
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Học sinh phải ít nhất 4 tuổi.");
                return;  // dừng lại, không chạy tiếp
            }

            var updated = new BaiTapLon_WinFormApp.Models.Student()
                {
                    FullName = guna2TextBoxFullName.Text,
                    Email = guna2TextBoxEmail.Text,
                    Gender = guna2TextBoxGender.Text == "Nam",
                    DateOfBirth = DateOnly.FromDateTime(guna2DateTimePickerDateBirth.Value),
                    PhoneNumber = guna2TextBoxPhone.Text,
                    PhoneNumberOfParents = guna2TextBoxPhoneParent.Text,
                    Address = guna2TextBoxAddress.Text
                };

            bool result = _context.UpdateStudent(_currentStudentId, updated);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");

                // Khoá lại
                guna2TextBoxFullName.ReadOnly = true;
                guna2TextBoxGender.ReadOnly = true;

                guna2TextBoxDateBirth.Visible = false;
                guna2DateTimePickerDateBirth.Visible = true;

                guna2TextBoxPhone.ReadOnly = true;
                guna2TextBoxPhoneParent.ReadOnly = true;
                guna2TextBoxAddress.ReadOnly = true;

                guna2TextBoxGender.Visible = true;
                guna2RadioButtonBoy.Visible = false;
                guna2RadioButtonGirl.Visible = false;

                guna2ButtonSave.Visible = false;
                guna2ButtonEdit.Visible = true;   // hiện lại nút Edit
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật!");
            }
        }

    }
}
