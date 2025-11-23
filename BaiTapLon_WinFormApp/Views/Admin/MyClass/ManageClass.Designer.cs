namespace BaiTapLon_WinFormApp.Views.Admin.MyClass
{
    partial class ManageClass
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowPanelClasses;

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
            this.flowPanelClasses = new FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPanelClasses
            // 
            this.flowPanelClasses.Dock = DockStyle.Fill;
            this.flowPanelClasses.AutoScroll = true;
            this.flowPanelClasses.Padding = new Padding(10);
            this.flowPanelClasses.FlowDirection = FlowDirection.LeftToRight;
            this.flowPanelClasses.WrapContents = true;
            // 
            // MyClass
            // 
            this.Controls.Add(this.flowPanelClasses);
            this.BackColor = Color.White;
            this.Size = new Size(1000, 600);
            this.ResumeLayout(false);
        }
    }
}
