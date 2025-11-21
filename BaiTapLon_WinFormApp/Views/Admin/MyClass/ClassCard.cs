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
        public string ImagePath { get; private set; }

        public event EventHandler CardClick;

        public ClassCard(string classCode, string type, string imagePath)
        {
            InitializeComponent();

            ClassCode = classCode;
            Type = type;
            ImagePath = imagePath;

            LoadData();
        }

        private void LoadData()
        {
            lblClassCode.Text = ClassCode;
            lblType.Text = Type;

            string baseFolder = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\";
            string path = Path.Combine(baseFolder, ImagePath);
            picThumbnail.Image = File.Exists(path)
                ? Image.FromFile(path)
                : Properties.Resources.defaultBanner2;
        }

        private void OnClickAll(object sender, EventArgs e)
        {
            CardClick?.Invoke(this, e);
        }
    }
}
