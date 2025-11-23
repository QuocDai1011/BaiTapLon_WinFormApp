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
    public partial class ManageClass : UserControl
    {
        private List<ClassCard> classCards = new List<ClassCard>();

        public ManageClass(List<(string classCode, string type, string imagePath)> classData)
        {
            InitializeComponent();
            LoadClassCards(classData);
        }

        private void LoadClassCards(List<(string classCode, string type, string imagePath)> classData)
        {
            flowPanelClasses.Controls.Clear();
            classCards.Clear();

            foreach (var item in classData)
            {
                ClassCard card = new ClassCard(item.classCode, item.type, item.imagePath);
                card.CardClick += Card_CardClick;
                classCards.Add(card);
                flowPanelClasses.Controls.Add(card);
            }
        }

        private void Card_CardClick(object sender, EventArgs e)
        {
            if (sender is ClassCard card)
            {
                MessageBox.Show($"Bạn đã chọn lớp: {card.ClassCode}");
            }
        }
    }
}
