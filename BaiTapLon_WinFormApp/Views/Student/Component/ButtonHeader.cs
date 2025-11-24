using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.UI.Views.Student.Component
{
    public class ActionItem
    {
        public Image? Icon { get; set; }
        public string? Text { get; set; }   // tên tượng trưng
        public Action? OnClick { get; set; }
    }
}
