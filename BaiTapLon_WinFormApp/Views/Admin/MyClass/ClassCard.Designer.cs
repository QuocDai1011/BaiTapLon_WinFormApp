namespace BaiTapLon_WinFormApp.Views.Admin.MyClass
{
    partial class ClassCard
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picThumbnail;
        private Label lblClassCode;
        private Label lblType;

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
            picThumbnail = new PictureBox();
            lblClassCode = new Label();
            lblType = new Label();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            SuspendLayout();
            // 
            // picThumbnail
            // 
            picThumbnail.Location = new Point(15, 3);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(280, 160);
            picThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            picThumbnail.TabIndex = 0;
            picThumbnail.TabStop = false;
            picThumbnail.Click += OnClickAll;
            // 
            // lblClassCode
            // 
            lblClassCode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblClassCode.Location = new Point(25, 168);
            lblClassCode.Name = "lblClassCode";
            lblClassCode.Size = new Size(260, 30);
            lblClassCode.TabIndex = 1;
            lblClassCode.Click += OnClickAll;
            // 
            // lblType
            // 
            lblType.Font = new Font("Segoe UI", 10F);
            lblType.ForeColor = Color.Gray;
            lblType.Location = new Point(25, 203);
            lblType.Name = "lblType";
            lblType.Size = new Size(260, 25);
            lblType.TabIndex = 2;
            lblType.Click += OnClickAll;
            // 
            // ClassCard
            // 
            BackColor = Color.White;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(picThumbnail);
            Controls.Add(lblClassCode);
            Controls.Add(lblType);
            Cursor = Cursors.Hand;
            Name = "ClassCard";
            Size = new Size(312, 236);
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            ResumeLayout(false);
        }
    }
}
