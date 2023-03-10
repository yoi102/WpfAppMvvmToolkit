using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMvvmToolkit.Core.Models
{
    public partial class MemoDto : ObservableObject
    {


        [ObservableProperty]
        private string? title;     
        [ObservableProperty]
        private string? memo;



    }
}
