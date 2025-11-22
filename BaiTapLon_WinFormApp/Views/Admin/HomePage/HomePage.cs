using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Services.Interfaces;
using BaiTapLon_WinFormApp.Views.Admin.StudentUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon_WinFormApp.Views.Admin.MyClass;
namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    public partial class HomePage : Form
    {

        private readonly ServiceHub _serviceHub;
        public HomePage(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _serviceHub.ClassService.RunAutoUpdate();
            loadDashBoardView();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            resetFeatureClicked();
            pnlDashboard.BackColor = Color.FromArgb(240, 245, 255);
            loadDashBoardView();
        }

        private void loadDashBoardView()
        {
            contentPanel.Controls.Clear();
            var dashboardView = new DashBoard();
            dashboardView.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(dashboardView);
        }

        private void studentManagement_Click(object sender, EventArgs e)
        {
            resetFeatureClicked();
            pnlStudentList.BackColor = Color.FromArgb(240, 245, 255);
            contentPanel.Controls.Clear();
            var studentManagementView = new ManageStudent(_serviceHub);
            studentManagementView.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(studentManagementView);
        }

        private void resetFeatureClicked()
        {
            pnlManagement.BackColor = Color.White;
            pnlMyClass.BackColor = Color.White;
            pnlInvoice.BackColor = Color.White;
            pnlDashboard.BackColor = Color.White;
            pnlCalendar.BackColor = Color.White;
            pnlStudentList.BackColor = Color.White;

        }

        private void management_Click(object sender, EventArgs e)
        {
            resetFeatureClicked();
            pnlManagement.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void myClass_Click(object sender, EventArgs e)
        {
            resetFeatureClicked();
            pnlMyClass.BackColor = Color.FromArgb(240, 245, 255);
            List<Class> classes = _serviceHub.ClassService.getAllClass().ToList();
            List<(string, string, int)> cardItems = new List<(string, string, int)>();
            foreach (Class cls in classes) {
                // Sử dụng StartDate - EndDate hoặc imagePath nếu muốn hiển thị ảnh
                string typeText = $"{cls.StartDate:dd/MM/yyyy} - {cls.EndDate:dd/MM/yyyy}";
                cardItems.Add((cls.ClassName, typeText, cls.ClassId));
            }
            var myClassView = new ManageClass(cardItems, _serviceHub) { 
                Dock = DockStyle.Fill
            };
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(myClassView);

        }

        private void invoice_Click(object sender, EventArgs e)
        {
            resetFeatureClicked();
            pnlInvoice.BackColor = Color.FromArgb(240, 245, 255);
        }

        private void calendar_Click(object sender, EventArgs e)
        {
            resetFeatureClicked();
            pnlCalendar.BackColor = Color.FromArgb(240, 245, 255);
        }


    }
}
