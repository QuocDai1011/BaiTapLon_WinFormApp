using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.MyClass
{
    public partial class ClassCard : UserControl
    {
        public string ClassCode { get; private set; }
        public string Type { get; private set; }

        public int id  { get; private set; }
        public event EventHandler CardClick;
        public event EventHandler CardRightClick; // Event mới

        public ClassCard(string classCode, string type, int id)
        {
            InitializeComponent();

            ClassCode = classCode;
            Type = type;

            this.id = id;
            lblClassCode.Text = ClassCode;
            lblType.Text = Type;
        }

        // Xử lý MouseClick (phân biệt Left/Right)
        private void ClassCard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CardClick?.Invoke(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                CardRightClick?.Invoke(this, e);
            }
        }
    }
}
