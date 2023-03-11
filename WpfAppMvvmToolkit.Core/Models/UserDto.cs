using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMvvmToolkit.Core.Models
{
    public partial class UserDto : ObservableValidator
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        [Required]
        [MinLength(5)]
        private string? account;
        [ObservableProperty]
        [Required]
        [MinLength(5)]
        private string? password;
 
    }

}
