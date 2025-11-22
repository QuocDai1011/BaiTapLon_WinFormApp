namespace BaiTapLon_WinFormApp.Views.Admin.MyClass
{
    partial class ManageClass
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnAdd;
        private FlowLayoutPanel flowPanelClasses;
        private Panel pnlContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnAdd = new Button();
            pnlContainer = new Panel();
            flowPanelClasses = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnAdd);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 15, 20, 15);
            pnlHeader.Size = new Size(1334, 80);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(438, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản Lý Lớp Học";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(0, 120, 212);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(1146, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(178, 59);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+ Thêm Lớp Mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAddClass_Click;
            btnAdd.MouseEnter += BtnAdd_MouseEnter;
            btnAdd.MouseLeave += BtnAdd_MouseLeave;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(248, 249, 250);
            pnlContainer.Controls.Add(flowPanelClasses);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 80);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(10);
            pnlContainer.Size = new Size(1334, 520);
            pnlContainer.TabIndex = 0;
            // 
            // flowPanelClasses
            // 
            flowPanelClasses.AutoScroll = true;
            flowPanelClasses.BackColor = Color.FromArgb(248, 249, 250);
            flowPanelClasses.Dock = DockStyle.Fill;
            flowPanelClasses.Location = new Point(10, 10);
            flowPanelClasses.Name = "flowPanelClasses";
            flowPanelClasses.Padding = new Padding(15);
            flowPanelClasses.Size = new Size(1314, 500);
            flowPanelClasses.TabIndex = 0;
            // 
            // ManageClass
            // 
            BackColor = Color.White;
            Controls.Add(pnlContainer);
            Controls.Add(pnlHeader);
            Name = "ManageClass";
            Size = new Size(1334, 600);
            pnlHeader.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Button hover effects
        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(0, 100, 190);
        }

        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(0, 120, 212);
        }
    }
}
