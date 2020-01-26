using System.Collections.Generic;
using XamarinApp.MVVM;

namespace XamarinApp.Models
{
    public class HandModel : ViewModelBase
    {
        public List<string> Cards { get; set; }
        public string RoleImage { get; set; }
    }
}
