namespace BaiTapLon_WinFormApp.Views.Admin.MyClass
{
    partial class ClassCard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlCard;
        private PictureBox picThumbnail;
        private Label lblClassCode;
        private Label lblType;
        private Panel pnlShadow;

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
            pnlShadow = new Panel();
            pnlCard = new Panel();
            picThumbnail = new PictureBox();
            lblClassCode = new Label();
            lblType = new Label();
            pnlShadow.SuspendLayout();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            SuspendLayout();
            // 
            // pnlShadow
            // 
            pnlShadow.BackColor = Color.FromArgb(240, 240, 240);
            pnlShadow.Controls.Add(pnlCard);
            pnlShadow.Location = new Point(3, 3);
            pnlShadow.Name = "pnlShadow";
            pnlShadow.Size = new Size(333, 299);
            pnlShadow.TabIndex = 0;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(picThumbnail);
            pnlCard.Controls.Add(lblClassCode);
            pnlCard.Controls.Add(lblType);
            pnlCard.Cursor = Cursors.Hand;
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(330, 296);
            pnlCard.TabIndex = 0;
            pnlCard.MouseClick += ClassCard_MouseClick;
            pnlCard.MouseEnter += Card_MouseEnter;
            pnlCard.MouseLeave += Card_MouseLeave;
            // 
            // picThumbnail
            // 
            picThumbnail.Image = Properties.Resources.defaultBanner2;
            picThumbnail.Location = new Point(0, 0);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(327, 197);
            picThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            picThumbnail.TabIndex = 0;
            picThumbnail.TabStop = false;
            picThumbnail.MouseClick += ClassCard_MouseClick;
            picThumbnail.MouseEnter += Card_MouseEnter;
            picThumbnail.MouseLeave += Card_MouseLeave;
            // 
            // lblClassCode
            // 
            lblClassCode.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblClassCode.ForeColor = Color.FromArgb(33, 33, 33);
            lblClassCode.Location = new Point(0, 258);
            lblClassCode.Name = "lblClassCode";
            lblClassCode.Size = new Size(327, 28);
            lblClassCode.TabIndex = 1;
            lblClassCode.TextAlign = ContentAlignment.MiddleCenter;
            lblClassCode.MouseClick += ClassCard_MouseClick;
            lblClassCode.MouseEnter += Card_MouseEnter;
            lblClassCode.MouseLeave += Card_MouseLeave;
            // 
            // lblType
            // 
            lblType.Font = new Font("Segoe UI", 9F);
            lblType.ForeColor = Color.FromArgb(117, 117, 117);
            lblType.Location = new Point(3, 219);
            lblType.Name = "lblType";
            lblType.Size = new Size(324, 25);
            lblType.TabIndex = 2;
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            lblType.MouseClick += ClassCard_MouseClick;
            lblType.MouseEnter += Card_MouseEnter;
            lblType.MouseLeave += Card_MouseLeave;
            // 
            // ClassCard
            // 

            BackColor = Color.Transparent;
            Controls.Add(pnlShadow);
            Cursor = Cursors.Hand;
            Name = "ClassCard";
            Padding = new Padding(5);
            Size = new Size(357, 310);
            pnlShadow.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            ResumeLayout(false);

            MouseClick += ClassCard_MouseClick;
            MouseEnter += Card_MouseEnter;
            MouseLeave += Card_MouseLeave;
        }

        // Hover effects
        // Hover effects
        private void Card_MouseEnter(object sender, EventArgs e)
        {
            pnlCard.Location = new Point(-2, -2);
            pnlShadow.BackColor = Color.FromArgb(220, 220, 220);
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            pnlCard.Location = new Point(0, 0);
            pnlShadow.BackColor = Color.FromArgb(240, 240, 240);
        }
    }
}
