using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMvvmToolkit.Core.Models
{
    public partial class UserDto : ObservableObject
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string? account;
        [ObservableProperty]
        private string? password;
  

    }

}
