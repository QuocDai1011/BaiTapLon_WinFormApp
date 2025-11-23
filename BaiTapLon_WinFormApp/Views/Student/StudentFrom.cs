using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Implementations;
using BaiTapLon_WinFormApp.Services.Implementations;
using BaiTapLon_WinFormApp.Services.Interfaces;
using Guna.UI2.WinForms;
using EnglishCenterManagement.UI.Views.Student.Component;

namespace EnglishCenterManagement.UI.Views
{
    public partial class StudentFrom : Form
    {
        private readonly IStudentService _studentService;
        private readonly EnglishCenterDbContext _context;
        public StudentFrom()
        {
            InitializeComponent();
            _context = new EnglishCenterDbContext(); // gán cho biến thành viên
            var studentRepo = new StudentRepository(_context);
            _studentService = new StudentService(studentRepo, _context);

            RenderActions();
            RenderRightActions();
            RenderSideBarAction();
        }

        private void RenderActions()
        {
            List<ActionItem> actions = new List<ActionItem>()
            {
                new ActionItem()
                {

                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\home.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\group.png"),
                    OnClick = () => MessageBox.Show("Trang Group")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\calendar.png"),
                    OnClick = () => MessageBox.Show("Trang Calendar")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\classroom.png"),
                    OnClick = () => MessageBox.Show("Trang People")
                }
            };
            FlowLayoutPanel flowActions = panelHeader.Controls
                                             .OfType<FlowLayoutPanel>()
                                             .FirstOrDefault(f => f.Name == "flowActions");
            if (flowActions == null) return;

            foreach (var item in actions)
            {
                Button btn = new Button();
                Image image = new Bitmap(item.Icon, new Size(40, 40));
                btn.Image = image;
                btn.Size = new Size(70, 70);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Text = "";
                btn.Cursor = Cursors.Hand;
                btn.Margin = new Padding(30, 0, 0, 30);

                ToolTip tip = new ToolTip();
                tip.SetToolTip(btn, item.Text ?? "");

                btn.Click += (s, e) => item.OnClick();

                flowActions.Controls.Add(btn);
            }

            // Căn giữa flowActions sau khi đã có button
            flowActions.Left = (panelHeader.Width - flowActions.Width) / 2;
            flowActions.Top = (panelHeader.Height - flowActions.Height) / 2;
            flowActions.BringToFront(); // không bị flowRightActions đè
        }

        private void RenderRightActions()
        {
            FlowLayoutPanel flowRightActions = panelHeader.Controls.OfType<FlowLayoutPanel>()
                                                .FirstOrDefault(f => f.Name == "flowRightActions");
            if (flowRightActions == null) return;

            flowRightActions.Controls.Clear();

            // List button tương ứng ảnh bạn gửi: +, grid, message, bell, arrow
            List<ActionItem> icons = new List<ActionItem>()
            {
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\user.png"),
                    Text = "Đại",
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\add.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\multiButton.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\chat.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
                new ActionItem()
                {
                    Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\bell.png"),
                    OnClick = () => MessageBox.Show("Trang Home")
                },
            };

            foreach (var icon in icons)
            {
                Guna2CircleButton btn = new Guna2CircleButton();
                Image image = new Bitmap(icon.Icon, new Size(40, 40));
                btn.Image = image;
                btn.FillColor = Color.LightGray; // Màu nền bạn mu
                btn.Size = new Size(40, 40);
                btn.HoverState.FillColor = Color.Gray; // Màu khi hover
                //btn.FlatStyle = FlatStyle.Flat;
                //btn.FlatAppearance.BorderSize = 0;
                btn.Text = "";
                btn.Cursor = Cursors.Hand;
                btn.Margin = new Padding(5, 20, 20, 5);

                flowRightActions.Controls.Add(btn);
            }
        }

