using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppMvvmToolkit.Core.ViewModels
{
    public partial class MainWindowViewModel : ObservableValidator
    {
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [MinLength(2)] // Any other validation attributes too...
        //[CustomValidation(typeof(RegistrationForm), nameof(ValidateName))]
        private string? content = "app";


        [RelayCommand]
        private void buttonClick()
        {
            ValidateAllProperties();
            if (HasErrors)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ja-Jp"); 
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja-Jp"); 

            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN"); 
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN"); 
            }
 
            //OnPropertyChanged(nameof( Properties.Resources.Cancel));
            //OnPropertyChanged("Cancel");
        }






    }
}
