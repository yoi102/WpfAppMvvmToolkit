using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMvvmToolkit.Core.Models
{
    public partial class UserInfo : ObservableObject
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string? userName;
        [ObservableProperty]
        private string? account;
        [ObservableProperty]
        private string? password;
        [ObservableProperty]
        private List<UserInfoData>? userData;

    }

}
