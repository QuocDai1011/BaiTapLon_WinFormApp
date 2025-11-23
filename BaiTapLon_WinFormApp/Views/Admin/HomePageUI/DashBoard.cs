using BaiTapLon_WinFormApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.HomePageUI
{
    public partial class DashBoard : UserControl
    {
        private readonly ServiceHub _serviceHub;
        public DashBoard(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            initDashboard();
        }

        private void initDashboard()
        {
            lblStudentsValue.Text = _serviceHub.StudentService.getAllStudent().Count.ToString();
            lblClassesValue.Text = _serviceHub.ClassService.getAllClass().Count.ToString();
            //lblTeachersValue.Text = _serviceHub.
        }
    }
}
