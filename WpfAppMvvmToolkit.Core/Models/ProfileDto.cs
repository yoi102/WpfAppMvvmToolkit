using CommunityToolkit.Mvvm.ComponentModel;
using System.Drawing;

namespace WpfAppMvvmToolkit.Core.Models
{
    public partial class ProfileDto : ObservableObject
    {

        [ObservableProperty]
        private string? netName;
        [ObservableProperty]
        private string? imageUrl;
        [ObservableProperty]
        private string? description;
        [ObservableProperty]
        private Image? predictImage;





    }
}
