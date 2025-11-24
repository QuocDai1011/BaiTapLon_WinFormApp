using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.UI.Views.Student.Component
{
    public class SidebarItem
    {
        public Image? Icon { get; set; }
        public string? Text { get; set; }
        public Action? OnClick { get; set; }
    }
}
