using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Utils;
using BaiTapLon_WinFormApp.Views.Admin.StudentUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.CourseUI
{
    public partial class ManageCourse : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private List<Course> _course;

        public ManageCourse(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            loadCourse();
        }


        private void loadCourse()
        {
            try
            {
                _course = _serviceHub.CourseService.getAllCourse();
                lblTotalCourses.Text = $"Tổng số: {_course.Count} khóa học";
                if(_course.Count <= 0)
                {
                    MessageHelper.ShowInfo("Chưa có khóa học nào trong hệ thống");
                    return;
                }

                loadDataGridView();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi khi tải danh sách khóa học");
            }
        }

        private void loadDataGridView() 
        {
            dgvCourses.Rows.Clear();
            int stt = 0;
            foreach (var course in _course)
            {
                int rowIndex = dgvCourses.Rows.Add();
                var row = dgvCourses.Rows[rowIndex];
                stt++;
                // Gán giá trị
                row.Cells["colCourseId"].Value = course.CourseId;
                row.Cells["colCourseCode"].Value = course.CourseCode;
                row.Cells["colCourseName"].Value = course.CourseName;
                row.Cells["colTutitionFee"].Value = course.TutitionFee.ToString("C3", CultureInfo.GetCultureInfo("vi-VN"));
                row.Cells["colNumberSession"].Value = course.NumberSessions;
                row.Cells["colDescription"].Value = course.Description;
                row.Cells["colLevel"].Value = course.Level;

                // Gán tag để truy xuất đối tượng
                row.Tag = course;

                // Căn giữa cho tất cả các ô
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // Header căn giữa
            foreach (DataGridViewColumn col in dgvCourses.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var courseForm = new CourseAddEditForm(_serviceHub);
            var result = courseForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadCourse();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if(dgvCourses.CurrentRow == null)
            {
                MessageHelper.ShowWarning("Vui lòng chọn một dòng để chỉnh sửa!");
                return;
            }


            Course? updateCourse = _serviceHub.CourseService.getCourseById((int)dgvCourses.CurrentRow.Cells["colCourseId"].Value);


            var courseForm = new CourseAddEditForm(_serviceHub, updateCourse);
            var result = courseForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadCourse();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null)
            {
                MessageHelper.ShowWarning("Vui lòng chọn một dòng để chỉnh sửa!");
                return;
            }

            if (!MessageHelper.ShowConfirmation("Bạn có chắc chắn muốn xóa khóa học này ?"))
                return;

            string message = _serviceHub.CourseService.deleteCourse((int)dgvCourses.CurrentRow.Cells["colCourseId"].Value);

            if (!string.IsNullOrEmpty(message))
            {
                MessageHelper.ShowError("Đã có lỗi trong quá trình xóa khóa học!\n" + message);
                return;
            }

            MessageHelper.ShowSuccess("Đã xóa khóa học thành công!");

            // load lại giao diện sau khi xóa
            loadCourse();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadCourse();
        }
    }
}