        private void RenderSideBarAction()
        {
            // Xóa FlowLayoutPanel cũ nếu có
            foreach (Control c in this.Controls.OfType<FlowLayoutPanel>().ToList())
            {
                this.Controls.Remove(c);
                c.Dispose();
            }

            // Tạo FlowLayoutPanel mới
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Name = "flowPanelSidebar";
            flowPanel.Location = new Point(0, 100);
            flowPanel.Size = new Size(263, 400); // chỉnh theo panel bạn muốn
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.WrapContents = false;     // không xuống hàng ngang
            flowPanel.AutoScroll = true;        // bật cuộn nếu nút nhiều
            flowPanel.Padding = new Padding(5); // padding xung quanh
            // Danh sách các nút
            List<SidebarItem> sidebarItems = new List<SidebarItem>()
            {
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\user.png"), Text = "Quốc Đại", OnClick = () => RenderDetailStudent(15) },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\store.png"), Text = "Marketplace", OnClick = () => renderCourse(15) },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\classroom.png"), Text = "Lớp học của tôi", OnClick = () => RenderRegisteredClasses(15) },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\calendar.png"), Text = "Lịch cá nhân", OnClick = () => { } },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\details.png"), Text = "Bài tập về nhà", OnClick = () => { } },
                new SidebarItem() {Icon = Image.FromFile(@"D:\Code\EnglishCenterManagement_WinformsApp\EnglishCenterMangement.UI\Views\Student\assets\shopping-cart.png"), Text = "Đơn hàng", OnClick = () => { } },
            };

            int buttonWidth = flowPanel.ClientSize.Width - flowPanel.Padding.Horizontal; // rộng theo panel
            int buttonHeight = 50; // chiều cao cố định

            foreach (var item in sidebarItems)
            {
                Button btn = new Button();
                Image image = new Bitmap(item.Icon, new Size(24, 24));
                btn.Image = image;
                btn.Text = "       " + item.Text;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.Click += (s, e) => item.OnClick();
                btn.Margin = new Padding(0, 0, 0, 5); // khoảng cách giữa các nút

                flowPanel.Controls.Add(btn);
            }

            // Thêm FlowLayoutPanel vào Form
            this.Controls.Add(flowPanel);
        }

        private void RenderDetailStudent(int studentId)
        {
            // Tạo control và truyền service vào
            var control = new DetailStudent(_studentService);

            // Load dữ liệu ở đây
            control.LoadDetailStudent(studentId);

            // Render vào panelControl
            control.Dock = DockStyle.Fill;
            control.Margin = new Padding(0);

            panelControl.Controls.Clear();
            panelControl.Controls.Add(control);
        }
        private void RenderRegisteredClasses(int studentId)
        {
            panelControl.Controls.Clear();

            // Tạo FlowLayoutPanel để chứa danh sách lớp đã đăng ký
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10),
                AutoSize = false
            };

            // Lấy danh sách lớp đã đăng ký
            var classes = _studentService.GetRegisteredCourses(studentId);

            if (classes == null || classes.Count == 0)
            {
                MessageBox.Show("Bạn chưa đăng ký lớp học nào");
                return;
            }

            foreach (var c in classes)
            {
                var item = new ClassStudent(); // user control hiển thị thông tin lớp
                item.LoadClassStudent(c);      // load dữ liệu lớp

                item.Width = 300;              // chiều rộng item
                item.Height = 400;             // chiều cao item
                item.Margin = new Padding(10);

                flowPanel.Controls.Add(item);
            }

            panelControl.Controls.Add(flowPanel);
        }

        private void renderCourse(int studentId)
        {
            panelControl.Controls.Clear();

            // FlowPanel để chứa danh sách khóa học
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10),
                AutoSize = false
            };

            var courses = _studentService.GetAvailableCourses(studentId);

            if (courses == null || courses.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khóa học");
                return;
            }

            foreach (var c in courses)
            {
                var item = new UC_Course(studentId, _studentService, _context);

                item.LoadCourse(c);

                item.Width = 300;
                item.Height = 400;
                item.Margin = new Padding(10);

                flowPanel.Controls.Add(item);
            }

            panelControl.Controls.Add(flowPanel);
        }


    }
}
